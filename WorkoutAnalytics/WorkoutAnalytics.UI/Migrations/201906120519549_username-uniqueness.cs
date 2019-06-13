namespace WorkoutAnalytics.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usernameuniqueness : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "UserName", c => c.String(maxLength: 450));
            CreateIndex("dbo.User", "UserName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", new[] { "UserName" });
            AlterColumn("dbo.User", "UserName", c => c.String());
        }
    }
}
