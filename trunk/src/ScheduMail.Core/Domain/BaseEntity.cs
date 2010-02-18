using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduMail.Core.Domain
{
    /// <osummary>
    /// Base Entity class provides default values for identification and logging purposes.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Identification key for storage in database
        /// </summary>
        private int? id = default(int);

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
        }

        /// <summary>
        /// Modifies this instance.
        /// </summary>
        public void Modify()
        {
            this.Modified = DateTime.Now;
        }

        /// <summary>
        /// Transient objects are not associated with an item already in storage.  
        /// For instance, a <see cref="Applicant" /> is transient if its ID is 0.
        /// </summary>
        public bool IsNew()
        {
            return id.Equals(default(int));
        }

        /// <summary>
        /// Must be provided to properly compare two objects
        /// </summary>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Overriden to return the class type
        /// of this object.
        /// </summary>
        /// 
        /// <returns>
        /// the class name for this object
        /// </returns>
        /// 
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(" Class: ").Append(GetType().FullName);
            return str.ToString();
        }

        public int? Id
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
