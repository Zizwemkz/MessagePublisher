using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MessagePublisher.Models;
using RabbitMQ.Client;
using System;
using System.Text;
using Newtonsoft.Json;
using MessagePublisher.Interface;

namespace MessagePublisher.Service
{
   public class Publisher : IPublisher
    {
        private readonly PublisherConnection _rabbitconn;
        private IConnection _connection;
        private IModel _channel;

        public Publisher(PublisherConnection rabbitconn)
        {
            _rabbitconn = rabbitconn;
            _connection = _rabbitconn.getCreateconnection();
            _channel = _connection.CreateModel();

        }

        public bool SendMessage(MessageEvent message)
        {
            var status = false;
            try
            {

                _channel.ExchangeDeclare("streamer_job", "fanout", true, false, null);
                _channel.QueueDeclare("Department_1", true, false, false, null);

                _channel.QueueBind("Department_1", "streamer_job", "");

                var rawContent = JsonConvert.SerializeObject(message);
                var encodedContent = Encoding.UTF8.GetBytes(rawContent);

                _channel.BasicPublish("streamer_job", "Department_1", null, encodedContent);

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
