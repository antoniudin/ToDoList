using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TaskManager.Models
{
    public class ApplicationViewModel
    {
        public Issue Issue { get; set; }
        public List<Issue> Issues { get; set; }
        public IssueType IssueType { get; set; }
        public List<IssueType> IssueTypes { get; set; }
        public IssueStatus IssueStatus { get; set; }
        public List<IssueStatus> IssueStatuses { get; set; }

        public IdentityUser CurrentUser { get; set; }
    }
}
