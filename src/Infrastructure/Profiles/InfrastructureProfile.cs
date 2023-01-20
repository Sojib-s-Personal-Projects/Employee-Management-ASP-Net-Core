using AutoMapper;
using WorkerInfoBO = Infrastructure.BusinessObjects.WorkerInfo;
using WorkerInfoEO = Infrastructure.Entities.WorkerInfo;
using WorkerBO = Infrastructure.BusinessObjects.Worker;
using WorkerEO = Infrastructure.Entities.Worker;

namespace Infrastructure.Profiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<WorkerInfoBO, WorkerInfoEO>()
               .ReverseMap();

            CreateMap<WorkerBO, WorkerEO>()
               .ReverseMap();
        }
    }
}