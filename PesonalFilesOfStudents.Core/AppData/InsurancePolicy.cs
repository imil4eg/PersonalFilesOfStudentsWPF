namespace PesonalFilesOfStudents.Core
{
    public partial class Student
    {
        ///// <summary>
        ///// The students id,which insurance policy is
        ///// </summary>
        //public int StudentID { get; set; }

        /// <summary>
        /// The number of insurance policy
        /// </summary>
        public long InsuranceNumber { get; set; }

        /// <summary>
        /// The insurance policy company name
        /// </summary>
        public string InsuranceCompany { get; set; }
    }
}
