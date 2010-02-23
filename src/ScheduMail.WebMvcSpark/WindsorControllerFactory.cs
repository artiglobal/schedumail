using System;
using System.Configuration;
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
        this.container = new WindsorContainer
        (
            new XmlInterpreter(new ConfigResource("castle"))
        );

        var controllerTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
                              where typeof(IController).IsAssignableFrom(t)
                              select t;
        foreach (Type t in controllerTypes)
        {
            this.container.AddComponentLifeStyle(
                t.FullName, 
                t,
                LifestyleType.Transient);
        }
    }

    /// <summary>
    /// Gets the controller instance.
    /// </summary>
    /// <param name="controllerType">Type of the controller.</param>
    /// <returns>A reference to the controller.</returns>
    protected override IController GetControllerInstance(Type controllerType)
    {
        return (IController)this.container.Resolve(controllerType);
    }
}