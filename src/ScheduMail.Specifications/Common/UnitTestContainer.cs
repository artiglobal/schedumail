using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.ServiceLocation;

namespace ScheduMail.Specifications.Common {
  public class UnitTestContainer : IServiceLocator {
    private static UnitTestContainer instance;
    private IDictionary<KeyValuePair<string, Type>, object> implementors;
    private IServiceLocator resolverForMocks;

    private UnitTestContainer() {
      implementors = new Dictionary<KeyValuePair<string, Type>, object>();
    }


    public static void Initialize() {
      instance = new UnitTestContainer();
    }

    public static void TearDownAndUnregisterFromDependencyResolver() {
      instance = null;
      AppContext.InitializeWith(null);
    }

    public static void AddResolverToHandleNonLoggingDependencyRequests(IServiceLocator mockResolver) {
      instance.resolverForMocks = mockResolver;
    }

    public static void AddImplementationOf<Interface>(Interface implementation) {
      instance.implementors.Add(new KeyValuePair<string, Type>(Guid.NewGuid().ToString(), typeof(Interface)),
                                implementation);
    }

    public static void RegisterInContainer() {
      AppContext.InitializeWith(instance);
    }


    #region IServiceLocator Members

    public IEnumerable<TService> GetAllInstances<TService>() {
      return (from instances in instance.implementors
              where instances.Key.Value == typeof(TService)
              select instances.Value).Cast<TService>();
    }

    public IEnumerable<object> GetAllInstances(Type serviceType) {
      return (from instances in instance.implementors
              where instances.Key.Value == serviceType
              select instances.Value);
    }

    public TService GetInstance<TService>(string key) {
      return (from instances in instance.implementors
              where instances.Key.Key == key
              select instances.Value).Cast<TService>().First();
    }

    public TService GetInstance<TService>() {
      var result = (from instances in instance.implementors
                    where instances.Key.Value == typeof(TService)
                    select instances.Value).First();

      if (result != null) return (TService)result;
      return resolverForMocks.GetInstance<TService>();
    }

    public object GetInstance(Type serviceType, string key) {
      throw new NotImplementedException();
    }

    public object GetInstance(Type serviceType) {
      var result = (from instances in instance.implementors
                    where instances.Key.Value == serviceType
                    select instances.Value).First();

      if (result != null) return result;
      return resolverForMocks.GetInstance(serviceType);
    }

    #endregion

    #region IServiceProvider Members

    public object GetService(Type serviceType) {
      var result = (from instances in instance.implementors
                    where instances.Key.Value == serviceType
                    select instances.Value).First();

      if (result != null) return result;
      return resolverForMocks.GetInstance(serviceType);
    }

    #endregion

  }
}