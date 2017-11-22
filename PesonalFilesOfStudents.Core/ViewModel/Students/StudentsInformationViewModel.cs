using System.Windows.Media.Imaging;
using System;
using System.Linq;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// A view model for each student information 
    /// </summary>
    public class StudentsInformationViewModel : BaseViewModel
    {
        #region  Public Properties

        #region Student

        public TextEntryViewModel StudentID { get; set; }

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

        public static Student StudentInformation { get; set; } 

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
        public TextEntryViewModel InsurencePolicyNumber { get; set; }

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

        /// <summary>
        /// The attachment to the image
        /// </summary>
        public string Image { get; set; } = "pack://application:,,,/Images/index.png";

        /// <summary>
        /// True to show the attachment menu, false to hide it
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }

        /// <summary>
        /// True if any popup menu are visible 
        /// </summary>
        public bool AnyPopupVisibile => AttachmentMenuVisible;

        /// <summary>
        /// The view model for the attachment menu
        /// </summary>
        public StudentInformationAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command for when the attachment button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        /// <summary>
        /// The command for when the area outside of any popup is clicked
        /// </summary>
        public ICommand PopupClickawayCommand { get; set; }

        #endregion

        #region Contructer

        /// <summary>
        /// Default contructer
        /// </summary>
        public StudentsInformationViewModel()
        {
            // Create commands
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickawayCommand = new RelayCommand(PopupClickaway);

            // Make a default menu
            AttachmentMenu = new StudentInformationAttachmentPopupMenuViewModel();
            
            StudentInformation = StudentInformation ?? SqlDbConnect.TakeStudents().FirstOrDefault();


            // Student textboxes
            StudentID = new TextEntryViewModel { Label = "ID", OriginalText = StudentInformation.StudentID.ToString() };
            StudentFirstName = new TextEntryDesignModel { Label = "First Name", OriginalText = StudentInformation.StudentFirstName };
            StudentMiddleName = new TextEntryDesignModel { Label = "Middle Name", OriginalText = StudentInformation.StudentMiddleName };
            StudentLastName = new TextEntryDesignModel { Label = "Last Name", OriginalText = StudentInformation.StudentLastName };
            StudentBirthDate = new TextEntryDesignModel { Label = "Birth date", OriginalText = StudentInformation.StudentBirthDate.ToString() };
            StudentRegistration = new TextEntryDesignModel { Label = "Registration", OriginalText = StudentInformation.StudentRegistration };
            StudentCourse = new TextEntryDesignModel { Label = "Course", OriginalText = StudentInformation.StudentCourse.ToString() };
            StudentGroup = new TextEntryDesignModel { Label = "Group", OriginalText = StudentInformation.StudentGroup.ToString() };
            StudentFaculty = new TextEntryDesignModel { Label = "Faculty", OriginalText = StudentInformation.StudentFaculty.ToString() };
            StudentGender = new TextEntryDesignModel { Label = "Gender", OriginalText = StudentInformation.StudentGender };
            StudentINN = new TextEntryViewModel { Label = "INN", OriginalText = StudentInformation.StudentINN.ToString() };
            StudentSNILS = new TextEntryViewModel { Label = "SNILS", OriginalText = StudentInformation.StudentSNILS.ToString() };
            StudentProfilePhoto = new TextEntryDesignModel { Label = "Profile Photo", OriginalText = "lico.png" };

            //// Passport textboxes
            PassportNumber = new TextEntryViewModel { Label = "Number", OriginalText = StudentInformation.PassportNumber.ToString() };
            PassportSeries = new TextEntryViewModel { Label = "Series", OriginalText = StudentInformation.PassportSeries.ToString() };
            PassportIssuedBy = new TextEntryViewModel { Label = "Issued By", OriginalText = StudentInformation.PassportIssuedBy };
            PassportIssuedDate = new TextEntryViewModel { Label = "Issued Date", OriginalText = StudentInformation.PassportIssuedDate };

            //// Parent textboxes
            //ParentLastName = new TextEntryViewModel { Label = "Last Name", OriginalText = "Pupkin" };
            //ParentFirstName = new TextEntryViewModel { Label = "First Name", OriginalText = "Petrovich" };
            //ParentMiddleName = new TextEntryViewModel { Label = "Middle Name", OriginalText = "Kek" };
            //ParentPhone = new TextEntryViewModel { Label = "Phone", OriginalText = "322-228-1488" };

            //// Insurance Policy textboxes
            //InsurencePolicyNumber = new TextEntryViewModel { Label = "Number", OriginalText = "23852395" };
            //InsurencePolicyCompany = new TextEntryViewModel { Label = "Company", OriginalText = "SuperSaveCompany" };

            //// Documents On Education textboxes
            //EducationFile = new TextEntryViewModel { Label = "File", OriginalText = "Putyaga n1" };
            //EducationEndDate = new TextEntryViewModel { Label = "Date Of End", OriginalText = "2001" };
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// When the attachment button is clicked, show/hide the attachment popup
        /// </summary>
        public void AttachmentButton()
        {
            // Toggle menu visibility
            AttachmentMenuVisible ^= true;
        }

        /// <summary>
        /// When the popup clickaway area is clicked, hide any popups
        /// </summary>
        public void PopupClickaway()
        {
            // Hide attachment menu 
            AttachmentMenuVisible ^= true;
        }


        #endregion

    }
}
