using System;
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
			if(Directory.Exists(@"\Modules") && File.Exists(@"\Modules\KernelModule.txt"))
			{
				string txtKernel = File.ReadAllText(@"\Module\\KernelModule.txt");
                if (new FileInfo(@"\Modules\KernelModule.txt").Length != 0 && txtKernel == "Installed 1," + Program.version + "," + Program.milestone)
                {
                    textFiles = Directory.GetFiles(assemblyPath + "\\Modules\\", "*.txt", SearchOption.AllDirectories);
                    foreach (string listFiles in textFiles)
                    {
                        Console.WriteLine(listFiles);
                    }
                }
                else
                {
					string txtKernelString = "Installed 1," + Program.version + "," + Program.milestone;
					File.WriteAllText(@"\Modules\KernelModule.txt", txtKernelString);
				}
			}
			else
            {
				Directory.CreateDirectory(@"\Modules");
            }
		}
	}
}
