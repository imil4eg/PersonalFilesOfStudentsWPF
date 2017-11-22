using System;

namespace PesonalFilesOfStudents.Core
{
    public partial class Student
    {
        /// <summary>
        /// The students ID
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// The name of student
        /// </summary>
        public string StudentFirstName { get; set; }

        /// <summary>
        /// The middle name of student
        /// </summary>
        public string StudentMiddleName { get; set; }

        /// <summary>
        /// The last name of student
        /// </summary>
        public string StudentLastName { get; set; }

        /// <summary>
        /// The students birth date
        /// </summary>
        public DateTime StudentBirthDate { get; set; }

        /// <summary>
        /// The students place of living
        /// </summary>
        public string StudentRegistration { get; set; }

        /// <summary>
        /// The students current course
        /// </summary>
        public int StudentCourse { get; set; }

        /// <summary>
        /// The students current group
        /// </summary>
        public int StudentGroup { get; set; }

        /// <summary>
        /// The students current faculty
        /// </summary>
        public int StudentFaculty { get; set; }

        /// <summary>
        /// The students gender
        /// </summary>
        public string StudentGender { get; set; }

        /// <summary>
        /// The students INN
        /// </summary>
        public long StudentINN { get; set; }

        /// <summary>
        /// The students SNILS
        /// </summary>
        public long StudentSNILS { get; set; }
    }
}
