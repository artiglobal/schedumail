using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ScheduMail.API.Contracts
{
  /// <summary>
  /// User DTO for retrieving  User data from the third-party / source systems
  /// </summary>
  [Serializable]
  public class User 
  {
    public User() {
      Data = new XElement("Data");
    }

    /// <summary>
    /// Gets/Sets the Title of the user.
    /// </summary>
    /// <value>The Title of the user.</value>
    public string Title { get; set; }

    /// <summary>
    /// Gets/Sets the First Name of the user.
    /// </summary>
    /// <value>The name of the get user.</value>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets/Sets the Surname of the user.
    /// </summary>
    /// <value>The Surname of the user.</value>
    public string Surname { get; set; }

    /// <summary>
    /// Gets/Sets the Email Address of the user.
    /// </summary>
    /// <value>The name of the get user.</value>
    public string EmailAddress { get; set; }

    /// <summary>
    /// Gets/Sts the custom data of the user.
    /// </summary>
    /// <value>Custom data for user.</value>
    public XElement Data { get; set; }
  }
}
