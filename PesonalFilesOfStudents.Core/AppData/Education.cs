using System;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// Class that holds information about education
    /// </summary>
    public class Education
    {
        /// <summary>
        /// The current education id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The students id , which file is
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// The file of education
        /// </summary>
        public string EducationFile { get; set; }

        /// <summary>
        /// The educations date of end
        /// </summary>
        public DateTime EducationDateOfEnd { get; set; }
    }
}
