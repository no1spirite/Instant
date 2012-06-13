namespace Instant.Web.Installers
{

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class DomainAssemblyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(Component.For<IResourceManager>().ImplementedBy<ResourceManager>().LifeStyle.Transient);

            //container.Register(
            //    AllTypes.FromAssemblyContaining<ResourceManager>().Where(n => n.Name.EndsWith("Service")).WithService.
            //        FirstInterface().LifestyleTransient());
        }
    }
}