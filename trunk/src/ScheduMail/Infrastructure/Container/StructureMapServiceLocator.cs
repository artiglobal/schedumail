using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using Microsoft.Practices.ServiceLocation;

namespace ScheduMail.Infrastructure.Container {
  public class StructureMapServiceLocator : ServiceLocatorImplBase {

    public StructureMapServiceLocator(IBootstrapper bootstrapper) {
      bootstrapper.BootstrapStructureMap();
    }

    protected override object DoGetInstance(Type serviceType, string key) {
      return string.IsNullOrEmpty(key)
                 ? ObjectFactory.GetInstance(serviceType)
                 : ObjectFactory.GetNamedInstance(serviceType, key);
    }

    protected override IEnumerable<object> DoGetAllInstances(Type serviceType) {
      return ObjectFactory.GetAllInstances(serviceType).Cast<object>().AsEnumerable();
    }
  }
}
