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
        private readonly Interface.IRabbitConnection _channel;

        public Publisher(Interface.IRabbitConnection channel)
        {
            _channel = channel;
        }

        public bool SendMessage(MessageEvent message)
        {
            var status = false;
            try
            {
                var rawContent = JsonConvert.SerializeObject(message);
                var encodedContent = Encoding.UTF8.GetBytes(rawContent);
                _channel.FanoutExchangPublisher(encodedContent);
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
