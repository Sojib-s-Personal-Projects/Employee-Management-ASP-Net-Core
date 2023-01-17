using AutoMapper;
using Infrastructure.BusinessObjects;
using ProductManagement.Web.Areas.Admin.Models;

namespace DevTrack.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<WorkerInfo,WorkerInfoModel>()
                .ForMember(x => x.BarCode2, opt => opt.Ignore())
                .ForMember(dest => dest.BarCode1, src => src.MapFrom(x => x.BarCodeData))
                .ReverseMap();

            //CreateMap<UpdatePassword, PasswordEditModel>()
            //    .ReverseMap();

            //CreateMap<ProjectCreateModel, Project>()
            //   .ReverseMap();

            //CreateMap<ProjectEditModel, Project>()
            //    .ReverseMap();

            //CreateMap<ProjectViewModel, Project>()
            //    .ReverseMap();

            //CreateMap<InvitationModel, Invitation>()
            //    .ReverseMap();

            //CreateMap<InvitationResponseModel, Invitation>()
            //    .ReverseMap();

            //CreateMap<ProjectUserEmailListModel, UserEmailList>()
            //    .ReverseMap();
        }
    }
}