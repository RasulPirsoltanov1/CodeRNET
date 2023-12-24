namespace Constructors.Models;


public class BaseEntity : IDisposable
{
    ~BaseEntity()
    {
        Dispose(false);
    }
    // Logs
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Mail { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int CreatedBy { get; set; }
    public string CreatedIp { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public string CreatedComputerName { get; set; } = null!;
    public string CreatedADUserName { get; set; } = null!;

    public int? ModifiedBy { get; set; }
    public string? ModifiedIp { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? ModifiedComputerName { get; set; }
    public string? ModifiedADUserName { get; set; }


    public bool disposed = false;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool diposing)
    {
        if (!disposed)
        {
            // if (diposing)   { }
            disposed = true;
        }
    }
    public BaseEntity()
    {
        // Initialize fields with some default values
        CreatedDate = DateTime.Now;
        CreatedComputerName = Environment.MachineName;
        CreatedADUserName = Environment.UserName;
        CreatedIp = "::1";
        CreatedBy = 1;

        // Note: In a real-world application, you might retrieve these values from a config file, database, or environment variables
    }
    public BaseEntity(string firstName)
    {
        this.FirstName = firstName;
    }
    /// <summary>
    /// Create Default Employee
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    public BaseEntity(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
    // Employee properties

}



public class Employee : BaseEntity
{
    // Constructor
  



    public Employee(string firstName) : base(firstName) { }

    /// <summary>
    /// Create Default Employee
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    public Employee(string firstName, string lastName) : base(firstName, lastName) { }

    public Employee(string firstName, string lastName, string mail) : this(firstName, lastName)
    {
        this.Mail = mail;
    }
    public Employee(string firstName, string lastName, string mail, string phone) : this(firstName, lastName,mail)
    {
        this.Phone = phone;
    }

    public Employee(string firstName, string lastName, string mail, string phone, string address) : this(firstName, lastName,mail,phone)
    {
        this.Address = address;
    }




    // Destructor
    ~Employee()
    {
        // Here you can log the destruction of the Employee or perform other clean-up operations
        Console.WriteLine("Employee destroyed: " + this.FirstName + " " + this.LastName);
    }



}