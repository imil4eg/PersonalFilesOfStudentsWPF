using PesonalFilesOfStudents.Core;

namespace PesonalFilesOfStudents
{
    /// <summary>
    /// A view model for any popup menus 
    /// </summary>
    public class BasePopupViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The background color of the bubble in ARGB value
        /// </summary>
        public string BubbleBackground { get; set; }

        /// <summary>
        /// The aligment of the bubble arrow
        /// </summary>
        public ElementHorizontalAligment ArrowAligment { get; set; }

        /// <summary>
        /// The content inside of this popup menu
        /// </summary>
        public BaseViewModel Content { get; set; }

        #endregion

        #region Contructer

        /// <summary>
        /// Default constructer
        /// </summary>
        public BasePopupViewModel()
        {
            BubbleBackground = "ffffff";
            ArrowAligment = ElementHorizontalAligment.Right;
        }

        #endregion
    }
}
