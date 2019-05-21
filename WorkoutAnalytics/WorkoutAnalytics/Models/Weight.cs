using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAnalytics.UI.Models
{
    public class Weight
    {
        public int UserID { get; set; }
        public int UserWeight { get; set; }
        public DateTime WeightDate { get; set; }

        public virtual User User { get; set; }
    }
}
