﻿//Funktionen zur Nutzung der Registry
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace myRegistry
{
    /// <summary>
    /// Applikation registrieren
    /// </summary>
        public static class regApp
        {
            public static string sNameDll = string.Empty;

            public static void register()
            {
                //Pfad für {Autocad} bestimmen
                string sProductKey = Autodesk.AutoCAD.DatabaseServices.HostApplicationServices.Current.UserRegistryProductRootKey + "\\Applications";

                //Pfad für dll bestimmen
                string sPathDll = System.Reflection.Assembly.GetExecutingAssembly().Location;

                //Name von dll bestimmen
                sNameDll = System.Reflection.Assembly.GetExecutingAssembly().GetName().ToString();
                sNameDll = sNameDll.Substring(0, sNameDll.IndexOf(','));

                // Gehezu HKEY_CURRENT_USER\{Autocad}\Applications
                RegistryKey key = Registry.CurrentUser.OpenSubKey(sProductKey, true);

                // Schlüssel "Name".dll hinzufügen
                RegistryKey newkey = key.CreateSubKey(sNameDll);

                //Gehezu {Autocad}\NAME
                key = key.OpenSubKey(sNameDll);

                // Unterschlüssel hinzufügen
                newkey.SetValue("Description", sNameDll + " von Rudi Matzeder");
                newkey.SetValue("LOADER", sPathDll);
                newkey.SetValue("MANAGED", 1);
                newkey.SetValue("LOADCTRLS", 2);

                //Vorgabewerte
                regIO objRegIO = new regIO();
                objRegIO.regValue("blocks", "insert3d", false);
                objRegIO.regValue("blocks", "Kommastellen", 3);
                objRegIO.regValue("blocks", "Basislayer", "Punkte-P");
            }

            public static void unregister()
            {
                //Pfad für {Autocad\Applications\NAME} bestimmen
                string sNameKey = Autodesk.AutoCAD.DatabaseServices.HostApplicationServices.Current.UserRegistryProductRootKey + "\\Applications\\" + sNameDll;

                //Schlüssel "App" löschen
                Registry.CurrentUser.DeleteSubKey(sNameKey);
            }
        }

        public class regIO
        {
            private string m_sProductKey;
            public static string sNameDll = string.Empty;
            public string m_sNameDllKey;

            //Konstruktor
            public regIO()
            {
                //Name von dll bestimmen
                sNameDll = System.Reflection.Assembly.GetExecutingAssembly().GetName().ToString();
                sNameDll = sNameDll.Substring(0, sNameDll.IndexOf(','));
                
                //Pfad für {Autocad} bestimmen
                m_sProductKey = Autodesk.AutoCAD.DatabaseServices.HostApplicationServices.Current.UserRegistryProductRootKey + "\\Applications";
                m_sNameDllKey = m_sProductKey + "\\" + sNameDll;
            }

            //Methoden
            //CheckBox registrieren
            public void regChkBox(string Funktion, string chkBox, bool bChecked)
            {
                string sFunktionKey = m_sNameDllKey + "\\" + Funktion;

                // Gehezu HKEY_CURRENT_USER\{Autocad}\Applications\RuMa2011
                RegistryKey keySub = Registry.CurrentUser.OpenSubKey(sFunktionKey, true);

                // Unterschlüssel hinzufügen
                keySub.SetValue(chkBox, bChecked.ToString());
            }

            //CheckBox Wert aus Registry auslesen
            public bool readChkBox(string Funktion, string chkBox)
            {
                bool bChecked = false;

                string sFunktionKey = m_sNameDllKey + "\\" + Funktion;

                try
                {
                    // Gehezu HKEY_CURRENT_USER\{Autocad}\Applications
                    RegistryKey keySub = Registry.CurrentUser.OpenSubKey(sFunktionKey, true);

                    string sCheck = (string)keySub.GetValue(chkBox);
                    bChecked = bool.Parse(sCheck);
                }

                catch
                {
                    // Schlüssel "Name".dll hinzufügen
                    RegistryKey keySub = Registry.CurrentUser.CreateSubKey(sFunktionKey);

                    keySub.SetValue(chkBox, false.ToString());
                }

                return bChecked;
            }

            /// <summary>
            /// beliebigen Wert in Registry ab
            /// </summary>
            /// <param name="Funktion"></param>
            /// <param name="Name"></param>
            /// <param name="Wert"></param>
            public void regValue(string Funktion, string Name, object Wert)
            {
                string sFunktionKey = m_sNameDllKey + "\\" + Funktion;

                // Gehezu HKEY_CURRENT_USER\{Autocad}\Applications\CAS2016
                RegistryKey keySub = Registry.CurrentUser.OpenSubKey(sFunktionKey, true);

                if (keySub == null)
                    keySub = Registry.CurrentUser.CreateSubKey(sFunktionKey);

                // Unterschlüssel hinzufügen
                keySub.SetValue(Name, Wert);
            }

            /// <summary>
            /// beliebigen Wert aus Registry lesen
            /// </summary>
            /// <param name="Funktion"></param>
            /// <param name="Name"></param>
            /// <returns></returns>
            public object readValue(string Funktion, string Name)
            {
                object Wert = null;

                string sFunktionKey = m_sNameDllKey + "\\" + Funktion;

                try
                {
                    // Gehezu HKEY_CURRENT_USER\{Autocad}\Applications
                    RegistryKey keySub = Registry.CurrentUser.OpenSubKey(sFunktionKey, true);

                    if (keySub != null)
                        Wert = keySub.GetValue(Name);
                   
                    else
                    {
                        // Schlüssel "Name".dll hinzufügen
                        keySub = Registry.CurrentUser.CreateSubKey(sFunktionKey);

                        keySub.SetValue(Name, "");
                    }
                }

                catch { }
  
                return Wert;
            }
        }
}