using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFundamentals.Models
{
    /// <summary>
    /// Represents a single Task to be completed by a certain Employee
    /// </summary>
    public class WorkTask
    {
        [Key]
        public int WorkTaskId { get; set; }

        /// <summary>
        /// Foreign Key for Employee
        /// </summary>
        [Required]
        public int EmployeeId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Boolean IsComplete { get; set; }
    }

    /// <summary>
    /// Represents a Category for WorkTasks
    /// </summary>
    public class WorkTaskCategory
    {
        [Key]
        public int WorkTaskCategoryId { get; set; }

        /// <summary>
        /// Foreign Key for WorkTask
        /// </summary>
        public int WorkTaskId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
