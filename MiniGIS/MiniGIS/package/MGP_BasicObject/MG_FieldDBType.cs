using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGP_BasicObject
{

    /* 
   Data Type : VARCHAR INTEGER  FLOAT8  DATE  TIMESTAMP
   VARCHAR VARCHAR(30) varchar varchar(30) character varying(30)
   INT2
   INT INT4   INTEGER
   INT8
   FLOAT4  REAL
   FLOAT8  DOUBLE PRECISION
   DATE
   TIME
   TIMESTAMP
     */

    //CREATE TABLE point2 ( oid SERIAL PRIMARY KEY, name1 VARCHAR, name2 VARCHAR); SELECT AddGeometryColumn('public','point2','geom',0,'POINT',2);
   
     public enum MG_FieldDBType
    {
         VARCHAR,
         INTEGER,
         FLOAT8,
         DATE,
         TIME,
         TIMESTAMP
    }
}
