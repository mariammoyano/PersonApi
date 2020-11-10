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
        private IPersonRepository personRepository;
        public PeopleController()
        {
            //TODO is this ok?
            this.personRepository = new PersonRepository(new PersonContext());
        }

        // GET: api/<PeopleController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return personRepository.GetAll();
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return personRepository.GetById(id);
        }

        // POST api/<PeopleController>
        [HttpPost]
        public void Post([FromBody] Person person)
        {
            personRepository.Insert(person);
            personRepository.Save();
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Person person)
        {
            //TODO is this ok?
            personRepository.Update(person);
            personRepository.Save();
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            personRepository.Delete(id);
            personRepository.Save();
        }
    }
}
