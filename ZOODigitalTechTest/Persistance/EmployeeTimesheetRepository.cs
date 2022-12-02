using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZOODigitalTechTest.Entities;
using ZOODigitalTechTest.Extensions;
using ZOODigitalTechTest.Services;

namespace ZOODigitalTechTest.Persistance
{
    public static class EmployeeTimesheetRepository
    {
        public static IEnumerable<EmployeeTimesheet> GetAllEmployeeTimesheets()
        {
            var timesheets = TimesheetCSVReader.GenerateEmployeeTimesheets("C:\\JoesDocs\\Work Stuff\\Projects\\ZOOTechTest\\timesheet.csv").ToList();

            var sortedTimesheets = SortTimesheetsByName(timesheets);

            return sortedTimesheets;
        }

        public static IEnumerable<EmployeeTimesheet> GetEmployeesLessThanForty()
        {
            var timesheets = TimesheetCSVReader.GenerateEmployeeTimesheets("C:\\JoesDocs\\Work Stuff\\Projects\\ZOOTechTest\\timesheet.csv").ToList();

            var sortedTimesheets = SortTimesheetsByName(timesheets);

            return sortedTimesheets.Where(x => x.GetTotalHours() < 40);
        }

        public static IEnumerable<EmployeeTimesheet> GetEmployeesWhoWorkedWeekends()
        {
            var timesheets = TimesheetCSVReader.GenerateEmployeeTimesheets("C:\\JoesDocs\\Work Stuff\\Projects\\ZOOTechTest\\timesheet.csv").ToList();

            var sortedTimesheets = SortTimesheetsByName(timesheets);

            return sortedTimesheets.Where(x => x.GetWeekendHours() > 0);
        }

        public static IEnumerable<EmployeeTimesheet> GetEmployeesWhoWorkedOvertime()
        {
            var timesheets = TimesheetCSVReader.GenerateEmployeeTimesheets("C:\\JoesDocs\\Work Stuff\\Projects\\ZOOTechTest\\timesheet.csv").ToList();

            var sortedTimesheets = SortTimesheetsByName(timesheets);

            return sortedTimesheets.Where(x => x.GetOvertimeHours() > 0 || x.GetDoubleTimeHours() > 0);
        }

        private static List<EmployeeTimesheet> SortTimesheetsByName(List<EmployeeTimesheet> timesheets)
        {
            return timesheets.OrderBy(x => x.Surname).ThenBy(x => x.FirstName).ToList();
        }
    }
}
