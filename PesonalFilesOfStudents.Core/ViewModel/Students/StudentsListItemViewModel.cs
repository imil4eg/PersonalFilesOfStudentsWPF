using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// A view model for each students list item in the overview students list
    /// </summary>
    public class StudentsListItemViewModel : BaseViewModel
    {
        #region Public Properties

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
        public string ProfilePicture { get; set; }

        /// <summary>
        /// The RGB values (in hex) for the background color of the profile picture
        /// For example FF00FF for Red and Blue mixed
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        /// <summary>
        /// True if this item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Opens the current information thread
        /// </summary>
        public ICommand OpenInformationCommand { get; set; }

        #endregion

        #region Contructor

        /// <summary>
        /// Default contructor
        /// </summary>
        public StudentsListItemViewModel()
        {
            // Create commands
            OpenInformationCommand = new RelayCommand(OpenInformation);   
        }

        #endregion

        #region Command Methods

        public void OpenInformation()
        {
            IoC.Application.GoToPage(ApplicationPage.Students, new StudentsInformationViewModel()
            {
                ID = new TextEntryViewModel() { Label = "Student ID", OriginalText = ID.ToString()},
                FirstName = new TextEntryDesignModel { Label = "First Name", OriginalText = FirstName },
                MiddleName = new TextEntryDesignModel { Label = "Middle Name", OriginalText = MiddleName },
                LastName = new TextEntryDesignModel { Label = "Last Name", OriginalText = LastName },
                BirthDate = new TextEntryDesignModel { Label = "Birth date", OriginalText = BirthDate.ToString() },
                Registration = new TextEntryDesignModel { Label = "Registration", OriginalText = Registration },
                Course = new TextEntryDesignModel { Label = "Course", OriginalText = Course.ToString() },
                Group = new TextEntryDesignModel { Label = "Group", OriginalText = Group.ToString() },
                Faculty = new TextEntryDesignModel { Label = "Faculty", OriginalText = Faculty.ToString() },
                Gender = new TextEntryDesignModel { Label = "Gender", OriginalText = Gender.ToString() },
                ImageAttachment = new TextEntryDesignModel { Label = "Profile photo", OriginalText = "lico.png" }
            });
        }

        #endregion
    }
}
