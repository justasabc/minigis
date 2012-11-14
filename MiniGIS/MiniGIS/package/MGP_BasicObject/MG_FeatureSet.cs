using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGP_BasicObject
{
    public class MG_FeatureSet
    {
        private List<MG_Feature> FeatureSet;

        public MG_FeatureSet()
        {
            this.FeatureSet = new List<MG_Feature>();
        }

        public void Add(MG_Feature field)
        {
            this.FeatureSet.Add(field);
        }

        public void RemoveAt(int i)
        {
            this.FeatureSet.RemoveAt(i);
        }

        public int Count()
        {
            return this.FeatureSet.Count;
        }

        public MG_Feature GetAt(int i)
        {
            return this.FeatureSet[i];
        }

        public void Clear()
        {
            this.FeatureSet.Clear();
        }
   
    }
}
