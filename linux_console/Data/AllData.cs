using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class AllData
    {
        public static List<Employee> GetEmployees()
        {
            List <Employee> employees = new List<Employee>();

            Employee employee = new Employee
            {
                Id = 1,
                FirstName = "Test1",
                LastName = "John",
                AnnualSalary = 4000.3m,
                IsManager = false,
                DepartmentId = 1,
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 1,
                FirstName = "Test2",
                LastName = "Keith",
                AnnualSalary = 6000.3m,
                IsManager = true,
                DepartmentId = 2,
            };
            employees.Add(employee);

            return employees;
        }

        public static List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            Department department = new Department
            {
                Id = 1,
                ShortName = "HR",
                LongName = "Human Resource",
            };

            departments.Add(department);

            department = new Department
            {
                Id = 2,
                ShortName = "FI",
                LongName = "Finance",
            };
            departments.Add(department);

            return departments;
        }

    }
}