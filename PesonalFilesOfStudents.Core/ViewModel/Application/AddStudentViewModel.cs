using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// The add student state as a view model
    /// </summary>
    public class AddStudentViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The current students name
        /// </summary>
        public TextEntryViewModel FirstName { get; set; }

        /// <summary>
        /// The current students middle name
        /// </summary>
        public TextEntryViewModel MiddleName { get; set; }

        /// <summary>
        /// The current students last name
        /// </summary>
        public TextEntryViewModel LastName { get; set; }

        /// <summary>
        /// The current students birdth date
        /// </summary>
        public TextEntryViewModel BirthDate { get; set; }

        /// <summary>
        /// The current students place of living
        /// </summary>
        public TextEntryViewModel Registration { get; set; }

        /// <summary>
        /// The current students course number
        /// </summary>
        public TextEntryViewModel Course { get; set; }

        /// <summary>
        /// The current students group number
        /// </summary>
        public TextEntryViewModel Group { get; set; }

        /// <summary>
        /// The current students faculty number
        /// </summary>
        public TextEntryViewModel Faculty { get; set; }

        /// <summary>
        /// The current students gender
        /// </summary>
        public TextEntryViewModel Gender { get; set; }

        /// <summary>
        /// The current students profile photo
        /// </summary>
        public TextEntryViewModel ProfilePhoto { get; set; }

        #endregion

        #region Public Command

        /// <summary>
        /// The command to close the add student menu
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to open the add student menu
        /// </summary>
        public ICommand OpenCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AddStudentViewModel()
        {
            // Create commands
            CloseCommand = new RelayCommand(Close);
            OpenCommand = new RelayCommand(Open);
        }

        #endregion

        /// <summary>
        /// Close the add student menu
        /// </summary>
        public void Close()
        {
            // Close add student menu
            IoC.Application.AddStudentMenuVisible = false;
            IoC.Application.SideMenuVisible = true;
        }

        /// <summary>
        /// Open the add student menu
        /// </summary>
        public void Open()
        {
            // Open add student menu
            IoC.Application.SideMenuVisible = false;
            IoC.Application.AddStudentMenuVisible = true;
        }
    }
}
