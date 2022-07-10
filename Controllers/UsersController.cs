using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DiaryAPI.Services;
using DiaryAPI.UOW;
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
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Returns list of users limited by count number 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetUsers(int count)
        {

            IEnumerable<User> users = _unitOfWork.Users.GetAll();
            if(!users.Any())
            {
                return NotFound();
            }
            return Ok(users);
        }
 
        /// <summary>
        /// Returns a user by its id 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Users/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetUserById(int id)
        {
            User? fetchedUser = _unitOfWork.Users.GetById(id);
            if(fetchedUser != null)
            {
                return Ok(fetchedUser);

            }
            else
            {
                return NotFound();

            }
        }
        /// <summary>
        /// Creates a user    
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreateUser([FromBody] User user)
        {
            User newUser = _unitOfWork.Users.Add(user);
            if (newUser != null)
            {
                _unitOfWork.Complete();
                return Created("User Added Successfully", user);

            }
                
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
           
            User? user = _unitOfWork.Users.GetById(id);

            if (user != null)
            {
                userUpdates.ApplyTo(user);
                _unitOfWork.Users.Update(user);
                _unitOfWork.Complete();
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

            User deletedUser = _unitOfWork.Users.GetById(id);
            if(deletedUser != null)
            {
              _unitOfWork.Users.Delete(deletedUser);
                _unitOfWork.Complete();
                return NoContent();


            }
            else
            {
                return BadRequest();

            }
        }
    }
}
 