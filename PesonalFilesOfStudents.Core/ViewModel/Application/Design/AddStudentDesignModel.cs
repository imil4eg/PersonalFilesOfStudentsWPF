namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// The design-time data for a <see cref="AddStudentViewModel"/>
    /// </summary>
    public class AddStudentDesignModel : AddStudentViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static AddStudentDesignModel Instance => new AddStudentDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AddStudentDesignModel()
        {

        }

        #endregion
    }
}
