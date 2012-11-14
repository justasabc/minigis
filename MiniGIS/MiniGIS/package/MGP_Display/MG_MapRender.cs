using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MGP_BasicObject;
using System.Drawing;// MG_Geometry


namespace MGP_Display
{
    public class MG_MapRender : MG_BaseRender
    {
        public static void RenderMap(MG_Map map, MG_MapView mapview, Graphics g)
        {
            for (int i = 0; i < map.GetLayerCount(); i++)
            {
                RenderLayer(map.GetLayer(i), mapview, g);
            }
        }

        public static void RenderLayer(MG_Layer layer, MG_MapView mapview, Graphics g)
        {
            if (layer.GetVisible())
            {
                for (int i = 0; i < layer.GetFeatureCount(); i++)
                {
                    RenderFeature(layer.GetFeature(i),mapview, g);
                }
            }
        }

        public static void RenderFeature(MG_Feature f, MG_MapView mapview, Graphics g)
        {
            //int realValue = GetRealValue(f.Symbol.LineWidth, mapview);
            Pen pen = new Pen(f.Symbol.OutlineColor, f.Symbol.LineWidth);
            SolidBrush brush = new SolidBrush(f.Symbol.FillColor);
            RenderGeometry(g, pen, brush, mapview, f.Geometry);
        }

    }
}
