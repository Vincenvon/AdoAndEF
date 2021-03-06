﻿using System;
using System.Web.Routing;
using System.Web.Mvc;
using Ninject;
using Domain.Abstract;
using Domain.Concrete;


namespace WebUi.Ifrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory() {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContex, Type controllerType) {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings() {
            ninjectKernel.Bind<IPersonRepository>().To<MyUserRepository>();
            
        }
    }
}