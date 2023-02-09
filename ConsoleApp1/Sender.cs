using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer;
public static class Sender
{
    public static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);
                string message = "First rabbitmq Message";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("", "BasicTest", null, body);
                Console.WriteLine("Sent Message {0}.... ", message);
            }
        }
        Console.WriteLine("Press [enter] to exit the sender app");
        Console.ReadKey();
    }
}