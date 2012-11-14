/***********************************************************************
 * Module:  MG_Geometry.cs
 * Author:  ke
 * Purpose: Definition of the Class MGP_BasicObject.MiniGIS.MG_Geometry
 ***********************************************************************/

using System;
using OSGeo.OGR;//Geometry
using System.Drawing;
using MGP_Display;


namespace MGP_BasicObject
{
    public class MG_Geometry
   {
      public MG_Geometry()
      {
          this.Type = MG_GeometryType.NONE;
      }

        public static MG_Geometry CreateGeometryFromWKT(string wkt)
      {

          return null;
      }
      
      /// virtural --->override
      public virtual string AsWKT()
      {
          return null;
      }
      
      public virtual string AsWKT_Reduced()
      {
          return null;
      }
      
      public byte[] AsWKB()
      {// Points--->wkt--->Geometry--->wkb
          Geometry g = Geometry.CreateFromWkt(this.AsWKT());//call subclass.AsWKT()
          if (g == null)
              return null;
          byte[] wkb = null;
          int wkbSize = g.WkbSize();
          if (wkbSize > 0)
          {
              // wkb
              wkb = new byte[wkbSize];
              g.ExportToWkb(wkb);
          }
          return wkb;
      }
      
      public virtual MG_Geometry Envelope()
      {
          return null;
      }
      
      public int IsEmpty()
      {
         // TODO: implement
         return 0;
      }
      
      public int IsSimple()
      {
         // TODO: implement
         return 0;
      }
      
      public MG_Geometry Boundary()
      {
         // TODO: implement
         return null;
      }
   
      public MG_GeometryType Type
      {
         get
         ;
         set
         ;
      }
   }
}