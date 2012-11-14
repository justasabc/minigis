/***********************************************************************
 * Module:  MG_Polygon.cs
 * Author:  ke
 * Purpose: Definition of the Class MGP_BasicObject.MiniGIS.MG_Polygon
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace MGP_BasicObject
{
    public class MG_Polygon : MG_Geometry
    {
        public MG_Polygon()
        {
            this.Type = MG_GeometryType.POLYGON;
            this.LineStrings = new List<MG_LineString>();
        }

        public MG_Polygon(MG_Polygon p)
        {
            this.Type = MG_GeometryType.POLYGON;
            this.LineStrings = new List<MG_LineString>();
            if (p != null)
            {
                for (int i = 0; i < p.Count(); i++)
                {
                    MG_LineString l = new MG_LineString(p.GetAt(i));
                    this.LineStrings.Add(l);
                }
            }
        }

        public void Add(MG_LineString l)
        {
            this.LineStrings.Add(l);
        }

        public void Remove(MG_LineString l)
        {
            this.LineStrings.Remove(l);
        }

        public void RemoveAt(int i)
        {
            this.LineStrings.RemoveAt(i);
        }

        public void Clear()
        {
            this.LineStrings.Clear();
        }

        public MG_LineString GetAt(int i)
        {
            return (MG_LineString)this.LineStrings[i];
        }

        public override string AsWKT()
        {   //  "LINESTRING (10 20, 30 40, 50 60)"
            //  "MULTILINESTRING ((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10), (40 40, 30 30, 40 20, 30 10))"
            //  "POLYGON ((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10), (40 40, 30 30, 40 20, 30 10))"
            int count = this.LineStrings.Count;
            if (count < 1)
                return null;
            MG_LineString l = (MG_LineString)this.LineStrings[0];

            string front = "{0} ({1}";
            front = String.Format(front, this.Type.ToString(), l.AsWKT_Reduced());

            string m = ", {0}";
            string mid = "";
            for (int i = 1; i < count; i++)
            {
                MG_LineString ll = (MG_LineString)this.LineStrings[i];
                mid += String.Format(m, ll.AsWKT_Reduced());
            }

            string end = ")";
            return front + mid + end;
        }

        public override string AsWKT_Reduced()
        {   //  "LINESTRING (10 20, 30 40, 50 60)"
            //  "MULTILINESTRING ((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10), (40 40, 30 30, 40 20, 30 10))"
            //  "POLYGON ((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10), (40 40, 30 30, 40 20, 30 10))"

            int count = this.LineStrings.Count;
            if (count < 1)
                return null;
            MG_LineString l = (MG_LineString)this.LineStrings[0];

            string front = "({0}"; // Reduced Here : "{0} ({1}"
            front = String.Format(front, l.AsWKT_Reduced());

            string m = ", {0}";
            string mid = "";
            for (int i = 1; i < count; i++)
            {
                MG_LineString ll = (MG_LineString)this.LineStrings[i];
                mid += String.Format(m, ll.AsWKT_Reduced());
            }

            string end = ")";
            return front + mid + end;
        }

        public int Count()
        {
            // TODO: implement
            return this.LineStrings.Count;
        }

        private List<MG_LineString> LineStrings;


    }
}