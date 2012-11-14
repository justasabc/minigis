using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGP_BasicObject
{
    public class MG_Value
    {
        public int Index;
        public object Value;

        public MG_Value()
        {

        }

        public MG_Value(int index, object value)
        {
            this.Index = index;
            this.Value = value;
        }

        public MG_Value(MG_Value v)
        {
            this.Index = v.Index;
            this.Value = v.Value;
        }
    }
}
