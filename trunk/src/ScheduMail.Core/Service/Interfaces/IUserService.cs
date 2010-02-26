using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.API.Contracts;

namespace ScheduMail.Core.Service.Interfaces 
{
  /// <summary>
  /// User Facade for retrieving users for remote ScheduMail data source
  /// </summary>
  public interface IUserService 
  {
    /// <summary>
    /// Gets a list of API users from a ScheduMail user provider
    /// </summary>
    /// <param name="url">The url for retrieving users from the API.</param>
    /// <param name="userName">User name for authenticating with the API.</param>
    /// <param name="password">Password for authenticating with the API.</param>
    /// <returns>List of Users.</returns>
    IList<User> GetUsers(string url, string userName, string password);
  }
}
