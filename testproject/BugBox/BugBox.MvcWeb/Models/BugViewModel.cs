using System;
using System.ComponentModel.DataAnnotations;
using BugBox.Domain.Shared.Bugs;

namespace MvcWebTest.Models
{
    public class BugViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public BugPriority Priority { get; set; }

        public BugSeverity Severity { get; set; }

        public BugStatus Status { get; set; }
    }

}
