using System.Globalization;
using ZOODigitalTechTest.Enums;

namespace ZOODigitalTechTest.Entities
{
    public class DailyHours
    {
        public DailyHours(int day, double totalHours) { 
            DayOfWeek = (DaysOfWeek)day;
            TotalHours = totalHours;
            SplitTotalHours(totalHours);
        }

        public DaysOfWeek DayOfWeek { get; set; }
        public double TotalHours { get; set; }
        public double OvertimeHours { get; set; }
        public double DoubleTimeHours { get; set; }
        public double RegularHours { get; set; }

        public void AwardSeventhDay()
        {
            DoubleTimeHours = OvertimeHours;
            OvertimeHours = RegularHours;
            RegularHours = 0;
        }

        private void SplitTotalHours(double hoursWorked)
        {
            CalculateDoubleTime(ref hoursWorked);
            CalculateOvertime(ref hoursWorked);
            CalculateRegularHours(ref hoursWorked);
        }

        private void CalculateDoubleTime(ref double hoursLeftOver)
        {
            if(hoursLeftOver > 12)
            {
                DoubleTimeHours = hoursLeftOver - 12;

                hoursLeftOver -= DoubleTimeHours;
            }
        }

        private void CalculateOvertime(ref double hoursLeftOver)
        {
            if(hoursLeftOver > 8) 
            { 
                OvertimeHours = hoursLeftOver - 8;

                hoursLeftOver -= OvertimeHours;
            }
        }

        private void CalculateRegularHours(ref double hoursLeftOver)
        {
            RegularHours = hoursLeftOver;
        }
    }
}
