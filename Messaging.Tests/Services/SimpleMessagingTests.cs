using Messaging.Services.PublisherSubscriber;
using Messaging.Services.PublisherSubscriber.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using Messaging.Services.Common;

namespace Messaging.Tests.Services
{
    [TestClass]
    public class SimpleMessagingTests : MessagingBase
    {
        [TestMethod]
        public void PublisherSubscriberTestAgainstPublisherClasss_WhenSubscriberDoesntSetupAccordingly_ExpectPublisherTransformAndPublishDataNotSentAndErrorLogAttached()
        {
            // Arrange
            var mockMessaging = MockRepository.GenerateMock<SimpleMessaging>();
            var mockMessagingPublisher = MockRepository.GenerateMock<IMessagingPublisher>();
            var mockMessagingSubscriber = MockRepository.GenerateMock<IMessagingSubscriber>(null);

            // Act
            mockMessaging.MessagingPublisher = mockMessagingPublisher;
            mockMessaging.MessagingSubscriber = mockMessagingSubscriber;

            mockMessaging.SendMessage((data) => { ErrorLog = data; }, Formatter);

            Assert.AreEqual(ExceptionCode.SimpleMessaging_NullExceptionThrownForPublisherOverSubscriber, ErrorLog);
            
            // Assert
            Assert.IsNull(mockMessaging.MessagingSubscriber.Publisher);
            mockMessaging.MessagingPublisher.AssertWasNotCalled(x => x.TransformAndPublishData(Arg<Action<String>>.Is.Anything, Arg<String>.Is.Anything));
        }

        [TestMethod]
        public void PublisherSubscriberTestAgainstPublisherClasss_WhenPubsliherAndSubscriberWasSetupCorrectly_ExpectPublisherTransformAndPublishDataAndSubScriber()
        {
            // Arrange
            var mockMessaging = MockRepository.GenerateMock<SimpleMessaging>();
            var mockMessagingPublisher = MockRepository.GenerateMock<IMessagingPublisher>();
            var mockMessagingSubscriber = MockRepository.GenerateMock<IMessagingSubscriber>();

            // Act
            mockMessaging.MessagingPublisher = mockMessagingPublisher;
            mockMessagingSubscriber.Stub(x => x.Publisher).Return(mockMessagingPublisher);
            mockMessaging.MessagingPublisher.Stub(x => x.DataPublisher += Arg<EventHandler<String>>.Is.Anything);

            mockMessaging.MessagingSubscriber = mockMessagingSubscriber;
            mockMessaging.SendMessage((data) => { ErrorLog = data; }, Formatter);
            
            Assert.AreEqual("", ErrorLog);

            // Assert
            Assert.IsNotNull(mockMessaging.MessagingSubscriber.Publisher);
            mockMessaging.MessagingPublisher.AssertWasCalled(x => x.TransformAndPublishData(Arg<Action<String>>.Is.Anything, Arg<String>.Is.Anything));
            mockMessaging.MessagingSubscriber.AssertWasCalled(x => x.Publisher.DataPublisher += Arg<EventHandler<String>>.Is.Equal(Message));
        }
    }
}
