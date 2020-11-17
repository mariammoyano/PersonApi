using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonApi.Domain;
using PersonApi.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public PeopleController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<PeopleController>
        [HttpGet]
        [ProducesResponseType(typeof(PersonDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get()
        {
            return Ok(unitOfWork.PersonRepository.GetAll());
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get(Guid id)
        {
            return Ok(unitOfWork.PersonRepository.GetById(id));
        }

        // POST api/<PeopleController>
        [HttpPost]
        [ProducesResponseType(typeof(PersonDTO), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] PersonDTO personDto)
        {
            unitOfWork.PersonRepository.Insert(person);
            unitOfWork.Save();
            return Created(person.Id.ToString(), person);
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(Guid id, [FromBody] PersonDTO personDto)
        {
            unitOfWork.PersonRepository.Update(person);
            unitOfWork.Save();
            return Ok();
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            unitOfWork.PersonRepository.Delete(id);
            unitOfWork.Save();
            return new NoContentResult();
        }
    }
}
