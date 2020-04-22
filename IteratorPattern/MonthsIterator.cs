using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorPattern
{
    public class MonthsIterator : IEnumerable<KeyValuePair<string, int>>
    {
        private readonly Dictionary<string, int> months = new Dictionary<string, int>() {
            {"January", 31 },
            {"February", 28 },
            {"March", 31 },
            {"April", 30 },
            {"May", 31 },
            {"June", 30 },
            {"July", 31 },
            {"August", 31 },
            {"September", 30 },
            {"October", 31 },
            {"November", 30 },
            {"December", 31 }
        };

        public IEnumerator<KeyValuePair<string, int>> GetEnumerator()
        {
            foreach (KeyValuePair<string, int> monthName in months)
            {
                yield return monthName;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<KeyValuePair<string, int>> MonthsWith30Days
        {
            get
            {
                IEnumerable<KeyValuePair<string, int>> monthsWith30Days = months.Where(m => m.Value == 30);

                foreach (KeyValuePair<string, int> month in monthsWith30Days)
                {
                    yield return month;
                }
            }
        }

        public IEnumerable<KeyValuePair<string, int>> MonthsWith31Days
        {
            get
            {
                {
                    IEnumerable<KeyValuePair<string, int>> monthsWith31Days = months.Where(m => m.Value == 31);

                    foreach (KeyValuePair<string, int> month in monthsWith31Days)
                    {
                        yield return month;
                    }
                }
            }
        }
    }
}
