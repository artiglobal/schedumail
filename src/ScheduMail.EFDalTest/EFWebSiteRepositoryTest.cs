using System;
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
    public class EFWEBRepository_Test
    {
        /// <summary>
        /// Repository to be used for Test
        /// </summary>
        private EFWebSiteRepository repository;
        
        /// <summary>
        /// Sets up repository.
        /// </summary>
        [SetUp]
        protected void SetUp()
        {
            this.repository = new EFWebSiteRepository();
        }

        /// <summary>
        /// EFWEBs the repository_ save test.
        /// </summary>
        [Test]
        public void EFWEBRepository_SaveTest()
        {
            WebSite webSite = GetTestWebSite();
            WebSite newSite = this.repository.Save(webSite);

            Assert.AreEqual(webSite.Created, newSite.Created);
            Assert.AreEqual(webSite.CreatedBy, newSite.CreatedBy);
            Assert.AreEqual(webSite.Modified, newSite.Modified);
            Assert.AreEqual(webSite.ModifiedBy, newSite.ModifiedBy);
            Assert.AreEqual(webSite.SiteName, newSite.SiteName);
            Assert.AreEqual(webSite.Template, newSite.Template);
            Assert.Greater(newSite.Id, 0);
        }

        /// <summary>
        /// EFWEBs the repository_ update test.
        /// </summary>
        [Test]
        public void EFWEBRepository_UpdateTest()
        {
            WebSite webSite = new WebSite
            {
                Id = 12,
                SiteName = "wwww.google.com",
                Template = "<Hello World>",
                Created = DateTime.Now,
                CreatedBy = "James Galway",
                Modified = DateTime.Now,
                ModifiedBy = "John Coxhead"
            };

            WebSite newSite = this.repository.Save(webSite);
            Assert.AreEqual(webSite.Created, newSite.Created);
            Assert.AreEqual(webSite.CreatedBy, newSite.CreatedBy);
            Assert.AreEqual(webSite.Modified, newSite.Modified);
            Assert.AreEqual(webSite.ModifiedBy, newSite.ModifiedBy);
            Assert.AreEqual(webSite.SiteName, newSite.SiteName);
            Assert.AreEqual(webSite.Template, newSite.Template);
            Assert.Greater(newSite.Id, 0);
        }

        /// <summary>
        /// EFWEBs the repository_ get test.
        /// </summary>
        [Test]
        public void EFWEBRepository_GetTest()
        {           
            WebSite newSite = this.repository.GetById(10);
            Assert.AreEqual(10, newSite.Id);
        }

        /// <summary>
        /// EFWEBs the repository_ remove test.
        /// </summary>
        [Test]
        public void EFWEBRepository_RemoveTest()
        {
            WebSite webSite = GetTestWebSite();

            WebSite newSite = this.repository.Save(webSite);
            this.repository.Delete(newSite);          
        }

        /// <summary>
        /// EFWEBs the repository_ list test.
        /// </summary>
        [Test]
        public void EFWEBRepository_ListTest()
        {
            IQueryable<WebSite> webSites = this.repository.List;
            Assert.IsTrue(webSites.Count() > 0);
        }

        /// <summary>
        /// EFWEBs the repository_ list test.
        /// </summary>
        [Test]
        public void EFWEBRepository_ListWebSiteEMailsTest()
        {
            IQueryable<WebSiteEMails> webSites = this.repository.GetWebSiteEMails(1);
            Assert.IsTrue(webSites.Count() > 0);
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
