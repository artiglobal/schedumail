using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
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
      List<User> result = new List<User>();
      HttpWebRequest request;
      HttpWebResponse response = null;

      try 
      {
        // Create and initialize the web request  
        request = WebRequest.Create(url) as HttpWebRequest;
        request.Credentials = new NetworkCredential(userName, password);  
        request.UserAgent = "ScheduMail";
        request.KeepAlive = false;
        request.Timeout = 15 * 1000;

        // Get response  
        response = request.GetResponse() as HttpWebResponse;

        if (request.HaveResponse == true && response != null) 
        {
          // Get the response stream  
          var reader = XmlReader.Create(response.GetResponseStream());
          var serializer = new XmlSerializer(typeof(List<User>));

          // Deserialize response to user dtos
          result = (List<User>)serializer.Deserialize(reader);
        }
      }
      catch (WebException wex) 
      {
        // This exception will be raised if the server didn't return 200 - OK  
        // TODO wire in logging and log details of api failure
        throw;
      }
      finally 
      {
        if (response != null) 
        { 
          response.Close(); 
        }
      }
      return result;
    }
    #endregion
  }
}
