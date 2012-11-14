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
    public class MG_ToolDrawDoubleLineString : MG_BaseTool
    {
        private MG_LineString LineString;
        private MG_LineString LineStringOther;//another line of the doubleline

        // doubleline
        protected Point FromPointOther;//doubleline
        protected Point ToPointOther;//doubleline
        protected int DoubleLine = 0;//draw doubleline automatic 0¡¢1
        protected int WhichLine = 1;//decide which line the point will be added 1¡¢2
        protected int OneLineStill = 0;//decide if still put a point in one line
        protected bool QuitEdit = false;//if quit edit linestring

        public MG_ToolDrawDoubleLineString(MG_Layer layer, MG_MapView mapview)
            : base(MG_ToolType.Tool_DrawDoubleLineString, layer, mapview)
        {
            this.LineString = new MG_LineString();
            this.LineStringOther = new MG_LineString();
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

                Point realPoint = new Point(e.X, e.Y);//

                //Draw doubleline
                if (this.DoubleLine == 0)//draw double line alternative
                {//
                    if (WhichLine == 2)//put the point in the second line//
                    {//
                        this.LineStringOther.Add(new MG_Point(realPoint));//
                        this.FromPointOther.X = (int)this.LineStringOther.GetAt(this.LineStringOther.Count() - 1).x;//
                        this.FromPointOther.Y = (int)this.LineStringOther.GetAt(this.LineStringOther.Count() - 1).y;//
                        this.ToPointOther = this.FromPointOther;//
                        if (OneLineStill == 0)//
                        {//
                            WhichLine = 1;//
                        }//
                        else if (OneLineStill == 2)//
                        {//
                            WhichLine = 2;//
                        }//
                        else if (OneLineStill == 1)//
                        {//
                            WhichLine = 1;//
                        }//
                    }//
                    else//put the point in the first line
                    {//
                        this.LineString.Add(new MG_Point(realPoint));//
                        this.FromPoint.X = (int)this.LineString.GetAt(this.LineString.Count() - 1).x;//
                        this.FromPoint.Y = (int)this.LineString.GetAt(this.LineString.Count() - 1).y;//
                        this.ToPoint = this.FromPoint;//
                        if (OneLineStill == 0)//
                        {//
                            WhichLine = 2;//
                        }//
                        else if (OneLineStill == 1)
                        {//
                            WhichLine = 1;//
                        }//
                        else if (OneLineStill == 2)//
                        {//
                            WhichLine = 2;//
                        }//
                    }//
                }//
                else//draw double line automatic down
                {//
                    if (WhichLine == 1)
                    {
                        this.LineString.Add(new MG_Point(realPoint));//
                        this.FromPoint.X = (int)this.LineString.GetAt(this.LineString.Count() - 1).x;//
                        this.FromPoint.Y = (int)this.LineString.GetAt(this.LineString.Count() - 1).y;//
                        this.ToPoint = this.FromPoint;//

                        this.FromPointOther.X = (int)this.LineStringOther.GetAt(this.LineStringOther.Count() - 1).x +
                            (this.FromPoint.X - (int)this.LineString.GetAt(this.LineString.Count() - 2).x);//
                        this.FromPointOther.Y = (int)this.LineStringOther.GetAt(this.LineStringOther.Count() - 1).y +
                            (this.FromPoint.Y - (int)this.LineString.GetAt(this.LineString.Count() - 2).y);//
                        this.LineStringOther.Add(new MG_Point(FromPointOther));//
                        this.ToPointOther = this.FromPointOther;//
                    }
                    else
                    {
                        //this.LineStringOther.Add(MG_BaseRender.ToPoint(realPoint, this.MapView));//
                        this.LineStringOther.Add(new MG_Point(realPoint));//
                        this.FromPoint.X = (int)this.LineString.GetAt(this.LineString.Count() - 1).x;//
                        this.FromPoint.Y = (int)this.LineString.GetAt(this.LineString.Count() - 1).y;//
                        this.ToPoint = this.FromPoint;//
                        WhichLine = 1;//
                    }
                }//

            }
        }

        public override void MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                Panel panel = (Panel)sender;
                if (this.DoubleLine == 0)//draw double line alternative
                {//
                    if ((WhichLine == 1) || (this.LineStringOther.Count() == 0))//
                    {//
                        FromPoint.X = (int)this.LineString.GetAt(this.LineString.Count() - 1).x;//
                        FromPoint.Y = (int)this.LineString.GetAt(this.LineString.Count() - 1).y;//
                        ControlPaint.DrawReversibleLine(panel.PointToScreen(FromPoint), panel.PointToScreen(ToPoint), Color.Red);
                        ToPoint = new Point(e.X, e.Y);
                        ControlPaint.DrawReversibleLine(panel.PointToScreen(FromPoint), panel.PointToScreen(ToPoint), Color.Red);
                        if ((WhichLine == 1) && (this.LineStringOther.Count() == 1))//
                        {//
                            FromPointOther.X = (int)this.LineStringOther.GetAt(this.LineStringOther.Count() - 1).x;//
                            FromPointOther.Y = (int)this.LineStringOther.GetAt(this.LineStringOther.Count() - 1).y;//
                            ControlPaint.DrawReversibleLine(panel.PointToScreen(FromPointOther), panel.PointToScreen(ToPointOther), Color.Red);//
                            ToPointOther = new Point(e.X, e.Y);//
                            ControlPaint.DrawReversibleLine(panel.PointToScreen(FromPointOther), panel.PointToScreen(ToPointOther), Color.Red);//
                        }//
                    }//
                    else
                    {
                        FromPointOther.X = (int)this.LineStringOther.GetAt(this.LineStringOther.Count() - 1).x;//
                        FromPointOther.Y = (int)this.LineStringOther.GetAt(this.LineStringOther.Count() - 1).y;//
                        ControlPaint.DrawReversibleLine(panel.PointToScreen(FromPointOther), panel.PointToScreen(ToPointOther), Color.Red);//
                        ToPointOther = new Point(e.X, e.Y);//
                        ControlPaint.DrawReversibleLine(panel.PointToScreen(FromPointOther), panel.PointToScreen(ToPointOther), Color.Red);//
                    }//
                }//
                else//draw double line automatic
                {//
                    //if (this.LineString.Count() == this.LineStringOther.Count())
                    if (WhichLine == 1)
                    {
                        FromPoint.X = (int)this.LineString.GetAt(this.LineString.Count() - 1).x;//
                        FromPoint.Y = (int)this.LineString.GetAt(this.LineString.Count() - 1).y;//
                        ControlPaint.DrawReversibleLine(panel.PointToScreen(FromPoint), panel.PointToScreen(ToPoint), Color.Red);
                        ToPoint = new Point(e.X, e.Y);
                        ControlPaint.DrawReversibleLine(panel.PointToScreen(FromPoint), panel.PointToScreen(ToPoint), Color.Red);

                        FromPointOther.X = (int)this.LineStringOther.GetAt(this.LineStringOther.Count() - 1).x;//
                        FromPointOther.Y = (int)this.LineStringOther.GetAt(this.LineStringOther.Count() - 1).y;//
                        ControlPaint.DrawReversibleLine(panel.PointToScreen(FromPointOther), panel.PointToScreen(ToPointOther), Color.Red);//
                        ToPointOther = new Point(((int)this.LineStringOther.GetAt(this.LineStringOther.Count() - 1).x + (e.X - (int)this.LineString.GetAt(this.LineString.Count() - 1).x)),
                                ((int)this.LineStringOther.GetAt(this.LineStringOther.Count() - 1).y + (e.Y - (int)this.LineString.GetAt(this.LineString.Count() - 1).y)));//
                        ControlPaint.DrawReversibleLine(panel.PointToScreen(FromPointOther), panel.PointToScreen(ToPointOther), Color.Red);//
                    }
                }
            }
        }

        public override void MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.IsMouseDown = false;

                // screen point to map point
                MG_LineString MapLineString = new MG_LineString();
                for (int i = 0; i < this.LineString.Count();i++ )
                {
                    MG_Point screenPoint = this.LineString.GetAt(i);
                    Point screen = new Point((int)screenPoint.x, (int)screenPoint.y);
                    MG_Point mapPoint = MG_BaseRender.ToPoint(screen, this.MapView);
                    MapLineString.Add(mapPoint);
                }
                MG_LineString MapLineStringOther = new MG_LineString();
                for (int i = 0; i < this.LineStringOther.Count(); i++)
                {
                    MG_Point screenPoint = this.LineStringOther.GetAt(i);
                    Point screen = new Point((int)screenPoint.x, (int)screenPoint.y);
                    MG_Point mapPoint = MG_BaseRender.ToPoint(screen, this.MapView);
                    MapLineStringOther.Add(mapPoint);
                }


                //1 create a feature
                // 1.1 set geometry
                this.Feature.SetGeometry(MapLineString);
                // 1.2 set field value
                for (int i = 0; i < this.Feature.GetFieldSet().Count(); i++)
                {
                    this.Feature.SetValue(i, null);
                }

                //2 create a new feature
                MG_Feature newFeature1 = new MG_Feature(this.Feature);
                //3 add new feature to layer
                this.Layer.AddFeature(newFeature1);

                //4 clear data to store the next linestring
                this.LineString.Clear();

                //1 create a feature
                // 1.1 set geometry
                this.Feature.SetGeometry(MapLineStringOther);
                // 1.2 set field value
                for (int i = 0; i < this.Feature.GetFieldSet().Count(); i++)
                {
                    this.Feature.SetValue(i, null);
                }

                //2 create a new feature
                MG_Feature newFeature2 = new MG_Feature(this.Feature);
                //3 add new feature to layer
                this.Layer.AddFeature(newFeature2);

                //4 clear data to store the next linestring
                this.LineStringOther.Clear();
            }
        }

        public override void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {

            }
            else if (e.KeyData == Keys.U)
            {

            }
            else if (e.KeyData == Keys.R)
            {

            }
            else if (e.Shift == true)//
            {//
                //MessageBox.Show("111");
               this.DoubleLine = 1;//
            }//
            else if (e.KeyCode == Keys.Escape)//
            {//
                this.IsMouseDown = false;
            }//
            else if (e.KeyData == Keys.D1)
            {
                //MessageBox.Show("111");
                //WhichLine = 1;
                this.OneLineStill = 1;
            }
            else if (e.KeyData == Keys.D2)
            {
                //MessageBox.Show("222");
                //WhichLine = 2;
                this.OneLineStill = 2;
            }
            else if(e.KeyData==Keys.Q)//Ìí¼ÓµÄ
            {//
                this.DoubleLine = 0;//
                this.OneLineStill = 0;//
            }//
        }

        public override void KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        public override void KeyUp(object sender, KeyEventArgs e)
        {
            
        }

    }
}
