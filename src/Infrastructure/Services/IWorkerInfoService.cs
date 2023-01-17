using Infrastructure.BusinessObjects;

namespace Infrastructure.Services
{
    public interface IWorkerInfoService
    {
        Task InsertData(WorkerInfo model);
    }
}