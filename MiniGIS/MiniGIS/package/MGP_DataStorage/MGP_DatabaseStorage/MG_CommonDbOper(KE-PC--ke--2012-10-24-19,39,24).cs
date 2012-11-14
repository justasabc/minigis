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
        public MG_CommonDbOper()
        {
            this.ConnectionString = new MG_ConnectionString();
            this.m_strConn = this.ConnectionString.ToString();
        }

        private void sql_GetTableNames(out string strSQL, out NpgsqlParameter[] sqlParams)
        { // select f_table_name from public.geometry_columns;
            strSQL = "select f_table_name from public.geometry_columns;";
            sqlParams = null;
        }

        public ArrayList GetTableNames()
        {
            this.sql_GetTableNames(out m_strSQL, out m_sqlParams);
            NpgsqlDataReader reader = this.SelectBySQL(m_strConn, m_strSQL, m_sqlParams);

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
                    return tables;
                }
            }
            return null;
        }

        private void sql_GetGeomType(string table, out string strSQL, out NpgsqlParameter[] sqlParams)
        { // select type from public.geometry_columns where f_table_name='point';
            strSQL = "select type from public.geometry_columns where f_table_name='{0}';";
            strSQL = String.Format(strSQL, table);
            sqlParams = null;
        }

        public string GetGeomType(string table)
        {
            if (!this.IsTableExist(table))
                return null;
            object value = this.sql_GetGeomType(table,m_strConn, m_strSQL, m_sqlParams);
            // true false   value.ToString(); // True False
            return (string)value;
        }


        private void sql_IsTableExist(string table, out string strSQL, out NpgsqlParameter[] sqlParams)
        {// select exists(select * from information_schema.tables where table_name='point');
            strSQL = "select exists(select * from information_schema.tables where table_name='{0}');";
            strSQL = String.Format(strSQL, table.ToLower());
            sqlParams = null;
        }

        public bool IsTableExist(string table)
        {
            this.sql_IsTableExist(table, out m_strSQL, out m_sqlParams);
            object value = this.GetValue(m_strConn, m_strSQL, m_sqlParams);
            // true false   value.ToString(); // True False
            return (bool)value;
        }

        public void sql_IsColumnExist(string table, string column, out string strSQL, out NpgsqlParameter[] sqlParams)
        {// select exists (select column_name from information_schema.columns where table_name='point' and column_name='geom');
            strSQL = "select exists (select column_name from information_schema.columns where table_name='{0}' and column_name='{1}');";
            strSQL = String.Format(strSQL, table.ToLower(), column.ToLower());
            sqlParams = null;
        }

        public bool IsColumnExist(string table, string column)
        {
            this.sql_IsColumnExist(table, column, out m_strSQL, out m_sqlParams);
            object value = this.GetValue(m_strConn, m_strSQL, m_sqlParams);
            // true false   value.ToString(); // True False
            return (bool)value;
        }

        private void sql_CreateTable(MG_FieldSet fieldSet, MG_GeometryType gt, out string strSQL, out NpgsqlParameter[] sqlParams)
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
                mid += String.Format(m, field.Name, field.Type.ToString());
            }
            string end = "); SELECT AddGeometryColumn('public','{0}','geom',0,'{1}',2);";
            end = String.Format(end, table, gt.ToString());

            strSQL = front + mid + end;
            sqlParams = null;
        }

        private void sql_Insert(string table, MG_ValueSet valueSet, MG_Geometry geometry, out string strSQL, out NpgsqlParameter[] sqlParams)
        {// oid, field1, field2, field3, field4,...fieldN, geom
            //  INSERT INTO point(f1, f2, f3, geom) VALUES('v1', 'v2', 'v3', ST_GeometryFromText('POINT (100 200)',0));
            string str1 = "INSERT INTO {0}(";
            str1 = String.Format(str1, table);

            // oid name geom cityno length
            // name cityno length
            ArrayList columns = this.GetTableColumnNames(table);
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

            strSQL = str1+str2+str3+str4+str5;
            sqlParams = null;
        }

        public int Insert(string table, MG_ValueSet valueSet, MG_Geometry geometry)
        {
            this.sql_Insert(table, valueSet, geometry, out m_strSQL, out m_sqlParams);
            return this.RunSQL(m_strConn, m_strSQL, m_sqlParams);
        }

        public int CreateTable(MG_FieldSet fieldSet, MG_GeometryType gt)
        {
            if (this.IsTableExist(fieldSet.GetName()))
                return 0;
            this.sql_CreateTable(fieldSet, gt, out m_strSQL, out m_sqlParams);
            return this.RunSQL(m_strConn, m_strSQL, m_sqlParams);
        }

        private void sql_DropTable(string table, out string strSQL, out NpgsqlParameter[] sqlParams)
        {
            strSQL = "DROP TABLE {0};";
            strSQL = String.Format(strSQL, table.ToLower());
            sqlParams = null;
        }

        public int DropTable(string table)
        {
            if (!this.IsTableExist(table))
                return 0;
            this.sql_DropTable(table, out m_strSQL, out m_sqlParams);
            return this.RunSQL(m_strConn, m_strSQL, m_sqlParams);
        }

        private void sql_Count(string table, out string strSQL, out NpgsqlParameter[] sqlParams)
        {
            strSQL = "SELECT count(*) FROM {0};";
            strSQL = String.Format(strSQL, table.ToLower());
            sqlParams = null;
        }

        public int Count(string table)
        {
            this.sql_Count(table, out m_strSQL, out m_sqlParams);
            object value = this.GetValue(m_strConn, m_strSQL, m_sqlParams);
            return int.Parse(value.ToString());
        }

        private void sql_GetTableColumnNames(string table, out string strSQL, out NpgsqlParameter[] sqlParams)
        {// select column_name from information_schema.columns where table_name='point';
            strSQL = "select column_name from information_schema.columns where table_name='{0}';";
            strSQL = String.Format(strSQL, table.ToLower());
            sqlParams = null;
        }

        public ArrayList GetTableColumnNames(string table)
        {
            this.sql_GetTableColumnNames(table, out m_strSQL, out m_sqlParams);
            NpgsqlDataReader reader = this.SelectBySQL(m_strConn, m_strSQL, m_sqlParams);

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
                    return columns;
                }
            }
            return null;
        }

        private string sqlSelectAll(string table)
        {
            // SELECT oid, f1, f2, ST_AsText(geom) as geomText FROM {0};
            ArrayList columns = this.GetTableColumnNames(table);
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

        private void sql_SelectAll(string table, out string strSQL, out NpgsqlParameter[] sqlParams)
        {
            strSQL = this.sqlSelectAll(table);
            sqlParams = null;
        }

        public NpgsqlDataReader SelectAll(string table)
        {
            this.sql_SelectAll(table, out m_strSQL, out m_sqlParams);
            return this.SelectBySQL(m_strConn, m_strSQL, m_sqlParams);
        }

        private void sql_SelectByOid(string table, int oid, out string strSQL, out NpgsqlParameter[] sqlParams)
        {// SELECT {0} FROM {1};
            // SELECT {0} FROM {1} WHERE oid = {2};
            string selectAll = this.sqlSelectAll(table);
            int index = selectAll.IndexOf(";");
            string header = selectAll.Remove(index); // remove ;
            strSQL = header + " WHERE oid = {0};";
            strSQL = String.Format(strSQL, oid);
            sqlParams = null;
        }

        public NpgsqlDataReader SelectByOid(string table, int oid)
        {
            this.sql_SelectByOid(table, oid, out m_strSQL, out m_sqlParams);
            return this.SelectBySQL(m_strConn, m_strSQL, m_sqlParams);
        }

        private void sql_SelectByName(string table, string name, out string strSQL, out NpgsqlParameter[] sqlParams)
        {// SELECT {0} FROM {1};
            // SELECT {0} FROM {1} WHERE name LIKE '%{2}%';
            string selectAll = this.sqlSelectAll(table);
            int index = selectAll.IndexOf(";");
            string header = selectAll.Remove(index); // remove ;
            strSQL = header + " WHERE name LIKE '%{0}%';";
            strSQL = String.Format(strSQL, name);
            // SELECT oid, name, ST_AsText(geom) as geomText FROM point WHERE name LIKE '%'zun'%';  // WRONG
            // SELECT oid, name, ST_AsText(geom) as geomText FROM point WHERE name LIKE '%zun%';    // RIGHT
            sqlParams = null;
        }

        public NpgsqlDataReader SelectByName(string table, string name)
        {
            this.sql_SelectByName(table, name, out m_strSQL, out m_sqlParams);
            return this.SelectBySQL(m_strConn, m_strSQL, m_sqlParams);
        }

        /// <summary>
        /// Interactively update the database table by DataGridView and NpgsqlDataAdapter
        /// Insert Update Delete
        /// </summary>
        private void UpdateTable(string strConn, string strSQL, NpgsqlParameter[] sqlParams, DataGridView gridView, out NpgsqlDataAdapter da, out DataSet ds)
        {
            ds = new DataSet();
            da = this.GetDataAdapter(strConn, strSQL, sqlParams, false);
            da.Fill(ds);
            gridView.DataSource = ds.Tables[0];
            gridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

        public void UpdateTable_SelectAll(string table, DataGridView gridView, out NpgsqlDataAdapter da, out DataSet ds)
        {
            this.sql_SelectAll(table, out m_strSQL, out m_sqlParams);
            this.UpdateTable(m_strConn, m_strSQL, m_sqlParams, gridView, out da, out ds);
        }

        public void UpdateTable_SelectByOid(string table, int oid, DataGridView gridView, out NpgsqlDataAdapter da, out DataSet ds)
        {
            this.sql_SelectByOid(table, oid, out m_strSQL, out m_sqlParams);
            this.UpdateTable(m_strConn, m_strSQL, m_sqlParams, gridView, out da, out ds);
        }

        public void UpdateTable_SelectByName(string table, string name, DataGridView gridView, out NpgsqlDataAdapter da, out DataSet ds)
        {
            this.sql_SelectByName(table, name, out m_strSQL, out m_sqlParams);
            this.UpdateTable(m_strConn, m_strSQL, m_sqlParams, gridView, out da, out ds);
        }

        private void sql_DeleteAll(string table, out string strSQL, out NpgsqlParameter[] sqlParams)
        {
            strSQL = "DELETE FROM {0};";
            strSQL = String.Format(strSQL, table.ToLower());
            sqlParams = null;
        }

        public int DeleteAll(string table)
        {
            this.sql_DeleteAll(table, out m_strSQL, out m_sqlParams);
            return this.RunSQL(m_strConn, m_strSQL, m_sqlParams);
        }

        private void sql_Delete(string table, int oid, out string strSQL, out NpgsqlParameter[] sqlParams)
        {
            strSQL = "DELETE FROM {0} WHERE oid = {1};";
            strSQL = String.Format(strSQL, table.ToLower(), oid);
            sqlParams = null;
        }

        // NOT COMMON
        public int Delete(string table, int oid)
        {
            this.sql_Delete(table, oid, out m_strSQL, out m_sqlParams);
            return this.RunSQL(m_strConn, m_strSQL, m_sqlParams);
        }

        private void sql_UpdateColumn(string table, int oid, string column, object value, out string strSQL, out NpgsqlParameter[] sqlParams)
        {// UPDATE point SET name = 'kezunlin' WHERE oid = 1;
            // "UPDATE {0} SET geom = ST_GeometryFromText({1},0)  WHERE oid = {2};";
            strSQL = "UPDATE {0} SET {1} = {2} WHERE oid = {3};";
            strSQL = String.Format(strSQL, table.ToLower(), column, value, oid);
            sqlParams = null;
        }

        public int UpdateColumn(string table, int oid, string column, object value)
        {// column exist
            if (!IsColumnExist(table, column))
                return 0;
            this.sql_UpdateColumn(table, oid, column, value, out m_strSQL, out m_sqlParams);
            return this.RunSQL(m_strConn, m_strSQL, m_sqlParams);
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


        private void sql_AddColumn(string table, string column, string type, out string strSQL, out NpgsqlParameter[] sqlParams)
        {// ALTER TABLE point ADD COLUMN address VARCHAR;
            strSQL = "ALTER TABLE {0} ADD COLUMN {1} {2};";
            strSQL = String.Format(strSQL, table.ToLower(), column.ToLower(), type);
            sqlParams = null;
        }

        public int AddColumn(string table, string column, string type)
        {
            if (this.IsColumnExist(table, column))
                return 0;
            this.sql_AddColumn(table, column, type, out m_strSQL, out m_sqlParams);
            return this.RunSQL(this.ConnectionString.ToString(), m_strSQL, m_sqlParams);
        }

        private void sql_DropColumn(string table, string column, out string strSQL, out NpgsqlParameter[] sqlParams)
        {// ALTER TABLE point DROP COLUMN address RESTRICT;
            strSQL = "ALTER TABLE {0} DROP COLUMN {1} RESTRICT;";
            strSQL = String.Format(strSQL, table.ToLower(), column.ToLower());
            sqlParams = null;
        }

        public int DropColumn(string table, string column)
        {
            if (!this.IsColumnExist(table, column))
                return 0;
            this.sql_DropColumn(table, column, out m_strSQL, out m_sqlParams);
            return this.RunSQL(this.ConnectionString.ToString(), m_strSQL, m_sqlParams);
        }

        private void sql_RenameColumn(string table, string column, string newcolumn, out string strSQL, out NpgsqlParameter[] sqlParams)
        {// ALTER TABLE point RENAME COLUMN address TO city;
            strSQL = "ALTER TABLE {0} RENAME COLUMN {1} TO {2};";
            strSQL = String.Format(strSQL, table.ToLower(), column.ToLower(), newcolumn.ToLower());
            sqlParams = null;
        }

        public int RenameColumn(string table, string column, string newcolumn)
        {
            if (!this.IsColumnExist(table, column) || this.IsColumnExist(table, newcolumn))
                return 0;
            this.sql_RenameColumn(table, column, newcolumn, out m_strSQL, out m_sqlParams);
            return this.RunSQL(this.ConnectionString.ToString(), m_strSQL, m_sqlParams);
        }

        private void sql_RenameTable(string table, string newtable, out string strSQL, out NpgsqlParameter[] sqlParams)
        {// ALTER TABLE point RENAME TO pointnew;
            strSQL = "ALTER TABLE {0} RENAME TO {1};";
            strSQL = String.Format(strSQL, table.ToLower(), newtable.ToLower());
            sqlParams = null;
        }

        public int RenameTable(string table, string newtable)
        {
            if (!this.IsTableExist(table) || this.IsTableExist(newtable))
                return 0;
            this.sql_RenameTable(table, newtable, out m_strSQL, out m_sqlParams);
            return this.RunSQL(this.ConnectionString.ToString(), m_strSQL, m_sqlParams);
        }

        private void sql_InsertNameGeom(string table, string name, string geom, out string strSQL, out NpgsqlParameter[] sqlParams)
        {
            strSQL = "INSERT INTO {0}(name,geom) VALUES('{1}',ST_GeometryFromText('{2}',0));";
            strSQL = String.Format(strSQL, table.ToLower(), name, geom);
            sqlParams = null;
        }

        public int InsertNameGeom(string table, string name, string wkt)
        {
            this.sql_InsertNameGeom(table, name, wkt, out m_strSQL, out m_sqlParams);
            return this.RunSQL(this.ConnectionString.ToString(), m_strSQL, m_sqlParams);
        }

        private string m_strConn;
        private string m_strSQL;
        private NpgsqlParameter[] m_sqlParams;

        public MG_ConnectionString ConnectionString;// Association in PowerDesigner
        //public MG_ConnectionString ConnectionString {set;get;}  attribute
    }
}