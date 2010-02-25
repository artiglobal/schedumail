using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.Core.Domain;

namespace ScheduMail.Core.UnitsOfWorkFactory
{
    /// <summary>
    /// Mail Unit of Work interface
    /// </summary>
    public interface IMailUnitOfWork
    {
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list of mails.</value>
        List<Mail> List { get; }      

        /// <summary>
        /// Saves the specified web site.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        /// <returns>Mail instance.</returns>
        ScheduMail.Core.Domain.Mail Save(Mail webSite);

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The identification of mail.</param>
        /// <returns>>Mail instance</returns>
        ScheduMail.Core.Domain.Mail GetById(long id);

        /// <summary>
        /// Deletes the specified web site.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        void Delete(Mail webSite);
    }
}
