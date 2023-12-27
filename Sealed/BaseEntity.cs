using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sealed
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Date{ get; set; }
        public BaseEntity()
        {
            Date = DateTime.Now;
        }
        public void LogCurrentUser()
        {
            Console.WriteLine("Current user : admin");
        }
        public void LogLastUser()
        {
            Console.WriteLine("Last user : admin");
        }
        public void setLogDb()
        {
            Console.WriteLine("Log: BaseEntity: admin : date = " +this.Date);
        }
    }
    public class Book:BaseEntity
    {
        public string title{ get; set; }
        public string author{ get; set; }
        public DateTime PublishDate{ get; set; }
        public int PageCount{ get; set; }
        public string Publisher{ get; set; }
        public string Isbn{ get; set; }
        public string Description{ get; set; }
        public decimal price{ get; set; }
        public int StockCount{ get; set; }
    }
    public sealed class Author : BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
    public sealed class Magazine : Book
    {

    }
    public sealed class Novel : Book
    {

    }
    public sealed class Bio: Book
    {

    }
    public sealed class Dictionary : Book
    {

    }
    public sealed class Encyclopedia : Book
    {

    }
}
