/***********************************************************************
 * Module:  MG_GeometryType.cs
 * Author:  ke
 * Purpose: Definition of the Enum MGP_BasicObject.MiniGIS.MG_GeometryType
 ***********************************************************************/

using System;

namespace MGP_BasicObject
{
   public enum MG_GeometryType
   {
      NONE,
      POINT,
      MULTIPOINT,
      LINESTRING,
      MULTILINESTRING,
      POLYGON,
      MULTIPOLYGON,
      GEOMETRYCOLLECTION
   }
}