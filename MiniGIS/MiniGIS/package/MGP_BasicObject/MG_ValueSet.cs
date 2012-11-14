using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGP_BasicObject
{
    public class MG_ValueSet
    {
        private List<MG_Value> Values;

        public MG_ValueSet()
        {
            this.Values = new List<MG_Value>();
        }

        public void Add(MG_Value value)
        {
            this.Values.Add(value);
        }

        public void RemoveAt(int i)
        {
            this.Values.RemoveAt(i);
        }

        public int Count()
        {
            return this.Values.Count;
        }

        public MG_Value GetAt(int i)
        {
            return this.Values[i];
        }

        public void Clear()
        {
            this.Values.Clear();
        }
    }
}
