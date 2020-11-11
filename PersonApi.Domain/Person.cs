using System;

namespace PersonApi.Domain
{
    public class Person : DbEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}