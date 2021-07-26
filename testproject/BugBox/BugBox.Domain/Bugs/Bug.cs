using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugBox.Domain.Shared.Bugs;
using BugBox.Domain.Users;
using Hakka.Domain.Entities;

namespace BugBox.Domain.Bugs
{
    public class Bug : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public BugPriority Priority { get; set; }

        public BugSeverity Severity { get; set; }

        public BugStatus Status { get; set; }

        //public AppUser AssignedTo { get; set; }

        //public AppUser CreatedBy { get; set; }

        //public DateTimeOffset CreatedOn { get; set; }

        //public AppUser LastModifiedBy { get; set; }

        //public DateTimeOffset LastModifiedOn { get; set; }

    }
}
