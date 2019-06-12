using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkoutAnalytics.UI.Models
{
    [Table("UserWorkoutTemplates")]
    public class UserWorkoutTemplate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TemplateID { get; set; }
        public int WorkoutID { get; set; }

        [ForeignKey("TemplateID")]
        public virtual UserTemplate UserTemplate { get; set; }
        [ForeignKey("WorkoutID")]
        public virtual Workout Workout { get; set; }
    }
}
