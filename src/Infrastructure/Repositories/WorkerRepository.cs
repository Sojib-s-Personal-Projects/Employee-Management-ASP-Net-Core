using Infrastructure.DbContexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
                GetDynamic(x => x.Roll.ToString().Contains(searchText) || x.Name.Contains(searchText) || x.WorkerInfo != null, orderby,
                "WorkerInfo", pageIndex, pageSize, true);

            return results;
        }

        public (IList<Worker> data, int total, int totalDisplay) GetDashBoardInfo(int pageIndex,
            int pageSize, string searchText, string orderby)
        {
            (IList<Worker> data, int total, int totalDisplay) results =
                GetDynamic(x => x.Roll.ToString().Contains(searchText), orderby,
                "WorkerInfo", pageIndex, pageSize, true);

            return results;
        }

        public List<Worker> GetWorkersList()
        {
            return _dbContext.Workers.Include(x=>x.WorkerInfo).Select(x=>x).ToList();
        }

        public async Task<int> GetUnscannedWorkersCount()
        {
            return _dbContext.Workers.Where(x => x.WorkerInfo == null).Count();
        }

        public async Task<int> GetPriceNotInsertedWorkersCount()
        {
            return _dbContext.Workers.Where(x => x.WorkerInfo != null && x.WorkerInfo.Price==null).Count();
        }
    }
}