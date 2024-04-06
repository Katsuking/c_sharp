using System;
using System.Linq;
using Data;

namespace linux_console;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        List<Employee> employeeList= AllData.GetEmployees();
        List<Department> departmentList = AllData.GetDepartments();

        foreach (Employee e in employeeList)
        {
            Console.WriteLine($"what {e.FirstName}");
        }
    }
}
