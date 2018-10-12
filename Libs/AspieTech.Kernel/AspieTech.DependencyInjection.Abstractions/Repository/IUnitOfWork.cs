using System;

namespace AspieTech.DependencyInjection.Abstractions.Repository
{
    public interface IUnitOfWork<TDbContext> : IDisposable
    {
        TDbContext Context { get; }
    }
}
