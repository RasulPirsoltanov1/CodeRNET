namespace CodeFirst.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public short? UnitInStock { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category{ get; set; }
    }
}
