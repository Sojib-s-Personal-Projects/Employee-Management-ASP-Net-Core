using Autofac;
using ProductManagement.Web.Models;

namespace ProductManagement.Web
{
    public class WebModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterModel>().AsSelf();

            builder.RegisterType<LoginModel>().AsSelf();

            base.Load(builder);
        }
    }
}
