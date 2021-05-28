using System;
using Microsoft.EntityFrameworkCore;
using BugBox.Domain.Bugs;

namespace BugBox.Repository.EF
{
    public class BugBoxDbContext : DbContext
    {
        private string connStr = "Server=localhost;Integrated Security=true;Database=BugBoxDb;";

        public BugBoxDbContext()
        {
            //await this.Database.EnsureCreatedAsync();
        }

        public BugBoxDbContext(string connStr)
        {
            this.connStr = connStr;
        }

        public BugBoxDbContext(DbContextOptions<BugBoxDbContext> options)
           : base(options)
        {

        }

        public DbSet<Bug> Bugs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connStr);
        }
    }
}
