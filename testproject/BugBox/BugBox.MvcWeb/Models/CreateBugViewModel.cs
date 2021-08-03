﻿using BugBox.Domain.Shared.Bugs;
using System.ComponentModel.DataAnnotations;

namespace MvcWebTest.Models
{
    public class CreateBugViewModel
    {
        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        public string Description { get; set; }

        public BugPriority Priority { get; set; }

        public BugSeverity Severity { get; set; }

        public BugStatus Status { get; set; }
    }
}
