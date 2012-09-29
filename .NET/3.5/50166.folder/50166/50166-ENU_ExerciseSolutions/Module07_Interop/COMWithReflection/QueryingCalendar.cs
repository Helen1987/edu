using System;
using System.Reflection;

namespace COMWithReflection
{
    class QueryingCalendar
    {
        static void Main(string[] args)
        {
            Type calendarType = Type.GetTypeFromProgID("MSCAL.Calendar.7");
            object calendar = Activator.CreateInstance(calendarType);

            short year = (short)calendarType.InvokeMember("Year", BindingFlags.GetProperty, null, calendar, null);
            short month = (short)calendarType.InvokeMember("Month", BindingFlags.GetProperty, null, calendar, null);
            short day = (short)calendarType.InvokeMember("Day", BindingFlags.GetProperty, null, calendar, null);

            Console.WriteLine("{0}/{1}/{2}", day, month, year);
        }
    }
}
