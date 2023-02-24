using Database.ClassLibrary.DataAccess;
using Database.ClassLibrary.DataAccess.Events;
using Database.ClassLibrary.DatabaseFirst;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Index.HPRtree;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using RabbitMQInfrastructure.ClassLibrary;


namespace UserService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        IRabbitMQService _rabbitMQService;
        IUserDal _userDal;


        public UsersController(IRabbitMQService rabbitMQService, IUserDal userDal)
        {
            _rabbitMQService = rabbitMQService;
            _userDal = userDal;
        }



        [HttpGet("Get/{IdUser}")]
        public async Task<IActionResult> Get(int IdUser)
        {

            try
            {

                  var  item = _userDal.Get(p => p.IdUser == Convert.ToInt32(IdUser));

                  return Ok(item);

            }
            catch (Exception)
            {

            }


            return BadRequest();

        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] User user)
        {
            try
            {
                _userDal.Add(user);

                var userEvent = new UserEvent
                {
                    IdUser = user.IdUser,
                    Name = user.Name,
                    Surname = user.Surname,
                    City = user.City,
                    When=user.When,
                    PhoneNumber=user.PhoneNumber,
                    EventType = "UserCreated"
                };

                string status = "created";

                _rabbitMQService.PublishUserCreatedMessage(JsonConvert.SerializeObject(userEvent));

                _rabbitMQService.PublishUserNotificationMessage(JsonConvert.SerializeObject(userEvent));



                return Ok("Created");

            }
            catch (Exception)
            {


            }
            return BadRequest();

        }


        [HttpDelete("Delete/{IdUser}")]
        public async Task<IActionResult> Delete(int IdUser)
        {




            var item = _userDal.GetList().Where(p => p.IdUser == Convert.ToInt32(IdUser)).FirstOrDefault();

                if (item != null)
                {


                    var userEvent = new UserEvent
                    {
                        IdUser = item.IdUser,
                        Name = item.Name,
                        Surname = item.Surname,
                        City = item.City,
                        When = item.When,
                        PhoneNumber = item.PhoneNumber,
                        EventType = "UserDeleted"
                    };

                    string status = "deleted";

                    //_userDal.Delete(item);

                    _rabbitMQService.PublishUserDeletedMessage(JsonConvert.SerializeObject(userEvent));

                    _rabbitMQService.PublishUserNotificationMessage(JsonConvert.SerializeObject(userEvent));


                    return Ok("Deleted");
                }

  
            return BadRequest();

        }

    }
}
