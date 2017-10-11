using PosRi.BusinessLogic.Dtos;
using PosRi.BusinessLogic.Managers;
using PosRi.BusinessLogic.Utils;
using System.Web.Http;

namespace PosRi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            UserManager userManager = new UserManager();
            return Ok(userManager.GetUsers());
        }

        [HttpPost]
        public IHttpActionResult AddUser(UserDto user)
        {
            UserManager userManager = new UserManager();
            string message;
            if (userManager.IsValid(MethodTypes.Post, user, out message))
            {
                var newUser = userManager.AddUser(user, out message);
                if (newUser != null)

                    return Ok(newUser);
                }
            
            return BadRequest(message);

        }

        [HttpPut]
        public IHttpActionResult UpdateUser(UserDto user)
        {
            UserManager userManager = new UserManager();
            string message;
            if (userManager.IsValid(MethodTypes.Put, user, out message))
            {
                var userUpdated = userManager.UpdateUser(user, out message);
                if (userUpdated != null)
                {
                    return Ok(userUpdated);
                }
            }

            return BadRequest(message);
        }

        [HttpDelete]
        [Route("{userId}")]
        public IHttpActionResult DeleteUser(int userId)
        {
            UserManager userManager = new UserManager();
            string message;
            var user = new UserDto {Id = userId};
            if (userManager.IsValid(MethodTypes.Delete, user, out message))
            {
                if (userManager.DeleteUser(user, out message))
                    return Ok();

            };
            return BadRequest(message);
        }
    }
}
