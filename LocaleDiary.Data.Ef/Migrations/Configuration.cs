using LocaleDiary.Core.Entities;

namespace LocaleDiary.Data.Ef.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LocaleDiary.Data.Ef.LocaleDiaryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LocaleDiary.Data.Ef.LocaleDiaryContext context)
        {
            
        }
    }
}
