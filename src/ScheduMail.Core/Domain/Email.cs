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
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        
        /// <summary>Indicate if email should be sent as high priority</summary>
        public bool HighPriority { get; set; }

        /// <summary>True indicates email should be left in pickup directory</summary>
        public bool FireAndForget { get; set; }

        /// <summary>True indicates alternative SMTP settings to be used</summary>
        public bool UseBackupSMTP { get; set; }

        public Email()
        {
            HighPriority = false;
            FireAndForget = false;
            UseBackupSMTP = false;
        }
    }
}
