using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public interface IWorkerInfoRepository : IRepository<WorkerInfo, Guid>
    {
        (IList<WorkerInfo> data, int total, int totalDisplay) GetWorkersInformation(int pageIndex,
            int pageSize, string searchText, string orderby);
        (IList<WorkerInfo> data, int total, int totalDisplay) GetWorkersPriceInformation(int pageIndex,
            int pageSize, string searchText, string orderby);
        (IList<WorkerInfo> data, int total, int totalDisplay) GetPriceNotInsertedWorkersInformation(int pageIndex,
            int pageSize, string searchText, string orderby);
    }
}