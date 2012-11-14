using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace MGP_BasicObject
{
    public class MG_Symbol
    {
        public Color FillColor;
        public Color OutlineColor;
        public int LineWidth;
        public int PointRadius;

        public MG_Symbol()
        {
            this.FillColor = MG_Constant.FillColor;
            this.OutlineColor = MG_Constant.OutlineColor;
            this.LineWidth = MG_Constant.LineWidth;
            this.PointRadius = MG_Constant.PointRadius;
        }

        public MG_Symbol(MG_Symbol s)
        {
            this.FillColor = s.FillColor;
            this.OutlineColor = s.OutlineColor;
            this.LineWidth = s.LineWidth;
            this.PointRadius = s.PointRadius;
        }
    }
}
