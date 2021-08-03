using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MvcWebTest.Models;
using BugBox.App.Contracts.Bugs;

namespace BugBox.MvcWeb.Models
{
    public class BugViewModelProfile : Profile
    {
        public BugViewModelProfile()
        {
            CreateMap<BugDto, BugViewModel>();
            CreateMap<BugViewModel, BugDto>();
            CreateMap<CreateBugDto, CreateBugViewModel>();
            CreateMap<CreateBugViewModel, CreateBugDto>();
        }
    }
}
