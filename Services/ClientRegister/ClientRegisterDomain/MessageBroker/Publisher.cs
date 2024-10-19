using ClientRegisterDomain.Message.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace ClientRegisterDomain.Message;

internal class Publisher : IEventBus
{
    public Publisher() { }

    public void ConsumeMessage()
    {
        throw new NotImplementedException();
    }

    public void PublishMessage()
    {

        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        string[] strings = { "algo", "algo 1" };
        channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Direct);

        var message = GetMessage(strings);
        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(exchange: "logs",
                             routingKey: string.Empty,
                             basicProperties: null,
                             body: body);
        Console.WriteLine($" [x] Sent {message}");

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();

        static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "info: Hello World!");
        }

    }
}
