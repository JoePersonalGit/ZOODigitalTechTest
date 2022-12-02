using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZOODigitalTechTest.Entities;
using ZOODigitalTechTest.Enums;

namespace ZOODigitalTechTest.Extensions
{
    public static class EmployeeTimesheetExtensions
    {
        public static double GetTotalHours(this EmployeeTimesheet employeeTimesheet) => employeeTimesheet.DailyHours.Sum(x => x.TotalHours);
        public static double GetWeekendHours(this EmployeeTimesheet employeeTimesheet) => employeeTimesheet.DailyHours.Where(x => x.DayOfWeek >= (DaysOfWeek)6).Sum(x => x.TotalHours);
        public static double GetRegularHours(this EmployeeTimesheet employeeTimesheet)
        {
            var regularHours = employeeTimesheet.DailyHours.Sum(x => x.RegularHours);
            if (regularHours <= 40) return regularHours;
            else return 40;
        }
        public static double GetOvertimeHours(this EmployeeTimesheet employeeTimesheet) 
        {
            var overtimeHours = employeeTimesheet.DailyHours.Sum(x => x.OvertimeHours);
            var regularHours = employeeTimesheet.DailyHours.Sum(x => x.RegularHours);

            if (regularHours > 40)
                overtimeHours += (regularHours - 40);

            return overtimeHours;
        }
        public static double GetDoubleTimeHours(this EmployeeTimesheet employeeTimesheet) => employeeTimesheet.DailyHours.Sum(x => x.DoubleTimeHours);
    }
}
