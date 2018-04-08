using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messaging.Services.MessageMassage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Messaging.Tests.Services
{
    [TestClass]
    public class MessageFormatterTest
    {
        [TestMethod]
        public void MessageFormatter_WhenStringProvider_ExpectedDataMassageIsHeld()
        {
            var content = "hello contents";
            var messageFormatter = new MessageFormatter();
            messageFormatter.Content = content;

            var dataAfterMassage = messageFormatter.MassageData();
            Assert.AreNotEqual(content, dataAfterMassage);
        }
    }
}
