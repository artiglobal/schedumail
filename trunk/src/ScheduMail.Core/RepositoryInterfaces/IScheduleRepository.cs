using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.DBModel;

namespace ScheduMail.Core.RepositoryInterfaces
{
    /// <summary>
    /// Provides a standard interface for Schedul operations
    /// </summary>
    public interface IScheduleRepository
    {
        /// <summary>
        /// Adds the Schedule instance into the dataabse
        /// </summary>
        /// <param name="schedule">Schedule instance parameter.</param>
        /// <returns>True value indicating whether or not schedule added</returns>
        bool Add(Schedule schedule);

        /// <summary>
        /// Update the Schedule instance into the dataabse
        /// </summary>
        /// <param name="schedule">contains all the values of schedulee</param>
        /// <returns>true/false as a sucess message</returns>        
        bool Update(Schedule schedule);

        /// <summary>
        /// Delete the Schedule instance from the dataabse
        /// </summary>
        /// <param name="id">id of the schedule</param>
        /// <returns>true/false as a sucess message</returns>        
        bool Delete(int id);

        /// <summary>
        /// Returnts the object of  Schedule from ID
        /// </summary>
        /// <param name="id">id of the schedule to return</param>
        /// <returns>object of Schedule</returns>
        Schedule Get(int id);

        /// <summary>
        /// returns all the instance from database of schedules
        /// </summary>
        /// <returns>return as a list</returns>
        List<Schedule> GetAll();
    }
}
