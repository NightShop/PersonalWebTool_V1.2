using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebTool_V1.Models
{
    public class PostListViewModel
    {
        public List<PostCategory> Categories { get; set; }
        public List<BlogPost> BlogPosts { get; set; }
        public string SelectedCategory { get; set; }
        public string CheckActiveCategory (string category)
        {
            if(category == SelectedCategory)
            {
                return "active";
            }
            else
            {
                return "";
            }
        }
    }
}
