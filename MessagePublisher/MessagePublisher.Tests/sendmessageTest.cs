using NUnit.Framework;
using System.Net;
using NSubstitute;
using MessagePublisher.Service;
using RabbitMQ.Client;
using MessagePublisher.Interface;
using MessagePublisher.Models;

namespace MessagePublisher.Tests
{
    public class Tests
    {
        private IPublisher _publishmessage;
        private  IPublisherConnection _rabbitconn;
        private IConnection _connection;
        private IModel _channel;

        [SetUp]
        public void Setup(PublisherConnection rabbitconn, Publisher publishmessage)
        {
            _rabbitconn = rabbitconn;
            _connection = _rabbitconn.getCreateconnection();
            _channel = _connection.CreateModel();
            _publishmessage = publishmessage;
        }


        [Test]
        public void GetMessage_GivenValidPhonebook_ShouldAddPhonebook()
        {
            var message = new MessageEvent { message = "Hi dad", subject = "Family", date = "" };

            var result = _publishmessage.SendMessage(message);
            Assert.True(result);
            Assert.AreEqual(message.subject, "Family");
            Assert.IsNotNull(message);
        }

    }
}