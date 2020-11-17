using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonApi.Domain;
using PersonApi.Domain.DTO;
using PersonApi.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PeopleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<PeopleController>
        [HttpGet]
        [ProducesResponseType(typeof(PersonDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get()
        {
            return Ok(_unitOfWork.PersonRepository.GetAll());
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get(Guid id)
        {
            return Ok(_unitOfWork.PersonRepository.GetById(id));
        }

        // POST api/<PeopleController>
        [HttpPost]
        [ProducesResponseType(typeof(PersonDTO), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] PersonDTO personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            _unitOfWork.PersonRepository.Insert(person);
            _unitOfWork.Save();
            return Created(person.Id.ToString(), _mapper.Map<PersonDTO>(person));
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(Guid id, [FromBody] PersonDTO personDto)
        {
            _unitOfWork.PersonRepository.Update(_mapper.Map<Person>(personDto));
            _unitOfWork.Save();
            return Ok();
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            _unitOfWork.PersonRepository.Delete(id);
            _unitOfWork.Save();
            return new NoContentResult();
        }
    }
}
