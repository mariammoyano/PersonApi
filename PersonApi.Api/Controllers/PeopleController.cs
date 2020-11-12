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
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            return Ok(unitOfWork.PersonRepository.GetAll());
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            return Ok(unitOfWork.PersonRepository.GetById(id));
        }

        // POST api/<PeopleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            unitOfWork.PersonRepository.Insert(person);
            unitOfWork.Save();
            return Created(person.Id.ToString(), person);
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Person person)
        {
            unitOfWork.PersonRepository.Update(person);
            unitOfWork.Save();
            return Ok();
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            unitOfWork.PersonRepository.Delete(id);
            unitOfWork.Save();
            return new NoContentResult();
        }
    }
}
