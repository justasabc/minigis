using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace MGP_UI.MGP_Dialog
{
    public partial class MG_DlgListTableNames : Form
    {
        public MG_DlgListTableNames()
        {
            InitializeComponent();
        }

        private ArrayList tables;
        private string selectedTable;

        public void InitializeTableNames(ArrayList tables)
        {
            this.tables = tables;
            if (tables!=null)
            {
                for (int i = 0; i < tables.Count;i++ )
                {
                    this.listBox1.Items.Add(tables[i].ToString());
                }
            }
        }

        public string GetSelectedTableName()
        {
            return this.selectedTable;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            int index = this.listBox1.SelectedIndex;
            if (index >=0)
            {
                this.selectedTable = this.tables[index].ToString();
            }
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
