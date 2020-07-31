using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFundamentals.Models
{
    /// <summary>
    /// An authorized manager with Schedule and Task manipulation authorization
    /// </summary>
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }

        public string Name { get; set; }

        public string JobTitle { get; set; }
    }
}
