using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFundamentals.Models;

namespace WorkFundamentals.Data
{
    public class EmployeeDb
    {
        public async Task<List<Employee>> GetAllEmployees(ApplicationDbContext context)
        {
            List<Employee> employees =  await context.Employees
                .OrderBy(e => e.Name)
                .ToListAsync();

            return employees;
        }

        public async Task<Employee> GetEmployeeById(int id, ApplicationDbContext context)
        {
            Employee employee = await context.Employees
                .Where(e => e.EmployeeId == id)
                .SingleOrDefaultAsync();

            return employee;
        }

        public async void Add(Employee employee, ApplicationDbContext context)
        {
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
        }

        public async Task<Employee> Update(Employee employee, ApplicationDbContext context)
        {
            context.Employees.Attach(employee);
            context.Entry(employee).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return employee;
        }

        public async void Delete(Employee employee, ApplicationDbContext context)
        {
            context.Employees.Attach(employee);
            context.Entry(employee).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }
}
