namespace CAS2018.myFunctions
{
    partial class battPreSuf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(battPreSuf));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Prefix = new System.Windows.Forms.TextBox();
            this.tb_Suffix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslb_AnzahlBlöcke = new System.Windows.Forms.ToolStripStatusLabel();
            this.bt_BlockWahl = new System.Windows.Forms.Button();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.bt_OK = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Prefix";
            // 
            // tb_Prefix
            // 
            this.tb_Prefix.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Prefix.Location = new System.Drawing.Point(71, 13);
            this.tb_Prefix.Name = "tb_Prefix";
            this.tb_Prefix.Size = new System.Drawing.Size(100, 22);
            this.tb_Prefix.TabIndex = 1;
            // 
            // tb_Suffix
            // 
            this.tb_Suffix.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Suffix.Location = new System.Drawing.Point(70, 43);
            this.tb_Suffix.Name = "tb_Suffix";
            this.tb_Suffix.Size = new System.Drawing.Size(100, 22);
            this.tb_Suffix.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Suffix";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(234, 182);
            this.shapeContainer1.TabIndex = 4;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 0;
            this.lineShape1.X2 = 285;
            this.lineShape1.Y1 = 80;
            this.lineShape1.Y2 = 80;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tslb_AnzahlBlöcke});
            this.statusStrip1.Location = new System.Drawing.Point(0, 160);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(234, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabel1.Text = "Blöcke:";
            // 
            // tslb_AnzahlBlöcke
            // 
            this.tslb_AnzahlBlöcke.Name = "tslb_AnzahlBlöcke";
            this.tslb_AnzahlBlöcke.Size = new System.Drawing.Size(13, 17);
            this.tslb_AnzahlBlöcke.Text = "0";
            // 
            // bt_BlockWahl
            // 
            this.bt_BlockWahl.Location = new System.Drawing.Point(71, 95);
            this.bt_BlockWahl.Name = "bt_BlockWahl";
            this.bt_BlockWahl.Size = new System.Drawing.Size(116, 23);
            this.bt_BlockWahl.TabIndex = 10;
            this.bt_BlockWahl.Text = "Blöcke wählen";
            this.bt_BlockWahl.UseVisualStyleBackColor = true;
            this.bt_BlockWahl.Click += new System.EventHandler(this.bt_BlockWahl_Click);
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Location = new System.Drawing.Point(71, 124);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(52, 23);
            this.bt_Cancel.TabIndex = 11;
            this.bt_Cancel.Text = "Cancel";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // bt_OK
            // 
            this.bt_OK.Location = new System.Drawing.Point(135, 124);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(52, 23);
            this.bt_OK.TabIndex = 12;
            this.bt_OK.Text = "OK";
            this.bt_OK.UseVisualStyleBackColor = true;
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            // 
            // battPreSuf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 182);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.bt_BlockWahl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tb_Suffix);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Prefix);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(250, 220);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 220);
            this.Name = "battPreSuf";
            this.ShowInTaskbar = false;
            this.Text = "battPreSuf";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Prefix;
        private System.Windows.Forms.TextBox tb_Suffix;
        private System.Windows.Forms.Label label2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tslb_AnzahlBlöcke;
        private System.Windows.Forms.Button bt_BlockWahl;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Button bt_OK;
    }
}