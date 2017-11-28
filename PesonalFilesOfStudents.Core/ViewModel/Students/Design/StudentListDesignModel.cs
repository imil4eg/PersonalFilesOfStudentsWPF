using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// The design-time data for a <see cref="StudentsListViewModel"/>
    /// </summary>
    public class StudentListDesignModel : StudentsListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        private static StudentListDesignModel _instance; //=> new StudentListDesignModel();

        #endregion

        #region Protected Members

        /// <summary>
        /// The last searched text in this list
        /// </summary>
        protected string mLastSearchText;

        /// <summary>
        /// The text to search for in the search command
        /// </summary>
        protected string mSearchText;

        /// <summary>
        /// The students thread items for the list
        /// </summary>
        protected ObservableCollection<StudentsListItemViewModel> mItems;

        #endregion

        #region Propetry

        public static StudentListDesignModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StudentListDesignModel();

                return _instance;
            }
        }

        /// <summary>
        /// The students thread items for the list
        /// NOTE : Do not call Items.Add to add students to this list
        ///        as it will make the FilteredItems out of sync
        /// </summary>
        public ObservableCollection<StudentsListItemViewModel> dItems
        {
            get { return mItems; }
            set
            {
                // Make sure list has changed
                if (mItems == value)
                    return;

                // Update value
                mItems = SqlDbConnect.CreateStudentsListViewModel();

                // Update filtered list to match
                FilteredItems = new ObservableCollection<StudentsListItemViewModel>(mItems);
            }
        }

        /// <summary>
        /// The students thread items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<StudentsListItemViewModel> FilteredItems { get; set; }

        /// <summary>
        /// The text to search for when we do a search
        /// </summary>
        public string SearchText
        {
            get { return mSearchText; }
            set
            {
                // Check value is different
                if (mSearchText == value)
                    return;

                // Update value
                mSearchText = value;

                // If the search text is emptry...
                if (string.IsNullOrEmpty(SearchText))
                    // Search to restore messages
                    Search();
            }
        }

        #endregion

        #region Public Command

        /// <summary>
        /// The command when the user want to search
        /// </summary>
        public ICommand SearchCommand { get; set; }

        #endregion

        #region Contructor

        /// <summary>
        /// Default contructor
        /// </summary>
        private StudentListDesignModel()
        {
            mItems = SqlDbConnect.CreateStudentsListViewModel();

            FilteredItems = mItems;

            SearchCommand = new RelayCommand(Search);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Searches the current student list and filters the view 
        /// </summary>
        public void Search()
        {
            // Make sure we don't re-search the same text
            if ((string.IsNullOrEmpty(mLastSearchText) && string.IsNullOrEmpty(SearchText)) ||
                string.Equals(mLastSearchText, SearchText))
                return;

            // If we have no search or no items
            if (string.IsNullOrEmpty(SearchText) || dItems == null || dItems.Count <= 0)
            {
                // Make filtered list the same
                FilteredItems = new ObservableCollection<StudentsListItemViewModel>(dItems);

                // Set last search
                mLastSearchText = SearchText;

                return;
            }

            //// Find all items that contains the given text
            FilteredItems =
                new ObservableCollection<StudentsListItemViewModel>(dItems.Where(item =>
                    item.StudentLastName.ToLower().Contains(SearchText)));

            // Set last search text
            mLastSearchText = SearchText;
        }

        //public static StudentListDesignModel Instance()
        //{
        //    if(_instance == null)
        //        return new StudentListDesignModel();

        //    return _instance;
        //}

        #endregion
    }
}
