using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Reflection;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using CAS2018.myUtilities;

namespace CAS2018.myAutoCAD
{
    /// <summary>
    /// Punkte werden von Acad Punkten repräsentiert
    /// </summary>
    public partial class Punkt
    {
        //private Database m_db = null;
        //private Transaction m_myT = null;
        private Editor m_ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;

        private Point3d m_pt;

        //Properties
        public double X
        {
            get { return this.m_pt.X; }
        }

        public double Y
        {
            get { return this.m_pt.Y; }
        }

        public double Z
        {
            get { return this.m_pt.Z; }
        }

        //Methoden
        public PromptStatus selectPoint(string message)
        {
            PromptStatus pStatus = PromptStatus.Error;

            try
            {
                PromptPointResult resPT = this.m_ed.GetPoint(message);
                pStatus = resPT.Status;

                if (pStatus == PromptStatus.OK)
                    this.m_pt = resPT.Value;

            }
            catch { }

            return pStatus;
        }
    }

    /// <summary>
    /// Messpunkte werden von Acad Blöcken repräsentiert
    /// </summary>
    [Serializable()] 
    public partial class Messpunkt : ISerializable
    {
        private myRegistry.regIO m_objRegistry = new myRegistry.regIO();

        private string m_PNum;
        private string m_Name;
        private string m_Layer;
        private int? m_AttCount = null;
        private Point3d m_Pos;
        private double? m_Höhe;
        private double? m_CASHöhe;
        private int? m_CASPrecision;
        private BlockReference m_blkRef = null;
        private bool m_isErased = false;
        private int? m_HeigthPrecision;
        private double m_FaktorX;
        private double m_FaktorY;
        private double m_FaktorZ;
        private string m_HöhePrefix;
        private string m_HöheSufix;

        //Att1
        private Point3d m_Att1_Pos;
        private string m_Att1_Textstyle;
        private string m_Att1_Layer;
        private double m_Att1_Height;
        private double m_Att1_Neigung;
        private double m_Att1_Breitenfaktor;
        private bool m_Att1_Visible;

        //Att2
        private Point3d m_Att2_Pos;
        private string m_Att2_Textstyle;
        private string m_Att2_Layer;
        private double m_Att2_Height;
        private double m_Att2_Neigung;
        private double m_Att2_Breitenfaktor;
        private bool m_Att2_Visible;

        //Att3
        private Point3d m_Att3_Pos;
        private string m_Att3_Textstyle;
        private string m_Att3_Layer;
        private double m_Att3_Height;
        private double m_Att3_Neigung;
        private double m_Att3_Breitenfaktor;
        private string m_Att3_Wert;
        private bool m_Att3_Visible;

        //Att4
        private Point3d m_Att4_Pos;
        private string m_Att4_Textstyle;
        private string m_Att4_Layer;
        private double m_Att4_Height;
        private double m_Att4_Neigung;
        private double m_Att4_Breitenfaktor;
        private string m_Att4_Wert;
        private bool m_Att4_Visible;

        //Att5
        private Point3d m_Att5_Pos;
        private string m_Att5_Textstyle;
        private string m_Att5_Layer;
        private double m_Att5_Height;
        private double m_Att5_Neigung;
        private double m_Att5_Breitenfaktor;
        private string m_Att5_Wert;
        private bool m_Att5_Visible;

        //Att6
        private Point3d m_Att6_Pos;
        private string m_Att6_Textstyle;
        private string m_Att6_Layer;
        private double m_Att6_Height;
        private double m_Att6_Neigung;
        private double m_Att6_Breitenfaktor;
        private string m_Att6_Wert;
        private bool m_Att6_Visible;

        //Att7
        private Point3d m_Att7_Pos;
        private string m_Att7_Textstyle;
        private string m_Att7_Layer;
        private double m_Att7_Height;
        private double m_Att7_Neigung;
        private double m_Att7_Breitenfaktor;
        private string m_Att7_Wert;
        private bool m_Att7_Visible;

        //Att8
        private Point3d m_Att8_Pos;
        private string m_Att8_Textstyle;
        private string m_Att8_Layer;
        private double m_Att8_Height;
        private double m_Att8_Neigung;
        private double m_Att8_Breitenfaktor;
        private string m_Att8_Wert;
        private bool m_Att8_Visible;

        //Att9
        private Point3d m_Att9_Pos;
        private string m_Att9_Textstyle;
        private string m_Att9_Layer;
        private double m_Att9_Height;
        private double m_Att9_Neigung;
        private double m_Att9_Breitenfaktor;
        private string m_Att9_Wert;
        private bool m_Att9_Visible;

        //Att10
        private Point3d m_Att10_Pos;
        private string m_Att10_Textstyle;
        private string m_Att10_Layer;
        private double m_Att10_Height;
        private double m_Att10_Neigung;
        private double m_Att10_Breitenfaktor;
        private string m_Att10_Wert;
        private bool m_Att10_Visible;

        /// <summary>
        /// Blockreferenz festlegen bzw. abrufen
        /// </summary>
        public BlockReference BlockReferenz
        {
            get { return this.m_blkRef; }
            set { this.m_blkRef = value; }
        }

        /// Punktnummer festlegen bzw. abfragen
        /// </summary>
        public string PNum
        {
            get { return this.m_PNum; }
            set { this.m_PNum = value; }
        }

        /// <summary>
        /// Blocknamen festlegen bzw. abfragen
        /// </summary>
        public string Name
        {
            get { return this.m_Name; }
            set { this.m_Name = value; }
        }

        public bool isErased
        {
            get {  return this.isErased; }
            set { this.m_isErased = value; }
        }

        /// <summary>
        /// Anzahl der Attribute
        /// </summary>
        public int? AttCount
        {
            get { return this.m_AttCount; }
            set { this.m_AttCount = value; }
        }

        /// <summary>
        /// Layer abfragen bzw. festlegen
        /// </summary>
        public string Layer
        {
            get { return this.m_Layer; }
            set { this.m_Layer = value; }
        }

        /// <summary>
        /// Blockeinfügeposition festlegen bzw. abrufen
        /// </summary>
        public Point3d Position
        {
            get { return this.m_Pos; }
            set { this.m_Pos = value; }
        }

        /// <summary>
        /// Höhe festlegen bzw. abrufen
        /// </summary>
        public double? Höhe
        {
            get { return this.m_Höhe; }
            set { this.m_Höhe = value; }
        }

        public double? CASHöhe
        {
            get { return this.m_CASHöhe; }
            set { this.m_CASHöhe = value; }
        }

        public int? CASPrecision
        {
            get { return this.m_CASPrecision; }
            set { this.m_CASPrecision = value; }
        }

        public string Prefix
        {
            get { return this.m_HöhePrefix; }
            set { this.m_HöheSufix = value; }
        }

        /// <summary>
        /// Höhengenauigkeit
        /// </summary>
        public int? HeigthPrecision
        {
            get { return this.m_HeigthPrecision; }
            set { this.m_HeigthPrecision = value; }
        }

        /// <summary>
        /// Att3 Wert festlegen bzw. abrufen
        /// </summary>
        public string Att3_Wert
        {
            get { return this.m_Att3_Wert; }
            set { this.m_Att3_Wert = value; }
        }

        /// <summary>
        /// Att4 Wert festlegen bzw. abrufen
        /// </summary>
        public string Att4_Wert
        {
            get { return this.m_Att4_Wert; }
            set { this.m_Att4_Wert = value; }
        }

        /// <summary>
        /// Att5 Wert festlegen bzw. abrufen
        /// </summary>
        public string Att5_Wert
        {
            get { return this.m_Att5_Wert; }
            set { this.m_Att5_Wert = value; }
        }

        /// <summary>
        /// Att6 Wert festlegen bzw. abrufen
        /// </summary>
        public string Att6_Wert
        {
            get { return this.m_Att6_Wert; }
            set { this.m_Att6_Wert = value; }
        }

        /// <summary>
        /// Att7 Wert festlegen bzw. abrufen
        /// </summary>
        public string Att7_Wert
        {
            get { return this.m_Att7_Wert; }
            set { this.m_Att7_Wert = value; }
        }

        /// <summary>
        /// Att8 Wert festlegen bzw. abrufen
        /// </summary>
        public string Att8_Wert
        {
            get { return this.m_Att8_Wert; }
            set { this.m_Att8_Wert = value; }
        }

        /// <summary>
        /// Att9 Wert festlegen bzw. abrufen
        /// </summary>
        public string Att9_Wert
        {
            get { return this.m_Att9_Wert; }
            set { this.m_Att9_Wert = value; }
        }

        /// <summary>
        /// Att10 Wert festlegen bzw. abrufen
        /// </summary>
        public string Att10_Wert
        {
            get { return this.m_Att10_Wert; }
            set { this.m_Att10_Wert = value; }
        }

        /// <summary>
        /// Faktor X
        /// </summary>
        public double FaktorX
        {
            get { return this.m_FaktorX; }
            set { this.m_FaktorX = value; }
        }

        /// <summary>
        /// Faktor Y
        /// </summary>
        public double FaktorY
        {
            get { return this.m_FaktorY; }
            set { this.m_FaktorY = value; }
        }

        /// <summary>
        /// Faktor Z
        /// </summary>
        public double FaktorZ
        {
            get { return this.m_FaktorZ; }
            set { this.m_FaktorZ = value; }
        }

        //Att1
        public Point3d Att1_Pos
        {
            get { return this.m_Att1_Pos; }
            set { this.m_Att1_Pos = value; }
        }

        public string Att1_Textstil
        {
            get { return this.m_Att1_Textstyle; }
            set { this.m_Att1_Textstyle = value; }
        }

        public string Att1_Layer
        {
            get { return this.m_Att1_Layer; }
            set { this.m_Att1_Layer = value; }
        }

        public double Att1_Height
        {
            get { return this.m_Att1_Height; }
            set { this.m_Att1_Height = value; }
        }

        public double Att1_Neigung
        {
            get { return this.m_Att1_Neigung; }
            set { this.m_Att1_Neigung = value; }
        }

        public double Att1_Breitenfaktor
        {
            get { return m_Att1_Breitenfaktor; }
            set { m_Att1_Breitenfaktor = value; }
        }

        public bool Att1_Visible
        {
            get { return m_Att1_Visible; }
            set { m_Att1_Visible = value; }
        }

        //Att2
        public Point3d Att2_Pos
        {
            get { return this.m_Att2_Pos; }
            set { this.m_Att2_Pos = value; }
        }

        public string Att2_Textstil
        {
            get { return this.m_Att2_Textstyle; }
            set { this.m_Att2_Textstyle = value; }
        }

        public string Att2_Layer
        {
            get { return this.m_Att2_Layer; }
            set { this.m_Att2_Layer = value; }
        }

        public double Att2_Height
        {
            get { return this.m_Att2_Height; }
            set { this.m_Att2_Height = value; }
        }

        public double Att2_Neigung
        {
            get { return this.m_Att2_Neigung; }
            set { this.m_Att2_Neigung = value; }
        }

        public double Att2_Breitenfaktor
        {
            get { return m_Att2_Breitenfaktor; }
            set { m_Att2_Breitenfaktor = value; }
        }

        public bool Att2_Visible
        {
            get { return m_Att2_Visible; }
            set { m_Att2_Visible = value; }
        }

        //Att3
        public Point3d Att3_Pos
        {
            get { return this.m_Att3_Pos; }
            set { this.m_Att3_Pos = value; }
        }

        public string Att3_Textstil
        {
            get { return this.m_Att3_Textstyle; }
            set { this.m_Att3_Textstyle = value; }
        }

        public string Att3_Layer
        {
            get { return this.m_Att3_Layer; }
            set { this.m_Att3_Layer = value; }
        }

        public double Att3_Height
        {
            get { return this.m_Att3_Height; }
            set { this.m_Att3_Height = value; }
        }

        public double Att3_Neigung
        {
            get { return this.m_Att3_Neigung; }
            set { this.m_Att3_Neigung = value; }
        }

        public double Att3_Breitenfaktor
        {
            get { return m_Att3_Breitenfaktor; }
            set { m_Att3_Breitenfaktor = value; }
        }

        public bool Att3_Visible
        {
            get { return m_Att3_Visible; }
            set { m_Att3_Visible = value; }
        }

        //Att4
        public Point3d Att4_Pos
        {
            get { return this.m_Att4_Pos; }
            set { this.m_Att4_Pos = value; }
        }

        public string Att4_Textstil
        {
            get { return this.m_Att4_Textstyle; }
            set { this.m_Att4_Textstyle = value; }
        }

        public string Att4_Layer
        {
            get { return this.m_Att4_Layer; }
            set { this.m_Att4_Layer = value; }
        }

        public double Att4_Height
        {
            get { return this.m_Att4_Height; }
            set { this.m_Att4_Height = value; }
        }

        public double Att4_Neigung
        {
            get { return this.m_Att4_Neigung; }
            set { this.m_Att4_Neigung = value; }
        }

        public double Att4_Breitenfaktor
        {
            get { return m_Att4_Breitenfaktor; }
            set { m_Att4_Breitenfaktor = value; }
        }

        public bool Att4_Visible
        {
            get { return m_Att4_Visible; }
            set { m_Att4_Visible = value; }
        }

        //Att5
        public Point3d Att5_Pos
        {
            get { return this.m_Att5_Pos; }
            set { this.m_Att5_Pos = value; }
        }

        public string Att5_Textstil
        {
            get { return this.m_Att5_Textstyle; }
            set { this.m_Att5_Textstyle = value; }
        }

        public string Att5_Layer
        {
            get { return this.m_Att5_Layer; }
            set { this.m_Att5_Layer = value; }
        }

        public double Att5_Height
        {
            get { return this.m_Att5_Height; }
            set { this.m_Att5_Height = value; }
        }

        public double Att5_Neigung
        {
            get { return this.m_Att5_Neigung; }
            set { this.m_Att5_Neigung = value; }
        }

        public double Att5_Breitenfaktor
        {
            get { return m_Att5_Breitenfaktor; }
            set { m_Att5_Breitenfaktor = value; }
        }

        public bool Att5_Visible
        {
            get { return m_Att5_Visible; }
            set { m_Att5_Visible = value; }
        }

        //Att6
        public Point3d Att6_Pos
        {
            get { return this.m_Att6_Pos; }
            set { this.m_Att6_Pos = value; }
        }

        public string Att6_Textstil
        {
            get { return this.m_Att6_Textstyle; }
            set { this.m_Att6_Textstyle = value; }
        }

        public string Att6_Layer
        {
            get { return this.m_Att6_Layer; }
            set { this.m_Att6_Layer = value; }
        }

        public double Att6_Height
        {
            get { return this.m_Att6_Height; }
            set { this.m_Att6_Height = value; }
        }

        public double Att6_Neigung
        {
            get { return this.m_Att6_Neigung; }
            set { this.m_Att6_Neigung = value; }
        }

        public double Att6_Breitenfaktor
        {
            get { return m_Att6_Breitenfaktor; }
            set { m_Att6_Breitenfaktor = value; }
        }

        public bool Att6_Visible
        {
            get { return m_Att6_Visible; }
            set { m_Att6_Visible = value; }
        }

        //Att7
        public Point3d Att7_Pos
        {
            get { return this.m_Att7_Pos; }
            set { this.m_Att7_Pos = value; }
        }

        public string Att7_Textstil
        {
            get { return this.m_Att7_Textstyle; }
            set { this.m_Att7_Textstyle = value; }
        }

        public string Att7_Layer
        {
            get { return this.m_Att7_Layer; }
            set { this.m_Att7_Layer = value; }
        }

        public double Att7_Height
        {
            get { return this.m_Att7_Height; }
            set { this.m_Att7_Height = value; }
        }

        public double Att7_Neigung
        {
            get { return this.m_Att7_Neigung; }
            set { this.m_Att7_Neigung = value; }
        }

        public double Att7_Breitenfaktor
        {
            get { return m_Att7_Breitenfaktor; }
            set { m_Att7_Breitenfaktor = value; }
        }

        public bool Att7_Visible
        {
            get { return m_Att7_Visible; }
            set { m_Att7_Visible = value; }
        }

        //Att8
        public Point3d Att8_Pos
        {
            get { return this.m_Att8_Pos; }
            set { this.m_Att8_Pos = value; }
        }

        public string Att8_Textstil
        {
            get { return this.m_Att8_Textstyle; }
            set { this.m_Att8_Textstyle = value; }
        }

        public string Att8_Layer
        {
            get { return this.m_Att8_Layer; }
            set { this.m_Att8_Layer = value; }
        }

        public double Att8_Height
        {
            get { return this.m_Att8_Height; }
            set { this.m_Att8_Height = value; }
        }

        public double Att8_Neigung
        {
            get { return this.m_Att8_Neigung; }
            set { this.m_Att8_Neigung = value; }
        }

        public double Att8_Breitenfaktor
        {
            get { return m_Att8_Breitenfaktor; }
            set { m_Att8_Breitenfaktor = value; }
        }

        public bool Att8_Visible
        {
            get { return m_Att8_Visible; }
            set { m_Att8_Visible = value; }
        }

        //Att9
        public Point3d Att9_Pos
        {
            get { return this.m_Att9_Pos; }
            set { this.m_Att9_Pos = value; }
        }

        public string Att9_Textstil
        {
            get { return this.m_Att9_Textstyle; }
            set { this.m_Att9_Textstyle = value; }
        }

        public string Att9_Layer
        {
            get { return this.m_Att9_Layer; }
            set { this.m_Att9_Layer = value; }
        }

        public double Att9_Height
        {
            get { return this.m_Att9_Height; }
            set { this.m_Att9_Height = value; }
        }

        public double Att9_Neigung
        {
            get { return this.m_Att9_Neigung; }
            set { this.m_Att9_Neigung = value; }
        }

        public double Att9_Breitenfaktor
        {
            get { return m_Att9_Breitenfaktor; }
            set { m_Att9_Breitenfaktor = value; }
        }

        public bool Att9_Visible
        {
            get { return m_Att9_Visible; }
            set { m_Att9_Visible = value; }
        }

        //Att10
        public Point3d Att10_Pos
        {
            get { return this.m_Att10_Pos; }
            set { this.m_Att10_Pos = value; }
        }

        public string Att10_Textstil
        {
            get { return this.m_Att10_Textstyle; }
            set { this.m_Att10_Textstyle = value; }
        }

        public string Att10_Layer
        {
            get { return this.m_Att10_Layer; }
            set { this.m_Att10_Layer = value; }
        }

        public double Att10_Height
        {
            get { return this.m_Att10_Height; }
            set { this.m_Att10_Height = value; }
        }

        public double Att10_Neigung
        {
            get { return this.m_Att10_Neigung; }
            set { this.m_Att10_Neigung = value; }
        }

        public double Att10_Breitenfaktor
        {
            get { return m_Att10_Breitenfaktor; }
            set { m_Att10_Breitenfaktor = value; }
        }

        public bool Att10_Visible
        {
            get { return m_Att10_Visible; }
            set { m_Att10_Visible = value; }
        }

        //Konstruktor
        public Messpunkt() { }

        //Deserialization constructor.
        public Messpunkt(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            m_Name = (String)info.GetValue("Name", typeof(string));
            m_PNum = (String)info.GetValue("PNum", typeof(string));
            m_Höhe = (double?)info.GetValue("Höhe", typeof(double));
            m_Layer = (String)info.GetValue("Layer", typeof(string));

            m_FaktorX = (Double)info.GetValue("FaktorX", typeof(double));
            m_FaktorY = (Double)info.GetValue("FaktorY", typeof(double));
            m_FaktorZ = (Double)info.GetValue("FaktorZ", typeof(double));

            double PosX = (double)info.GetValue("PosX", typeof(double));
            double PosY = (double)info.GetValue("PosY", typeof(double));
            double PosZ = (double)info.GetValue("PosZ", typeof(double));
            Point3d Pos = new Point3d(PosX, PosY, PosZ);
            m_Pos = Pos;

            double Att1_PosX = (double)info.GetValue("Att1_PosX", typeof(double));
            double Att1_PosY = (double)info.GetValue("Att1_PosY", typeof(double));
            double Att1_PosZ = (double)info.GetValue("Att1_PosZ", typeof(double));
            Point3d Att1_Pos = new Point3d(Att1_PosX, Att1_PosY, Att1_PosZ);
            m_Att1_Pos = Att1_Pos;

            double Att2_PosX = (double)info.GetValue("Att2_PosX", typeof(double));
            double Att2_PosY = (double)info.GetValue("Att2_PosY", typeof(double));
            double Att2_PosZ = (double)info.GetValue("Att2_PosZ", typeof(double));
            Point3d Att2_Pos = new Point3d(Att2_PosX, Att2_PosY, Att2_PosZ);
            m_Att2_Pos = Att2_Pos;
        }

        public Messpunkt(string Nr, double x, double y, double? z, double? CASHöhe, int Precision)
        {
            m_PNum = Nr;
            m_CASHöhe = CASHöhe;
            m_Höhe = z;
            m_CASPrecision = Precision;
            m_Pos = new Point3d(x, y, 0);
        }

        public Messpunkt(string Nr, double x, double y, double? z, double? CASHöhe, int Precision, string Blockname)
        {
            m_PNum = Nr;
            m_CASHöhe = CASHöhe;
            m_Höhe = z;
            m_CASPrecision = Precision;
            m_Pos = new Point3d(x, y, 0);
            m_Name = Blockname;
        }

        //Methoden
        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Name", m_Name);
            info.AddValue("PNum", m_PNum);
            info.AddValue("Höhe", m_Höhe);
            info.AddValue("Layer", m_Layer);
            info.AddValue("FaktorX", m_FaktorX);
            info.AddValue("FaktorY", m_FaktorY);
            info.AddValue("FaktorZ", m_FaktorZ);
            info.AddValue("PosX", m_Pos.X);
            info.AddValue("PosY", m_Pos.Y);
            info.AddValue("PosZ", m_Pos.Z);
            info.AddValue("Att1_PosX", m_Att1_Pos.X);
            info.AddValue("Att1_PosY", m_Att1_Pos.Y);
            info.AddValue("Att1_PosZ", m_Att1_Pos.Z);
            info.AddValue("Att2_PosX", m_Att2_Pos.X);
            info.AddValue("Att2_PosY", m_Att2_Pos.Y);
            info.AddValue("Att2_PosZ", m_Att2_Pos.Z);
        }

        public void Deserialize(FileStream stream)
        {
            SoapFormatter formatter = new SoapFormatter();
            formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;

            Messpunkt objMP = (Messpunkt)formatter.Deserialize(stream);
        }

        public void mark(double Radius)
        {
            Database db = HostApplicationServices.WorkingDatabase;
            Autodesk.AutoCAD.DatabaseServices.TransactionManager myTm = db.TransactionManager;
            Transaction myT = db.TransactionManager.StartTransaction();

            Vector3d v3d = new Vector3d(0, 0, 1);
            Circle MKreis = new Circle(this.Position, v3d, Radius);

            using (DocumentLock dl = Application.DocumentManager.MdiActiveDocument.LockDocument())
            {
                try
                {
                    BlockTable bt = (BlockTable)myT.GetObject(db.BlockTableId, OpenMode.ForRead);
                    BlockTableRecord btr = (BlockTableRecord)myT.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                    ObjectId idMKreis = btr.AppendEntity(MKreis);
                    myTm.AddNewlyCreatedDBObject(MKreis, true);
                    myT.Commit();
                }
                finally
                {
                    myT.Dispose();
                }
            }
        }

        public ErrorStatus delete()
        {
            Database db = HostApplicationServices.WorkingDatabase;
            Autodesk.AutoCAD.DatabaseServices.TransactionManager myTm = db.TransactionManager;
            Transaction myT = db.TransactionManager.StartTransaction();

            ErrorStatus es = ErrorStatus.KeyNotFound;

            using (DocumentLock dl = Application.DocumentManager.MdiActiveDocument.LockDocument())
            {
                try
                {
                    myT.GetObject(m_blkRef.ObjectId, OpenMode.ForRead);
                    m_blkRef.UpgradeOpen();
                    m_blkRef.Erase(true);
                    isErased = m_blkRef.IsErased;

                    myT.Commit();
                    es = ErrorStatus.OK;
                }
                catch { }

                finally
                {
                    myT.Dispose();
                }
            }
            return es;
        }

        /// <summary>
        /// einzelnen Block auswählen
        /// </summary>
        /// <returns></returns>
        public ErrorStatus pickPoint()
        {
            Database db = HostApplicationServices.WorkingDatabase;
            Autodesk.AutoCAD.DatabaseServices.TransactionManager myTm = db.TransactionManager;
            Transaction myT = db.TransactionManager.StartTransaction();
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;

            ErrorStatus es = ErrorStatus.KeyNotFound;

            try
            {
                using (DocumentLock dl = Application.DocumentManager.MdiActiveDocument.LockDocument())
                {
                    PromptEntityResult prEntRes = ed.GetEntity("Referenzblock wählen");

                    m_blkRef = (BlockReference)myT.GetObject(prEntRes.ObjectId, OpenMode.ForRead);
                    m_Name = m_blkRef.Name;
                    m_Layer = m_blkRef.Layer;
                    m_FaktorX = m_blkRef.ScaleFactors.X;
                    m_FaktorY = m_blkRef.ScaleFactors.Y;
                    m_FaktorZ = m_blkRef.ScaleFactors.Z;

                    es = ErrorStatus.OK;

                    //Attribute iterieren
                    AttributeCollection colAtt = m_blkRef.AttributeCollection;
                    int attCount = 0;

                    foreach (ObjectId attID in colAtt)
                    {
                        AttributeReference attRef = (AttributeReference)myT.GetObject(attID, OpenMode.ForRead);

                        switch (attCount)
                        {
                            //Punktnummer
                            case 0:
                                m_PNum = attRef.TextString;
                                m_Att1_Textstyle = attRef.TextStyleName;
                                m_Att1_Height = attRef.Height;
                                m_Att1_Layer = attRef.Layer;
                                m_Att1_Neigung = attRef.Oblique;
                                m_Att1_Breitenfaktor = attRef.WidthFactor;
                                break;

                            //Punkthöhe 
                            case 1:
                                string sHöhe = attRef.TextString;
                                m_Att2_Textstyle = attRef.TextStyleName;
                                m_Att2_Height = attRef.Height;
                                m_Att2_Layer = attRef.Layer;
                                m_Att2_Neigung = attRef.Oblique;
                                m_Att2_Breitenfaktor = attRef.WidthFactor;

                                //leeren Textstring überspringen
                                if (sHöhe != "")
                                {
                                    myAutoCAD.myUtilities objUtil = new myUtilities();
                                    double dHöhe = 0;

                                    if (objUtil.convertToDouble(sHöhe, ref dHöhe, null) == ErrorStatus.OK)
                                    {
                                        //double dHöhe = Convert.ToDouble(sHöhe);
                                        m_Höhe = dHöhe;

                                        try
                                        {
                                            sHöhe = sHöhe.Substring(sHöhe.LastIndexOf('.'));
                                        }

                                        catch { }

                                        if (sHöhe[0] == '.')
                                            sHöhe = sHöhe.Substring(1);
                                        m_HeigthPrecision = sHöhe.Length;
                                    }
                                }
                                break;

                            default:
                                break;
                        }

                        attCount++;
                        attRef.Dispose();

                        if (attCount > 0)
                            m_AttCount = attCount;
                    }
                }
            }
            finally
            {
                myT.Dispose();
            }

            return es;
        }

        /// <summary>
        /// Blockreferenz austauschen
        /// </summary>
        /// <param name="objProto"></param>
        /// <returns></returns>
        public ErrorStatus updateBlockRef(BlockReference blkRefProto)
        {
            Database db = HostApplicationServices.WorkingDatabase;
            Autodesk.AutoCAD.DatabaseServices.TransactionManager myTm = db.TransactionManager;
            Transaction myT = db.TransactionManager.StartTransaction();
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;

            ErrorStatus es = ErrorStatus.KeyNotFound;

            try
            {
                using (DocumentLock dl = Application.DocumentManager.MdiActiveDocument.LockDocument())
                {
                    BlockTable bt = (BlockTable)myT.GetObject(db.BlockTableId, OpenMode.ForRead);
                    BlockTableRecord btr = new BlockTableRecord();

                   
                    btr.Name = m_blkRef.Name;


                    AttributeCollection colAtt = m_blkRef.AttributeCollection;

                    BlockReference blkRef = (BlockReference)myT.GetObject(m_blkRef.Id, OpenMode.ForRead);

                    blkRef = blkRefProto;

                    
                    es = ErrorStatus.OK;
                }
            }

            finally
            {
                myT.Commit();
                myT.Dispose();
            }

            return es;
        }

        public ErrorStatus draw(string blockName, string Basislayer)
        {
            Database db = HostApplicationServices.WorkingDatabase;
            Autodesk.AutoCAD.DatabaseServices.TransactionManager myTm = db.TransactionManager;
            Transaction myT = db.TransactionManager.StartTransaction();
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ObjectContextManager conTextManager = db.ObjectContextManager;

            ErrorStatus es = ErrorStatus.KeyNotFound;
            myLayer objLayer = myLayer.Instance;
            Dictionary<string, Point3d> _attPos;
            _attPos = new Dictionary<string, Point3d>();
            List<AttributeDefinition> _attDef = new List<AttributeDefinition>();
            myAutoCAD.myUtilities objUtil = new myUtilities();
            
            try
            {
                using (DocumentLock dl = Application.DocumentManager.MdiActiveDocument.LockDocument())
                {
                    BlockTable bt = (BlockTable)myT.GetObject(db.BlockTableId, OpenMode.ForRead);
                    BlockTableRecord btr = (BlockTableRecord)myT.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                    BlockTableRecord btrDef = (BlockTableRecord)myT.GetObject(bt[blockName], OpenMode.ForRead);
                    myRegistry.regIO objRegIO = new myRegistry.regIO();
                    int Precision = (int) objRegIO.readValue("blocks", "Kommastellen");

                    //Attribute übernehmen      
                    if (btrDef.HasAttributeDefinitions)
                    {
                        foreach (ObjectId id in btrDef)
                        {
                            DBObject obj = myT.GetObject(id, OpenMode.ForRead);
                            try
                            {
                                AttributeDefinition ad = (AttributeDefinition)obj;

                                if (ad != null)
                                {
                                    _attPos.Add(ad.Tag, ad.Position);
                                    _attDef.Add(ad);
                                }
                            }
                            catch
                            {
                                try
                                {
                                    Entity ent = (Entity)obj;
                                    //Layer = ent.Layer;
                                }
                                catch { }
                            }
                        }
                    }

                    Point3d ptIns;

                    bool b3d = Convert.ToBoolean(m_objRegistry.readValue("blocks", "insert3d"));

                    if (b3d && m_Höhe.HasValue)
                        ptIns = new Point3d(m_Pos.X, m_Pos.Y, m_Höhe.Value);
                    else
                        ptIns = m_Pos;

                    BlockReference blkRef = new BlockReference(ptIns, bt[blockName]);
                    blkRef.ScaleFactors= new Scale3d(db.Cannoscale.Scale);
                    blkRef.Layer = Basislayer;
                    btr.AppendEntity(blkRef);

                    m_HeigthPrecision = Precision;

                    //XData schreiben
                    AddRegAppTableRecord("DKRM");
                    ResultBuffer rb = new ResultBuffer();
                    rb.Add(new TypedValue((int)DxfCode.ExtendedDataRegAppName, "DKRM"));
                    rb.Add(new TypedValue((int)DxfCode.ExtendedDataWorldXCoordinate, m_Pos));
                    rb.Add(new TypedValue((int)DxfCode.ExtendedDataLayerName, Basislayer));

                    if (m_CASHöhe.HasValue)
                        rb.Add(new TypedValue((int)DxfCode.ExtendedDataAsciiString, m_CASHöhe.Value));

                    rb.Add(new TypedValue((int)DxfCode.ExtendedDataInteger32, m_CASPrecision));

                    blkRef.XData = rb;
                    rb.Dispose();

                    //Event
                    //blkRef.ObjectClosed += new ObjectClosedEventHandler(evtBlockModified);

                    myT.AddNewlyCreatedDBObject(blkRef, true);

                    if (_attPos != null)
                    {
                        for (int i = 0; i < _attPos.Count; i++)
                        {
                            AttributeReference _attRef = new AttributeReference();
                            _attRef.SetDatabaseDefaults();
                            _attRef.SetAttributeFromBlock(_attDef[i], Matrix3d.Identity);
                            _attRef.SetPropertiesFrom(_attDef[i]);

                            Point3d ptBase = new Point3d(blkRef.Position.X + _attRef.Position.X,
                                                         blkRef.Position.Y + _attRef.Position.Y,
                                                         blkRef.Position.Z + _attRef.Position.Z);


                            _attRef.Position = ptBase;
                            string Stammlayer = Basislayer.Substring(0, Basislayer.Length - 2);
                            string attLayer = String.Empty;

                            switch (i)
                            {
                                //Punktnummer
                                case 0:
                                    _attRef.TextString = m_PNum;
                                    attLayer = Stammlayer + Global.layAtt1;
                                    objLayer.checkLayer(attLayer, true);
                                    _attRef.Layer = attLayer;

                                    break;

                                //Höhe
                                case 1:
                                    if (m_Höhe.HasValue && m_HeigthPrecision.HasValue)
                                    {
                                        _attRef.TextString = m_Höhe.Value.ToString(objUtil.Formatstring(HeigthPrecision.Value));
                                        attLayer = Stammlayer + Global.layAtt2;
                                        objLayer.checkLayer(attLayer,true);
                                        _attRef.Layer = attLayer;
                                    }

                                    break;

                                case 2:
                                    if (m_Att3_Wert != null)
                                    {
                                        _attRef.TextString = m_Att3_Wert;
                                        attLayer = Stammlayer + Global.layAtt3;
                                        objLayer.checkLayer(attLayer,true);
                                        _attRef.Layer = attLayer;
                                    }

                                    break;

                                case 3:
                                        attLayer = Stammlayer + Global.layAtt4;
                                        objLayer.checkLayer(attLayer,true);
                                        _attRef.Layer = attLayer;
                                        if (m_Att4_Wert != null)
                                            _attRef.TextString = m_Att4_Wert;

                                    break;

                                case 4:
                                        attLayer = Stammlayer + Global.layAtt5;
                                        objLayer.checkLayer(attLayer,true);
                                        _attRef.Layer = attLayer;                                    
                                        
                                        if (m_Att5_Wert != null)
                                            _attRef.TextString = m_Att5_Wert;

                                    break;

                                case 5:
                                        attLayer = Stammlayer + Global.layAtt6;
                                        objLayer.checkLayer(attLayer,true);
                                        _attRef.Layer = attLayer;

                                    if (m_Att6_Wert != null)
                                        _attRef.TextString = m_Att6_Wert;

                                    break;

                                case 6:
                                    attLayer = "0";
                                    _attRef.Layer = attLayer;

                                    if (m_Att7_Wert != null)
                                        _attRef.TextString = m_Att7_Wert;

                                    break;

                                case 7:
                                    attLayer = "0";
                                    _attRef.Layer = attLayer;

                                    if (m_Att8_Wert != null)
                                        _attRef.TextString = m_Att8_Wert;

                                    break;

                                case 8:
                                    attLayer = "0";
                                    _attRef.Layer = attLayer;

                                    if (m_Att9_Wert != null)
                                        _attRef.TextString = m_Att9_Wert;

                                    break;

                                case 9:
                                    attLayer = "0";
                                    _attRef.Layer = attLayer;

                                    if (m_Att10_Wert != null)
                                        _attRef.TextString = m_Att10_Wert;

                                    break;
                            }

                            blkRef.AttributeCollection.AppendAttribute(_attRef);
                            myT.AddNewlyCreatedDBObject(_attRef, true);
                        }
                    }

                    es = ErrorStatus.OK;
                }
            }

            catch (Autodesk.AutoCAD.Runtime.Exception e)
            {
                if (e.Message == "eKeyNotFound")
                {
                    System.Windows.Forms.MessageBox.Show("Block " + blockName + " nicht gefunden!");
                    es = ErrorStatus.KeyNotFound;
                }
            }

            finally
            {
                myT.Commit();
                myT.Dispose();
            }

            return es;
        }

        //XData hinzufügen
        static void AddRegAppTableRecord(string regAppName)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            Database db = doc.Database;
            Transaction tr = doc.TransactionManager.StartTransaction();

            using (tr)
            {
                RegAppTable rat = (RegAppTable)tr.GetObject(db.RegAppTableId, OpenMode.ForRead, false);
                if (!rat.Has(regAppName))
                {
                    rat.UpgradeOpen();
                    RegAppTableRecord ratr = new RegAppTableRecord();
                    ratr.Name = regAppName;
                    rat.Add(ratr);
                    tr.AddNewlyCreatedDBObject(ratr, true);
                }

                tr.Commit();
            }
        }

        //Events
        public void evtBlockModified(object sender, EventArgs arg)
        {
            Database db = HostApplicationServices.WorkingDatabase;
            Autodesk.AutoCAD.DatabaseServices.TransactionManager myTm = db.TransactionManager;
            Transaction myT = db.TransactionManager.StartTransaction();
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ObjectContextManager conTextManager = db.ObjectContextManager;
            try
            {
                using (DocumentLock dl = Application.DocumentManager.MdiActiveDocument.LockDocument())
                {
                    BlockTable bt = (BlockTable)myT.GetObject(db.BlockTableId, OpenMode.ForRead);
                    BlockTableRecord btr = (BlockTableRecord)myT.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                    //BlockTableRecord btrDef = (BlockTableRecord)myT.GetObject(bt[(ObjectId) arg.], OpenMode.ForRead);
                }

            }

            catch { }
        }

        /// <summary>
        /// Kommastellen anpassen
        /// </summary>
        /// <param name="decimals"></param>
        public void Kommastellen(int decimals)
        {
            myUtilities objUtil = new myUtilities();

            if (decimals >= m_HeigthPrecision.Value)
                decimals = m_HeigthPrecision.Value;

            if (m_CASHöhe.HasValue)
                m_Höhe = Math.Round(m_CASHöhe.Value, decimals);

            HeigthPrecision = decimals;
        }
    }

    public partial class Blöcke
    {
        private Database m_db = null;
        private Transaction m_myT = null;
        private Editor m_ed = null;

        private Messpunkt[] m_vMP = null;           //alle Messpunkte
        private Messpunkt[] m_vMPheigth = null;     //Messpunkte mit korrektem Höhenattribut
        private Messpunkt[] m_vMPbereich = null;    //Messpunkte im gewählten Höhenbereich
        private int[] m_vMPempty = null;
        private int m_vMPEmptycount = 0;

        private double? m_Hmin = null;              //minimale Höhe
        private double? m_Hmax = null;              //maximale Höhe
        
        private lsHöhen m_lsHöhen = new lsHöhen();
        private List<string> mls_textStyles = new List<string>(); 
        private string m_Textstyle = null;


        //Konstruktor (damit kein Default Konstruktor generiert wird!)
        protected Blöcke() { }

        public void init()
        {
            //Datenbank initialisieren
            m_db = HostApplicationServices.WorkingDatabase;
            m_myT = m_db.TransactionManager.StartTransaction();
            m_ed = Application.DocumentManager.MdiActiveDocument.Editor;

            //Tabelle wieder löschen
            m_vMP = null;
            m_vMPempty = null;
            m_vMPEmptycount = 0;

            m_Hmin = null;
            m_Hmax = null;
        }

        public void close()
        {
            try
            {
                m_myT.Commit();
                m_myT.Dispose();
            }
            catch { }
        }

        //Instanz (Singleton)
        public static Blöcke Instance
        {
            get { return BlöckeCreator.createInstance; }
        }

        private sealed class BlöckeCreator
        {
            private static readonly Blöcke _Instance = new Blöcke();

            public static Blöcke createInstance
            {
                get { return _Instance; }
            }
        }

        //Properties
        /// <summary>
        /// Anzahl der gewählten Blöcke
        /// </summary>
        public int count
        {
            get {
                try
                {
                    return this.m_vMP.Length;
                }
                catch { return 0; }
            }
        }

        /// <summary>
        /// Id's von Blöcken mit leerem Höhenstring
        /// </summary>
        public int[] idBlockEmpty
        {
            get { return this.m_vMPempty; }
        }

        /// <summary>
        /// Anzahl der Blöcke mit gültiger Höhe
        /// </summary>
        public int countHeigths
        {
            get { return this.m_vMPheigth.Length; }
        }

        /// <summary>
        /// Anzahl der Blöcke mit leerem Höhenstring
        /// </summary>
        public int countEmptyHeigths
        {
            get { return this.m_vMPEmptycount; }
        }

        /// <summary>
        /// kleinste Höhe
        /// </summary>
        public double getHmin
        {
            get { return this.m_Hmin.Value; }
        }

        /// <summary>
        /// größte Höhe
        /// /// </summary>
        public double getHmax
        {
            get { return this.m_Hmax.Value; }
        }

        /// <summary>
        /// alle Messpunkte
        /// </summary>
        public Messpunkt[] getMP
        {
            get { return this.m_vMP; }
        }

        /// <summary>
        /// Messpunkte im gewählten Höhenbereich
        /// </summary>
        public Messpunkt[] getMPsel
        {
            get { return this.m_vMPbereich; }
        }

        /// <summary>
        /// löscht Blöcke mit übergebenen Namen aus Blockliste
        /// </summary>
        /// <param name="Blocknamen"></param>
        public void delNames(string[] Blocknamen)
        {
            Messpunkt[] vBlöckeNeu = new Messpunkt[m_vMP.Length];
            List<Messpunkt> lsMPNeu = new List<Messpunkt>();

            foreach (Messpunkt objMP in m_vMP)
            {
                if (!Blocknamen.Contains(objMP.Name))
                    lsMPNeu.Add(objMP);
            }

            m_vMP = lsMPNeu.ToArray();
        }

        /// <summary>
        /// TextStile in Attributen abfragen
        /// </summary>
        public string[] getTextstyles
        {
            get {
                string[] lsTextstyles = new String[this.mls_textStyles.Count];

                for (int i = 0; i < this.mls_textStyles.Count; i++)
                {
                    lsTextstyles[i] = this.mls_textStyles[i];
                }
                return lsTextstyles; }
        }

        /// <summary>
        /// Textstil für Blockattribute setzen
        /// </summary>
        public string setTextstyle
        {
            set { this.m_Textstyle = value; }
        }

        //public int? setHeightPrecision
        //{
        //    set { this.m_HeightPrecision = value; }
        //}

        public List<string> getNames
        {
            get
            {
                List<string> lsNamen = new List<string>();

                foreach (Messpunkt objMP in m_vMP)
                {
                    if(!lsNamen.Contains(objMP.Name))
                        lsNamen.Add(objMP.Name);
                }

                return lsNamen;
            }
        }

        //Methoden

        /// <summary>
        /// alle Blöcke aus Zeichnung lesen
        /// </summary>
        /// <returns></returns>
        public ErrorStatus selectAll()
        {
            ErrorStatus eStatus = ErrorStatus.KeyNotFound;
            SelectionSet ssRes = null;

            //Blöcke auswählen
            //Filter
            TypedValue[] values = new TypedValue[1] {
                new TypedValue((int)DxfCode.Start, "INSERT")};
            SelectionFilter selFilter = new SelectionFilter(values);

            PromptSelectionResult resSel = m_ed.SelectAll(selFilter);
            ssRes = resSel.Value;

            if (ssRes.Count > 0)
            {
                fillTable(ssRes);
                eStatus = ErrorStatus.OK;
            }

            return eStatus;
        }   //selectAll

        /// <summary>
        /// Blöcke mit Fenster wählen
        /// </summary>
        /// <returns></returns>
        public ErrorStatus selectWindow()
        {
            ErrorStatus eStatus = ErrorStatus.KeyNotFound;
            SelectionSet ssRes = null;
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;

            //Filter
            TypedValue[] values = new TypedValue[1] {
                new TypedValue((int)DxfCode.Start, "INSERT")};
            SelectionFilter selFilter = new SelectionFilter(values);

            PromptSelectionResult resSel = ed.GetSelection(selFilter);

            if (resSel.Status == PromptStatus.OK)
            {
                ssRes = resSel.Value;

                fillTable(ssRes);
                eStatus = ErrorStatus.OK;
            }

            return eStatus;
        }   //selectWindow

        /// <summary>
        /// Blöcke mit eigenem Filter auswählen
        /// </summary>
        /// <param name="Filter"></param>
        /// <returns></returns>
        public ErrorStatus selectWindow(SelectionFilter selFilter)
        {
            ErrorStatus eStatus = ErrorStatus.KeyNotFound;
            SelectionSet ssRes = null;
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;

            PromptSelectionResult resSel = ed.GetSelection(selFilter);

            if (resSel.Status == PromptStatus.OK)
            {
                ssRes = resSel.Value;

                fillTable(ssRes);
                eStatus = ErrorStatus.OK;
            }

            return eStatus;
        }   //selectWindow

        /// <summary>
        /// Wert zu Attributen addieren
        /// </summary>
        /// <param name="dH"></param>
        public void addHeigth(double dH)
        {
            for (int i = 0; i < m_vMP.Length; i++)
            {
                Messpunkt MP = m_vMP[i];
                if (MP.Höhe != null)
                    MP.Höhe += dH;

            }   //for

            //Attribute aktualisieren
            refreshAttributes();
        }   //addHeigth

        /// <summary>
        /// Sichtbarkeit von Blockattributen schalten
        /// </summary>
        /// <param name="Switch"></param>
        public void attSwitch(string Switch)
        {
            switch (Switch)
            {
                case "AttPon":
                    foreach (Messpunkt MP in m_vMP)
                        MP.Att1_Visible = true;
                    break;

                case "AttPoff":
                    foreach (Messpunkt MP in m_vMP)
                        MP.Att1_Visible = false;
                    break;

                case "AttHon":
                    foreach (Messpunkt MP in m_vMP)
                        MP.Att2_Visible = true;
                    break;

                case "AttHoff":
                    foreach (Messpunkt MP in m_vMP)
                        MP.Att2_Visible = false;
                    break;
            }
            refreshAttributes();
        }

        //Kommastellen anpassen
        public void Kommastellen(int decimals)
        {
            foreach (Messpunkt MP in m_vMP)
                MP.Kommastellen(decimals);

            refreshAttributes();
        }

        //Messpunkt an bestimmter Position
        public ErrorStatus findPos(ref Messpunkt MP, Point2d Position, double Tolerance)
        {
            ErrorStatus eStatus = ErrorStatus.KeyNotFound;

            for (int i = 0; i < m_vMP.Length; i++)
            {
                Point3d blockPos = m_vMP[i].Position;
                Point2d blockPos2d = new Point2d(blockPos.X, blockPos.Y);

                if ((Position.GetDistanceTo(blockPos2d) < Tolerance)    //nur Blöcke mit mind. 1 Attribut
                    && m_vMP[i].AttCount > 0 && !m_vMP[i].isErased)
                {
                    MP = m_vMP[i];
                    eStatus = ErrorStatus.OK;
                    break;
                }
            }

            return eStatus;
        }

        //Messpunkt auf Bogen
        public ErrorStatus findArc(ref Messpunkt MP, CircularArc2d objArc, double Tolerance)
        {
            ErrorStatus eStatus = ErrorStatus.KeyNotFound;

            for (int i = 0; i < m_vMP.Length; i++)
            {
                Point3d blockPos = m_vMP[i].Position;
                Point2d blockPos2d = new Point2d(blockPos.X, blockPos.Y);

                if ((objArc.GetDistanceTo(blockPos2d) < Tolerance)    //nur Blöcke mit mind. 1 Attribut
                    && m_vMP[i].AttCount > 0)
                {
                    //Anfangs- und Endpunkt des Bogens auschliessen
                    Point2d ptMP = new Point2d(m_vMP[i].Position.X, m_vMP[i].Position.Y);
                    if ((objArc.StartPoint.GetDistanceTo(ptMP) > Tolerance)
                        && (objArc.EndPoint.GetDistanceTo(ptMP) > Tolerance))
                    {
                        MP = m_vMP[i];
                        eStatus = ErrorStatus.OK;
                        break;
                    }
                }
            }

            return eStatus;
        }

        public ErrorStatus findID(ref Messpunkt MP, int id)
        {
            ErrorStatus eStatus = ErrorStatus.NotInBlock;

            try
            {
                MP = m_vMP[id];
            }
            finally
            {
                eStatus = ErrorStatus.OK;
            }

            return eStatus;
        }


        /// <summary>
        /// MP anhand von Höhenbereich finden
        /// </summary>
        /// <param name="?"></param>
        /// <param name="Hstart"></param>
        /// <param name="Hend"></param>
        /// <returns></returns>
        public ErrorStatus createMPBereich(double Hstart, double Hend)
        {
            ErrorStatus eStatus = ErrorStatus.NotApplicable;

            //Anzahl der Punkte im Höhenbereich bestimmen
            int iMPBereich = 0;

            foreach (Messpunkt mp in m_vMP)
            {
                if ((mp.Höhe >= Hstart) && (mp.Höhe <= Hend))
                    iMPBereich++;
            }

            //Array befüllen
            Messpunkt[] vMPBereich = new Messpunkt[iMPBereich];
            m_vMPbereich = vMPBereich;
            int iZähler = 0;

            foreach (Messpunkt mp in m_vMP)
            {
                if ((mp.Höhe >= Hstart) && (mp.Höhe <= Hend))
                    vMPBereich[iZähler++] = mp;
            }

            if (m_vMPbereich != null)
                eStatus = ErrorStatus.OK;

            return eStatus;
        }

        private void fillTable(SelectionSet ssRes)
        {
            Messpunkt[] vMP = new Messpunkt[ssRes.Count];
            m_vMP = vMP;

            int[] vMPempty = new int[ssRes.Count];
            m_vMPempty = vMPempty;

            ObjectId[] objID = ssRes.GetObjectIds();
            int i = 0;

            //SelectionSet iterieren
            foreach (ObjectId blkID in objID)
            {
                using (DocumentLock dl = Application.DocumentManager.MdiActiveDocument.LockDocument())
                {
                    try
                    {
                        m_myT.GetObject(blkID, OpenMode.ForRead);
                        BlockReference blkRef = (BlockReference)m_myT.GetObject(blkID, OpenMode.ForRead);

                        //nur Blöcke mit Attributen berücksichtigen
                        AttributeCollection colAtt = blkRef.AttributeCollection;
                        
                        if (colAtt.Count >= 1)
                        {

                            m_vMP[i] = new Messpunkt();

                            m_vMP[i].BlockReferenz = blkRef;
                            m_vMP[i].Name = blkRef.Name;
                            m_vMP[i].Position = blkRef.Position;
                            m_vMP[i].Layer = blkRef.Layer;
                            m_vMP[i].FaktorX = blkRef.ScaleFactors.X;
                            m_vMP[i].FaktorY = blkRef.ScaleFactors.Y;
                            m_vMP[i].FaktorZ = blkRef.ScaleFactors.Z;

                        //XData lesen
                        ResultBuffer rb = blkRef.XData;

                        if (rb != null)
                        {
                            int n = 0;
                            foreach (TypedValue tv in rb)
                            {
                                switch (tv.TypeCode)
                                {
                                    case 1000:
                                        try
                                        {
                                            m_vMP[i].CASHöhe = Convert.ToDouble(tv.Value);
                                                                                    }
                                        catch { }

                                        break;

                                    case 1001:

                                        break;

                                    case 1071:
                                        try
                                        {
                                            m_vMP[i].HeigthPrecision = Convert.ToInt32(tv.Value);
                                        }
                                        catch { }

                                        break;
                                }
                                n++;
                            }
                        }
                            //Attribute iterieren
                            int attCount = 0;

                            foreach (ObjectId attID in colAtt)
                            {
                                AttributeReference attRef = (AttributeReference)m_myT.GetObject(attID, OpenMode.ForRead);

                                switch (attCount)
                                {
                                    //Punktnummer
                                    case 0:
                                        m_vMP[i].PNum = attRef.TextString;

                                        m_vMP[i].Att1_Pos = attRef.Position;
                                        m_vMP[i].Att1_Layer = attRef.Layer;
                                        m_vMP[i].Att1_Height = attRef.Height;
                                        m_vMP[i].Att1_Neigung = attRef.Oblique;
                                        m_vMP[i].Att1_Textstil = attRef.TextStyleName;
                                        m_vMP[i].Att1_Breitenfaktor = attRef.WidthFactor;
                                        m_vMP[i].Att1_Visible = attRef.Visible;

                                        if (!this.mls_textStyles.Contains(attRef.TextStyleName))
                                            this.mls_textStyles.Add(attRef.TextStyleName);
                                        break;

                                    //Punkthöhe 
                                    case 1:
                                        string sHöhe = attRef.TextString;

                                        m_vMP[i].Att2_Pos = attRef.Position;
                                        m_vMP[i].Att2_Layer = attRef.Layer;
                                        m_vMP[i].Att2_Height = attRef.Height;
                                        m_vMP[i].Att2_Neigung = attRef.Oblique;
                                        m_vMP[i].Att2_Textstil = attRef.TextStyleName;
                                        m_vMP[i].Att2_Breitenfaktor = attRef.WidthFactor;
                                        m_vMP[i].Att2_Visible = attRef.Visible;

                                        //leeren Textstring überspringen
                                        if (sHöhe.Trim() == "")
                                        {
                                            m_vMP[i].Höhe = null;
                                            m_vMP[i].HeigthPrecision = null;
                                            m_vMPempty[m_vMPEmptycount++] = i;
                                            break;
                                        }

                                        myAutoCAD.myUtilities objUtil = new myUtilities();
                                        double dHöhe = 0;
                                        if (objUtil.convertToDouble(sHöhe, ref dHöhe, null) == ErrorStatus.OK)
                                        {
                                            //double dHöhe = Convert.ToDouble(sHöhe);
                                            m_vMP[i].Höhe = dHöhe;

                                            if ((dHöhe < m_Hmin) || (m_Hmin == null))
                                            {
                                                m_Hmin = dHöhe;
                                            }

                                            if ((dHöhe > m_Hmax) || (m_Hmax == null))
                                                m_Hmax = dHöhe;

                                            try
                                            {
                                                sHöhe = sHöhe.Substring(sHöhe.LastIndexOf('.'));
                                            }
                                            catch { }

                                            if (sHöhe[0] == '.')
                                                sHöhe = sHöhe.Substring(1);

                                            if (m_vMP[i].HeigthPrecision == null)
                                                m_vMP[i].HeigthPrecision = sHöhe.Length;
                                        }
                                        break;

                                    //Att3
                                    case 2:
                                        string sAtt3Wert = attRef.TextString;

                                        m_vMP[i].Att3_Pos = attRef.Position;
                                        m_vMP[i].Att3_Layer = attRef.Layer;
                                        m_vMP[i].Att3_Height = attRef.Height;
                                        m_vMP[i].Att3_Neigung = attRef.Oblique;
                                        m_vMP[i].Att3_Textstil = attRef.TextStyleName;
                                        m_vMP[i].Att3_Breitenfaktor = attRef.WidthFactor;
                                        m_vMP[i].Att3_Wert = attRef.TextString;
                                        
                                        break;

                                    //Att4
                                    case 3:
                                        string sAtt4Wert = attRef.TextString;

                                        m_vMP[i].Att4_Pos = attRef.Position;
                                        m_vMP[i].Att4_Layer = attRef.Layer;
                                        m_vMP[i].Att4_Height = attRef.Height;
                                        m_vMP[i].Att4_Neigung = attRef.Oblique;
                                        m_vMP[i].Att4_Textstil = attRef.TextStyleName;
                                        m_vMP[i].Att4_Breitenfaktor = attRef.WidthFactor;
                                        m_vMP[i].Att4_Wert = attRef.TextString;

                                        break;

                                    //Att5
                                    case 4:
                                        string sAtt5Wert = attRef.TextString;

                                        m_vMP[i].Att5_Pos = attRef.Position;
                                        m_vMP[i].Att5_Layer = attRef.Layer;
                                        m_vMP[i].Att5_Height = attRef.Height;
                                        m_vMP[i].Att5_Neigung = attRef.Oblique;
                                        m_vMP[i].Att5_Textstil = attRef.TextStyleName;
                                        m_vMP[i].Att5_Breitenfaktor = attRef.WidthFactor;
                                        m_vMP[i].Att5_Wert = attRef.TextString;

                                        break;

                                    //Att6
                                    case 5:
                                        string sAtt6Wert = attRef.TextString;

                                        m_vMP[i].Att6_Pos = attRef.Position;
                                        m_vMP[i].Att6_Layer = attRef.Layer;
                                        m_vMP[i].Att6_Height = attRef.Height;
                                        m_vMP[i].Att6_Neigung = attRef.Oblique;
                                        m_vMP[i].Att6_Textstil = attRef.TextStyleName;
                                        m_vMP[i].Att6_Breitenfaktor = attRef.WidthFactor;
                                        m_vMP[i].Att6_Wert = attRef.TextString;

                                        break;

                                    //Att7
                                    case 6:
                                        string sAtt7Wert = attRef.TextString;

                                        m_vMP[i].Att7_Pos = attRef.Position;
                                        m_vMP[i].Att7_Layer = attRef.Layer;
                                        m_vMP[i].Att7_Height = attRef.Height;
                                        m_vMP[i].Att7_Neigung = attRef.Oblique;
                                        m_vMP[i].Att7_Textstil = attRef.TextStyleName;
                                        m_vMP[i].Att7_Breitenfaktor = attRef.WidthFactor;
                                        m_vMP[i].Att7_Wert = attRef.TextString;

                                        break;

                                    //Att8
                                    case 7:
                                        string sAtt8Wert = attRef.TextString;

                                        m_vMP[i].Att8_Pos = attRef.Position;
                                        m_vMP[i].Att8_Layer = attRef.Layer;
                                        m_vMP[i].Att8_Height = attRef.Height;
                                        m_vMP[i].Att8_Neigung = attRef.Oblique;
                                        m_vMP[i].Att8_Textstil = attRef.TextStyleName;
                                        m_vMP[i].Att8_Breitenfaktor = attRef.WidthFactor;
                                        m_vMP[i].Att8_Wert = attRef.TextString;

                                        break;

                                    //Att9
                                    case 8:
                                        string sAtt9Wert = attRef.TextString;

                                        m_vMP[i].Att9_Pos = attRef.Position;
                                        m_vMP[i].Att9_Layer = attRef.Layer;
                                        m_vMP[i].Att9_Height = attRef.Height;
                                        m_vMP[i].Att9_Neigung = attRef.Oblique;
                                        m_vMP[i].Att9_Textstil = attRef.TextStyleName;
                                        m_vMP[i].Att9_Breitenfaktor = attRef.WidthFactor;
                                        m_vMP[i].Att9_Wert = attRef.TextString;

                                        break;

                                    //Att10
                                    case 9:
                                        string sAtt10Wert = attRef.TextString;

                                        m_vMP[i].Att10_Pos = attRef.Position;
                                        m_vMP[i].Att10_Layer = attRef.Layer;
                                        m_vMP[i].Att10_Height = attRef.Height;
                                        m_vMP[i].Att10_Neigung = attRef.Oblique;
                                        m_vMP[i].Att10_Textstil = attRef.TextStyleName;
                                        m_vMP[i].Att10_Breitenfaktor = attRef.WidthFactor;
                                        m_vMP[i].Att10_Wert = attRef.TextString;

                                        break;

                                    default:
                                        break;
                                }
                                attCount++;
                                attRef.Dispose();
                            }
                            m_vMP[i].AttCount = attCount;
                            i++;

                        }
                    }
                    catch { }
                }   
            }

            //Array auf tatsächliche Größe reduzieren
            Messpunkt[] vMPneu = new Messpunkt[i];
            for (int j = 0; j < i; j++)
            {
                vMPneu[j] = m_vMP[j];
            }
            m_vMP = vMPneu;
            //Vektor mit MP mit gültiger Höhe befüllen
            createValidHeigths();

            m_myT.Commit();

        }   //fillTable

        /// <summary>
        /// Attribute aktualisieren
        /// </summary>
        private void refreshAttributes()
        {
            IFormatProvider iFormatDE = CultureInfo.GetCultureInfo("de-DE").NumberFormat;
            Transaction tr = m_db.TransactionManager.StartTransaction();

            myFunctions.Settings objSettings = new myFunctions.Settings();

            using (DocumentLock dl = Application.DocumentManager.MdiActiveDocument.LockDocument())
            {
                

                for (int i = 0; i < m_vMP.Length; i++)
                {
                    Messpunkt MP = m_vMP[i];
                    BlockTable bt = (BlockTable)tr.GetObject(m_db.BlockTableId, OpenMode.ForRead);
                    ObjectId id = bt[BlockTableRecord.ModelSpace];

                    //Attribute iterieren
                    AttributeCollection colAtt = MP.BlockReferenz.AttributeCollection;
                    int attCount = 0;

                    foreach (ObjectId attID in colAtt)
                    {
                        AttributeReference attRef = (AttributeReference)tr.GetObject(attID, OpenMode.ForRead);

                        switch (attCount)
                        {
                            //Punktnummer
                            case 0:
                                attRef.UpgradeOpen();
                                attRef.Visible = MP.Att1_Visible;
                                attRef.DowngradeOpen();
                                break;

                            //Punkthöhe 
                            case 1:
                                string sFormat = "{0:f" + objSettings.HeightPrecision.ToString() + "}";

                                attRef.UpgradeOpen();
                                attRef.TextString = string.Format(sFormat, m_vMP[i].Höhe);
                                attRef.Visible = MP.Att2_Visible;
                                attRef.DowngradeOpen();

                                attRef.Dispose();
                                break;

                            default:
                                break;
                        }

                        attCount++;
                    }
                }
            }
            tr.Commit();
        }   //refreshAttributes

        /// <summary>
        /// Eigenschaften der Blockattribute aktualisieren
        /// </summary>
        public void refreshAttProperties(string A1Textstil, double? A1Texthöhe, double? A1Neigung, double? A1Breitenfaktor,
                                         string A2Textstil, double? A2Texthöhe, double? A2Neigung, double? A2Breitenfaktor, bool A2SwitchVis, int? precision)
        {
            Database db = HostApplicationServices.WorkingDatabase;
            Transaction myT = db.TransactionManager.StartTransaction();

            for (int i = 0; i < m_vMP.Length; i++)
            {
                using (DocumentLock dl = Application.DocumentManager.MdiActiveDocument.LockDocument())
                {
                    Messpunkt MP = m_vMP[i];

                    //Attribute iterieren
                    AttributeCollection colAtt = MP.BlockReferenz.AttributeCollection;
                    int attCount = 0;

                    foreach (ObjectId attID in colAtt)
                    {
                        AttributeReference attRef = (AttributeReference)myT.GetObject(attID, OpenMode.ForWrite);
                        switch (attCount)
                        {
                            //Punktnummer 
                            case 0:
                                if (A1Textstil != null)
                                {
                                    myAutoCAD.myUtilities myUtil = new myUtilities();

                                    ObjectId A1TextstilId = new ObjectId();
                                    if (myUtil.getTextStyleId(A1Textstil, ref A1TextstilId) == ErrorStatus.OK)
                                        attRef.TextStyleId = A1TextstilId;
                                }

                                if (A1Texthöhe.HasValue)
                                    attRef.Height = A1Texthöhe.Value;

                                if (A1Neigung.HasValue)
                                    attRef.Oblique = A1Neigung.Value;

                                if (A1Breitenfaktor.HasValue)
                                    attRef.WidthFactor = A1Breitenfaktor.Value;

                                break;

                            // Punkthöhe
                            case 1:
                                if (A2Textstil != null)
                                {
                                    myAutoCAD.myUtilities myUtil = new myUtilities();

                                    ObjectId A2TextstilId = new ObjectId();
                                    if (myUtil.getTextStyleId(A2Textstil, ref A2TextstilId) == ErrorStatus.OK)
                                        attRef.TextStyleId = A2TextstilId;

                                }

                                if (A2Texthöhe.HasValue)
                                    attRef.Height = A2Texthöhe.Value;

                                if (A2Neigung.HasValue)
                                    attRef.Oblique = A2Neigung.Value;

                                if (A2Breitenfaktor.HasValue)
                                    attRef.WidthFactor = A2Breitenfaktor.Value;

                                if (A2SwitchVis)
                                {
                                    bool bVis = attRef.Invisible;
                                    if (bVis)
                                    {
                                        attRef.Invisible = false;
                                        attRef.Visible = true;
                                    }
                                    else
                                    {
                                        attRef.Invisible = true;
                                        attRef.Visible = false;
                                    }
                                }

                                if (precision.HasValue)
                                {
                                    string sFormat = "{0:f" + precision.Value.ToString() + "}";
                                    if ((precision < this.m_vMP[i].HeigthPrecision) && precision.HasValue && m_vMP[i].Höhe.HasValue)
                                        attRef.TextString = string.Format(sFormat, m_vMP[i].Höhe);
                                }

                                break;

                            default:
                                break;
                        }
                        
                        attCount++; ;
                    }
                }
            }
            myT.Commit();
            Application.UpdateScreen();
            m_ed.Regen();
        }

        /// <summary>
        /// Blöcke aus Prototypzeichnung übernehmen
        /// </summary>
        /// <param name="objProto"></param>
        /// <returns></returns>
        public ErrorStatus updateBlocks(Prototyp objProto, List<string> lsNamen)
        {
            Transaction tr = m_db.TransactionManager.StartTransaction();

            ErrorStatus es = ErrorStatus.KeyNotFound;
            List<BlockReference> lsBlkRef = objProto.getBlockRefList;        

            //zu ersetzende Blöcke umbenennen
            //Blocktable
            try
            {
                using (DocumentLock dl = Application.DocumentManager.MdiActiveDocument.LockDocument())
                {
                    BlockTable bt = (BlockTable)(tr.GetObject(m_db.BlockTableId, OpenMode.ForWrite));
                    BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                    ObjectIdCollection blockIDs = new ObjectIdCollection();

                    //Blockdefinition aus Prototypzeichnung einfügen
                    objProto.importBlock(lsNamen);


                    foreach (ObjectId btrId in btr)
                    {
                        BlockReference br = (BlockReference)tr.GetObject(btrId, OpenMode.ForWrite);

                        if (lsNamen.Contains(br.Name))
                        {
                            //zu ersetzende Blöcke umbenennen
                    
                         


                            //neuen Block anlegen
                        }
                    }

                }
            }
            catch {}

            tr.Commit();
            tr.Dispose();

            return es;
        }

        public ErrorStatus refreshAttributes(int index)
        {
            IFormatProvider iFormatDE = CultureInfo.GetCultureInfo("de-DE").NumberFormat;

            Document doc = Application.DocumentManager.MdiActiveDocument;
            DocumentLock dl = doc.LockDocument(DocumentLockMode.ProtectedAutoWrite, null, null, true);
            Database db = HostApplicationServices.WorkingDatabase;

            ErrorStatus eS = ErrorStatus.KeyNotFound;

            Transaction tr = db.TransactionManager.StartTransaction();

            Messpunkt MP = m_vMP[index];
            //Attribute iterieren
            try
            {

            AttributeCollection colAtt = MP.BlockReferenz.AttributeCollection;
            int attCount = 0;

            foreach (ObjectId attID in colAtt)
            {
                AttributeReference attRef = (AttributeReference)tr.GetObject(attID, OpenMode.ForRead);
                    switch (attCount)
                    {
                        //Punkthöhe 
                        case 1:

                            string sFormat = "{0:f" + m_vMP[index].HeigthPrecision.ToString() + "}";
                            attRef.UpgradeOpen();
                            attRef.TextString = string.Format(sFormat, m_vMP[index].Höhe);
                            attRef.DowngradeOpen();

                            //attRef.Dispose();
                            break;

                        default:
                            break;
                    }

                    attCount++;
                }
            }
            catch { }
            tr.Commit();

            return eS;
        }

        public void HeigthsOffset(double Hmin, double Hmax, double Offset)
        {
            createMPBereich(Hmin, Hmax);
            foreach (Messpunkt mp in m_vMPbereich)
            {
                mp.Höhe += Offset;
            }

            //Attribute aktualisieren
            refreshAttributes();
        }

        public void Dispose()
        {
            m_myT.Dispose();
        }


        private void createValidHeigths()
        {
            Messpunkt[] vMPmitHöhe = new Messpunkt[countValidHeigths()];
            m_vMPheigth = vMPmitHöhe;
            int i = 0;

            foreach (Messpunkt mp in m_vMP)
            {
                if (mp.Höhe != null)
                    m_vMPheigth[i++] = mp;
            }
        }

        //MP mit gültiger Höhe zählen
        private int countValidHeigths()
        {
            int i = 0;
            foreach (Messpunkt mp in m_vMP)
            {
                if (mp.Höhe != null)
                    i++;
            }

            return i;
        }

        public void getClosestHeigths(double dHöhe, ref double? min, ref double? max)
        {
            //Liste mit Höhen auffüllen
            List<double> lsHöhen = new List<double>();

            foreach (Messpunkt mp in m_vMPheigth)
            {
                if (!lsHöhen.Contains(mp.Höhe.Value))
                    lsHöhen.Add(mp.Höhe.Value);

            }

            //Testen, ob gesuchte Höhe vorhanden ist
            if (lsHöhen.Contains(dHöhe))
            {
                min = dHöhe;
                max = dHöhe;
            }
            else
            {
                lsHöhen.Sort();

                for (int i = 0; i < lsHöhen.Count; i++)
                {
                    if (lsHöhen[i] > dHöhe)
                    {
                        if (i > 0)
                            min = lsHöhen[i - 1];
                        else
                            min = lsHöhen[i];

                        max = lsHöhen[i];

                        break;
                    }
                }

                //wenn max immer noch NULL -> max = größte Höhe
                if (max == null)
                {
                    min = lsHöhen[lsHöhen.Count - 1];
                    max = min;
                }
            }
        }


        private class lsHöhen
        {
            private List<idHöhe> m_liste = new List<idHöhe>();
            private Dictionary<int, double> m_dict = new Dictionary<int, double>();

            public void insert(int id, double dHöhe)
            {
                idHöhe IDHöhe = new idHöhe(id, dHöhe);
                m_liste.Add(IDHöhe);
            }

            public void sort()
            {
                int n = m_liste.Count;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n - 1; j++)
                    {
                        if (m_liste[j].Höhe > m_liste[j + 1].Höhe)
                        {
                            idHöhe temp = new idHöhe(m_liste[j].ID, m_liste[j].Höhe);
                            m_liste[j] = m_liste[j + 1];
                            m_liste[j + 1] = temp;
                        }
                    }
                }

                //sortierte Liste in Dictionary schreiben
                for (int i = 0; i < m_liste.Count; i++)
                {
                    m_dict.Add(m_liste[i].ID, m_liste[i].Höhe);
                }

            }

            //Hmin
            public double getHmin()
            {
                Dictionary<int, double>.Enumerator it = m_dict.GetEnumerator();
                it.MoveNext();
                return it.Current.Value;
            }

            //Hmax
            public double getHmax()
            {
                Dictionary<int, double>.Enumerator it = m_dict.GetEnumerator();
                for (int i = 0; i < m_dict.Count; i++)
                    it.MoveNext();
                return it.Current.Value;
            }

            //Dict
            public Dictionary<int, double> getDictionary
            {
                get { return this.m_dict; }
            }

            private class idHöhe
            {
                private int m_id;
                private double m_dHöhe;

                public idHöhe(int id, double Höhe)
                {
                    m_id = id;
                    m_dHöhe = Höhe;
                }

                public int ID
                {
                    get { return this.m_id; }
                }


                public double Höhe
                {
                    get { return this.m_dHöhe; }
                }

            }
        }

        private ObjectId createMarker()
        {
            Database db = HostApplicationServices.WorkingDatabase;
            Transaction tr = db.TransactionManager.StartTransaction();

            ObjectId btrId = new ObjectId();
            string blkName = "Marker";

            // Get the block table from the drawing
            BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);

            // Check the block name, to see whether it's
            // already in use     
            if (bt.Has(blkName))
                btrId = bt[blkName];
            else
            {
                // Kreis als Geometrie hinzufügen
                Point3d center = new Point3d(0, 0, 0);
                Circle ent = new Circle(center, Vector3d.ZAxis, 0.5);

                // Attribute Definition
                Point3d attPos = new Point3d(0.6, 0, 0);
                AttributeDefinition att1 = new AttributeDefinition(attPos, "", "dH", "", db.Textstyle);
                att1.ColorIndex = 1;
                att1.Height = 1.0;

                // Create our new block table record...
                BlockTableRecord btr = new BlockTableRecord();
                btr.Name = blkName;

                // Add the new block to the block table
                bt.UpgradeOpen();
                btrId = bt.Add(btr);
                tr.AddNewlyCreatedDBObject(btr, true);

                btr.AppendEntity(ent);
                btr.AppendEntity(att1);

                tr.AddNewlyCreatedDBObject(ent, true);
                tr.AddNewlyCreatedDBObject(att1, true);
            }
            tr.Commit();
            return btrId;
        }

        //Marker setzen
        public ErrorStatus setMarker(Point3d pos, string Wert)
        {
            ErrorStatus eS = ErrorStatus.KeyNotFound;

            Database db = HostApplicationServices.WorkingDatabase;
            Transaction tr = db.TransactionManager.StartTransaction();

            using (DocumentLock dl = Application.DocumentManager.MdiActiveDocument.LockDocument())
            {
                try
                {
                    BlockTable bt = (BlockTable)(tr.GetObject(db.BlockTableId, OpenMode.ForWrite));
                    BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                    // Create the block reference
                    BlockReference br = new BlockReference(pos, createMarker());
                    Scale3d Skalierung = new Scale3d(0.3);
                    br.ScaleFactors = Skalierung;

                    AttributeReference attRef = new AttributeReference();

                    // Iterate the Marker block and find the attribute definition
                    BlockTableRecord btrMarker = (BlockTableRecord)tr.GetObject(bt["Marker"], OpenMode.ForRead);
                    foreach (ObjectId id in btrMarker)
                    {
                    Entity ent = (Entity)tr.GetObject(id, OpenMode.ForRead, false);
                    // Use it to open the current object! 
                    if (ent is AttributeDefinition)
                    {
                        // Set the properties from the attribute definition on our attribute reference
                        AttributeDefinition attDef = ((AttributeDefinition)(ent));
                        attRef.SetAttributeFromBlock(attDef, br.BlockTransform);
                        attRef.TextString = Wert;
                    }
                }

                // Add the reference to ModelSpace
                btr.AppendEntity(br);
                // Add the attribute reference to the block reference
                br.AttributeCollection.AppendAttribute(attRef);
                // let the transaction know
                tr.AddNewlyCreatedDBObject(attRef, true);
                tr.AddNewlyCreatedDBObject(br, true);

                tr.Commit();
                }
                catch { }
            }

            return eS;
        }
    }   //Blöcke

    /// <summary>
    /// Prototypzeichnung
    /// </summary>
    public partial class Prototyp
    {
        private DocumentCollection m_dm = Application.DocumentManager;
        private Editor m_ed = Application.DocumentManager.MdiActiveDocument.Editor;
        private Database m_destDB = null;
        private Database m_sourceDB = new Database(false, true);
        private Autodesk.AutoCAD.DatabaseServices.TransactionManager m_myTM = null;
        private Transaction m_myT = null;

        private BlockTable m_bt = null;
        private List<BlockReference> m_lsBlockRef = new List<BlockReference>();

        //Konstruktor (damit kein Default Konstruktor generiert wird!)
        protected Prototyp() { }

        //Properties
        public int AnzahlBlöcke
        {
            get { return m_lsBlockRef.Count; }
        }

        public List<BlockReference> getBlockRefList
        {
            get { return m_lsBlockRef; }
        }

        /// <summary>
        /// Blocknamen in Prototypzeichnung abrufen
        /// </summary>
        public List<string> getNames
        {
            get
            {
                List<string> lsNamen = new List<string>();

                foreach (BlockReference blkRef in m_lsBlockRef)
                {
                    lsNamen.Add(blkRef.Name);
                }

                return lsNamen;
            }
        }

        //Methoden
        public ErrorStatus init(string Zeichnungsname)
        {
            ErrorStatus es = ErrorStatus.OK;

            //Datenbank initialisieren
            m_destDB = m_dm.MdiActiveDocument.Database;
            m_myTM = m_sourceDB.TransactionManager;
            m_myT = m_myTM.StartTransaction();

            try
            {
                if (m_sourceDB.Filename != "")
                    m_sourceDB.Dispose();

                using (DocumentLock dl = Application.DocumentManager.MdiActiveDocument.LockDocument())
                {
                    m_sourceDB.ReadDwgFile(Zeichnungsname, FileOpenMode.OpenTryForReadShare, true, "");
                }

                //BlockTable öffnen
                m_bt = (BlockTable)m_myTM.GetObject(m_sourceDB.BlockTableId, OpenMode.ForRead, false);
                List<string> blkName = new List<string>();

                foreach (ObjectId btrId in m_bt)
                {
                    BlockTableRecord btr = (BlockTableRecord)m_myTM.GetObject(btrId, OpenMode.ForRead, false);

                    //nur benannte Blöcke aus dem Modellbereich übernehmen
                    if (!btr.IsAnonymous && !btr.IsLayout)
                    {
                        ObjectIdCollection blockReferences = btr.GetBlockReferenceIds(true, true);

                        foreach(ObjectId blkRefObjId in blockReferences)
                        {
                            DBObject blockRefDbObj = (DBObject)m_myTM.GetObject(blkRefObjId, OpenMode.ForRead);
                            BlockReference blkRef = (BlockReference)blockRefDbObj;

                            if (!blkName.Contains(blkRef.Name))
                            {
                                blkName.Add(blkRef.Name);
                                m_lsBlockRef.Add(blkRef);
                            }
                        }
                    }

                    btr.Dispose();
                }
            }
            catch { es = ErrorStatus.KeyNotFound; }

            return es;
        }

        public BlockReference findBlockReference(string Name)
        {
            foreach (BlockReference br in m_lsBlockRef)
            {
                if (br.Name == Name)
                    return br;
            }

            return null;
        }

        public ObjectId findObjectId(string Name)
        {
            ObjectId blockId = new ObjectId();

            foreach (BlockReference br in m_lsBlockRef )
            {
                if (br.Name == Name)
                    return br.ObjectId;
            }
            return blockId;
        }

        public ErrorStatus importBlock(List<string> lsBlöcke)
        {
            ErrorStatus es = ErrorStatus.KeyNotFound;


            return es;
        }

        public void close()
        {
            try
            {
                m_sourceDB.CloseInput(true);
                m_sourceDB.Dispose();
                m_destDB.CloseInput(false);
                m_myT.Commit();
                m_myT.Dispose();
            }
            catch { }
        }

        //Instanz
        public static Prototyp Instance
        {
            get { return PrototypCreator.createInstance; }
        }

        private sealed class PrototypCreator
        {
            private static readonly Prototyp _Instance = new Prototyp();

            public static Prototyp createInstance
            {
                get { return _Instance; }
            }
        }
    }
}
