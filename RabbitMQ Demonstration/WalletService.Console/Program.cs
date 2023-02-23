using Database.ClassLibrary.DataAccess;
using Database.ClassLibrary.DataAccess.Events;
using Database.ClassLibrary.DatabaseFirst;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQInfrastructure.ClassLibrary;
using System.Text;

internal class Program
{

    private static void Main(string[] args)
    {
        var item = new Wallet();



        Console.Title = "Wallet";


        IWalletDal _walletDal = new EfWalletDal();

        IUserDal _userDal = new EfUserDal();
        IRabbitMQService _rabbitMQService= new RabbitMQService();

        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.ExchangeDeclare(exchange: "microservice_exchange", type: ExchangeType.Direct);
        channel.QueueDeclare("wallet_queue", durable: true, exclusive: false);
        channel.QueueBind("wallet_queue", "microservice_exchange", "user_created");

        var consumer = new EventingBasicConsumer(channel);


        consumer.Received += (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var userEvent = JsonConvert.DeserializeObject<UserEvent>(message);

            if (userEvent.EventType == "UserCreated")
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("I start to create new wallets for the recently created user");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"Message received: {message}");

                Random random = new Random();
                int[] a = Enumerable.Range(100, 5000).OrderBy(b => random.Next()).ToArray();

                var wallet = new Wallet
                {
                    Currency = "AZN",
                    Balance = a.ElementAt(0),
                    UserIdForWallet = userEvent.IdUser
                };

                _walletDal.Add(wallet);


                var walletEvent = new WalletEvent
                {
                    IdWallet= wallet.IdWallet,
                    Currency = "AZN",
                    Balance = a.ElementAt(0),
                    UserIdForWallet = userEvent.IdUser,
                    EventType= "WalletCreated"
                };

                _rabbitMQService.PublishWalletNotificationMessage(JsonConvert.SerializeObject(walletEvent));



            }

        };

        channel.BasicConsume(queue: "wallet_queue", autoAck: true, consumer: consumer);


        var connection2 = factory.CreateConnection();
        using var channel2 = connection.CreateModel();

        channel2.ExchangeDeclare(exchange: "microservice_exchange", type: ExchangeType.Direct);
        channel2.QueueDeclare("wallet_queue2", durable: true, exclusive: false);
        channel2.QueueBind("wallet_queue2", "microservice_exchange", "user_deleted");

        var consumer2 = new EventingBasicConsumer(channel);

        consumer2.Received += (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var userEvent = JsonConvert.DeserializeObject<UserEvent>(message);

            if (userEvent.EventType == "UserDeleted")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("I start to delete  wallets for created user");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"Message received: {message}");

                


                    var item = _walletDal.GetList().Where(p => p.UserIdForWallet == userEvent.IdUser).FirstOrDefault();


                if (item != null)
                {

                    var walletEvent = new WalletEvent
                    {
                        IdWallet = item.IdWallet,
                        Currency = item.Currency,
                        Balance = item.Balance,
                        UserIdForWallet = item.UserIdForWallet,
                        EventType = "WalletDeleted"
                    };

                    var item2 = _userDal.GetList().Where(p => p.IdUser == Convert.ToInt32(item.UserIdForWallet)).FirstOrDefault();


                    if (item2 != null)
                    {
                        _walletDal.Delete(item);



                        _userDal.Delete(item2);


                        _rabbitMQService.PublishWalletNotificationMessage(JsonConvert.SerializeObject(walletEvent));

                    }
                }
                
           
            }


        };

       
        channel2.BasicConsume(queue: "wallet_queue2", autoAck: true, consumer: consumer2);



        var connection3 = factory.CreateConnection();
        using var channel3 = connection.CreateModel();

        channel3.ExchangeDeclare(exchange: "microservice_exchange", type: ExchangeType.Direct);
        channel3.QueueDeclare("wallet_queue3", durable: true, exclusive: false);
        channel3.QueueBind("wallet_queue3", "microservice_exchange", "carttocart_notification");

        var consumer3 = new EventingBasicConsumer(channel3);


        consumer3.Received += (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var cartToCartEvent = JsonConvert.DeserializeObject<CartToCartEvent>(message);

            if (cartToCartEvent.EventType == "CartToCartCreated")
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Wallets updated.");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"Message received: {message}");

                var item = _walletDal.GetList().Where(p => p.UserIdForWallet == cartToCartEvent.ReceiverUserIdForCartToCart).FirstOrDefault();


                if (item != null)
                {
                    item.Balance += cartToCartEvent.Amount - cartToCartEvent.Fee;

                    var wallet = new Wallet
                    {
                        IdWallet= item.IdWallet,
                        Currency = item.Currency,
                        Balance = item.Balance,
                        UserIdForWallet = item.UserIdForWallet
                    };

                    _walletDal.Update(wallet);

                    var walletEvent = new WalletEvent
                    {
                        IdWallet = wallet.IdWallet,
                        Currency = wallet.Currency,
                        Balance = wallet.Balance,
                        UserIdForWallet = wallet.UserIdForWallet,
                        EventType = "WalletPlus"
                    };

                    _rabbitMQService.PublishWalletNotificationMessage(JsonConvert.SerializeObject(walletEvent));

                }


                var item2 = _walletDal.GetList().Where(p => p.UserIdForWallet == cartToCartEvent.SenderUserIdForCartToCart).FirstOrDefault();

                if (item2 != null)
                {



                    item2.Balance -= cartToCartEvent.Amount - cartToCartEvent.Fee;

                    var wallet2 = new Wallet
                    {
                        IdWallet = item2.IdWallet,
                        Currency = item2.Currency,
                        Balance = item2.Balance,
                        UserIdForWallet = item2.UserIdForWallet,
                    };

                    _walletDal.Update(wallet2);



                    var walletEvent2 = new WalletEvent
                    {
                        IdWallet = item2.IdWallet,
                        Currency = item2.Currency,
                        Balance = item2.Balance,
                        UserIdForWallet = item2.UserIdForWallet,
                        EventType = "WalletMinus"
                    };

                    _rabbitMQService.PublishWalletNotificationMessage(JsonConvert.SerializeObject(walletEvent2));

                }
            }

        };

        channel3.BasicConsume(queue: "wallet_queue3", autoAck: true, consumer: consumer3);



        Console.ReadKey();
    }
}