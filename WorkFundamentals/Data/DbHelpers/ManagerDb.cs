using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFundamentals.Models;

namespace WorkFundamentals.Data.DbHelpers
{
    public class ManagerDb
    {
        public async Task<List<Manager>> GetAllEmployees(ApplicationDbContext context)
        {
            List<Manager> managers = await context.Managers
                .OrderBy(m => m.Name)
                .ToListAsync();

            return managers;
        }

        public async Task<Manager> GetEmployeeById(int id, ApplicationDbContext context)
        {
            Manager managers = await context.Managers
                .Where(m => m.ManagerId == id)
                .SingleOrDefaultAsync();

            return managers;
        }

        public async void Add(Manager manager, ApplicationDbContext context)
        {
            await context.Managers.AddAsync(manager);
            await context.SaveChangesAsync();
        }

        public async Task<Manager> Update(Manager manager, ApplicationDbContext context)
        {
            context.Managers.Attach(manager);
            context.Entry(manager).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return manager;
        }

        public async void Delete(Manager manager, ApplicationDbContext context)
        {
            context.Managers.Attach(manager);
            context.Entry(manager).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }
}
