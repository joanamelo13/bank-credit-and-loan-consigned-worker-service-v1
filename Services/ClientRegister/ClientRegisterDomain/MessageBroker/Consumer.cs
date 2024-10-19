
using ClientRegisterDomain.Message.Interfaces;
using RabbitMQ.Client;

namespace ClientRegisterDomain.Message;

public class Consumer : IEventBus
{
    private readonly IEventBus _eventBus;

    public Consumer() { }

    public Consumer(IEventBus eventBus) 
    {
        _eventBus = eventBus;
    }

    public void ConsumeMessage()
    {
        throw new NotImplementedException();
    }

    public void PublishMessage()
    {
        throw new NotImplementedException();
    }
}
