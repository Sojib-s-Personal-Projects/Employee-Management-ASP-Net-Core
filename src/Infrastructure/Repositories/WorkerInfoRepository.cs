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

        public (IList<WorkerInfo> data, int total, int totalDisplay) GetWorkersInformation(int pageIndex,
            int pageSize, string searchText, string orderby)
        {
            (IList<WorkerInfo> data, int total, int totalDisplay) results =
                Get(x => x.BarCodeData.Contains(searchText), null,
                "Worker", pageIndex, pageSize, true);

            return results;
        }
    }
}