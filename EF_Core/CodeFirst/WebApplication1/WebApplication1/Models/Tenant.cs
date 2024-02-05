namespace WebApplication1.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? TenancyName
        {
            get
            {
                return this.Name.Replace(" ", "").Replace("-", "").Replace("_", "").ToLower();
            }
           private set { }
            
        }
        public string? ConnectionString { get; set; }
    }
}
