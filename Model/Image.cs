using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Image
    {
        public int Id { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }
    }
}
