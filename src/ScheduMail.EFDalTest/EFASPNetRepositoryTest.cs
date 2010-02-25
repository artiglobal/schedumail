using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ScheduMail.Core.Domain;
using ScheduMail.EFDal.Dal;

namespace NUnit.Samples.Money
{
    /// <summary>
    /// Set of Tests for Persistence of Web Site.
    /// </summary>
    [TestFixture]
    public class EFASPNetRepository_Test
    {
        /// <summary>
        /// Repository to be used for Test
        /// </summary>
        private EFAspNetUsersRepository repository;
        
        /// <summary>
        /// Sets up repository.
        /// </summary>
        [SetUp]
        protected void SetUp()
        {
            this.repository = new EFAspNetUsersRepository();
        }

        /// <summary>
        /// EFWEBs the repository_ save test.
        /// </summary>
        [Test]
        public void EFLogEventRepository_GetASPNetUsersForWebSite()
        {
          List<AspnetUsers> list = this.repository.ListByWebSiteId(1).ToList<AspnetUsers>();
          AspnetUsers user = this.repository.GetById(list[0].UserId);      
        }      

        #region Private Helpers

        /// <summary>
        /// Gets the test web site.
        /// </summary>
        /// <returns>Test Web site.</returns>
        private static WebSite GetTestWebSite()
        {
            return new WebSite
            {
                SiteName = "wwww.google.com",
                Template = "<Hello World>",
                CreatedBy = "John Coxhead",
                ModifiedBy = "John Coxhead"
            };
        }

        #endregion
    }
}
