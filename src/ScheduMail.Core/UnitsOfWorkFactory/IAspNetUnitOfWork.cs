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
        /// <returns>Aspnet user instance.</returns>
        ScheduMail.Core.Domain.AspnetUsers Save(AspnetUsers user);

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
    }
}
