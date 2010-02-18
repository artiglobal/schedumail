using System;
using NUnit.Framework;
using ScheduMail.EFDal.Dal;
using ScheduMail.Core.Domain;

namespace NUnit.Samples.Money
{
    [TestFixture]
    public class EFWEBRepository_Test
    {
        private EFWebSiteRepository repository;
        /// <summary>
        /// 
        /// </summary>
        /// 
        [SetUp]
        protected void SetUp()
        {
            this.repository = new EFWebSiteRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        [Test]
        public void EFWEBRepository_SaveTest()
        {
            WebSite webSite = new WebSite
            {
                SiteName = "wwww.google.com",
                Template = "<Hello World>",  
                CreatedBy = "John Coxhead",
                ModifiedBy = "John Coxhead"
            };

            webSite = repository.Save(webSite);
        }
    }
}
