using Database.ClassLibrary.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ClassLibrary.DataAccess
{
    public class EfCartToCartDal : EF_EntityRepositoryBase<CartToCart, RabbitMQ_DbContext>, ICartToCartDal
    {
    }
}
