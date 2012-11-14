/***********************************************************************
 * Module:  MG_BaseDbOper.cs
 * Author:  ke
 * Purpose: Definition of the Class MiniGIS.MG_BaseDbOper
 ***********************************************************************/

using System;
using Npgsql; // Npgsql.dll is a .NET Data Provider for PostgreSQL
using System.Data;
using System.Windows.Forms;
using MGP_BasicObject; // MG_Geometry

namespace MGP_DataStorage.MGP_DatabaseStorage
{
   public class MG_BaseDbOper
   {
        private NpgsqlConnection m_gConn;
        private NpgsqlCommand m_gCommnd;
        public MG_BaseDbOper(NpgsqlConnection conn)
        {
            this.m_gConn = conn;
            this.m_gCommnd = new NpgsqlCommand();
            this.m_gCommnd.Connection = conn;
        }

       /// <summary>
      /// DataSet ---NpgsqlDataAdapter ---Database
      /// </summary>
      public NpgsqlDataAdapter GetDataAdapter(string strSQL)
      {// Use NpgsqlCommandBuilder and SelectCommand--->Auto generate InsertCommand UpdateCommand DeleteCommand
          try
          {
              m_gCommnd.CommandText = strSQL;
              NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(m_gCommnd);//associate
              //InsertCommand  UpdateCommand DeleteCommand SelectCommand = m_sqlCommand;
      
              // Initialize the InsertCommand UpdateCommand DeleteCommand of NpgsqlDataAdapter by NpgsqlCommandBuilder.
              NpgsqlCommandBuilder cb = new NpgsqlCommandBuilder(dataAdapter);
              dataAdapter.InsertCommand = cb.GetInsertCommand();
              dataAdapter.UpdateCommand = cb.GetUpdateCommand();
              dataAdapter.DeleteCommand = cb.GetDeleteCommand();
              return dataAdapter;
          }
          catch (System.Exception ex)
          {
              MessageBox.Show(ex.ToString());
              return null;
          }
      }
      
      /// <summary>
      /// ExecuteNonQuery (Insert,Update,Delete,StoredProcedure)
      /// Generally speaking, parameter binding is the best way to build dynamic SQL statements in your client code.
      /// </summary>
      public int Run(string strSQL)
      {
          try
          {
              m_gCommnd.CommandText = strSQL;
              return m_gCommnd.ExecuteNonQuery();//affected_rows
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.ToString());
              return -1;
          }
      }
      
      /// <summary>
      /// ExecuteReader (SELECT,StoredProcedure)
      /// Generally speaking, parameter binding is the best way to build dynamic SQL statements in your client code.
      ///  ExecuteReader:return one or more datasets NpgsqlDataReader
      ///  "select * from table1"   
      /// "select * from tablea; select * from tableb"
      /// </summary>
      public NpgsqlDataReader Select(string strSQL)
      {
          try
          {
              m_gCommnd.CommandText = strSQL;
              return m_gCommnd.ExecuteReader(CommandBehavior.Default); 
              // Use reader.Close() to close the connection
          }
          catch (System.Exception ex)
          {
              MessageBox.Show(ex.ToString());
              return null;
          }
      }
      
      /// <summary>
      /// ExecuteScalar (SELECT)
      /// return only one single value
      /// "select version()"
      /// NOTE: 
      /// You may also use ExecuteScalar against queries that return a recordset, such as 
      /// "select count(*) from table1". However, when calling a function that returns a set of 
      /// one or more records, only the first column of the first row is returned 
      /// (DataSet.Tables[0].Rows[0][0]). In general, any query that returns a single value 
      /// should be called with Command.ExecuteScalar.
      /// </summary>
      public object GetValue(string strSQL)
      {
          try
          {
              m_gCommnd.CommandText = strSQL;
              return m_gCommnd.ExecuteScalar();// SELECT
          }
          catch (System.Exception ex)
          {
              MessageBox.Show(ex.ToString());
              return null;
          }
      }
   
      public void testDataReader(NpgsqlDataReader reader)
      {
          if (reader != null)
          {
              if (reader.HasRows)
              {
                  while (reader.Read())
                  {// oid geomText       
                      //string oid = reader["oid"].ToString();
                      //string geomText = reader["geomText"].ToString();
                      for (int i = 0; i < reader.FieldCount; i++)
                      {
                          string value = reader[i].ToString();
                      }
                  }
                  reader.Close();
                  reader.Dispose();
              }
          }
      }
      
      public void testDataAdapter(NpgsqlDataAdapter da)
      {
          DataSet ds = new DataSet();
          da.Fill(ds);
          DataTable dt = ds.Tables[0];
          //this.dataGridView1.DataSource = dt;
          //DataTableReader reader = ds.CreateDataReader();
          for (int i = 0; i < dt.Rows.Count; i++)
          {
              DataRow dr = dt.Rows[i];
              string oid = dr[0].ToString();
              string name = dr[1].ToString();
              string geomwkt = dr[2].ToString();
          }
      }
   
   }
}