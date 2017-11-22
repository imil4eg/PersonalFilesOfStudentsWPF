using System.Collections.Generic;
using System.Windows.Input;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// A view model for the overview students list 
    /// </summary>
    public class StudentsListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The students list items for the list
        /// </summary>
        public List<StudentsListItemViewModel> Items { get; set; }

        #endregion

        #region Contructor

        /// <summary>
        /// Defualt contructer
        /// </summary>
        public StudentsListViewModel()
        {

            
        }

        #endregion
    }
}
