using System;

namespace LocaleDiary.Core.Entities
{
    public class Locale
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}