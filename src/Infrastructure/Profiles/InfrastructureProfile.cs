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
            //CreateMap<ApplicationUserBO, ApplicationUserEO>()
            //    .ForMember(x => x.Image, opt => opt.Ignore())
            //    .ReverseMap();

            //CreateMap<ApplicationUserEO, UserInfo>()
            //    .ForMember(dest => dest.UserId, src => src.MapFrom(x => x.Id));

            //CreateMap<ProjectEO, Project>()
            //    .ReverseMap();

            CreateMap<WorkerInfoBO, WorkerInfoEO>()
               .ReverseMap();

            CreateMap<WorkerBO, WorkerEO>()
               .ReverseMap();

            //CreateMap<ActivityEO, ActivityBO>()
            //   .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.ApplicationUserId))
            //   .ForMember(dest => dest.ActivityId, opt => opt.MapFrom(src => src.Id))
            //   .ReverseMap();
        }
    }
}