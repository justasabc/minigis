/***********************************************************************
 * Module:  MG_BaseTool.cs
 * Author:  ke
 * Purpose: Definition of the Class MGP_UI.MGP_Tool.MG_BaseTool
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
   public class MG_BaseTool : MGP_UI.MG_BaseUI
   {
       private MG_ToolType ToolType = MG_ToolType.Tool_None;

       // access in sub class
       protected MG_Layer Layer;// pass in so that store data in layer
       protected MG_MapView MapView; // pass in so that get call Screen2Map
       protected MG_Feature Feature; // store feature

       // symbol
       protected Pen pen = new Pen(MG_Constant.OutlineColor);
       protected Brush brush = new SolidBrush(MG_Constant.FillColor);

       // control interactive process
       protected int Step = 0;
       protected bool IsMouseDown = false;
       protected Point FromPoint;
       protected Point ToPoint;
       protected Point Point3;
       protected Rectangle SelectRect;

       public MG_BaseTool(MG_ToolType type, MG_Layer layer, MG_MapView mapview)
       {
           this.ToolType = type;

           this.Layer = layer;
           this.MapView = mapview;
           if (layer!=null)
           {// pan tool: layer==null
               this.Feature = new MG_Feature(this.Layer.GetFieldSet());
           } 

           // empty point
           this.FromPoint = Point.Empty;
           this.ToPoint = Point.Empty;
           this.Point3 = Point.Empty;
           this.SelectRect = Rectangle.Empty;
       }

       public MG_ToolType GetToolType()
       {
           return this.ToolType;
       }
       

      public virtual void Paint(object sender, PaintEventArgs e)
      {
         
      }

      public virtual void Resize(object sender, EventArgs e)
      {
         
      }

      public virtual void ResizeBegin(object sender, EventArgs e)
      {
         
      }

      public virtual void ResizeEnd(object sender, EventArgs e)
      {
        
      }

      public virtual void MouseDown(object sender, MouseEventArgs e)
      {
         
      }

      public virtual void MouseMove(object sender, MouseEventArgs e)
      {
         
      }

      public virtual void MouseUp(object sender, MouseEventArgs e)
      {
         
      }

      public virtual void KeyDown(object sender, KeyEventArgs e)
      {
         
      }

      public virtual void KeyPress(object sender, KeyPressEventArgs e)
      {

      }

      public virtual void KeyUp(object sender, KeyEventArgs e)
      {

      }

   }
}