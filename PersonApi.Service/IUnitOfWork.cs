using PersonApi.Domain;

namespace PersonApi.Service
{
    public interface IUnitOfWork
    {
        GenericRepository<Person> PersonRepository { get; }

        void Dispose();
        void Save();
    }
}