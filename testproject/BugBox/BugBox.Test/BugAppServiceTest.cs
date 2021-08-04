using BugBox.Domain.Bugs;
using BugBox.Repository.EF;
using BugBox.Repository.EF.Bugs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using BugBox.App.Bugs;
using BugBox.App.Contracts.Bugs;

namespace BugBox.Test
{
    public class BugAppServiceTest
    {
        private BugBoxDbContext db;
        private Repository.EF.Bugs.BugRepository bugRepository;
        private BugAppService bugAppService;

        private ServiceProvider ServiceProvider
        {
            get;
            set;
        }

        public BugAppServiceTest()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = configBuilder.Build();

            var connStr = config.GetConnectionString("Default");

            var services = new ServiceCollection();
            services.AddDbContext<BugBoxDbContext>(opts => { 
                opts.UseSqlServer(connStr);
            });

            this.ServiceProvider = services.BuildServiceProvider();
            db = ServiceProvider.GetService<BugBoxDbContext>();
            //db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            bugRepository = new BugRepository(db);
            bugAppService = new BugAppService(bugRepository, null);
        }

        [Fact]
        public async Task Crud_Normal()
        {
            //Create
            var createBugDto = new CreateUpdateBugDto()
            {
                Title = "Bug 1",
            };

            var bugDto = await bugAppService.CreateAsync(createBugDto);
            var newId = bugDto.Id;
            Assert.Equal(createBugDto.Title, bugDto.Title);

            //Get
            bugDto = await bugAppService.GetByIdAsync(newId);
            Assert.Equal(createBugDto.Title, bugDto.Title);

            //Udpate
            var updateBugDto = new CreateUpdateBugDto()
            {
                Title = "Bug 1-1",
            };

            bugDto = await bugAppService.UpdateAsync(newId, updateBugDto);
            Assert.Equal(updateBugDto.Title, bugDto.Title);

            //Create More
            createBugDto = new CreateUpdateBugDto()
            {
                Title = "Bug 2",
            };
            bugDto = await bugAppService.CreateAsync(createBugDto);

            createBugDto = new CreateUpdateBugDto()
            {
                Title = "Bug 3",
            };
            bugDto = await bugAppService.CreateAsync(createBugDto);

            //Get List
            var bugDtoes = await bugAppService.GetListAsync();
            Assert.Equal(3, bugDtoes.Count);

            //Get
            await bugAppService.DeleteByIdAsync(newId);
            Assert.Equal(3, bugDtoes.Count);

        }

    }
}
