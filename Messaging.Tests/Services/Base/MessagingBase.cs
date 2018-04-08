using System;
using Messaging.Services.MessageMassage;

namespace Messaging.Tests.Services
{
    public class MessagingBase
    {
        public readonly String Message = "Hello, My Message.";
        public IMessageFormatter Formatter = new MessageFormatter();
        public String ErrorLog = "";
    }
}
