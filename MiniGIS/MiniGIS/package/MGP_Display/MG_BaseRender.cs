/***********************************************************************
 * Module:  MG_Display.cs
 * Author:  ke
 * Purpose: Definition of the Class MGP_Display.MG_Display
 ***********************************************************************/

using System;
using MGP_BasicObject;// MG_Geometry
using System.Drawing;
using System.Collections.Generic;

namespace MGP_Display
{
    public class MG_BaseRender : MG_BaseDisplay
    {
        public static int GetRealValue(int value, MG_MapView mapview)
        {
            int realValue = value;
            if (mapview != null)
            {
                realValue = (int)mapview.GetValue(value);
                if (realValue <= 0)
                {
                    realValue = 1;
                }
            }
            return realValue;
        }

        private static Point AsPoint(MG_Point point, MG_MapView mapview)
        {
            Point sp;
            if (mapview != null)
            {
                sp = mapview.Map2Screen(point);
            }
            else
            {
                sp = new Point((int)point.x, (int)point.y);
            }
            return sp;
        }

        public static MG_Point ToPoint(Point point, MG_MapView mapview)
        {
            MG_Point mp;
            if (mapview != null)
            {
                mp = mapview.Screent2Map(point);
            }
            else
            {
                mp = new MG_Point(point.X, point.Y);
            }
            return mp;
        }


        public static void RenderPoint(Graphics g, Brush brush, int radius, MG_MapView mapview, MG_Point point)
        {
            //int realValue = GetRealValue(radius, mapview);
            //if (realValue < MG_Constant.PointRadius)
            //{
            //    realValue = MG_Constant.PointRadius;
            //}
            Point sp = AsPoint(point, mapview);
            FillPoint(g, brush, sp, radius);
        }

        public static void RenderMultiPoint(Graphics g, Brush brush, int radius, MG_MapView mapview, MG_MultiPoint multiPoint)
        {
            for (int i = 0; i < multiPoint.Count(); i++)
            {
                RenderPoint(g, brush, radius, mapview, multiPoint.GetAt(i));
            }
        }

        public static void RenderLineString(Graphics g, Pen pen, MG_MapView mapview, MG_LineString lineString)
        {
            int count = lineString.Count();
            if (count < 2)
                return;
            Point[] points = new Point[count];
            for (int i = 0; i < count; i++)
            {
                MG_Point mp = lineString.GetAt(i);
                points[i] = AsPoint(mp, mapview);
            }
            DrawLineString(g, pen, points);
        }

        public static void RenderMultiLineString(Graphics g, Pen pen, MG_MapView mapview, MG_MultiLineString multiLineString)
        {
            for (int i = 0; i < multiLineString.Count(); i++)
            {
                RenderLineString(g, pen, mapview, multiLineString.GetAt(i));
            }
        }

        public static void RenderPolygon(Graphics g, Brush brush, MG_MapView mapview, MG_Polygon polygon)
        {
            int countLineString = polygon.Count();
            for (int i = 0; i < countLineString; i++)
            {
                MG_LineString lineString = polygon.GetAt(i);
                int countPoint = lineString.Count();
                if (countPoint < 3)
                    return;
                Point[] points = new Point[countPoint];
                for (int j = 0; j < countPoint; j++)
                {
                    MG_Point mp = lineString.GetAt(j);
                    points[j] = AsPoint(mp, mapview);
                }
                FillPolygon(g, brush, points);
                //Pen pen = new Pen(Color.Red, 1);
                //DrawPolygon(g, pen, points);
            }
        }

        public static void RenderMultiPolygon(Graphics g, Brush brush, MG_MapView mapview, MG_MultiPolygon multiPolygon)
        {
            for (int i = 0; i < multiPolygon.Count(); i++)
            {
                RenderPolygon(g, brush, mapview, multiPolygon.GetAt(i));
            }
        }

        public static void RenderPolygon(Graphics g, Pen pen, MG_MapView mapview, MG_Polygon polygon)
        {
            int countLineString = polygon.Count();
            for (int i = 0; i < countLineString; i++)
            {
                MG_LineString lineString = polygon.GetAt(i);
                int countPoint = lineString.Count();
                if (countPoint < 3)
                    return;
                Point[] points = new Point[countPoint];
                for (int j = 0; j < countPoint; j++)
                {
                    MG_Point mp = lineString.GetAt(j);
                    points[j] = AsPoint(mp, mapview);
                }
                //FillPolygon(g, brush, points);
                //Pen pen = new Pen(Color.Red, 1);
                DrawPolygon(g, pen, points);
            }
        }

        public static void RenderMultiPolygon(Graphics g, Pen pen, MG_MapView mapview, MG_MultiPolygon multiPolygon)
        {
            for (int i = 0; i < multiPolygon.Count(); i++)
            {
                RenderPolygon(g, pen, mapview, multiPolygon.GetAt(i));
            }
        }

        public static void RenderGeometry(Graphics g, Pen pen, Brush brush, MG_MapView mapview, MG_Geometry geometry)
        {
            switch (geometry.Type)
            {
                case MG_GeometryType.NONE:
                    break;
                case MG_GeometryType.POINT:
                    MG_MapRender.RenderPoint(g, brush, MG_Constant.PointRadius, mapview, geometry as MG_Point);
                    break;
                case MG_GeometryType.MULTIPOINT:
                    MG_MapRender.RenderMultiPoint(g, brush, MG_Constant.PointRadius, mapview, geometry as MG_MultiPoint);
                    break;
                case MG_GeometryType.LINESTRING:
                    MG_MapRender.RenderLineString(g, pen, mapview, geometry as MG_LineString);
                    break;
                case MG_GeometryType.MULTILINESTRING:
                    MG_MapRender.RenderMultiLineString(g, pen, mapview, geometry as MG_MultiLineString);
                    break;
                case MG_GeometryType.POLYGON:
                    MG_MapRender.RenderPolygon(g, brush, mapview, geometry as MG_Polygon);
                    //MG_MapRender.RenderPolygon(g, pen, mapview, geometry as MG_Polygon);
                    break;
                case MG_GeometryType.MULTIPOLYGON:
                    MG_MapRender.RenderMultiPolygon(g, brush, mapview, geometry as MG_MultiPolygon);
                    //MG_MapRender.RenderMultiPolygon(g, pen, mapview, geometry as MG_MultiPolygon);
                    break;
            }
        }


        public static void RenderGeometrys(Graphics g, Pen pen, Brush brush, MG_MapView mapview, List<MG_Geometry> geometrys)
        {
            for (int i = 0; i < geometrys.Count; i++)
            {
                RenderGeometry(g, pen, brush, mapview, geometrys[i]);
            }
        }



    }
}