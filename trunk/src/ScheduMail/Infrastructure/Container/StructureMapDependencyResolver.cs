using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenRasta.DI;
using StructureMap;
using OpenRasta.Pipeline;

namespace ScheduMail.Infrastructure.Container {
  public class StructureMapDependencyResolver : IDependencyResolver {
    #region IDependencyResolver Members

    public void AddDependency(Type serviceType, Type concreteType, DependencyLifetime dependencyLifetime) {
      ObjectFactory.Configure(dependency =>
      {
        dependency.For(serviceType).LifecycleIs(CreateInstanceScope.From(dependencyLifetime)).Use(concreteType);
      });
    }

    public void AddDependency(Type concreteType, DependencyLifetime lifetime) {
      ObjectFactory.Configure(dependency =>
      {
        dependency.For(concreteType).LifecycleIs(CreateInstanceScope.From(lifetime));
      });
    }

    public void AddDependencyInstance(Type registeredType, object value, DependencyLifetime dependencyLifetime) {
      ObjectFactory.Configure(dependency =>
      {
        dependency.For(registeredType).LifecycleIs(CreateInstanceScope.From(dependencyLifetime)).Use(value);
      });
    }

    public void HandleIncomingRequestProcessed() {
      var contextStore = ObjectFactory.GetInstance<IContextStore>();
    }

    public bool HasDependency(Type serviceType) {
      return ObjectFactory.Model.HasDefaultImplementationFor(serviceType);
    }

    public bool HasDependencyImplementation(Type serviceType, Type concreteType) {
      return ObjectFactory.Model.For(serviceType).Default.ConcreteType == concreteType;
    }

    public object Resolve(Type type) {
      return ObjectFactory.GetInstance(type);
    }

    public IEnumerable<TService> ResolveAll<TService>() {
      return ObjectFactory.GetAllInstances<TService>().AsEnumerable();
    }

    #endregion
  }
}
