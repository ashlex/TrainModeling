using System;
using System.Windows.Forms;

namespace DoNotRun
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Random rnd = new Random();
			int y = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
			int x = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
			while (true)
			{
				Cursor.Position = new System.Drawing.Point(rnd.Next(0, x), rnd.Next(0, y));
			}
		}

		private static int Gcd(int a, int b)
		{
			if (a == 0 || b == 0) return b;
			if ((a & 1) == 0 && (b & 1) == 0) return Gcd(a >> 1, b >> 1) << 1;
			if ((a & 0x1) == 0) return Gcd(a >> 1, b);
			if ((b & 0x1) == 0) return Gcd(a, b >> 1);
			if (a >= b) return Gcd(a - b, b);
			else return Gcd(a, b - a);
		}

	}
}