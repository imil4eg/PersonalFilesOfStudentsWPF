using PesonalFilesOfStudents.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PesonalFilesOfStudents
{
    /// <summary>
    /// Locates view models from the IoC for use in binding in Xaml files
    /// </summary>
    public class ViewModelLocator
    {
        #region Public Properties

        /// <summary>
        /// Singleton instance of the locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        /// <summary>
        /// The application view model
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => IoC.Application;

        /// <summary>
        /// The add student menu view model
        /// </summary>
        public static AddStudentViewModel AddStudentViewModel => IoC.AddStudent;

        /// <summary>
        /// The Student List model
        /// </summary>
        public static StudentListDesignModel StudentListDesignModel => IoC.StudentListDesignModel;

        #endregion
    }
}
