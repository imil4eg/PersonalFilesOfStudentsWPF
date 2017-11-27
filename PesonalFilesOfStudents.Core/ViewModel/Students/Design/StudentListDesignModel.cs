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
        private static StudentListDesignModel _instance; //=> new StudentListDesignModel();

        #endregion

        #region Propetry

        public static StudentListDesignModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StudentListDesignModel();

                return _instance;
            }
        }

        #endregion

        #region Contructor

        /// <summary>
        /// Default contructor
        /// </summary>
        private StudentListDesignModel()
        {
            Items = SqlDbConnect.CreateStudentsListViewModel();
        }

        #endregion

        #region Methods

        //public static StudentListDesignModel Instance()
        //{
        //    if(_instance == null)
        //        return new StudentListDesignModel();

        //    return _instance;
        //}

        #endregion
    }
}
