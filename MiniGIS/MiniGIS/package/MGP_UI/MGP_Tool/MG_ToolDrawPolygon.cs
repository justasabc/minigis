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
    public class MG_ToolDrawPolygon : MG_BaseTool
    {
        protected MG_LineString LineString;
        protected MG_Polygon Polygon;

        public MG_ToolDrawPolygon(MG_Layer layer, MG_MapView mapview)
            : base(MG_ToolType.Tool_DrawPolygon, layer, mapview)
        {
            this.LineString = new MG_LineString();
            this.Polygon = new MG_Polygon();
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
                Panel panel = (Panel)sender;

                if (this.Step == 0)
                {
                    this.Step = 1;

                    this.FromPoint = new Point(e.X, e.Y);

                    // store map point
                    MG_Point mapPoint1 = MG_BaseRender.ToPoint(this.FromPoint, this.MapView);
                    this.LineString.Add(mapPoint1);
                }
                else if (this.Step == 1)
                {
                    this.Step = 2;

                    this.ToPoint = new Point(e.X, e.Y);

                    // store map point
                    MG_Point mapPoint2 = MG_BaseRender.ToPoint(this.ToPoint, this.MapView);
                    this.LineString.Add(mapPoint2);
                }
                else if (this.Step == 2)
                {
                    this.Point3 = new Point(e.X, e.Y);

                    // repeat same pattern
                    this.ToPoint = this.Point3;

                    // store map point
                    MG_Point mapPoint3 = MG_BaseRender.ToPoint(Point3, this.MapView);
                    this.LineString.Add(mapPoint3);
                }
            }
        }

        public override void MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                Panel panel = (Panel)sender;
                if (this.Step == 0)
                {

                }
                else if (this.Step == 1)
                {
                    if (!this.ToPoint.IsEmpty)
                    {
                        ControlPaint.DrawReversibleLine(panel.PointToScreen(FromPoint), panel.PointToScreen(ToPoint), Color.Red);
                    }
                    ToPoint = new Point(e.X, e.Y);
                    ControlPaint.DrawReversibleLine(panel.PointToScreen(FromPoint), panel.PointToScreen(ToPoint), Color.Red);
                }
                else if (this.Step == 2)
                {
                    if (!this.Point3.IsEmpty)
                    {
                        ControlPaint.DrawReversibleLine(panel.PointToScreen(FromPoint), panel.PointToScreen(Point3), Color.Red);
                        ControlPaint.DrawReversibleLine(panel.PointToScreen(ToPoint), panel.PointToScreen(Point3), Color.Red);
                    }
                    Point3 = new Point(e.X, e.Y);
                    ControlPaint.DrawReversibleLine(panel.PointToScreen(FromPoint), panel.PointToScreen(Point3), Color.Red);
                    ControlPaint.DrawReversibleLine(panel.PointToScreen(ToPoint), panel.PointToScreen(Point3), Color.Red);
                }
            }
        }

        public override void MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.IsMouseDown = false;
                Panel panel = (Panel)sender;

                if (this.Step == 0)
                {

                }
                else if (this.Step == 1)
                {

                }
                else if (this.Step == 2)
                {
                    // add last point
                    this.Point3 = new Point(e.X, e.Y);
                    MG_Point mapPoint3 = MG_BaseRender.ToPoint(Point3, this.MapView);
                    this.LineString.Add(mapPoint3);

                    // add first point again(same to first point)
                    MG_Point firstPoint = MG_BaseRender.ToPoint(this.FromPoint, this.MapView);
                    this.LineString.Add(firstPoint);
                    // add to polygon
                    this.Polygon.Add(this.LineString);

                    //1 create a feature
                    // 1.1 set geometry
                    this.Feature.SetGeometry(this.Polygon);
                    // 1.2 set field value
                    for (int i = 0; i < this.Feature.GetFieldSet().Count(); i++)
                    {
                        this.Feature.SetValue(i, null);
                    }

                    //2 create a new feature
                    MG_Feature newFeature = new MG_Feature(this.Feature);
                    //3 add new feature to layer
                    this.Layer.AddFeature(newFeature);

                    //4 clear data to store the next linestring
                    this.Polygon.Clear();
                    this.LineString.Clear();

                    // 5 reset control params
                    this.Step = 0;
                    this.FromPoint = Point.Empty;
                    this.ToPoint = Point.Empty;
                    this.Point3 = Point.Empty;
                }
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