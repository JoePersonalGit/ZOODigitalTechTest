using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZOODigitalTechTest.Entities;
using ZOODigitalTechTest.Extensions;

namespace ZOODigitalTechTest.Services
{
    public static class TimesheetCSVReader
    {
        public static IEnumerable<EmployeeTimesheet> GenerateEmployeeTimesheets(string filePath)
        {
            List<EmployeeTimesheet> newSet = new List<EmployeeTimesheet>();
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var row = reader.ReadLine();
                    var trimmed = row.Remove(row.Length - 1, 1).Remove(0, 1);
                    var columns = trimmed.Split("\",\"");
                    
                    if (columns[0] == "Name") continue;

                    var dailyHours = CreateDailyHours(new ArraySegment<string>(columns, 1, 7));
                    var fullName = columns[0];

                    newSet.Add(new EmployeeTimesheet(fullName, dailyHours));
                }
            }

            return newSet;
        }

        private static IEnumerable<DailyHours> CreateDailyHours(ArraySegment<string> data)
        {
            var newDailyHours = new List<DailyHours>();
            for (int i = 0; i < data.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(data[i]))
                {
                    newDailyHours.Add(new DailyHours(i, data[i].WrittenTimeSpanToTotalHours()));
                }
                    
            }
            return newDailyHours;
        }
    }
}
