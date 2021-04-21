using MBGE.LoggingSystem;
using System;
using System.Globalization;

namespace MBGE.Locale
{
    class CommonStrings
	{
		public static string Locale_PressEnter;
		public static void InitStrings()
		{
			if (CultureInfo.CurrentCulture.Name.Equals("en-US"))
			{
				Locale_PressEnter = "[" + DateTime.UtcNow.ToString() + "] " + "[Kernel thread/" + LogStatus.Msg + "]: " + "Press Enter!";
			}
			else if (CultureInfo.CurrentCulture.Name.Equals("ru-RU"))
			{
				Locale_PressEnter = "[" + DateTime.UtcNow.ToString() + "] " + "[Kernel thread/" + LogStatus.Msg + "]: " + "Нажмите клавишу Enter!";
			}
			else
            {
				Locale_PressEnter = "[" + DateTime.UtcNow.ToString() + "] " + "[Kernel thread/" + LogStatus.Msg + "]: " + "PLACEHOLDER_NO_LANG";
			}
		}
	}
}
