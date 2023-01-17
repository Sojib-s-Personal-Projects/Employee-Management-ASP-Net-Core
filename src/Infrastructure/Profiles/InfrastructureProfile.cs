using AutoMapper;

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

            //CreateMap<ProjectUserEO, ProjectUser>()
            //   .ReverseMap();

            //CreateMap<ActivityEO, ActivityBO>()
            //   .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.ApplicationUserId))
            //   .ForMember(dest => dest.ActivityId, opt => opt.MapFrom(src => src.Id))
            //   .ReverseMap();
        }
    }
}