using System.Data.Entity;
using LocaleDiary.Core.Entities;
using LocaleDiary.Data.Ef.Mapping;

namespace LocaleDiary.Data.Ef
{
    public class LocaleDiaryContext : DbContext
    {
        public LocaleDiaryContext()
            : base("LocaleDiaryDb")
        {
            
        }

        public virtual DbSet<Locale> Locales { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("locale");

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new LocaleMap());
        }
    }
}