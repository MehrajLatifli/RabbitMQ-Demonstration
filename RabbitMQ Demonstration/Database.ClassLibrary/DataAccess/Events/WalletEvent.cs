using Database.ClassLibrary.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ClassLibrary.DataAccess.Events
{
    public class WalletEvent
    {
        public int IdWallet { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public int UserIdForWallet { get; set; }

        public string EventType { get; set; }

    }
}
