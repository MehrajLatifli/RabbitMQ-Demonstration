using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ClassLibrary.DataAccess.Events
{
    public class UserEvent
    {

        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public DateTime? When { get; set; }
        public string PhoneNumber { get; set; }

        public string EventType { get; set; }
    }
}
