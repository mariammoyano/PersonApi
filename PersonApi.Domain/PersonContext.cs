using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PersonApi.Domain
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> People;
    }
}
