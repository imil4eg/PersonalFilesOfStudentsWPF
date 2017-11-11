using PesonalFilesOfStudents.Core;
using System;
using System.Security;
using System.Windows.Controls;


namespace PesonalFilesOfStudents
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel> , IHavePassword
    {
        #region Contructor

        /// <summary>
        /// Default contructor
        /// </summary>
        public LoginPage()
        {
            InitializeComponent();
        }
        

        #endregion
        /// <summary>
        /// The secure password for this login page
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
