using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Ribbon;
using Autodesk.Windows;


namespace CAS2018
{
    public class CAS2018 : IExtensionApplication
    {
        private Autodesk.AutoCAD.EditorInput.Editor m_editor =
            Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;

        void IExtensionApplication.Initialize()
        {
            Autodesk.Windows.ComponentManager.ApplicationMenu.Opening +=
                new EventHandler<EventArgs>(ApplicationMenu_Opening);

            Application.Idle += new EventHandler(Application_OnIdle);

            //adding Events
            Application.DocumentManager.DocumentActivated += new DocumentCollectionEventHandler(docColDocAct);
        }

        void IExtensionApplication.Terminate()
        {
            // Assuming these events have fired, they have already been removed
            Autodesk.Windows.ComponentManager.ApplicationMenu.Opening -= new EventHandler<EventArgs>(ApplicationMenu_Opening);
            Application.Idle -= new EventHandler(Application_OnIdle);

            //Application.DocumentManager.DocumentActivated -= new DocumentCollectionEventHandler(docColDocAct);
        }

        //Events
        void Application_OnIdle(object sender, EventArgs e)
        {
            // Remove the event when it is fired
            Application.Idle -= new EventHandler(Application_OnIdle);

            // Add our Quick Access Toolbar item
            addRessourceTab();

            //prüfen, ob App registriert ist
            myRegistry.regIO objRegIO = new myRegistry.regIO();
            string Basislayer;
            if ((Basislayer = (string)objRegIO.readValue("blocks", "Basislayer")) == null)
                myRegistry.regApp.register();

            //Basislayer prüfen bzw. erzeugen
            myAutoCAD.myLayer objLayer = myAutoCAD.myLayer.Instance;
            objLayer.checkLayer(Basislayer, true);
        }
        
        //Zeichnung aktiviert
        public void docColDocAct(object senderObj, DocumentCollectionEventArgs docColDocAcrEvtArgs)
        {
            myRegistry.regIO objRegIO = new myRegistry.regIO();
            string Basislayer = (string) objRegIO.readValue("blocks", "Basislayer");

            myAutoCAD.myLayer objLayer = myAutoCAD.myLayer.Instance;
            objLayer.refresh();    
        }

        //remove Events
        void ApplicationMenu_Opening(object sender, EventArgs e)
        {
            // Remove the event when it is fired
            Autodesk.Windows.ComponentManager.ApplicationMenu.Opening -=
              new EventHandler<EventArgs>(ApplicationMenu_Opening);
        }

        //Ribbon hinzufügen
        public void addRessourceTab()
        {
            RibbonSeparator separator = new RibbonSeparator();
            separator.SeparatorStyle = RibbonSeparatorStyle.Spacer;

             //**************
            //PanelSource IO
            RibbonPanelSource panelSrcIO = new RibbonPanelSource();
            panelSrcIO.Title = "Punkte Import/Export";

                //Pt Import
                RibbonButton bt_PtImport = new RibbonButton();
                bt_PtImport.Id = "PtImport";
                bt_PtImport.Text = "Punkte importieren";
                bt_PtImport.Image = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.IN_small);
                bt_PtImport.LargeImage = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.IN_small);
                bt_PtImport.Orientation = System.Windows.Controls.Orientation.Horizontal;
                bt_PtImport.Size = RibbonItemSize.Standard;
                bt_PtImport.ShowText = false;
                bt_PtImport.ShowImage = true;
                bt_PtImport.CommandHandler = new RibbonCommandHandler();
                bt_PtImport.ShowToolTipOnDisabled = true;
                bt_PtImport.Description = "Punkte importieren";

                //Import 3d?
                RibbonCheckBox ribchkBoxImport3d = new RibbonCheckBox();
                ribchkBoxImport3d.Id = "PtImport3d";
                ribchkBoxImport3d.Text = "3d";
                ribchkBoxImport3d.Initialized += new EventHandler(ribchkBoxImport3d_Initialized);
                ribchkBoxImport3d.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ribchkBoxImport3d_PropertyChanged);
                ribchkBoxImport3d.CommandHandler = new RibbonCommandHandler();

                //Pt Export
                RibbonButton bt_PtExport = new RibbonButton();
                bt_PtExport.Id = "PtExport";
                bt_PtExport.Text = "Punkte exportieren";
                bt_PtExport.Image = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.Out_small);
                bt_PtExport.LargeImage = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.Out);
                bt_PtExport.Orientation = System.Windows.Controls.Orientation.Horizontal;
                bt_PtExport.Size = RibbonItemSize.Standard;
                bt_PtExport.ShowText = false;
                bt_PtExport.ShowImage = true;
                bt_PtExport.CommandHandler = new RibbonCommandHandler();
                bt_PtExport.ShowToolTipOnDisabled = true;
                bt_PtExport.Description = "Punkte exportieren";

                //ComboBox für aktuellen Punktlayer
                RibbonCombo ribCB_Basislayer = new RibbonCombo();
                ribCB_Basislayer.Text = "Basislayer:";
                ribCB_Basislayer.ShowText = true;
                ribCB_Basislayer.MinWidth = 100;
                ribCB_Basislayer.DropDownWidth = 150;
                ribCB_Basislayer.Initialized+= new EventHandler(ribCB_Basislayer_Initialized);
                ribCB_Basislayer.CurrentChanged += new EventHandler<RibbonPropertyChangedEventArgs>(ribCB_Basislayer_CurrentChanged);
                ribCB_Basislayer.DropDownOpened += new EventHandler<EventArgs>(ribCB_Basislayer_DropDownOpened);

                RibbonRowPanel rowPanel_IO = new RibbonRowPanel();
                rowPanel_IO.Items.Add(bt_PtImport);
                rowPanel_IO.Items.Add(ribchkBoxImport3d);
                rowPanel_IO.Items.Add(new RibbonRowBreak());
                rowPanel_IO.Items.Add(bt_PtExport);
                rowPanel_IO.Items.Add(separator);
                rowPanel_IO.Items.Add(ribCB_Basislayer);
                panelSrcIO.Items.Add(rowPanel_IO);
                

            //**************
            //PanelSource Tools
            Autodesk.Windows.RibbonPanelSource panelSrcTools = new Autodesk.Windows.RibbonPanelSource();
            panelSrcTools.Title = "Tools";

                //Punkte einfügen
                Autodesk.Windows.RibbonButton bt_PtIns = new Autodesk.Windows.RibbonButton();
                bt_PtIns.Id = "PtIns";
                bt_PtIns.Text = "Punkte einfügen";
                bt_PtIns.Image = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.BlockManipulation);
                bt_PtIns.LargeImage = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.BlockManipulation);
                bt_PtIns.Orientation = System.Windows.Controls.Orientation.Horizontal;
                bt_PtIns.Size = Autodesk.Windows.RibbonItemSize.Standard;
                bt_PtIns.ShowText = false;
                bt_PtIns.ShowImage = true;
                bt_PtIns.CommandHandler = new RibbonCommandHandler();
                bt_PtIns.ShowToolTipOnDisabled = true;
                bt_PtIns.Description = "Punkte einfügen";

                //Blockattribute Pre-/Suffix
                Autodesk.Windows.RibbonButton bt_attPreSuf = new Autodesk.Windows.RibbonButton();
                bt_attPreSuf.Id = "BlockManipulator";
                bt_attPreSuf.Text = "Block Operationen";
                bt_attPreSuf.Image = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.BlockManipulation);
                bt_attPreSuf.LargeImage = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.BlockManipulation);
                bt_attPreSuf.Orientation = System.Windows.Controls.Orientation.Horizontal;
                bt_attPreSuf.Size = Autodesk.Windows.RibbonItemSize.Standard;
                bt_attPreSuf.ShowText = false;
                bt_attPreSuf.ShowImage = true;
                bt_attPreSuf.CommandHandler = new RibbonCommandHandler();
                bt_attPreSuf.ShowToolTipOnDisabled = true;
                bt_attPreSuf.Description = "Blöcke manipulieren";

                //Layer exportieren
                Autodesk.Windows.RibbonButton bt_layExport = new Autodesk.Windows.RibbonButton();
                bt_layExport.Id = "layExport";
                bt_layExport.Text = "Layer exportieren";
                bt_layExport.Image = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.LayerEport);
                bt_layExport.LargeImage = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.LayerEport);
                bt_layExport.Orientation = System.Windows.Controls.Orientation.Horizontal;
                bt_layExport.Size = Autodesk.Windows.RibbonItemSize.Large;
                bt_layExport.ShowText = false;
                bt_layExport.ShowImage = true;
                bt_layExport.CommandHandler = new RibbonCommandHandler();
                bt_layExport.ShowToolTipOnDisabled = true;
                bt_layExport.Description = "Layer exportieren";

                //Objekte auf 3d heben
                Autodesk.Windows.RibbonButton bt_Obj3d = new Autodesk.Windows.RibbonButton();
                bt_layExport.Id = "Obj3d";
                bt_layExport.Text = "Objekte auf 3d heben";
                bt_layExport.Image = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.ObjTo3d);
                bt_layExport.LargeImage = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.ObjTo3d);
                bt_layExport.Orientation = System.Windows.Controls.Orientation.Horizontal;
                bt_layExport.Size = Autodesk.Windows.RibbonItemSize.Standard;
                bt_layExport.ShowText = false;
                bt_layExport.ShowImage = true;
                bt_layExport.CommandHandler = new RibbonCommandHandler();
                bt_layExport.ShowToolTipOnDisabled = true;
                bt_layExport.Description = "Objekte auf 3d heben";

            panelSrcTools.Items.Add(bt_PtIns);
            panelSrcTools.Items.Add(bt_attPreSuf);
            panelSrcTools.Items.Add(bt_layExport);
            panelSrcTools.Items.Add(new RibbonRowBreak());
            panelSrcTools.Items.Add(bt_Obj3d);

            //**************
            //PanelSource Attribute
            Autodesk.Windows.RibbonPanelSource panelSrcAtt = new Autodesk.Windows.RibbonPanelSource();
            panelSrcAtt.Title = "Blockattribute";

            Autodesk.Windows.RibbonSubPanelSource panelSubSrcAtt = new Autodesk.Windows.RibbonSubPanelSource();

            //Att Pon
            Autodesk.Windows.RibbonButton bt_AttPon = new Autodesk.Windows.RibbonButton();
                bt_AttPon.Id = "AttPon";
                bt_AttPon.Image = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.AttPon);
                bt_AttPon.LargeImage = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.AttPon);
                bt_AttPon.Orientation = System.Windows.Controls.Orientation.Vertical;
                bt_AttPon.Size = Autodesk.Windows.RibbonItemSize.Standard;
                bt_AttPon.ShowText = false;
                bt_AttPon.ShowImage = true;
                bt_AttPon.CommandHandler = new RibbonCommandHandler();
                bt_AttPon.ShowToolTipOnDisabled = true;
                bt_AttPon.Description = "PNr einschalten";

                //Att Poff
                Autodesk.Windows.RibbonButton bt_AttPoff = new Autodesk.Windows.RibbonButton();
                bt_AttPoff.Id = "AttPoff";
                bt_AttPoff.Image = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.AttPoff_small);
                bt_AttPoff.LargeImage = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.AttPoff);
                bt_AttPoff.Orientation = System.Windows.Controls.Orientation.Horizontal;
                bt_AttPoff.Size = Autodesk.Windows.RibbonItemSize.Standard;
                bt_AttPoff.ShowText = false;
                bt_AttPoff.ShowImage = true;
                bt_AttPoff.CommandHandler = new RibbonCommandHandler();
                bt_AttPoff.ShowToolTipOnDisabled = true;
                bt_AttPoff.Description = "PNr ausschalten";

                //Att Hon
                Autodesk.Windows.RibbonButton bt_AttHon = new Autodesk.Windows.RibbonButton();
                bt_AttHon.Id = "AttHon";
                bt_AttHon.Image = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.AttHon_small);
                bt_AttHon.LargeImage = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.AttHon_small1);
                bt_AttHon.Orientation = System.Windows.Controls.Orientation.Horizontal;
                bt_AttHon.Size = Autodesk.Windows.RibbonItemSize.Standard;
                bt_AttHon.ShowText = false;
                bt_AttHon.ShowImage = true;
                bt_AttHon.CommandHandler = new RibbonCommandHandler();
                bt_AttHon.ShowToolTipOnDisabled = true;
                bt_AttHon.Description = "Höhe einschalten";
            
                //Att Hoff
                Autodesk.Windows.RibbonButton bt_AttHoff = new Autodesk.Windows.RibbonButton();
                bt_AttHoff.Id = "AttHoff";
                bt_AttHoff.Image = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.AttHoff);
                bt_AttHoff.LargeImage = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.AttHoff);
                bt_AttHoff.Orientation = System.Windows.Controls.Orientation.Horizontal;
                bt_AttHoff.Size = Autodesk.Windows.RibbonItemSize.Standard;
                bt_AttHoff.ShowText = false;
                bt_AttHoff.ShowImage = true;
                bt_AttHoff.CommandHandler = new RibbonCommandHandler();
                bt_AttHoff.ShowToolTipOnDisabled = true;
                bt_AttHoff.Description = "Höhe ausschalten";

                Autodesk.Windows.RibbonRowPanel rowPanel_Att = new Autodesk.Windows.RibbonRowPanel();
                rowPanel_Att.Items.Add(bt_AttPon);
                rowPanel_Att.Items.Add(bt_AttPoff);
                rowPanel_Att.Items.Add(new RibbonRowBreak());
                rowPanel_Att.Items.Add(bt_AttHon);
                rowPanel_Att.Items.Add(bt_AttHoff);

                panelSrcAtt.Items.Add(rowPanel_Att);

            //**************
            //PanelSource Zeichnen
            Autodesk.Windows.RibbonPanelSource panelSrcZeichnen = new Autodesk.Windows.RibbonPanelSource();
            panelSrcZeichnen.Title = "Zeichnen";
            //Settings
            Autodesk.Windows.RibbonButton bt_Block3P = new Autodesk.Windows.RibbonButton();
            bt_Block3P.Id = "Block3P";
            bt_Block3P.Text = "Einstellungen";
            bt_Block3P.Image = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.Block3P);
            bt_Block3P.LargeImage = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.Block3P);
            bt_Block3P.Orientation = System.Windows.Controls.Orientation.Horizontal;
            bt_Block3P.Size = Autodesk.Windows.RibbonItemSize.Standard;
            bt_Block3P.ShowText = false;
            bt_Block3P.ShowImage = true;
            bt_Block3P.CommandHandler = new RibbonCommandHandler();
            bt_Block3P.ShowToolTipOnDisabled = true;
            bt_Block3P.Description = "Block mit 3 Punkten einfügen";

            panelSrcZeichnen.Items.Add(bt_Block3P);

            //**************
            //PanelSource Settings
            Autodesk.Windows.RibbonPanelSource panelSrcSettings = new Autodesk.Windows.RibbonPanelSource();
            panelSrcSettings.Title = "Settings";
                //Settings
                Autodesk.Windows.RibbonButton bt_Settings = new Autodesk.Windows.RibbonButton();
                bt_Settings.Id = "Settings";
                bt_Settings.Text = "Einstellungen";
                bt_Settings.Image = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.settings_16x16);
                bt_Settings.LargeImage = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.Settings);
                bt_Settings.Orientation = System.Windows.Controls.Orientation.Horizontal;
                bt_Settings.Size = Autodesk.Windows.RibbonItemSize.Large;
                bt_Settings.ShowText = false;
                bt_Settings.ShowImage = true;
                bt_Settings.CommandHandler = new RibbonCommandHandler();
                bt_Settings.ShowToolTipOnDisabled = true;
                bt_Settings.Description = "Einstellungen ";

                panelSrcSettings.Items.Add(bt_Settings);

            //**************
            //PanelSource Help
            Autodesk.Windows.RibbonPanelSource panelSrcHelp = new Autodesk.Windows.RibbonPanelSource();
            panelSrcHelp.Title = "Hilfe";

                //AboutBox
                Autodesk.Windows.RibbonButton bt_About = new Autodesk.Windows.RibbonButton();
                bt_About.Id = "AboutBox";
                bt_About.Text = "Info zu CAS2018";
                bt_About.Image = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.helpdoc);
                bt_About.LargeImage = myUtilities.Media.Images.ToImageSource(global::CAS2018.Resources.helpdoc);
                bt_About.Orientation = System.Windows.Controls.Orientation.Horizontal;
                bt_About.Size = Autodesk.Windows.RibbonItemSize.Large;
                bt_About.ShowText = false;
                bt_About.ShowImage = true;
                bt_About.CommandHandler = new RibbonCommandHandler();
                bt_About.ShowToolTipOnDisabled = true;
                bt_About.Description = "Info über CAS2018";

            panelSrcHelp.Items.Add(bt_About);

            // Row Panel
            Autodesk.Windows.RibbonRowPanel rowPanel1 = new Autodesk.Windows.RibbonRowPanel();
            rowPanel1.Items.Add(bt_About);
            rowPanel1.Items.Add(bt_attPreSuf);

            //rowPanel.Items.Add( panelSubSrcAtt);
            rowPanel1.Items.Add(bt_Settings);
            rowPanel1.ResizeStyle = Autodesk.Windows.RibbonItemResizeStyles.ChangeSize;
            rowPanel1.Size = Autodesk.Windows.RibbonItemSize.Standard;

            // Create a panel for holding the panel
            // source content
            Autodesk.Windows.RibbonPanel panelCAS = new Autodesk.Windows.RibbonPanel();

            panelCAS.Source = panelSrcIO;
            Autodesk.Windows.RibbonControl control = panelCAS.RibbonControl;

            //Tabs
            Autodesk.Windows.RibbonPanel panel_IO = new Autodesk.Windows.RibbonPanel();
            
            panel_IO.Source = panelSrcIO;

            Autodesk.Windows.RibbonPanel panel_Tools = new Autodesk.Windows.RibbonPanel();
            panel_Tools.Source = panelSrcTools;

            Autodesk.Windows.RibbonPanel panel_Att = new Autodesk.Windows.RibbonPanel();
            panel_Att.Source = panelSrcAtt;

            Autodesk.Windows.RibbonPanel panel_Zeichnen = new RibbonPanel();
            panel_Zeichnen.Source = panelSrcZeichnen;

            Autodesk.Windows.RibbonPanel panel_Settings = new Autodesk.Windows.RibbonPanel();
            panel_Settings.Source = panelSrcSettings;

            Autodesk.Windows.RibbonPanel panel_Help = new Autodesk.Windows.RibbonPanel();
            panel_Help.Source = panelSrcHelp;

            Autodesk.Windows.RibbonTab tabCAS2018 = new Autodesk.Windows.RibbonTab();
            tabCAS2018.Title = "CAS2018";
            tabCAS2018.Id = "CAS2018";
            tabCAS2018.IsContextualTab = false;

            tabCAS2018.Panels.Add(panel_IO);
            tabCAS2018.Panels.Add(panel_Tools);
            tabCAS2018.Panels.Add(panel_Att);
            tabCAS2018.Panels.Add(panel_Zeichnen);
            tabCAS2018.Panels.Add(panel_Settings);
            tabCAS2018.Panels.Add(panel_Help);

            // Now add the tab to AutoCAD Ribbon bar...
            try
            {
                Autodesk.Windows.RibbonControl ribbonControl = RibbonServices.RibbonPaletteSet.RibbonControl;
                Autodesk.Windows.RibbonTab ribTab = new Autodesk.Windows.RibbonTab();
                ribbonControl.Tabs.Add(tabCAS2018);
            }
            catch { }
        }

        /// <summary>
        /// Befehl für Ribbon Button
        /// </summary>
        public class RibbonCommandHandler : System.Windows.Input.ICommand
        {
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                if (parameter.ToString() == "Autodesk.Windows.RibbonButton")
                {
                    Autodesk.Windows.RibbonButton bt = (Autodesk.Windows.RibbonButton)parameter;
                    myFunctions.AttSwitch objAttSwitch = new myFunctions.AttSwitch();
                    myAutoCAD.Zeichnen objZeichnen = new myAutoCAD.Zeichnen();

                    switch (bt.Id)
                    {
                        case "PtImport":
                            myFunctions.PtImport objPtImport = new myFunctions.PtImport();
                            objPtImport.run();

                            break;

                        case "PtExport":
                            myFunctions.PtExport objPtExport = new myFunctions.PtExport();
                            objPtExport.run();
                            break;

                        case "PtIns":
                            objZeichnen.PTIns();

                            break;

                        case "BlockManipulator":
                            myFunctions.BlockManipulator objBlockManipulator = new myFunctions.BlockManipulator();
                            objBlockManipulator.ShowDialog();

                            break;

                        case "layExport":
                            myAutoCAD.myLayer objLayer = myAutoCAD.myLayer.Instance;
                            objLayer.export();

                            break;

                        case "Obj3d":
                            myFunctions.Obj3d obj3d = new myFunctions.Obj3d();
                            obj3d.run();

                            break;

                        case "AttPon":
                            objAttSwitch.run("AttPon");
                            break;

                        case "AttPoff":
                            objAttSwitch.run("AttPoff");
                            break;

                        case "AttHon":
                            objAttSwitch.run("AttHon");
                            break;

                        case "AttHoff":
                            objAttSwitch.run("AttHoff");
                            break;

                        case "Block3P":
                            objZeichnen.Block3P();
                            break;

                        case "Settings":
                            myFunctions.Settings objSettings = new myFunctions.Settings();
                            objSettings.ShowDialog();
                            break;

                        case "AboutBox":
                            myFunctions.AboutBox objAboutBox = new myFunctions.AboutBox();
                            objAboutBox.ShowDialog();
                            break;
                    }
                }
            }
        }

        public void ribchkBoxImport3d_Initialized(object sender, EventArgs e)
        {
            myRegistry.regIO objRegistry = new myRegistry.regIO();

            bool b3d = Convert.ToBoolean(objRegistry.readValue("blocks", "insert3d"));
            Autodesk.Windows.RibbonCheckBox ribchkBoxImport3d = (Autodesk.Windows.RibbonCheckBox)sender;
            ribchkBoxImport3d.IsChecked = b3d;
        }

        public void ribchkBoxImport3d_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            myRegistry.regIO objRegistry = new myRegistry.regIO();
            bool b3d = ((Autodesk.Windows.RibbonCheckBox)sender).IsChecked.Value;
            
            if (e.PropertyName == "IsChecked")
                objRegistry.regValue("blocks", "insert3d", b3d);
        }

        public void ribCB_Basislayer_Initialized(object sender, EventArgs e)
        {
            RibbonCombo ribCombo = (RibbonCombo)sender;
            myRegistry.regIO objRegistry = new myRegistry.regIO();
            string Basislayer = (string)objRegistry.readValue("blocks", "Basislayer");

            //Basislayer
            myAutoCAD.myLayer objLayer = myAutoCAD.myLayer.Instance;
            objLayer.refresh();
            objLayer.checkLayer(Basislayer, true);

            foreach (LayerTableRecord ltr in objLayer.lsLayerTableRecord)
            {
                string layName = ltr.Name;
                if (layName.Length > 2)
                {
                    if (layName.Substring(layName.Length - 2, 2) == "-P")
                    {
                        RibbonLabel ribLabel = new RibbonLabel();
                        ribLabel.Text = layName;
                        ribCombo.Items.Add(ribLabel);

                        if (ribLabel.Text == Basislayer)
                            ribCombo.Current = ribLabel;
                    }    
                }
            }
        }

        void ribCB_Basislayer_CurrentChanged(object sender, RibbonPropertyChangedEventArgs e)
        {
            RibbonCombo ribCombo = (RibbonCombo)sender;
            myRegistry.regIO objRegIO = new myRegistry.regIO();
            objRegIO.regValue("blocks", "Basislayer", ((RibbonLabel)ribCombo.Current).Text);
        }

        void ribCB_Basislayer_DropDownOpened(object sender, EventArgs e)
        {
            RibbonCombo ribCombo = (RibbonCombo)sender;
            myAutoCAD.myLayer objLayer = myAutoCAD.myLayer.Instance;
            objLayer.refresh();
            List<string> lsPunktlayer = new List<string>();

            foreach (LayerTableRecord ltr in objLayer.lsLayerTableRecord)
            {
                string layName = ltr.Name;
                if (layName.Length > 2)
                {
                    if (layName.Substring(layName.Length - 2, 2) == "-P")
                        lsPunktlayer.Add(layName);
                }

                
            }
        }

        public static class Images
        {
            public static System.Windows.Media.Imaging.BitmapImage getBitmap(System.Drawing.Bitmap image)
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                System.Windows.Media.Imaging.BitmapImage bmp = new System.Windows.Media.Imaging.BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = stream;
                bmp.EndInit();

                return bmp;
            }
        }

        // Befehle für AutoCad registrieren
        public class Commands
        {
            public Commands()
            { }

            // CAS2018 registrieren
            [CommandMethod("CAS-Reg")]
            static public void CASreg()
            { myRegistry.regApp.register(); }

            //Ribbons wiederherstellen
            [CommandMethod("CAS-Ribbons")]
            static public void CASRibbons()
            {
                CAS2018 objCAS2018 = new CAS2018();
                objCAS2018.addRessourceTab();
            }
        }
    }
}