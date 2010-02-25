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
        IlogEventUnitOfWork GetLogEventUnitOfWork();

        #endregion
    }
}
