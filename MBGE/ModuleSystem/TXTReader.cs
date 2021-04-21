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
		public static void ReadTXT(string textFile)
		{
            _ = System.IO.File.ReadAllText(@textFile);
        }

		public static List<string> ScanTXTs(string start_path)
		{
			List<string> ls = new();
			try
			{
				string[] folders = Directory.GetDirectories(start_path);
				foreach (string folder in folders)
				{
					ls.Add("Папка: " + folder);
					ls.AddRange(ScanTXTs(folder));
				}
				string[] files = Directory.GetFiles(start_path);
                foreach (string filename in files)
                {
                    ls.Add("Файл: " + filename);
                }
				foreach (string fname in ls)
				{
					Trace.WriteLine("[" + DateTime.UtcNow.ToString() + "] " + "[Kernel thread/" + LogStatus.Info + "]: " + fname);
				}
			}
			catch (System.Exception e)
			{
				Trace.WriteLine("[" + DateTime.UtcNow.ToString() + "] " + "[Kernel thread/" + LogStatus.Error + "]: " + e.Message);
			}
			return ls;
		}

		static readonly string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        readonly List<string> ls = ScanTXTs(assemblyPath + "\\Modules");
	}
}
