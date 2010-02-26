using System;
using System.Collections.Generic;
using ScheduMail.API.Contracts;
using ScheduMail.Core.Service.Interfaces;

namespace ScheduMail.Core.Service.Implementations 
{
  /// <summary>
  /// Implementation of User Facade for retrieving users for remote ScheduMail data source
  /// </summary>
  public class UserService : IUserService 
  {
    #region IUserService Members
    /// <summary>
    /// Gets a list of API users from a ScheduMail user provider
    /// </summary>
    /// <param name="url">The url for retrieving users from the API.</param>
    /// <param name="userName">User name for authenticating with the API.</param>
    /// <param name="password">Password for authenticating with the API.</param>
    /// <returns>List of Users.</returns>
    public IList<User> GetUsers(string url, string userName, string password) 
    {
      // TODO Implement API Call and deserialze
      // For now return users
      return new List<User> 
      {
        { new User { Title = "Mr.", FirstName = "Andrew", Surname = "Fuller", EmailAddress = "afuller@northwind.com" } },
        { new User { Title = "Mrs.", FirstName = "Nancy", Surname = "Davilio", EmailAddress = "ndavilio@northwind.com" } }
      };
    }
    #endregion
  }
}
