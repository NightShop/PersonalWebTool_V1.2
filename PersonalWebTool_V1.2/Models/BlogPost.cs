using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebTool_V1.Models
{
    public class BlogPost
    {
        public int BlogPostID { get; set; }
        [Required(ErrorMessage = "You forgot to enter the title")]
        public string Title { get; set; }
        public string Slug => Title == null ? "" : Title.Replace(' ', '-');
        public DateTime DateCreated { get; set; }
        [Required(ErrorMessage ="You can not create blog post without body")]
        public string Body { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Please select category")]
        public int PostCategoryID { get; set; }
        public PostCategory Category { get; set; }
        public BlogPost()
        {
            this.DateCreated = DateTime.Now;
        }
    }
}
