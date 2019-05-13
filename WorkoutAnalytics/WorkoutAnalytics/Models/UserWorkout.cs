using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAnalytics.UI.Models
{
    public enum Sentiment
    {
        TooLight,
        Good,
        Exhausted,
        Pain
    }

    public enum DistanceUnit
    {
        Miles,
        KM
    }

    public enum WeightUnit
    {
        lbs,
        kg
    }

    public class UserWorkout
    {
        public int UserWorkoutID { get; set; }
        public int WorkoutID { get; set; }
        public int UserID { get; set; }
        public int WeightLifted { get; set; }
        public DateTime TimeOfWorkout { get; set; }
        public int Distance { get; set; }
        public DistanceUnit DistanceUnits { get; set; }
        public WeightUnit WeightUnits { get; set; }
        public Sentiment? SentimentID { get; set; }
        public DateTime WorkoutDate { get; set; }

        public virtual User User { get; set; }
        public virtual Workout Workout { get; set; }
    }
}
