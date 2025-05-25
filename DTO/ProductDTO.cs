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
        public IFormFile? product_image { get; set; }   //Physical file store Like .JPG
        public string? product_imageURL { get; set; }   //Link with Cloudinary and store the URL in our database 
        public string? product_isActive { get; set; }
        public int? category_id { get; set; }
        public string? category_name { get; set; }
    }

}
