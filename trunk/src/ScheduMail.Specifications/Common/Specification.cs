using System;
using OpenRasta.DI;
using OpenRasta.Hosting;
using OpenRasta.Pipeline;
using OpenRasta.Web;
using Rhino.Mocks;
using ScheduMail.Application;
using MbUnit.Framework;

namespace ScheduMail.Specifications.Common
{
    [TestFixture]
    public abstract class Specification {
      private MockRepository mockery;

      protected MockRepository Mocks {
        get { return mockery; }
      }


      [TestFixtureSetUp]
      public void Setup() {
        mockery = new MockRepository();

        InitializeContainer();
        CommonContext();
        Given();
        When();
      }

      [TestFixtureTearDown]
      public void TearDown() {
        TidyUp();
      }

      protected virtual void CommonContext() { }
      protected abstract void Given();
      protected abstract void When();
      protected virtual void TidyUp() { }

      protected T Dependency<T>() {
        return AppContext.GetImplementationOf<T>();
      }

      protected void InjectDependency<T>(T dependency) {
        UnitTestContainer.AddImplementationOf(dependency);
      }

      protected T SUT<T>() {
        return AppContext.GetImplementationOf<T>();
      }

      //protected void Verify<T>(T actual, IResolveConstraint assertion) {
      //  Assert.AreEqual(actual, assertion);
      //}

      protected InternalDependencyResolver Resolver {
        get { return Dependency<IDependencyResolver>() as InternalDependencyResolver; }
      }

      protected IUriResolver UriResolver {
        get { return Dependency<IUriResolver>(); }
      }

        protected abstract void InitializeContainer();

        private void ResetContainer() {
          AppContext.InitializeWith(null);
        }
    }

    public abstract class IntegrationSpecification : Specification {
      protected override void InitializeContainer() {
        ApplicationStartupService.ApplicationBegin();
      }
    }
    public abstract class ContextSpecification : Specification {
      ContextScope contextScope;

      protected override void InitializeContainer() {
        UnitTestContainer.Initialize();
        SetupDependencyResolver();
        SetupUriResolution();
      }

      void SetupDependencyResolver() {
        InjectDependency<IDependencyResolver>(new InternalDependencyResolver());
        DependencyManager.SetResolver(Resolver);

        Resolver.AddDependency<IContextStore, AmbientContextStore>();

        contextScope = new ContextScope(new AmbientContext());
      }

      void SetupUriResolution() {
        InjectDependency<IUriResolver>(new TemplatedUriResolver());

        Dependency<ICommunicationContext>()
            .Stub(x => x.ApplicationBaseUri)
            .Return(new Uri("http://localhost/", UriKind.Absolute));

        //AddDependencyToResolver<ICommunicationContext>();
        //AddDependencyToResolver<IUriResolver>();
      }

      protected override void TidyUp() {
        contextScope.Dispose();
        base.TidyUp();
      }
    }
}