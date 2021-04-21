using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using MBGE.Locale;
using MBGE.LoggingSystem;

namespace MBGE
{
	class Program
	{
		public static void Main(string[] args)
		{
			Marshal.PrelinkAll(typeof(Program));
			CommonStrings.InitStrings();
			MBGE_LogInit();
			Trace.WriteLine("[" + DateTime.UtcNow.ToString() + "] " + "[Kernel thread/" + LogStatus.Info + "]: " + "Ok!");
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
