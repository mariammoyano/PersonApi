using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PersonApi.Domain;

namespace PersonApi.Service
{
    public class PersonRepository : IPersonRepository
    {
        private PersonContext context;

        public PersonRepository(PersonContext context)
        {
            this.context = context;
        }

        public PersonRepository()
        {
        }

        public IEnumerable<Person> GetAll()
        {
            return context.People.ToList();
        }

        public Person GetById(int id)
        {
            return context.People.Find(id);
        }

        public void Insert(Person person)
        {
            context.People.Add(person);
        }

        public void Update(Person person)
        {
            context.Entry(person).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Person person = context.People.Find(id);
            context.People.Remove(person);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
