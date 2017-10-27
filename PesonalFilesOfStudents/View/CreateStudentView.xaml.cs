using PesonalFilesOfStudents.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PesonalFilesOfStudents.View
{
    /// <summary>
    /// Interaction logic for CreateStudentView.xaml
    /// </summary>
    public partial class CreateStudentView : Window
    {
        public CreateStudentView()
        {
            InitializeComponent();
            Loaded += CreateStudentView_Loaded;
        }

        private void CreateStudentView_Loaded(object sender, RoutedEventArgs e)
        {
            Environment.SetEnvironmentVariable("windir", Environment.GetEnvironmentVariable("SystemRoot"),EnvironmentVariableTarget.User);
            DataContext = new CreateStudentViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
