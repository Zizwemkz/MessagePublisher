using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher.Interface
{
   public interface IPublisherConnection
    {
        public ConnectionFactory getfactoryConnection();
        public IConnection getCreateconnection();
        public IModel getCreatemodel();
    }
}
