﻿using System;
using Eto.Forms;

namespace XamlMultiLanguageEditor.EtoForms.Mac
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Eto.Platforms.Mac64).Run(new MainForm());
        }
    }
}
