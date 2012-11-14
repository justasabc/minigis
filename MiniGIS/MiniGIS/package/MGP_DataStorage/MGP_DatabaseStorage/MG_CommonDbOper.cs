/***********************************************************************
 * Module:  MG_PostgreSQLDbOper.cs
 * Author:  ke
 * Purpose: Definition of the Class MiniGIS.MG_PostgreSQLDbOper
 ***********************************************************************/

using System;
using Npgsql; // Npgsql.dll is a .NET Data Provider for PostgreSQL
using System.Data;
using System.Windows.Forms;
using MGP_BasicObject;
using System.Collections; // MG_Geometry



namespace MGP_DataStorage.MGP_DatabaseStorage
{
    public class MG_CommonDbOper : MG_BaseDbOper
    {
        public MG_CommonDbOper (NpgsqlConnection conn) 
            : base(conn)
        {
            
        }

        private string sql_GetTableNames()
        { // select f_table_name from public.geometry_columns;
            string strSQL = "select f_table_name from public.geometry_columns;";
            return strSQL;
        }

        public ArrayList GetTableNames()
        {
            string strSQL = this.sql_GetTableNames();
            NpgsqlDataReader reader = this.Select(strSQL);

            if (reader != null)
            {
                if (reader.HasRows)
                {
                    ArrayList tables = new ArrayList();
                    int fc = reader.FieldCount; // 1
                    while (reader.Read())
                    {// oid f1,f2,f3... geom 
                        for (int i = 0; i < fc; i++)
                        {
                            string table = reader[0].ToString();
                            tables.Add(table);
                        }
                    }
                    reader.Close();
                    reader.Dispose();
                    return tables;
                }
            }
            return null;
        }

        private string sql_GetGeomType(string table)
        { // select type from public.geometry_columns where f_table_name='point';
            string strSQL = "select type from public.geometry_columns where f_table_name='{0}';";
             strSQL = String.Format(strSQL, table);
            return strSQL;
        }

        public string GetGeomType(string table)
        {
            if (!this.IsTableExist(table))
                return null;
            string strSQL = this.sql_GetGeomType(table);
            object value = this.GetValue(strSQL);
            // POINT LINESTRING POLYGON MULTIPOINT MULTILINESTRING MULTIPOLYGON
            return (string)value;
        }


        private string sql_IsTableExist(string table)
        {// select exists(select * from information_schema.tables where table_name='point');
            string strSQL = "select exists(select * from information_schema.tables where table_name='{0}');";
            strSQL = String.Format(strSQL, table.ToLower());
            return strSQL;
        }

        public bool IsTableExist(string table)
        {
            string strSQL = this.sql_IsTableExist(table);
            object value = this.GetValue(strSQL);
            // true false   value.ToString(); // True False
            return (bool)value;
        }

        public string sql_IsColumnExist(string table, string column)
        {// select exists (select column_name from information_schema.columns where table_name='point' and column_name='geom');
            string strSQL = "select exists (select column_name from information_schema.columns where table_name='{0}' and column_name='{1}');";
            strSQL = String.Format(strSQL, table.ToLower(), column.ToLower());
            return strSQL;
        }

        public bool IsColumnExist(string table, string column)
        {
            string strSQL = this.sql_IsColumnExist(table, column);
            object value = this.GetValue(strSQL);
            // true false   value.ToString(); // True False
            return (bool)value;
        }

        private string sql_CreateTable(MG_FieldSet fieldSet, MG_GeometryType gt)
        {// oid, field1, field2, field3, field4,...fieldN, geom
            //CREATE TABLE point2 ( oid SERIAL PRIMARY KEY, name1 VARCHAR, name2 VARCHAR); SELECT AddGeometryColumn('public','point2','geom',0,'POINT',2);
            // table name, column name must be lowercase, e.g.   pointTABLE --->pointtable

            string front = "CREATE TABLE {0} ( oid SERIAL PRIMARY KEY";
            string table = fieldSet.GetName().ToLower();
            front = String.Format(front, table);

            string m = ", {0} {1}";
            string mid = "";
            for (int i = 0; i < fieldSet.Count(); i++)
            {
                MG_Field field = fieldSet.GetAt(i);
                mid += String.Format(m, field.Name.ToLower(), field.Type.ToString());
            }
            string end = "); SELECT AddGeometryColumn('public','{0}','geom',0,'{1}',2);";
            end = String.Format(end, table, gt.ToString());

            string strSQL = front + mid + end;
            return strSQL;
        }

        public int CreateTable(MG_FieldSet fieldSet, MG_GeometryType gt)
        {
            if (this.IsTableExist(fieldSet.GetName()))
                return 0;
            string strSQL = this.sql_CreateTable(fieldSet, gt);
            return this.Run(strSQL);
        }

        private string sql_Insert(string table, MG_ValueSet valueSet, MG_Geometry geometry)
        {// oid, field1, field2, field3, field4,...fieldN, geom
            //  INSERT INTO point(f1, f2, f3, geom) VALUES('v1', 'v2', 'v3', ST_GeometryFromText('POINT (100 200)',0));
            string str1 = "INSERT INTO {0}(";
            str1 = String.Format(str1, table);

            // oid name geom cityno length
            // name cityno length
            ArrayList columns = this.GetColumnNames(table);
            string str2 = "";
            string str4 = "";
            if (columns!= null && valueSet!=null)
            {
                string temp1 = "{0}, ";
                string temp2 = "'{0}', ";
                int countField = columns.Count; //5 
                int countValue = valueSet.Count(); // 3
                if (countField-2 == countValue) // oid geom
                {
                    for (int i = 0; i < countField; i++)
                    {
                        string column = columns[i].ToString();
                        if (!column.Equals("oid") && !column.Equals("geom"))
                        {
                            str2 += String.Format(temp1, column);
                        }
                    }
                    for (int j = 0; j < countValue;j++ )
                    {
                        str4 += String.Format(temp2, valueSet.GetAt(j).Value);
                    }
                }
            }
            string str3 = "geom) VALUES(";
            string str5 = "ST_GeometryFromText('{0}',0));";
            str5 = String.Format(str5, geometry.AsWKT());

            string strSQL = str1 + str2 + str3 + str4 + str5;
            return strSQL;
        }

        public int Insert(string table, MG_ValueSet valueSet, MG_Geometry geometry)
        {
            string strSQL = this.sql_Insert(table, valueSet, geometry);
            return this.Run(strSQL);
        }

        private string sql_DropTable(string table)
        {
            string strSQL = "DROP TABLE {0};";
            strSQL = String.Format(strSQL, table.ToLower());
            return strSQL;
        }

        public int DropTable(string table)
        {
            if (!this.IsTableExist(table))
                return 0;
            string strSQL = this.sql_DropTable(table);
            return this.Run(strSQL);
        }

        private string sql_Count(string table)
        {
            string strSQL = "SELECT count(*) FROM {0};";
            strSQL = String.Format(strSQL, table.ToLower());
            return strSQL;
        }

        public int Count(string table)
        {
            string strSQL = this.sql_Count(table);
            object value = this.GetValue(strSQL);
            return int.Parse(value.ToString());
        }

        private string sql_GetColumnTypes(string table)
        {// select data_type from information_schema.columns where table_name='point';
            string strSQL = "select data_type from information_schema.columns where table_name='{0}';";
            strSQL = String.Format(strSQL, table.ToLower());
            return strSQL;
        }

        public ArrayList GetColumnTypes(string table)
        {
            string strSQL = this.sql_GetColumnTypes(table);
            NpgsqlDataReader reader = this.Select(strSQL);

            if (reader != null)
            {
                if (reader.HasRows)
                {
                    ArrayList types = new ArrayList();
                    int fc = reader.FieldCount; // 1
                    while (reader.Read())
                    {// oid f1,f2,f3... geom 
                        for (int i = 0; i < fc; i++)
                        {
                            string type = reader[0].ToString();
                            types.Add(type);
                        }
                    }
                    reader.Close();
                    reader.Dispose();
                    return types;
                }
            }
            return null;
        }

        private string sql_GetColumnNames(string table)
        {// select column_name from information_schema.columns where table_name='point';
            string strSQL = "select column_name from information_schema.columns where table_name='{0}';";
            strSQL = String.Format(strSQL, table.ToLower());
            return strSQL;
        }

        public ArrayList GetColumnNames(string table)
        {
            string strSQL = this.sql_GetColumnNames(table);
            NpgsqlDataReader reader = this.Select(strSQL);

            if (reader != null)
            {
                if (reader.HasRows)
                {
                    ArrayList columns = new ArrayList();
                    int fc = reader.FieldCount; // 1
                    while (reader.Read())
                    {// oid f1,f2,f3... geom 
                        for (int i = 0; i < fc; i++)
                        {
                            string column = reader[0].ToString();
                            columns.Add(column);
                        }
                    }
                    reader.Close();
                    reader.Dispose();
                    return columns;
                }
            }
            return null;
        }

        private string sqlSelectAll(string table)
        {
            // SELECT oid, f1, f2, ST_AsText(geom) as geomText FROM {0};
            ArrayList columns = this.GetColumnNames(table);
            string strSQL = "SELECT {0} FROM {1};";
            // oid f1 f2 f3 ... geom
            string column = "oid";
            //  oid , f1, f2
            string c = ", {0}";
            if (columns != null)
            {
                int count = columns.Count;
                for (int i = 1; i < columns.Count; i++)
                {
                    string temp = columns[i].ToString();
                    if (temp.Equals("geom"))
                    {
                        temp = "ST_AsText(geom) as geomtext";
                    }
                    column += String.Format(c, temp);
                }
            }

            strSQL = String.Format(strSQL, column, table.ToLower());
            return strSQL;
        }

        private string sql_SelectAll(string table)
        {
            string strSQL = this.sqlSelectAll(table);
            return strSQL;
        }

        public NpgsqlDataReader SelectAll(string table)
        {
            string strSQL = this.sql_SelectAll(table);
            return this.Select(strSQL);
        }

        private string sql_SelectByOid(string table, int oid)
        {// SELECT {0} FROM {1};
            // SELECT {0} FROM {1} WHERE oid = {2};
            string selectAll = this.sqlSelectAll(table);
            int index = selectAll.IndexOf(";");
            string header = selectAll.Remove(index); // remove ;
            string strSQL = header + " WHERE oid = {0};";
            strSQL = String.Format(strSQL, oid);
            return strSQL;
        }

        public NpgsqlDataReader SelectByOid(string table, int oid)
        {
            string strSQL = this.sql_SelectByOid(table, oid);
            return this.Select(strSQL);
        }

        private string sql_SelectByName(string table, string name)
        {// SELECT {0} FROM {1};
            // SELECT {0} FROM {1} WHERE name LIKE '%{2}%';
            string selectAll = this.sqlSelectAll(table);
            int index = selectAll.IndexOf(";");
            string header = selectAll.Remove(index); // remove ;
            string strSQL = header + " WHERE name LIKE '%{0}%';";
            strSQL = String.Format(strSQL, name);
            // SELECT oid, name, ST_AsText(geom) as geomText FROM point WHERE name LIKE '%'zun'%';  // WRONG
            // SELECT oid, name, ST_AsText(geom) as geomText FROM point WHERE name LIKE '%zun%';    // RIGHT
            return strSQL;
        }

        public NpgsqlDataReader SelectByName(string table, string name)
        {
            string strSQL = this.sql_SelectByName(table, name);
            return this.Select(strSQL);
        }

        /// <summary>
        /// Interactively update the database table by DataGridView and NpgsqlDataAdapter
        /// Insert Update Delete
        /// </summary>
        private void UpdateTable(string strSQL, DataGridView gridView, out NpgsqlDataAdapter da, out DataSet ds)
        {
            ds = new DataSet();
            da = this.GetDataAdapter(strSQL);
            da.Fill(ds);
            gridView.DataSource = ds.Tables[0];
            gridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

        // private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //  Save modified data back into database   
        //    this.Validate();
        //    //this.da.Update(ds, ds.Tables[0].TableName);
        //}

        }

        public void UpdateTable_SelectAll(string table, DataGridView gridView, out NpgsqlDataAdapter da, out DataSet ds)
        {
            string strSQL = this.sql_SelectAll(table);
            this.UpdateTable(strSQL,  gridView, out da, out ds);
        }

        public void UpdateTable_SelectByOid(string table, int oid, DataGridView gridView, out NpgsqlDataAdapter da, out DataSet ds)
        {
            string strSQL = this.sql_SelectByOid(table, oid);
            this.UpdateTable(strSQL, gridView, out da, out ds);
        }

        public void UpdateTable_SelectByName(string table, string name, DataGridView gridView, out NpgsqlDataAdapter da, out DataSet ds)
        {
            string strSQL = this.sql_SelectByName(table, name);
            this.UpdateTable(strSQL, gridView, out da, out ds);
        }

        private string sql_DeleteAll(string table)
        {
            string strSQL = "DELETE FROM {0};";
            strSQL = String.Format(strSQL, table.ToLower());
            return strSQL;
        }

        public int DeleteAll(string table)
        {
            string strSQL = this.sql_DeleteAll(table);
            return this.Run(strSQL);
        }

        private string sql_Delete(string table, int oid)
        {
            string strSQL = "DELETE FROM {0} WHERE oid = {1};";
            strSQL = String.Format(strSQL, table.ToLower(), oid);
            return strSQL;
        }

        // NOT COMMON
        public int Delete(string table, int oid)
        {
            string strSQL = this.sql_Delete(table, oid);
            return this.Run(strSQL);
        }

        private string sql_UpdateColumn(string table, int oid, string column, object value)
        {// UPDATE point SET name = 'kezunlin' WHERE oid = 1;
            // "UPDATE {0} SET geom = ST_GeometryFromText({1},0)  WHERE oid = {2};";
            string strSQL = "UPDATE {0} SET {1} = {2} WHERE oid = {3};";
            strSQL = String.Format(strSQL, table.ToLower(), column, value, oid);
            return strSQL;
        }

        public int UpdateColumn(string table, int oid, string column, object value)
        {// column exist
            if (!IsColumnExist(table, column))
                return 0;
            string strSQL = this.sql_UpdateColumn(table, oid, column, value);
            return this.Run(strSQL);
        }

        public int UpdateGeom(string table, int oid, string wkt)
        {
            // "UPDATE {0} SET geom = ST_GeometryFromText('{1}',0)  WHERE oid = {2};";
            string column = "geom";
            string value = "ST_GeometryFromText('{0}',0)";
            value = String.Format(value, wkt);
            return this.UpdateColumn(table, oid, column, value);
        }

        public int UpdateString(string table, int oid, string column, string value)
        {
            string finalValue = " '{0}' ";
            finalValue = String.Format(finalValue, value);
            return this.UpdateColumn(table, oid, column, finalValue);
        }

        public int UpdateNumber(string table, int oid, string column, object value)
        {// Integer 12  Float8  3.14
            return this.UpdateColumn(table, oid, column, value);
        }

        private string sql_AddColumn(string table, string column, string type)
        {// ALTER TABLE point ADD COLUMN address VARCHAR;
            string strSQL = "ALTER TABLE {0} ADD COLUMN {1} {2};";
            strSQL = String.Format(strSQL, table.ToLower(), column.ToLower(), type);
            return strSQL;
        }

        public int AddColumn(string table, string column, string type)
        {
            if (this.IsColumnExist(table, column))
                return 0;
            string strSQL = this.sql_AddColumn(table, column, type);
            return this.Run(strSQL);
        }

        private string sql_DropColumn(string table, string column)
        {// ALTER TABLE point DROP COLUMN address RESTRICT;
            string strSQL = "ALTER TABLE {0} DROP COLUMN {1} RESTRICT;";
            strSQL = String.Format(strSQL, table.ToLower(), column.ToLower());
            return strSQL;
        }

        public int DropColumn(string table, string column)
        {
            if (!this.IsColumnExist(table, column))
                return 0;
            string strSQL = this.sql_DropColumn(table, column);
            return this.Run(strSQL);
        }

        private string sql_RenameColumn(string table, string column, string newcolumn)
        {// ALTER TABLE point RENAME COLUMN address TO city;
            string strSQL = "ALTER TABLE {0} RENAME COLUMN {1} TO {2};";
            strSQL = String.Format(strSQL, table.ToLower(), column.ToLower(), newcolumn.ToLower());
            return strSQL;
        }

        public int RenameColumn(string table, string column, string newcolumn)
        {
            if (!this.IsColumnExist(table, column) || this.IsColumnExist(table, newcolumn))
                return 0;
            string strSQL = this.sql_RenameColumn(table, column, newcolumn);
            return this.Run(strSQL);
        }

        private string sql_RenameTable(string table, string newtable)
        {// ALTER TABLE point RENAME TO pointnew;
            string strSQL = "ALTER TABLE {0} RENAME TO {1};";
            strSQL = String.Format(strSQL, table.ToLower(), newtable.ToLower());
            return strSQL;
        }

        public int RenameTable(string table, string newtable)
        {
            if (!this.IsTableExist(table) || this.IsTableExist(newtable))
                return 0;
            string strSQL = this.sql_RenameTable(table, newtable);
            return this.Run(strSQL);
        }

        private string sql_InsertNameGeom(string table, string name, string geom)
        {
            string strSQL = "INSERT INTO {0}(name,geom) VALUES('{1}',ST_GeometryFromText('{2}',0));";
            strSQL = String.Format(strSQL, table.ToLower(), name, geom);
            return strSQL;
        }

        public int InsertNameGeom(string table, string name, string wkt)
        {
            string strSQL = this.sql_InsertNameGeom(table, name, wkt);
            return this.Run(strSQL);
        }
    }
}