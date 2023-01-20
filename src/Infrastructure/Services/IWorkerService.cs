using Infrastructure.BusinessObjects;

namespace Infrastructure.Services
{
    public interface IWorkerService
    {
        Task <(int total, int totalDisplay, IList<Worker> records)> GetDashboardInfo(int pageIndex, int pageSize, string searchText, string orderby);
        (int total, int totalDisplay, IList<Worker> records) GetWorkers(int pageIndex, int pageSize, string searchText, string orderby);
        Task<IList<Worker>> GetWorkerList();
        Task<int> GetUnscannedWorkersCount();
        Task<int> GetPriceNotInsertedWorkersCount();
    }
}