using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MessagePublisher.Models;
using RabbitMQ.Client;
using System;
using System.Text;
using Newtonsoft.Json;

namespace MessagePublisher.PublishEventService
{
   public class Publisher
    {
        public bool SendMessage(MessageEvent message)
        {
            PublisherConnection conn =  new PublisherConnection();
            var factory = conn.RabbitmqConnection();
            var status = false;

            try
            {
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.ExchangeDeclare("streamer_job", "fanout", true, false, null);
                        channel.QueueDeclare("Department_1", true, false, false, null);

                        channel.QueueBind("Department_1", "streamer_job", "");

                        var rawContent = JsonConvert.SerializeObject(message);
                        var encodedContent = Encoding.UTF8.GetBytes(rawContent);

                        channel.BasicPublish("streamer_job", "Department_1", null, encodedContent);
                    }
                }

                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return status;
        }
    }
}
