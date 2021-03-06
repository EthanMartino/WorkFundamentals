﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFundamentals.Models
{
    /// <summary>
    /// Represents a single Employee's Schedule for one week.
    /// </summary>
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }

        /// <summary>
        /// Foreign Key for Employee
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Foreign Key for WorkTask
        /// </summary>
        public int? WorkTaskId { get; set; }

        /// <summary>
        /// Indicates whether the Schedule is for the current week or not.
        /// </summary>
        public Boolean IsCurrent { get; set; }

        [Display(Name = "Starting Date")]
        public DateTime StartingDate { get; set; }

        [NotMapped]
        public Dictionary<Day, DateTime> DailySchedule { get; set; }

        [Display(Name = "Daily Schedule")]
        public string DailyScheduleAsJSON
        {
            get
            {
                return JsonConvert.SerializeObject(DailySchedule, Formatting.Indented);
            }
            set 
            {
                JsonConvert.DeserializeObject<Dictionary<Day, DateTime>>(value);
            }
        }


        public Schedule()
        {
            DailySchedule = new Dictionary<Day, DateTime>()
            {
                { Day.Monday, new DateTime() },
                { Day.Tuesday, new DateTime() },
                { Day.Wednesday, new DateTime() },
                { Day.Thursday, new DateTime() },
                { Day.Firday, new DateTime() },
                { Day.Saturday, new DateTime() },
                { Day.Sunday, new DateTime() }
            };
        }
    }

    public enum Day
    {
        Monday, Tuesday, Wednesday, Thursday, Firday, Saturday, Sunday
    }
}
