using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// The application state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        /// <summary>
        /// The view model to use for the current page when the CurrentPage changes
        /// NOTE : This is not a live up-to-date view model of the current page 
        ///        it is simply use to set the view model of the current page
        ///        at the time it changes
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

        /// <summary>
        /// True if the side menu should be shown
        /// </summary>
        public bool SideMenuVisible { get; set; } = false;

        /// <summary>
        /// True if the add student menu should be shown
        /// </summary>
        public bool AddStudentMenuVisible { get; set; }


        #endregion

        #region Consturctor

        /// <summary>
        /// Default contructor
        /// </summary>
        public ApplicationViewModel()
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">The page to go to</param>
        /// <param name="viewModel">The view model, if any , to set explicitly to the new page</param>
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {

            // Set the current page 
            CurrentPage = page;

            // Show side menu or not?
            SideMenuVisible = page == ApplicationPage.Students;

        }

        #endregion
    }
}
