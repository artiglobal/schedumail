using ScheduMail.Core.UnitsOfWorkRepository;

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
        public ScheduMail.Core.UnitsOfWorkFactory.IWebSiteUnitOfWork GetUnitOfWork()
        {
            return new WebSiteUnitOfWork();
        }

        #endregion
    }
}
