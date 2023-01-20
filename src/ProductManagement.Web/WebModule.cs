using Autofac;
using ProductManagement.Web.Areas.Admin.Models;
using ProductManagement.Web.Models;

namespace ProductManagement.Web
{
    public class WebModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterModel>().AsSelf();

            builder.RegisterType<LoginModel>().AsSelf();

            builder.RegisterType<WorkerListModel>().AsSelf();

            builder.RegisterType<WorkerInfoModel>().AsSelf();

            builder.RegisterType<WorkerInfoListModel>().AsSelf();

            builder.RegisterType<DashBoardModel>().AsSelf();

            builder.RegisterType<ReportModel>().AsSelf();

            base.Load(builder);
        }
    }
}