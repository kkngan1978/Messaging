using System;
using Messaging.Services.PublisherSubscriber.Interfaces;

namespace Messaging.Services.PublisherSubscriber
{
    /// <summary>
    /// Subscriber receive message from publisher
    /// </summary>
    public class MessagingSubscriber : IMessagingSubscriber
    {
        public IMessagingPublisher Publisher { get; }
        
        public MessagingSubscriber(IMessagingPublisher publisher)
        {
            Publisher = publisher;
        }
    }
}