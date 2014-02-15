using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LED.Domain.Entities;
using LED.DataProvider.Mapping;

namespace LED.DataProvider
{
    public partial class ledContext : DbContext
    {
        public ledContext() { }

        public DbSet<t_org> t_org { get; set; }
        public DbSet<t_resources> t_resources { get; set; }
        public DbSet<t_role> t_role { get; set; }
        public DbSet<t_user> t_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new t_orgMap());
            modelBuilder.Configurations.Add(new t_resourcesMap());
            modelBuilder.Configurations.Add(new t_roleMap());
            modelBuilder.Configurations.Add(new t_userMap());

        }
    }
}
