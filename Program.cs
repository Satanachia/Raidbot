using System;
using System.Windows.Forms;
using System.Threading;

namespace PoiBot
{
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new RaidBot());

		}

	}
}
