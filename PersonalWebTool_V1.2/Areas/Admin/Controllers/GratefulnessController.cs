using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebTool_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebTool_V1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GratefulnessController : AdminController
    {
        private BlogContext context;
        public GratefulnessController(BlogContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            List<GratefulnessEntry> entries = context.GratefulnessEntries.Include(entry => entry.GratefulnessUnits).OrderByDescending(entry => entry.DateCreated).ToList();
            return View(entries);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            GratefulnessViewModel model = new GratefulnessViewModel();
            model.GratefulnessEntry = new GratefulnessEntry();
            List<GratefulnessUnit> units = new List<GratefulnessUnit> {
                new GratefulnessUnit(),
                new GratefulnessUnit(),
                new GratefulnessUnit(),
                new GratefulnessUnit(),
                new GratefulnessUnit()};
            model.GratefulnessUnits = units;
            return View("AddUpdate", model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Action = "Update";

            GratefulnessEntry entry = context.GratefulnessEntries.Find(id);
            List<GratefulnessUnit> units = context.GratefulnessUnits.Where(u => u.GratefulnessEntryID == entry.GratefulnessEntryID).ToList();
            GratefulnessViewModel model = new GratefulnessViewModel();
            model.GratefulnessEntry = entry;
            model.GratefulnessUnits = units;
            return View("AddUpdate", model);
        }

        [HttpPost]
        public IActionResult Add(GratefulnessViewModel model)
        {

            if (ModelState.IsValid)
            {

                if (model.GratefulnessEntry.GratefulnessEntryID == 0)
                {
                    GratefulnessEntry entry = model.GratefulnessEntry;
                    entry.GratefulnessUnits = new List<GratefulnessUnit>();
                    for (int i = 0; i < model.GratefulnessUnits.Count; i++)
                    {
                        entry.GratefulnessUnits.Add(model.GratefulnessUnits[i]);
                    }
                    context.GratefulnessEntries.Add(entry);
                }
                else
                {
                    for (int i = 0; i < model.GratefulnessUnits.Count; i++)
                    {
                        context.GratefulnessUnits.Update(model.GratefulnessUnits[i]);

                    }
                    
                }
            context.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("AddUpdate", model);
            }
        }

        public IActionResult Delete(int id)
        {
            GratefulnessEntry entry = context.GratefulnessEntries.Find(id);
            List<GratefulnessUnit> units = context.GratefulnessUnits.Where(u => u.GratefulnessEntryID == entry.GratefulnessEntryID).ToList();
            context.GratefulnessEntries.Remove(entry);
            context.GratefulnessUnits.RemoveRange(units);
            context.SaveChanges();
            return RedirectToAction("List");
        }


    }
}
