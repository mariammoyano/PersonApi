using System;
using System.Collections.Generic;
using System.Text;
using PersonApi.Domain;

namespace PersonApi.Service
{
    public class UnitOfWork : IDisposable
    {
        //TODO dependency injection everything
        private PersonContext context = new PersonContext();
        private GenericRepository<Person> personRepository;

        public GenericRepository<Person> PersonRepository 
        {
            get
            {
                if (this.personRepository == null)
                {
                    this.personRepository = new GenericRepository<Person>(context);
                }
                return this.personRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
