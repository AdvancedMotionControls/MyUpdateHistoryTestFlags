using System;
using System.Windows.Forms;

namespace UpdateHistoryTestFlags
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new HistoryTestFlagsFixForm());
		}
	}
}