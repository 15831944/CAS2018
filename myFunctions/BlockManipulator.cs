using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using CAS2018.myAutoCAD;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

namespace CAS2018.myFunctions
{
    public partial class BlockManipulator : Form
    {
        private myAutoCAD.Blöcke m_Blöcke = myAutoCAD.Blöcke.Instance;
        
        private List<Messpunkt> m_lsMP = new List<Messpunkt>();
        private string m_Filename;                                  //gewählter File Name
        private string m_Extention;                                 //gewähltes Fileformat
        private string m_Text;
        List<Messpunkt> m_lsMPÜbereinstimmung = new List<Messpunkt>();
        private Editor m_ed = Autodesk.AutoCAD.ApplicationServices .Application.DocumentManager.MdiActiveDocument.Editor;
        private myAutoCAD.myUtilities m_Util = new myAutoCAD.myUtilities();

        myRegistry.regIO objRegIO = new myRegistry.regIO();


        public BlockManipulator()
        {
            InitializeComponent();

            m_Blöcke.init();        
            //tB_Kommastellen.Text = objRegIO.readValue("blocks", "Kommastellen").ToString();
        }

        //Properties
        public int CASBlöcke
        {
            set { tb_CASBlöcke.Text =  value.ToString(); }
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            m_Blöcke.Dispose();
            Close();
        }

        private void bt_selectWindow_Click(object sender, EventArgs e)
        {
            m_Blöcke.selectWindow();
            tB_nBlöcke.Text = m_Blöcke.count.ToString();
            tB_nHöhe.Text = m_Blöcke.countHeigths.ToString();
            tB_ohneHöhe.Text = m_Blöcke.countEmptyHeigths.ToString();
            tB_Hmin.Text = m_Blöcke.getHmin.ToString();
            tB_Hmax.Text = m_Blöcke.getHmax.ToString();
        }

        private void bt_OpenPTFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ddOpenFile = new OpenFileDialog();
            ddOpenFile.Title = "Vermessungspunkte importieren";
            ddOpenFile.Filter = "Punktwolke|*.csv";
            ddOpenFile.DefaultExt = "csv";

            string[] arText;                                  //Array mit Zeilen
            List<string[]> arPunkte = new List<string[]>();
            arPunkte.Clear();
            m_lsMP.Clear();
            tB_nPTÜbereinstimmung.Text = "";
            m_lsMPÜbereinstimmung.Clear();

            Editor m_ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;

            if (ddOpenFile.ShowDialog() == DialogResult.OK)
            {
                m_Filename = ddOpenFile.FileName;
                StreamReader sr = new StreamReader(m_Filename, Encoding.Default);
                m_Text = sr.ReadToEnd();
                sr.Close();

                m_Extention = m_Filename.Substring(m_Filename.LastIndexOf('.') + 1).ToLower();
                string[] arZeile;
                int iZeile = 1;

                switch (m_Extention)
                {
                    case "csv": 
                        arText = m_Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                        //Zeilen von MP in Array einfügen
                        foreach (string Zeile in arText)
                        {
                            arZeile = Zeile.Split(new char[] { ';' }, StringSplitOptions.None);
                            arPunkte.Add(arZeile);
                        }

                       foreach (string[] Zeile in arPunkte)
                        {
                            string PNum;
                            double Rechtswert = new double();
                            double Hochwert = new double();
                            double Höhe = new double();
                            double? Höhenwert = null;
                            bool bFehler = false;
                            Autodesk.AutoCAD.Runtime.ErrorStatus es;

                            PNum = Zeile[0];
                            if (m_Util.convertToDouble(Zeile[1], ref Rechtswert, iZeile) != Autodesk.AutoCAD.Runtime.ErrorStatus.OK)
                                bFehler = true;
                            if (m_Util.convertToDouble(Zeile[2], ref Hochwert, iZeile) != Autodesk.AutoCAD.Runtime.ErrorStatus.OK)
                                bFehler = true;
                            es = m_Util.convertToDouble(Zeile[3], ref Höhe, iZeile);
                            if (es == Autodesk.AutoCAD.Runtime.ErrorStatus.OK)
                                Höhenwert = Höhe;

                            if (es != Autodesk.AutoCAD.Runtime.ErrorStatus.OK || es != Autodesk.AutoCAD.Runtime.ErrorStatus.NullPtr)
                                bFehler = false;

                            //Nachkommastellen Höhe
                            myAutoCAD.myUtilities objUtil = new myAutoCAD.myUtilities();
                            int Precision = objUtil.Precision(Zeile[3]);

                            if (!bFehler)
                            {
                                myAutoCAD.Messpunkt objMP = new Messpunkt(PNum, Rechtswert, Hochwert, Höhenwert, Höhenwert, Precision);
                                objMP.Att4_Wert = myUtilities.Global.Owner;

                                m_lsMP.Add(objMP);
                            }
                            iZeile++;
                        }

                        //Bestimmen der Punkte mit Übereinstimmung Punktdatenfile mit Zeichnung
                        foreach (Messpunkt MP in m_lsMP)
                        {
                            Messpunkt objMP = new Messpunkt();
                            if (m_Blöcke.findPos(ref objMP, new Autodesk.AutoCAD.Geometry.Point2d(MP.Position.X, MP.Position.Y), 0.01) == ErrorStatus.OK)
                                m_lsMPÜbereinstimmung.Add(objMP);
                        }

                        //Ausgabe Dialogbox
                        tB_PTFilename.Text = m_Filename;
                        tb_nPunkteFile.Text = m_lsMP.Count.ToString();
                        tB_nPTÜbereinstimmung.Text = m_lsMPÜbereinstimmung.Count.ToString();

                        if (m_lsMPÜbereinstimmung.Count > 0)
                        {
                            bt_markieren.Enabled = true;
                            bt_löschen.Enabled = true;
                        }

                        break;
                }        
            }
        }

        private void bt_markieren_Click(object sender, EventArgs e)
        {
            foreach (Messpunkt MP in m_lsMPÜbereinstimmung)
            {
                m_Blöcke.setMarker(MP.Position, "Match");

                m_ed.Regen();
                Object acadObject = Autodesk.AutoCAD.ApplicationServices.Application.AcadApplication;
                //acadObject.GetType().InvokeMember("ZoomExtents", BindingFlags.InvokeMethod, null, acadObject, null);
            }
        }

        private void bt_löschen_Click(object sender, EventArgs e)
        {
            int Zähler = 0;

            foreach (Messpunkt MP in m_lsMPÜbereinstimmung)
            {
                if (MP.delete() == Autodesk.AutoCAD.Runtime.ErrorStatus.OK)
                    Zähler++;
            }

            tB_nPTÜbereinstimmung.Text = (m_lsMPÜbereinstimmung.Count - Zähler).ToString();
            MessageBox.Show(Zähler.ToString() + " Punkte gelöscht!");
        }

        private void bt_KommaSelectWindow_Click(object sender, EventArgs e)
        {
            Blöcke objBlöcke = Blöcke.Instance;
            objBlöcke.selectWindow();
            //objBlöcke.Kommastellen(Convert.ToInt32(tB_Kommastellen.Text));
        }

        private void bt_OffsetHeight_Click(object sender, EventArgs e)
        {
            double offsetHeight = Convert.ToDouble(tb_OffsetHeight.Text);
            m_Blöcke.addHeigth(offsetHeight);

            
        }

        //nur Dezimalzahlen werden zugelassen
        private void tb_OffsetHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
