using AutoMapper;
using BugBox.App.Contracts.Bugs;
using BugBox.Domain.Bugs;
using Hakka.App;

namespace BugBox.App.Bugs
{
    public class BugAppService : CrudAppServiceBase<CreateUpdateBugDto, CreateUpdateBugDto, BugDto, Bug>, 
        IBugAppService
    {
        public  BugAppService(IBugRepository bugRepository, IMapper mapper) :
            base(bugRepository, mapper)
        {
        }

    }
}
