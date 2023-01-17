using AutoMapper;
using Infrastructure.BusinessObjects;
using Infrastructure.DbContexts;
using Infrastructure.Exceptions;
using Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerInfoBO = Infrastructure.BusinessObjects.WorkerInfo;
using WorkerInfoEO = Infrastructure.Entities.WorkerInfo;

namespace Infrastructure.Services
{
    public class WorkerInfoService : IWorkerInfoService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;

        public WorkerInfoService(IApplicationUnitOfWork applicationUnitOfWork,IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public async Task InsertData(WorkerInfoBO model)
        {
            var workerInfoEO=_mapper.Map<WorkerInfoEO>(model);
            var worker=_applicationUnitOfWork.Workers.Get(x => x.Roll == workerInfoEO.Roll, "").Select(s => s).FirstOrDefault();
            workerInfoEO.Worker = worker;

            var workerInfoCount = _applicationUnitOfWork.WorkersInformation.Get(x => x.Roll == workerInfoEO.Roll, "").Count;
            if(workerInfoCount>0)
            {
                throw new DataExistsException("This workers data has barcode has already been scanned");
            }

            _applicationUnitOfWork.WorkersInformation.Add(workerInfoEO);
            _applicationUnitOfWork.Save();

        }
    }
}
