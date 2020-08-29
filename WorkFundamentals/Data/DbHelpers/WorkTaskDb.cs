using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFundamentals.Models;

namespace WorkFundamentals.Data.DbHelpers
{
    public static class WorkTaskDb
    {
        public static async Task<List<WorkTask>> GetAllWorkTasks(ApplicationDbContext context)
        {
            List<WorkTask> workTasks = await context.WorkTasks
                .OrderBy(wt => wt.Title)
                .ToListAsync();

            return workTasks;
        }
        public static async Task<List<WorkTask>> GetAllWorkTasksByEmployeeId(int id, ApplicationDbContext context)
        {
            List<WorkTask> workTasks = await context.WorkTasks
                .Where(wt => wt.EmployeeId == id)
                .ToListAsync();

            return workTasks;
        }

        public static async Task<WorkTask> GetWorkTaskById(int id, ApplicationDbContext context)
        {
            WorkTask workTasks = await context.WorkTasks
                .Where(wt => wt.WorkTaskId == id)
                .SingleOrDefaultAsync();

            return workTasks;
        }

        public static async Task<WorkTaskCategory> GetCategoryByWorkTaskId(int id, ApplicationDbContext context)
        {
            WorkTaskCategory category = await context.WorkTaskCategories
                .Where(wtc => wtc.WorkTaskId == id)
                .SingleOrDefaultAsync();

            return category;
        }


        public static async Task Add(WorkTask workTask, ApplicationDbContext context)
        {
            await context.WorkTasks.AddAsync(workTask);
            await context.SaveChangesAsync();
        }

        public static async Task<WorkTask> Update(WorkTask workTask, ApplicationDbContext context)
        {
            context.WorkTasks.Attach(workTask);
            context.Entry(workTask).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return workTask;
        }

        public static async Task Delete(WorkTask workTask, ApplicationDbContext context)
        {
            context.WorkTasks.Attach(workTask);
            context.Entry(workTask).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }
}
