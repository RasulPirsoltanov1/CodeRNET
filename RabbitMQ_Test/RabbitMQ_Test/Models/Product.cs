
namespace Models;

public class Product:BaseEntity<Guid>{
    public IFormFile FormFile{ get; set; }
}


public class BaseEntity<T>
{
    public T Id { get; set; }
    public string Name { get; set; }
    public DateTime CreateDate{ get; set; }
}