using RabbitMQ.Client;

namespace ClientRegisterDomain.Message.Interfaces;

public interface IEventBus
{
    public void PublishMessage();
    public void ConsumeMessage();
}
