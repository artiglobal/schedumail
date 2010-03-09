using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ScheduMail.TemplateParsers.Spark;
using ScheduMail.API.Contracts;

namespace ScheduMail.Spark.TemplateParserTest 
{
  public class RenderingUserTemplateSpecs : Specification
  {
    private TemplateParser sut;
    private User templateData;
    private string template;
    private string result;

    protected override void Given() 
    {
      var assemblies = new string[] { "ScheduMail.API" };
      var namespaces = new string[] { "ScheduMail.API.Contracts" };

      sut = new TemplateParser(assemblies,namespaces);

      templateData = new User
      {
        Title = "Mrs.",
        FirstName = "Nancy",
        Surname = "Davilio",
        EmailAddress = "nancy.davilio@northwindtraders.com"
      };

      template = @"
      <var  user = ""(ScheduMail.API.Contracts.User)Data""/>
      Name: ${user.Title} ${user.FirstName} ${user.Surname}";
    }

    protected override void When() 
    {
      result = sut.Render<User>(templateData, "simpleElementTemplate", template);
    }

    [Then]
    public void ShouldRenderStronglyTypedTemplate() 
    {
      Verify(result.Trim(), Is.EqualTo("Name: Mrs. Nancy Davilio"));
    }
  }
}
