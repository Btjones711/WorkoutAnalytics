using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkoutAnalytics.UI.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        [StringLength(450)]
        [Index(IsUnique = true)]
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
