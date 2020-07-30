using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFundamentals.Models;

namespace WorkFundamentals.Data.DbHelpers
{
    public class WorkTaskDb
    {
        public async Task<List<WorkTask>> GetAllWorkTasks(ApplicationDbContext context)
        {
            List<WorkTask> workTasks = await context.WorkTasks
                .OrderBy(wt => wt.Title)
                .ToListAsync();

            return workTasks;
        }

        public async Task<WorkTask> GetWorkTaskById(int id, ApplicationDbContext context)
        {
            WorkTask workTasks = await context.WorkTasks
                .Where(wt => wt.WorkTaskId == id)
                .SingleOrDefaultAsync();

            return workTasks;
        }

        public async void Add(WorkTask workTask, ApplicationDbContext context)
        {
            await context.WorkTasks.AddAsync(workTask);
            await context.SaveChangesAsync();
        }

        public async Task<WorkTask> Update(WorkTask workTask, ApplicationDbContext context)
        {
            context.WorkTasks.Attach(workTask);
            context.Entry(workTask).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return workTask;
        }

        public async void Delete(WorkTask workTask, ApplicationDbContext context)
        {
            context.WorkTasks.Attach(workTask);
            context.Entry(workTask).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }
}
