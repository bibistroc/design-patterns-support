using System.Collections;
using System.Collections.Generic;

namespace IteratorPattern
{
    public class DaysOfWeekIterator : IEnumerable<string>
    {
        private readonly string[] days = new string[7] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

        public IEnumerator<string> GetEnumerator()
        {
            foreach (string day in days)
            {
                yield return day;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
