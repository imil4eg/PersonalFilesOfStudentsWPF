using System.Collections.Generic;
using System.Windows;
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

        /// <summary>
        /// The current students parents last name
        /// </summary>
        public TextEntryViewModel SecondParentLastName { get; set; }

        /// <summary>
        /// The current students parents first name
        /// </summary>
        public TextEntryViewModel SecondParentFirstName { get; set; }

        /// <summary>
        /// The current students parents middle name
        /// </summary>
        public TextEntryViewModel SecondParentMiddleName { get; set; }

        /// <summary>
        /// The current students parents phone number
        /// </summary>
        public TextEntryViewModel SecondParentPhone { get; set; }

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
        public TextEntryViewModel EducationFile1 { get; set; }

        /// <summary>
        /// The current students end date of education
        /// </summary>
        public TextEntryViewModel EducationEndDate1 { get; set; }

        /// <summary>
        /// The current students file on education
        /// </summary>
        public TextEntryViewModel EducationFile2 { get; set; }

        /// <summary>
        /// The current students end date of education
        /// </summary>
        public TextEntryViewModel EducationEndDate2 { get; set; }

        /// <summary>
        /// The current students file on education
        /// </summary>
        public TextEntryViewModel EducationFile3 { get; set; }

        /// <summary>
        /// The current students end date of education
        /// </summary>
        public TextEntryViewModel EducationEndDate3 { get; set; }

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

        /// <summary>
        /// The command to save the student
        /// </summary>
        public ICommand SaveCommand { get; set; }

        #endregion

        #region Private List
        /// <summary>
        /// The list to hold parents entry boxes , to take information from them after
        /// </summary>
        private List<TextEntryViewModel> _parents = new List<TextEntryViewModel>();

        /// <summary>
        /// The list to hold educations entry boxes , to take information from them after
        /// </summary>
        private List<TextEntryViewModel> _educations = new List<TextEntryViewModel>();

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
            SaveCommand = new RelayCommand(Save);

            // Student textboxes
            StudentFirstName = new TextEntryViewModel { Label = "First Name", OriginalText = " "};
            StudentMiddleName = new TextEntryViewModel { Label = "Middle Name", OriginalText = " "};
            StudentLastName = new TextEntryViewModel { Label = "Last Name", OriginalText = " "};
            StudentBirthDate = new TextEntryViewModel { Label = "Birth Date", OriginalText = " "};
            StudentRegistration = new TextEntryViewModel { Label = "Registration", OriginalText = " " };
            StudentCourse = new TextEntryViewModel { Label = "Course", OriginalText = " " };
            StudentGroup = new TextEntryViewModel { Label = "Group", OriginalText = " " };
            StudentFaculty = new TextEntryViewModel { Label = "Faculty", OriginalText = " " };
            StudentGender = new TextEntryViewModel { Label = "Gender", OriginalText = " " };
            StudentINN = new TextEntryViewModel {Label = "INN", OriginalText = " "};
            StudentSNILS = new TextEntryViewModel {Label = "SNILS", OriginalText = " "};
            StudentProfilePhoto = new TextEntryViewModel { Label = "Profile Photo", OriginalText = " " };

            // Passport textboxes
            PassportNumber = new TextEntryViewModel {Label = "Number", OriginalText = " "};
            PassportSeries = new TextEntryViewModel {Label = "Series", OriginalText = " "};
            PassportIssuedBy = new TextEntryViewModel {Label = "Issued By", OriginalText = " "};
            PassportIssuedDate = new TextEntryViewModel {Label = "Issued Date", OriginalText = " "};
            
            // Parent textboxes
            _parents.Add(ParentLastName = new TextEntryViewModel {Label = "Last Name", OriginalText = " "});
            _parents.Add(ParentFirstName = new TextEntryViewModel {Label = "First Name", OriginalText = " "});
            _parents.Add(ParentMiddleName = new TextEntryViewModel {Label = "Middle Name", OriginalText = " "});
            _parents.Add(ParentPhone = new TextEntryViewModel {Label = "Phone", OriginalText = " "});
            _parents.Add(SecondParentLastName = new TextEntryViewModel { Label = "Last Name", OriginalText = " " });
            _parents.Add(SecondParentFirstName = new TextEntryViewModel { Label = "First Name", OriginalText = " " });
            _parents.Add(SecondParentMiddleName = new TextEntryViewModel { Label = "Middle Name", OriginalText = " " });
            _parents.Add(SecondParentPhone = new TextEntryViewModel { Label = "Phone", OriginalText = " " });

            // Insurance Policy textboxes
            InsurencePolicyNumber = new TextEntryViewModel {Label = "Number", OriginalText = " "};
            InsurencePolicyCompany = new TextEntryViewModel {Label = "Company", OriginalText = " "};

            // Documents On Education textboxes
            _educations.Add(EducationFile1 = new TextEntryViewModel {Label = "File", OriginalText = " "});
            _educations.Add(EducationEndDate1 = new TextEntryViewModel {Label = "Date Of End", OriginalText = " "});
            _educations.Add(EducationFile2 = new TextEntryViewModel { Label = "File", OriginalText = " " });
            _educations.Add(EducationEndDate2 = new TextEntryViewModel { Label = "Date Of End", OriginalText = " " });
            _educations.Add(EducationFile3 = new TextEntryViewModel { Label = "File", OriginalText = " " });
            _educations.Add(EducationEndDate3 = new TextEntryViewModel { Label = "Date Of End", OriginalText = " " });

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
            IoC.Application.PictureControlVisible = false;
        }

        /// <summary>
        /// Open the add student menu
        /// </summary>
        public void Open()
        {
            // Open add student menu
            IoC.Application.SideMenuVisible = false;
            IoC.Application.AddStudentMenuVisible = true;
            IoC.Application.PictureControlVisible = true;
        }

        /// <summary>
        /// Save the student and close add student menu
        /// </summary>
        public void Save()
        {
            if (EntryBoxesValueCheck.Check(new List<TextEntryViewModel>
            {
                // Order is importnant
                StudentProfilePhoto,
                StudentFirstName,
                StudentMiddleName,
                StudentLastName,
                StudentBirthDate,
                StudentRegistration,
                StudentCourse,
                StudentGroup,
                StudentFaculty,
                StudentGender,
                StudentINN,
                StudentSNILS,
                StudentProfilePhoto,
                PassportNumber,
                PassportSeries,
                PassportIssuedBy,
                PassportIssuedDate,
                ParentLastName,
                ParentFirstName,
                ParentMiddleName,
                ParentPhone,
                SecondParentLastName,
                SecondParentFirstName,
                SecondParentMiddleName,
                SecondParentPhone,
                InsurencePolicyNumber,
                InsurencePolicyCompany,
                EducationFile1,
                EducationEndDate1,
                EducationFile2,
                EducationEndDate2,
                EducationFile3,
                EducationEndDate3
            }))
            {
                if (SqlDbConnect.CreateStudent(StudentLastName.OriginalText, StudentFirstName.OriginalText,
                    StudentGroup.OriginalText, StudentFaculty.OriginalText, StudentCourse.OriginalText,
                    StudentINN.OriginalText, StudentSNILS.OriginalText, PassportNumber.OriginalText,
                    PassportSeries.OriginalText, PassportIssuedBy.OriginalText, PassportIssuedDate.OriginalText,
                    InsurencePolicyNumber.OriginalText, InsurencePolicyCompany.OriginalText,_parents,_educations, StudentGender.OriginalText,
                    StudentRegistration.OriginalText, StudentBirthDate.OriginalText, StudentMiddleName.OriginalText))
                {
                    MessageBox.Show("The student successfully added to data base", "Congratulation");
                    IoC.Application.AddStudentMenuVisible = false;
                    IoC.Application.PictureControlVisible = false;
                    StudentListDesignModel.Instance.Items = SqlDbConnect.CreateStudentsListViewModel();
                    IoC.Application.SideMenuVisible = true;
                }
                //else
                //{
                //    MessageBox.Show("The student hand't added to data base", "Error");
                //}
            }
            else
            {
                MessageBox.Show("The student hand't added to data base", "Error");
            }
        }
    }
}
