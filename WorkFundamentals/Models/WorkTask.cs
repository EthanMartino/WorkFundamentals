using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFundamentals.Models
{
    public class WorkTask
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Employee Employee { get; set; }

        public Schedule Schedule { get; set; }

        public WorkTaskCategory Category { get; set; }
    }

    public class WorkTaskCategory
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
