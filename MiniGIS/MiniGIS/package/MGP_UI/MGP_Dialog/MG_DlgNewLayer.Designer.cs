namespace MGP_UI.MGP_Dialog
{
    partial class MG_DlgNewLayer
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
            this.textBox1_layerName = new System.Windows.Forms.TextBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3_Polygon = new System.Windows.Forms.RadioButton();
            this.radioButton2_LineString = new System.Windows.Forms.RadioButton();
            this.radioButton1_Point = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1_layerName
            // 
            this.textBox1_layerName.Location = new System.Drawing.Point(28, 51);
            this.textBox1_layerName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1_layerName.Name = "textBox1_layerName";
            this.textBox1_layerName.Size = new System.Drawing.Size(239, 21);
            this.textBox1_layerName.TabIndex = 11;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(160, 174);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(63, 29);
            this.button_Cancel.TabIndex = 10;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(37, 174);
            this.button_OK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(71, 29);
            this.button_OK.TabIndex = 9;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "LayerName";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3_Polygon);
            this.groupBox1.Controls.Add(this.radioButton2_LineString);
            this.groupBox1.Controls.Add(this.radioButton1_Point);
            this.groupBox1.Location = new System.Drawing.Point(28, 91);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(239, 65);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type";
            // 
            // radioButton3_Polygon
            // 
            this.radioButton3_Polygon.AutoSize = true;
            this.radioButton3_Polygon.Location = new System.Drawing.Point(146, 29);
            this.radioButton3_Polygon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton3_Polygon.Name = "radioButton3_Polygon";
            this.radioButton3_Polygon.Size = new System.Drawing.Size(65, 16);
            this.radioButton3_Polygon.TabIndex = 2;
            this.radioButton3_Polygon.Text = "Polygon";
            this.radioButton3_Polygon.UseVisualStyleBackColor = true;
            // 
            // radioButton2_LineString
            // 
            this.radioButton2_LineString.AutoSize = true;
            this.radioButton2_LineString.Location = new System.Drawing.Point(61, 29);
            this.radioButton2_LineString.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton2_LineString.Name = "radioButton2_LineString";
            this.radioButton2_LineString.Size = new System.Drawing.Size(83, 16);
            this.radioButton2_LineString.TabIndex = 1;
            this.radioButton2_LineString.Text = "LineString";
            this.radioButton2_LineString.UseVisualStyleBackColor = true;
            // 
            // radioButton1_Point
            // 
            this.radioButton1_Point.AutoSize = true;
            this.radioButton1_Point.Location = new System.Drawing.Point(5, 29);
            this.radioButton1_Point.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton1_Point.Name = "radioButton1_Point";
            this.radioButton1_Point.Size = new System.Drawing.Size(53, 16);
            this.radioButton1_Point.TabIndex = 0;
            this.radioButton1_Point.Text = "Point";
            this.radioButton1_Point.UseVisualStyleBackColor = true;
            // 
            // MG_DlgNewLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 234);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1_layerName);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MG_DlgNewLayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MG_DlgNewLayer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1_layerName;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1_Point;
        private System.Windows.Forms.RadioButton radioButton3_Polygon;
        private System.Windows.Forms.RadioButton radioButton2_LineString;
    }
}