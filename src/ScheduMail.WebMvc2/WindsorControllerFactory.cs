using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Castle.Core;
using Castle.Core.Resource;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

public class WindsorControllerFactory : DefaultControllerFactory
{
    WindsorContainer container;

    /// <summary>
    /// Initializes a new instance of the <see cref="WindsorControllerFactory"/> class.
    /// The constructor
    /// 1. Sets up a new Ioc container.
    /// 2. Registers all components specified in the web.config.
    /// 3. Registers all controller types as components.
    /// </summary>
    public WindsorControllerFactory()
    {
        container = new WindsorContainer
        (
            new XmlInterpreter(new ConfigResource("castle"))
        );

        var controllerTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
                              where typeof(IController).IsAssignableFrom(t)
                              select t;
        foreach (Type t in controllerTypes)
        {
            container.AddComponentWithLifestyle(t.FullName, t,
                LifestyleType.Transient);
        }
    }

    protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
    {
        // return base.GetControllerInstance(requestContext, controllerType);
        return (IController)container.Resolve(controllerType);
    }  
}