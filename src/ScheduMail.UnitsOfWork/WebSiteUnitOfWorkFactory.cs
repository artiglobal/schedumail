using ScheduMail.Core.UnitsOfWorkRepository;
using ScheduMail.EFDal.Dal;

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
            return new WebSiteUnitOfWork(new EFWebSiteRepository());
        }

        /// <summary>
        /// Gets the log event unit of work.
        /// </summary>
        /// <returns>LogEvent Unit of Work instance.</returns>
        public ScheduMail.Core.UnitsOfWorkFactory.IlogEventUnitOfWork GetLogEventUnitOfWork()
        {
            return new LogEventUnitOfWork(new EFLogEventRepository());
        }

        /// <summary>
        /// Gets the mail unit of work.
        /// </summary>
        /// <returns>List of mails.</returns>
        public ScheduMail.Core.UnitsOfWorkFactory.IMailUnitOfWork GetMailUnitOfWork()
        {
            return new MailUnitOfWork(new EFMailRepository());
        }

        /// <summary>
        /// Gets the ASP net unit of work.
        /// </summary>
        /// <returns>List of AspNet Users.</returns>
        public ScheduMail.Core.UnitsOfWorkFactory.IAspNetUnitOfWork GetAspNetUnitOfWork()
        {
            return new AspNetUserOfWork(new EFAspNetUsersRepository());
        }

        #endregion
    }
}
