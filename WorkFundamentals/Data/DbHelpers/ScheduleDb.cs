using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFundamentals.Models;

namespace WorkFundamentals.Data.DbHelpers
{
    public static class ScheduleDb
    {
        public static async Task<List<Schedule>> GetAllSchedules(ApplicationDbContext context)
        {
            List<Schedule> schedules = await context.Schedules
                .OrderByDescending(s => s.StartingDate)
                .ToListAsync();

            return schedules;
        }

        public static async Task<Schedule> GetCurrentScheduleByEmployeeId(int id, ApplicationDbContext context)
        {
            Schedule schedule = await context.Schedules
                .Where(s => s.EmployeeId == id)
                .Where(s => s.IsCurrent)
                .SingleOrDefaultAsync();

            return schedule;
        }

        public static async Task<Schedule> GetScheduleByWorkTaskId(int id, ApplicationDbContext context)
        {
            Schedule schedule = await context.Schedules
                .Where(s => s.WorkTaskId == id)
                .SingleOrDefaultAsync();

            return schedule;
        }

        public static async Task<Schedule> GetScheduleById(int id, ApplicationDbContext context)
        {
            Schedule schedules = await context.Schedules
                .Where(s => s.ScheduleId == id)
                .SingleOrDefaultAsync();

            return schedules;
        }

        public static async void Add(Schedule schedule, ApplicationDbContext context)
        {
            await context.Schedules.AddAsync(schedule);
            await context.SaveChangesAsync();
        }

        public static async Task<Schedule> Update(Schedule schedule, ApplicationDbContext context)
        {
            context.Schedules.Attach(schedule);
            context.Entry(schedule).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return schedule;
        }

        public static async void Delete(Schedule schedule, ApplicationDbContext context)
        {
            context.Schedules.Attach(schedule);
            context.Entry(schedule).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }
}
