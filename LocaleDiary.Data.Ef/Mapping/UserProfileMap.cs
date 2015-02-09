using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LocaleDiary.Core.Entities;

namespace LocaleDiary.Data.Ef.Mapping
{
    public class UserProfileMap : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Bio).HasMaxLength(2000);
            Property(x => x.DateModified).IsRequired();
            //Property(x => x.UserId).IsRequired();
            /*HasRequired(x => x.User)
                .WithRequiredDependent(x => x.UserProfile);*/
        }
    }
}