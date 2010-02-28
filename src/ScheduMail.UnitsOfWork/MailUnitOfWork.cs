using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.Core.UnitsOfWorkFactory;

namespace ScheduMail.UnitsOfWork
{
    /// <summary>
    /// Web site unit of work.
    /// </summary>
    public class MailUnitOfWork : IMailUnitOfWork
    {
        #region IMailUnitOfWork Members

        /// <summary>
        /// Repository handle.
        /// </summary>
        private IMailRespository repository;

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>The repository.</value>
        public IMailRespository Repository
        {
            get { return this.repository; }
            set { this.repository = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MailUnitOfWork"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public MailUnitOfWork(IMailRespository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The Web site list.</value>
        public List<ScheduMail.Core.Domain.Mail> List
        {
            get
            {
                return this.repository.List.ToList();
            }
        }

        /// <summary>
        /// Get a Mail instance by id.
        /// </summary>
        /// <param name="id">The mail instance id.</param>
        /// <returns>mail instance.</returns>
        public ScheduMail.Core.Domain.Mail GetById(long id)
        {
            return this.repository.GetById(id);
        }

        /// <summary>
        /// Saves the specified mail.
        /// </summary>
        /// <param name="schedule">The mail instance.</param>
        /// <returns>Updated Web site instance.</returns>
        public ScheduMail.Core.Domain.Mail Save(ScheduMail.Core.Domain.Mail schedule)
        {
            var errors = this.GetRuleViolations(schedule);
            if (errors.Count > 0)
            {
                throw new RuleException(errors);
            }

            return this.repository.Save(schedule);
        }

        /// <summary>
        /// Deletes the specified mail.
        /// </summary>
        /// <param name="schedule">The schedule instance.</param>
        public void Delete(ScheduMail.Core.Domain.Mail schedule)
        {
            this.repository.Delete(schedule);
        }

        /// <summary>
        /// Gets the rule violations.
        /// </summary>
        /// <param name="schedule">The mail instance.</param>
        /// <returns>Collection of Rules Violations.</returns>
        private NameValueCollection GetRuleViolations(ScheduMail.Core.Domain.Mail schedule)
        {
            var errors = new NameValueCollection();           

            return errors;
        }

        #endregion
    }
}
