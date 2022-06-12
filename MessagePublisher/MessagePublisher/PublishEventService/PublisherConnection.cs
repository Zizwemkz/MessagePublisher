using MessagePublisher.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher.PublishEventService
{
  public class PublisherConnection
    {
        public ConnectionFactory RabbitmqConnection()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                VirtualHost = "/",
                UserName = "guest",
                Password = "guest"
            };

            return factory;
        }
      

    }
}
