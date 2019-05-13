using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAnalytics.UI.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public virtual ICollection<Weight> WeightHistory { get; set; }
        public virtual ICollection<UserWorkout> WorkoutHistory { get; set; }
        public virtual ICollection<UserTemplate> Templates { get; set; }
    }
}
