using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.DTO
{
    public class ProductDTO
    {
        public int? product_id { get; set; }
        public string? product_name { get; set; }
        public string? product_description { get; set; }
        public int? product_price { get; set; }
        public IFormFile? product_image { get; set; } 
        public string? product_imageURL { get; set; }
        public string? product_isActive { get; set; }
        public int? category_id { get; set; }
        public string? category_name { get; set; }
    }

}
