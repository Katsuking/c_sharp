using System;
using System.Linq;
using System.Collections.Generic;
using TCPData;
using TCPExtensions;

List<Employee> employeeList = Data.GetEmployees();
List<Department> departmentList = Data.GetDepartments();

// lambda expressionを使ってかける
// 自作の extension methodを用いた場合は, Extension.csで定義しているような
var filteredEmployees = employeeList.Filter(emp => emp.IsManager == true);

foreach (var e in filteredEmployees)
{
    Console.WriteLine($"First Name: {e.FirstName}");
    Console.WriteLine($"IsManager: {e.IsManager}");
}

// linq を使えば、わざわざ関数書かなくてもよしなにやってくれる
// 自作したFilterに置き換える
var linq_FilteredEmployees = employeeList.Where(e => e.AnnualSalary > 5000);

foreach (var e in linq_FilteredEmployees)
{
    Console.WriteLine($"First Name: {e.FirstName}");
    Console.WriteLine($"Salary: {e.AnnualSalary}");
}

// SQL like な書き方もできる
var resultList = from emp in employeeList
                 join dept in departmentList
                 on emp.DepartmentId equals dept.Id
                 select new
                 {
                     FirstName = emp.FirstName,
                     LastName = emp.LastName,
                     AnnualSalary = emp.AnnualSalary,
                     Manager = emp.IsManager,
                     Department = dept.LongName,
                 };

foreach (var e in resultList)
{
    Console.WriteLine($"First Name: {e.FirstName}");
    Console.WriteLine($"Department Name: {e.Department}");
}

var averageSalary = resultList.Max(a => a.AnnualSalary);
Console.WriteLine($"Average Salary: ${averageSalary}");