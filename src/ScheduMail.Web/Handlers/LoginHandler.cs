using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScheduMail.Web.Resources;
using OpenRasta.Web;

namespace ScheduMail.Web.Handlers {
  public class LoginHandler {

    public Login Get() {
      return new Login();
    }

    public OperationResult Post(Login login) {
      return new OperationResult.SeeOther() { Title = "Login Completed" };
    }
  }
}
