using System;
using Microsoft.EntityFrameworkCore;
using exam.Models;

namespace exam.Repository
{
    public class SeedData
    {
        public static void SeedingData(DataContext _context)
        {
            _context.Database.Migrate();

            if (!_context.Employees.Any())
            {
                DepartmentModel DesignerModel = new DepartmentModel { name = "Designer", code = "DS01", location = "Tang 2", numberOfPersonals = 10};
                DepartmentModel ItModel = new DepartmentModel { name = "It", code = "IT01", location = "Tang 1", numberOfPersonals = 5 };
             

                _context.Employees.AddRange(
                    new EmployeeModel { Name = "Nguyen Manh Hieu", Code = "1409", Departments = DesignerModel},
                    new EmployeeModel{ Name = "Nguyen Van Quy", Code = "2210", Departments = ItModel }
                );
                _context.SaveChanges();

            }
        }
    }
}

