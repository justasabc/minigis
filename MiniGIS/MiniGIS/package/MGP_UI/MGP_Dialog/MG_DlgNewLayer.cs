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
    public partial class MG_DlgNewLayer : Form
    {
        public MG_DlgNewLayer()
        {
            InitializeComponent();
        }

        private string layerName;
        private MG_GeometryType layerType;

        public void InitializeLayerName(string name)
        {
            this.layerName = name;
            this.textBox1_layerName.Text = name;
        }
        public void InitializeLayerType(MG_GeometryType type)
        {
            this.layerType = type;
            switch (type)
            {
                case MG_GeometryType.POINT:
                    this.radioButton1_Point.Checked = true;
                    break;
                case MG_GeometryType.LINESTRING:
                    this.radioButton2_LineString.Checked = true;
                    break;
                case MG_GeometryType.POLYGON:
                    this.radioButton3_Polygon.Checked = true;
                    break;
            }
        }

        public string GetLayerName()
        {
            return this.layerName;
        }
        public MG_GeometryType GetLayerType()
        {
            return this.layerType;
        }


        private void button_OK_Click(object sender, EventArgs e)
        {
            string name = this.textBox1_layerName.Text.Trim().ToString();
            if (!name.Equals(""))
            {
                this.layerName = name;
            }
            if (this.radioButton1_Point.Checked)
            {
                this.layerType = MG_GeometryType.POINT;
            }
            else if (this.radioButton2_LineString.Checked)
            {
                this.layerType = MG_GeometryType.LINESTRING;
            }
            else if (this.radioButton3_Polygon.Checked)
            {
                this.layerType = MG_GeometryType.POLYGON;
            }

            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
