using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;

namespace CAS2018.myAutoCAD
{
    public partial class myLayer
    {
        private List<Autodesk.AutoCAD.DatabaseServices.LayerTableRecord> m_lsLayerTableRecord = new List<LayerTableRecord>();

        //Konstruktor (damit kein Default Konstruktor generiert wird!)
        protected myLayer()
        {
            //Datenbank
            try {
                Database db = HostApplicationServices.WorkingDatabase;
                Transaction myT = db.TransactionManager.StartTransaction();

                using (DocumentLock dl = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument())
                {
                    LayerTable layT = (LayerTable)myT.GetObject(db.LayerTableId, OpenMode.ForRead);

                    //Layernamen in Liste schreiben
                    foreach (ObjectId id in layT)
                    {
                        LayerTableRecord ltr = (LayerTableRecord)(myT.GetObject(id, OpenMode.ForRead));

                        m_lsLayerTableRecord.Add(ltr);
                    }
                }

                myT.Commit();
                myT.Dispose();
            }
            catch { }
        }
        //Properties
        public List<Autodesk.AutoCAD.DatabaseServices.LayerTableRecord> lsLayerTableRecord
        {
            get { return m_lsLayerTableRecord; }
        }

        //Methoden
        //neuen Layer anlegen
        public void add(string Name)
        {
            //Datenbank
            Database db = HostApplicationServices.WorkingDatabase;
            Transaction myT = db.TransactionManager.StartTransaction();

            using (DocumentLock dl = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument())
            {
                LayerTable layT = (LayerTable)myT.GetObject(db.LayerTableId, OpenMode.ForWrite);

                if (!layT.Has(Name))
                {
                    LayerTableRecord layTR = new LayerTableRecord();
                    layTR.Name = Name;
                    layT.Add(layTR);
                    m_lsLayerTableRecord.Add(layTR);
                    myT.AddNewlyCreatedDBObject(layTR, true);
                }
            }
            myT.Commit();
            myT.Dispose();
        }

        public void refresh()
        {
            //Datenbank
            Database db = HostApplicationServices.WorkingDatabase;

            if (db != null)
            {
                Transaction myT = db.TransactionManager.StartTransaction();

                using (DocumentLock dl = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument())
                {
                    LayerTable layT = (LayerTable)myT.GetObject(db.LayerTableId, OpenMode.ForRead);
                    m_lsLayerTableRecord.Clear();

                    //Layernamen in Liste schreiben
                    foreach (ObjectId id in layT)
                    {
                        LayerTableRecord ltr = (LayerTableRecord)(myT.GetObject(id, OpenMode.ForRead));

                        m_lsLayerTableRecord.Add(ltr);
                    }
                }

                myT.Commit();
                myT.Dispose();
            }
        }

        //Layerliste in csv exportieren
        public void export()
        {
            myAutoCAD.myLayer objLayer = myAutoCAD.myLayer.Instance;

            SaveFileDialog ddSaveFile = new SaveFileDialog();
            ddSaveFile.DefaultExt = "csv";
            ddSaveFile.Filter = "Layerliste|*.csv";
            string dwgName = HostApplicationServices.WorkingDatabase.Filename;
            ddSaveFile.InitialDirectory = dwgName.Substring(0, dwgName.LastIndexOf('\\'));
            ddSaveFile.FileName = dwgName.Substring(dwgName.LastIndexOf('\\') +1, dwgName.LastIndexOf('.'));

            if (ddSaveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(ddSaveFile.FileName, false, Encoding.Default);

                foreach (Autodesk.AutoCAD.DatabaseServices.LayerTableRecord objLTR in objLayer.lsLayerTableRecord)
                {
                    string Zeile = objLTR.Name + ";";
                    Zeile += objLTR.Color.ToString() + ";";

                    sw.WriteLine(Zeile);
                }
                sw.Close();
            }
        }

        /// <summary>
        /// Prüft, ob Layer vorhanden. Kann diesen anlegen.
        /// </summary>
        /// <param name="Layer"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        public bool checkLayer(string Layer, bool create)
        {
            bool LayerExists = false;

            if (Layer != null)
            {
                List<string> lsLayer = new List<string>();

                foreach (LayerTableRecord ltr in m_lsLayerTableRecord)
                    lsLayer.Add(ltr.Name);

                if (lsLayer.Contains(Layer))
                    LayerExists = true;
                else
                {
                    if (create)
                        add(Layer);
                }
            }
            return LayerExists;
        }

        public bool isBlockLayer(string Layer)
        {
            bool blockLayer = false;

            if (Layer.Length > 2)
            {
                if (Layer.Substring(Layer.Length - 2, 2) == "-P")
                    blockLayer = true;
            }

            return blockLayer;
        }

        //Instanz (Singleton)
        public static myLayer Instance
        {
            get { return myLayerCreator.createInstance; }
        }

        private sealed class myLayerCreator
        {
            private static readonly myLayer _Instance = new myLayer();

            public static myLayer createInstance
            {
                get { return _Instance; }
            }
        }
    }
}
