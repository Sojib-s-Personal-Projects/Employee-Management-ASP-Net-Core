using Infrastructure.BusinessObjects;

namespace Infrastructure.Services
{
    public interface IWorkerInfoService
    {
        Task<WorkerInfo> GetWorkerInformationByRoll(long roll);
        Task InsertData(WorkerInfo model);
        void InsertPrice(WorkerInfo model);
    }
}