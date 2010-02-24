using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.Core.RepositoryInterfaces;

namespace ScheduMail.EFDal.Dal
{
    /// <summary>
    /// Web site repository crud operations for Schedule
    /// </summary>
    public class EFScheduleRepositary : IScheduleRepository
    {
        #region IScheduleRepository Members

        /// <summary>
        /// Adds the Schedule instance into the dataabse
        /// </summary>
        /// <param name="schedule">Schedule instance.</param>
        /// <returns>true or false value.</returns>
        public bool Add(ScheduMail.DBModel.Schedule schedule)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update the Schedule instance into the dataabse
        /// </summary>
        /// <param name="schedule">contains all the values of schedulee</param>
        /// <returns>true/false as a sucess message</returns>
        public bool Update(ScheduMail.DBModel.Schedule schedule)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete the Schedule instance from the dataabse
        /// </summary>
        /// <param name="id">id of the schedule</param>
        /// <returns>true/false as a sucess message</returns>
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returnts the object of  Schedule from ID
        /// </summary>
        /// <param name="id">id of the schedule to return</param>
        /// <returns>object of Schedule</returns>
        public ScheduMail.DBModel.Schedule Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns all the instance from database of schedules
        /// </summary>
        /// <returns>return as a list</returns>
        public List<ScheduMail.DBModel.Schedule> GetAll()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
