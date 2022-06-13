using MessagePublisher.Interface;
using MessagePublisher.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher.Service
{
  public class PublisherConnection : IPublisherConnection
    {
        public ConnectionFactory getfactoryConnection()
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

        public IConnection getCreateconnection()
        {
            var _connection = getfactoryConnection().CreateConnection();
            return _connection;
        }

        public IModel getCreatemodel()
        {
            var _connection = getCreateconnection().CreateModel();
            return _connection;
        }


    }
}
