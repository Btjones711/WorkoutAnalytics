using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkoutAnalytics.UI.Models
{
    public enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    [Table("UserTemplates")]
    public class UserTemplate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TemplateID { get; set; }
        public int UserID { get; set; }
        public string TemplateDesc { get; set; }
        public DayOfWeek DayOfTheWeek { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
