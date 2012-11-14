using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MGP_DataStorage.MGP_DatabaseStorage;

namespace MGP_UI.MGP_Dialog
{
    public partial class MG_DlgSetConnectionString : Form
    {
        public MG_DlgSetConnectionString()
        {
            InitializeComponent();
        }

        private MG_ConnectionString connString;

        public void InitalizeConnString(MG_ConnectionString cs)
        {
            this.connString = cs;
            this.textBox_Server.Text = cs.Server;
            this.textBox_Port.Text = cs.Port;
            this.textBox_UserId.Text = cs.UserId;
            this.textBox_Password.Text = cs.Password;
            this.textBox_Database.Text = cs.Database;
        }

        public MG_ConnectionString GetConnString()
        {
            return this.connString;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            this.connString.Server = this.textBox_Server.Text;
            this.connString.Port = this.textBox_Port.Text;
            this.connString.UserId = this.textBox_UserId.Text;
            this.connString.Password = this.textBox_Password.Text;
            this.connString.Database = this.textBox_Database.Text;
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
