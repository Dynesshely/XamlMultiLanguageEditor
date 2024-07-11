using System;
using Eto.Forms;

namespace XamlMultiLanguageEditor.EtoForms.Wpf
{
	class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			new Application(Eto.Platforms.Wpf).Run(new MainForm());
		}
	}
}
