using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ClassLibrary.DataAccess.Events
{
    public class CartToCartEvent
    {
        public int IdCartToCart { get; set; }
        public decimal Amount { get; set; }
        public int SenderUserIdForCartToCart { get; set; }
        public int ReceiverUserIdForCartToCart { get; set; }

        public decimal Fee { get; set; }

        public string EventType { get; set; }
    }
}
