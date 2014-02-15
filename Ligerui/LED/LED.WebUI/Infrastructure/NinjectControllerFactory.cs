using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LED.Domain.IRepository;
using LED.DataProvider.RepositoryImpl;

namespace LED.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext
            requestContext, Type controllerType)
        {

            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
           
            ninjectKernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));

            ninjectKernel.Bind<IOrgRepository>().To<OrgRepository>();
            ninjectKernel.Bind<IMenuRepository>().To<MenuRepository>();
            ninjectKernel.Bind<IUserRepository>().To<UserRepository>();
            ninjectKernel.Bind<IRoleRepository>().To<RoleRepository>();
        }
    }
}