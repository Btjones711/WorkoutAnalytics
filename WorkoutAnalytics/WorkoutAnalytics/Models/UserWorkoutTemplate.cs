using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAnalytics.UI.Models
{
    public class UserWorkoutTemplate
    {
        public int Id { get; set; }
        public int TemplateID { get; set; }
        public int WorkoutID { get; set; }

        public virtual UserTemplate UserTemplate { get; set; }
        public virtual Workout Workout { get; set; }
    }
}
