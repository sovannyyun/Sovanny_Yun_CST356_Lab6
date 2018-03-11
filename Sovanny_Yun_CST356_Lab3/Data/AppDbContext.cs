using Sovanny_Yun_CST356_Lab3.Data.Entities;
using System.Data.Entity;

namespace Sovanny_Yun_CST356_Lab3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
    }

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        // intentionally left blank
    }
}