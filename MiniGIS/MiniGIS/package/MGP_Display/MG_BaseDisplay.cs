/***********************************************************************
 * Module:  MG_BaseDisplay.cs
 * Author:  ke
 * Purpose: Definition of the Class MGP_Display.MG_BaseDisplay
 ***********************************************************************/

using System;

using MGP_BasicObject;// MG_Geometry
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MGP_Display
{
   public class MG_BaseDisplay
   {
       public static void DrawPoint(Graphics g, Pen pen, Point p, int radius)
       {
           DrawCircle(g, pen, p, radius);
       }

       public static void FillPoint(Graphics g, Brush brush, Point p, int radius)
       {
           FillCircle(g, brush, p, radius);
       }

       public static void DrawRectangle(Graphics g, Pen pen, int x, int y, int w, int h)
       {
           g.DrawRectangle(pen, x, y, w, h);
       }

       public static void FillRectangle(Graphics g, Brush brush, int x, int y, int w, int h)
       {
           g.FillRectangle(brush, x, y, w, h);
       }

       public static void DrawCircle(Graphics g, Pen pen, Point p, int radius)
       {
           drawCircle(g, pen, p.X, p.Y, radius);
       }

       private static void drawCircle(Graphics g, Pen pen, int centerX, int centerY, int radius)
       {
           int start = centerX - radius;
           int end = centerY - radius;
           int diam = radius * 2;
           g.DrawEllipse(pen, start, end, diam, diam);
       }

       public static void FillCircle(Graphics g, Brush brush, Point p, int radius)
       {
           fillCircle(g, brush, p.X, p.Y, radius);
       }

       private static void fillCircle(Graphics g, Brush brush, int centerX, int centerY, int radius)
       {
           int start = centerX - radius;
           int end = centerY - radius;
           int diam = radius * 2;
           g.FillEllipse(brush, start, end, diam, diam);
       }

       public static void DrawLine(Graphics g, Pen pen, Point p1, Point p2)
       {
           g.DrawLine(pen, p1,p2);
       }

       public static void DrawLineString(Graphics g, Pen pen, Point[] points)
       {
           g.DrawLines(pen, points);
       }

       public static void DrawLineString2(Graphics g)
       {
           Pen pen = new Pen(Color.Red, 2);

           Point[] points = new Point[5];
           points[0] = new Point(100, 100);
           points[1] = new Point(100, 200);
           points[2] = new Point(200, 200);
           points[3] = new Point(200, 100);
           points[4] = new Point(500, 500);

           g.DrawLines(pen, points);
       }

       public static void DrawPolygon2(Graphics g)
       {
           Pen pen = new Pen(Color.Red, 2);
           
           Point[] points = new Point[5];
           points[0]= new Point(100,100);
           points[1]= new Point(100,200);
           points[2]= new Point(200,200);
           points[3]= new Point(200,100);
           points[4]= new Point(100,100);

           //g.DrawPolygon(pen, points);

           SolidBrush solidColorBrush =
               new SolidBrush(Color.Red);
           g.FillPolygon(solidColorBrush, points);

           //coloredPen.Color = Color.Green;
           //coloredPen.Width = 5;
           //coloredPen.DashCap = DashCap.Round;
           //coloredPen.DashStyle = DashStyle.Dash;
       }

       public static void DrawPolygon(Graphics g, Pen pen, Point[] points)
       {
           g.DrawPolygon(pen, points);
       }

       public static void FillPolygon(Graphics g, Brush brush, Point[] points)
       {
           g.FillPolygon(brush, points);
       }


   }
}