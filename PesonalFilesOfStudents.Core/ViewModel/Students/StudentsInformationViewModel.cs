using System.Windows.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;
using System.Windows;

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
        /// The value to show 
        ///// </summary>
        //public bool FirstParentVisibility { get; set; } = true;

        //public bool SecondParentVisibility { get; set; } = true;

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

        #region Helpers

        private List<Parent> _parents = SqlDbConnect.TakeParents();
        private List<Education> _educations = SqlDbConnect.TakeEducations();
        private List<Parent> teParents = new List<Parent>();
        private List<Education> tempEducations = new List<Education>();
        private List<TextEntryViewModel> _textEntrys = new List<TextEntryViewModel>();

        #endregion

        #region Public Commands

        /// <summary>
        /// The command for then the user need to save values
        /// </summary>
        public ICommand SaveChangedCommand { get; set; }

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
            SaveChangedCommand = new RelayCommand(Save);

            // Make a default menu
            AttachmentMenu = new StudentInformationAttachmentPopupMenuViewModel();
            
            StudentInformation = StudentInformation ?? SqlDbConnect.TakeStudents().FirstOrDefault();

            teParents = _parents.Where(x => x.StudentId == StudentInformation.StudentID).ToList();
            tempEducations = _educations.Where(x => x.StudentID == StudentInformation.StudentID).ToList();

            // Student textboxes
            StudentID = new TextEntryViewModel { Label = "ID", OriginalText = StudentInformation.StudentID.ToString() };
            StudentFirstName = new TextEntryViewModel { Label = "First Name", OriginalText = StudentInformation.StudentFirstName };
            StudentMiddleName = new TextEntryViewModel { Label = "Middle Name", OriginalText = StudentInformation.StudentMiddleName };
            StudentLastName = new TextEntryViewModel { Label = "Last Name", OriginalText = StudentInformation.StudentLastName };
            StudentBirthDate = new TextEntryViewModel { Label = "Birth date", OriginalText = StudentInformation.StudentBirthDate.ToString("dd/M/yyyy") };
            StudentRegistration = new TextEntryViewModel { Label = "Registration", OriginalText = StudentInformation.StudentRegistration };
            StudentCourse = new TextEntryViewModel { Label = "Course", OriginalText = StudentInformation.StudentCourse.ToString() };
            StudentGroup = new TextEntryViewModel { Label = "Group", OriginalText = StudentInformation.StudentGroup.ToString() };
            StudentFaculty = new TextEntryViewModel { Label = "Faculty", OriginalText = StudentInformation.StudentFaculty.ToString() };
            StudentGender = new TextEntryViewModel { Label = "Gender", OriginalText = StudentInformation.StudentGender };
            StudentINN = new TextEntryViewModel { Label = "INN", OriginalText = StudentInformation.StudentINN.ToString() };
            StudentSNILS = new TextEntryViewModel { Label = "SNILS", OriginalText = StudentInformation.StudentSNILS.ToString() };
            StudentProfilePhoto = new TextEntryViewModel { Label = "Profile Photo", OriginalText = "lico.png" };

            //// Passport textboxes
            PassportNumber = new TextEntryViewModel { Label = "Number", OriginalText = StudentInformation.PassportNumber.ToString() };
            PassportSeries = new TextEntryViewModel { Label = "Series", OriginalText = StudentInformation.PassportSeries.ToString() };
            PassportIssuedBy = new TextEntryViewModel { Label = "Issued By", OriginalText = StudentInformation.PassportIssuedBy };
            PassportIssuedDate = new TextEntryViewModel { Label = "Issued Date", OriginalText = StudentInformation.PassportIssuedDate.ToString("dd/M/yyyy") };

            // Parent textboxes
            ParentLastName = new TextEntryViewModel {Label = "Last Name", OriginalText = teParents.Count > 0 ? teParents[0].ParentLastName : " "};
            ParentFirstName = new TextEntryViewModel {Label = "First Name", OriginalText = teParents.Count > 0 ? teParents[0].ParentFirstName : " "};
            ParentMiddleName = new TextEntryViewModel {Label = "Middle Name", OriginalText = teParents.Count > 0 ? teParents[0].ParentMiddleName : " "};
            ParentPhone = new TextEntryViewModel {Label = "Phone", OriginalText = teParents.Count > 0 ? teParents[0].ParentPhone.ToString() : " "};
            SecondParentLastName = new TextEntryViewModel {Label = "Last Name", OriginalText = teParents.Count > 1 ? teParents[1].ParentLastName : " "};
            SecondParentFirstName = new TextEntryViewModel {Label = "First Name", OriginalText = teParents.Count > 1 ? teParents[1].ParentFirstName : " "};
            SecondParentMiddleName = new TextEntryViewModel {Label = "Middle Name", OriginalText = teParents.Count > 1 ? teParents[1].ParentMiddleName : " "};
            SecondParentPhone = new TextEntryViewModel {Label = "Phone", OriginalText = teParents.Count > 1 ? teParents[1].ParentPhone.ToString() : " "};


            //// Insurance Policy textboxes
            InsurencePolicyNumber = new TextEntryViewModel { Label = "Number", OriginalText = StudentInformation.InsuranceNumber.ToString() };
            InsurencePolicyCompany = new TextEntryViewModel { Label = "Company", OriginalText = StudentInformation.InsuranceCompany };

            //// Documents On Education textboxes
            EducationFile1 = new TextEntryViewModel { Label = "File", OriginalText = tempEducations.Count > 0 ? tempEducations[0].EducationFile : " " };
            EducationEndDate1 = new TextEntryViewModel { Label = "Date Of End", OriginalText = tempEducations.Count > 0 ? tempEducations[0].EducationDateOfEnd.ToString("dd/M/yyyy") : " " };
            EducationFile2 = new TextEntryViewModel { Label = "File", OriginalText = tempEducations.Count > 1 ? tempEducations[1].EducationFile : " " };
            EducationEndDate2 = new TextEntryViewModel { Label = "Date Of End", OriginalText = tempEducations.Count > 1 ? tempEducations[1].EducationDateOfEnd.ToString("dd/M/yyyy") : " " };
            EducationFile3 = new TextEntryViewModel { Label = "File", OriginalText = tempEducations.Count > 2 ? tempEducations[2].EducationFile : " " };
            EducationEndDate3 = new TextEntryViewModel { Label = "Date Of End", OriginalText = tempEducations.Count > 2 ? tempEducations[2].EducationDateOfEnd.ToString("dd/M/yyyy") : " " };
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

        /// <summary>
        /// When the save button is clicked, saves corrected information
        /// </summary>
        public void Save()
        {
            // Order is important 
            if (EntryBoxesValueCheck.Check(new List<TextEntryViewModel>
            {
                StudentID,
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
                // Order is important
                SqlDbConnect.UpdateInfromation(new List<TextEntryViewModel>
                {
                    // Student table info
                    StudentID,
                    StudentFirstName,
                    StudentLastName,
                    StudentMiddleName,
                    StudentFaculty,
                    StudentCourse,
                    StudentBirthDate,
                    StudentGender,
                    StudentGroup,
                    StudentINN,
                    StudentSNILS,
                    StudentRegistration,
                    PassportNumber,
                    PassportSeries,
                    PassportIssuedBy,
                    PassportIssuedDate,
                    InsurencePolicyNumber,
                    InsurencePolicyCompany
                }, new List<TextEntryViewModel>
                {
                    // Parent table info
                    ParentLastName,
                    ParentFirstName,
                    ParentMiddleName,
                    ParentPhone,
                    SecondParentLastName,
                    SecondParentFirstName,
                    SecondParentMiddleName,
                    SecondParentPhone
                }, new List<TextEntryViewModel>
                {
                    // Education table info
                    EducationFile1,
                    EducationEndDate1,
                    EducationFile2,
                    EducationEndDate2,
                    EducationFile3,
                    EducationEndDate3
                });
            }
            else
            {
                MessageBox.Show("Information didn't updated", "Error");
            }

            //    //Check if this entry box has any value
            //    CheckIsValuesNull(StudentRegistration);

            //    CheckIsValuesNull(ParentFirstName, ParentLastName, ParentPhone);
            //    CheckIsValuesNull(SecondParentFirstName, SecondParentLastName, SecondParentPhone);
            //    CheckIsValuesNull(EducationFile2, EducationEndDate2);

            //    CheckIsValuesNull(EducationFile3, EducationEndDate3);

            //    foreach (var item in _textEntrys)
            //    {
            //        // Checks if some textbox is empty and show the message and end this method
            //        if (!string.IsNullOrWhiteSpace(item.OriginalText)) continue;
            //        MessageBox.Show(string.Format("The box {0} can't be empty", item.Label), "Error");
            //        return;


            //    }

            //    // Clear list
            //    _textEntrys.RemoveRange(0, _textEntrys.Count);

            //    // Paste all values that must be string into list
            //    _textEntrys.AddRange(new[]
            //    {
            //    StudentFirstName,StudentLastName,StudentMiddleName,StudentGender,
            //    PassportIssuedBy
            //});

            //    //Check if this entry box has any value
            //    CheckIsValuesNull(ParentFirstName, ParentLastName);

            //    CheckIsValuesNull(SecondParentFirstName, SecondParentLastName);

            //    // Each element of list...
            //    foreach (var item in _textEntrys)
            //    {
            //        // Check if this item is null
            //        if (!string.IsNullOrWhiteSpace(item.OriginalText))
            //        {
            //            // Check every element on having a letter in it
            //            foreach (var c in item.OriginalText)
            //            {
            //                // if it have a letter , Show messagebox with error and end method
            //                if (char.IsNumber(c))
            //                {
            //                    MessageBox.Show(string.Format("The enter box {0} must contain only letters", item.Label),
            //                        "Error");
            //                    return;
            //                }
            //            }
            //        }
            //    }

            //    // Clear list
            //    _textEntrys.RemoveRange(0, _textEntrys.Count);

            //    _textEntrys.AddRange(new[]
            //    {
            //    StudentCourse,StudentFaculty,StudentINN,StudentSNILS,
            //    PassportNumber,PassportSeries,InsurencePolicyNumber
            //});

            //    int check = 0;

            //    // Each element of list...
            //    foreach (var item in _textEntrys)
            //    {
            //        // trying parse value to int , if true show message box with error and end this method
            //        if (!int.TryParse(item.OriginalText, out check))
            //        {
            //            MessageBox.Show(string.Format("The enter box {0} must contain only nums", item.Label), "Error");
            //            return;
            //        }
            //    }

            //    // Clear list
            //    _textEntrys.RemoveRange(0, _textEntrys.Count);

            //    //Check if this entry box has any value
            //    CheckIsValuesNull(StudentBirthDate);

            //    CheckIsValuesNull(EducationEndDate1);
            //    CheckIsValuesNull(EducationEndDate2);
            //    CheckIsValuesNull(EducationEndDate3);

            //    DateTime checkTime;

            //    // Each element of list...
            //    foreach (var item in _textEntrys)
            //    {
            //        // trying parse value to DateTime , if true show message box with error and end this method
            //        if (!DateTime.TryParse(item.OriginalText, out checkTime))
            //        {
            //            MessageBox.Show(string.Format("The date in {0} must be like dd-mm-yyyy", item.Label), "Error");
            //            return;
            //        }
            //    }

            //    // Order is important
            //    SqlDbConnect.UpdateInfromation(new List<TextEntryViewModel>
            //    {
            //        StudentID,
            //        StudentFirstName,
            //        StudentLastName,
            //        StudentMiddleName,
            //        StudentFaculty,
            //        StudentCourse,
            //        StudentBirthDate,
            //        StudentGender,
            //        StudentGroup,
            //        StudentINN,
            //        StudentSNILS,
            //        StudentRegistration,
            //        PassportNumber,
            //        PassportSeries,
            //        PassportIssuedBy,
            //        PassportIssuedDate,
            //        InsurencePolicyNumber,
            //        InsurencePolicyCompany
            //    }, new List<TextEntryViewModel>
            //    {
            //        ParentLastName,
            //        ParentFirstName,
            //        ParentMiddleName,
            //        ParentPhone,
            //        SecondParentLastName,
            //        SecondParentFirstName,
            //        SecondParentMiddleName,
            //        SecondParentPhone
            //    }, new List<TextEntryViewModel>
            //    {
            //        EducationFile1,
            //        EducationEndDate1,
            //        EducationFile2,
            //        EducationEndDate2,
            //        EducationFile3,
            //        EducationEndDate3
            //    });
        }


        #endregion

        #region Methods

        ///// <summary>
        ///// This method check if someof entry boxes has value
        ///// </summary>
        ///// <param name="firstTextEntry"></param>
        ///// <param name="secondTextEntry"></param>
        ///// <param name="thirdTextEntry"></param>
        //private void CheckIsValuesNull(params TextEntryViewModel[] textEntrys)
        //{
        //    if (textEntrys.Length == 1 && !string.IsNullOrWhiteSpace(textEntrys[0].OriginalText))
        //    {
        //        _textEntrys.Add(textEntrys[0]);
        //    }
        //    if (textEntrys.Length == 2 &&
        //        (!string.IsNullOrWhiteSpace(textEntrys[0].OriginalText) || !string.IsNullOrWhiteSpace(textEntrys[1].OriginalText)))
        //    {
        //        _textEntrys.AddRange(new[] { textEntrys[0], textEntrys[1] });
        //    }

        //    if (textEntrys.Length == 3 &&
        //        (!string.IsNullOrWhiteSpace(textEntrys[0].OriginalText) ||
        //         !string.IsNullOrWhiteSpace(textEntrys[1].OriginalText) ||
        //         !string.IsNullOrWhiteSpace(textEntrys[2].OriginalText)))
        //    {
        //        _textEntrys.AddRange(new[] { textEntrys[0], textEntrys[1], textEntrys[2] });
        //    }

        //    //if (!string.IsNullOrWhiteSpace(firstTextEntry.OriginalText) ||
        //    //    !string.IsNullOrWhiteSpace(secondTextEntry.OriginalText ?? " ") ||
        //    //    !string.IsNullOrWhiteSpace(thirdTextEntry.OriginalText ?? " "))
        //    //{
        //    //    // if has add into entry boxes into list
        //    //    _textEntrys.AddRange(new[] { firstTextEntry, secondTextEntry, thirdTextEntry });
        //    //}
        //}

        #endregion
    }
}
