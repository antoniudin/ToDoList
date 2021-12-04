using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class Settings
    {
        public int StatusId { get; set; }
        
        [Required]
        public string StatusName { get; set; }
        
        public int TypeId { get; set; }
        
        [Required]
        public string TypeName { get; set; }

        public List<IssueStatus> IssueStatuses { get; set; }
        
        public List<IssueType> IssueTypes  { get; set; }
    }
}
