using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureEventHub
{
    public static class EventDataExtension

    {

        public static void SetEventName(this EventData eventData, string eventName)
        {

            SetPropertyValue(eventData, "eventName", eventName);

        }

        private static void SetPropertyValue(EventData eventData, string propertyName, object value)
        {
            eventData.Properties[propertyName] = value;
        }

        public static void SetReceivedAt(this EventData eventData, long receivedAt)
        {
            SetPropertyValue(eventData, "receivedAt", receivedAt);
        }

    }
}
