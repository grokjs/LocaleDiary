using System.Data.Entity;
using LocaleDiary.Core.Entities;

namespace LocaleDiary.Data.Ef
{
    public class LocaleDiaryContext : DbContext
    {
        public virtual DbSet<Locale> Locales { get; set; }
    }
}