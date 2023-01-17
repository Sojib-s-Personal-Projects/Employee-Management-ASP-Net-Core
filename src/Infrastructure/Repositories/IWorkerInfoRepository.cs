using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Repositories
{
    public interface IWorkerInfoRepository: IRepository<WorkerInfo, Guid>
    {

    }
}