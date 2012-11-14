using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGP_BasicObject
{
    public class MG_Field
    {
        private static int fieldCount = 0;
        public string Name;
        public MG_FieldDBType Type;
        public int Width;
        public int Precision;

        public MG_Field()
        {
            fieldCount++;
            this.Name = "Field_" + fieldCount.ToString();
        }

        public MG_Field(string name, MG_FieldDBType type)
        {
            this.Name = name;
            this.Type = type;
        }

        public MG_Field(string name, MG_FieldDBType type, int width, int precision)
        {
            this.Name = name;
            this.Type = type;
            this.Width = width;
            this.Precision = precision;
        }

        public MG_Field(MG_Field f)
        {
            this.Name = f.Name;
            this.Type = f.Type;
            this.Width = f.Width;
            this.Precision = f.Precision;
        }

    }
}
