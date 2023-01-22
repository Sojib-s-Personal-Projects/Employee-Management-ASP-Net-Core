using Infrastructure.DbContexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastructure.Repositories
{
    public class WorkerRepository : Repository<Worker, long>, IWorkerRepository
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
                GetDynamic(x => x.Id.ToString().Contains(searchText) || x.Name.Contains(searchText) || x.WorkerInfo != null, orderby,
                "WorkerInfo", pageIndex, pageSize, true);

            return results;
        }

        public (IList<Worker> data, int total, int totalDisplay) GetDashBoardInfo(int pageIndex,
            int pageSize, string searchText, string orderby)
        {
            (IList<Worker> data, int total, int totalDisplay) results =
                GetDynamic(x => x.Id.ToString().Contains(searchText), orderby,
                "WorkerInfo", pageIndex, pageSize, true);

            return results;
        }

        public List<Worker> GetWorkersList()
        {
            return _dbContext.Workers.Where(x=>x.WorkerInfo != null).Include(x=>x.WorkerInfo).ToList();
        }

        public async Task<int> GetUnscannedWorkersCount()
        {
            return _dbContext.Workers.Where(x => x.WorkerInfo == null).Count();
        }

        public async Task<int> GetPriceNotInsertedWorkersCount()
        {
            return _dbContext.Workers.Where(x => x.WorkerInfo != null && (x.WorkerInfo.Price==null||x.WorkerInfo.PriceConfirmed==false)).Count();
        }
    }
}