using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CAS2018.myAutoCAD;
using Autodesk.AutoCAD.EditorInput;

namespace CAS2018.myFunctions
{
    class AttSwitch
    {
        private myAutoCAD.Blöcke m_Blöcke = myAutoCAD.Blöcke.Instance;

        //Methoden
        public void run(string Switch)
        {
            m_Blöcke.init();
            m_Blöcke.selectWindow();
            m_Blöcke.attSwitch(Switch);
        }
    }
}
