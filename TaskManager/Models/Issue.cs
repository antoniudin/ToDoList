using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class Issue
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Display(Name="Description")]
        public string Body { get; set; }
        
        [Required]
        [Display(Name ="Creation Date")]
        public DateTime CreationDate { get; set; }
        
        [Required]
        [Display(Name = "Deadline")]
        public DateTime DueDate { get; set; }

        public string CreationUser { get; set; }

        public bool IsDone { get; set; }
        
        [Display(Name = "Type")]
        public int IssueTypeId { get; set; }
        
        public IssueType IssueType { get; set; }
        
        [Display(Name = "Status")]
        public int IssueStatusId { get; set; }

        public IssueStatus IssueStatus { get; set; }
    }
}
