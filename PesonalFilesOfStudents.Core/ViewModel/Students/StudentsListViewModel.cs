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

            Items = CreateStudentsListViewModel();
        }

        #endregion


        private List<StudentsListItemViewModel> CreateStudentsListViewModel()
        {
            List<StudentsListItemViewModel> studs = new List<StudentsListItemViewModel>();

            foreach (var stud in SqlDbConnect.TakeStudents())
            {
                studs.Add(new StudentsListItemViewModel
                {
                    FirstName = stud.LastName + " " + stud.FirstName + " " + stud.MiddleName,
                    Group = stud.Group
                });
            }

            return studs;
        }
    }
}
