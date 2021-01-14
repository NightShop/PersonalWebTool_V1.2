using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebTool_V1.Models
{
    public class ImageViewModel
    {
        public int BlogID { get; set; }
        public IFormFile Image { get; set; }
    }
}
