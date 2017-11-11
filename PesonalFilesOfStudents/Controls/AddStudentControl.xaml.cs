using PesonalFilesOfStudents.Core;
using System.Windows.Controls;

namespace PesonalFilesOfStudents
{
    /// <summary>
    /// Interaction logic for AddStudentControl.xaml
    /// </summary>
    public partial class AddStudentControl : UserControl
    {
        public AddStudentControl()
        {
            InitializeComponent();

            // Set data context to addstudent view model
            DataContext = IoC.AddStudent;
        }
    }
}
