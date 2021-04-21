using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using MBGE.Locale;
using MBGE.LoggingSystem;
using System.IO;
using MBGE.ModuleSystem;

namespace MBGE
{
	class Program
	{
		public static string version = "0.1.2"; // Increment only if implementing new necessary feature.
		public static string milestone = "0lpha";
		public static void Main(string[] args)
		{
			Marshal.PrelinkAll(typeof(Program));
			try
			{
				CommonStrings.InitStrings();
				MBGE_LogInit();
				Trace.WriteLine("[" + DateTime.UtcNow.ToString() + "] " + "[Kernel/" + LogStatus.Info + "]: " + "Kernel loading complete!");
				ModuleSystem.TXTReader.ScanTXTs();
			}
			catch
			{
				Trace.WriteLine("[" + DateTime.UtcNow.ToString() + "] " + "[Kernel/" + LogStatus.Fatal + "]: " + "Unknown error!");
				// Needs here a error handler...
			}
			MBGE_PressEnter();
		}

		public static void MBGE_LogInit()
		{
			Trace.AutoFlush = true;
			Trace.Listeners.Clear();
			Trace.Listeners.Add(new ConsoleTraceListener());
			Trace.Listeners.Add(new TextWriterTraceListener("MBGE.log"));
		}

		public static void MBGE_PressEnter()
		{
			Trace.WriteLine(CommonStrings.Locale_PressEnter);
			do
			{
				while (!Console.KeyAvailable) { }
			} while (Console.ReadKey(true).Key != ConsoleKey.Enter);
		}
	}
}
