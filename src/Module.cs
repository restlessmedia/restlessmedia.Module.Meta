using Autofac;
using restlessmedia.Module.Meta.Data;

namespace restlessmedia.Module.Meta
{
  public class Module : IModule
  {
    public void RegisterComponents(ContainerBuilder containerBuilder)
    {
      containerBuilder.RegisterType<MetaService>().As<IMetaService>().SingleInstance();
      containerBuilder.RegisterType<MetaDataDataProvider>().As<IMetaDataDataProvider>().SingleInstance(); 
    }
  }
}