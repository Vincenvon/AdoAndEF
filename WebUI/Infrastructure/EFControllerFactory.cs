using System;
using System.Web.Routing;
using System.Web.Mvc;
using Ninject;
using Domain.Abstract;
using Domain.EF;

namespace WebUI.Infrastructure
{
    public class EFControllerFactory:DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public EFControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContex, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<IPersonRepository>().To<Repository>();
            
        }
    }
}