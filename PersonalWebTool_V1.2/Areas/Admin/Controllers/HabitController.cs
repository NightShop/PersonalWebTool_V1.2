using Microsoft.AspNetCore.Mvc;
using PersonalWebTool_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebTool_V1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HabitController : AdminController
    {
        private BlogContext context;
        public HabitController(BlogContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            List<Habit> habits = context.Habits.OrderBy(h => h.Name).ToList();
            return View(habits);
        }
        [HttpGet]
        public IActionResult Add()
        {
            Habit habit = new Habit();
            ViewBag.Action = "Add";
            return View("AddUpdate", habit);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Habit habit = context.Habits.Find(id);
            ViewBag.Action = "Update";
            return View("AddUpdate", habit);
        }

        [HttpPost]
        public IActionResult Update(Habit habit)
        {
            if(ModelState.IsValid)
            {
                if(habit.HabitID == 0)
                {
                    context.Habits.Add(habit);
                    context.SaveChanges();
                    foreach(HabitDay habitDay in context.HabitDays)
                    {
                        //habitDay.HabitQuantities = context.HabitDays.Find(habitDay.HabitDayID).HabitQuantities;
                        HabitQuantity habitQuantity = new HabitQuantity();
                        habitQuantity.Habit = habit;
                        habitQuantity.HabitDay = habitDay;
                        habitQuantity.Counter = 0;
                        habitQuantity.HabitQuantityID = habit.HabitID + "-" + habitDay.HabitDayID;
                        context.Add(habitQuantity);
                        habitDay.HabitQuantities.Add(habitQuantity);
                    }
                }
                else
                {
                    context.Habits.Update(habit);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return View("AddUpdate", habit);
            }
        }
        

    }
}
