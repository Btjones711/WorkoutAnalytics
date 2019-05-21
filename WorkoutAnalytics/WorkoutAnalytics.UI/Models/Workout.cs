using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkoutAnalytics.UI.Models
{
    [Table("Workouts")]
    public class Workout
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkoutID { get; set; }
        [Key]
        [Column(Order = 2)]
        public string WorkoutDesc { get; set; }
        public string WorkoutBodyArea { get; set; }
    }
}
