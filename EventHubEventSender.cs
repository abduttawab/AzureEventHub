
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace AzureEventHub
{
    public class EventHubEventSender
    {
        string connectionString = "—- Get key from azure queue ->Shared access key------  From APP SET - —";
        string eventHubName = "—-Event hub name-------  From APP SET - ";

        public async Task SendEventAsync(JArray events, string deviceId)
        {

            if (events.Count > 0)
            {

                var client = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);

                foreach (dynamic eventObj in events)
                {
                    var json = eventObj.ToString(Newtonsoft.Json.Formatting.None);
                    EventData eventData = new EventData(Encoding.UTF8.GetBytes(json))
                    {

                        PartitionKey = deviceId
                    };

                    eventData.SetEventName((string)eventObj.eventName);
                    eventData.SetReceivedAt((long)eventObj.receivedAt);

                    await client.SendAsync(eventData);
                }



            }


        }
    }
}
