using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebTool_V1.Models
{
    public class HabitQuantity
    {
        [Key]
        public string HabitQuantityID { get; set; }
        [Required()]
        public HabitDay HabitDay { get; set; }
        [Required()]
        public Habit Habit { get; set; }

        public int Counter { get; set; }
        
    }
}
