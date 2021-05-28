using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugBox.Domain.Bugs
{
    public interface IBugRepository
    {
        public Task<Bug> InsertAsync(Bug bug);

        public Task<Bug> UpdateAsync(Bug bug);

        public Task DeleteAsync(Bug bug);

        public Task<Bug> GetAsync(int id);

        public Task<List<Bug>> GetListAsync();
    }
}
