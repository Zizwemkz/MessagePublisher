using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using MessagePublisher.Service;

namespace MessagePublisher.Service
{
    public class RabbitConnection
    {
        private readonly PublisherConnection _rabbitconn;
        public RabbitConnection(PublisherConnection rabbitconn)
        {
            _rabbitconn = rabbitconn;
        }
        public IConnection getCreateconnection()
        {
            var _connection = _rabbitconn.getfactoryConnection().CreateConnection();
            return _connection;
        }

        public IModel getCreatemodel()
        {
            var _connection = getCreateconnection().CreateModel();
            return _connection;
        }

    }
}
