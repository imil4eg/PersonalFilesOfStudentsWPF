using System;

namespace PesonalFilesOfStudents.Core
{
    public class Student
    {
        public int StudentID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Registration { get; set; }

        public int Course { get; set; }

        public int Group { get; set; }

        public int Faculty { get; set; }

        public string Gender { get; set; }
    }
}
