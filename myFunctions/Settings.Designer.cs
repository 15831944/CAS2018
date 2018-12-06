namespace CAS2018.myFunctions
{
    partial class Settings
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Allgemein");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Pt Import");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Pt Export");
            this.label1 = new System.Windows.Forms.Label();
            this.nUD_Height = new System.Windows.Forms.NumericUpDown();
            this.cB_Basislayer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cB_insert3d = new System.Windows.Forms.CheckBox();
            this.chkBox_RichtlinienMP = new System.Windows.Forms.CheckBox();
            this.ckB_UCScoords = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tView = new System.Windows.Forms.TreeView();
            this.pan_PtImport = new System.Windows.Forms.Panel();
            this.ckB_openExportfile = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cB_Extention = new System.Windows.Forms.ComboBox();
            this.pan_PtExport = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cB_AusgabeFormat = new System.Windows.Forms.ComboBox();
            this.tB_ExportFile = new System.Windows.Forms.TextBox();
            this.ckB_Header = new System.Windows.Forms.CheckBox();
            this.bt_search = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rTB_Header = new System.Windows.Forms.RichTextBox();
            this.ckB_PtExportFile = new System.Windows.Forms.CheckBox();
            this.pan_Allgemein = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pan_PtImport.SuspendLayout();
            this.pan_PtExport.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pan_Allgemein.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Höhe Nachkommastellen:";
            // 
            // nUD_Height
            // 
            this.nUD_Height.Location = new System.Drawing.Point(141, 17);
            this.nUD_Height.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUD_Height.Name = "nUD_Height";
            this.nUD_Height.Size = new System.Drawing.Size(34, 20);
            this.nUD_Height.TabIndex = 2;
            this.nUD_Height.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nUD_Height.ValueChanged += new System.EventHandler(this.nUD_Height_ValueChanged);
            // 
            // cB_Basislayer
            // 
            this.cB_Basislayer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cB_Basislayer.FormattingEnabled = true;
            this.cB_Basislayer.Location = new System.Drawing.Point(126, 73);
            this.cB_Basislayer.Name = "cB_Basislayer";
            this.cB_Basislayer.Size = new System.Drawing.Size(373, 21);
            this.cB_Basislayer.TabIndex = 6;
            this.cB_Basislayer.TabStop = false;
            this.cB_Basislayer.SelectedValueChanged += new System.EventHandler(this.cB_Basislayer_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Basislayer für Punkte:";
            // 
            // cB_insert3d
            // 
            this.cB_insert3d.AutoSize = true;
            this.cB_insert3d.Location = new System.Drawing.Point(10, 45);
            this.cB_insert3d.Name = "cB_insert3d";
            this.cB_insert3d.Size = new System.Drawing.Size(75, 17);
            this.cB_insert3d.TabIndex = 7;
            this.cB_insert3d.Text = "Punkte 3d";
            this.cB_insert3d.UseVisualStyleBackColor = true;
            this.cB_insert3d.CheckedChanged += new System.EventHandler(this.cB_insert3d_CheckedChanged);
            // 
            // chkBox_RichtlinienMP
            // 
            this.chkBox_RichtlinienMP.AutoSize = true;
            this.chkBox_RichtlinienMP.Location = new System.Drawing.Point(126, 100);
            this.chkBox_RichtlinienMP.Name = "chkBox_RichtlinienMP";
            this.chkBox_RichtlinienMP.Size = new System.Drawing.Size(204, 17);
            this.chkBox_RichtlinienMP.TabIndex = 9;
            this.chkBox_RichtlinienMP.Text = "Richtlinien für Messpunkte anwenden";
            this.chkBox_RichtlinienMP.UseVisualStyleBackColor = true;
            // 
            // ckB_UCScoords
            // 
            this.ckB_UCScoords.AutoSize = true;
            this.ckB_UCScoords.Location = new System.Drawing.Point(8, 131);
            this.ckB_UCScoords.Name = "ckB_UCScoords";
            this.ckB_UCScoords.Size = new System.Drawing.Size(107, 17);
            this.ckB_UCScoords.TabIndex = 10;
            this.ckB_UCScoords.Text = "BKS Koordinaten";
            this.ckB_UCScoords.UseVisualStyleBackColor = true;
            this.ckB_UCScoords.CheckedChanged += new System.EventHandler(this.cB_Zgeometry_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pan_PtImport);
            this.splitContainer1.Panel2.Controls.Add(this.pan_PtExport);
            this.splitContainer1.Panel2.Controls.Add(this.pan_Allgemein);
            this.splitContainer1.Size = new System.Drawing.Size(684, 361);
            this.splitContainer1.SplitterDistance = 128;
            this.splitContainer1.SplitterIncrement = 1000;
            this.splitContainer1.TabIndex = 11;
            // 
            // tView
            // 
            this.tView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tView.Location = new System.Drawing.Point(0, 0);
            this.tView.Name = "tView";
            treeNode1.Name = "Allgemein";
            treeNode1.Text = "Allgemein";
            treeNode2.Name = "PtImport";
            treeNode2.Text = "Pt Import";
            treeNode3.Name = "PtExport";
            treeNode3.Text = "Pt Export";
            this.tView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.tView.Size = new System.Drawing.Size(128, 361);
            this.tView.TabIndex = 0;
            this.tView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // pan_PtImport
            // 
            this.pan_PtImport.Controls.Add(this.ckB_openExportfile);
            this.pan_PtImport.Controls.Add(this.label4);
            this.pan_PtImport.Controls.Add(this.cB_Extention);
            this.pan_PtImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_PtImport.Location = new System.Drawing.Point(0, 0);
            this.pan_PtImport.Name = "pan_PtImport";
            this.pan_PtImport.Size = new System.Drawing.Size(552, 361);
            this.pan_PtImport.TabIndex = 20;
            this.pan_PtImport.Visible = false;
            // 
            // ckB_openExportfile
            // 
            this.ckB_openExportfile.AutoSize = true;
            this.ckB_openExportfile.Enabled = false;
            this.ckB_openExportfile.Location = new System.Drawing.Point(13, 45);
            this.ckB_openExportfile.Name = "ckB_openExportfile";
            this.ckB_openExportfile.Size = new System.Drawing.Size(162, 17);
            this.ckB_openExportfile.TabIndex = 22;
            this.ckB_openExportfile.Text = "Exportfile automatisch öffnen";
            this.ckB_openExportfile.UseVisualStyleBackColor = true;
            this.ckB_openExportfile.CheckedChanged += new System.EventHandler(this.ckB_openExportfile_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Default Extention:";
            // 
            // cB_Extention
            // 
            this.cB_Extention.FormattingEnabled = true;
            this.cB_Extention.Items.AddRange(new object[] {
            "csv",
            "dat"});
            this.cB_Extention.Location = new System.Drawing.Point(107, 13);
            this.cB_Extention.Name = "cB_Extention";
            this.cB_Extention.Size = new System.Drawing.Size(61, 21);
            this.cB_Extention.TabIndex = 20;
            this.cB_Extention.SelectedIndexChanged += new System.EventHandler(this.cB_Extention_SelectedIndexChanged);
            // 
            // pan_PtExport
            // 
            this.pan_PtExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pan_PtExport.Controls.Add(this.label2);
            this.pan_PtExport.Controls.Add(this.cB_AusgabeFormat);
            this.pan_PtExport.Controls.Add(this.tB_ExportFile);
            this.pan_PtExport.Controls.Add(this.ckB_Header);
            this.pan_PtExport.Controls.Add(this.bt_search);
            this.pan_PtExport.Controls.Add(this.panel1);
            this.pan_PtExport.Controls.Add(this.ckB_PtExportFile);
            this.pan_PtExport.Controls.Add(this.ckB_UCScoords);
            this.pan_PtExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_PtExport.Location = new System.Drawing.Point(0, 0);
            this.pan_PtExport.MaximumSize = new System.Drawing.Size(550, 360);
            this.pan_PtExport.MinimumSize = new System.Drawing.Size(550, 360);
            this.pan_PtExport.Name = "pan_PtExport";
            this.pan_PtExport.Size = new System.Drawing.Size(550, 360);
            this.pan_PtExport.TabIndex = 10;
            this.pan_PtExport.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Ausgabeformat:";
            // 
            // cB_AusgabeFormat
            // 
            this.cB_AusgabeFormat.FormattingEnabled = true;
            this.cB_AusgabeFormat.Items.AddRange(new object[] {
            "x,y,z",
            "x,z,y",
            "x,z,z"});
            this.cB_AusgabeFormat.Location = new System.Drawing.Point(114, 204);
            this.cB_AusgabeFormat.Name = "cB_AusgabeFormat";
            this.cB_AusgabeFormat.Size = new System.Drawing.Size(61, 21);
            this.cB_AusgabeFormat.TabIndex = 18;
            this.cB_AusgabeFormat.SelectedIndexChanged += new System.EventHandler(this.cB_AusgabeFormat_SelectedIndexChanged);
            // 
            // tB_ExportFile
            // 
            this.tB_ExportFile.Location = new System.Drawing.Point(27, 174);
            this.tB_ExportFile.Name = "tB_ExportFile";
            this.tB_ExportFile.Size = new System.Drawing.Size(482, 20);
            this.tB_ExportFile.TabIndex = 17;
            this.tB_ExportFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ckB_Header
            // 
            this.ckB_Header.AutoSize = true;
            this.ckB_Header.Location = new System.Drawing.Point(10, 8);
            this.ckB_Header.Name = "ckB_Header";
            this.ckB_Header.Size = new System.Drawing.Size(61, 17);
            this.ckB_Header.TabIndex = 0;
            this.ckB_Header.Text = "Header";
            this.ckB_Header.UseVisualStyleBackColor = true;
            this.ckB_Header.CheckedChanged += new System.EventHandler(this.cB_Header_CheckedChanged);
            // 
            // bt_search
            // 
            this.bt_search.BackgroundImage = global::CAS2018.Resources.Icon_Durchsuchen;
            this.bt_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_search.Location = new System.Drawing.Point(515, 170);
            this.bt_search.Name = "bt_search";
            this.bt_search.Size = new System.Drawing.Size(32, 26);
            this.bt_search.TabIndex = 16;
            this.bt_search.UseVisualStyleBackColor = true;
            this.bt_search.Click += new System.EventHandler(this.bt_search_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rTB_Header);
            this.panel1.Location = new System.Drawing.Point(9, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 91);
            this.panel1.TabIndex = 14;
            // 
            // rTB_Header
            // 
            this.rTB_Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTB_Header.EnableAutoDragDrop = true;
            this.rTB_Header.Font = new System.Drawing.Font("SansSerif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.rTB_Header.Location = new System.Drawing.Point(0, 0);
            this.rTB_Header.Name = "rTB_Header";
            this.rTB_Header.Size = new System.Drawing.Size(531, 91);
            this.rTB_Header.TabIndex = 0;
            this.rTB_Header.Text = "";
            this.rTB_Header.TextChanged += new System.EventHandler(this.rTB_Header_TextChanged);
            // 
            // ckB_PtExportFile
            // 
            this.ckB_PtExportFile.AutoSize = true;
            this.ckB_PtExportFile.Location = new System.Drawing.Point(9, 154);
            this.ckB_PtExportFile.Name = "ckB_PtExportFile";
            this.ckB_PtExportFile.Size = new System.Drawing.Size(91, 17);
            this.ckB_PtExportFile.TabIndex = 11;
            this.ckB_PtExportFile.Text = "Ausgabedatei";
            this.ckB_PtExportFile.UseVisualStyleBackColor = true;
            this.ckB_PtExportFile.CheckedChanged += new System.EventHandler(this.cB_PtExportFile_CheckedChanged);
            // 
            // pan_Allgemein
            // 
            this.pan_Allgemein.Controls.Add(this.label1);
            this.pan_Allgemein.Controls.Add(this.nUD_Height);
            this.pan_Allgemein.Controls.Add(this.chkBox_RichtlinienMP);
            this.pan_Allgemein.Controls.Add(this.cB_insert3d);
            this.pan_Allgemein.Controls.Add(this.cB_Basislayer);
            this.pan_Allgemein.Controls.Add(this.label3);
            this.pan_Allgemein.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_Allgemein.Location = new System.Drawing.Point(0, 0);
            this.pan_Allgemein.Name = "pan_Allgemein";
            this.pan_Allgemein.Size = new System.Drawing.Size(552, 361);
            this.pan_Allgemein.TabIndex = 0;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Einstellungen";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Height)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pan_PtImport.ResumeLayout(false);
            this.pan_PtImport.PerformLayout();
            this.pan_PtExport.ResumeLayout(false);
            this.pan_PtExport.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pan_Allgemein.ResumeLayout(false);
            this.pan_Allgemein.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUD_Height;
        private System.Windows.Forms.ComboBox cB_Basislayer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cB_insert3d;
        private System.Windows.Forms.CheckBox chkBox_RichtlinienMP;
        private System.Windows.Forms.CheckBox ckB_UCScoords;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tView;
        private System.Windows.Forms.Panel pan_Allgemein;
        private System.Windows.Forms.Panel pan_PtExport;
        private System.Windows.Forms.CheckBox ckB_PtExportFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_search;
        private System.Windows.Forms.TextBox tB_ExportFile;
        private System.Windows.Forms.CheckBox ckB_Header;
        private System.Windows.Forms.RichTextBox rTB_Header;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cB_AusgabeFormat;
        private System.Windows.Forms.Panel pan_PtImport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cB_Extention;
        private System.Windows.Forms.CheckBox ckB_openExportfile;
    }
}