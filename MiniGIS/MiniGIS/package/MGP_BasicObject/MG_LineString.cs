/***********************************************************************
 * Module:  MG_LineString.cs
 * Author:  ke
 * Purpose: Definition of the Class MGP_BasicObject.MiniGIS.MG_LineString
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace MGP_BasicObject
{
    public class MG_LineString : MG_Geometry
    {
        public MG_LineString()
        {
            this.Type = MG_GeometryType.LINESTRING;
            this.Points = new List<MG_Point>();
        }

        public MG_LineString(MG_LineString l)
        {
            this.Type = MG_GeometryType.LINESTRING;
            this.Points = new List<MG_Point>();
            if (l != null)
            {
                for (int i = 0; i < l.Count(); i++)
                {
                    MG_Point p = new MG_Point(l.GetAt(i));
                    this.Add(p);
                }
            }
        }

        public void Add(MG_Point p)
        {
            this.Points.Add(p);
        }

        public void Remove(MG_Point p)
        {
            this.Points.Remove(p);
        }

        public void RemoveAt(int i)
        {
            this.Points.RemoveAt(i);
        }

        public void Clear()
        {
            this.Points.Clear();
        }

        public MG_Point GetAt(int i)
        {
            return (MG_Point)this.Points[i];
        }

        public override string AsWKT()
        {// "LINESTRING (10 20, 30 40, 50 60)"
            // "MULTIPOINT (10 20, 30 40, 50 60)"
            int count = this.Points.Count;
            if (count < 1)
                return null;
            MG_Point p = (MG_Point)this.Points[0];

            string front = "{0} ({1}";
            front = String.Format(front, this.Type.ToString(), p.AsWKT_Reduced());

            string m = ", {0}";
            string mid = "";
            for (int i = 1; i < count; i++)
            {
                MG_Point pp = (MG_Point)this.Points[i];
                mid += String.Format(m, pp.AsWKT_Reduced());
            }

            string end = ")";
            return front + mid + end;
        }

        ///  xxx between 2 ,
        public override string AsWKT_Reduced()
        {// "LINESTRING (10 20, 30 40, 50 60)"  ---> "(10 20, 30 40, 50 60)"
            int count = this.Points.Count;
            if (count < 1)
                return null;
            MG_Point p = (MG_Point)this.Points[0];

            string front = "({0}"; //Reduced Here: "{0} ({1}";
            front = String.Format(front, p.AsWKT_Reduced());

            string m = ", {0}";
            string mid = "";
            for (int i = 1; i < count; i++)
            {
                MG_Point pp = (MG_Point)this.Points[i];
                mid += String.Format(m, pp.AsWKT_Reduced());
            }

            string end = ")";
            return front + mid + end;
        }

        public int Count()
        {
            // TODO: implement
            return this.Points.Count;
        }

        private List<MG_Point> Points;


    }
}