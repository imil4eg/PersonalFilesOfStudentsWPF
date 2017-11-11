using System.Windows.Media.Imaging;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// A view model for each student information 
    /// </summary>
    public class StudentsInformationViewModel : BaseViewModel
    {
        /// <summary>
        /// Students ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Students first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Students last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Students middle name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Students birth date
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Students living place
        /// </summary>
        public string Registration { get; set; }

        /// <summary>
        /// Students study course
        /// </summary>
        public int Course { get; set; }

        /// <summary>
        /// Students group
        /// </summary>
        public int Group { get; set; }

        /// <summary>
        /// Students faculty
        /// </summary>
        public int Faculty { get; set; }

        /// <summary>
        /// Students gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// The attachment to the image
        /// </summary>
        public StudentsInformationImageViewModel ImageAttachment { get; set; }

    }
}
