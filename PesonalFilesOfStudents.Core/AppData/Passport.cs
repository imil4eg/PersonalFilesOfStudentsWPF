using System;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// Class that holds passport information of student
    /// </summary>
    public partial class Student
    {
        /// <summary>
        /// The passports number
        /// </summary>
        public long PassportNumber { get; set; }

        /// <summary>
        /// The passports series
        /// </summary>
        public long PassportSeries { get; set; }

        /// <summary>
        /// The passports issued place
        /// </summary>
        public string PassportIssuedBy { get; set; }

        /// <summary>
        /// The passports issued date
        /// </summary>
        public DateTime PassportIssuedDate { get; set; }
    }
}
