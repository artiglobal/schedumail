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
    public class EFMailRepository_Test
    {
        /// <summary>
        /// Repository to be used for Test
        /// </summary>
        private EFMailRepository repository;
        
        /// <summary>
        /// Sets up repository.
        /// </summary>
        [SetUp]
        protected void SetUp()
        {
            this.repository = new EFMailRepository();
        }

        /// <summary>
        /// EFWEBs the repository_ save test.
        /// </summary>
        [Test]
        public void EFLogEventRepository_GetLogEvent()
        {
          List<Mail> list = this.repository.List.ToList<Mail>();
          Mail mail = this.repository.GetById(list[0].Id);           
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
