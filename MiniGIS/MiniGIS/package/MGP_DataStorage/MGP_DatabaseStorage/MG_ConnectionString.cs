/***********************************************************************
 * Module:  MG_ConnectionString.cs
 * Author:  ke
 * Purpose: Definition of the Class MiniGIS.MG_ConnectionString
 ***********************************************************************/

using System;
using MGP_BasicObject;

namespace MGP_DataStorage.MGP_DatabaseStorage
{
   public class MG_ConnectionString
   {
      public MG_ConnectionString()
      {
          this.Server = MG_Constant.Server;
          this.Port = MG_Constant.Port;
          this.UserId = MG_Constant.UserId;
          this.Password = MG_Constant.Password;
          this.Database = MG_Constant.Database; 
          //this.MaxPoolSize = "100";
      }
       

       public void SetConnectionString(string server,string port,string userid,string password,string database)
      {
          this.Server = server;
          this.Port = port;
          this.UserId = userid;
          this.Password = password;
          this.Database = database; 
      }
      
      public override string ToString()
      {//  "Server=localhost;Port=5432;User Id=postgres;Password=111;Database=testdb;"
          string toString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", this.Server, this.Port, this.UserId, this.Password, this.Database);
          return toString;
      }
   
      public string Server
      {
         get
         ;
         set
         ;
      }
      
      public string Port
      {
         get
         ;
         set
         ;
      }
      
      public string UserId
      {
         get
         ;
         set
         ;
      }
      
      public string Password
      {
         get
         ;
         set
         ;
      }
      
      public string Database
      {
         get
         ;
         set
         ;
      }
   
   }
}