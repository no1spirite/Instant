using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Instant.Web.Installers
{
    using System.Web.Mvc;

    using Instant.Web.Controllers;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class ControllersInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Installs the controllers
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(FindControllers().LifestyleTransient());
        }

        /// <summary>
        /// Find controllers within this assembly in the same namespace as HomeController
        /// </summary>
        /// <returns></returns>
        private BasedOnDescriptor FindControllers()
        {
            return AllTypes.FromThisAssembly()
                .BasedOn<IController>()
                .If(Component.IsInSameNamespaceAs<HomeController>())
                .If(t => t.Name.EndsWith("Controller"));
        }

    }
}