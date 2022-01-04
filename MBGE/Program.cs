using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using MBGE.Locale;
using MBGE.LoggingSystem;
using MBGE.ModuleSystem;
using MBGE.Config;

namespace MBGE
{
	public static class Program
	{
		public static bool debugEnabled = true;
		public static bool debugThrow;

		public static string version = "0.1.3"; // Increment only if implementing new necessary feature.
		public static string milestone = "0lpha";
		public static void Main()
		{
			Marshal.PrelinkAll(typeof(Program));
			try
			{
				CommonStrings.InitStrings();
				MBGE_LogInit();
				Trace.WriteLine("[" + DateTime.UtcNow.ToString() + "] " + "[Kernel/" + LogStatus.Info + "]: " + "Kernel loading complete!");
				if (debugThrow == true)
				{
					throw new Exception();
				}
				MBGE_PressEnter();
			}
			catch (Exception ex)
			{
				Trace.WriteLine("[" + DateTime.UtcNow.ToString() + "] " + "[Kernel/" + LogStatus.Fatal + "]: " + $"{ex.Message}");
				Process.Start(new ProcessStartInfo("https://stackoverflow.com/search?q=" + $"{ex.Message}") { UseShellExecute = true });
				throw;
			}
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
