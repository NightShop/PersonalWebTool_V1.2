using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalWebTool_V1.Models;

namespace PersonalWebTool_V1.Controllers
{
    public class BlogPostController : Controller
    {
        private BlogContext context;
        public BlogPostController(BlogContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "BlogPost");
        }

        public IActionResult Detail(int id)
        {
            List<PostCategory> categories = context.Categories.OrderBy(c => c.PostCategoryID).ToList();
            BlogPost blogPost = context.BlogPosts.Find(id);
            ViewBag.CategoryName = categories.Find(c => c.PostCategoryID == blogPost.PostCategoryID).Name;

            return View(blogPost);
        }
        [Route("[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            List<PostCategory> categories = context.Categories.OrderBy(c => c.PostCategoryID).ToList();
            List<BlogPost> blogPosts;
            if (id == "All")
            {
                blogPosts = context.BlogPosts.OrderByDescending(p => p.DateCreated).ToList();
            }
            else
            {
                blogPosts = context.BlogPosts.Where(p => p.Category.Name == id).OrderByDescending(p => p.DateCreated).ToList();
            }

            PostListViewModel model = new PostListViewModel
            {
                Categories = categories,
                BlogPosts = blogPosts,
                SelectedCategory = id
            };
           
            return View(model);
        }

        
    }
}
