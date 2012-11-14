using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGP_BasicObject
{
    public class MG_FieldSet
    {
        private string Name; // layerName
        private List<MG_Field> Fields;

        public MG_FieldSet()
        {
            this.Fields = new List<MG_Field>();
        }

        public MG_FieldSet(string name)
        {
            this.Name = name;
            this.Fields = new List<MG_Field>();
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public string GetName()
        {
            return this.Name;
        }

        public void Add(MG_Field field)
        {
            this.Fields.Add(field);
        }

        public int Count()
        {
            return this.Fields.Count;
        }

        public MG_Field GetAt(int i)
        {
            return this.Fields[i];
        }

        public void Clear()
        {
            this.Fields.Clear();
        }
    }
}
