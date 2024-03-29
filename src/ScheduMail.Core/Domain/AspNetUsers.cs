﻿/***************************************************************************************************
// -- Generated by AlteraxGen 19/02/2010 12:00:16
// Version 1.0
***************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduMail.Core.Domain
{
    /// <summary>
    /// ASPNet user table.
    /// </summary>
    [Serializable]
    public class AspnetUsers
    {        
        /// <summary>
        /// User id private member variable.
        /// </summary>
        private string userId;
        
        /// <summary>
        /// Username private member variable.
        /// </summary>
        private string username;

        /// <summary>
        /// Lowered username private member variable.
        /// </summary>
        private string loweredUsername;

        /// <summary>
        /// ApplicationId private member variable.
        /// </summary>
        private string applicationId;

        /// <summary>
        /// EMail private member variable.
        /// </summary>
        private string email;

        /// <summary>
        /// LoweredEmail private member variable.
        /// </summary>
        private string loweredEmail;

        /// <summary>
        /// Comment private member variable.
        /// </summary>
        private string comment;

        /// <summary>
        /// Password private member variable.
        /// </summary>
        private string password;

        /// <summary>
        /// PasswordFormat private member variable.
        /// </summary>
        private string passwordFormat;

        /// <summary>
        /// User PasswordSalt private member variable.
        /// </summary>
        private string passwordSalt;

        /// <summary>
        /// Password question private member variable.
        /// </summary>
        private string passwordQuestion;

        /// <summary>
        /// User PasswordAnswer private member variable.
        /// </summary>
        private string passwordAnswer;

        /// <summary>
        /// Approved private member variable.
        /// </summary>
        private bool isApproved;

        /// <summary>
        /// Anonymous check private member variable.
        /// </summary>
        private bool isAnonymous;

        /// <summary>
        /// LastActivityDate private member variable.
        /// </summary>
        private DateTime lastActivityDate;

        /// <summary>
        /// LastLoginDate private member variable.
        /// </summary>
        private DateTime lastLoginDate;

        /// <summary>
        /// LastPasswordChangedDate private member variable.
        /// </summary>
        private DateTime lastPasswordChangedDate;

        /// <summary>
        /// CreateDate private member variable.
        /// </summary>
        private DateTime createDate;

        /// <summary>
        /// Is LockedOut private member variable.
        /// </summary>
        private bool isLockedOut;

        /// <summary>
        /// LastLockoutDate private member variable.
        /// </summary>
        private DateTime lastLockoutDate;

        /// <summary>
        /// FailedPasswordAttemptCount private member variable.
        /// </summary>
        private int failedPasswordAttemptCount;

        /// <summary>
        /// FailedPasswordAttemptWindowStart private member variable.
        /// </summary>
        private DateTime failedPasswordAttemptWindowStart;

        /// <summary>
        /// Failed PasswordAnswerAttemptCount private member variable.
        /// </summary>
        private int failedPasswordAnswerAttemptCount;

        /// <summary>
        /// FailedPasswordAnswerAttemptWindowStart member variable.
        /// </summary>
        private DateTime failedPasswordAnswerAttemptWindowStart;

        /// <summary>
        /// List of associated web sites
        /// </summary>
        private List<WebSite> webSites;

        /// <summary>
        /// Initializes a new instance of the <see cref="AspnetUsers"/> class.
        /// </summary>
        public AspnetUsers()
        {
        }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id.</value>
        public string UserId
        {
            get
            {
                return this.userId;
            }

            set
            {
                this.userId = value;
            }
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                this.username = value;
            }
        }

        /// <summary>
        /// Gets or sets the lowered username.
        /// </summary>
        /// <value>The lowered username.</value>
        public string LoweredUsername
        {
            get
            {
                return this.loweredUsername;
            }

            set
            {
                this.loweredUsername = value;
            }
        }

        /// <summary>
        /// Gets or sets the application id.
        /// </summary>
        /// <value>The application id.</value>
        public string ApplicationId
        {
            get
            {
                return this.applicationId;
            }

            set
            {
                this.applicationId = value;
            }
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        /// <summary>
        /// Gets or sets the lowered email.
        /// </summary>
        /// <value>The lowered email.</value>
        public string LoweredEmail
        {
            get
            {
                return this.loweredEmail;
            }

            set
            {
                this.loweredEmail = value;
            }
        }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>The comment.</value>
        public string Comment
        {
            get
            {
                return this.comment;
            }

            set
            {
                this.comment = value;
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
            }
        }

        /// <summary>
        /// Gets or sets the password format.
        /// </summary>
        /// <value>The password format.</value>
        public string PasswordFormat
        {
            get
            {
                return this.passwordFormat;
            }

            set
            {
                this.passwordFormat = value;
            }
        }

        /// <summary>
        /// Gets or sets the password salt.
        /// </summary>
        /// <value>The password salt.</value>
        public string PasswordSalt
        {
            get
            {
                return this.passwordSalt;
            }

            set
            {
                this.passwordSalt = value;
            }
        }

        /// <summary>
        /// Gets or sets the password question.
        /// </summary>
        /// <value>The password question.</value>
        public string PasswordQuestion
        {
            get
            {
                return this.passwordQuestion;
            }

            set
            {
                this.passwordQuestion = value;
            }
        }

        /// <summary>
        /// Gets or sets the password answer.
        /// </summary>
        /// <value>The password answer.</value>
        public string PasswordAnswer
        {
            get
            {
                return this.passwordAnswer;
            }

            set
            {
                this.passwordAnswer = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is approved.
        /// </summary>
        /// <value>
        ///    <c>true</c> if this instance is approved; otherwise, <c>false</c>.
        /// </value>
        public bool IsApproved
        {
            get
            {
                return this.isApproved;
            }

            set
            {
                this.isApproved = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is anonymous.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is anonymous; otherwise, <c>false</c>.
        /// </value>
        public bool IsAnonymous
        {
            get
            {
                return this.isAnonymous;
            }

            set
            {
                this.isAnonymous = value;
            }
        }

        /// <summary>
        /// Gets or sets the last activity date.
        /// </summary>
        /// <value>The last activity date.</value>
        public DateTime LastActivityDate
        {
            get
            {
                return this.lastActivityDate;
            }

            set
            {
                this.lastActivityDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the last login date.
        /// </summary>
        /// <value>The last login date.</value>
        public DateTime LastLoginDate
        {
            get
            {
                return this.lastLoginDate;
            }

            set
            {
                this.lastLoginDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the last password changed date.
        /// </summary>
        /// <value>The last password changed date.</value>
        public DateTime LastPasswordChangedDate
        {
            get
            {
                return this.lastPasswordChangedDate;
            }

            set
            {
                this.lastPasswordChangedDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>The create date.</value>
        public DateTime CreateDate
        {
            get
            {
                return this.createDate;
            }

            set
            {
                this.createDate = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is locked out.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is locked out; otherwise, <c>false</c>.
        /// </value>
        public bool IsLockedOut
        {
            get
            {
                return this.isLockedOut;
            }

            set
            {
                this.isLockedOut = value;
            }
        }

        /// <summary>
        /// Gets or sets the last lockout date.
        /// </summary>
        /// <value>The last lockout date.</value>
        public DateTime LastLockoutDate
        {
            get
            {
                return this.lastLockoutDate;
            }

            set
            {
                this.lastLockoutDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the failed password attempt count.
        /// </summary>
        /// <value>The failed password attempt count.</value>
        public int FailedPasswordAttemptCount
        {
            get
            {
                return this.failedPasswordAttemptCount;
            }

            set
            {
                this.failedPasswordAttemptCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the failed password attempt window start.
        /// </summary>
        /// <value>The failed password attempt window start.</value>
        public DateTime FailedPasswordAttemptWindowStart
        {
            get
            {
                return this.failedPasswordAttemptWindowStart;
            }

            set
            {
                this.failedPasswordAttemptWindowStart = value;
            }
        }

        /// <summary>
        /// Gets or sets the failed password answer attempt count.
        /// </summary>
        /// <value>The failed password answer attempt count.</value>
        public int FailedPasswordAnswerAttemptCount
        {
            get
            {
                return this.failedPasswordAnswerAttemptCount;
            }

            set
            {
                this.failedPasswordAnswerAttemptCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the failed password answer attempt window start.
        /// </summary>
        /// <value>The failed password answer attempt window start.</value>
        public DateTime FailedPasswordAnswerAttemptWindowStart
        {
            get
            {
                return this.failedPasswordAnswerAttemptWindowStart;
            }

            set
            {
                this.failedPasswordAnswerAttemptWindowStart = value;
            }
        }

        /// <summary>
        /// Gets or sets the web sites.
        /// </summary>
        /// <value>The web sites.</value>
        public List<WebSite> WebSites
        {
            get 
            { 
                return this.webSites; 
            }

            set 
            { 
                this.webSites = value; 
            }
        }
    }
}
