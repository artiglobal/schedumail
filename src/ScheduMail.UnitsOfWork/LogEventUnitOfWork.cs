﻿using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.Core.UnitsOfWorkFactory;

namespace ScheduMail.UnitsOfWork
{
    /// <summary>
    /// Log Vvent unit of work.
    /// </summary>
    public class LogEventUnitOfWork : IlogEventUnitOfWork
    {
        #region IlogEventUnitOfWork Members

         /// <summary>
        /// Repository handle.
        /// </summary>
        private ILogEventRepository repository;

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>The repository.</value>
        public ILogEventRepository Repository
        {
            get { return this.repository; }
            set { this.repository = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEventUnitOfWork"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public LogEventUnitOfWork(ILogEventRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The Web site id.</param>
        /// <returns>Web Site instance.</returns>
        ScheduMail.Core.Domain.LogEvent IlogEventUnitOfWork.GetById(long id)
        {
            return this.repository.GetById(id);
        }

        #endregion
    }
}
