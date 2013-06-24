﻿using System.Windows.Forms;

namespace ArdupilotMega.Katana
{
    public class AuxToolStripControl : ToolStripControlHost
    {
        // Call the base constructor passing in a MonthCalendar instance.     
        public AuxToolStripControl()
            : base(new AuxConnectionControl())
        {
        }

        public AuxConnectionControl AuxConnectionControl
        {
            get { return Control as AuxConnectionControl; }
        }
    }
}
