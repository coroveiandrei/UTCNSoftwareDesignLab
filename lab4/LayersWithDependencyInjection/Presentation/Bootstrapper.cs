using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;

namespace Presentation
{
    class Bootstrapper : UnityBootstrapper
    {

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog mCat = (ModuleCatalog)this.ModuleCatalog;
            mCat.AddModule(typeof(DataAccess.DataAccessModule));
            mCat.AddModule(typeof(BusinessLogic.BusinessLogicModule));
        }

        protected override void ConfigureServiceLocator()
        {
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(Container));
        }
    }
}
