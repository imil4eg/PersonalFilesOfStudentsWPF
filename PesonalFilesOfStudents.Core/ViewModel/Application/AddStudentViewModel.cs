using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

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

        private List<TextEntryViewModel> _textEntrys = new List<TextEntryViewModel>();

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
            _textEntrys.Add(StudentFirstName = new TextEntryViewModel { Label = "First Name", OriginalText = " "});
            _textEntrys.Add(StudentMiddleName = new TextEntryViewModel { Label = "Middle Name", OriginalText = " "});
            _textEntrys.Add(StudentLastName = new TextEntryViewModel { Label = "Last Name", OriginalText = " "});
            StudentBirthDate = new TextEntryViewModel { Label = "Birth Date", OriginalText = " "};
            StudentRegistration = new TextEntryViewModel { Label = "Registration", OriginalText = " " };
            _textEntrys.Add(StudentCourse = new TextEntryViewModel { Label = "Course", OriginalText = " " });
            _textEntrys.Add(StudentGroup = new TextEntryViewModel { Label = "Group", OriginalText = " " });
            _textEntrys.Add(StudentFaculty = new TextEntryViewModel { Label = "Faculty", OriginalText = " " });
            _textEntrys.Add(StudentGender = new TextEntryViewModel { Label = "Gender", OriginalText = " " });
            _textEntrys.Add(StudentINN = new TextEntryViewModel {Label = "INN", OriginalText = " "});
            _textEntrys.Add(StudentSNILS = new TextEntryViewModel {Label = "SNILS", OriginalText = " "});
            StudentProfilePhoto = new TextEntryViewModel { Label = "Profile Photo", OriginalText = " " };

            // Passport textboxes
            _textEntrys.Add(PassportNumber = new TextEntryViewModel {Label = "Number", OriginalText = " "});
            _textEntrys.Add(PassportSeries = new TextEntryViewModel {Label = "Series", OriginalText = " "});
            _textEntrys.Add(PassportIssuedBy = new TextEntryViewModel {Label = "Issued By", OriginalText = " "});
            _textEntrys.Add(PassportIssuedDate = new TextEntryViewModel {Label = "Issued Date", OriginalText = " "});
            
            // Parent textboxes
            ParentLastName = new TextEntryViewModel {Label = "Last Name", OriginalText = " "};
            ParentFirstName = new TextEntryViewModel {Label = "First Name", OriginalText = " "};
            ParentMiddleName = new TextEntryViewModel {Label = "Middle Name", OriginalText = " "};
            ParentPhone = new TextEntryViewModel {Label = "Phone", OriginalText = " "};
            SecondParentLastName = new TextEntryViewModel { Label = "Last Name", OriginalText = " " };
            SecondParentFirstName = new TextEntryViewModel { Label = "First Name", OriginalText = " " };
            SecondParentMiddleName = new TextEntryViewModel { Label = "Middle Name", OriginalText = " " };
            SecondParentPhone = new TextEntryViewModel { Label = "Phone", OriginalText = " " };

            // Insurance Policy textboxes
            _textEntrys.Add(InsurencePolicyNumber = new TextEntryViewModel {Label = "Number", OriginalText = " "});
            _textEntrys.Add(InsurencePolicyCompany = new TextEntryViewModel {Label = "Company", OriginalText = " "});

            // Documents On Education textboxes
            _textEntrys.Add(EducationFile1 = new TextEntryViewModel {Label = "File", OriginalText = " "});
            _textEntrys.Add(EducationEndDate1 = new TextEntryViewModel {Label = "Date Of End", OriginalText = " "});
            EducationFile2 = new TextEntryViewModel { Label = "File", OriginalText = " " };
            EducationEndDate2 = new TextEntryViewModel { Label = "Date Of End", OriginalText = " " };
            EducationFile3 = new TextEntryViewModel { Label = "File", OriginalText = " " };
            EducationEndDate3 = new TextEntryViewModel { Label = "Date Of End", OriginalText = " " };

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

        /// <summary>
        /// Save the student and close add student menu
        /// </summary>
        public void Save()
        {
            //Check if this entry box has any value
            CheckIsValuesNull(StudentRegistration);
            CheckIsValuesNull(ParentFirstName,ParentLastName,ParentPhone);
            CheckIsValuesNull(SecondParentFirstName,SecondParentLastName,SecondParentPhone);
            CheckIsValuesNull(EducationFile2,EducationEndDate2);
            CheckIsValuesNull(EducationFile3, EducationEndDate3);

            foreach (var item in _textEntrys)
            {
                // Checks if some textbox is empty and show the message and end this method
                if (!string.IsNullOrWhiteSpace(item.OriginalText)) continue;
                MessageBox.Show(string.Format("The box {0} can't be empty", item.Label),"Error");
                return;

                
            }

            // Clear list
            _textEntrys.RemoveRange(0,_textEntrys.Count);

            // Paste all values that must be string into list
            _textEntrys.AddRange(new []
            {
                StudentFirstName,StudentLastName,StudentMiddleName,StudentGender,
                PassportIssuedBy
            });

            //Check if this entry box has any value
            CheckIsValuesNull(ParentFirstName, ParentLastName);
            CheckIsValuesNull(SecondParentFirstName, SecondParentLastName);

            // Each element of list...
            foreach (var item in _textEntrys)
            {
                // Check if this item is null
                if (!string.IsNullOrWhiteSpace(item.OriginalText))
                {
                    // Check every element on having a letter in it
                    foreach (var c in item.OriginalText)
                    {
                        // if it have a letter , Show messagebox with error and end method
                        if (char.IsNumber(c))
                        {
                            MessageBox.Show(string.Format("The enter box {0} must contain only letters", item.Label), "Error");
                            return;
                        }
                    }
                }
            }

            // Clear list
            _textEntrys.RemoveRange(0, _textEntrys.Count);

            _textEntrys.AddRange(new []
            {
                StudentCourse,StudentFaculty,StudentINN,StudentSNILS,
                PassportNumber,PassportSeries,InsurencePolicyNumber
            });

            int check = 0;

            // Each element of list...
            foreach (var item in _textEntrys)
            {
                // trying parse value to int , if true show message box with error and end this method
                if (!int.TryParse(item.OriginalText, out check))
                {
                    MessageBox.Show(string.Format("The enter box {0} must contain only nums", item.Label), "Error");
                    return;
                }
            }

            // Clear list
            _textEntrys.RemoveRange(0,_textEntrys.Count);

            //Check if this entry box has any value
            CheckIsValuesNull(StudentBirthDate);
            CheckIsValuesNull(EducationEndDate1);
            CheckIsValuesNull(EducationEndDate2);
            CheckIsValuesNull(EducationEndDate3);

            DateTime checkTime;

            // Each element of list...
            foreach (var item in _textEntrys)
            {
                // trying parse value to DateTime , if true show message box with error and end this method
                if (!DateTime.TryParse(item.OriginalText, out checkTime))
                {
                    MessageBox.Show(string.Format("The date in {0} must be like dd-mm-yyyy", item.Label), "Error");
                    return;
                }
            }


            // Trying to add student to data base , if true student added to db else show message box
            if (SqlDbConnect.AddInformationToDb(StudentLastName.OriginalText, StudentFirstName.OriginalText,
                StudentGroup.OriginalText, StudentFaculty.OriginalText, StudentCourse.OriginalText,
                StudentINN.OriginalText, StudentSNILS.OriginalText, PassportNumber.OriginalText,
                PassportSeries.OriginalText, PassportIssuedBy.OriginalText, PassportIssuedDate.OriginalText,
                InsurencePolicyNumber.OriginalText, InsurencePolicyCompany.OriginalText, StudentGender.OriginalText,
                StudentRegistration.OriginalText, StudentBirthDate.OriginalText, StudentMiddleName.OriginalText))
            {
                MessageBox.Show("The user successfully added to data base", "POZDROVLYU PACANI");
                IoC.Application.AddStudentMenuVisible = false;
            }
            else
                MessageBox.Show("The student hadn't add to data base.There is some errors", "Error");
        }

        /// <summary>
        /// This method check if someof entry boxes has value
        /// </summary>
        /// <param name="firstTextEntry"></param>
        /// <param name="secondTextEntry"></param>
        /// <param name="thirdTextEntry"></param>
        private void CheckIsValuesNull(params TextEntryViewModel[] textEntrys)
        {
            if (textEntrys.Length == 1 && !string.IsNullOrWhiteSpace(textEntrys[0].OriginalText))
            {
                _textEntrys.Add(textEntrys[0]);
            }
            if(textEntrys.Length == 2 &&
                (!string.IsNullOrWhiteSpace(textEntrys[0].OriginalText) || !string.IsNullOrWhiteSpace(textEntrys[1].OriginalText)))
            {
                _textEntrys.AddRange(new []{textEntrys[0],textEntrys[1]});
            }

            if (textEntrys.Length == 3 &&
                (!string.IsNullOrWhiteSpace(textEntrys[0].OriginalText) ||
                 !string.IsNullOrWhiteSpace(textEntrys[1].OriginalText) ||
                 !string.IsNullOrWhiteSpace(textEntrys[2].OriginalText)))
            {
                _textEntrys.AddRange(new [] {textEntrys[0],textEntrys[1],textEntrys[2]});
            }

            //if (!string.IsNullOrWhiteSpace(firstTextEntry.OriginalText) ||
            //    !string.IsNullOrWhiteSpace(secondTextEntry.OriginalText ?? " ") ||
            //    !string.IsNullOrWhiteSpace(thirdTextEntry.OriginalText ?? " "))
            //{
            //    // if has add into entry boxes into list
            //    _textEntrys.AddRange(new[] { firstTextEntry, secondTextEntry, thirdTextEntry });
            //}
        }
    }
}
