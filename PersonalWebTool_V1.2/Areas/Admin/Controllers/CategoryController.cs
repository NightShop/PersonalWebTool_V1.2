using Microsoft.AspNetCore.Mvc;
using PersonalWebTool_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebTool_V1.Areas.Admin.Controllers
{

    [Area("Admin")]

    public class CategoryController : AdminController
    {
        private BlogContext context;
        public CategoryController(BlogContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List", "Category");
        }
        [Route("[area]/Categories/{id?}")]
        public IActionResult List()
        {
            List<PostCategory> categories = context.Categories.OrderBy(c => c.PostCategoryID).ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            return View("AddUpdate", new PostCategory());
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Action = "Update";
            PostCategory postCategory = context.Categories.Find(id);
            return View("AddUpdate", postCategory);
        }

        [HttpPost]
        public IActionResult Update(PostCategory postCategory)
        {
            if (ModelState.IsValid)
            {
                if(postCategory.PostCategoryID == 0)
                { 
                context.Categories.Add(postCategory);
                }
                else
                {
                    context.Categories.Update(postCategory);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("AddUpdate");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            PostCategory postCategory = context.Categories.Find(id);
            return View(postCategory);
        }

        [HttpPost]
        public IActionResult Delete(PostCategory postCategory)
        {

            context.Categories.Remove(postCategory);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
