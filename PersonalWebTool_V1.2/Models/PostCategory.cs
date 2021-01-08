using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebTool_V1.Models
{
    public class PostCategory
    {
        public int PostCategoryID { get; set; }
        [Required(ErrorMessage ="Please enter category name")]
        public string Name { get; set; }
    }
}
