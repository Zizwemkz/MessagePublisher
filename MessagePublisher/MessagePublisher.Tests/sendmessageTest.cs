using NUnit.Framework;
using System.Net;
using NSubstitute;
using MessagePublisher.Service;
using RabbitMQ.Client;
using MessagePublisher.Interface;
using MessagePublisher;
using MessagePublisher.Models;

namespace MessagePublisher.Tests
{
    public class Tests
    {
        private IPublisher _publishmessage;
        //private  IPublisherConnection _rabbitconn;
        private RabbitMQ.Client.IConnection _connection;
        private IModel _channel;

        [SetUp]
        public void Setup(Publisher publishmessage)
        {
            //PublisherConnection rabbitconn
            //_rabbitconn = rabbitconn;
            //_connection = _rabbitconn.getCreateconnection();
            //_channel = _connection.CreateModel();
            _publishmessage = publishmessage;
        }


        [Test]
        public void GetMessage_GivenValidPhonebook_ShouldAddPhonebook()
        {
            // Arrange
            var message = new MessageEvent { message = "Hi dad", subject = "Family", date = "" };

            // Act
            var result = _publishmessage.SendMessage(message);

            //Assort
            Assert.True(result);
            Assert.AreEqual(message.subject, "Family");
            Assert.IsNotNull(message);
        }

    }
}