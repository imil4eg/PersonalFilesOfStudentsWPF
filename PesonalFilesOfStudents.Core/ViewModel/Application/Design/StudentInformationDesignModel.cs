namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// The design-time data for a <see cref="StudentsInformationViewModel"/>
    /// </summary>
    public class StudentInformationDesignModel : StudentsInformationViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static StudentInformationDesignModel Instance => new StudentInformationDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public StudentInformationDesignModel()
        {

        }

        #endregion
    }
}
