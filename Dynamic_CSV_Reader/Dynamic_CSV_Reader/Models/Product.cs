namespace Dynamic_CSV_Reader.Models
{
    public class Product: Base
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public int? Stock { get; set; }
    }
}
