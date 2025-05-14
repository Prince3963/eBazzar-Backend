using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.DTO
{
    public class UserDTO
    {
        public int? user_id { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public string? mobile { get; set; }
        public string? password { get; set; }

    }
}
