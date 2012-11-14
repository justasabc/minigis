using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGP_BasicObject
{
    public class MG_ZoomHistory
    {
        private List<MG_ZoomRecord> Zooms;
        public MG_ZoomHistory()
        {
            this.Zooms = new List<MG_ZoomRecord>();
        }

        public void Add(MG_ZoomRecord zoom)
        {
            this.Zooms.Add(zoom);
        }

        public MG_ZoomRecord GetAt(int i)
        {
            return this.Zooms[i];
        }

        public int Count()
        {
            return this.Zooms.Count;
        }

        public void Clear()
        {
            this.Zooms.Clear();
        }

    }
}
