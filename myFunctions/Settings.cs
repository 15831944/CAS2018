using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using Autodesk.AutoCAD.DatabaseServices;

namespace CAS2018.myFunctions
{
    public partial class Settings : Form
    {
        myRegistry.regIO objRegistry = new myRegistry.regIO();

        public Settings()
        {
            InitializeComponent();

            try
            {
                cB_insert3d.Checked = Convert.ToBoolean(objRegistry.readValue("blocks", "insert3d"));
                ckB_Header.Checked = Convert.ToBoolean(objRegistry.readValue("PT-Export", "isHeader"));
                rTB_Header.Text = Convert.ToString(objRegistry.readValue("PT-Export", "Header"));
                ckB_UCScoords.Checked = Convert.ToBoolean(objRegistry.readValue("PT-Export", "UCScoords"));
                ckB_PtExportFile.Checked = Convert.ToBoolean(objRegistry.readValue("PT-Export", "isExportFile"));
                tB_ExportFile.Text = Convert.ToString(objRegistry.readValue("PT-Export", "ExportFile"));
                cB_AusgabeFormat.SelectedIndex = Convert.ToInt32(objRegistry.readValue("PT-Export", "AusgabeFormat"));
                cB_Extention.SelectedIndex = Convert.ToInt32(objRegistry.readValue("PT-Import", "Default Extention"));
                ckB_openExportfile.Checked = Convert.ToBoolean(objRegistry.readValue("PT-Import", "openExportFile"));
                nUD_Height.Value = (int) objRegistry.readValue("blocks", "Kommastellen");


                //Basislayer
                myAutoCAD.myLayer objLayer = myAutoCAD.myLayer.Instance;
                objLayer.refresh();

                string Basislayer = (string) objRegistry.readValue("blocks", "Basislayer");

                //objLayer.checkLayer(Basislayer,true);

                foreach (LayerTableRecord ltr in objLayer.lsLayerTableRecord)
                {
                    string layName = ltr.Name;
                    if (layName.Length > 2)
                    {
                        if (layName.Substring(layName.Length - 2, 2) == "-P")
                            cB_Basislayer.Items.Add(layName);
                    }
                }

                cB_Basislayer.Text = Basislayer;
            }
            catch { }
        }

        //Properties
        public int HeightPrecision
        {
            get { return (int) nUD_Height.Value; }
        }

        public bool Punkte3D
        {
            get 
            { return cB_insert3d.Checked; }
        }

        public bool isHeader
        {
            get { return ckB_Header.Checked; }
        }

        public string Header
        {
            get { return rTB_Header.Text; }
        }

        public bool isExportFile
        { get { return ckB_PtExportFile.Checked; } }

        public string ExportFile
        { get { return tB_ExportFile.Text; } }

        public bool UCScoords
        {
            get { return ckB_UCScoords.Checked; }
        }

        public string Extention
        {
            get { return (string) cB_Extention.SelectedItem; }
        }
        public int AusgabeFormat
        {
            get { return cB_AusgabeFormat.SelectedIndex; }
        }

        public bool openExportFile
        {
            get { return ckB_openExportfile.Checked; }
        }

        //Methoden
        private void bt_OK_Click(object sender, EventArgs e)
        {
            string Basislayer = cB_Basislayer.Text;
            bool textOK = false;
            if (cB_Basislayer.Text.Length > 2 )
            {
                if (Basislayer.Substring(Basislayer.Length - 2, 2) == "-P")
                {
                    myAutoCAD.myLayer objLayer = myAutoCAD.myLayer.Instance;
                    
                    myRegistry.regIO objRegIO = new myRegistry.regIO();
                    objRegIO.regValue("blocks", "Basislayer", cB_Basislayer.Text);
                    textOK = true;
                }
            }

            if (!textOK)
                MessageBox.Show("Basislayer müssen dem Format \"*-P\" entsprechen!");

            else
                Close();
        }

        private void nUD_Height_ValueChanged(object sender, EventArgs e)
        {
            objRegistry.regValue("blocks", "Kommastellen", Convert.ToInt32(nUD_Height.Value));
        }

        private void cB_insert3d_CheckedChanged(object sender, EventArgs e)
        {
            objRegistry.regValue("blocks", "insert3d", cB_insert3d.Checked);
        }

        private void cB_Basislayer_SelectedValueChanged(object sender, EventArgs e)
        {
            myRegistry.regIO objRegIO = new myRegistry.regIO();
            objRegIO.regValue("blocks", "Basislayer", cB_Basislayer.SelectedItem);
        }

        private void cB_Zgeometry_CheckedChanged(object sender, EventArgs e)
        {
            objRegistry.regValue("PT-Export", "UCScoords", ckB_UCScoords.Checked);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (tView.SelectedNode.Name)
                {
                case "Allgemein":
                    foreach (TreeNode tNode in tView.Nodes)
                        { tNode.BackColor = Color.White; }
                    tView.SelectedNode.BackColor = Color.Aqua;
                    pan_Allgemein.Visible = true;
                    pan_PtImport.Visible = false;
                    pan_PtExport.Visible = false;

                    break;

                case "PtImport":
                    foreach (TreeNode tNode in tView.Nodes)
                        { tNode.BackColor = Color.White; }
                    tView.SelectedNode.BackColor = Color.Aqua;
                    pan_Allgemein.Visible = false;
                    pan_PtImport.Visible = true;
                    pan_PtExport.Visible = false;
                    break;

                case "PtExport":
                    foreach (TreeNode tNode in tView.Nodes)
                        { tNode.BackColor = Color.White; }
                    tView.SelectedNode.BackColor = Color.Aqua;
                    pan_Allgemein.Visible = false;
                    pan_PtImport.Visible = false;
                    pan_PtExport.Visible = true;
                    break;
            }
        }

        private void cB_Header_CheckedChanged(object sender, EventArgs e)
        {
            objRegistry.regValue("PT-Export", "isHeader", ckB_Header.Checked);
        }

        private void rTB_Header_TextChanged(object sender, EventArgs e)
        {
            objRegistry.regValue("PT-Export", "Header", rTB_Header.Text);
        }

        private void cB_PtExportFile_CheckedChanged(object sender, EventArgs e)
        {
            objRegistry.regValue("PT-Export", "isExportFile", ckB_PtExportFile.Checked);

            if (ckB_PtExportFile.Checked)
                ckB_openExportfile.Enabled = true;
            else
                ckB_openExportfile.Enabled = false;
        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            SaveFileDialog diaFileSave = new SaveFileDialog();
            diaFileSave.Filter = "Punktwolke|*.csv";

            if (diaFileSave.ShowDialog() == DialogResult.OK)
            {
                tB_ExportFile.Text = diaFileSave.FileName.ToString();
                objRegistry.regValue("PT-Export", "ExportFile", diaFileSave.FileName.ToString());
            }
        }

        private void cB_AusgabeFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            objRegistry.regValue("PT-Export", "AusgabeFormat", cB_AusgabeFormat.SelectedIndex);
        }

        private void cB_Extention_SelectedIndexChanged(object sender, EventArgs e)
        {
            objRegistry.regValue("PT-Import", "Default Extention", cB_Extention.SelectedIndex);
        }

        private void ckB_openExportfile_CheckedChanged(object sender, EventArgs e)
        {
            objRegistry.regValue("PT-Import", "openExportFile", ckB_openExportfile.Checked);
        }
    }
}
