using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGP_BasicObject
{
    public class MG_MapSet
    {
        private List<MG_Map> Maps;

        public MG_MapSet()
        {
            this.Maps = new List<MG_Map>();
        }

        public void Add(MG_Map map)
        {
            this.Maps.Add(map);
        }

        public void RemoveAt(int i)
        {
            this.Maps.RemoveAt(i);
        }

        public int Count()
        {
            return this.Maps.Count;
        }

        public MG_Map GetAt(int i)
        {
            return this.Maps[i];
        }

        public void Clear()
        {
            this.Maps.Clear();
        }
    }
}
