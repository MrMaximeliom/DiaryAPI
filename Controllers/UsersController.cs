using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DiaryAPI.Services;
using DiaryAPI.Models;
using DiaryAPI.Data;
using Microsoft.AspNetCore.JsonPatch;
using System.Net.Mime;

namespace DiaryAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]

    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Returns a user for a given id   
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetUsers(int count)
        {
            UserService userService = new();
            List < User > users = userService.GetUsers(count);
            if(!users.Any())
            {
                return NotFound();
            }
            return Ok(users);
        }
        /// <summary>
        /// Creates a user    
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreateUser([FromBody] User user)
        {
            UserService userService = new();
           bool isUserAdded =  userService.CreateUser(user);
            if (isUserAdded)
                return Created("User Added Successfully", user);
            else
                return BadRequest();


        }
        /// <summary>
        /// Edits a user by its id
        /// </summary>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdateUser(int id,JsonPatchDocument<User> userUpdates)
        {
            DBContext context = new();
            User? user = context.Users.Find(id);
            if (user != null)
            {
                userUpdates.ApplyTo(user);
                context.Users.Update(user);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
            
        }
        /// <summary>
        /// Deletes a user with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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
 