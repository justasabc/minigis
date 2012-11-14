using System;
using Npgsql; // Npgsql.dll is a .NET Data Provider for PostgreSQL
using System.Data;
using System.Windows.Forms;
using MGP_BasicObject;
using System.Collections; // MG_Geometry
using MGP_DataStorage.MGP_FileStorage;
using OSGeo.OGR; // ogr


namespace MGP_DataStorage.MGP_DatabaseStorage
{
    public class MG_PostgreSQLDbOper : MG_CommonDbOper
    {
        public MG_PostgreSQLDbOper(NpgsqlConnection conn)
            : base(conn)
        {
            
        }

        // default extent table   ext(layername,minx,miny,maxx,maxy)
        protected int CreateTableExt()
        {//-- ext(layername,minx,miny,maxx,maxy)
            //CREATE TABLE ext(layername VARCHAR, minx FLOAT8, miny FLOAT8, maxx FLOAT8, maxy FLOAT8);
            if (this.IsTableExist("ext"))
                return 0;
            string strSQL = "CREATE TABLE ext(layername VARCHAR, minx FLOAT8, miny FLOAT8, maxx FLOAT8, maxy FLOAT8);";
            return this.Run(strSQL);
        }

        protected int InsertExtent(string layername, MG_MapExtent mapExt)
        {// INSERT INTO ext(layername, minx, miny, maxx, maxy) VALUES('links', 1.1, 1.1, 2.2, 2.2);
            string strSQL = "INSERT INTO ext(layername, minx, miny, maxx, maxy) VALUES('{0}', {1}, {2}, {3}, {4});";
            strSQL = String.Format(strSQL, layername.ToLower(), mapExt.MinX, mapExt.MinY, mapExt.MaxX, mapExt.MaxY);
            return this.Run(strSQL);
        }

        protected MG_MapExtent GetExtent(string layername)
        {// SELECT minx, miny, maxx, maxy FROM ext WHERE layername = 'links';
            string strSQL = "SELECT minx, miny, maxx, maxy FROM ext WHERE layername = '{0}';";
            strSQL = String.Format(strSQL, layername.ToLower());
            NpgsqlDataReader reader = this.Select(strSQL);
            if (reader != null)
            {
                if (reader.HasRows)
                {
                    MG_MapExtent mapExt = new MG_MapExtent();
                    int fc = reader.FieldCount; // 4
                    while (reader.Read())
                    {// xmin ymin xmax ymax
                        
                            double xmin = Double.Parse(reader["minx"].ToString());
                            double ymin = Double.Parse(reader["miny"].ToString());
                            double xmax = Double.Parse(reader["maxx"].ToString());
                            double ymax = Double.Parse(reader["maxy"].ToString());
                            mapExt.SetExtent(xmin, ymin, xmax, ymax);
                       
                    }
                    reader.Close();
                    reader.Dispose();
                    return mapExt;
                }
            }
            return null;
        }


        public void ImportToDB(string filePath)
        {
           MG_Layer layer = MG_ShapeFileOper.LoadShapeFile(filePath);
           this.ImportLayer(layer);
        }

        public void ExportToFile(string table, string filePath)
        {
            MG_Layer layer = this.ExportLayer(table);
            MG_ShapeFileOper.CreateShapeFile(layer, filePath);
        }

        public void ImportLayer(MG_Layer layer)
        {
            if (layer == null)
             return;
            // stop multi same data
            if (this.IsTableExist(layer.GetLayerName()))
                return;

            this.CreateTable(layer.FieldSet, layer.Type);
            string layerName = layer.FieldSet.GetName();
            int fc = layer.GetFeatureCount();
            // save ext
            this.CreateTableExt();
            this.InsertExtent(layerName,layer.Extent);
            for (int i=0; i< fc;i++)
            {
                MG_Feature f = layer.GetFeature(i);
                if (f.Geometry.Type == layer.Type)
                {
                    this.Insert(layerName, f.ValueSet, f.Geometry);
                }
            }
        }

        protected MG_FeatureSet GetFeatureSet(MG_FieldSet fieldSet,string table)
        {
            NpgsqlDataReader reader = this.SelectAll(table);
            if (reader == null || !reader.HasRows)
            return null;
           
            MG_FeatureSet featureSet = new MG_FeatureSet();
            int fc = reader.FieldCount; // 4
            while (reader.Read())
            {// oid f1,f2,f3... geom 
                MG_Feature f = new MG_Feature(fieldSet);
                MG_ValueSet valueSet = new MG_ValueSet();
                string oid = reader["oid"].ToString();
                string geom = reader["geomtext"].ToString();
                        
                for (int i = 1; i < fc-1; i++)
                {
                    string str = reader[i].ToString();
                    MG_Value value = new MG_Value(i - 1, str);
                    valueSet.Add(value);
                }
                f.ValueSet = valueSet;
                f.Geometry = MG_ShapeFileOper.AsGeometry(geom);
                featureSet.Add(f);
            }
            reader.Close();
            reader.Dispose();
            return featureSet;
        }

        protected MG_FieldSet GetFieldSet(string table)
        {
            ArrayList columns = this.GetColumnNames(table);
            ArrayList types = this.GetColumnTypes(table);
            if (columns == null || types == null)
                return null;
            int columnCount = columns.Count;
            int typeCount = types.Count;
            if (columnCount != typeCount)
                return null;
            MG_FieldSet fieldSet = new MG_FieldSet(table);
            
            // oid .... geom
            for (int i = 0; i < columnCount;i++ )
            {
                string column = columns[i].ToString();
                string type = types[i].ToString();
                if (!column.Equals("oid") && !column.Equals("geom"))
                {
                    // oid      name                geom         no       length
                    // integer character varying  USER-DEFINED  integer double precision
                    MG_FieldDBType dbType = MG_FieldDBType.VARCHAR;
                    if (type.Equals("integer"))
                    {
                        dbType = MG_FieldDBType.INTEGER;
                    }
                    else if (type.Equals("character varying"))
                    {
                        dbType = MG_FieldDBType.VARCHAR;
                    }
                    else if (type.Equals("double precision"))
                    {
                        dbType = MG_FieldDBType.FLOAT8;
                    }

                    MG_Field field = new MG_Field(column,dbType);
                    fieldSet.Add(field);
                }
            }

            return fieldSet;
        }

        public MG_Layer ExportLayer(string table)
        {
            MG_Layer mgLayer = new MG_Layer();
            mgLayer.SetLayerName(table);//

            // read ext
            mgLayer.Extent = this.GetExtent(table);
            MG_FieldSet fieldSet = this.GetFieldSet(table);
            mgLayer.FieldSet = fieldSet;// collect data
            mgLayer.FeatureSet = this.GetFeatureSet(mgLayer.GetFieldSet(), table);
            mgLayer.Type = mgLayer.FeatureSet.GetAt(0).Geometry.Type;
            return mgLayer;
        }

    }
}
