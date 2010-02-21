using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Moq;
using NUnit.Framework;
using ScheduMail.Core.Domain;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.UnitsOfWork;

namespace ScheduMail.UnitsOfWorkTests
{
    /// <summary>
    /// Web site unit of work unit tests.
    /// </summary>
    [TestFixture]
    public class WebSiteUnitOfWorkTest
    {
        /// <summary>
        /// Webs the site_ container test.
        /// </summary>
        [Test]
        public void WebSite_ContainerTest()
        {
            IWindsorContainer container = new WindsorContainer(new XmlInterpreter());

            IWebSiteRepository repository;

            // generic default service retrieval
            repository = container.Resolve<IWebSiteRepository>();
            Assert.IsNotNull(repository);
            //// repository.Save(new ScheduMail.Core.Domain.WebSite());

            // service retreival only by given id
            repository = (IWebSiteRepository)container.Resolve("webSiteRepositoryService");
            Assert.IsNotNull(repository);
        }

        /// <summary >
        /// Webs the site_ create test.
        /// </summary>
        [Test]
        public void WebSite_CreateTest()
        {
            var webSiteRepositoryMock = new Mock<IWebSiteRepository>();
            var webSiteMock = new Mock<WebSite>();
            webSiteMock.Object.Id = 1;
            webSiteMock.Object.SiteName = "www.google.com";

            webSiteRepositoryMock.Setup(repository => repository.Save(webSiteMock.Object))
                .Returns(webSiteMock.Object);

            WebSiteUnitOfWork uow = new WebSiteUnitOfWork(webSiteRepositoryMock.Object);
            WebSite webSite = uow.Save(webSiteMock.Object);

            webSiteRepositoryMock.Verify(repository => repository.Save(webSiteMock.Object), Times.Exactly(1));
            Assert.IsTrue(webSite == webSiteMock.Object);
        }

        /// <summary>
        /// Webs the site_ delete test.
        /// </summary>
        [Test]
        public void WebSite_DeleteTest()
        {
            var webSiteRepositoryMock = new Mock<IWebSiteRepository>();
            var webSiteMock = new Mock<WebSite>();
            webSiteMock.Object.Id = 1;
            webSiteMock.Object.SiteName = "www.google.com";

            webSiteRepositoryMock.Setup(repository => repository.Delete(webSiteMock.Object));

            WebSiteUnitOfWork unitOfWork = new WebSiteUnitOfWork(webSiteRepositoryMock.Object);
            unitOfWork.Delete(webSiteMock.Object);

            webSiteRepositoryMock.Verify(repository => repository.Delete(webSiteMock.Object), Times.Exactly(1));
        }

        /// <summary>
        /// Webs the site_ delete test.
        /// </summary>
        [Test]
        public void WebSite_GetById()
        {
            var webSiteRepositoryMock = new Mock<IWebSiteRepository>();
            var webSiteMock = new Mock<WebSite>();
            webSiteMock.Object.Id = 0;
            webSiteMock.Object.SiteName = "www.google.com";

            webSiteRepositoryMock.Setup(repository => repository.GetById(It.Is<long>(id => id > 0 && id < 6)))
                    .Returns(webSiteMock.Object);

            WebSiteUnitOfWork unitOfWork = new WebSiteUnitOfWork(webSiteRepositoryMock.Object);
            for (long i = 1; i <= 2; i++)
            {
                unitOfWork.GetById(i);
            }

            webSiteRepositoryMock.Verify(repository => repository.GetById(It.Is<long>(id => id > 0 && id < 6)), Times.Exactly(2));
        }

        /// <summary>
        /// Webs the site_ list.
        /// </summary>
        [Test]
        public void WebSite_List()
        {
            var webSiteRepositoryMock = new Mock<IWebSiteRepository>();
            List<WebSite> webSites = new List<WebSite>();

            webSiteRepositoryMock.Setup(repository => repository.List)
                    .Returns(webSites.AsQueryable());

            WebSiteUnitOfWork unitOfWork = new WebSiteUnitOfWork(webSiteRepositoryMock.Object);
            List<WebSite> webSiteList = unitOfWork.List;

            webSiteRepositoryMock.Verify(repository => repository.List, Times.AtLeastOnce());
            Assert.True(webSiteList.Count == 0);
        }
    }
}
