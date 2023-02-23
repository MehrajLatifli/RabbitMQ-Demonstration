using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQInfrastructure.ClassLibrary
{
    public interface IRabbitMQService
    {
        void PublishUserCreatedMessage(string message);
        void PublishUserDeletedMessage(string message);
        void PublishUserNotificationMessage(string message);

        void PublishWalletNotificationMessage(string message);

        void PublishCartToCartNotificationMessage(string message);
    }
}
