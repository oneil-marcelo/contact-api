using System;
using System.Threading.Tasks;
using contact_api.Models;
using contact_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace contact_api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ContactTypeController : Controller
    {
        private readonly IContactTypeRepository _repository;
        public ContactTypeController(IContactTypeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetContactTypes()
        {
            try
            {
                
                var contactTypes = await _repository.GetContactTypes();
                return Ok(contactTypes);

            } catch(Exception ex) {

                return BadRequest(ex.Message);

            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetContactTypeById(int id)
        {
            try
            {
                var contactType = await _repository.GetContactTypeById(id);

                if(contactType == null)
                    return NotFound();

                return Ok(contactType);

            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddContactType([FromBody] ContactType model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);


            try {

                var contactType = await _repository.AddContactType(model);
                return Ok(contactType);

            } catch (Exception ex) {

                return BadRequest( ex.Message);
            
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditContactType ([FromBody] ContactType model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                var contactType = await _repository.EditContactType(model);
                return Ok(contactType);

            } catch ( Exception ex) {
                return BadRequest(ex.Message);
            }



        }

    }
}