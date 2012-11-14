using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;


namespace MGP_BasicObject
{
    public class MG_Map
    {
        private static int mapCount = 0;
        private string MapName;
        private string MapPath;// null or not

        private MG_LayerSet LayerSet;
        private MG_MapExtent MapExtent;// depend on layers extent


        private MG_MapView MapView;//
        private MG_ZoomHistory ZoomHistory;
        public int CurrentZoomIndex;

        public MG_Map()
        {
            mapCount++;
            this.MapName = "Map_" + mapCount.ToString();
            this.MapPath = null;
            this.MapExtent = new MG_MapExtent();
            this.LayerSet = new MG_LayerSet();
            this.ZoomHistory = new MG_ZoomHistory();
            this.CurrentZoomIndex = -1;
            this.MapView = null;
        }

        public void SetMapName(string mapName)
        {
            this.MapName = mapName;
        }

        public string GetMapName()
        {
            return this.MapName;
        }

        public void SetMapPath(string mapPath)
        {
            this.MapPath = mapPath;
        }

        public string GetMapPath()
        {
            return this.MapPath;
        }

        public void InitMapView(Rectangle rect, MG_MapExtent me)
        {// layerCount>0 => MapExtent!=Empty => MapView!=null
            if (!this.MapExtent.Empty())
            {
                this.MapView = new MG_MapView(rect, me);
            }
        }

        public MG_MapView GetMapView()
        {
            return this.MapView;
        }

        public void AddZoomToHistory(MG_MapView mapview)
        {// updateMapView
            // zoomin/zoomout/pan/left/right/up/down
            if (mapview != null)
            {
                this.CurrentZoomIndex++;
                MG_ZoomRecord zoom = new MG_ZoomRecord(mapview.GetScale(), mapview.GetCenterX(), mapview.GetCenterY());
                this.ZoomHistory.Add(zoom);
            }
        }

        public MG_ZoomHistory GetZoomHistory()
        {
            return this.ZoomHistory;
        }

        public void AddLayer(MG_Layer layer)
        {
            this.LayerSet.Add(layer);

            // calculate extent dynamic
            if (this.MapExtent.Empty())
            {
                this.MapExtent = layer.Extent;
            }
            else
            {
                this.MapExtent = calculateExtent(this.MapExtent, layer.Extent);
            }
        }

        public MG_MapExtent GetMapExtent()
        {
            return this.MapExtent;
        }

        public void SetMapExtent(MG_MapExtent mapExtent)
        {// zoom to layer : mapextent = layerextent
            this.MapExtent = mapExtent;
        }

        public bool HasFeature()
        {// mapExtent !=Empty  FeatureCount = 0
            for (int i = 0; i < this.LayerSet.Count(); i++)
            {
                if (this.LayerSet.GetAt(i).GetFeatureCount() > 0)
                    return true;
            }
            return false;
        }

        public MG_Layer GetLayer(int i)
        {
            if (i < 0 || i >= this.GetLayerCount())
                return null;
            return this.LayerSet.GetAt(i);
        }

        public void RemoveLayer(int i)
        {
            if (i < 0 || i >= this.GetLayerCount())
                return;
            this.LayerSet.RemoveAt(i);

            // calculate extent dynamic(except i layer)
            this.MapExtent = new MG_MapExtent();// Empty extent
            for (int j = 0; j < this.GetLayerCount(); j++)
            {
                if (j != i)
                {
                    if (this.MapExtent.Empty())
                    {
                        this.MapExtent = this.LayerSet.GetAt(j).Extent;
                    }
                    else
                    {
                        this.MapExtent = calculateExtent(this.MapExtent, this.LayerSet.GetAt(j).Extent);
                    }
                }
            }
        }

        public int GetLayerCount()
        {
            return this.LayerSet.Count();
        }

        public void Clear()
        {
            this.LayerSet.Clear();
            this.ZoomHistory.Clear();
        }

        #region math_for_calculte
        private double min(double a, double b)
        {
            return a < b ? a : b;
        }

        private double max(double a, double b)
        {
            return a > b ? a : b;
        }

        private MG_MapExtent calculateExtent(MG_MapExtent e1, MG_MapExtent e2)
        {
            MG_MapExtent ext = new MG_MapExtent();
            ext.MinX = min(e1.MinX, e2.MinX);
            ext.MinY = min(e1.MinY, e2.MinY);
            ext.MaxX = max(e1.MaxX, e2.MaxX);
            ext.MaxY = max(e1.MaxY, e2.MaxY);
            return ext;
        }
        #endregion

    }
}
