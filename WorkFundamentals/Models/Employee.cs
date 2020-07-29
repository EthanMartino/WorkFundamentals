using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFundamentals.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string JobTitle { get; set; }

        public Schedule CurrentSchedule { get; set; }

        public List<WorkTask> CurrentTasks { get; set; }

        public List<WorkTask> CompletedTasks { get; set; }
    }
}
