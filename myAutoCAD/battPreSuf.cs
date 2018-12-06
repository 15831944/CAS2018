using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using CAS2018.myAutoCAD;

namespace CAS2018.myFunctions
{
    public partial class battPreSuf : Form
    {
        private Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
        private Blöcke m_objBlöcke = Blöcke.Instance;
        private List<Messpunkt> m_lsMP = new List<Messpunkt>();

        public battPreSuf()
        {
            InitializeComponent();

            Database db = HostApplicationServices.WorkingDatabase;
            Autodesk.AutoCAD.DatabaseServices.TransactionManager myTm = db.TransactionManager;
            Transaction myT = db.TransactionManager.StartTransaction();
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_BlockWahl_Click(object sender, EventArgs e)
        {
            //Messpunkte abfragen
            m_objBlöcke.init();
            m_objBlöcke.selectWindow();

            tslb_AnzahlBlöcke.Text = m_objBlöcke.count.ToString();
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            Messpunkt[] vMP = m_objBlöcke.getMP;

            for (int i =0; i < m_objBlöcke.count; i++)
            {
                Messpunkt objMP = vMP[i];
                objMP.Prefix = tb_Prefix.Text;

            }
        }
    }
}
