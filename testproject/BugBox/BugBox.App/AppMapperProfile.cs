using AutoMapper;
using BugBox.App.Contracts.Bugs;
using BugBox.Domain.Bugs;

namespace BugBox.App
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<BugDto, Bug>();
            CreateMap<Bug, BugDto>();
            CreateMap<CreateUpdateBugDto, Bug>();
            CreateMap<Bug, CreateUpdateBugDto>();
        }
    }
}
