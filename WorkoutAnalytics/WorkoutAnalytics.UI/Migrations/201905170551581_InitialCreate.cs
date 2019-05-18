namespace WorkoutAnalytics.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Height = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserTemplates",
                c => new
                    {
                        TemplateID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        TemplateDesc = c.String(),
                        DayOfTheWeek = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TemplateID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.UserWeightHist",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        WeightDate = c.DateTime(nullable: false),
                        UserWeight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.WeightDate })
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.UserWorkouts",
                c => new
                    {
                        UserWorkoutID = c.Int(nullable: false, identity: true),
                        WorkoutID = c.Int(nullable: false),
                        WorkoutDesc = c.String(maxLength: 128),
                        UserID = c.Int(nullable: false),
                        WeightLifted = c.Int(nullable: false),
                        TimeOfWorkout = c.Int(nullable: false),
                        Distance = c.Int(nullable: false),
                        DistanceUnits = c.Int(nullable: false),
                        WeightUnits = c.Int(nullable: false),
                        SentimentID = c.Int(),
                        WorkoutDate = c.DateTime(nullable: false),
                        Reps = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserWorkoutID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Workouts", t => new { t.WorkoutID, t.WorkoutDesc })
                .Index(t => new { t.WorkoutID, t.WorkoutDesc })
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        WorkoutID = c.Int(nullable: false, identity: true),
                        WorkoutDesc = c.String(nullable: false, maxLength: 128),
                        WorkoutBodyArea = c.String(),
                    })
                .PrimaryKey(t => new { t.WorkoutID, t.WorkoutDesc });
            
            CreateTable(
                "dbo.UserWorkoutTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TemplateID = c.Int(nullable: false),
                        WorkoutID = c.Int(nullable: false),
                        WorkoutDesc = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTemplates", t => t.TemplateID, cascadeDelete: true)
                .ForeignKey("dbo.Workouts", t => new { t.WorkoutID, t.WorkoutDesc })
                .Index(t => t.TemplateID)
                .Index(t => new { t.WorkoutID, t.WorkoutDesc });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserWorkoutTemplates", new[] { "WorkoutID", "WorkoutDesc" }, "dbo.Workouts");
            DropForeignKey("dbo.UserWorkoutTemplates", "TemplateID", "dbo.UserTemplates");
            DropForeignKey("dbo.UserWorkouts", new[] { "WorkoutID", "WorkoutDesc" }, "dbo.Workouts");
            DropForeignKey("dbo.UserWorkouts", "UserID", "dbo.User");
            DropForeignKey("dbo.UserWeightHist", "UserID", "dbo.User");
            DropForeignKey("dbo.UserTemplates", "UserID", "dbo.User");
            DropIndex("dbo.UserWorkoutTemplates", new[] { "WorkoutID", "WorkoutDesc" });
            DropIndex("dbo.UserWorkoutTemplates", new[] { "TemplateID" });
            DropIndex("dbo.UserWorkouts", new[] { "UserID" });
            DropIndex("dbo.UserWorkouts", new[] { "WorkoutID", "WorkoutDesc" });
            DropIndex("dbo.UserWeightHist", new[] { "UserID" });
            DropIndex("dbo.UserTemplates", new[] { "UserID" });
            DropTable("dbo.UserWorkoutTemplates");
            DropTable("dbo.Workouts");
            DropTable("dbo.UserWorkouts");
            DropTable("dbo.UserWeightHist");
            DropTable("dbo.UserTemplates");
            DropTable("dbo.User");
        }
    }
}
