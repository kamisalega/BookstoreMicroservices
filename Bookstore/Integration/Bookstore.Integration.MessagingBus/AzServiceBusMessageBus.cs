using System;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Integration.Messages;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Newtonsoft.Json;

namespace Bookstore.Integration.MessagingBus
{
    public class AzServiceBusMessageBus : IMessageBus
    {
        private ISenderClient _topicClient;
        //TODO: read from settings
        private string connectionString =
            "Endpoint=sb://bookstore-sample.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=6jtcZwr83MmNl3V2Int0evsH95snmUTHEDhlsrTeiN8=";

        public async Task PublishMessage(IntegrationBaseMessage message, string topicName)
        {
            _topicClient = new TopicClient(connectionString, topicName);

            var jsonMessage = JsonConvert.SerializeObject(message);
            var serviceBusMessage = new Message(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString()
            };

            await _topicClient.SendAsync(serviceBusMessage);
            Console.WriteLine($"Sent message to {_topicClient.Path}");
            await _topicClient.CloseAsync();
        }
    }
}
