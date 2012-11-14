using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MGP_UI.MGP_Dialog
{
    public partial class MG_DlgNewMap : Form
    {
        public MG_DlgNewMap()
        {
            InitializeComponent();
        }

        private string mapName;
        public void InitializeMapName(string name)
        {
            this.mapName = name;
            this.textBox1_mapName.Text = name;
        }

        public string GetMapName()
        {
            return this.mapName;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            string name = this.textBox1_mapName.Text.Trim().ToString();
            if (!name.Equals(""))
            {
                this.mapName = name;
            }
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
