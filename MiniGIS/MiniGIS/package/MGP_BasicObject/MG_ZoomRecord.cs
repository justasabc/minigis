using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGP_BasicObject
{
    public class MG_ZoomRecord
    {
        public double scale;
        public double centermapx;
        public double centermapy;
        public MG_ZoomRecord(double scale, double centermapx, double centermapy)
        {
            this.scale = scale;
            this.centermapx = centermapx;
            this.centermapy = centermapy;
        }
    }
}
