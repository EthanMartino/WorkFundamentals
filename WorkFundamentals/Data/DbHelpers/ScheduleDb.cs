using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFundamentals.Models;

namespace WorkFundamentals.Data.DbHelpers
{
    public class ScheduleDb
    {
        public async Task<List<Schedule>> GetAllSchedules(ApplicationDbContext context)
        {
            List<Schedule> schedules = await context.Schedules
                .OrderByDescending(s => s.StartingDate)
                .ToListAsync();

            return schedules;
        }

        public async Task<Schedule> GetScheduleById(int id, ApplicationDbContext context)
        {
            Schedule schedules = await context.Schedules
                .Where(s => s.ScheduleId == id)
                .SingleOrDefaultAsync();

            return schedules;
        }

        public async void Add(Schedule schedule, ApplicationDbContext context)
        {
            await context.Schedules.AddAsync(schedule);
            await context.SaveChangesAsync();
        }

        public async Task<Schedule> Update(Schedule schedule, ApplicationDbContext context)
        {
            context.Schedules.Attach(schedule);
            context.Entry(schedule).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return schedule;
        }

        public async void Delete(Schedule schedule, ApplicationDbContext context)
        {
            context.Schedules.Attach(schedule);
            context.Entry(schedule).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }
}
