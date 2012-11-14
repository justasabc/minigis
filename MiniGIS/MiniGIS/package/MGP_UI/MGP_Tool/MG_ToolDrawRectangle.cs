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
    public class MG_ToolDrawRectangle : MG_BaseTool
    {
        protected bool  IsStart = true;// start end

        public MG_ToolDrawRectangle(MG_Layer layer, MG_MapView mapview)
            : base(MG_ToolType.Tool_DrawRectangle, layer, mapview)
        {

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
                if (this.IsStart)
                {
                    this.IsMouseDown = true;
                    this.IsStart = false;

                    this.SelectRect.Width = 0;
                    this.SelectRect.Height = 0;
                    this.SelectRect.X = e.X;
                    this.SelectRect.Y = e.Y;
                }
                else
                {
                    this.IsMouseDown = false;
                    this.IsStart = true;
                    SelectRect.Width = e.X - SelectRect.X;
                    SelectRect.Height = e.Y - SelectRect.Y;

                    // save point

                    // clear data
                    this.SelectRect.Width = 0;
                    this.SelectRect.Height = 0;
                    this.SelectRect.X = 0;
                    this.SelectRect.Y = 0;
                }
            }
        }

        public override void MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                Panel panel = (Panel)sender;
                ControlPaint.DrawReversibleFrame(panel.RectangleToScreen(SelectRect), Color.Red, FrameStyle.Dashed);
                SelectRect.Width = e.X - SelectRect.X;
                SelectRect.Height = e.Y - SelectRect.Y;
                ControlPaint.DrawReversibleFrame(panel.RectangleToScreen(SelectRect), Color.Red, FrameStyle.Dashed);
            }
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