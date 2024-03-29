﻿using Infrastructure.DbContexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class WorkerInfoRepository : Repository<WorkerInfo, Guid>, IWorkerInfoRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public WorkerInfoRepository(IApplicationDbContext context) : base((DbContext)context)
        {
            _dbContext = context;
        }

        public (IList<WorkerInfo> data, int total, int totalDisplay) GetWorkersInformation(int pageIndex,
            int pageSize, string searchText, string orderby)
        {
            (IList<WorkerInfo> data, int total, int totalDisplay) results =
                GetDynamic(x => x.BarCodeData == searchText, orderby,
                "Worker", pageIndex, pageSize, true);

            return results;
        }

        public (IList<WorkerInfo> data, int total, int totalDisplay) GetWorkersPriceInformation(int pageIndex,
            int pageSize, string searchText, string orderby)
        {
            (IList<WorkerInfo> data, int total, int totalDisplay) results =
                GetDynamic(x => x.BarCodeData.Contains(searchText)|| x.Roll.ToString().Contains(searchText), orderby,
                "Worker", pageIndex, pageSize, true);

            return results;
        }

        public (IList<WorkerInfo> data, int total, int totalDisplay) GetPriceNotInsertedWorkersInformation(int pageIndex,
            int pageSize, string searchText, string orderby)
        {
            (IList<WorkerInfo> data, int total, int totalDisplay) results =
                GetDynamic(x => x.Price==null, orderby,
                "Worker", pageIndex, pageSize, true);

            return results;
        }
    }
}