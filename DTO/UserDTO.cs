using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.FileProviders;

namespace eBazzar.DTO
{
    public class UserDTO
    {
        public int? user_id { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public string? mobile { get; set; }
        public string? password { get; set; }
        //public IFormFile? user_image { get; set; }
        //public string? user_imageURL { get; set; }
        public string? user_isActive { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;
    }
}
