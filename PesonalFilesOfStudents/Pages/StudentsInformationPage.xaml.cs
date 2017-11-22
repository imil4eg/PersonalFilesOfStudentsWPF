using PesonalFilesOfStudents.Core;
using System;
using System.Security;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace PesonalFilesOfStudents
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class StudentsInformationPage : BasePage<StudentsInformationViewModel>
    {
        #region Constructor

        /// <summary>
        /// Default contructor
        /// </summary>
        public StudentsInformationPage() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructer with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use for this page</param>
        public StudentsInformationPage(StudentsInformationViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Fired when the view model changes
        /// </summary>
        protected override void OnViewModelChanged()
        {
            // Make sure UI exists first
            if (StudentInformation == null)
                return;

            // Fade in information 
            var storyboard = new Storyboard();
            storyboard.AddFadeIn(1);
            storyboard.Begin(StudentInformation);
        }

        #endregion
    }
}
