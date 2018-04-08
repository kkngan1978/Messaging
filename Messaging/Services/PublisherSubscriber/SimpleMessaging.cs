using Messaging.Services.Common;
using Messaging.Services.PublisherSubscriber.Interfaces;
using System;
using Messaging.Services.MessageMassage;

namespace Messaging.Services.PublisherSubscriber
{
    /// <summary>
    /// Implementation that holds integration between subscriber and publisher for sending messages
    /// </summary>
    public class SimpleMessaging
    {
        public IMessagingPublisher MessagingPublisher;
        public IMessagingSubscriber MessagingSubscriber;

        /// <summary>
        /// This is simple Implementation That will Holds Implementation that will instantiate publisher and subscriber for sending 
        /// messages
        /// </summary>
        /// <param name="errorHandler">Error Log Action Handler Expect to be log</param>
        /// <param name="messageFormatter">An Implementation That Hold Massage Data Implementation</param>
        public void SendMessage(Action<String> errorHandler,
            IMessageFormatter messageFormatter)
        {
            // Instantiate A Publisher
            if (MessagingPublisher == null)
                MessagingPublisher = new MessagingPublisher();

            // Instantiate A Subscriber
            if (MessagingSubscriber == null)
                MessagingSubscriber = new MessagingSubscriber(MessagingPublisher);

            if (MessagingSubscriber.Publisher == null)
            {
                errorHandler(ExceptionCode.SimpleMessaging_NullExceptionThrownForPublisherOverSubscriber);
            }
            else
            {
                MessagingSubscriber.Publisher.DataPublisher += PublisherOnDataPublisher;
                MessagingPublisher.TransformAndPublishData(errorHandler, messageFormatter.MassageData());
            }
        }

        // Implementation That process against Subscriber Act over data
        private void PublisherOnDataPublisher(object sender, string data)
        {
            Console.WriteLine("Subscriber : " + data);
        }
    }
}