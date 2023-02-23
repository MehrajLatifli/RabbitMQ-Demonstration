using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQInfrastructure.ClassLibrary
{
    public class RabbitMQService : IRabbitMQService
    {
        public void PublishUserCreatedMessage(string message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel())
            {

                channel.ExchangeDeclare(exchange: "microservice_exchange", type: ExchangeType.Direct);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "microservice_exchange",
                    routingKey: "user_created",
                    basicProperties: null,
                    body: body);
            };
        }

        public void PublishUserDeletedMessage(string message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel())
            {

                channel.ExchangeDeclare(exchange: "microservice_exchange", type: ExchangeType.Direct);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "microservice_exchange",
                    routingKey: "user_deleted",
                    basicProperties: null,
                    body: body);
            };
        }


        public void PublishUserNotificationMessage(string message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };


            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "microservice_exchange", type: ExchangeType.Direct);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "microservice_exchange",
                routingKey: "user_notification",
                basicProperties: null,
                body: body);
        }

        public void PublishWalletNotificationMessage(string message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };


            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "microservice_exchange", type: ExchangeType.Direct);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "microservice_exchange",
                routingKey: "wallet_notification",
                basicProperties: null,
                body: body);
        }

        public void PublishCartToCartNotificationMessage(string message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };


            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "microservice_exchange", type: ExchangeType.Direct);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "microservice_exchange",
                routingKey: "carttocart_notification",
                basicProperties: null,
                body: body);
        }
    }
}
