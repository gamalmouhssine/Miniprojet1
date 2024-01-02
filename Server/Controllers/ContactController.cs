using Microsoft.AspNetCore.Mvc;
using Miniprojet.Server.AppDbcontext;
using Miniprojet.Server.Repositories;
using Miniprojet.Shared.Entites;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Miniprojet.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContact _contact;

        public ContactController(IContact contact)
        {
            _contact = contact;
        }


        // GET: api/<ContactController>
        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAll()
        {
            var clients = await _contact.GetContactsAsync();
            return Ok(clients);
        }

        // GET api/<ContactController>/5
        [HttpGet("{Contactid}")]
        public async Task<ActionResult<Contact>> Get(int contactId)
        {
            var contact = await _contact.GetContactByIdAsync(contactId);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }


        // POST api/<ContactController>
        [HttpPost]
        public async Task<ActionResult<int>> AddContact([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }

            try
            {
                int addedContactId = await _contact.AddContactAsync(contact);

                if (addedContactId > 0)
                {
                   
                    return Ok(addedContactId);
                }
                else
                {
                    
                    return StatusCode(500, "Failed to add client");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        // PUT api/<ContactController>/5
        [HttpPut("{contactId}")]
        public async Task<ActionResult> UpdateClient(int contactId, [FromBody] Contact contact)
        {

            await _contact.UpdateContactAsync(contactId, contact);
            return NoContent();
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{contactId}")]
        public async Task<ActionResult> DeleteClient(int contactId)
        {
            await _contact.DeleteContactAsync(contactId);
            return NoContent();
        }
    }
}
