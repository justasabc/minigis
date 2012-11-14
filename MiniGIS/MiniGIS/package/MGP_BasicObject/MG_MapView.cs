using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MGP_BasicObject
{
    public class MG_MapView
    {
        private MG_MapExtent CurrentExtent; // Empty
        private Rectangle CurrentWindow; // Empty
        private Point CenterScreenPoint;

        private MG_Point CenterMapPoint;
        private double Scale;

        public MG_MapView(Rectangle rect, MG_MapExtent me)
        {
            this.Scale = 1.0;
            this.CurrentWindow = rect;
            this.CurrentExtent = me;
            this.Calculate();
        }

        public void Update(Rectangle rect, MG_MapExtent me)
        {// FullExtent  ZoomToLayer
            this.CurrentWindow = rect;
            this.CurrentExtent = me;
            this.Calculate();
        }

        #region change_scale_center

        public void SetScale(double scale)
        {
            this.Scale = scale;
        }

        public double GetScale()
        {
            return this.Scale;
        }

        public void Scalex(double factor)
        {
            this.Scale *= factor;
        }

        public void SetCenterX(double cx)
        {
            this.CenterMapPoint.x = cx;
        }
        public void SetCenterY(double cy)
        {
            this.CenterMapPoint.y = cy;
        }

        public double GetCenterX()
        {
            return this.CenterMapPoint.x;
        }

        public double GetCenterY()
        {
            return this.CenterMapPoint.y;
        }

        public void Xoff(double xoff)
        {
            this.CenterMapPoint.x += xoff;
        }

        public void Yoff(double yoff)
        {
            this.CenterMapPoint.y += yoff;
        }

        public void XYoff(double xoff, double yoff)
        {
            this.CenterMapPoint.x += xoff;
            this.CenterMapPoint.y += yoff;
        }
        #endregion

        private void calculateScale()
        {
            double ScaleX = 1.0;
            double ScaleY = 1.0;
            if (CurrentWindow.Width > 0)
            {
                ScaleX = (CurrentExtent.MaxX - CurrentExtent.MinX) / CurrentWindow.Width;
            }
            if (CurrentWindow.Height > 0)
            {
                ScaleY = (CurrentExtent.MaxY - CurrentExtent.MinY) / CurrentWindow.Height;
            }
            this.Scale = Math.Max(ScaleX, ScaleY);
            //this.Scale = Math.Min(ScaleX, ScaleY);
        }

        private void calculateCenterMapPoint()
        {
            this.CenterMapPoint = new MG_Point((CurrentExtent.MaxX + CurrentExtent.MinX) / 2, (CurrentExtent.MaxY + CurrentExtent.MinY) / 2);
        }

        private void calculateCenterScreenPoint()
        {
            this.CenterScreenPoint = new Point(CurrentWindow.Width / 2, CurrentWindow.Height / 2);
        }

        private void Calculate()
        {
            this.calculateScale();
            this.calculateCenterMapPoint();
            this.calculateCenterScreenPoint();
        }

        /*
         // CenterMapPoint (a1,b1)  CenterScreenPoint(a2,b2)
         // DX/dx = (a1-mx)/(a2-sx) = scalex   DY/dy = (b1-my)/(sy-b2) = scaley
         * */
        public MG_Point Screent2Map(Point point)
        {
            double mx = CenterMapPoint.x - ((double)(CenterScreenPoint.X - point.X)) * Scale;
            double my = CenterMapPoint.y - ((double)(point.Y - CenterScreenPoint.Y)) * Scale;
            return new MG_Point(mx, my);
        }

        public Point Map2Screen(MG_Point point)
        {//scale = 0.015 229,251--->542  530
            double sx = CenterScreenPoint.X - (int)((CenterMapPoint.x - point.x) / Scale);
            double sy = CenterScreenPoint.Y + (int)((CenterMapPoint.y - point.y) / Scale);
            return new Point((int)sx, (int)sy);
        }

        public double GetValue(double v)
        {// pixel value to real value
            // zoomin scale 1--->0.5
             // zoom out scale 1--->2
            return v * this.Scale;
        }

    }
}
