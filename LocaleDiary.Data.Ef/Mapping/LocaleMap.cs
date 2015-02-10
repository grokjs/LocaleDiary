using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LocaleDiary.Core.Entities;

namespace LocaleDiary.Data.Ef.Mapping
{
    public class LocaleMap : EntityTypeConfiguration<Locale>
    {
        public LocaleMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).IsRequired().HasMaxLength(250);
            Property(x => x.Description).HasMaxLength(1000);
            Property(x => x.UserId).IsRequired();
        }
    }
}