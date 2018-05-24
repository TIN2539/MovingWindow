using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MovingWindow
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[DllImport("user32")]
		private static extern void SetProcessDPIAware();

		internal static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());
		}
	}
}