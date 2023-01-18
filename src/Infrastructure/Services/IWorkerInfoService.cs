using Infrastructure.BusinessObjects;

namespace Infrastructure.Services
{
    public interface IWorkerInfoService
    {
        Task<WorkerInfo> GetWorkerInformationByRoll(string barcode);
        Task InsertData(WorkerInfo model);
        void InsertPrice(WorkerInfo model);
        public (int total, int totalDisplay, IList<WorkerInfo> records) GetWorkersInformation(int pageIndex,
            int pageSize, string searchText, string orderby);
    }
}