using Newtonsoft.Json;
using Rabbit.BLL.RabbitMq;
using Rabbit.BLL.Repository;
using Rabbit.Models.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Generic;
using System.Text;

namespace Rabbit.Consumer
{
    public class Consumer
    {
        private readonly RabbitMqService _rabbitMqService;
        public EventingBasicConsumer ConsumerEvent;
        public Consumer(string queueName)
        {
            _rabbitMqService = new RabbitMqService();
            var connection = _rabbitMqService.GetRabbitMqConnection();
            var channel = connection.CreateModel();
            ConsumerEvent = new EventingBasicConsumer(channel);
            ConsumerEvent.Received += (model, ea) =>
              {
                  var body = ea.Body;
                  var message = Encoding.UTF8.GetString(body);
                  if (queueName == "MailLog")
                  {
                      var data = JsonConvert.DeserializeObject<List<MailLog>>(message);
                  }
                  else if (queueName == "Customer")
                  {
                      var data = JsonConvert.DeserializeObject<List<Customer>>(message);
                      var repo = new CustomerRepo();

                      foreach (var customer in data)
                      {
                          repo.Insert(new Customer()
                          {
                              Address=customer.Address,
                              Email=customer.Email,
                              Id=customer.Id,
                              Name=customer.Name,
                              Phone=customer.Phone,
                              Surname=customer.Surname,
                              RegisterDate=customer.RegisterDate
                          });
                      }
                  }
              };
            channel.BasicConsume(queueName, true, ConsumerEvent);
        }
    }
}
