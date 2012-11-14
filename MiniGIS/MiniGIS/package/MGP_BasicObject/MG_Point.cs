/***********************************************************************
 * Module:  MG_Point.cs
 * Author:  ke
 * Purpose: Definition of the Class MGP_BasicObject.MiniGIS.MG_Point
 ***********************************************************************/

using System;
using System.Drawing;

namespace MGP_BasicObject
{
    ///  "POINT (10 20)"
    ///  "MULTIPOINT (10 20, 30 40, 50 60)"
    ///  "LINESTRING (10 20, 30 40, 50 60)"
    ///  "MULTILINESTRING ((10 10, 20 20, 10 40),(40 40, 30 30, 40 20, 30 10))"
    ///  "POLYGON ((35 10, 10 20, 15 40, 45 45, 35 10),(20 30, 35 35, 30 20, 20 30))"
    public class MG_Point : MG_Geometry
    {
        public MG_Point()
        {
            this.Type = MG_GeometryType.POINT;
        }

        public MG_Point(MG_Point p)
        {
            this.Type = MG_GeometryType.POINT;
            this.x = p.x;
            this.y = p.y;
        }

        public MG_Point(Point p)
        {
            this.Type = MG_GeometryType.POINT;
            this.x = p.X;
            this.y = p.Y;
        }

        public MG_Point(double x, double y)
        {
            this.Type = MG_GeometryType.POINT;
            this.x = x;
            this.y = y;
        }

        public void Clear()
        {
            this.x = 0;
            this.y = 0;
        }

        public override string AsWKT()
        {// "POINT (10 20)"
            string wkt = "{0} ({1} {2})";
            wkt = String.Format(wkt, this.Type.ToString(), this.x, this.y);
            return wkt;
        }

        ///  xxx between 2 ,
        public override string AsWKT_Reduced()
        {// "POINT (10 20)"---> "10 20"
            string wkt = "{0} {1}";// Reduced Here:  "{0} ({1} {2})"
            wkt = String.Format(wkt, this.x, this.y);
            return wkt;
        }

        public double x
        {
            get
           ;
            set
           ;
        }

        public double y
        {
            get
           ;
            set
           ;
        }

    }
}