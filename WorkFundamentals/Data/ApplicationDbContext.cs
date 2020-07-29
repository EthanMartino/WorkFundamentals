using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkFundamentals.Models;

namespace WorkFundamentals.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<WorkTask> WorkTasks { get; set; }
        public DbSet<WorkTaskCategory> WorkTaskCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorkTask>() //Dependent entity
                        .HasOne<Employee>() //Parent Entity
                        .WithMany()
                        .HasForeignKey(wt => wt.EmployeeId);

            modelBuilder.Entity<Schedule>() //Dependent entity
                        .HasOne<Employee>() //Parent Entity
                        .WithMany()
                        .HasForeignKey(sc => sc.EmployeeId);

            modelBuilder.Entity<WorkTaskCategory>() //Dependent entity
                        .HasOne<WorkTask>() //Parent Entity
                        .WithMany()
                        .HasForeignKey(wtc => wtc.WorkTaskId);

            modelBuilder.Entity<Schedule>() //Dependent entity
                        .HasOne<WorkTask>() //Parent Entity
                        .WithMany()
                        .HasForeignKey(sc => sc.WorkTaskId);
        }
    }
}
