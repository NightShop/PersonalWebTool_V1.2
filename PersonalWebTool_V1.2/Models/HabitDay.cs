using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebTool_V1.Models
{
    public class HabitDay
    {
        private BlogContext context;
        public int HabitDayID { get; set; }
        public DateTime DateCreated { get; set; }
        public int? Points { get; set; }
        public List<Habit> habitsAtMoment { get; set; }
        Dictionary<Habit, int> PointPerHabit { get; set; }

        public HabitDay(BlogContext ctx)
        {
            context = ctx;
            this.DateCreated = DateTime.Now;
            this.habitsAtMoment.AddRange(context.Habits);
            this.PointPerHabit = habitsAtMoment.ToDictionary(h => h, h => 0);
        }
    }
}
