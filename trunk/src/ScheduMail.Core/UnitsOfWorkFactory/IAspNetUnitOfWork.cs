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
    public interface IAspNetUnitOfWork
    {
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list of users.</value>
        List<AspnetUsers> List { get; }

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="user">The user instance.</param>
        /// <param name="isAdministrator">if set to <c>true</c> [is administrator].</param>
        /// <param name="selectedWebSites">The selected web sites.</param>
        /// <returns>The User instance.</returns>
        ScheduMail.Core.Domain.AspnetUsers Save(AspnetUsers user, bool isAdministrator, string[] selectedWebSites);

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The identifiction of ASPNet user.</param>
        /// <returns>Aspnet user instance.</returns>
        ScheduMail.Core.Domain.AspnetUsers GetById(string id);

        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        /// <param name="user">The user instance.</param>
        void Delete(AspnetUsers user);

        /// <summary>
        /// Gets the ASP ner users by id.
        /// </summary>
        /// <param name="id">The identification passed.</param>
        /// <returns>List of ASP net Users.</returns>
        List<ScheduMail.Core.Domain.AspnetUsers> ListByWebSiteId(long id);
    }
}
