using Messaging.Services.PublisherSubscriber.Interfaces;
using System;
using Messaging.Services.Common;

namespace Messaging.Services.PublisherSubscriber
{
    /// <summary>
    /// Publisher Class provide Implementation of subscriber for attaching
    /// them selves to this event for listening
    /// </summary>
    public class MessagingPublisher : IMessagingPublisher
    {
        // A Delegate Action For Logging Error Purpose
        private Action<String> _raceHandler;

        // Event which will be dispatch to subscriber for listening
        public event EventHandler<String> DataPublisher;
        
        private void OnDataPublisher(String args)
        {
            var handler = DataPublisher;

            // Do not replace this with null progation
            // as threading race might happens.
            if (handler != null)
                handler(this, args);
            else
                _raceHandler(ExceptionCode.MessagingPublisher_PublisherNotSetOrThreadRacing);
        }

        /// <summary>
        /// Implementation For Handling Transform Data And Publish Data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="raceActionHandler"></param>
        public void TransformAndPublishData(Action<String> raceActionHandler, String data)
        {
            _raceHandler = raceActionHandler;
            OnDataPublisher(data);
        }
    }
}