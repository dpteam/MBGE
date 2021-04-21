using MBGE.LoggingSystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
			string[] textFiles = Directory.GetFiles(assemblyPath + "\\Modules\\", "*.txt", SearchOption.AllDirectories);
			foreach (string listFiles in textFiles)
			{
				Console.WriteLine(listFiles);
			}
		}
	}
}
