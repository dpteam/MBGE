using MBGE.LoggingSystem;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace MBGE.ModuleSystem
{
	class TXTReader
	{
		public static string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		public static void ReadTXT(string textFile)
		{
			_ = System.IO.File.ReadAllText(@textFile);
		}

		public static void ScanTXTs()
		{
			string[] textFiles;
			if (!Directory.Exists(@".\Modules"))
			{
			}
            else
            {
				Directory.CreateDirectory(@".\Modules");
				Trace.WriteLine("[" + DateTime.UtcNow.ToString() + "] " + "[TXTReader/" + LogStatus.Debug + "]: " + "Modules folder not found and writed");
			}
				if (File.Exists(@".\Modules\KernelModule.txt"))
				{
					Trace.WriteLine("[" + DateTime.UtcNow.ToString() + "] " + "[TXTReader/" + LogStatus.Debug + "]: " + "#1 if is passed");
					string txtKernel = File.ReadAllText(@"\Modules\KernelModule.txt");
					Trace.WriteLine("[" + DateTime.UtcNow.ToString() + "] " + "[TXTReader/" + LogStatus.Debug + "]: " + "All text readed from File");
					if (new FileInfo(@".\Modules\KernelModule.txt").Length != 0 && txtKernel == "Installed 1," + Program.version + "," + Program.milestone)
					{
						Trace.WriteLine("[" + DateTime.UtcNow.ToString() + "] " + "[TXTReader/" + LogStatus.Debug + "]: " + "#2 if is passed");
						textFiles = Directory.GetFiles(assemblyPath + "\\Modules\\", "*.txt", SearchOption.AllDirectories);
						Trace.WriteLine("[" + DateTime.UtcNow.ToString() + "] " + "[TXTReader/" + LogStatus.Debug + "]: " + "Listed all files");
						foreach (string listFiles in textFiles)
						{
							Trace.WriteLine(listFiles);
						}
					}
					else
					{
						string txtKernelString = "Installed 1," + Program.version + "," + Program.milestone;
						File.WriteAllText(@".\Modules\KernelModule.txt", txtKernelString);
						Trace.WriteLine("[" + DateTime.UtcNow.ToString() + "] " + "[TXTReader/" + LogStatus.Debug + "]: " + "KernelModule.txt not found and writed");
					}
			}
		}
	}
}
