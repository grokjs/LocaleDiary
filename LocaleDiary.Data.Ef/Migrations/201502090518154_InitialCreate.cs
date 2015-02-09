namespace LocaleDiary.Data.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "locale.Locales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(maxLength: 1000),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("locale.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "locale.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("locale.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);
            
            CreateTable(
                "locale.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bio = c.String(maxLength: 2000),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("locale.Locales", "UserId", "locale.Users");
            DropForeignKey("locale.Users", "UserProfileId", "locale.UserProfiles");
            DropIndex("locale.Users", new[] { "UserProfileId" });
            DropIndex("locale.Locales", new[] { "UserId" });
            DropTable("locale.UserProfiles");
            DropTable("locale.Users");
            DropTable("locale.Locales");
        }
    }
}
