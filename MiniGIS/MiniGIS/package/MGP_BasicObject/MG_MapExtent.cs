using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MGP_BasicObject
{
    public class MG_MapExtent
    {
        public double MinX { set; get; }
        public double MinY { set; get; }
        public double MaxX { set; get; }
        public double MaxY { set; get; }

        public MG_MapExtent()
        {

        }

        public MG_MapExtent(double minx, double miny, double maxx, double maxy)
        {
            this.MinX = minx;
            this.MinY = miny;
            this.MaxX = maxx;
            this.MaxY = maxy;
        }

        public MG_MapExtent(MG_MapExtent ext)
        {
            this.MinX = ext.MinX;
            this.MinY = ext.MinY;
            this.MaxX = ext.MaxX;
            this.MaxY = ext.MaxY;
        }

        public MG_MapExtent(Rectangle rect)
        {
            this.MinX = rect.X;
            this.MinY = rect.Y;
            this.MaxX = rect.X + rect.Width;
            this.MaxY = rect.Y + rect.Height;
        }

        public void SetExtent(double minx, double miny, double maxx, double maxy)
        {
            this.MinX = minx;
            this.MinY = miny;
            this.MaxX = maxx;
            this.MaxY = maxy;
        }

        public bool Empty()
        {
            return (MinX==0.0)&&(MinY==0.0)&&(MaxX==0.0)&&(MaxY==0.0);
        }

    }
}
