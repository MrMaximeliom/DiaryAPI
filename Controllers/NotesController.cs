using DiaryAPI.Models;
using DiaryAPI.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace DiaryAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Returns list of notes limited by count number 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetNotes()
        {

            IEnumerable<Note> notes = _unitOfWork.Notes.GetAll();
            if (!notes.Any())
            {
                return NotFound();
            }
            return Ok(notes);
        }

        /// <summary>
        /// Returns a note by its id 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Notes/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetNoteById(int id)
        {
            Note? fetchedNote = _unitOfWork.Notes.GetById(id);
            if (fetchedNote != null)
            {
                return Ok(fetchedNote);

            }
            else
            {
                return NotFound();

            }
        }
        /// <summary>
        /// Creates a note    
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreateUser([FromBody] Note note)
        {
            Note newNote = _unitOfWork.Notes.Add(note);
            if (newNote != null)
            {
                _unitOfWork.Complete();
                return Created("Note Added Successfully", note);

            }

            else
                return BadRequest();


        }
        /// <summary>
        /// Edits a note by its id
        /// </summary>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdateNote(int id, JsonPatchDocument<Note> noteUpdates)
        {

            Note? note = _unitOfWork.Notes.GetById(id);

            if (note != null)
            {
                noteUpdates.ApplyTo(note);
                _unitOfWork.Notes.Update(note);
                _unitOfWork.Complete();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }
        /// <summary>
        /// Deletes a note with a given id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult DeleteNotes(int id)
        {

            Note deletedNote = _unitOfWork.Notes.GetById(id);
            if (deletedNote != null)
            {
                _unitOfWork.Notes.Delete(deletedNote);
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
