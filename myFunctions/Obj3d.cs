using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CAS2018.myAutoCAD;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;

namespace CAS2018.myFunctions
{
    class Obj3d
    {
        private Editor m_ed = Application.DocumentManager.MdiActiveDocument.Editor;

        //Listen für die verschiedenen Polylinientypen
        private Dictionary<ObjectId, Polyline> m_PolylineCollection = new Dictionary<ObjectId, Polyline>();
        private Dictionary<ObjectId, Polyline2d> m_Polyline2dCollection = new Dictionary<ObjectId, Polyline2d>();
        private List<PolylineCurve2d> m_PolylineCurve2dCollection = new List<PolylineCurve2d>();
        private Dictionary<ObjectId, Line> m_LineCollection = new Dictionary<ObjectId, Line>();
        private List<Messpunkt> m_lsMP_Error = new List<Messpunkt>();

        public void run()
        {
            if (selectPL() == ErrorStatus.OK)
                convertTo3d();
        }

        private ErrorStatus selectPL()
        {
            Database db = HostApplicationServices.WorkingDatabase;
            Autodesk.AutoCAD.DatabaseServices.TransactionManager myTm = db.TransactionManager;
            Transaction myT = db.TransactionManager.StartTransaction();
            ErrorStatus es = ErrorStatus.KeyNotFound;

            //Polylinien auswählen
            PromptSelectionOptions prSelOpt = new PromptSelectionOptions();

            //Filter
            TypedValue[] values = new TypedValue[] {
            new TypedValue((int)DxfCode.Operator, "<or"),
            new TypedValue((int)DxfCode.Start, "LWPolyline"),
            new TypedValue((int)DxfCode.Start, "Polyline"),
            new TypedValue((int)DxfCode.Start, "Line"),
            new TypedValue((int)DxfCode.Operator, "or>")};
            SelectionFilter selFilter = new SelectionFilter(values);

            PromptSelectionResult resSel = m_ed.GetSelection(prSelOpt, selFilter);

            if (resSel.Status == PromptStatus.OK)
            {
                //Polylinien nach Art in Listen schreiben
                SelectionSet ssRes = resSel.Value;

                //PolylinienLW iterativ bearbeiten
                ObjectId[] objID = ssRes.GetObjectIds();

                for (int i = 0; i < objID.Length; i++)
                {
                    DBObject dbObj = myT.GetObject(objID[i], OpenMode.ForRead);
                    string objTyp = dbObj.GetType().ToString();
                    objTyp = objTyp.Substring(objTyp.LastIndexOf('.') + 1);

                    switch (objTyp)
                    {
                        case "Line":
                            m_LineCollection.Add(objID[i], (Line)myT.GetObject(objID[i], OpenMode.ForRead));

                            break;

                        case "Polyline":
                            m_PolylineCollection.Add(objID[i], (Polyline)myT.GetObject(objID[i], OpenMode.ForRead));

                            break;

                        case "Polyline2d":
                            m_Polyline2dCollection.Add(objID[i], (Polyline2d)myT.GetObject(objID[i], OpenMode.ForRead));

                            break;
                    }

                    es = ErrorStatus.OK;
                }
            }

            myT.Commit();

            return es;
        }

        public void convertTo3d()
        {
            Database db = HostApplicationServices.WorkingDatabase;
            Autodesk.AutoCAD.DatabaseServices.TransactionManager myTm = db.TransactionManager;
            Transaction myT = db.TransactionManager.StartTransaction();

            //alle Blöcke wählen
            myAutoCAD.Blöcke.Instance.init();
            myAutoCAD.Blöcke.Instance.selectAll();
            Messpunkt[] vMP = Blöcke.Instance.getMP;

            //Linien

            using (DocumentLock dl = Application.DocumentManager.MdiActiveDocument.LockDocument())
            {
                foreach (KeyValuePair<ObjectId, Line> valPair in m_LineCollection)
                {
                    ObjectId id = valPair.Key;
                    Line objLine = valPair.Value;

                    Messpunkt MP = new Messpunkt();
                    Point2d startPt = new Point2d(objLine.StartPoint.X, objLine.StartPoint.Y);
                    Point2d endPt = new Point2d(objLine.EndPoint.X, objLine.EndPoint.Y);

                    Line line = (Line)myT.GetObject(id, OpenMode.ForWrite);
                    if (Blöcke.Instance.findPos(ref MP, startPt, 0.001) == ErrorStatus.OK)
                        line.StartPoint = MP.Position;
                    else
                        m_lsMP_Error.Add(new Messpunkt("", startPt.X, startPt.Y, null, null, 0));

                    if (Blöcke.Instance.findPos(ref MP, endPt, 0.001) == ErrorStatus.OK)
                        line.EndPoint = MP.Position;
                    else
                        m_lsMP_Error.Add(new Messpunkt("", endPt.X, endPt.Y, null, null, 0));

                }
            }
            
            //Polylinien
            using (DocumentLock dl = Application.DocumentManager.MdiActiveDocument.LockDocument())
            {
                foreach (KeyValuePair<ObjectId,  Polyline> valPair in m_PolylineCollection)
                {
                    ObjectId id = valPair.Key;
                    Polyline objPL = valPair.Value;

                    List<Point3d> lsPt3d = new List<Point3d>();

                    //Vertices iterieren
                    for (int i = 0; i < objPL.NumberOfVertices; i++)
                    {
                        Point2d pt = objPL.GetPoint2dAt(i);
                        Messpunkt MP = new Messpunkt();

                        if (Blöcke.Instance.findPos(ref MP, pt, 0.001) == ErrorStatus.OK)
                            lsPt3d.Add(MP.Position);
                        else
                        {
                            Point3d pt3d = new Point3d(pt.X, pt.Y, 0);
                            MP.Position = pt3d;
                            m_lsMP_Error.Add(MP);
                            lsPt3d.Add(pt3d);
                        }
                    }                

                    //3dPolylinie erstellen
                    //Punktliste erzeugen
                    Point3d[] vPT3d = new Point3d[ lsPt3d.Count];
                    for (int i = 0; i < lsPt3d.Count; i++)
                        vPT3d[i] = lsPt3d[i];

                    //3d Polylinie erzeugen
                    Point3dCollection pt3dCol = new Point3dCollection(vPT3d);
                    Polyline3d objPL3d = new Polyline3d(Poly3dType.SimplePoly, pt3dCol, objPL.Closed);
                    objPL3d.Layer = objPL.Layer;

                    //2d Polylinie löschen
                    Polyline pl = (Polyline)myT.GetObject(id, OpenMode.ForWrite);
                    pl.Erase(true);

                    //Polylinie in DB einfügen
                    try
                    {
                        BlockTable bt = (BlockTable)myT.GetObject(db.BlockTableId, OpenMode.ForRead,false);
                        BlockTableRecord btr = (BlockTableRecord)myT.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite, false);

                        ObjectId idPL3d = btr.AppendEntity(objPL3d);
                        myT.AddNewlyCreatedDBObject(objPL3d, true);
                        objPL3d.Draw();
                    }
                    catch { }
                }
            }

            //Polyline2d
            using (DocumentLock dl = Application.DocumentManager.MdiActiveDocument.LockDocument())
            {
                foreach (KeyValuePair<ObjectId, Polyline2d> valPair in m_Polyline2dCollection)
                {
                    ObjectId id = valPair.Key;
                    Polyline2d objPL2d = valPair.Value;
                    List<Point3d> lsPt3d = new List<Point3d>();

                    //Vertices iterieren
                    foreach (ObjectId idVertex in objPL2d)
                    {
                        Vertex2d vertex2d = (Vertex2d)myT.GetObject(idVertex, OpenMode.ForRead);
                        Point2d pt = new Point2d(vertex2d.Position.X, vertex2d.Position.Y);
                        Messpunkt MP = new Messpunkt();

                        if (Blöcke.Instance.findPos(ref MP, pt, 0.001) == ErrorStatus.OK)
                            lsPt3d.Add(MP.Position);
                        else
                        {
                            Point3d pt3d = new Point3d(pt.X, pt.Y, 0);
                            MP.Position = pt3d;
                            m_lsMP_Error.Add(MP);
                            lsPt3d.Add(pt3d);
                        }
                    }

                    //3dPolylinie erstellen
                    //Punktliste erzeugen
                    Point3d[] vPT3d = new Point3d[lsPt3d.Count];
                    for (int i = 0; i < lsPt3d.Count; i++)
                        vPT3d[i] = lsPt3d[i];

                    //3d Polylinie erzeugen
                    Point3dCollection pt3dCol = new Point3dCollection(vPT3d);
                    Polyline3d objPL3d = new Polyline3d(Poly3dType.SimplePoly, pt3dCol, objPL2d.Closed);
                    objPL3d.Layer = objPL2d.Layer;

                    //2d Polylinie löschen
                    Polyline2d pl2d = (Polyline2d)myT.GetObject(id, OpenMode.ForWrite);
                    pl2d.Erase(true);

                    //Polylinie in DB einfügen
                    try
                    {
                        BlockTable bt = (BlockTable)myT.GetObject(db.BlockTableId, OpenMode.ForRead, false);
                        BlockTableRecord btr = (BlockTableRecord)myT.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite, false);

                        ObjectId idPL3d = btr.AppendEntity(objPL3d);
                        myT.AddNewlyCreatedDBObject(objPL3d, true);
                        objPL3d.Draw();
                    }
                    catch { }
                }
            }

            //Fehler anzeigen
            if (m_lsMP_Error.Count > 0)
            {
                foreach (Messpunkt MP in m_lsMP_Error)
                    MP.mark(0.2);

                System.Windows.Forms.MessageBox.Show(m_lsMP_Error.Count.ToString() + " Fehler gefunden!");
            }

            else
                System.Windows.Forms.MessageBox.Show("3d Konvertierung fehlerfrei durchgeführt!");

            myT.Commit();
        }
     }
}
