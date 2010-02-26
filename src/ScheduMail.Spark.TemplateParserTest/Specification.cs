using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace ScheduMail.Spark.TemplateParserTest 
{

  public class ThenAttribute : TestAttribute 
  {

  }

  [TestFixture]
  public abstract class Specification 
  {

    [TestFixtureSetUp]
    public void Setup() 
    {
      Given();
      When();
    }

    [TestFixtureTearDown]
    public void TearDown() 
    {
      TidyUp();
    }

    protected abstract void Given();
    protected abstract void When();
    protected virtual void TidyUp() { }


    public void Verify<T>(T actual, IResolveConstraint assertion) 
    {
      Assert.That(actual, assertion);
    }
  }
}
