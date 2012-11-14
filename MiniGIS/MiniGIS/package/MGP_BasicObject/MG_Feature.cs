using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using MGP_Display;

namespace MGP_BasicObject
{
    public class MG_Feature
    {
        private MG_FieldSet FieldSet;// same as Layer.FieldSet

        public MG_ValueSet ValueSet;
        public MG_Geometry Geometry;
        public MG_Symbol Symbol;

        public MG_Feature(MG_FieldSet fs)
        {
            this.FieldSet = fs;
            this.ValueSet = new MG_ValueSet();
            this.Geometry = new MG_Geometry();
            this.Symbol = new MG_Symbol();
        }

        public MG_Feature(MG_Feature f)
        {
            this.FieldSet = new MG_FieldSet();
            this.ValueSet = new MG_ValueSet();
            this.Geometry = new MG_Geometry();
            this.Symbol = new MG_Symbol();

            for (int i = 0; i < f.GetFieldCount();i++ )
            {
                MG_Field field = f.GetFieldSet().GetAt(i);
                MG_Field newField = new MG_Field(field);
                this.FieldSet.Add(newField);

                MG_Value value = f.GetValue(i);
                MG_Value newValue = new MG_Value(value);
                this.ValueSet.Add(newValue);
            }
            MG_Geometry g = f.GetGeometry();
            MG_Geometry newGeom = new MG_Geometry();
            switch (g.Type)
            {
                case MG_GeometryType.NONE:
                    break;
                case MG_GeometryType.POINT:
                    newGeom = new MG_Point(g as MG_Point);
                    break;
                case MG_GeometryType.MULTIPOINT:
                    newGeom = new MG_MultiPoint(g as MG_MultiPoint);
                    break;
                case MG_GeometryType.LINESTRING:
                    newGeom = new MG_LineString(g as MG_LineString);
                    break;
                case MG_GeometryType.MULTILINESTRING:
                    newGeom = new MG_MultiLineString(g as MG_MultiLineString);
                    break;
                case MG_GeometryType.POLYGON:
                    newGeom = new MG_Polygon(g as MG_Polygon);
                    break;
                case MG_GeometryType.MULTIPOLYGON:
                    newGeom = new MG_MultiPolygon(g as MG_MultiPolygon);
                    break;
            }
            this.Geometry = newGeom;
            MG_Symbol newSymbol = new MG_Symbol(f.GetSymbol());
            this.Symbol = newSymbol;
        }

        public void SetFieldSet(MG_FieldSet fs)
        {
            this.FieldSet = fs;
        }

        public MG_FieldSet GetFieldSet()
        {
            return this.FieldSet;
        }

        public void SetGeometry(MG_Geometry geometry)
        {
            this.Geometry = geometry;
        }
        public MG_Geometry GetGeometry()
        {
            return this.Geometry;
        }

        public void SetSymbol(MG_Symbol symbol)
        {
            this.Symbol = symbol;
        }

        public MG_Symbol GetSymbol()
        {
            return this.Symbol;
        }

        public void SetValue(int index, object value)
        {
            MG_Value v = new MG_Value(index, value);
            this.ValueSet.Add(v);
        }

        public MG_Value GetValue(int i)
        {
            if(i<0|| i>= this.ValueSet.Count())
                return null;
            return this.ValueSet.GetAt(i);
        }

        public int GetFieldCount()
        {
            return this.FieldSet.Count();
        }

    }
}
