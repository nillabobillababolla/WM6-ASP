using Rabbit.BLL.RabbitMq;
using RabbitMQ.Client;
using System.Text;

namespace Rabbit.Web.MVC.Models
{
    public class Publisher
    {
        private readonly RabbitMqService _rabbitMQService;
        private const string DefaultQueue = "wissen1";
        public Publisher(string message, string queueName = null)
        {
            if (string.IsNullOrEmpty(queueName))
            {
                queueName = DefaultQueue;
            }
            _rabbitMQService = new RabbitMqService();
            using (var connection = _rabbitMQService.GetRabbitMqConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);
                    channel.BasicPublish(string.Empty, queueName, null, Encoding.UTF8.GetBytes(message));
                }
            }
        }
    }
}