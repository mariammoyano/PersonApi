using System;

namespace PersonApi.Domain
{
    public abstract class DbEntity
    {
        Guid Id { get; set; }
    }
}