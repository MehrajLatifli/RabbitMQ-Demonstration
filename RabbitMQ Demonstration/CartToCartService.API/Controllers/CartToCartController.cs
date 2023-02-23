using Database.ClassLibrary.DataAccess;
using Database.ClassLibrary.DataAccess.Events;
using Database.ClassLibrary.DatabaseFirst;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQInfrastructure.ClassLibrary;

namespace CartToCartService.API.Controllers
{
    public class CartToCartController : Controller
    {
        IRabbitMQService _rabbitMQService;
        ICartToCartDal _cartToCartDal;

        public CartToCartController(IRabbitMQService rabbitMQService, ICartToCartDal cartToCartDal)
        {
            _rabbitMQService = rabbitMQService;
            _cartToCartDal = cartToCartDal;
        }

        [HttpPost("SendMoney")]
        public async Task<IActionResult> SendMoney([FromBody] CartToCart cartToCart)
        {
            try
            {

                var cartToCartEvent = new CartToCartEvent
                {
                    IdCartToCart = cartToCart.IdCartToCart,
                    Amount = cartToCart.Amount,
                    SenderUserIdForCartToCart = cartToCart.SenderUserIdForCartToCart,
                    ReceiverUserIdForCartToCart = cartToCart.ReceiverUserIdForCartToCart,
                    Fee = cartToCart.Amount * 0.01M/100,
                    EventType = "CartToCartCreated"
                };


                _cartToCartDal.Add(cartToCart);

                _rabbitMQService.PublishCartToCartNotificationMessage(JsonConvert.SerializeObject(cartToCartEvent));



                return Ok("Send Money");

            }
            catch (Exception)
            {


            }
            return BadRequest();

        }

        [HttpPost("RequestMoney")]
        public async Task<IActionResult> RequestMoney([FromBody] CartToCart cartToCart)
        {
            try
            {


                var cartToCartEvent = new CartToCartEvent
                {
                    IdCartToCart = cartToCart.IdCartToCart,
                    Amount = cartToCart.Amount,
                    SenderUserIdForCartToCart = cartToCart.SenderUserIdForCartToCart,
                    ReceiverUserIdForCartToCart = cartToCart.ReceiverUserIdForCartToCart,
                    Fee = cartToCart.Amount * 0.01M / 100,
                    EventType = "CartToCartRequest"
                };



                _rabbitMQService.PublishCartToCartNotificationMessage(JsonConvert.SerializeObject(cartToCartEvent));



                return Ok("Request Money");

            }
            catch (Exception)
            {


            }
            return BadRequest();

        }

    }
}
