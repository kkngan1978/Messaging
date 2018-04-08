using System;

namespace Messaging.Services.PublisherSubscriber.Interfaces
{
    public interface IMessagingPublisher
    {
        event EventHandler<String> DataPublisher;
        void TransformAndPublishData(Action<String> raceActionHandler, String data);
    }
}
