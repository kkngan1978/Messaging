using System;

namespace Messaging.Services.MessageMassage
{
    /// <summary>
    /// General Implementation Wrapper To Extract Data Formatter Increase scalability
    /// </summary>
    public class MessageFormatter : IMessageFormatter
    {
        public string Content { get; set; }
        public string MassageData()
        {
            return Content + " Massage Data Went Here.";
        }
    }
}