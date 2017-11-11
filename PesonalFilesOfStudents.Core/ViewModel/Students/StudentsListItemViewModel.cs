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
        /// The display name of this chat list
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The latest message from this chat
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The initials to show for the profile picture background
        /// </summary>
        public string Initials { get; set; }

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
            IoC.Application.GoToPage(ApplicationPage.Students, new StudentsListViewModel());
            //{

            //    Items = new List<StudentsListItemViewModel>
            //    {
            //        new StudentsListItemViewModel
            //        {
            //            Message = Message,
            //            Initials = Initials,
            //            ProfilePictureRGB = "FF00FF"
            //        },
            //        new StudentsListItemViewModel
            //        {
            //            Message = "A recived message",
            //            Initials = Initials,
            //            ProfilePictureRGB = "fF0000"
            //        },
            //        new StudentsListItemViewModel
            //        {
            //            Message = "A recived message",
            //            Initials = Initials,
            //            ProfilePictureRGB = "fF0000"
            //        },
            //        new StudentsListItemViewModel
            //        {
            //            Message = "A recived message",
            //            Initials = Initials,
            //            ProfilePictureRGB = "fF0000"
            //        },
            //        new StudentsListItemViewModel
            //        {
            //            Message = "A recived message",
            //            Initials = Initials,
            //            ProfilePictureRGB = "fF0000"
            //        },

            //    }
            //});
        }

        #endregion
    }
}
