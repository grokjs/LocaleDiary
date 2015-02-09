using System.Data.Entity.ModelConfiguration;
using LocaleDiary.Core.Entities;

namespace LocaleDiary.Data.Ef.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired();
            Property(x => x.UserProfileId).IsRequired();
        }
    }
}