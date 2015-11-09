using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MakeReserve
{
	class Program
	{
		static void Main(string[] args)
		{

			if (args.Any() && args.Contains("-r"))
			{
				if (args.Contains("-top"))
				{
					ConsoleConfig consoleConfig=new ConsoleConfig();
					consoleConfig.setTop();
				}
				if (args.Contains("-r"))
				{
					Console.WriteLine("Path Source:" + Properties.Settings.Default.PathFrom);
					while (true)
					{
						string pathWhere = Path.Combine(Properties.Settings.Default.PathWhere,
							DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss"));

						Console.WriteLine("Path Dest:" + pathWhere);
						Console.WriteLine("Please wait...");

						DirectoryCopy(Properties.Settings.Default.PathFrom, pathWhere, true);

						Console.WriteLine("Time to sleep:" + (Properties.Settings.Default.TimeRepeat/1000) + " s");
						Console.Write("Sleep...");
						Console.WriteLine();
						Thread.Sleep(Properties.Settings.Default.TimeRepeat);
					}
				}
			}

			while (true)
			{
				string pathWhere = Path.Combine(Properties.Settings.Default.PathWhere,
				   DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss"));

				Console.WriteLine("Path Dest:" + pathWhere);
				Console.WriteLine("Please wait...");

				DirectoryCopy(Properties.Settings.Default.PathFrom, pathWhere, true);

				Thread.Sleep(1000);
				Console.Write("Click \"Enter\" to repeat.");
				Console.WriteLine();
				Console.Read();
			}
		}


		private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
		{
			// Get the subdirectories for the specified directory.
			DirectoryInfo dir = new DirectoryInfo(sourceDirName);

			if (!dir.Exists)
			{
				throw new DirectoryNotFoundException(
					"Source directory does not exist or could not be found: "
					+ sourceDirName);
			}

			DirectoryInfo[] dirs = dir.GetDirectories();
			// If the destination directory doesn't exist, create it.
			if (!Directory.Exists(destDirName))
			{
				Directory.CreateDirectory(destDirName);
			}

			// Get the files in the directory and copy them to the new location.
			FileInfo[] files = dir.GetFiles();
			foreach (FileInfo file in files)
			{
				string temppath = Path.Combine(destDirName, file.Name);
				file.CopyTo(temppath, false);
			}

			// If copying subdirectories, copy them and their contents to new location.
			if (copySubDirs)
			{
				foreach (DirectoryInfo subdir in dirs)
				{
					string temppath = Path.Combine(destDirName, subdir.Name);
					DirectoryCopy(subdir.FullName, temppath, copySubDirs);
				}
			}
		}

	}
}
