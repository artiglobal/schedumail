using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.ServiceLocation;
using ScheduMail.Infrastructure.Container;

namespace ScheduMail {
  public class AppContext {
    private static IServiceLocator serviceLocator;

    public static void InitializeWith(IServiceLocator serviceLocator) {
      AppContext.serviceLocator = serviceLocator;
    }

    public static IServiceLocator ServiceLocator() {
      return serviceLocator;
    }

    public static IEnumerable<Interface> GetAllImplementationsOf<Interface>() {
      return serviceLocator.GetAllInstances<Interface>();
    }

    public static object GetImplementationOf(Type type) {
      return serviceLocator.GetInstance(type);
    }

    public static object GetImplementationOf(Type type, string key) {
      return serviceLocator.GetInstance(type, key);
    }

    public static Interface GetImplementationOf<Interface>() {
      try {
        return serviceLocator.GetInstance<Interface>();
      }
      catch (Exception e) {
        throw new DependencyResolutionException(e, typeof(Interface));
      }
    }

    public static Interface GetImplementationOf<Interface>(string key) {
      try {
        return serviceLocator.GetInstance<Interface>(key);
      }
      catch (Exception e) {
        throw new DependencyResolutionException(e, typeof(Interface));
      }
    }

  }
}