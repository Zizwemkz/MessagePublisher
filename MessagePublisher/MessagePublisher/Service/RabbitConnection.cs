using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using MessagePublisher.Service;
using MessagePublisher.Interface;
using MessagePublisher.Models;

namespace MessagePublisher.Service
{
    public class RabbitConnection : IRabbitConnection
    {
        public RabbitConnection()
        {
         
        }

        public IModel getSetUpConnecion()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                VirtualHost = "/",
                UserName = "guest",
                Password = "guest"
            };
            var _connection = factory.CreateConnection();
            var _channel = _connection.CreateModel();

            return _channel;
        }

        public void FanoutExchangPublisher(ReadOnlyMemory<byte> message)
        {
            var setupconn = getSetUpConnecion();
            setupconn.ExchangeDeclare("streamer_job", "fanout", true, false, null);
            setupconn.QueueDeclare("Department_1", true, false, false, null);

            setupconn.QueueBind("Department_1", "streamer_job", "");
            setupconn.BasicPublish("streamer_job", "Department_1", null, message); 
        }
    }
}
