using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduMail.Core.Domain
{
    /// <summary>
    /// Base Entity class provides default values for identification and logging purposes.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Identification key for storage in database
        /// </summary>
        private long id = default(long);

        /// <summary>
        /// User object is created by
        /// </summary>
        private string createdBy;

        /// <summary>
        /// Date object was created
        /// </summary>
        private DateTime? created;

        /// <summary>
        /// User object is being modified by
        /// </summary>
        private string modifiedBy;

        /// <summary>
        /// Date object is being modified
        /// </summary>
        private DateTime? modified;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity"/> class.
        /// </summary>
        public BaseEntity()
        {
            // Default object to a newly created object
            this.Created = DateTime.Now;        
            this.Modified = DateTime.Now;         
            this.CreatedBy = Auth.GetUserName;            
            this.ModifiedBy = Auth.GetUserName;
        }

        /// <summary>
        /// Modifies this instance.
        /// </summary>
        public void Modify()
        {
            this.Modified = DateTime.Now;
            this.ModifiedBy = Auth.GetUserName;
        }

        /// <summary>
        /// Determines whether this instance is new.
        /// </summary>
        /// <returns>
        ///    <c>true</c> if this instance is new; otherwise, <c>false</c>.
        /// </returns>
        public bool IsNew()
        {
            return this.id.Equals(default(long));
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Overriden to return the class type
        /// of this object.
        /// </summary>        
        /// <returns>
        /// the class name for this object
        /// </returns>        
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(" Class: ").Append(GetType().FullName);
            return str.ToString();
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id key value.</value>
        public long Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public string CreatedBy
        {
            get
            {
                return this.createdBy;
            }

            set
            {
                this.createdBy = value;
            }
        }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>The created.</value>
        public DateTime? Created
        {
            get
            {
                return this.created;
            }

            set
            {
                this.created = value;
            }
        }

        /// <summary>
        /// Gets or sets the modified by.
        /// </summary>
        /// <value>The modified by.</value>
        public string ModifiedBy
        {
            get
            {
                return this.modifiedBy;
            }

            set
            {
                this.modifiedBy = value;
            }
        }

        /// <summary>
        /// Gets or sets the modified.
        /// </summary>
        /// <value>The modified.</value>
        public DateTime? Modified
        {
            get
            {
                return this.modified;
            }

            set
            {
                this.modified = value;
            }
        }
    }
}
