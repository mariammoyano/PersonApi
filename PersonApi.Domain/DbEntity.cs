using System;

namespace PersonApi.Domain
{
    public abstract class DbEntity
    {
        public Guid Id { get; set; }
    }
}