using System;
using System.Collections.Generic;
using System.Text;

namespace PersonApi.Domain
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person GetById(int id);
        void Insert(Person person);
        void Delete(int id);
        void Update(Person person);
        void Save();
    }
}
