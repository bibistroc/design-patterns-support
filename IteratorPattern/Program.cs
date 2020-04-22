using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            DaysOfWeekIterator daysOfWeek = new DaysOfWeekIterator();

            Console.WriteLine("All days");
            Console.WriteLine($"-----------------------------------------------------------------------{Environment.NewLine}");
            foreach (string day in daysOfWeek)
            {
                Console.WriteLine($"Day of week: {day}");
            }

            Console.WriteLine($"-----------------------------------------------------------------------{Environment.NewLine}");

            MonthsIterator months = new MonthsIterator();

            Console.WriteLine("All months");
            Console.WriteLine($"-----------------------------------------------------------------------{Environment.NewLine}");
            foreach (KeyValuePair<string, int> month in months)
            {
                Console.WriteLine($"Month: {month.Key} has {month.Value} days");
            }
            Console.WriteLine($"-----------------------------------------------------------------------{Environment.NewLine}");

            Console.WriteLine("Months that have 31 days");
            Console.WriteLine($"-----------------------------------------------------------------------{Environment.NewLine}");
            foreach (KeyValuePair<string, int> month in months.MonthsWith31Days)
            {
                Console.WriteLine($"Month: {month.Key} has {month.Value} days");
            }
            Console.WriteLine($"-----------------------------------------------------------------------{Environment.NewLine}");

            Console.WriteLine("Months that have 30 days");
            Console.WriteLine($"-----------------------------------------------------------------------{Environment.NewLine}");
            
            IEnumerable<KeyValuePair<string, int>> monthsWith30Days = months.Where(m => m.Value == 30);

            foreach (KeyValuePair<string, int> month in monthsWith30Days)
            {
                Console.WriteLine($"Month: {month.Key} has {month.Value} days");
            }
            Console.WriteLine($"-----------------------------------------------------------------------{Environment.NewLine}");

        }
    }
}
