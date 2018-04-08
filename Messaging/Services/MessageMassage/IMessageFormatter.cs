using System;

namespace Messaging.Services.MessageMassage
{
    public interface IMessageFormatter
    {
        String Content { get; set; }

        String MassageData();
    }
}