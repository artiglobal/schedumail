using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ScheduMail.Utils
{
    /// <summary>
    /// Extension methods to provide shallow copies on objects
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// Clones the specified entity.
        /// </summary>
        /// <typeparam name="T">Type to clone.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>cloned type</returns>
        public static T Clone<T>(this T entity)
        {
            PropertyInfo[] pis = entity.GetType().GetProperties();

            object o = Activator.CreateInstance(typeof(T));

            // foreach (PropertyInfo pi in pis)
            foreach (var pi in pis)
            {
                o.GetType().GetProperty(pi.Name).SetValue(o, pi.GetValue((object)entity, null), null);
            }

            return (T)o;
        }

        /// <summary>
        /// Clones the properties.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="origin">The origin.</param>
        /// <param name="destination">The destination.</param>
        public static void CloneProperties<T1, T2>(this T1 origin, T2 destination)
        {
            // Instantiate if necessary
            if (destination == null)
            {
                throw new ArgumentNullException("destination", "Destination object must first be instantiated.");
            }

            // Loop through each property in the destination
            foreach (var destinationProperty in destination.GetType().GetProperties())
            {
                // find and set val if we can find a matching property name and matching type in the origin with the origin's value
                if (origin != null && destinationProperty.CanWrite)
                {
                    origin.GetType().GetProperties().Where(x => x.CanRead && (x.Name == destinationProperty.Name && x.PropertyType == destinationProperty.PropertyType))
                        .ToList()
                        .ForEach(x => destinationProperty.SetValue(destination, x.GetValue(origin, null), null));
                }
            }
        }

        /// <summary>
        /// Clones the properties.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="origin">The origin.</param>
        /// <returns>cloned type</returns>
        public static T2 CloneProperties<T1, T2>(this T1 origin)
        {
            // Instantiate if necessary
            T2 destination = Activator.CreateInstance<T2>();
            if (destination == null)
            {
                throw new ArgumentNullException("destination", "Destination object must first be instantiated.");
            }

            // Loop through each property in the destination
            foreach (var destinationProperty in destination.GetType().GetProperties())
            {
                // find and set val if we can find a matching property name and matching type in the origin with the origin's value
                if (origin != null && destinationProperty.CanWrite)
                {
                    origin.GetType().GetProperties().Where(x => x.CanRead && (x.Name == destinationProperty.Name && x.PropertyType == destinationProperty.PropertyType))
                        .ToList()
                        .ForEach(x => destinationProperty.SetValue(destination, x.GetValue(origin, null), null));
                }
            }

            return destination;
        }

        /// <summary>
        /// Clones the list.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="origList">The orig list.</param>
        /// <returns>List of cloned types</returns>
        public static List<T2> CloneList<T1, T2>(List<T1> origList)
        {
            List<T2> destinationList = new List<T2>();
            foreach (T1 orig in origList)
            {
                T2 destination = Activator.CreateInstance<T2>();
                ObjectExtension.CloneProperties<T1, T2>(orig, destination);
                destinationList.Add(destination);
            }

            return destinationList;
        }
    }
}
