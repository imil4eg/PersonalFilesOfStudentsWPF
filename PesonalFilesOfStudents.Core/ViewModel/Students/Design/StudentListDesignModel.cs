using System;
using System.Collections.Generic;
using System.Linq;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// The design-time data for a <see cref="StudentsListViewModel"/>
    /// </summary>
    public class StudentListDesignModel : StudentsListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static StudentListDesignModel Instance => new StudentListDesignModel();

        #endregion

        #region Contructor

        /// <summary>
        /// Default contructor
        /// </summary>
        public StudentListDesignModel()
        {
            Items = SqlDbConnect.CreateStudentsListViewModel();


        }

        #endregion
    }
}
