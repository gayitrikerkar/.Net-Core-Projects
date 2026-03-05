namespace ImageApp.Models
{
    public class ProductView
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? Price { get; set; }

        public IFormFile Photo { get; set; }
    }
}
