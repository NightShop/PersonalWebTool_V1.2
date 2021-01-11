using Microsoft.AspNetCore.Mvc;
using PersonalWebTool_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebTool_V1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HabitDayController : Controller
    {
        private BlogContext context;
        public HabitDayController(BlogContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            HabitViewModel model = new HabitViewModel();
            model.HabitDays = context.HabitDays.OrderByDescending(h => h.DateCreated).ToList();
            model.Habits = context.Habits.OrderBy(h => h.HabitID).ToList();
            model.HabitQuantities = context.HabitQuantities.OrderBy(q => q.Habit.HabitID).ToList();
            return View(model);
        }

        public IActionResult MakeNew()
        {
            HabitDay currentDay = new HabitDay();
            context.Add(currentDay);
            context.SaveChanges();
            foreach (Habit habit in context.Habits)
            {
                string ID = currentDay.HabitDayID + "-" + habit.HabitID;
                HabitQuantity habitQuantity = new HabitQuantity();
                habitQuantity.HabitQuantityID = ID;
                habitQuantity.Habit = habit;
                habitQuantity.HabitDay = currentDay;
                habitQuantity.Counter = 0;
                context.HabitQuantities.Add(habitQuantity);
            }
            context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult AddPoint(string id)
        {
            string[] slug = id.Split("-");
            string habitID = slug[0];
            string habitDayID = slug[1];
            HabitQuantity habitQuantity = context.HabitQuantities.Where(q => q.Habit.HabitID.ToString() == habitID && q.HabitDay.HabitDayID.ToString() == habitDayID).FirstOrDefault();
            habitQuantity.Counter++;
            context.HabitQuantities.Update(habitQuantity);
            context.SaveChanges();
            return RedirectToAction("List");

        }
    }
}
