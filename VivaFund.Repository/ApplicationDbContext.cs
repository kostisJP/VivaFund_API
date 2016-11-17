using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace VivaFund.Repository
{
    public class ApplicationDbContext : DbContext

    {
        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<ProjectMedia> ProjectMedia { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<ProjectUpdate> ProjectUpdates { get; set; }
        public DbSet<Reward> Rewards { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
