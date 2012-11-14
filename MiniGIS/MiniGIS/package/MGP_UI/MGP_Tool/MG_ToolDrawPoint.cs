/***********************************************************************
 * Module:  MG_ToolLine.cs
 * Author:  ke
 * Purpose: Definition of the Class MGP_UI.MGP_Tool.MG_ToolLine
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;// Graphics Rectangle
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using MGP_BasicObject;// MG_Geometry
using MGP_DataStorage;
using MGP_Analysis;
using MGP_Display;

namespace MGP_UI.MGP_Tool
{
    public class MG_ToolDrawPoint : MG_BaseTool
    {
        private MG_Point MapPoint;

        public MG_ToolDrawPoint(MG_Layer layer, MG_MapView mapview)
            : base(MG_ToolType.Tool_DrawPoint, layer, mapview)
        {
            this.MapPoint = new MG_Point();
        }

        public override void Paint(object sender, PaintEventArgs e)
        {

        }

        public override void Resize(object sender, EventArgs e)
        {

        }

        public override void ResizeBegin(object sender, EventArgs e)
        {

        }

        public override void ResizeEnd(object sender, EventArgs e)
        {

        }

        public override void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Panel panel = (Panel)sender;
                this.FromPoint = new Point(e.X, e.Y);

                // draw point
                MG_BaseDisplay.FillPoint(panel.CreateGraphics(), brush, this.FromPoint,MG_Constant.PointRadius);

                // screen to map
                this.MapPoint = MG_BaseRender.ToPoint(this.FromPoint, this.MapView);

                //1 create a feature
                // 1.1 set geometry
                this.Feature.SetGeometry(this.MapPoint);
                // 1.2 set field value
                for (int i = 0; i < this.Feature.GetFieldSet().Count();i++ )
                {
                    this.Feature.SetValue(i, null);
                }

                //2 create a new feature
                MG_Feature newFeature = new MG_Feature(this.Feature);
                //3 add new feature to layer
                this.Layer.AddFeature(newFeature);

                //4 clear data to store the next point
                this.MapPoint.Clear();
            }
        }

        public override void MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        public override void MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        public override void KeyDown(object sender, KeyEventArgs e)
        {

        }

        public override void KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public override void KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}