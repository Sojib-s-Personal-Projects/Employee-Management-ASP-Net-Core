using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWorks
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IWorkerRepository Workers { get; }
    }
}