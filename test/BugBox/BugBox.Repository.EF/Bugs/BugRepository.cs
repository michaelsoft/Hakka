using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugBox.Domain.Bugs;
using BugBox.Repository.EF;

namespace BugBox.Repository.EF.Bugs
{
    public class BugRepository : IBugRepository
    {
        private BugBoxDbContext db;

        public BugRepository(BugBoxDbContext db)
        {
            this.db = db;
        }

        public async Task<Bug> InsertAsync(Bug bug)
        {
            db.Bugs.Add(bug);
            await db.SaveChangesAsync();
            return bug;
        }

        public async Task<Bug> UpdateAsync(Bug bug)
        {
            db.Attach(bug);
            var updatedEntity = db.Bugs.Update(bug).Entity;
            await db.SaveChangesAsync();
            return updatedEntity;
        }

        public async Task DeleteAsync(Bug bug)
        {
            db.Bugs.Remove(bug);
            await db.SaveChangesAsync();
        }

        public async Task<Bug> GetAsync(int id)
        {
            return await db.Bugs.FindAsync(id);
        }

        public async Task<List<Bug>> GetListAsync()
        {
            return db.Bugs.ToList();
        }
    }
}
