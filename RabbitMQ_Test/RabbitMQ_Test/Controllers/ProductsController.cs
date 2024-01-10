using System.Text;
using Microsoft.AspNetCore.Mvc;
using Models;
using RabbitMQ.Client;

namespace Controllers;
[ApiController,Route("[controller]/[action]")]
public class ProductsController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromForm]ProductDto productDto)
    {
        var product = new Product
        {
            CreateDate = DateTime.UtcNow,
            Name = productDto.Name,
            Id = new Guid(),
        };
        var factory = new ConnectionFactory { Uri = new Uri("amqps://rctqzmnf:cSXWiUbvEGyuFjyad127zKeycF9KcxMi@jackal.rmq.cloudamqp.com/rctqzmnf") };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queue: "Rabbit_Test",
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);
        
        var body = Encoding.UTF8.GetBytes(product.Id+"_"+productDto.FormFile.FileName);
        channel.BasicPublish(exchange:"",routingKey:"Rabbit_Test",basicProperties:null,body:body);
        return Ok();
    }

}