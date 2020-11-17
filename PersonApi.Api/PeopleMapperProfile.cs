using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PersonApi.Domain;
using PersonApi.Domain.DTO;

namespace PersonApi.Api
{
    public class PeopleMapperProfile : Profile
    {
        public PeopleMapperProfile()
        {
            CreateMap<Person, PersonDTO>();
        }
    }
}
