
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQ_Test.Services
{
    public class CustomBackgroundService : IHostedService,IDisposable
    {
        IConnection connection;
        IModel channel;
        public CustomBackgroundService()
        {
            var factory = new ConnectionFactory { Uri = new Uri("amqps://rctqzmnf:cSXWiUbvEGyuFjyad127zKeycF9KcxMi@jackal.rmq.cloudamqp.com/rctqzmnf") };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "Rabbit_Test",
                     durable:true ,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);
            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;
            channel.BasicConsume(queue: "Rabbit_Test",
                     autoAck: true,
                     consumer: consumer);
        }

        private void Consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            Console.WriteLine(Encoding.UTF8.GetString(e.Body.ToArray()));
        }

        public void Dispose()
        {
            channel.Dispose();
            connection.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
   
    }
}
