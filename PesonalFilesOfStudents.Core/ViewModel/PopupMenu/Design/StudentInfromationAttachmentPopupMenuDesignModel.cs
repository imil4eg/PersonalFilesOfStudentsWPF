using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PesonalFilesOfStudents.Core;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// The design-time data for a <see cref="StudentInformationAttachmentPopupMenuViewModel"/>
    /// </summary>
    public class StudentInfromationAttachmentPopupMenuDesignModel : StudentInformationAttachmentPopupMenuViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static StudentInfromationAttachmentPopupMenuDesignModel Instance => new StudentInfromationAttachmentPopupMenuDesignModel();

        #endregion

        #region Contructor

        /// <summary>
        /// Default contructor
        /// </summary>
        public StudentInfromationAttachmentPopupMenuDesignModel()
        {

        }

        #endregion
    }
}
