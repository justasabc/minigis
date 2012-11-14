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
    public partial class MG_DlgNewField : Form
    {
        public MG_DlgNewField()
        {
            InitializeComponent();
        }

        private string fieldName;
        private MG_FieldDBType fieldType;

        public void InitializeFieldName(string name)
        {
            this.fieldName = name;
            this.textBox1_fieldName.Text = name;
        }

        public void InitializeFieldTypes()
        {
            this.comboBox1_fieldType.Items.Add(MG_FieldDBType.VARCHAR);
            this.comboBox1_fieldType.Items.Add(MG_FieldDBType.INTEGER);
            this.comboBox1_fieldType.Items.Add(MG_FieldDBType.FLOAT8);
            this.comboBox1_fieldType.SelectedIndex = 0;
            this.fieldType = (MG_FieldDBType)this.comboBox1_fieldType.SelectedItem;
        }

        public string GetFieldName()
        {
            return this.fieldName;
        }
        public MG_FieldDBType GetFieldType()
        {
            return this.fieldType;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            string name = this.textBox1_fieldName.Text.Trim().ToString();
            if (!name.Equals(""))
            {
                this.fieldName = name;
            }

            int index = this.comboBox1_fieldType.SelectedIndex;
            if (index>=0)
            {
                this.fieldType = (MG_FieldDBType)this.comboBox1_fieldType.SelectedItem;
            }
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
