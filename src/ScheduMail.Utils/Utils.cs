using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ScheduMail
{
    /// <summary>
    /// General purpose simple authentication ticket.
    /// </summary>
    public class Auth
    {
        /// <summary>
        /// Gets the name of the get user.
        /// </summary>
        /// <value>The name of the get user.</value>
        public static string GetUserName
        {
            get
            {
                System.Web.Security.MembershipUser user = System.Web.Security.Membership.GetUser();
                return (user == null) ? "Guest" : user.UserName;
            }
        }
    }
}
