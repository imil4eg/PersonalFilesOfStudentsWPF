﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
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
        /// (Update all information about this student in all tables)
        /// </summary>
        public ICommand SaveChangesCommand { get; set; }

        /// <summary>
        /// The command for when the attachment button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        /// <summary>
        /// The command for when the area outside of any popup is clicked
        /// </summary>
        public ICommand PopupClickawayCommand { get; set; }

        /// <summary>
        /// The command for then the user need to delete information 
        /// (Delete all information about this student in all tables)
        /// </summary>
        public ICommand DeleteCommand { get; set; }

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
            SaveChangesCommand = new RelayCommand(Save);
            DeleteCommand = new RelayCommand(Delete);

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
                    StudentLastName,
                    StudentFirstName,
                    StudentMiddleName,
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

                // Shows message that update was success
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Congratulation!",
                    Message = "Student information was successfully updated!",
                    OkText = "OK"
                });

                // Gets all new items from data base
                StudentListDesignModel.Instance.Items = SqlDbConnect.CreateStudentsListViewModel();
            }
            else
            {
                // Shows message that update failed
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Error!",
                    Message = "Information didn't updated!",
                    OkText = "OK"
                });
            }
        }

        /// <summary>
        /// Delete Student from data base
        /// </summary>
        public void Delete()
        {
            // Check if delete is 
            if (SqlDbConnect.DeleteInformation(int.Parse(StudentID.OriginalText)))
            {
                // Shows message that update was success
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Congratulation!",
                    Message = "Student was successfully deleted!",
                    OkText = "OK"
                });

                // Gets all new items from data base
                StudentListDesignModel.Instance.Items = SqlDbConnect.CreateStudentsListViewModel();

                // Shows block screen 
                IoC.Application.BlockScreenVisible = true;
            }
        }

        #endregion

    }
}
