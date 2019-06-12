namespace WorkoutAnalytics.UI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using WorkoutAnalytics.UI.Models;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<WorkoutAnalytics.UI.DAL.WorkoutContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WorkoutAnalytics.UI.DAL.WorkoutContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var users = new List<User>()
            {
                new User { UserName = "Btjones", Password = "Jonesy11", Gender=true, Height=68, Weight=158 },
                new User { UserName = "wai", Password = "yeng", Gender=false, Height=61, Weight=100 },
                new User { UserName = "ben", Password = "ten", Gender=true, Height=73, Weight=190 },
                new User { UserName = "test", Password = "testy", Gender=true, Height=63, Weight=200 }
            };
            users.ForEach(u => context.Users.AddOrUpdate(u));
            context.SaveChanges();
            var firstUser = context.Users.First(s => s.UserName == "Btjones").UserID;
            var weights = new List<Weight>(){
                new Weight { UserID = firstUser, UserWeight=158, WeightDate=new DateTime(2019,5,5)},
                new Weight { UserID = firstUser, UserWeight=160, WeightDate=new DateTime(2018,5,5)},
                new Weight { UserID = firstUser, UserWeight=155, WeightDate=new DateTime(2017,5,5)}
            };
            weights.ForEach(w => context.UserWeightHist.AddOrUpdate(p => new { p.UserID, p.WeightDate}, w));
            context.SaveChanges();
            var workouts = new List<Workout>()
            {
                new Workout{ WorkoutDesc = "Biceps Curl", WorkoutBodyArea = "Biceps" },
                new Workout{ WorkoutDesc = "Bench Press", WorkoutBodyArea = "Chest" },
                new Workout{ WorkoutDesc = "Rope Pulldown", WorkoutBodyArea = "Triceps" },
                new Workout{ WorkoutDesc = "Run", WorkoutBodyArea = "Cardio" },
                new Workout{ WorkoutDesc = "Leg Press", WorkoutBodyArea = "Legs" }
            };
            workouts.ForEach(w => context.Workouts.AddOrUpdate(p=>p.WorkoutDesc,w));
            context.SaveChanges();
            var userWorkouts = new List<UserWorkout>()
            {
                new UserWorkout{
                    WorkoutID = context.Workouts.First(s => s.WorkoutDesc == "Biceps Curl").WorkoutID,
                    Reps = 10, WeightLifted = 35, WeightUnits = WeightUnit.lbs, SentimentID = Sentiment.Exhausted,
                     WorkoutDate = DateTime.Today, UserID = firstUser
                },
                new UserWorkout{
                    WorkoutID = context.Workouts.First(s => s.WorkoutDesc == "Rope Pulldown").WorkoutID,
                    Reps = 12, WeightLifted = 25, WeightUnits = WeightUnit.kg, SentimentID = Sentiment.Good,
                     WorkoutDate = DateTime.Today, UserID = firstUser
                },
                new UserWorkout{
                    WorkoutID = context.Workouts.First(s => s.WorkoutDesc == "Run").WorkoutID,
                     TimeOfWorkout = 20,  Distance = 3, DistanceUnits = DistanceUnit.Miles, SentimentID = Sentiment.Exhausted,
                     WorkoutDate = DateTime.Today, UserID = firstUser
                }
            };
            userWorkouts.ForEach(u => context.UserWorkouts.AddOrUpdate(p => p.UserWorkoutID, u));
            context.SaveChanges();
            var userTemplate = new UserTemplate()
            {
                UserID = firstUser,
                DayOfTheWeek = Models.DayOfWeek.Thursday,
                TemplateDesc = "Back and Biceps",
            };
            context.UserTemplates.AddOrUpdate(userTemplate);
            context.SaveChanges();
            var userTemplateWorkouts = new List<UserWorkoutTemplate>()
            {
                new UserWorkoutTemplate{
                    TemplateID = context.UserTemplates.First(s => s.UserID == firstUser && s.TemplateDesc == "Back and Biceps").TemplateID,
                    WorkoutID = context.Workouts.First(s => s.WorkoutDesc.Contains("Biceps")).WorkoutID
                }
            };
            userTemplateWorkouts.ForEach(u => context.UserWorkoutTemplates.AddOrUpdate(p => new { p.TemplateID, p.WorkoutID }, u));
            context.SaveChanges();
        }
    }
}
