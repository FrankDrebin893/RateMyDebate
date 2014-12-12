using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using RateMyDebate.Models;

namespace RateMyDebate
{
    public class ControllerFactory : DefaultControllerFactory
    {

        private IKernel Kernel;
        public ControllerFactory()
        {
            Kernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)Kernel.Get(controllerType);
        }
        private void AddBindings()
        {
            Kernel.Bind<IDebateRepository>().To<DebateRepository>();
        }
    }
}