using Autofac;

namespace restlessmedia.Module.Meta
{
  public class Module : IModule
  {
    public void RegisterComponents(ContainerBuilder containerBuilder)
    {
      //containerBuilder.RegisterType<EmailService>().As<IEmailService>().SingleInstance();
      
      //containerBuilder.RegisterSettings<IGoogleSettings>("restlessmedia/google", required: false);
    }
  }
}