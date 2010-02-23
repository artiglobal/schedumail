using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduMail.Core.Domain
{
    /// <summary>
    /// Flat Dto to hold user created email details.
    /// </summary>
    public class WebSiteEMails
    {
        /// <summary>
        /// Gets or sets the log id.
        /// </summary>
        /// <value>The log id.</value>
        public int LogId { get; set; }

        /// <summary>
        /// Gets or sets the E mail subject.
        /// </summary>
        /// <value>The E mail subject.</value>
        public string EMailSubject { get; set; }

        /// <summary>
        /// Gets or sets the last sent.
        /// </summary>
        /// <value>The last sent.</value>
        public DateTime LastSent { get; set; }

        /// <summary>
        /// Gets or sets the next send.
        /// </summary>
        /// <value>The next send.</value>
        public DateTime NextSend { get; set; }      
    }
}
