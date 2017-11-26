using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// A view model for the overview students list 
    /// </summary>
    public class StudentsListViewModel : BaseViewModel
    {
        #region Lists

        public ObservableCollection<StudentsListItemViewModel> _items;

        #endregion

        #region Public Properties

        /// <summary>
        /// The students list items for the list
        /// </summary>
        public ObservableCollection<StudentsListItemViewModel> Items
        {
            get { return _items; }
            set { _items = value;
                OnPropertyChanged(
                    nameof(Items));
            }
        }

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
