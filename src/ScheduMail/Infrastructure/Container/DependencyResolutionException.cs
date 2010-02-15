using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduMail.Infrastructure.Container {
  public class DependencyResolutionException : Exception {
    public const string ExceptionMessageFormat = "Failed to resolve an implementation of an {0}";

    public DependencyResolutionException(Exception innerException, Type interfaceThatCouldNotBeResolvedForSomeReason)
      : base(string.Format(ExceptionMessageFormat, interfaceThatCouldNotBeResolvedForSomeReason.FullName), innerException)
    {
    }
  }
}