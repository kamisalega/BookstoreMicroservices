using System.Threading.Tasks;
using Bookstore.Integration.Messages;

namespace Bookstore.Integration.MessagingBus
{
    public interface IMessageBus
    {
        Task PublishMessage (IntegrationBaseMessage message, string topicName);
    }
}
