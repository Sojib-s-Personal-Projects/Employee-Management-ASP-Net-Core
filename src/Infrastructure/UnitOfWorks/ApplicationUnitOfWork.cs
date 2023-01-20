using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IWorkerRepository Workers { get; private set; }
        public IWorkerInfoRepository WorkersInformation { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext, IWorkerRepository workerRepository, IWorkerInfoRepository workerInfoRepository
            ) : base((DbContext)dbContext)
        {
            Workers = workerRepository;
            WorkersInformation = workerInfoRepository;
        }
    }
}