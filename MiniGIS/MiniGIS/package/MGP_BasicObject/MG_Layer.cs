using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace MGP_BasicObject
{
    public class MG_Layer
    {
        private static int layerCount = 0;
        private string LayerName;
        private string LayerPath;// null or not
        private bool IsVisible; // 1 0

        public MG_FeatureSet FeatureSet;
        public MG_MapExtent Extent;
        public MG_FieldSet FieldSet;//
        public MG_GeometryType Type;// default NONE

        public MG_Layer()
        {
            layerCount++;
            this.LayerName = "Layer_" + layerCount.ToString();
            this.LayerPath = null;
            this.IsVisible = true;
            this.FeatureSet = new MG_FeatureSet();
            this.FieldSet = new MG_FieldSet(this.LayerName);
            this.Extent = new MG_MapExtent();
            this.Type = MG_GeometryType.NONE;
        }

        public void SetLayerName(string layerName)
        {
            this.LayerName = layerName;
            this.FieldSet.SetName(layerName);
        }

        public string GetLayerName()
        {
            return this.LayerName;
        }

        public void SetLayerType(MG_GeometryType type)
        {
            this.Type = type;
        }

        public MG_GeometryType GetLayerType()
        {
            return this.Type;
        }

        public void SetLayerPath(string layerPath)
        {
            this.LayerPath = layerPath;
        }

        public string GetLayerPath()
        {
            return this.LayerPath;
        }

        public void SetVisible(bool bVisible)
        {
            this.IsVisible = bVisible;
        }

        public bool GetVisible()
        {
            return this.IsVisible;
        }

        public void AddField(MG_Field field)
        {
            this.FieldSet.Add(field);
        }

        public void SetFieldSet(MG_FieldSet fieldSet)
        {
            this.FieldSet = fieldSet;
        }

        public MG_FieldSet GetFieldSet()
        {
            return this.FieldSet;
        }

        // feature
        public void AddFeature(MG_Feature feature)
        {
            if (this.Type == MG_GeometryType.NONE)
            {
                this.Type = feature.GetGeometry().Type;
                this.FeatureSet.Add(feature);
            }
            else if (this.Type == feature.GetGeometry().Type)
            {
                this.FeatureSet.Add(feature);
            }
        }

        public int GetFeatureCount()
        {
            return this.FeatureSet.Count();
        }

        public bool HasFeature()
        {
            return this.FeatureSet.Count() > 0;
        }

        public MG_Feature GetFeature(int i)
        {
            return this.FeatureSet.GetAt(i);
        }


    }
}
