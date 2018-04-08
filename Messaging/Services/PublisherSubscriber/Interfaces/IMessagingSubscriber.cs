namespace Messaging.Services.PublisherSubscriber.Interfaces
{
    public interface IMessagingSubscriber
    {
        IMessagingPublisher Publisher { get; }
    }
}
