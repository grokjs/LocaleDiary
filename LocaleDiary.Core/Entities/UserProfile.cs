using System;

namespace LocaleDiary.Core.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Bio { get; set; }
        public DateTime DateModified { get; set; }
        //public Guid UserId { get; set; }

        //public virtual User User { get; set; }
    }
}