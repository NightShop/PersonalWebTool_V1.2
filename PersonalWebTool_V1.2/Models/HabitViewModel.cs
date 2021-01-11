using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebTool_V1.Models
{
    public class HabitViewModel
    {
        public List<HabitDay> HabitDays { get; set; }
        public List<Habit> Habits { get; set; }
        public List<HabitQuantity> HabitQuantities { get; set; }
    }
}
