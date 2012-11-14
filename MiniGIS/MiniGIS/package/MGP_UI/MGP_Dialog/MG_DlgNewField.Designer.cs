namespace MGP_UI.MGP_Dialog
{
    partial class MG_DlgNewField
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1_fieldName = new System.Windows.Forms.TextBox();
            this.comboBox1_fieldType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1_fieldName
            // 
            this.textBox1_fieldName.Location = new System.Drawing.Point(28, 54);
            this.textBox1_fieldName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1_fieldName.Name = "textBox1_fieldName";
            this.textBox1_fieldName.Size = new System.Drawing.Size(76, 21);
            this.textBox1_fieldName.TabIndex = 0;
            // 
            // comboBox1_fieldType
            // 
            this.comboBox1_fieldType.FormattingEnabled = true;
            this.comboBox1_fieldType.Location = new System.Drawing.Point(143, 54);
            this.comboBox1_fieldType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1_fieldType.Name = "comboBox1_fieldType";
            this.comboBox1_fieldType.Size = new System.Drawing.Size(92, 20);
            this.comboBox1_fieldType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "FieldName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "FieldType";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(143, 99);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(64, 27);
            this.button_Cancel.TabIndex = 12;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(30, 99);
            this.button_OK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(76, 27);
            this.button_OK.TabIndex = 11;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // MG_DlgNewField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 142);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1_fieldType);
            this.Controls.Add(this.textBox1_fieldName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MG_DlgNewField";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MG_NewField";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1_fieldName;
        private System.Windows.Forms.ComboBox comboBox1_fieldType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
    }
}