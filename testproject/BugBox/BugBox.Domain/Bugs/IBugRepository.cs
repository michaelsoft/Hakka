using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hakka.Domain.Repositories;

namespace BugBox.Domain.Bugs
{
    public interface IBugRepository : IRepository<Bug>
    {
    }
}
