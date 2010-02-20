using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace ScheduMail.Core.Facade
{
    /// <summary>
    /// Service Locator class for Castle
    /// </summary>
    public static class ServiceLocator
    {
        /// <summary>
        /// Service Locator class for Castle configured to read out of app.config/web.config
        /// </summary>
        private static IWindsorContainer container
            = new WindsorContainer(new XmlInterpreter());

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public static void Clear()
        {
            container = new WindsorContainer();
        }

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T">Object type to be resolved.</typeparam>
        /// <returns>Instantiated resolved object,</returns>
        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        /// <summary>
        /// Adds the instance.
        /// </summary>
        /// <typeparam name="T">Object type to be added.</typeparam>
        /// <param name="instance">The instance.</param>
        public static void AddInstance<T>(object instance)
        {
            container.Kernel.AddComponentInstance<T>(typeof(T), instance);
        }
    }
}
