using Messaging.Services.PublisherSubscriber;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Messaging.Tests.Services
{
    [TestClass]
    public class MessagingSubscriberTests
    {
        [TestMethod]
        public void MessagingSubscriber_WhenContructorReceivePublisher_ExpectPublisherWillAssignAccordingly()
        {
            // Act
            var messagingPublisher = new MessagingPublisher();

            // Arrange
            var messagingSubscriber = new MessagingSubscriber(messagingPublisher);

            // Assert
            Assert.IsNotNull(messagingSubscriber.Publisher);
        }
    }
}
