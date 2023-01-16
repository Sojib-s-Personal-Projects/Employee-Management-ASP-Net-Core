using Infrastructure.BusinessObjects;

namespace Infrastructure.Services
{
    public interface IWorkerService
    {
        (int total, int totalDisplay, IList<Worker> records) GetWorkers(int pageIndex, int pageSize, string searchText, string orderby);
    }
}