using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOODigitalTechTest.Entities
{
    public class EmployeeTimesheet
    {
        public EmployeeTimesheet(string fullName, IEnumerable<DailyHours> dailyHours)
        {
            FullName = fullName;
            DailyHours = dailyHours;
        }
        public string FullName { get; private set; } = "N/A";
        public string FirstName => FullName.Split(" ")[0];
        public string Surname => FullName.Split(" ")[1];
        private IEnumerable<DailyHours> _dailyHours;
        public IEnumerable<DailyHours> DailyHours
        {
            get => _dailyHours;
            private set
            {
                _dailyHours = value;
                if (value.Count() >= 7) value.Last().AwardSeventhDay();
            }
        }
    }
}
