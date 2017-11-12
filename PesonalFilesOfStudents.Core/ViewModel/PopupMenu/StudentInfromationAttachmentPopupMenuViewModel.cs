using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PesonalFilesOfStudents.Core;

namespace PesonalFilesOfStudents
{
    /// <summary>
    /// A view model for the <see cref="BubbleContent"/> control 
    /// </summary>
    public class StudentInformationAttachmentPopupMenuViewModel : BasePopupViewModel
    {

        #region Contructer

        /// <summary>
        /// Default constructer
        /// </summary>
        public StudentInformationAttachmentPopupMenuViewModel()
        {
            Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>(new[]
                {
                    new MenuItemViewModel {Text = "Actions with student...", Type = MenuItemType.Header},
                    new MenuItemViewModel { Text = "Edit",Icon = IconType.Edit},
                    new MenuItemViewModel { Text = "Delete",Icon = IconType.Delete},
                })
            };
        }

        #endregion
    }
}
