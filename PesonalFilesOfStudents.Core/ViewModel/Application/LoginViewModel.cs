using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The login of the user
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        #endregion

        #region Contructer

        /// <summary>
        /// Default contructer
        /// </summary>
        public LoginViewModel()
        {
            //Create commands
            LoginCommand = new RelayParametrizedCommand(async(parameter) => await Login(parameter));
        }

        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The<see cref="SecureString"/>Passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {
            await RunCommandAsync(() => this.LoginIsRunning, async () =>
            {
                await Task.Delay(1000);

                // Go to students page
                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Students);

                //var userName = this.UserName;
                //var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        }

    }
}
