using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGP_BasicObject
{
    public class MG_LayerSet
    {
        private List<MG_Layer> LayerSet;

        public MG_LayerSet()
        {
            this.LayerSet = new List<MG_Layer>();
        }

        public void Add(MG_Layer layer)
        {
            this.LayerSet.Add(layer);
        }

        public void RemoveAt(int i)
        {
            this.LayerSet.RemoveAt(i);
        }

        public int Count()
        {
            return this.LayerSet.Count;
        }

        public MG_Layer GetAt(int i)
        {
            return this.LayerSet[i];
        }

        public void Clear()
        {
            this.LayerSet.Clear();
        }
   

    }
}
