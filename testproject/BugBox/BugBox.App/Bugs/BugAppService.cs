using System;
using System.Threading.Tasks;
using BugBox.App.Contracts.Bugs;
using BugBox.Domain.Bugs;
using Hakka.Domain.Repositories;
using AutoMapper;
using Hakka.App;
using System.Collections.Generic;

namespace BugBox.App.Bugs
{
    public class BugAppService : CrudAppServiceBase<CreateBugDto, UpdateBugDto, BugDto, Bug>, 
        IBugAppService
    {
        public  BugAppService(IBugRepository bugRepository) :
            base(bugRepository)
        {
        }

    }
}
