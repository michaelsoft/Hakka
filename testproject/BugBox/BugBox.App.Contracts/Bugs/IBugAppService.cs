using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BugBox.App.Contracts.Bugs
{
    public interface IBugAppService
    {
        Task<BugDto> CreateAsync(CreateUpdateBugDto input);

        Task<BugDto> UpdateAsync(int id, CreateUpdateBugDto input);

        Task DeleteByIdAsync(int id);

        Task<BugDto> GetByIdAsync(int id);

        Task<List<BugDto>> GetListAsync();
    }
}
