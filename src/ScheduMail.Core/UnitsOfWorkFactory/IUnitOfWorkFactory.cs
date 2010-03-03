using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.Core.Domain;
using ScheduMail.Core.UnitsOfWorkFactory;

namespace ScheduMail.Core.UnitsOfWorkRepository
{
    /// <summary>
    /// Unit of Work Factory instance.
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        #region IUnitOfWorkFactory Crud interfaces

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <returns>Interface for Unit of Work.</returns>
        IWebSiteUnitOfWork GetWebSiteUnitOfWork();

        /// <summary>
        /// Gets the log event unit of work.
        /// </summary>
        /// <returns>Log event instance.</returns>
        IlogEventUnitOfWork GetLogEventUnitOfWork();

        /// <summary>
        /// Gets the mail unit of work.
        /// </summary>
        /// <returns>Log event instance.</returns>
        IMailUnitOfWork GetMailUnitOfWork();

        /// <summary>
        /// Gets the ASP net unit of work.
        /// </summary>
        /// <returns>Log event instance.</returns>
        IAspNetUnitOfWork GetAspNetUnitOfWork();

        /// <summary>
        /// Gets the schedule unit of work.
        /// </summary>
        /// <returns>Schedule instance.</returns>
        IScheduleUnitOfWork GetScheduleUnitOfWork();

        #endregion
    }
}
