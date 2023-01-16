using Infrastructure.DbContexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class WorkerRepository : Repository<Worker, Guid>, IWorkerRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public WorkerRepository(IApplicationDbContext context) : base((DbContext)context)
        {
            _dbContext = context;
        }

        public (IList<Worker> data, int total, int totalDisplay) GetWorkers(int pageIndex,
    int pageSize, string searchText, string orderby)
        {
            (IList<Worker> data, int total, int totalDisplay) results =
                GetDynamic(x => x.Roll.ToString().Contains(searchText), orderby,
                "", pageIndex, pageSize, true);

            return results;
        }
    }
}