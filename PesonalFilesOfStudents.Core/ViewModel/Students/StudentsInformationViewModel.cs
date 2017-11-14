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
        public TextEntryViewModel ID { get; set; }

        /// <summary>
        /// Students first name
        /// </summary>
        public TextEntryViewModel FirstName { get; set; }

        /// <summary>
        /// Students last name
        /// </summary>
        public TextEntryViewModel LastName { get; set; }

        /// <summary>
        /// Students middle name
        /// </summary>
        public TextEntryViewModel MiddleName { get; set; }

        /// <summary>
        /// Students birth date
        /// </summary>
        public TextEntryViewModel BirthDate { get; set; }

        /// <summary>
        /// Students living place
        /// </summary>
        public TextEntryViewModel Registration { get; set; }

        /// <summary>
        /// Students study course
        /// </summary>
        public TextEntryViewModel Course { get; set; }

        /// <summary>
        /// Students group
        /// </summary>
        public TextEntryViewModel Group { get; set; }

        /// <summary>
        /// Students faculty
        /// </summary>
        public TextEntryViewModel Faculty { get; set; }

        /// <summary>
        /// Students gender
        /// </summary>
        public TextEntryViewModel Gender { get; set; }

        /// <summary>
        /// The attachment to the image
        /// </summary>
        public TextEntryViewModel ImageAttachment { get; set; }

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

            FirstName = new TextEntryDesignModel { Label = "First Name", OriginalText = "Vasya" };
            MiddleName = new TextEntryDesignModel { Label = "Middle Name", OriginalText = "Vasilievich" };
            LastName = new TextEntryDesignModel { Label = "Last Name", OriginalText = "Pupkin" };
            BirthDate = new TextEntryDesignModel { Label = "Birth date", OriginalText = "14-08-1988" };
            Registration = new TextEntryDesignModel { Label = "Registration", OriginalText = "Azino" };
            Course = new TextEntryDesignModel { Label = "Course", OriginalText = "4" };
            Group = new TextEntryDesignModel { Label = "Group", OriginalText = "4132" };
            Faculty = new TextEntryDesignModel { Label = "Faculty", OriginalText = "1" };
            Gender = new TextEntryDesignModel { Label = "Gender", OriginalText = "Male" };
            ImageAttachment = new TextEntryDesignModel { Label = "Profile photo", OriginalText = "lico.png" };
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
