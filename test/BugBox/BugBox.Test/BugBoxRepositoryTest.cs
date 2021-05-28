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
        private BugRepository bugRepository;

        private ServiceCollection Services
        {
            get;
        }

        public BugBoxRepositoryTest()
        {
            var services = new ServiceCollection();
            services.AddDbContext<BugBoxDbContext>(opts => { 
                opts.UseSqlServer();
            });

            var dbContextOpts = new DbContextOptions<BugBoxDbContext>();
            db = new BugBoxDbContext(dbContextOpts);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            bugRepository = new BugRepository(db);
        }

        [Fact]
        public async Task Test1()
        {
            var bug = new Bug()
            {
                Title = "Bug 1",
            };

            var insertedBug = await bugRepository.InsertAsync(bug);
            Assert.Equal(1, insertedBug.Id);
            
        }
    }
}
