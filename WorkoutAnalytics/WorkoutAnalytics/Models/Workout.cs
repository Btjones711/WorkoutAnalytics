using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAnalytics.UI.Models
{
    public class Workout
    {
        public int WorkoutID { get; set; }
        public string WorkoutDesc { get; set; }
        public string WorkoutBodyArea { get; set; }
    }
}
