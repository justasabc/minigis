/***********************************************************************
 * Module:  MG_MultiPolygon.cs
 * Author:  ke
 * Purpose: Definition of the Class MGP_BasicObject.MiniGIS.MG_MultiPolygon
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace MGP_BasicObject
{
    public class MG_MultiPolygon : MG_Geometry
    {
        public MG_MultiPolygon()
        {
            this.Type = MG_GeometryType.MULTIPOLYGON;
            this.Polygons = new List<MG_Polygon>();
        }

        public MG_MultiPolygon(MG_MultiPolygon mp)
        {
            this.Type = MG_GeometryType.MULTIPOLYGON;
            this.Polygons = new List<MG_Polygon>();
            if (mp != null)
            {
                for (int i = 0; i < mp.Count(); i++)
                {
                    MG_Polygon p = new MG_Polygon(mp.GetAt(i));
                    this.Polygons.Add(p);
                }
            }
        }

        public void Add(MG_Polygon p)
        {
            this.Polygons.Add(p);
        }

        public void Remove(MG_Polygon p)
        {
            this.Polygons.Remove(p);
        }

        public void RemoveAt(int i)
        {
            this.Polygons.RemoveAt(i);
        }

        public void Clear()
        {
            this.Polygons.Clear();
        }

        public MG_Polygon GetAt(int i)
        {
            return (MG_Polygon)this.Polygons[i];
        }

        public override string AsWKT()
        {   //  "LINESTRING (10 20, 30 40, 50 60)"
            //  "MULTILINESTRING ((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10), (40 40, 30 30, 40 20, 30 10))"
            //  "POLYGON ((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10), (40 40, 30 30, 40 20, 30 10))"
            //  "MULTIPOLYGON (((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10), (40 40, 30 30, 40 20, 30 10)))"
            int count = this.Polygons.Count;
            if (count < 1)
                return null;
            MG_Polygon p = (MG_Polygon)this.Polygons[0];

            string front = "{0} ({1}";
            front = String.Format(front, this.Type.ToString(), p.AsWKT_Reduced());

            string m = ", {0}";
            string mid = "";
            for (int i = 1; i < count; i++)
            {
                MG_Polygon pp = (MG_Polygon)this.Polygons[i];
                mid += String.Format(m, pp.AsWKT_Reduced());
            }

            string end = ")";
            return front + mid + end;
        }

        public int Count()
        {
            // TODO: implement
            return this.Polygons.Count;
        }

        private List<MG_Polygon> Polygons;


    }
}