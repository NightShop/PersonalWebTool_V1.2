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
            BlogPostCreateViewModel model = new BlogPostCreateViewModel();
            model.blogPost = post;
            ViewBag.Action = "Add";
            ViewBag.Categories = categories;
            return View("AddUpdate", model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            BlogPostCreateViewModel model = new BlogPostCreateViewModel();
            BlogPost blogPost = context.BlogPosts.Include(p => p.Category).FirstOrDefault(b => b.BlogPostID == id);
            model.blogPost = blogPost;
            ViewBag.Action = "Update";
            ViewBag.Categories = categories;
            return View("AddUpdate", model);
        }

        [HttpPost]
        public IActionResult Update(BlogPostCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.blogPost.BlogPostID == 0)
                {


                    //adding picture

                    string uniqueFileName = null;
                    if (model.Image != null)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath + "\\img\\");

                        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        FileStream fileStream = new FileStream(filePath, FileMode.Create);
                        model.Image.CopyTo(fileStream);
                        fileStream.Close();
                        model.blogPost.ImageUrl = "\\img\\" + uniqueFileName;
                        string[] imageNameArray = uniqueFileName.Split("_");
                        string imageName = imageNameArray[imageNameArray.Length - 1];
                        model.blogPost.ImageName = imageName;
                    }

                    context.BlogPosts.Add(model.blogPost);
                }
                else
                {
                    //updating picture
                    string uniqueFileName = null;
                    string pathOldImage = null;
                    if (model.Image != null)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath + "\\img\\");
                        string oldImageName = Path.GetFileName(model.blogPost.ImageUrl);
                        //Delete previous picture
                        if (oldImageName != null)
                        {
                            pathOldImage = Path.Combine(uploadsFolder, oldImageName);
                            System.IO.File.Delete(pathOldImage);
                        }
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        FileStream fileStream = new FileStream(filePath, FileMode.Create);
                        model.Image.CopyTo(fileStream);
                        fileStream.Close();
                        model.blogPost.ImageUrl = "\\img\\" + uniqueFileName;
                        string[] imageNameArray = uniqueFileName.Split("_");
                        string imageName = imageNameArray[imageNameArray.Length - 1];
                        model.blogPost.ImageName = imageName;
                    }
                    context.BlogPosts.Update(model.blogPost);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                ViewBag.Categories = categories;
                return View("AddUpdate", model);
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
            BlogPostCreateViewModel model = new BlogPostCreateViewModel();
            model.BlogID = id;
            return View("AddImage", model);
        }

        [HttpPost]
        public IActionResult AddImage(BlogPostCreateViewModel model)
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
