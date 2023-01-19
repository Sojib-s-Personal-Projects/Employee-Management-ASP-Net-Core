using Infrastructure.DbContexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using DashBoardInfoBO = Infrastructure.BusinessObjects.DashBoardInfo;

namespace Infrastructure.Repositories
{
    public class WorkerRepository : Repository<Worker, Guid>, IWorkerRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public WorkerRepository(IApplicationDbContext context) : base((DbContext)context)
        {
            _dbContext = context;
        }

        //public async Task<(IList<DashBoardInfoBO> data, int total, int totalDisplay)> GetDashBoardInfo(int pageIndex, int pageSize, string searchText, string orderby)
        //{
        //    var result = await QueryWithStoredProcedureAsync<DashBoardInfoBO>("sp_GetDashBoardInfo", new Dictionary<string, object>
        //    {
        //        {"PageIndex", pageIndex},
        //        {"PageSize", pageSize},
        //        {"SearchText", searchText},
        //        {"OrderBy", orderby }
        //    },
        //    new Dictionary<string, Type>
        //    {
        //        {"Total", typeof(int)},
        //        {"TotalDisplay", typeof(int)}
        //    });

        //    return (result.result, int.Parse(result.outValues.ElementAt(0).Value.ToString()), int.Parse(result.outValues.ElementAt(1).Value.ToString()));
        //}

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
    }
}