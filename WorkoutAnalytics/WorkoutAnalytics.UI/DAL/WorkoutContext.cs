using System;
using System.Collections.Generic;
using System.Text;
using WorkoutAnalytics.UI.Models;
using System.Data.Entity;

namespace WorkoutAnalytics.UI.DAL
{
    public class WorkoutContext : DbContext
    {
        public WorkoutContext() : base("name=WorkoutContext")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<UserWorkout> UserWorkouts { get; set; }
        public DbSet<UserTemplate> UserTemplates { get; set; }
        public DbSet<UserWorkoutTemplate> UserWorkoutTemplates { get; set; }
        public DbSet<Weight> UserWeightHist { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
