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
            List<HabitDay> days = context.HabitDays.OrderBy(h => h.DateCreated).ToList();
            return View(days);
        }
    }
}
