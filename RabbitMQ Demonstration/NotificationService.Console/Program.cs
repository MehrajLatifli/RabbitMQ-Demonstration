// See https://aka.ms/new-console-template for more information


using Database.ClassLibrary.DataAccess;
using Database.ClassLibrary.DataAccess.Events;
using Database.ClassLibrary.DatabaseFirst;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.Title = "Notification";


    

        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.ExchangeDeclare(exchange: "microservice_exchange", type: ExchangeType.Direct);
        channel.QueueDeclare("usernotification_queue", durable: true, exclusive: false);
        channel.QueueBind("usernotification_queue", "microservice_exchange", "user_notification");

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var userEvent = JsonConvert.DeserializeObject<UserEvent>(message);

            if (userEvent.EventType == "UserCreated")
            {

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"Message received: A user account named {userEvent.Name} with ID {userEvent.IdUser} has been created.");

            }

            if (userEvent.EventType == "UserDeleted")
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"Message received: A user account named {userEvent.Name} with ID {userEvent.IdUser} has been deleted.");


            }

        };

        channel.BasicConsume(queue: "usernotification_queue", autoAck: true, consumer: consumer);


        var connection2 = factory.CreateConnection();
        using var channel2 = connection.CreateModel();

        channel2.ExchangeDeclare(exchange: "microservice_exchange", type: ExchangeType.Direct);
        channel2.QueueDeclare("walletnotification_queue", durable: true, exclusive: false);
        channel2.QueueBind("walletnotification_queue", "microservice_exchange", "wallet_notification");

        var consumer2 = new EventingBasicConsumer(channel);

        consumer2.Received += (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var walletEvent = JsonConvert.DeserializeObject<WalletEvent>(message);

            if (walletEvent.EventType == "WalletCreated")
            {

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"Message received: Wallet with id {walletEvent.IdWallet} has been created. Balance: {walletEvent.Balance}");

            }

            if (walletEvent.EventType == "WalletDeleted")
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"Message received: Wallet with id {walletEvent.IdWallet} has been deleted.");


            }

            if (walletEvent.EventType == "WalletPlus")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine($"Message received: Wallet with id {walletEvent.IdWallet} has been updated. Balance: {walletEvent.Balance}");

            }

            if (walletEvent.EventType == "WalletMinus")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine($"Message received: Wallet with id {walletEvent.IdWallet} has been updated. Balance: {walletEvent.Balance}");

            }


        };

        channel2.BasicConsume(queue: "walletnotification_queue", autoAck: true, consumer: consumer2);


        var connection3 = factory.CreateConnection();
        using var channel3 = connection.CreateModel();

        channel3.ExchangeDeclare(exchange: "microservice_exchange", type: ExchangeType.Direct);
        channel3.QueueDeclare("carttocart_notification_queue", durable: true, exclusive: false);
        channel3.QueueBind("carttocart_notification_queue", "microservice_exchange", "carttocart_notification");

        var consumer3 = new EventingBasicConsumer(channel);

        consumer3.Received += (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var cartToCartEvent = JsonConvert.DeserializeObject<CartToCartEvent>(message);



            if (cartToCartEvent.EventType == "CartToCartCreated")
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine($"Message received: User with ID {cartToCartEvent.ReceiverUserIdForCartToCart} sent User with ID {cartToCartEvent.SenderUserIdForCartToCart} {cartToCartEvent.Amount}");



            }

            if (cartToCartEvent.EventType == "CartToCartRequest")
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine($"Message received: User with ID {cartToCartEvent.ReceiverUserIdForCartToCart} request {cartToCartEvent.Amount} from  User with ID {cartToCartEvent.SenderUserIdForCartToCart} {cartToCartEvent.Amount}");



            }



        };

        channel3.BasicConsume(queue: "carttocart_notification_queue", autoAck: true, consumer: consumer3);


        Console.ReadKey();

    }
}
