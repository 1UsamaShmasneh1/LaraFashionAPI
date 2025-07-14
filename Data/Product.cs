namespace LaraFashionAPI.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public double Descount { get; set; }
        public SizeModel Size { get; set; }
        public byte[] ImageBytes { get; set; }
    }
}
