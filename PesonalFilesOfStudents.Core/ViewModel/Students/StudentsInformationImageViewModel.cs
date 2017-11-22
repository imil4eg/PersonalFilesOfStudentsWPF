using System.Windows.Media.Imaging;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace PesonalFilesOfStudents.Core
{
    public class StudentsInformationImageViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The thumbnail URL of this attachment
        /// </summary>
        private string mThumbnaiUrl;

        #endregion
        /// <summary>
        /// The thumbnail URL of this attachment
        /// </summary>
        public string ThumbnailUrl
        {
            get { return mThumbnaiUrl; }
            set
            {
                // If value hasn't changed, return
                if (value == mThumbnaiUrl)
                    return;

                // Update value
                mThumbnaiUrl = value;

                LocalFilePath = "pack://application:,,,/Images/index.png";
            }
        }

        /// <summary>
        /// The local file path on this machine to the downloaded thumnail
        /// </summary>
        public string LocalFilePath { get; set; }

    }
}
