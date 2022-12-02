using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOODigitalTechTest.Extensions
{
    public static class StringExtensions
    {
        public static double WrittenTimeSpanToTotalHours(this string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return 0;
            var times = data.Split("-");
            var startTime = TimeOnly.ParseExact(times[0], "HH:mm", CultureInfo.InvariantCulture);
            var endTime = TimeOnly.ParseExact(times[1], "HH:mm", CultureInfo.InvariantCulture);

            return (endTime - startTime).TotalHours - 1;
        }
    }
}
