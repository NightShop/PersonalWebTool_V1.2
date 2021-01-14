using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebTool_V1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebTool_V1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostController : AdminController
    {
        private BlogContext context;
        private IWebHostEnvironment hostingEnvironment;
        private List<PostCategory> categories;


        public BlogPostController(BlogContext ctx,
                                  IWebHostEnvironment hostingEnvironment)
        {
            context = ctx;
            this.hostingEnvironment = hostingEnvironment;
            categories = context.Categories.OrderBy(c => c.Name).ToList();
        }
        public IActionResult Index()
        {
            return RedirectToAction("List", "BlogPost");
        }

        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {

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

        [HttpGet]
        public IActionResult Add()
        {
            BlogPost post = new BlogPost();
            post.Category = context.Categories.Find(1);

            ViewBag.Action = "Add";
            ViewBag.Categories = categories;
            return View("AddUpdate", post);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            BlogPost blogPost = context.BlogPosts.Include(p => p.Category).FirstOrDefault(b => b.BlogPostID == id);

            ViewBag.Action = "Update";
            ViewBag.Categories = categories;
            return View("AddUpdate", blogPost);
        }

        [HttpPost]
        public IActionResult Update(BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                if (blogPost.BlogPostID == 0)
                {
                    context.BlogPosts.Add(blogPost);
                }
                else
                {
                    context.BlogPosts.Update(blogPost);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                ViewBag.Categories = categories;
                return View("AddUpdate", blogPost);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            BlogPost post = context.BlogPosts.Find(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult Delete(BlogPost product)
        {
            context.BlogPosts.Remove(product);
            context.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult AddImageWindow(int id)
        {
            ImageViewModel model = new ImageViewModel();
            model.BlogID = id;
            return View("AddImage", model);
        }

        [HttpPost]
        public IActionResult AddImage(ImageViewModel model)
        {
            string uniqueFileName = null;
            string pathOldImage = null;
            if (model.Image.FileName != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath + "\\img\\");
                BlogPost post = context.BlogPosts.Find(model.BlogID);
                string oldImageName = Path.GetFileName(post.ImageUrl);
                //Delete previous picture
                pathOldImage = Path.Combine(uploadsFolder, oldImageName);

                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                model.Image.CopyTo(fileStream);
                fileStream.Close();
                post.ImageUrl = "\\img\\" + uniqueFileName;
                string[] imageNameArray = uniqueFileName.Split("_");
                string imageName = imageNameArray[imageNameArray.Length - 1];
                post.ImageName = imageName;
                context.BlogPosts.Update(post);
                context.SaveChanges();
            }
            System.IO.File.Delete(pathOldImage);
            return RedirectToAction("List");
        }
    }
        
}
