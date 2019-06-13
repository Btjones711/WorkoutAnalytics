namespace WorkoutAnalytics.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeworkoutdescforeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserWorkouts", new[] { "WorkoutID", "WorkoutDesc" }, "dbo.Workouts");
            DropForeignKey("dbo.UserWorkoutTemplates", new[] { "WorkoutID", "WorkoutDesc" }, "dbo.Workouts");
            DropIndex("dbo.UserWorkouts", new[] { "WorkoutID", "WorkoutDesc" });
            DropIndex("dbo.UserWorkoutTemplates", new[] { "WorkoutID", "WorkoutDesc" });
            DropPrimaryKey("dbo.Workouts");
            AlterColumn("dbo.Workouts", "WorkoutDesc", c => c.String());
            AddPrimaryKey("dbo.Workouts", "WorkoutID");
            CreateIndex("dbo.UserWorkouts", "WorkoutID");
            CreateIndex("dbo.UserWorkoutTemplates", "WorkoutID");
            AddForeignKey("dbo.UserWorkouts", "WorkoutID", "dbo.Workouts", "WorkoutID", cascadeDelete: true);
            AddForeignKey("dbo.UserWorkoutTemplates", "WorkoutID", "dbo.Workouts", "WorkoutID", cascadeDelete: true);
            DropColumn("dbo.UserWorkouts", "WorkoutDesc");
            DropColumn("dbo.UserWorkoutTemplates", "WorkoutDesc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserWorkoutTemplates", "WorkoutDesc", c => c.String(maxLength: 128));
            AddColumn("dbo.UserWorkouts", "WorkoutDesc", c => c.String(maxLength: 128));
            DropForeignKey("dbo.UserWorkoutTemplates", "WorkoutID", "dbo.Workouts");
            DropForeignKey("dbo.UserWorkouts", "WorkoutID", "dbo.Workouts");
            DropIndex("dbo.UserWorkoutTemplates", new[] { "WorkoutID" });
            DropIndex("dbo.UserWorkouts", new[] { "WorkoutID" });
            DropPrimaryKey("dbo.Workouts");
            AlterColumn("dbo.Workouts", "WorkoutDesc", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Workouts", new[] { "WorkoutID", "WorkoutDesc" });
            CreateIndex("dbo.UserWorkoutTemplates", new[] { "WorkoutID", "WorkoutDesc" });
            CreateIndex("dbo.UserWorkouts", new[] { "WorkoutID", "WorkoutDesc" });
            AddForeignKey("dbo.UserWorkoutTemplates", new[] { "WorkoutID", "WorkoutDesc" }, "dbo.Workouts", new[] { "WorkoutID", "WorkoutDesc" });
            AddForeignKey("dbo.UserWorkouts", new[] { "WorkoutID", "WorkoutDesc" }, "dbo.Workouts", new[] { "WorkoutID", "WorkoutDesc" });
        }
    }
}
