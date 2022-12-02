// See https://aka.ms/new-console-template for more information
using ZOODigitalTechTest.Extensions;
using ZOODigitalTechTest.Persistance;
using ZOODigitalTechTest.Services;

Console.WriteLine("Welcome");
Console.WriteLine("==========");
Console.WriteLine("List of all employees and the total paid hours: ");

foreach (var employee in EmployeeTimesheetRepository.GetAllEmployeeTimesheets())
{
    Console.WriteLine($"{employee.FirstName} {employee.Surname} worked {employee.GetTotalHours()} hours");
}
Console.WriteLine("==========");
Console.WriteLine("List of all employees who didn't work 40 hrs and their hours worked");

foreach (var employee in EmployeeTimesheetRepository.GetEmployeesLessThanForty())
{
    Console.WriteLine($"{employee.FirstName} {employee.Surname} worked {employee.GetTotalHours()} hours");
}
Console.WriteLine("==========");
Console.WriteLine("List of all employees who worked weekends and their weekend hours worked");

foreach (var employee in EmployeeTimesheetRepository.GetEmployeesWhoWorkedWeekends())
{
    Console.WriteLine($"{employee.FirstName} {employee.Surname} worked {employee.GetWeekendHours()} hours at the weekend");
}
Console.WriteLine("==========");
Console.WriteLine("List of all employees who worked overtime and their overtime and doubletime hours");

foreach (var employee in EmployeeTimesheetRepository.GetEmployeesWhoWorkedOvertime())
{
    Console.WriteLine($"{employee.FirstName} {employee.Surname} worked {employee.GetRegularHours()} regular hours, {employee.GetOvertimeHours()} overtime hours, {employee.GetDoubleTimeHours()} double time hours");
}
