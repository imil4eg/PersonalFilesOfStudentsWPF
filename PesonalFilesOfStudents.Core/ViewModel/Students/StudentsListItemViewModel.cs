using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// A view model for each students list item in the overview students list
    /// </summary>
    public class StudentsListItemViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Consist of last name,first name,middle name of student for side menu item
        /// </summary>
        public string ItemHeader { get; set; }

        /// <summary>
        /// Consist of id and group of student for side menu item
        /// </summary>
        public string ItemInformation { get; set; }

        #region Student

        /// <summary>
        /// Students ID
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// Students first name
        /// </summary>
        public string StudentFirstName { get; set; }

        /// <summary>
        /// Students last name
        /// </summary>
        public string StudentLastName { get; set; }

        /// <summary>
        /// Students middle name
        /// </summary>
        public string StudentMiddleName { get; set; }

        /// <summary>
        /// Students birth date
        /// </summary>
        public DateTime StudentBirthDate { get; set; }

        /// <summary>
        /// Students living place
        /// </summary>
        public string StudentRegistration { get; set; }

        /// <summary>
        /// Students study course
        /// </summary>
        public int StudentCourse { get; set; }

        /// <summary>
        /// Students group
        /// </summary>
        public int StudentGroup { get; set; }

        /// <summary>
        /// Students faculty
        /// </summary>
        public int StudentFaculty { get; set; }

        /// <summary>
        /// Students gender
        /// </summary>
        public string StudentGender { get; set; }

        /// <summary>
        /// Students INN number
        /// </summary>
        public long StudentINN { get; set; }

        /// <summary>
        /// Students SNILS number
        /// </summary>
        public long StudentSNILS { get; set; }

        /// <summary>
        /// The attachment to the image
        /// </summary>
        public string StudentProfilePicture { get; set; }

        #endregion

        #region Passport

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

        #endregion

        #region Parent

        /// <summary>
        /// List to hold parents
        /// </summary>
        List<Parent> parents = new List<Parent>();

        /// <summary>
        /// The parents last name
        /// </summary>
        public string ParentLastName { get; set; }

        /// <summary>
        /// The parents first name
        /// </summary>
        public string ParentFirstName { get; set; }

        /// <summary>
        /// The parents middle name
        /// </summary>
        public string ParentMiddleName { get; set; }

        /// <summary>
        /// The parents phone number
        /// </summary>
        public long ParentPhone { get; set; }

        #endregion

        #region Education

        /// <summary>
        /// The list to hold educations of student
        /// </summary>
        List<Education> educations = new List<Education>();

        /// <summary>
        /// The file of education
        /// </summary>
        public string EducationFile { get; set; }

        /// <summary>
        /// The educations date of end
        /// </summary>
        public DateTime EducationDateOfEnd { get; set; }

        #endregion

        #region Insurance

        /// <summary>
        /// The number of insurance policy
        /// </summary>
        public long InsuranceNumber { get; set; }

        /// <summary>
        /// The insurance policy company name
        /// </summary>
        public string InsuranceCompany { get; set; }

        #endregion

        /// <summary>
        /// The RGB values (in hex) for the background color of the profile picture
        /// For example FF00FF for Red and Blue mixed
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        /// <summary>
        /// True if this item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Opens the current information thread
        /// </summary>
        public ICommand OpenInformationCommand { get; set; }

        #endregion

        #region Contructor

        /// <summary>
        /// Default contructor
        /// </summary>
        public StudentsListItemViewModel()
        {
            // Create commands
            OpenInformationCommand = new RelayCommand(OpenInformation);   
        }

        #endregion

        #region Command Methods

        public void OpenInformation()
        {
            IoC.Application.BlockScreenVisible = false;

            StudentsInformationViewModel.StudentInformation = new Student()
            {
                StudentID = StudentID,
                StudentFirstName = StudentFirstName,
                StudentLastName = StudentLastName,
                StudentMiddleName = StudentMiddleName,
                StudentGroup = StudentGroup,
                StudentRegistration = StudentRegistration,
                StudentBirthDate = StudentBirthDate,
                StudentFaculty = StudentFaculty,
                StudentCourse = StudentCourse,
                StudentGender = StudentGender,
                StudentINN = StudentINN,
                StudentSNILS = StudentSNILS,
                PassportNumber = PassportNumber,
                PassportSeries = PassportSeries,
                PassportIssuedBy = PassportIssuedBy,
                PassportIssuedDate = PassportIssuedDate,
                InsuranceNumber = InsuranceNumber,
                InsuranceCompany = InsuranceCompany
            };

            IoC.Application.GoToPage(ApplicationPage.Students, new StudentsInformationViewModel
            {
        });
        }

        #endregion
    }
}
