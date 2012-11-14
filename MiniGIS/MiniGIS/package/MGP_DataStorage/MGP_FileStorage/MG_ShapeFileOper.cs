/***********************************************************************
 * Module:  MG_ShapefileReader.cs
 * Author:  ke
 * Purpose: Definition of the Class MGP_DataStorage.MGP_FileStorage.MiniGIS.MG_ShapefileReader
 ***********************************************************************/

using System;
using OSGeo.OGR; // ogr
using OSGeo.OSR; // sr
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

using MGP_BasicObject;//
using System.IO;

namespace MGP_DataStorage.MGP_FileStorage
{
    class MG_ShapeFileOper
    {
        public static MG_Layer LoadShapeFile(string filePath)
        {// xxx\line.shp
            MG_Layer mgLayer = new MG_Layer();
            try
            {
                Ogr.RegisterAll();
                DataSource ds = Ogr.Open(filePath, 0);
                Layer layer = ds.GetLayerByIndex(0);

                mgLayer.SetLayerName(layer.GetName());
                mgLayer.SetLayerType(AsGeometryType(layer.GetGeomType()));

                Envelope ext = new Envelope();
                layer.GetExtent(ext, 1);
                mgLayer.Extent = AsExtent(ext);// collect data
                mgLayer.FieldSet = AsFieldSet(layer.GetLayerDefn());// collect data

                int fc = layer.GetFeatureCount(1);
                for (int fid = 0; fid < fc; fid++)
                {
                    Feature f = layer.GetFeature(fid);
                    MG_Feature mgFeature = AsFeature(f);
                    mgLayer.AddFeature(mgFeature);// collect data
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            return mgLayer;
        }

        public static void CreateShapeFile(MG_Layer mgLayer, string filePath)
        {
            string dataSourceName = filePath;
            string layerName = Path.GetFileNameWithoutExtension(filePath);
            mgLayer.SetLayerPath(filePath);
            try
            {
                Ogr.RegisterAll();
                string driverName = "ESRI Shapefile";
                Driver driver = Ogr.GetDriverByName(driverName);

                if (File.Exists(dataSourceName))
                {
                    //System.IO.File.Delete(dataSourceName);// only remove xxx.shp
                    driver.DeleteDataSource(dataSourceName);// reomve xxx.shp dbf shx
                }

                DataSource ds = driver.CreateDataSource(dataSourceName, new string[] { });
                wkbGeometryType gt = TowkbGeometryType(mgLayer.Type);// retrieve data
                Layer layer = ds.CreateLayer(layerName, null, gt, new string[] { });
                // create three files  xxx.shp xxx.dbf xxx.shx

                // fieldset 
                int fieldCount = mgLayer.FieldSet.Count();
                for (int i = 0; i < fieldCount; i++)
                {
                    MG_Field field = mgLayer.FieldSet.GetAt(i);
                    FieldDefn def = ToFieldDefn(field);
                    layer.CreateField(def, 1);
                }

                // feature
                int featureCount = mgLayer.GetFeatureCount();
                for (int i = 0; i < featureCount; i++)
                {
                    Feature f = ToFeature(mgLayer.GetFeature(i));
                    layer.CreateFeature(f);
                    f.Dispose();
                }
                
                // flush data to file
                layer.Dispose();
                ds.Dispose();
                driver.Dispose();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static MG_Map LoadMap(string mapPath)
        {
            string mapName = Path.GetFileNameWithoutExtension(mapPath);

            MG_Map map = new MG_Map();
            map.SetMapName(mapName);
            map.SetMapPath(mapPath);

            StreamReader sr = new StreamReader(mapPath); // stream reader
            int count = Int32.Parse(sr.ReadLine()); // layerCount
            for (int i = 0; i < count; i++)
            {
                string layerPath = sr.ReadLine(); // layerPath

                MG_Layer layer = LoadShapeFile(layerPath);
                map.AddLayer(layer);
            }
            sr.Close();
            return map;
        }

        public static void CreateMap(MG_Map map, string mapPath)
        {//  c:\\data\\hello.map    c:\\data\\layer.shp
            if (map == null)
                return;
            // set MapPath
            map.SetMapPath(mapPath);

            // save map  (layerCount  n * layerPath)
            int count = map.GetLayerCount();

            StreamWriter sw = new StreamWriter(mapPath); // stream writer
            sw.WriteLine(count); // layerCount

            for (int i = 0; i < count; i++)
            {
                string mapFolder = Path.GetDirectoryName(mapPath);
                MG_Layer layer = map.GetLayer(i);

                string layerPath = mapFolder + "\\" + layer.GetLayerName() + ".shp";
                CreateShapeFile(layer, layerPath); //save layer

                sw.WriteLine(layerPath); // layerPath
            }
            sw.Close();
        }

        public static MG_MapExtent AsExtent(Envelope ext)
        {
            return new MG_MapExtent(ext.MinX, ext.MinY, ext.MaxX, ext.MaxY);
        }

        public static MG_Geometry AsGeometry(string wkt)
        {
            return AsGeometry(Geometry.CreateFromWkt(wkt));
        }

        public static MG_Geometry AsGeometry(Geometry g)
        {
            MG_Geometry geometry = new MG_Geometry();
            if (g.GetGeometryType() == wkbGeometryType.wkbPoint)
            {
                geometry = AsPoint(g);
            }
            else if (g.GetGeometryType() == wkbGeometryType.wkbMultiPoint)
            {
                geometry = AsMultiPoint(g);
            }
            else if (g.GetGeometryType() == wkbGeometryType.wkbLineString)
            {
                geometry = AsLineString(g);
            }
            else if (g.GetGeometryType() == wkbGeometryType.wkbMultiLineString)
            {
                geometry = AsMultiLineString(g);
            }
            else if (g.GetGeometryType() == wkbGeometryType.wkbPolygon)
            {
                geometry = AsPolygon(g);
            }
            else if (g.GetGeometryType() == wkbGeometryType.wkbMultiPolygon)
            {
                geometry = AsMultiPolygon(g);
            }
            return geometry;
        }

        //Geometry GetPointCount   GetGeometryCount
        //POINT 1 0
        //MULTIPOINT 0  3(POINT)
        //LINESTRING 3  0
        //MULTILINESTRING 0  3(LINESTRING)
        //POLYGON 0  3(LINESTRING)
        //MULTIPOLYGON 0 3(POLYGON)
        private static MG_Point AsPoint(Geometry g)
        {
            //MG_Point point = new MG_Point();
            //int pointCount = g.GetPointCount();
            //if (pointCount == 1)
            //{
            //    point.x = g.GetX(0);
            //    point.y = g.GetY(0);
            //}
            //return point;
            return new MG_Point(g.GetX(0), g.GetY(0));
        }

        private static MG_MultiPoint AsMultiPoint(Geometry g)
        {
            MG_MultiPoint multiPoint = new MG_MultiPoint();
            int geometryCount = g.GetGeometryCount();
            for (int i = 0; i < geometryCount; i++)
            {
                MG_Point point = AsPoint(g.GetGeometryRef(i));
                multiPoint.Add(point);
            }
            return multiPoint;
        }

        private static MG_LineString AsLineString(Geometry g)
        {
            MG_LineString lineString = new MG_LineString();
            int pointCount = g.GetPointCount();
            for (int i = 0; i < pointCount; i++)
            {
                MG_Point point = new MG_Point(g.GetX(i), g.GetY(i));
                lineString.Add(point);
            }
            return lineString;
        }

        private static MG_MultiLineString AsMultiLineString(Geometry g)
        {
            MG_MultiLineString multiLineString = new MG_MultiLineString();
            int geometryCount = g.GetGeometryCount();
            for (int i = 0; i < geometryCount; i++)
            {
                MG_LineString lineString = AsLineString(g.GetGeometryRef(i));
                multiLineString.Add(lineString);
            }
            return multiLineString;
        }

        private static MG_Polygon AsPolygon(Geometry g)
        {
            MG_Polygon polygon = new MG_Polygon();
            int geometryCount = g.GetGeometryCount();
            for (int i = 0; i < geometryCount; i++)
            {
                MG_LineString lineString = AsLineString(g.GetGeometryRef(i));
                polygon.Add(lineString);
            }
            return polygon;
        }

        private static MG_MultiPolygon AsMultiPolygon(Geometry g)
        {
            MG_MultiPolygon multiPolygon = new MG_MultiPolygon();
            int geometryCount = g.GetGeometryCount();
            for (int i = 0; i < geometryCount; i++)
            {
                MG_Polygon polygon = AsPolygon(g.GetGeometryRef(i));
                multiPolygon.Add(polygon);
            }
            return multiPolygon;
        }

        public static MG_GeometryType AsGeometryType(wkbGeometryType type)
        {
            MG_GeometryType geomType;
            switch (type)
            {
                case wkbGeometryType.wkbPoint:
                    geomType = MG_GeometryType.POINT;
                    break;
                case wkbGeometryType.wkbMultiPoint:
                    geomType = MG_GeometryType.MULTIPOINT;

                    break;
                case wkbGeometryType.wkbLineString:
                    geomType = MG_GeometryType.LINESTRING;
                    break;
                case wkbGeometryType.wkbMultiLineString:
                    geomType = MG_GeometryType.MULTILINESTRING;
                    break;
                case wkbGeometryType.wkbPolygon:
                    geomType = MG_GeometryType.POLYGON;
                    break;
                case wkbGeometryType.wkbMultiPolygon:
                    geomType = MG_GeometryType.MULTIPOLYGON;
                    break;
                default:
                    geomType = MG_GeometryType.NONE;
                    break;
            }
            return geomType;
        }

        public static wkbGeometryType TowkbGeometryType(MG_GeometryType type)
        {
            wkbGeometryType geomType;
            switch (type)
            {
                case MG_GeometryType.POINT:
                    geomType = wkbGeometryType.wkbPoint;
                    break;
                case MG_GeometryType.MULTIPOINT:
                    geomType = wkbGeometryType.wkbMultiPoint;
                    break;
                case MG_GeometryType.LINESTRING:
                    geomType = wkbGeometryType.wkbLineString;
                    break;
                case MG_GeometryType.MULTILINESTRING:
                    geomType = wkbGeometryType.wkbMultiLineString;
                    break;
                case MG_GeometryType.POLYGON:
                    geomType = wkbGeometryType.wkbPolygon;
                    break;
                case MG_GeometryType.MULTIPOLYGON:
                    geomType = wkbGeometryType.wkbMultiPolygon;
                    break;
                default:
                    geomType = wkbGeometryType.wkbUnknown;
                    break;
            }
            return geomType;
        }

        public static MG_FieldDBType AsFieldDBType(FieldType type)
        {
            MG_FieldDBType dbtype = MG_FieldDBType.VARCHAR;
            if (type == FieldType.OFTString)
            {
                dbtype = MG_FieldDBType.VARCHAR;
            }
            else if (type == FieldType.OFTInteger)
            {
                dbtype = MG_FieldDBType.INTEGER;
            }
            else if (type == FieldType.OFTReal)
            {
                dbtype = MG_FieldDBType.FLOAT8;
            }
            else if (type == FieldType.OFTDate)
            {
                dbtype = MG_FieldDBType.DATE;
            }
            else if (type == FieldType.OFTTime)
            {
                dbtype = MG_FieldDBType.TIME;
            }
            else if (type == FieldType.OFTDateTime)
            {
                dbtype = MG_FieldDBType.TIMESTAMP;
            }
            return dbtype;
        }

        public static FieldType ToFieldType(MG_FieldDBType dbtype)
        {
            FieldType type = FieldType.OFTString;
            if (dbtype == MG_FieldDBType.VARCHAR)
            {
                type = FieldType.OFTString;
            }
            else if (dbtype == MG_FieldDBType.INTEGER)
            {
                type = FieldType.OFTInteger;
            }
            else if (dbtype == MG_FieldDBType.FLOAT8)
            {
                type = FieldType.OFTReal;
            }
            else if (dbtype == MG_FieldDBType.DATE)
            {
                type = FieldType.OFTDate;
            }
            else if (dbtype == MG_FieldDBType.TIME)
            {
                type = FieldType.OFTTime;
            }
            else if (dbtype == MG_FieldDBType.TIMESTAMP)
            {
                type = FieldType.OFTDateTime;
            }
            return type;
        }

        public static MG_Field AsField(FieldDefn f)
        {
            MG_Field mgField = new MG_Field();
            mgField.Name = f.GetNameRef();//collect data
            mgField.Type = AsFieldDBType(f.GetFieldType());//collect data
            mgField.Width = f.GetWidth();//collect data
            mgField.Precision = f.GetPrecision();//collect data
            return mgField;
        }

        public static FieldDefn ToFieldDefn(MG_Field field)
        {
            FieldType type = ToFieldType(field.Type);
            FieldDefn def = new FieldDefn(field.Name, type);
            def.SetWidth(field.Width);
            def.SetPrecision(field.Precision);
            return def;
        }

        public static MG_FieldSet AsFieldSet(FeatureDefn f)
        {
            MG_FieldSet fieldSet = new MG_FieldSet(f.GetName());// name
            int count = f.GetFieldCount();
            for (int i = 0; i < count; i++)
            {
                MG_Field field = AsField(f.GetFieldDefn(i));
                fieldSet.Add(field);
            }
            return fieldSet;
        }

        public static FeatureDefn ToFeatureDefn(MG_FieldSet fieldSet)
        {
            FeatureDefn def = new FeatureDefn(null);
            for (int i = 0; i < fieldSet.Count(); i++)
            {
                MG_Field field = fieldSet.GetAt(i);
                FieldDefn fdef = ToFieldDefn(field);
                def.AddFieldDefn(fdef);
            }
            return def;
        }

        public static MG_Feature AsFeature(Feature f)
        {
            FeatureDefn def = f.GetDefnRef();
            MG_FieldSet fieldSet = AsFieldSet(def);
            MG_Feature mgFeature = new MG_Feature(fieldSet);//collect data

            // geometry
            Geometry g = f.GetGeometryRef();
            MG_Geometry geometry = AsGeometry(g);
            string wkt = geometry.AsWKT();// Test
            mgFeature.SetGeometry(geometry);//collect data

            // symbol
            string styleString = f.GetStyleString();
            //f.SetStyleString(styleString);

            // attribute value
            MG_ValueSet valueSet = new MG_ValueSet();
            int fid = f.GetFID();
            int nFieldCount = f.GetFieldCount();
            for (int iField = 0; iField < nFieldCount; iField++)
            {
                FieldDefn fdef = def.GetFieldDefn(iField);
                FieldType fieldType = fdef.GetFieldType();//OFTInteger OFTString OFTString

                MG_Value mgValue = new MG_Value();
                mgValue.Index = iField;// collect data
                //collect data
                if (fieldType == FieldType.OFTString)
                {
                    mgValue.Value = f.GetFieldAsString(iField);
                }
                else if (fieldType == FieldType.OFTInteger)
                {
                    mgValue.Value = f.GetFieldAsInteger(iField);
                }
                else if (fieldType == FieldType.OFTReal)
                {
                    mgValue.Value = f.GetFieldAsDouble(iField);
                }
                else if (fieldType == FieldType.OFTDateTime)
                {
                    int year, month, day, hour, minute, second, flag;
                    f.GetFieldAsDateTime(iField, out year, out month, out day, out hour, out minute, out second, out flag);
                    mgValue.Value = new DateTime(year, month, day, hour, minute, second, flag);
                }
                valueSet.Add(mgValue);
            }
            mgFeature.ValueSet = valueSet;//collect data

            return mgFeature;
        }

        public static Feature ToFeature(MG_Feature mgFeature)
        {
            // field set
            FeatureDefn def = ToFeatureDefn(mgFeature.GetFieldSet());
            Feature f = new Feature(def);

            // field value
            int fieldCount = mgFeature.GetFieldCount();
            for (int i = 0; i < fieldCount; i++)
            {
                object value = mgFeature.GetValue(i).Value;
                FieldType fieldType = f.GetFieldType(i);
                if (fieldType == FieldType.OFTString)
                {
                    if (value != null)
                    {
                        f.SetField(i, value.ToString());
                    }
                }
                else if (fieldType == FieldType.OFTInteger)
                {// id name url
                    if (value != null)
                    {
                        f.SetField(i, Int32.Parse(value.ToString()));
                    }
                }
                else if (fieldType == FieldType.OFTReal)
                {
                    if (value != null)
                    {
                        f.SetField(i, Double.Parse(value.ToString()));
                    }
                }
                else if (fieldType == FieldType.OFTDateTime)
                {
                    if (value != null)
                    {
                        DateTime dt = (DateTime)value;
                        f.SetField(i, dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
                    }
                }
            }
            //geometry
            string wkt = mgFeature.GetGeometry().AsWKT();
            Geometry g = Geometry.CreateFromWkt(wkt);
            // test
            Envelope env = new Envelope();
            g.GetEnvelope(env);

            f.SetGeometry(g);

            //f.SetStyleString(null);

            return f;
        }

        public static void Test()
        {
            // Register format(s)
            Ogr.RegisterAll();
            // Open data souce
            string shapefile = @"C:\data\Links\Links.shp";

            DataSource ds = Ogr.Open(shapefile, 0);
            if (ds == null)
            {
                MessageBox.Show("can't open " + shapefile);
                return;
            }

            // Get driver
            Driver driver = ds.GetDriver();
            if (driver == null)
            {
                MessageBox.Show("can't get driver.");
                return;
            }

            //driver.name   //  "ESRI Shapefile"

            // iterating through the layers
            int nLayerCount = ds.GetLayerCount();//1
            for (int iLayer = 0; iLayer < nLayerCount; iLayer++)
            {
                Layer layer = ds.GetLayerByIndex(iLayer);

                if (layer == null)
                {
                    MessageBox.Show("FAILURE: Couldn't fetch advertised layer " + iLayer);
                    return;
                }
                ReportLayer(layer);
            }

        }

        public static void Test2()
        {
            try
            {
                Ogr.RegisterAll();
                string shapefile = @"C:\data\Links\Links.shp";
                DataSource ds = Ogr.Open(shapefile, 0);
                Driver driver = ds.GetDriver();

                int nLayerCount = ds.GetLayerCount();//1
                for (int iLayer = 0; iLayer < nLayerCount; iLayer++)
                {
                    Layer layer = ds.GetLayerByIndex(iLayer);
                    string layerName = layer.GetName();
                    int fc = layer.GetFeatureCount(1);

                    Envelope env = new Envelope();
                    layer.GetExtent(env, 1);

                    //MessageBox.Show("test sr");
                    OSGeo.OSR.SpatialReference sr = layer.GetSpatialRef();
                    string sr_wkt;
                    sr.ExportToPrettyWkt(out sr_wkt, 1);

                    layer.GetName();
                    FeatureDefn def = layer.GetLayerDefn();
                    def.GetName();
                    for (int iField = 0; iField < def.GetFieldCount(); iField++)
                    {
                        FieldDefn fdef = def.GetFieldDefn(iField);
                        string fieldName = fdef.GetName();//Id Name URL
                        FieldType fieldType = fdef.GetFieldType();//OFTInteger OFTString OFTString
                        string fieldTypeName = fdef.GetFieldTypeName(fdef.GetFieldType());//Integer String String
                        int width = fdef.GetWidth();//6 50 254
                        int precision = fdef.GetPrecision();//0 0 0
                    }

                    for (int fid = 0; fid < layer.GetFeatureCount(1); fid++)
                    {
                        Feature f = layer.GetFeature(fid);
                        int id = f.GetFID();
                        int nFiledCount = f.GetFieldCount();
                        Geometry geom = f.GetGeometryRef();

                        // retrive geometry data
                        //this.Geometrys.Add(geom);

                        string geomName = geom.GetGeometryName();//POINT
                        string geomType = geom.GetGeometryType().ToString();//wkbPoint

                        Envelope geom_env = new Envelope();
                        geom.GetEnvelope(geom_env);

                        // wkt
                        string geom_wkt;
                        geom.ExportToWkt(out geom_wkt);//"POINT (-63.490966216299803 46.66247022944782)"

                        int wkbSize = geom.WkbSize();
                        if (wkbSize > 0)
                        {
                            // wkb
                            byte[] geom_wkb = new byte[wkbSize];
                            geom.ExportToWkb(geom_wkb);
                            string str_wkb = BitConverter.ToString(geom_wkb);

                            // wkb--->wkt
                            Geometry geom2 = Geometry.CreateFromWkb(geom_wkb);
                            string geom2_wkt;
                            geom2.ExportToWkt(out geom2_wkt);
                        }

                        f.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        public static void Write(string dataSourceName, string layerName)
        {
            try
            {
                Ogr.RegisterAll();
                string driverName = "ESRI Shapefile";
                Driver driver = Ogr.GetDriverByName(driverName);

                if (System.IO.File.Exists(dataSourceName))
                {
                    //System.IO.File.Delete(dataSourceName);// only remove xxx.shp
                    driver.DeleteDataSource(dataSourceName);// reomve xxx.shp dbf shx
                }

                DataSource ds = driver.CreateDataSource(dataSourceName, new string[] { });

                Layer layer;

                int i;
                for (i = 0; i < ds.GetLayerCount(); i++)
                {
                    layer = ds.GetLayerByIndex(i);
                    if (layer != null && layer.GetLayerDefn().GetName() == layerName)
                    {
                        MessageBox.Show("Layer already existed. Recreating it.\n");
                        ds.DeleteLayer(i);
                        break;
                    }
                }

                layer = ds.CreateLayer(layerName, null, wkbGeometryType.wkbPoint, new string[] { });
                // create three files  xxx.shp xxx.dbf xxx.shx

                // add layer attribute field (fieldName at most 10 chars)
                // StringField --->StringFiel
                // IntField--->IntField
                // DoubleField--->DoubleFiel
                // DateField--->DateField

                FieldDefn fdef = new FieldDefn("StringField", FieldType.OFTString);
                fdef.SetWidth(32);
                layer.CreateField(fdef, 1);
                fdef = new FieldDefn("IntField", FieldType.OFTInteger);
                layer.CreateField(fdef, 1);
                fdef = new FieldDefn("DoubleField", FieldType.OFTReal);
                layer.CreateField(fdef, 1);
                fdef = new FieldDefn("DateField", FieldType.OFTDate);
                layer.CreateField(fdef, 1);

                // add feature 1
                Feature f = new Feature(layer.GetLayerDefn());
                // attribute value
                f.SetField(0, "pkuHelloGIS");
                f.SetField(1, (int)99);
                f.SetField(2, (float)3.14);
                f.SetField(3, 2012, 10, 17, 18, 24, 30, 0);

                // geometry value
                Geometry g = Geometry.CreateFromWkt("POINT(100 200)");
                f.SetGeometry(g);

                layer.CreateFeature(f);
                f.Dispose();

                // add feature 2
                Feature f2 = new Feature(layer.GetLayerDefn());
                // attribute value
                f2.SetField(0, "kezunlin");
                f2.SetField(1, (int)100);
                f2.SetField(2, (float)100.0);
                f2.SetField(3, 2007, 3, 15, 18, 24, 30, 0);

                // geometry value
                Geometry g2 = Geometry.CreateFromWkt("POINT(100 100)");
                f2.SetGeometry(g2);

                layer.CreateFeature(f2);
                // flush data to file
                f2.Dispose();
                layer.Dispose();
                ds.Dispose();
                driver.Dispose();

                MessageBox.Show("CreateShapefile Successfully.");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private static void ReportLayer(Layer layer)
        {
            //layer info
            string layerName = layer.GetName();//Links
            string layerName2 = layer.GetLayerDefn().GetName();//Links
            int fc = layer.GetFeatureCount(1);//16
            Envelope ext = new Envelope();
            layer.GetExtent(ext, 1);
            /* -------------------------------------------------------------------- */
            /*      Reading the spatial reference                                   */
            /* -------------------------------------------------------------------- */
            OSGeo.OSR.SpatialReference sr = layer.GetSpatialRef();
            string srs_wkt;
            if (sr != null)
            {
                sr.ExportToPrettyWkt(out srs_wkt, 1);
            }
            else
                srs_wkt = "(unknown)";

            // feature definition
            FeatureDefn def = layer.GetLayerDefn();
            //string layerName2 = def.GetName();//Links

            /* -------------------------------------------------------------------- */
            /*      Reading the fields                                              */
            /* -------------------------------------------------------------------- */
            int nFieldCount = def.GetFieldCount();//3
            for (int iField = 0; iField < nFieldCount; iField++)
            {
                // field definition
                FieldDefn fdef = def.GetFieldDefn(iField);
                // field info
                string fieldName = fdef.GetName();//Id Name URL
                string fieldNameRef = fdef.GetNameRef();// Id Name URL
                FieldType fieldType = fdef.GetFieldType();//OFTInteger OFTString OFTString
                string fieldTypeName = fdef.GetFieldTypeName(fdef.GetFieldType());//Integer String String
                int width = fdef.GetWidth();//6 50 254
                int precision = fdef.GetPrecision();//0 0 0
            }

            /* -------------------------------------------------------------------- */
            /*      Reading the shapes                                              */
            /* -------------------------------------------------------------------- */
            for (int fid = 0; fid < layer.GetFeatureCount(1); fid++)
            {
                Feature f = layer.GetFeature(fid);
                ReportFeature(f, def);
                f.Dispose();
            }
            //Feature f;
            //while ((f = layer.GetNextFeature()) != null)
            //{
            //   ReportFeature(f, def);
            //   f.Dispose();
            //}
        }

        private static void ReportFeature(Feature f, FeatureDefn def)
        {
            //string layerName = def.GetName();//Links
            int fid = f.GetFID();//0 1 2 3...15
            int nFieldCount = f.GetFieldCount();//3
            for (int iField = 0; iField < nFieldCount; iField++)
            {
                FieldDefn fdef = def.GetFieldDefn(iField);
                string fieldName = fdef.GetName();//Id Name URL
                string fieldNameRef = fdef.GetNameRef();//Id Name URL
                string fieldTypeName = fdef.GetFieldTypeName(fdef.GetFieldType());//Integer String String

                if (f.IsFieldSet(iField))
                {
                    if (fdef.GetFieldType() == FieldType.OFTStringList)
                    {
                        string[] sList = f.GetFieldAsStringList(iField);
                        foreach (string s in sList)
                        {
                        }
                    }
                    else if (fdef.GetFieldType() == FieldType.OFTIntegerList)
                    {
                        int count;
                        int[] iList = f.GetFieldAsIntegerList(iField, out count);
                        for (int i = 0; i < count; i++)
                        {
                        }
                    }
                    else if (fdef.GetFieldType() == FieldType.OFTRealList)
                    {
                        int count;
                        double[] iList = f.GetFieldAsDoubleList(iField, out count);
                        for (int i = 0; i < count; i++)
                        {
                        }
                    }
                    else if (fdef.GetFieldType() == FieldType.OFTString)
                    {
                        string strField = f.GetFieldAsString(iField);
                    }
                    else if (fdef.GetFieldType() == FieldType.OFTInteger)
                    {
                        int nField = f.GetFieldAsInteger(iField);
                    }
                    else if (fdef.GetFieldType() == FieldType.OFTReal)
                    {
                        double fField = f.GetFieldAsDouble(iField);
                    }
                    else
                    {
                        // other types
                    }
                }
            }

            if (f.GetStyleString() != null)
            {
                string style = f.GetStyleString();
            }

            // feature's geometry info
            Geometry geom = f.GetGeometryRef();
            if (geom != null)
            {
                string geomName = geom.GetGeometryName();//POINT
                string geomType = geom.GetGeometryType().ToString();//wkbPoint

                int geometryCount = geom.GetGeometryCount();//0
                for (int i = 0; i < geometryCount; i++)
                {
                    Geometry sub_geom = geom.GetGeometryRef(i);
                    if (sub_geom != null)
                    {
                        string sub_geomName = sub_geom.GetGeometryName();
                        string sub_geomType = sub_geom.GetGeometryType().ToString();
                    }
                }

                Envelope env = new Envelope();
                geom.GetEnvelope(env);

                string geom_wkt;
                geom.ExportToWkt(out geom_wkt);//POINT(-63.4,46.6)
            }

        }

    }
}