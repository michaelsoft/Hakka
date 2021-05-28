using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugBox.Domain.Shared.Bugs
{
    public enum BugStatus
    {
        Undefined = 0,
        New,
        Confirmed,
        Fixed,
        Verified,
        Closed
    }
}
