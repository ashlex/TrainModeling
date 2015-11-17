using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoNotRun
{
	static class Program
	{

		[STAThread]
		static void Main()
		{
//			WinAPI api=new WinAPI();
//			api.LockKB();
//			Thread.Sleep(30000);
//			uint WM_QUIT = 0x0012;
//			uint WM_CLOSE = 0x0010;
			Random rnd = new Random();
			int y = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
			int x = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
			while (true)
			{
//				try
//				{
//					IntPtr hwnd = WinAPI.FindWindow(null, "Диспетчер задач");
//					Console.WriteLine(hwnd);
//					if (hwnd.ToInt32() != 0)
//					{
//						WinAPI.PostMessage(hwnd, WM_CLOSE,  0, 0);
//					}else
//					{
//						hwnd = WinAPI.FindWindow(null, "Calculator");
//						Console.WriteLine(hwnd);
//						if (hwnd.ToInt32() != 0)
//						{
//							WinAPI.PostMessage(hwnd, WM_CLOSE, 0, 0);
//						}
//                    }
//				}
//				catch (Exception e)
//				{
//					Console.WriteLine(e);
//				}

//				Thread.Sleep(100);
				Cursor.Position = new System.Drawing.Point(rnd.Next(0, x), rnd.Next(0, y));
			}
		}
	}
}
