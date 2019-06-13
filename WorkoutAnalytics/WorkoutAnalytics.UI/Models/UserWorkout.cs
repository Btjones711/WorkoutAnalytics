using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

    [Table("UserWorkouts")]
    public class UserWorkout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserWorkoutID { get; set; }
        public int WorkoutID { get; set; }
        public int UserID { get; set; }
        public int WeightLifted { get; set; }
        public int TimeOfWorkout { get; set; }
        public int Distance { get; set; }
        public DistanceUnit DistanceUnits { get; set; }
        public WeightUnit WeightUnits { get; set; }
        public Sentiment? SentimentID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WorkoutDate { get; set; }
        public int Reps { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        [ForeignKey("WorkoutID")]
        public virtual Workout Workout { get; set; }
    }
}
