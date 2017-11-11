namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// The design-time data for a <see cref="StudentsListItemViewModel"/>
    /// </summary>
    public class StudentListItemDesignModel : StudentsListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static StudentListItemDesignModel Instance => new StudentListItemDesignModel(); 

        #endregion

        #region Contructor

        /// <summary>
        /// Default contructor
        /// </summary>
        public StudentListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            Message = "This app is awesome! I bet it will be fast too";
            ProfilePictureRGB = "3099c5";
        }

        #endregion
    }
}
