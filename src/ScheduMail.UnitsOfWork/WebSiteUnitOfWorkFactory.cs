using ScheduMail.Core.UnitsOfWorkRepository;
using ScheduMail.EFDal.Dal;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.Core.Facade;

namespace ScheduMail.UnitsOfWork
{
    /// <summary>
    /// Factory class for Units of Work,
    /// </summary>
    public class WebSiteUnitOfWorkFactory : IUnitOfWorkFactory
    {
        #region IUnitOfWorkFactory Members

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <returns>Web site unit of work unstance.</returns>
        public ScheduMail.Core.UnitsOfWorkFactory.IWebSiteUnitOfWork GetWebSiteUnitOfWork()
        {
            IWebSiteRepository webSiteRepository = ServiceLocator.Resolve<IWebSiteRepository>();
            return new WebSiteUnitOfWork(webSiteRepository);
        }

        /// <summary>
        /// Gets the log event unit of work.
        /// </summary>
        /// <returns>LogEvent Unit of Work instance.</returns>
        public ScheduMail.Core.UnitsOfWorkFactory.IlogEventUnitOfWork GetLogEventUnitOfWork()
        {
            ILogEventRepository logEventRepository = ServiceLocator.Resolve<ILogEventRepository>();
            return new LogEventUnitOfWork(logEventRepository);            
        }

        /// <summary>
        /// Gets the mail unit of work.
        /// </summary>
        /// <returns>List of mails.</returns>
        public ScheduMail.Core.UnitsOfWorkFactory.IMailUnitOfWork GetMailUnitOfWork()
        {
            IMailRespository mailRepository = ServiceLocator.Resolve<IMailRespository>();
            return new MailUnitOfWork(mailRepository);        
        }

        /// <summary>
        /// Gets the ASP net unit of work.
        /// </summary>
        /// <returns>List of AspNet Users.</returns>
        public ScheduMail.Core.UnitsOfWorkFactory.IAspNetUnitOfWork GetAspNetUnitOfWork()
        {
            IASPNetUserRepository userRepository = ServiceLocator.Resolve<IASPNetUserRepository>();
            return new AspNetUserOfWork(userRepository);               
        }

        #endregion
    }
}
