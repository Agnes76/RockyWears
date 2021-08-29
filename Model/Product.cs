using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantitySold { get; set; }

        public int QuantityAvailable { get; set; }

        [ForeignKey("ImageId")]
        public List<Image> Image { get; set; }

        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public bool InStock { get; set; }
        public DateTime DateAdded { get; set; }
        public string DateSold { get; set; } = null;
    }
}
