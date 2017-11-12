using System.Windows.Media.Imaging;
using System;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// A view model for each student information 
    /// </summary>
    public class StudentsInformationViewModel : BaseViewModel
    {
        #region  Public Properties

        /// <summary>
        /// Students ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Students first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Students last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Students middle name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Students birth date
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Students living place
        /// </summary>
        public string Registration { get; set; }

        /// <summary>
        /// Students study course
        /// </summary>
        public int Course { get; set; }

        /// <summary>
        /// Students group
        /// </summary>
        public int Group { get; set; }

        /// <summary>
        /// Students faculty
        /// </summary>
        public int Faculty { get; set; }

        /// <summary>
        /// Students gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// The attachment to the image
        /// </summary>
        public StudentsInformationImageViewModel ImageAttachment { get; set; }

        /// <summary>
        /// True to show the attachment menu, false to hide it
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }

        /// <summary>
        /// True if any popup menu are visible 
        /// </summary>
        public bool AnyPopupVisibile => AttachmentMenuVisible;

        /// <summary>
        /// The view model for the attachment menu
        /// </summary>
        public StudentInformationAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command for when the attachment button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        /// <summary>
        /// The command for when the area outside of any popup is clicked
        /// </summary>
        public ICommand PopupClickawayCommand { get; set; }

        #endregion

        #region Contructer

        /// <summary>
        /// Default contructer
        /// </summary>
        public StudentsInformationViewModel()
        {
            // Create commands
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickawayCommand = new RelayCommand(PopupClickaway);

            // Make a default menu
            AttachmentMenu = new StudentInformationAttachmentPopupMenuViewModel();
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// When the attachment button is clicked, show/hide the attachment popup
        /// </summary>
        public void AttachmentButton()
        {
            // Toggle menu visibility
            AttachmentMenuVisible ^= true;
        }

        /// <summary>
        /// When the popup clickaway area is clicked, hide any popups
        /// </summary>
        public void PopupClickaway()
        {
            // Hide attachment menu 
            AttachmentMenuVisible ^= true;
        }


        #endregion

    }
}
