using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkoutAnalytics.UI.Models
{
    [Table("UserWeightHist")]
    public class Weight
    {
        [Key]
        [Column(Order = 1)]
        public int UserID { get; set; }
        public int UserWeight { get; set; }
        [Key]
        [Column(Order = 2)]
        public DateTime WeightDate { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
