using Infrastructure.DbContexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class WorkerRepository: Repository<Worker, Guid>, IWorkerRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public WorkerRepository(IApplicationDbContext context) : base((DbContext)context)
        {
            _dbContext = context;
        }
    }
}