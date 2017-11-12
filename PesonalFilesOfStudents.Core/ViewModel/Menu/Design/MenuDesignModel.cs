using System.Collections.Generic;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// The design-time data for a <see cref="MenuViewModel"/>
    /// </summary>
    public class MenuDesignModel : MenuViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static MenuDesignModel Instance => new MenuDesignModel();

        #endregion

        #region Constructer

        /// <summary>
        /// Default constructor
        /// </summary>
        public MenuDesignModel()
        {
            Items = new List<MenuItemViewModel>(new[]
            {
                new MenuItemViewModel {Type = MenuItemType.Header, Text = "Design time header..."},
                new MenuItemViewModel { Text = "Menu item 1",Icon = IconType.Edit},
                new MenuItemViewModel { Text = "Menu item 2",Icon = IconType.Delete},
            });
        }

        #endregion
    }
}
