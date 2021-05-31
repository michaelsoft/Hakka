using System;
using System.Threading.Tasks;
using Xunit;
using BugBox.Domain.Bugs;
using BugBox.Repository.EF.Bugs;
using BugBox.Repository.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BugBox.Test
{
    public class BugBoxRepositoryTest
    {
        private BugBoxDbContext db;
        private Repository.EF.Bugs.BugRepository bugRepository;

        private ServiceProvider ServiceProvider
        {
            get;
            set;
        }

        public BugBoxRepositoryTest()
        {
            var services = new ServiceCollection();
            services.AddDbContext<BugBoxDbContext>(opts => { 
                opts.UseSqlServer();
            });

            this.ServiceProvider = services.BuildServiceProvider();
            db = ServiceProvider.GetService<BugBoxDbContext>();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            bugRepository = new BugRepository(db);
        }

        [Fact]
        public async Task CRUD_Normal()
        {
            var bug = new Bug()
            {
                Title = "Bug 1",
            };

            var insertedBug = await bugRepository.InsertAsync(bug);
            var newId = insertedBug.Id;
            Assert.Equal(1, newId);

            var retrievedBug = await bugRepository.GetByIdAsync(newId);
            Assert.NotNull(retrievedBug);

            retrievedBug.Title = "Bug 2";
            await bugRepository.UpdateAsync(retrievedBug);

            var retrievedBug2 = await bugRepository.GetByIdAsync(newId);
            Assert.NotNull(retrievedBug2);

            Assert.Equal("Bug 2", retrievedBug2.Title);

            await bugRepository.DeleteAsync(retrievedBug2);

            var retrievedBug3 = await bugRepository.GetByIdAsync(newId);
            Assert.Null(retrievedBug3);
        }

    }
}
