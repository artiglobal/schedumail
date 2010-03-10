using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ScheduMail.TemplateParsers.Spark;
using ScheduMail.API.Contracts;
using System.Xml.Linq;

namespace ScheduMail.Spark.TemplateParserTest 
{
  public class RenderingSimpleUserTemplateSpecs : Specification
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
      <viewdata  User = ""ScheduMail.API.Contracts.User""/>
      Name: ${User.Title} ${User.FirstName} ${User.Surname}";
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

  public class RenderingUserTemplateWithCustomDataSpecs : Specification {
    private TemplateParser sut;
    private User templateData;
    private string template;
    private string result;

    protected override void Given() {
      var assemblies = new string[] { "ScheduMail.API" };
      var namespaces = new string[] { "ScheduMail.API.Contracts", "System.Linq","System.Xml.Linq" };

      sut = new TemplateParser(assemblies, namespaces);

      var promotion = @"<promotions>
                          <promotion>
                            <product>Widget 1</product>
                            <discount>20%</discount>
                            <expires>this month</expires>
                          </promotion>
                        </promotions>";

      var userData = XElement.Parse(promotion);

      templateData = new User
      {
        Title = "Mrs.",
        FirstName = "Nancy",
        Surname = "Davilio",
        EmailAddress = "nancy.davilio@northwindtraders.com",
        Data = userData
      };

      template = @"
            <viewdata  User = ""ScheduMail.API.Contracts.User""/>
            <var  promotion = ""(from p in User.Data.Elements('promotion')
                                select new {
                                  Product = (string)p.Element('product'),
                                  Discount = (string)p.Element('discount'),
                                  Expires = (string)p.Element('expires')
                                }).FirstOrDefault()""/>
            Dear ${User.FirstName},

            We are excited to tell you about our latest offerings.  Due to your long standing account with us we would 
            like to give you a sneak peak at our latest product before commercial release. The ${promotion.Product} is the
            best thing since slice bread and for a limited time only we would like to extend you a discount of ${promotion.Discount}.

            Act soon because the offer is only good until the end of ${promotion.Expires}.

            Happy Buying!

            Click <a href='http://somecompany.com/unsubscribe?user=${User.EmailAddress}'>here</a> to unsubscribe from out mailings.
          ";
    }

    protected override void When() 
    {
      result = sut.Render<User>(templateData, "customDataElementTemplate", template);
    }

    [Then]
    public void ShouldRenderStronglyTypedTemplate() 
    {
      Verify(result.Trim().Length, Is.GreaterThan(0));
    }

    [Then]
    public void ShouldProperlyRenderCustomDataElements()
    {
      Verify(result.Trim(), Is.StringContaining("Widget 1"));
      Verify(result.Trim(), Is.StringContaining("discount of 20%."));
      Verify(result.Trim(), Is.StringContaining("good until the end of this month."));
    }
  }
}
