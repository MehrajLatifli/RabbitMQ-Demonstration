using Database.ClassLibrary.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ClassLibrary.DataAccess
{
    public class EfUserDal : EF_EntityRepositoryBase<User, RabbitMQ_DbContext>, IUserDal
    {
    }
}
