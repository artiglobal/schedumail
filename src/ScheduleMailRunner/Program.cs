using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using ScheduMail.Core.Service.Interfaces;
using ScheduMail.Core.Facade;
using System.Configuration;
using System.Xml.Linq;

namespace ScheduleMailRunner
{
    class Program
    {
        static void Main(string[] args)
        {
          string requestedURL = ConfigurationManager.AppSettings["URL"].ToString();


          //Example of api and parser collaboration, this should be moved to service class(ISchedularService) or similar in the core project
          var api = ServiceLocator.Resolve<IUserService>();
          var users = api.GetUsers(requestedURL, "user", "password");


          var parser = ServiceLocator.Resolve<ITemplateParser>();
          var template = @"
            <var  user = ""(ScheduMail.API.Contracts.User)Data""/>
            <var  promotion = ""(from p in user.Data.Elements('promotion')
                                select new {
                                  Product = (string)p.Element('product'),
                                  Discount = (string)p.Element('discount'),
                                  Expires = (string)p.Element('expires')
                                }).FirstOrDefault()""/>
            Dear ${user.FirstName},

            We are excited to tell you about our latest offerings.  Due to your long standing account with us we would 
            like to give you a sneak peak at our latest product before commercial release. The ${promotion.Product} is the
            best thing since slice bread and for a limited time only we would like to extend you a discount of ${promotion.Discount}.

            Act soon because the offer is only good until ${promotion.Expires}.

            Happy Buying!

            Click <a href='http://somecompany.com/unsubscribe?user=${user.EmailAddress}'>here</a> to unsubscribe from out mailings.
          ";

          foreach (var user in users) {
            var email = parser.Render(user, "emailTemplate", template);
            Console.Write(email);
            Console.WriteLine();
          }

          Console.Read();
        }

        private static void WriteRequest(string requestedURL) 
        {
          // Create a request using a URL that can receive a post. 
          WebRequest request = WebRequest.Create(requestedURL);
          // Set the Method property of the request to POST.
          request.Method = "POST";
          // Create POST data and convert it to a byte array.
          string postData = "This is a test that posts this string to a Web server.";
          byte[] byteArray = Encoding.UTF8.GetBytes(postData);
          // Set the ContentType property of the WebRequest.
          request.ContentType = "application/x-www-form-urlencoded";
          // Set the ContentLength property of the WebRequest.
          request.ContentLength = byteArray.Length;
          // Get the request stream.
          Stream dataStream = request.GetRequestStream();
          // Write the data to the request stream.
          dataStream.Write(byteArray, 0, byteArray.Length);
          // Close the Stream object.
          dataStream.Close();
          // Get the response.
          WebResponse response = request.GetResponse();
          // Display the status.
          Console.WriteLine(((HttpWebResponse)response).StatusDescription);
          // Get the stream containing content returned by the server.
          dataStream = response.GetResponseStream();
          // Open the stream using a StreamReader for easy access.
          StreamReader reader = new StreamReader(dataStream);
          // Read the content.
          string responseFromServer = reader.ReadToEnd();
          // Display the content.
          Console.WriteLine(responseFromServer);
          // Clean up the streams.
          reader.Close();
          dataStream.Close();
          response.Close();
        }
    }
}
