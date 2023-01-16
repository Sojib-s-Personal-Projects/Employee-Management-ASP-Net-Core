using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Repositories
{
    public interface IWorkerRepository: IRepository<Worker, Guid>
    {
        (IList<Worker> data, int total, int totalDisplay) GetWorkers(int pageIndex,
        int pageSize, string searchText, string orderby);
    }
}