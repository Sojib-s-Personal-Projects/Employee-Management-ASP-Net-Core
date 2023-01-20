using Infrastructure.Entities;
namespace Infrastructure.Repositories
{
    public interface IWorkerRepository: IRepository<Worker, long>
    {
        (IList<Worker> data, int total, int totalDisplay) GetWorkers(int pageIndex,
        int pageSize, string searchText, string orderby);
        (IList<Worker> data, int total, int totalDisplay) GetDashBoardInfo(int pageIndex,
        int pageSize, string searchText, string orderby);
        List<Worker> GetWorkersList();
        Task<int> GetUnscannedWorkersCount();
        Task<int> GetPriceNotInsertedWorkersCount();
    }
}