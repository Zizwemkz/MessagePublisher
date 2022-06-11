using System;
using System.Text;
using RabbitMQ.Client;

namespace MessagePublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            IConnection conn;
            IModel channel;


            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.Port = 5672;
            factory.VirtualHost = "/";
            factory.UserName = "guest";
            factory.Password = "guest";

            conn = factory.CreateConnection();
            channel = conn.CreateModel();

            channel.ExchangeDeclare("streamer_job", "fanout", true, false, null);

            channel.QueueDeclare("Department_1", true, false, false, null);

            channel.QueueBind("Testqueue", "streamer_job", "");
            channel.QueueBind("Department_1", "streamer_job", "");

            channel.BasicPublish("streamer_job", "", null, Encoding.UTF8.GetBytes("mesage sent currently 12"));

            //channel.QueueDelete("Postexchange");
            //channel.QueueDelete("Department_1");
            //channel.QueueDelete("Department_2");

            //channel.Close();
            //conn.Close();
        }
    }
}
