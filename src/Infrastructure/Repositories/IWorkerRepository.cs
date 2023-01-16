using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Repositories
{
    public interface IWorkerRepository: IRepository<Worker, Guid>
    {

    }
}