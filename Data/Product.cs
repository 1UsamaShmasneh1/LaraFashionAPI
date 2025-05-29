namespace LaraFashionAPI.Data
{
    public class Product
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public string? Category { get; set; }

        public string? Sizes { get; set; }

        public string? PictureName { get; set; }
    }
}
