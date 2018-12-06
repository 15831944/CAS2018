using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;

namespace CAS2018.myAutoCAD
{
    public partial class Zeichnen
    {
        Editor m_ed = null;
        myUtilities objUtil = new myUtilities();
        private static string PNrZähler = "1";

        public void PTIns()
        {
            m_ed = Application.DocumentManager.MdiActiveDocument.Editor;
            PromptPointOptions prPtOpt = new PromptPointOptions("Bitte Position wählen:");
            bool bBeenden = false;

            while (!bBeenden)
            {
                PromptPointResult prPtRes = m_ed.GetPoint("Position wählen:");

                if (prPtRes.Status == PromptStatus.OK)
                {
                    PromptStringOptions prStringOpt = new PromptStringOptions("Nr: " + PNrZähler);
                    prStringOpt.AllowSpaces = false;
                    PromptResult prRes = m_ed.GetString(prStringOpt);

                    if (prRes.Status == PromptStatus.OK)
                    {
                        if (prRes.StringResult != "")
                        {
                            PNrZähler = prRes.StringResult;
                            PNrZähler = objUtil.incString(PNrZähler);
                        }
                    }

                    Messpunkt objMP = new Messpunkt(PNrZähler, prPtRes.Value.X, prPtRes.Value.Y, null, null, 0);
                    objMP.draw("MP", "MP-P");
                }
                else
                    bBeenden = true;
            }
        }


        public void Block3P()
        {
            // Get the current database and start the Transaction Manager
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            PromptPointResult pPtRes;
            PromptPointOptions pPtOpts = new PromptPointOptions("");

            // Prompt for first point
            pPtOpts.Message = "\nPunkt1: ";
            pPtRes = acDoc.Editor.GetPoint(pPtOpts);
            Point3d ptPT1 = pPtRes.Value;

            // Prompt for second point
            pPtOpts.Message = "\nPunkt2: ";
            pPtRes = acDoc.Editor.GetPoint(pPtOpts);
            Point3d ptPT2 = pPtRes.Value;

            // Prompt for third point
            pPtOpts.Message = "\nPunkt3: ";
            pPtRes = acDoc.Editor.GetPoint(pPtOpts);
            Point3d ptPT3 = pPtRes.Value;
        }
    }
}
