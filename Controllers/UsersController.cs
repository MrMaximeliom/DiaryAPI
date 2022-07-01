using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DiaryAPI.Services;
using DiaryAPI.Models;

namespace DiaryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetUsers()
        {
            UserService userService = new();
            List < User > users = userService.GetUsers();
            if(users.Any())
            {
                return NotFound();
            }
            return Ok(users);
        }
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            UserService userService = new();
            userService.CreateUser(user);
            return Ok(user);


        }
        [HttpDelete("{id}")]
        public ActionResult DeleteUsers(int id)
        {
            bool isAnythingOk = false;
            UserService userService = new();

            isAnythingOk = userService.DeleteUser(id);

            if (isAnythingOk)
                return BadRequest();
            return NoContent();
        }
    }
}
 