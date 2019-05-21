using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    public class UserTemplate
    {
        public int TemplateID { get; set; }
        public int UserID { get; set; }
        public string TemplateDesc { get; set; }
        public DayOfWeek DayOfTheWeek { get; set; }

        public virtual User User { get; set; }
    }
}
