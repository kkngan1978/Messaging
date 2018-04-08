using Messaging.Services.Common;
using Messaging.Services.PublisherSubscriber;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Messaging.Tests.Services
{
    [TestClass]
    public class MessagingPublisherTest : MessagingBase
    {
        [TestMethod]
        public void MessagingPublisher_WhenEventHandlerOverPublisherWasNotSet_ExpectExceptionThrown()
        {
            MessagingPublisher messagingPublisher = new MessagingPublisher();

            messagingPublisher.TransformAndPublishData((data) => { ErrorLog = data; }, "message");

            Assert.AreEqual(ExceptionCode.MessagingPublisher_PublisherNotSetOrThreadRacing, ErrorLog);
        }

        [TestMethod]
        public void MessagingPublisher_WhenEventHandlerOverPublisherWasSet_ExpectWorkingFine()
        {
            MessagingPublisher messagingPublisher = new MessagingPublisher();

            messagingPublisher.DataPublisher += (object sender, string e) => { };
            messagingPublisher.TransformAndPublishData((data) => { ErrorLog = data; }, "message");

            Assert.AreEqual("", ErrorLog);
        }
    }
}
