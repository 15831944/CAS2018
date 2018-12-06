using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Globalization;

using CAS2018.myAutoCAD;
using Autodesk.AutoCAD.EditorInput;

namespace CAS2018.myFunctions
{
    partial class PtImport
    {
        private List<Messpunkt> m_lsMP = new List<Messpunkt>();
        private string m_Filename;                                  //gewählter File Name
        private string m_Extention;                                 //gewähltes Fileformat
        private string m_Text;
        private string[] m_arText;                                  //Array mit Zeilen
        private List<string[]> m_arPunkte = new List<string[]>();
        private myAutoCAD.myUtilities m_Util = new myAutoCAD.myUtilities();
        private myFunctions.Settings m_Settings = new Settings();
        private myRegistry.regIO m_objRegIO = new myRegistry.regIO();
        
        public void run()
        {
            OpenFileDialog ddOpenFile = new OpenFileDialog();
            ddOpenFile.Title = "Vermessungspunkte importieren";
            ddOpenFile.Filter = "Punktwolke|*.csv|Punktwolke|*.dat";
            ddOpenFile.DefaultExt = m_Settings.Extention;
            Editor m_ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;

            DialogResult diagRes = DialogResult.None;

            if (!m_Settings.openExportFile)
                diagRes = ddOpenFile.ShowDialog();
            else
            {
                ddOpenFile.FileName = m_Settings.ExportFile;
                diagRes = DialogResult.OK;
            }

            if (diagRes == DialogResult.OK)
            {
                bool fileOK = true;
                m_Filename = ddOpenFile.FileName;

                try
                {
                    StreamReader sr = new StreamReader(m_Filename, Encoding.Default);
                    m_Text = sr.ReadToEnd();
                    sr.Close();
                }
                catch { fileOK = false; }

                if (fileOK)
                {
                    m_Extention = m_Filename.Substring(m_Filename.LastIndexOf('.') + 1).ToLower();
                    string[] arZeile;

                    string PNum;
                    double Rechtswert = new double();
                    double Hochwert = new double();
                    double Höhe = new double();
                    double? Höhenwert = new Double();

                    myRegistry.regIO objRegIO = new myRegistry.regIO();
                    string Basislayer = (string)objRegIO.readValue("blocks", "Basislayer");

                    //Basislayer ggf. anlegen
                    myAutoCAD.myLayer objLayer = myAutoCAD.myLayer.Instance;
                    objLayer.checkLayer(Basislayer, true);

                    int Zähler = 0;
                    int iZeile = 1;

                    switch (m_Extention)
                    {

                        case "dat":
                            bool bDatFehler = false;

                            m_arText = m_Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                            //Zeilen von MP in Array einfügen
                            foreach (string Zeile in m_arText)
                            {
                                arZeile = Zeile.Split(new char[] { (char)32 }, StringSplitOptions.RemoveEmptyEntries);
                                m_arPunkte.Add(arZeile);

                                if (arZeile.Length < 3)
                                {
                                    bDatFehler = true;
                                    break;
                                }
                                iZeile++;
                            }

                            if (!bDatFehler)
                            {
                                foreach (string[] Zeile in m_arPunkte)
                                {
                                    bool bFehler = false;

                                    PNum = Zeile[0];
                                    if (m_Util.convertToDouble(Zeile[1], ref Rechtswert, null) != Autodesk.AutoCAD.Runtime.ErrorStatus.OK)
                                        bFehler = true;
                                    if (m_Util.convertToDouble(Zeile[2], ref Hochwert, null) != Autodesk.AutoCAD.Runtime.ErrorStatus.OK)
                                        bFehler = true;

                                    Autodesk.AutoCAD.Runtime.ErrorStatus eSHöhe = m_Util.convertToDouble(Zeile[3], ref Höhe, null);
                                                                        
                                    if (!(eSHöhe == Autodesk.AutoCAD.Runtime.ErrorStatus.OK || eSHöhe == Autodesk.AutoCAD.Runtime.ErrorStatus.NullExtents))
                                        bFehler = true;

                                    //Nachkommastellen Höhe
                                    myAutoCAD.myUtilities objUtil = new myAutoCAD.myUtilities();
                                    int Precision = objUtil.Precision(Zeile[3]);
                                    double CASHöhe = Höhe;

                                    Höhe = Math.Round(Höhe, Convert.ToInt32(m_objRegIO.readValue("blocks", "Kommastellen")));

                                    //Att3 (Datum)
                                    string Att3 = String.Empty;
                                    try
                                    {
                                        if (Zeile[4] != "" && Zeile[4] != "\r")
                                            Att3 = Zeile[4];
                                    }
                                    catch { }

                                    //Att4 (Code)
                                    string Att4 = String.Empty;
                                    try
                                    {
                                        if (Zeile[5] != "" && Zeile[5] != "\r")
                                            Att4 = Zeile[5];
                                    }
                                    catch { }

                                    //Att5 (Hersteller)
                                    string Att5 = String.Empty;
                                    try
                                    {
                                        if (Zeile[6] != "" && Zeile[6] != "\r")
                                            Att5 = Zeile[6];
                                    }
                                    catch { }

                                    if (!bFehler)
                                    {
                                        //Höhe
                                        if (eSHöhe == Autodesk.AutoCAD.Runtime.ErrorStatus.NullExtents)
                                            Höhenwert = null;
                                        else
                                            Höhenwert = Höhe;

                                        myAutoCAD.Messpunkt objMP = new Messpunkt(PNum, Rechtswert, Hochwert, Höhenwert, CASHöhe, Precision);

                                        if (Att3 != String.Empty)
                                            objMP.Att3_Wert = Att3;

                                        if (Att4 != String.Empty)
                                            objMP.Att4_Wert = Att4;

                                        if (Att5 != String.Empty)
                                            objMP.Att5_Wert = Att5;

                                        if (objMP.draw("MP", Basislayer) == Autodesk.AutoCAD.Runtime.ErrorStatus.OK)
                                            Zähler += 1;
                                        else
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Fehler in dat File! (Zeile: " + iZeile.ToString());
                            }

                            break;

                        case "csv":
                            m_arText = m_Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                            //Zeilen von MP in Array einfügen
                            foreach (string Zeile in m_arText)
                            {
                                arZeile = Zeile.Split(new char[] { ';' }, StringSplitOptions.None);
                                m_arPunkte.Add(arZeile);
                            }

                            foreach (string[] Zeile in m_arPunkte)
                            {
                                bool bFehler = false;
                                Rechtswert = new Double();
                                Hochwert = new Double();
                                Höhe = new Double();
                                string Blockname = String.Empty;

                                PNum = Zeile[0];
                                if (m_Util.convertToDouble(Zeile[1], ref Rechtswert, null) != Autodesk.AutoCAD.Runtime.ErrorStatus.OK)
                                    bFehler = true;
                                if (m_Util.convertToDouble(Zeile[2], ref Hochwert, null) != Autodesk.AutoCAD.Runtime.ErrorStatus.OK)
                                    bFehler = true;

                                Autodesk.AutoCAD.Runtime.ErrorStatus eSHöhe = m_Util.convertToDouble(Zeile[3], ref Höhe, null);
                                if (!(eSHöhe == Autodesk.AutoCAD.Runtime.ErrorStatus.OK || eSHöhe == Autodesk.AutoCAD.Runtime.ErrorStatus.NullExtents))
                                    bFehler = true;

                                //Nachkommastellen Höhe
                                myAutoCAD.myUtilities objUtil = new myAutoCAD.myUtilities();
                                int Precision = objUtil.Precision(Zeile[3]);
                                double CASHöhe = Höhe;

                                Höhe = Math.Round(Höhe, Convert.ToInt32(m_objRegIO.readValue("blocks", "Kommastellen")));

                                //Blockname
                                try
                                {
                                    if (Zeile[4] != "" && Zeile[4] != "\r")
                                        Blockname = Zeile[4];
                                }
                                catch { }

                                //Att3 (Datum)
                                string Att3 = String.Empty;
                                try
                                {
                                    if (Zeile[4] != "" && Zeile[4] != "\r")
                                        Att3 = Zeile[4];
                                }
                                catch { }

                                //Att4 (Code)
                                string Att4 = String.Empty;
                                try
                                {
                                    if (Zeile[5] != "" && Zeile[5] != "\r")
                                        Att4 = Zeile[5];
                                }
                                catch { }

                                //Att5 (Hersteller)
                                string Att5 = String.Empty;
                                try
                                {
                                    if (Zeile[6] != "" && Zeile[6] != "\r")
                                        Att5 = Zeile[6];
                                }
                                catch { }

                                //Att6
                                string Att6 = String.Empty;
                                try
                                {
                                    if (Zeile[7] != "" && Zeile[7] != "\r")
                                        Att6 = Zeile[7];
                                }
                                catch { }

                                //Att7
                                string Att7 = String.Empty;
                                try
                                {
                                    if (Zeile[8] != "" && Zeile[8] != "\r")
                                        Att7 = Zeile[8];
                                }
                                catch { }

                                //Att8
                                string Att8 = String.Empty;
                                try
                                {
                                    if (Zeile[9] != "" && Zeile[9] != "\r")
                                        Att8 = Zeile[9];
                                }
                                catch { }

                                //Att9
                                string Att9 = String.Empty;
                                try
                                {
                                    if (Zeile[10] != "" && Zeile[10] != "\r")
                                        Att9 = Zeile[10];
                                }
                                catch { }

                                //Att10
                                string Att10 = String.Empty;
                                try
                                {
                                    if (Zeile[11] != "" && Zeile[11] != "\r")
                                        Att10 = Zeile[11];
                                }
                                catch { }

                                if (!bFehler)
                                {
                                    //Höhe
                                    if (eSHöhe == Autodesk.AutoCAD.Runtime.ErrorStatus.NullExtents)
                                        Höhenwert = null;
                                    else
                                        Höhenwert = Höhe;

                                    myAutoCAD.Messpunkt objMP = new Messpunkt(PNum, Rechtswert, Hochwert, Höhenwert, CASHöhe, Precision, Blockname);

                                    if (Att3 != String.Empty)
                                        objMP.Att3_Wert = Att3;

                                    if (Att4 != String.Empty)
                                        objMP.Att4_Wert = Att4;

                                    if (Att5 != String.Empty)
                                        objMP.Att5_Wert = Att5;

                                    if (Att6 != String.Empty)
                                        objMP.Att6_Wert = Att6;

                                    if (Att7 != String.Empty)
                                        objMP.Att7_Wert = Att7;

                                    if (Att8 != String.Empty)
                                        objMP.Att8_Wert = Att8;

                                    if (Att9 != String.Empty)
                                        objMP.Att9_Wert = Att9;

                                    if (Att10 != String.Empty)
                                        objMP.Att10_Wert = Att10;

                                    if (objMP.draw("MP", Basislayer) == Autodesk.AutoCAD.Runtime.ErrorStatus.OK)
                                        Zähler += 1;
                                    else
                                        break;
                                }
                            }

                            break;
                    }

                    MessageBox.Show(Zähler.ToString() + " Punkte importiert!");
                    m_ed.Regen();

                    //Object acadObject = Autodesk.AutoCAD.ApplicationServices.Application.AcadApplication;
                    //acadObject.GetType().InvokeMember("ZoomExtents", BindingFlags.InvokeMethod, null, acadObject, null);

                }
                else
                    MessageBox.Show(m_Filename + " kann nicht geöffnet werden!");
            }
        }
    }
}
