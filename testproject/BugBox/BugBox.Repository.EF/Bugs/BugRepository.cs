using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugBox.Domain.Bugs;
using BugBox.Repository.EF;
using BugBox.Repository;
using Hakka.Domain.Repositories;

namespace BugBox.Repository.EF.Bugs
{
    public class BugRepository : EfRepository<Bug>
    {
        public BugRepository(BugBoxDbContext db):base(db)
        {
        }

    }
}
