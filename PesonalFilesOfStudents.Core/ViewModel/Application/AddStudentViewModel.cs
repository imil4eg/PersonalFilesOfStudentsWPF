using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// The add student state as a view model
    /// </summary>
    public class AddStudentViewModel : BaseViewModel
    {
        #region Public Properties

        #region Student

        /// <summary>
        /// The current students name
        /// </summary>
        public TextEntryViewModel StudentFirstName { get; set; }

        /// <summary>
        /// The current students middle name
        /// </summary>
        public TextEntryViewModel StudentMiddleName { get; set; }

        /// <summary>
        /// The current students last name
        /// </summary>
        public TextEntryViewModel StudentLastName { get; set; }

        /// <summary>
        /// The current students birdth date
        /// </summary>
        public TextEntryViewModel StudentBirthDate { get; set; }

        /// <summary>
        /// The current students place of living
        /// </summary>
        public TextEntryViewModel StudentRegistration { get; set; }

        /// <summary>
        /// The current students course number
        /// </summary>
        public TextEntryViewModel StudentCourse { get; set; }

        /// <summary>
        /// The current students group number
        /// </summary>
        public TextEntryViewModel StudentGroup { get; set; }

        /// <summary>
        /// The current students faculty number
        /// </summary>
        public TextEntryViewModel StudentFaculty { get; set; }

        /// <summary>
        /// The current students gender
        /// </summary>
        public TextEntryViewModel StudentGender { get; set; }

        /// <summary>
        /// The current students INN number
        /// </summary>
        public TextEntryViewModel StudentINN { get; set; }

        /// <summary>
        /// The current students SNINLS number
        /// </summary>
        public TextEntryViewModel StudentSNILS { get; set; }

        /// <summary>
        /// The current students profile photo
        /// </summary>
        public TextEntryViewModel StudentProfilePhoto { get; set; }

        #endregion

        #region Passport

        /// <summary>
        /// The current students number of passport
        /// </summary>
        public TextEntryViewModel PassportNumber { get; set; }

        /// <summary>
        /// The current students series of passport
        /// </summary>
        public TextEntryViewModel PassportSeries { get; set; }

        /// <summary>
        /// The current students name of point of issue
        /// </summary>
        public TextEntryViewModel PassportIssuedBy { get; set; }

        /// <summary>
        /// Thre current students passports issue date
        /// </summary>
        public TextEntryViewModel PassportIssuedDate { get; set; }

        #endregion

        #region Parent

        /// <summary>
        /// The current students parents last name
        /// </summary>
        public TextEntryViewModel ParentLastName { get; set; }

        /// <summary>
        /// The current students parents first name
        /// </summary>
        public TextEntryViewModel ParentFirstName { get; set; }

        /// <summary>
        /// The current students parents middle name
        /// </summary>
        public TextEntryViewModel ParentMiddleName { get; set; }

        /// <summary>
        /// The current students parents phone number
        /// </summary>
        public TextEntryViewModel ParentPhone { get; set; }

        #endregion

        #region Insurance Policy

        /// <summary>
        /// The current students number of insurance policy
        /// </summary>
        public TextEntryViewModel InsurencePolicyNumber { get ; set; }

        /// <summary>
        /// The current students company of insurance policy
        /// </summary>
        public TextEntryViewModel InsurencePolicyCompany { get; set; }

        #endregion

        #region Document On Education 

        /// <summary>
        /// The current students file on education
        /// </summary>
        public TextEntryViewModel EducationFile { get; set; }

        /// <summary>
        /// The current students end date of education
        /// </summary>
        public TextEntryViewModel EducationEndDate { get; set; }

        #endregion

        #endregion

        #region Public Command

        /// <summary>
        /// The command to close the add student menu
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to open the add student menu
        /// </summary>
        public ICommand OpenCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AddStudentViewModel()
        {
            // Create commands
            CloseCommand = new RelayCommand(Close);
            OpenCommand = new RelayCommand(Open);

            // Student textboxes
            StudentFirstName = new TextEntryDesignModel { Label = "First Name", OriginalText = "" };
            StudentMiddleName = new TextEntryDesignModel { Label = "Middle Name", OriginalText = "" };
            StudentLastName = new TextEntryDesignModel { Label = "Last Name", OriginalText = "" };
            StudentBirthDate = new TextEntryDesignModel { Label = "Birth Date", OriginalText = "" };
            StudentRegistration = new TextEntryDesignModel { Label = "Registration", OriginalText = "" };
            StudentCourse = new TextEntryDesignModel { Label = "Course", OriginalText = "" };
            StudentGroup = new TextEntryDesignModel { Label = "Group", OriginalText = "" };
            StudentFaculty = new TextEntryDesignModel { Label = "Faculty", OriginalText = "" };
            StudentGender = new TextEntryDesignModel { Label = "Gender", OriginalText = "" };
            StudentINN = new TextEntryViewModel {Label = "INN", OriginalText = ""};
            StudentSNILS = new TextEntryViewModel {Label = "SNILS", OriginalText = ""};
            StudentProfilePhoto = new TextEntryDesignModel { Label = "Profile Photo", OriginalText = "" };

            // Passport textboxes
            PassportNumber = new TextEntryViewModel {Label = "Number", OriginalText = ""};
            PassportSeries = new TextEntryViewModel {Label = "Series", OriginalText = ""};
            PassportIssuedBy = new TextEntryViewModel {Label = "Issued By", OriginalText = ""};
            PassportIssuedDate = new TextEntryViewModel {Label = "Issued Date", OriginalText = ""};
            
            // Parent textboxes
            ParentLastName = new TextEntryViewModel {Label = "Last Name", OriginalText = ""};
            ParentFirstName = new TextEntryViewModel {Label = "First Name", OriginalText = ""};
            ParentMiddleName = new TextEntryViewModel {Label = "Middle Name", OriginalText = ""};
            ParentPhone = new TextEntryViewModel {Label = "Phone", OriginalText = ""};

            // Insurance Policy textboxes
            InsurencePolicyNumber = new TextEntryViewModel {Label = "Number", OriginalText = ""};
            InsurencePolicyCompany = new TextEntryViewModel {Label = "Company", OriginalText = ""};

            // Documents On Education textboxes
            EducationFile = new TextEntryViewModel {Label = "File", OriginalText = ""};
            EducationEndDate = new TextEntryViewModel {Label = "Date Of End", OriginalText = ""};

        }

        #endregion

        /// <summary>
        /// Close the add student menu
        /// </summary>
        public void Close()
        {
            // Close add student menu
            IoC.Application.AddStudentMenuVisible = false;
            IoC.Application.SideMenuVisible = true;
        }

        /// <summary>
        /// Open the add student menu
        /// </summary>
        public void Open()
        {
            // Open add student menu
            IoC.Application.SideMenuVisible = false;
            IoC.Application.AddStudentMenuVisible = true;
        }
    }
}
