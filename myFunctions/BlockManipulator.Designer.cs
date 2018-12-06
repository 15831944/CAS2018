namespace CAS2018.myFunctions
{
    partial class BlockManipulator
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
            this.bt_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tB_nBlöcke = new System.Windows.Forms.TextBox();
            this.bt_BlöckeSelectWindow = new System.Windows.Forms.Button();
            this.tB_nHöhe = new System.Windows.Forms.TextBox();
            this.tB_ohneHöhe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tB_Hmin = new System.Windows.Forms.TextBox();
            this.tB_Hmax = new System.Windows.Forms.TextBox();
            this.bt_OpenPTFile = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_nPunkteFile = new System.Windows.Forms.TextBox();
            this.tB_PTFilename = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tB_nPTÜbereinstimmung = new System.Windows.Forms.TextBox();
            this.bt_markieren = new System.Windows.Forms.Button();
            this.bt_löschen = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tB_PTungültig = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_CASBlöcke = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_OffsetHeight = new System.Windows.Forms.TextBox();
            this.bt_OffsetHeight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_OK
            // 
            this.bt_OK.Location = new System.Drawing.Point(522, 350);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(50, 25);
            this.bt_OK.TabIndex = 0;
            this.bt_OK.Text = "OK";
            this.bt_OK.UseVisualStyleBackColor = true;
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Anzahl gewählter Blöcke:";
            // 
            // tB_nBlöcke
            // 
            this.tB_nBlöcke.Location = new System.Drawing.Point(146, 10);
            this.tB_nBlöcke.Name = "tB_nBlöcke";
            this.tB_nBlöcke.ReadOnly = true;
            this.tB_nBlöcke.Size = new System.Drawing.Size(77, 20);
            this.tB_nBlöcke.TabIndex = 2;
            // 
            // bt_BlöckeSelectWindow
            // 
            this.bt_BlöckeSelectWindow.AutoSize = true;
            this.bt_BlöckeSelectWindow.Location = new System.Drawing.Point(241, 10);
            this.bt_BlöckeSelectWindow.Name = "bt_BlöckeSelectWindow";
            this.bt_BlöckeSelectWindow.Size = new System.Drawing.Size(84, 23);
            this.bt_BlöckeSelectWindow.TabIndex = 4;
            this.bt_BlöckeSelectWindow.Text = "select window";
            this.bt_BlöckeSelectWindow.UseVisualStyleBackColor = true;
            this.bt_BlöckeSelectWindow.Click += new System.EventHandler(this.bt_selectWindow_Click);
            // 
            // tB_nHöhe
            // 
            this.tB_nHöhe.Location = new System.Drawing.Point(149, 65);
            this.tB_nHöhe.Name = "tB_nHöhe";
            this.tB_nHöhe.ReadOnly = true;
            this.tB_nHöhe.Size = new System.Drawing.Size(75, 20);
            this.tB_nHöhe.TabIndex = 5;
            // 
            // tB_ohneHöhe
            // 
            this.tB_ohneHöhe.Location = new System.Drawing.Point(149, 91);
            this.tB_ohneHöhe.Name = "tB_ohneHöhe";
            this.tB_ohneHöhe.ReadOnly = true;
            this.tB_ohneHöhe.Size = new System.Drawing.Size(75, 20);
            this.tB_ohneHöhe.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "mit Höhe:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "ohne Höhe:";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape4,
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(584, 386);
            this.shapeContainer1.TabIndex = 9;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape4
            // 
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 0;
            this.lineShape4.X2 = 585;
            this.lineShape4.Y1 = 193;
            this.lineShape4.Y2 = 193;
            // 
            // lineShape3
            // 
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 0;
            this.lineShape3.X2 = 585;
            this.lineShape3.Y1 = 262;
            this.lineShape3.Y2 = 262;
            // 
            // lineShape2
            // 
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 0;
            this.lineShape2.X2 = 585;
            this.lineShape2.Y1 = 159;
            this.lineShape2.Y2 = 159;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 0;
            this.lineShape1.X2 = 585;
            this.lineShape1.Y1 = 34;
            this.lineShape1.Y2 = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Anzahl gültiger Blöcke:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(316, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Hmin:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(313, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Hmax:";
            // 
            // tB_Hmin
            // 
            this.tB_Hmin.Location = new System.Drawing.Point(357, 65);
            this.tB_Hmin.Name = "tB_Hmin";
            this.tB_Hmin.ReadOnly = true;
            this.tB_Hmin.Size = new System.Drawing.Size(75, 20);
            this.tB_Hmin.TabIndex = 13;
            // 
            // tB_Hmax
            // 
            this.tB_Hmax.Location = new System.Drawing.Point(357, 91);
            this.tB_Hmax.Name = "tB_Hmax";
            this.tB_Hmax.ReadOnly = true;
            this.tB_Hmax.Size = new System.Drawing.Size(75, 20);
            this.tB_Hmax.TabIndex = 14;
            // 
            // bt_OpenPTFile
            // 
            this.bt_OpenPTFile.AutoSize = true;
            this.bt_OpenPTFile.Location = new System.Drawing.Point(16, 273);
            this.bt_OpenPTFile.Name = "bt_OpenPTFile";
            this.bt_OpenPTFile.Size = new System.Drawing.Size(114, 23);
            this.bt_OpenPTFile.TabIndex = 15;
            this.bt_OpenPTFile.Text = "Punktdaten einlesen";
            this.bt_OpenPTFile.UseVisualStyleBackColor = true;
            this.bt_OpenPTFile.Click += new System.EventHandler(this.bt_OpenPTFile_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Anzahl Punkte:";
            // 
            // tb_nPunkteFile
            // 
            this.tb_nPunkteFile.Location = new System.Drawing.Point(149, 300);
            this.tb_nPunkteFile.Name = "tb_nPunkteFile";
            this.tb_nPunkteFile.ReadOnly = true;
            this.tb_nPunkteFile.Size = new System.Drawing.Size(77, 20);
            this.tb_nPunkteFile.TabIndex = 17;
            // 
            // tB_PTFilename
            // 
            this.tB_PTFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_PTFilename.Location = new System.Drawing.Point(149, 275);
            this.tB_PTFilename.Name = "tB_PTFilename";
            this.tB_PTFilename.ReadOnly = true;
            this.tB_PTFilename.Size = new System.Drawing.Size(426, 20);
            this.tB_PTFilename.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 329);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "PT mit Übereinstimmung:";
            // 
            // tB_nPTÜbereinstimmung
            // 
            this.tB_nPTÜbereinstimmung.Location = new System.Drawing.Point(149, 326);
            this.tB_nPTÜbereinstimmung.Name = "tB_nPTÜbereinstimmung";
            this.tB_nPTÜbereinstimmung.ReadOnly = true;
            this.tB_nPTÜbereinstimmung.Size = new System.Drawing.Size(77, 20);
            this.tB_nPTÜbereinstimmung.TabIndex = 20;
            // 
            // bt_markieren
            // 
            this.bt_markieren.Enabled = false;
            this.bt_markieren.Location = new System.Drawing.Point(322, 303);
            this.bt_markieren.Name = "bt_markieren";
            this.bt_markieren.Size = new System.Drawing.Size(75, 20);
            this.bt_markieren.TabIndex = 21;
            this.bt_markieren.Text = "markieren";
            this.bt_markieren.UseVisualStyleBackColor = true;
            this.bt_markieren.Click += new System.EventHandler(this.bt_markieren_Click);
            // 
            // bt_löschen
            // 
            this.bt_löschen.Enabled = false;
            this.bt_löschen.Location = new System.Drawing.Point(322, 325);
            this.bt_löschen.Name = "bt_löschen";
            this.bt_löschen.Size = new System.Drawing.Size(75, 20);
            this.bt_löschen.TabIndex = 22;
            this.bt_löschen.Text = "löschen";
            this.bt_löschen.UseVisualStyleBackColor = true;
            this.bt_löschen.Click += new System.EventHandler(this.bt_löschen_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(73, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "<null> Höhe:";
            // 
            // tB_PTungültig
            // 
            this.tB_PTungültig.Location = new System.Drawing.Point(149, 117);
            this.tB_PTungültig.Name = "tB_PTungültig";
            this.tB_PTungültig.ReadOnly = true;
            this.tB_PTungültig.Size = new System.Drawing.Size(74, 20);
            this.tB_PTungültig.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(354, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Anzahl CAS2018 Blöcke:";
            // 
            // tb_CASBlöcke
            // 
            this.tb_CASBlöcke.Location = new System.Drawing.Point(486, 10);
            this.tb_CASBlöcke.Name = "tb_CASBlöcke";
            this.tb_CASBlöcke.ReadOnly = true;
            this.tb_CASBlöcke.Size = new System.Drawing.Size(77, 20);
            this.tb_CASBlöcke.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Offset Höhe:";
            // 
            // tb_OffsetHeight
            // 
            this.tb_OffsetHeight.BackColor = System.Drawing.SystemColors.Window;
            this.tb_OffsetHeight.Location = new System.Drawing.Point(83, 158);
            this.tb_OffsetHeight.Name = "tb_OffsetHeight";
            this.tb_OffsetHeight.Size = new System.Drawing.Size(77, 20);
            this.tb_OffsetHeight.TabIndex = 28;
            this.tb_OffsetHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_OffsetHeight_KeyPress);
            // 
            // bt_OffsetHeight
            // 
            this.bt_OffsetHeight.Location = new System.Drawing.Point(166, 158);
            this.bt_OffsetHeight.Name = "bt_OffsetHeight";
            this.bt_OffsetHeight.Size = new System.Drawing.Size(39, 23);
            this.bt_OffsetHeight.TabIndex = 29;
            this.bt_OffsetHeight.Text = "go";
            this.bt_OffsetHeight.UseVisualStyleBackColor = true;
            this.bt_OffsetHeight.Click += new System.EventHandler(this.bt_OffsetHeight_Click);
            // 
            // BlockManipulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 386);
            this.ControlBox = false;
            this.Controls.Add(this.bt_OffsetHeight);
            this.Controls.Add(this.tb_OffsetHeight);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tb_CASBlöcke);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tB_PTungültig);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bt_löschen);
            this.Controls.Add(this.bt_markieren);
            this.Controls.Add(this.tB_nPTÜbereinstimmung);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tB_PTFilename);
            this.Controls.Add(this.tb_nPunkteFile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bt_OpenPTFile);
            this.Controls.Add(this.tB_Hmax);
            this.Controls.Add(this.tB_Hmin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tB_ohneHöhe);
            this.Controls.Add(this.tB_nHöhe);
            this.Controls.Add(this.bt_BlöckeSelectWindow);
            this.Controls.Add(this.tB_nBlöcke);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.shapeContainer1);
            this.MaximumSize = new System.Drawing.Size(600, 425);
            this.MinimumSize = new System.Drawing.Size(600, 425);
            this.Name = "BlockManipulator";
            this.ShowIcon = false;
            this.Text = "BlockManipulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tB_nBlöcke;
        private System.Windows.Forms.Button bt_BlöckeSelectWindow;
        private System.Windows.Forms.TextBox tB_nHöhe;
        private System.Windows.Forms.TextBox tB_ohneHöhe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tB_Hmin;
        private System.Windows.Forms.TextBox tB_Hmax;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.Button bt_OpenPTFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_nPunkteFile;
        private System.Windows.Forms.TextBox tB_PTFilename;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tB_nPTÜbereinstimmung;
        private System.Windows.Forms.Button bt_markieren;
        private System.Windows.Forms.Button bt_löschen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tB_PTungültig;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_CASBlöcke;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_OffsetHeight;
        private System.Windows.Forms.Button bt_OffsetHeight;
    }
}