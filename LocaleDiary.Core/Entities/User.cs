using System;
using System.Collections.Generic;

namespace LocaleDiary.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public int UserProfileId { get; set; }

        public virtual ICollection<Locale> Locales { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}