using ClientRegisterDomain.Enumerables;
using ClientRegisterDomain.Message.Interfaces;
using RabbitMQ.Client;
using System.Diagnostics;


namespace ClientRegisterDomain.Message;
public class EventBus : IEventBus
{
    private readonly IEventBus _eventBus;

    #region Constructors
    public EventBus() { }

    public EventBus(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }
    #endregion

    public EventBus(EventType eventType)
    {
        switch (eventType)
        {
            case EventType.Publisher:
                _eventBus = new EventBus(eventType);
                break;
            case EventType.Consumer:
                _eventBus = new EventBus(eventType);
                break;
            default:
                throw new NotImplementedException();
        }
    }

    public void PublishMessage()
    {
        _eventBus.PublishMessage(); 
    }

    public void ConsumeMessage()
    {
        _eventBus.ConsumeMessage();
    }

    public ConnectionFactory SetConnection()
    {
        return _eventBus.SetConnection();
    }
}
