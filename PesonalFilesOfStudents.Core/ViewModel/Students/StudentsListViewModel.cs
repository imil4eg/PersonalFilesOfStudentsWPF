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

        /// <summary>
        /// True to show the attachment menu, false to hide it
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command for when the attachment button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        /// <summary>
        /// The command for when add button is clicked
        /// </summary>
        public ICommand AddButtonCommand { get; set; }

        #endregion

        #region Contructor

        /// <summary>
        /// Defualt contructer
        /// </summary>
        public StudentsListViewModel()
        {
            // Creates commands
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            AddButtonCommand = new RelayCommand(AddButton);

            Items = CreateStudentsListViewModel();
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
        /// When the ADD button is clicked, slide out side menu and show add student form
        /// </summary>
        public void AddButton()
        {

        }

        #endregion

        private List<StudentsListItemViewModel> CreateStudentsListViewModel()
        {
            List<StudentsListItemViewModel> studs = new List<StudentsListItemViewModel>();

            foreach (var stud in SqlDbConnect.TakeStudents())
            {
                studs.Add(new StudentsListItemViewModel
                {
                    Name = stud.LastName + " " + stud.FirstName + " " + stud.MiddleName,
                    Message = stud.Group.ToString()
                });
            }

            return studs;
        }
    }
}
