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
    public class MG_ToolPan : MG_BaseTool
    {
        private MG_Map CurrentMap;
        public MG_ToolPan(MG_Map map, MG_MapView mapview)
            : base(MG_ToolType.Tool_Pan, null, mapview)
        {
            this.CurrentMap = map;
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
                this.IsMouseDown = true;
                this.FromPoint = new Point(e.X, e.Y);
            }
        }

        public override void MouseMove(object sender, MouseEventArgs e)
        {

        }

        public override void MouseUp(object sender, MouseEventArgs e)
        {
            if (this.IsMouseDown)
            {
                this.IsMouseDown = false;
                Panel panel = (Panel)sender;

                this.ToPoint = new Point(e.X, e.Y);

                // pan map(screen point --->map point)
                MG_Point mpFrom = MG_BaseRender.ToPoint(this.FromPoint, this.MapView);
                MG_Point mpTo = MG_BaseRender.ToPoint(this.ToPoint, this.MapView);

                double xoff = mpFrom.x - mpTo.x;
                double yoff = mpFrom.y - mpTo.y;
                this.MapView.XYoff(xoff, yoff);

                this.CurrentMap.AddZoomToHistory(this.MapView);
                panel.Refresh();
            }
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