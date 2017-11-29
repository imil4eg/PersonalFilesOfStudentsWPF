﻿namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// Details for a message box dialog
    /// </summary>
    public class MessageBoxDialogDesignModel : MessageBoxDialogViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static MessageBoxDialogDesignModel Instance => new MessageBoxDialogDesignModel();

        #endregion

        #region Constructer

        /// <summary>
        /// Default constructer
        /// </summary>
        public MessageBoxDialogDesignModel()
        {
            OkText = "OK";
            Message = "Design time messages are fun";
        }

        #endregion
    }
}
