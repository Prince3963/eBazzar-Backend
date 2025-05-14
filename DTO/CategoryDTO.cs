namespace eBazzar.DTO
{
    public class CategoryDTO
    {
        public int category_id { get; set; }
        public string? category_name { get; set; }
        public string? category_description { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;

    }
}
