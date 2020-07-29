using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFundamentals.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        public Employee Employee { get; set; }

        public Boolean IsCurrent { get; set; }

        public DateTime StartingDate { get; set; }

        public Dictionary<Day, DateTime> DailySchedule { get; set; }

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
