using AutoMapper;
using BugBox.App.Contracts.Bugs;
using BugBox.MvcWeb.Models.Bugs;

namespace BugBox.MvcWeb
{
    public class MvcWebMapperProfile : Profile
    {
        public MvcWebMapperProfile()
        {
            CreateMap<BugDto, BugViewModel>();
            CreateMap<BugViewModel, BugDto>();
            CreateMap<CreateUpdateBugDto, CreateUpdateBugViewModel>();
            CreateMap<CreateUpdateBugViewModel, CreateUpdateBugDto>();
        }
    }
}
