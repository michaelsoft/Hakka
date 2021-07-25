using System;
using System.Threading.Tasks;
using BugBox.App.Contracts.Bugs;
using BugBox.Domain.Bugs;
using Hakka.Domain.Repositories;

namespace BugBox.App.Bugs
{
    public class BugAppService
    {
        private IBugRepository bugRepository;

        public  BugAppService(IBugRepository bugRepository)
        {
            this.bugRepository = bugRepository;
        }

        public async Task<BugDto> CreateAsync(CreateBugDto input)
        {
            //await this.bugRepository.InsertAsync(bug);

            //return ObjectMapper.Map<Bug, BugDto>(bug);
            return null;
        }

    }
}
