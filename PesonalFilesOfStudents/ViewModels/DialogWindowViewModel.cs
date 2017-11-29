﻿using PesonalFilesOfStudents.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PesonalFilesOfStudents
{
    /// <summary>
    /// The View Model for the custom flat window
    /// </summary>
    public class DialogWindowViewModel : MainWindowViewModel
    {
        #region Public Properties

        /// <summary>
        /// The title of this dialog window
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The content to host inside the dialog
        /// </summary>
        public Control Content { get; set; }

        #endregion

        #region Constructer

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public DialogWindowViewModel(Window window) : base(window)
        {
            // Make minimum size smaller 
            WindowMinimumHeight = 100;
            WindowMinimumWidth = 250;

            // Make title bar smaller
            TitleHeight = 30;
        }

        #endregion
    }
}
