using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using OpenRasta.DI;

namespace ScheduMail.Infrastructure.Container {
  public class CreateInstanceScope {

    public static InstanceScope From(DependencyLifetime lifetime) {
      InstanceScope result;
      switch (lifetime) {
        case DependencyLifetime.PerRequest:
          result = InstanceScope.PerRequest;
          break;
        case DependencyLifetime.Singleton:
          result = InstanceScope.Singleton;
          break;
        case DependencyLifetime.Transient:
          result = InstanceScope.Transient;
          break;
        default:
          result = InstanceScope.Hybrid;
          break;
      }
      return result;
    }
  }
}
