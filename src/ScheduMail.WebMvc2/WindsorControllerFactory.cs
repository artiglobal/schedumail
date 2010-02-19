using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Castle.Core;
using Castle.Core.Resource;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

/// <summary>
/// Castle IOC Container support for MVC.
/// </summary>
public class WindsorControllerFactory : DefaultControllerFactory
{
    /// <summary>
    /// Container reference.
    /// </summary>
    private WindsorContainer container;

    /// <summary>
    /// Initializes a new instance of the <see cref="WindsorControllerFactory"/> class.
    /// The constructor
    /// 1. Sets up a new Ioc container.
    /// 2. Registers all components specified in the web.config.
    /// 3. Registers all controller types as components.
    /// </summary>
    public WindsorControllerFactory()
    {
        this.container = new WindsorContainer(new XmlInterpreter(new ConfigResource("castle")));

        var controllerTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
                              where typeof(IController).IsAssignableFrom(t)
                              select t;
        foreach (Type t in controllerTypes)
        {
            this.container.AddComponentLifeStyle(t.FullName, t, LifestyleType.Transient);
        }
    }

    /// <summary>
    /// Retrieves the controller instance for the specified request context and controller type.
    /// </summary>
    /// <param name="requestContext">The context of the HTTP request, which includes the HTTP context and route data.</param>
    /// <param name="controllerType">The type of the controller.</param>
    /// <returns>The controller instance.</returns>
    /// <exception cref="T:System.Web.HttpException">
    ///     <paramref name="controllerType"/> is null.</exception>
    /// <exception cref="T:System.ArgumentException">
    ///     <paramref name="controllerType"/> cannot be assigned.</exception>
    /// <exception cref="T:System.InvalidOperationException">An instance of <paramref name="controllerType"/> cannot be created.</exception>
    protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
    {        
        return (IController)this.container.Resolve(controllerType);
    }  
}