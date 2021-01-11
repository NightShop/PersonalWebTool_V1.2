using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebTool_V1.Models
{
    public class HabitDay
    {
        public int HabitDayID { get; set; }
        public DateTime DateCreated { get; set; }
        public int? Points { get; set; }
        public ICollection<HabitQuantity> HabitQuantities { get; set; }
        public HabitDay()
        {
            this.DateCreated = DateTime.Now;
        }
    }
}
