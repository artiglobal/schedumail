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
    public interface IScheduleUnitOfWork
    {
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The Web site list.</value>
        List<Schedule> List { get; }

        /// <summary>
        /// Saves the specified web site.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        /// <returns>Changed Web site instance.</returns>
        ScheduMail.Core.Domain.Schedule Save(Schedule schedule);

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The Web site id.</param>
        /// <returns>Web Site instance.</returns>
        ScheduMail.Core.Domain.Schedule GetById(long id);

        /// <summary>
        /// Deletes the specified web site.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        void Delete(Schedule schedule);
    }
}
