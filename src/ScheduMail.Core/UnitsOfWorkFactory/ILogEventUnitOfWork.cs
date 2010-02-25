using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.Core.Domain;

namespace ScheduMail.Core.UnitsOfWorkFactory
{
    /// <summary>
    /// Web Site Unit of Work interface
    /// </summary>
    public interface IlogEventUnitOfWork
    {
        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The Web site id.</param>
        /// <returns>Web Site instance.</returns>
        ScheduMail.Core.Domain.LogEvent GetById(long id);
    }
}
