using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IWorkerRepository Workers { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext, IWorkerRepository workerRepository
            ) : base((DbContext)dbContext)
        {
            Workers = workerRepository;
        }
    }
}
