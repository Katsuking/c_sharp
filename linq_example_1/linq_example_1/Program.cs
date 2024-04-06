using System;
using System.Collections.Generic;
using System.Linq;

List<Employee> employeesList = Data.GetEmployees();
List<Department> departmentList = Data.GetDepartments();

// method chaining, method syntax
Console.WriteLine("\nmethod syntax を使って書いてみる (可読性が悪い気がする)");
var result = employeesList.Select(e => new
{
    FullName = e.FirstName + " " + e.LastName,
    AnnualSalary = e.AnnualSalary,
}).Where(e => e.AnnualSalary >= 5000); // フィルターをかける
foreach (var e in result)
{
    Console.WriteLine($"Full Name: {e.FullName}");
    Console.WriteLine($"Salary: {e.AnnualSalary, 10}");
}

// query syntax
Console.WriteLine("\nquery syntax を使って書いてみる (こっちの方がSQLっぽくてわかりやすい)");
var qreusult = from emp in employeesList
               where emp.AnnualSalary >= 5000
               select new
               {
                   FullName = emp.FirstName + " " + emp.LastName,
                   AnnualSalary = emp.AnnualSalary,
               };

foreach (var e in qreusult)
{
    Console.WriteLine($"Full Name: {e.FullName}");
    Console.WriteLine($"Salary: {e.AnnualSalary,10}");
}

// lazy evaluation (deferred excution) を確認してみる
Console.WriteLine("\nlazy excution を確認してみる");
var lazy_result = from emp in employeesList.GetHighSalariedEmployees()
                  select new
                  {
                      FullName = emp.FirstName + " " + emp.LastName,
                      AnnualSalary = emp.AnnualSalary,
                  };

// query syntax の後に書いたこれもきちんと実行される
employeesList.Add(new Employee
{
    Id = 5,
    FirstName = "sinner",
    LastName = "allmight",
    AnnualSalary = 5300.20m,
    IsManager = false,
    DepartmentId = 2,
});

foreach (var e in lazy_result)
{
    Console.WriteLine($"Full Name: {e.FullName}");
    Console.WriteLine($"Salary: {e.AnnualSalary,10}");
}

// Immediate Excution example
Console.WriteLine("\nImmediate excution を確認してみる");
var immediate_result = (from emp in employeesList.GetHighSalariedEmployees()
                  select new
                  {
                      FullName = emp.FirstName + " " + emp.LastName,
                      AnnualSalary = emp.AnnualSalary,
                  }).ToList();

employeesList.Add(new Employee
{
    Id = 6,
    FirstName = "Forgotten",
    LastName = "City",
    AnnualSalary = 10300.20m,
    IsManager = false,
    DepartmentId = 2,
});

foreach (var e in lazy_result)
{
    Console.WriteLine($"Full Name: {e.FullName}");
}

// check Lazy Evaluation (deferred)
public static class EnumerableCollectionExtensionMethods
{
    public static IEnumerable<Employee> GetHighSalariedEmployees(this IEnumerable<Employee> employees)
    {
        foreach (var e in employees)
        {
            Console.WriteLine($"Accessing employee: {e.FirstName + " " + e.LastName}");
            if (e.AnnualSalary >= 5000)
            {
                yield return e;
            }

        }
    }
}


// 以下はdata
public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal AnnualSalary { get; set; }
    public bool IsManager { get; set; }
    public int DepartmentId { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string ShortName { get; set; }

    public string LongName { get; set; }
}

public static class Data
{
    public static List<Employee> GetEmployees()
    {
        List<Employee> employees = new List<Employee>();

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
            Id = 2,
            FirstName = "Test2",
            LastName = "Keith",
            AnnualSalary = 6000.3m,
            IsManager = true,
            DepartmentId = 2,
        };
        employees.Add(employee);

        employee = new Employee
        {
            Id = 3,
            FirstName = "John",
            LastName = "Wick",
            AnnualSalary = 100000.3m,
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