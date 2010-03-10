using System;

namespace ScheduMail.Core.Domain
{
    /// <summary>
    /// Mail template definition. Used to define Email 
    /// template for forwarding on to recipients.
    /// </summary>
    [Serializable]
    public class Email
    {
        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>From.</value>
        public string From { get; set; }
        /// <summary>
        /// Gets or sets to.
        /// </summary>
        /// <value>To.</value>
        public string To { get; set; }
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        public string Subject { get; set; }
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public string Body { get; set; }

        /// <summary>
        /// Indicate if email should be sent as high priority
        /// </summary>
        /// <value><c>true</c> if [high priority]; otherwise, <c>false</c>.</value>
        public bool HighPriority { get; set; }

        /// <summary>True indicates email should be left in pickup directory</summary>
        public bool FireAndForget { get; set; }

        /// <summary>
        /// True indicates alternative SMTP settings to be used
        /// </summary>
        /// <value><c>true</c> if [use backup SMTP]; otherwise, <c>false</c>.</value>
        public bool UseBackupSMTP { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> class.
        /// </summary>
        public Email()
        {
            HighPriority = false;
            FireAndForget = false;
            UseBackupSMTP = false;
        }
    }
}
