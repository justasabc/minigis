using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MGP_BasicObject;

namespace MGP_UI.MGP_Dialog
{
    public partial class MG_DlgViewAttribute : Form
    {
        public MG_DlgViewAttribute()
        {
            InitializeComponent();
        }

        private MG_Layer layer;
        public void SetLayer(MG_Layer layer)
        {
            this.layer = layer;
        }

        private DataTable GetDataTable(MG_Layer layer)
        {
            // Create a new DataTable.
            DataTable table = new DataTable(layer.GetLayerName());

            // add oid
            DataColumn oid_Column = new DataColumn("OID", Type.GetType("System.Int32"));
            table.Columns.Add(oid_Column);

            int i, j;
            // Add the column
            for (i = 0; i < layer.GetFieldSet().Count(); i++)
            {
                MG_Field field = layer.GetFieldSet().GetAt(i);
                DataColumn column = new DataColumn(field.Name);
                column.DataType = Type.GetType("System.String");
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
            }

            // Add the row
            for (i = 0; i < layer.GetFeatureCount(); i++)
            {
                MG_Feature f = layer.GetFeature(i);
                DataRow row = table.NewRow();
                // add oid 
                row[0] = i+1;

                for (j = 0; j < f.GetFieldCount(); j++)
                {
                    object value = f.GetValue(j).Value;
                    if (value != null)
                    {
                        row[j + 1] = value.ToString();
                    }
                }

                // Add the row to the DataRowCollection.
                table.Rows.Add(row);
            }

            return table;
        }

        private void MG_DlgViewAttribute_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = this.GetDataTable(this.layer);
            this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

    }
}
