using System;

namespace Messaging.Services.Common
{
    public static class ExceptionCode
    {
        public const String SimpleMessaging_NullExceptionThrownForPublisherOverSubscriber =
            @"Publisher over Subscriber was null";

        public const String MessagingPublisher_PublisherNotSetOrThreadRacing = "Event Handler over Publisher Is Not Set or Racing issues over Multi Thread";
    }
}