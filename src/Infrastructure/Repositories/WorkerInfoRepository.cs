using Infrastructure.DbContexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class WorkerInfoRepository : Repository<WorkerInfo, Guid>, IWorkerInfoRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public WorkerInfoRepository(IApplicationDbContext context) : base((DbContext)context)
        {
            _dbContext = context;
        }
    }
}