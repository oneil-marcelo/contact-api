using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using contact_api.Models;
using contact_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace contact_api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;

        public  ContactController(IContactRepository repository)
        {
        
            _repository =  repository;
        
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            try
            {
                
                var contacts = await _repository.GetContacts();
                return Ok(contacts);

            } catch(Exception ex) {

                return BadRequest(ex.Message);

            }

        }



        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            try
            {
                var contact = await _repository.GetContactById(id);

                if(contact == null)
                    return NotFound();

                return Ok(contact);

            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddContactType([FromBody] Contact model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);


            try {

                var contact = await _repository.AddContact(model);
                return Ok(contact);

            } catch (Exception ex) {

                return BadRequest( ex.Message);
            
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditContactType ([FromBody] Contact model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                var contact = await _repository.EditContact(model);
                return Ok(contact);

            } catch ( Exception ex) {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact([FromBody] Contact model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result  = await _repository.DeleteContact(model);
                if(result)
                    return Ok("Contato excluído com sucesso.");
                
                return Ok("Não foi possível excluir o contanto.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}