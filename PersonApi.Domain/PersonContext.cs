using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PersonApi.Domain
{
    public class PersonContext : DbContext
    {
        private readonly IConfiguration configuration;
        public PersonContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DbSet<Person> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("mechidb"));
        }
    }
}
