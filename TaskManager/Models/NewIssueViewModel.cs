using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class NewIssueViewModel
    {
        public Issue Issue { get; set; }
        public IEnumerable<Issue> Issues { get; set; }
        public IssueType IssueType { get; set; }
        public IEnumerable<IssueType> IssueTypes { get; set; }
        public IssueStatus IssueStatus { get; set; }
        public IEnumerable<IssueStatus> IssueStatuses { get; set; }
        public string PageTitle { get; set; }

        public string User { get; set; }
        public string UserId { get; set; }
    }
}
