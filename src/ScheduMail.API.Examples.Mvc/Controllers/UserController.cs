using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ScheduMail.API.Contracts;
using System.Xml.Linq;

namespace ScheduMail.API.Examples.Mvc.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/List

        public ActionResult List()
        {
            var promotion = @"<promotions>
                                <promotion>
                                  <product>Widget 1</product>
                                  <discount>20%</discount>
                                  <expires>This Month</expires>
                                </promotion>
                              </promotions>";

            var userData = XElement.Parse(promotion);

            var users = new List<User> 
            {
              { new User { Title = "Mr.", FirstName = "Andrew", Surname = "Fuller", EmailAddress = "afuller@northwind.com", Data = userData } },
              { new User { Title = "Mrs.", FirstName = "Nancy", Surname = "Davilio", EmailAddress = "ndavilio@northwind.com", Data = userData } }
            };

            return new ObjectResult<List<User>>(users);
        }

    }
}
