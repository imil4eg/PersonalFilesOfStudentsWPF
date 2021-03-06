﻿namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// Class that holds information about student parents
    /// </summary>
    public class Parent
    {
        /// <summary>
        /// The current parent id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The students id,which parent is
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// The parents last name
        /// </summary>
        public string ParentLastName { get; set; }

        /// <summary>
        /// The parents first name
        /// </summary>
        public string ParentFirstName { get; set; }

        /// <summary>
        /// The parents middle name
        /// </summary>
        public string ParentMiddleName { get; set; }

        /// <summary>
        /// The parents phone number
        /// </summary>
        public int ParentPhone { get; set; }
    }
}
