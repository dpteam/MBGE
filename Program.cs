using System;
using System.Threading;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace MBGE
{
	class Program
	{
		static void Main(string[] args)
		{
			Marshal.PrelinkAll(typeof(Program));
			__MBGE_LogInit();
			Trace.WriteLine("[" + DateTime.UtcNow.ToString() + "] " + "Ok!");
			__MBGE_PressEnter();
		}

		private static void __MBGE_LogInit()
		{
			Trace.AutoFlush = true;
			Trace.Listeners.Clear();
			Trace.Listeners.Add(new ConsoleTraceListener());
			Trace.Listeners.Add(new TextWriterTraceListener("MBGE.log"));
		}

		private static void __MBGE_PressEnter()
		{
			Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
			Trace.WriteLine(Properties.locale.PressEnter);
			do
			{
				while (!Console.KeyAvailable) { }
			} while (Console.ReadKey(true).Key != ConsoleKey.Enter);
		}
	}
}
