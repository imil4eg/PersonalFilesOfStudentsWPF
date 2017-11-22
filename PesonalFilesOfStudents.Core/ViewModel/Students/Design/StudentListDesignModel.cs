using System;
using System.Collections.Generic;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// The design-time data for a <see cref="StudentsListViewModel"/>
    /// </summary>
    public class StudentListDesignModel : StudentsListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static StudentListDesignModel Instance => new StudentListDesignModel();

        #endregion

        #region Helpers

        #endregion

        #region Contructor

        /// <summary>
        /// Default contructor
        /// </summary>
        public StudentListDesignModel()
        {
            Items = CreateStudentsListViewModel(); //new List<StudentsListItemViewModel>() // CreateStudentsListViewModel();
            //{
            //    // TODO : Remake this path fully

            //    new StudentsListItemViewModel
            //    {
            //        FirstName= "Luke",
            //        ProfilePicture = "LM",
            //        LastName = "this chat app is awesome! I bet it will be fast too",
            //        ProfilePictureRGB = "3099c5"
            //    },
            //    new StudentsListItemViewModel
            //    {
            //        FirstName= "Jesse",
            //        ProfilePicture = "JA",
            //        LastName = "Hey dude, here are new icons",
            //        ProfilePictureRGB = "fe4503",
            //        IsSelected = true
            //    },
            //    new StudentsListItemViewModel
            //    {
            //        FirstName= "Parnell",
            //        ProfilePicture = "PL",
            //        LastName = "The new server is up, got 192.168.1.1",
            //        ProfilePictureRGB = "00d405"
            //    },
            //    new StudentsListItemViewModel
            //    {
            //        FirstName= "Luke",
            //        ProfilePicture = "LM",
            //        LastName = "this chat app is awesome! I bet it will be fast too",
            //        ProfilePictureRGB = "3099c5"
            //    }
            //};
        }

        #endregion

        private List<StudentsListItemViewModel> CreateStudentsListViewModel()
        {
            List<StudentsListItemViewModel> studs = new List<StudentsListItemViewModel>();

            foreach (var stud in SqlDbConnect.TakeStudents())
            {
                studs.Add(new StudentsListItemViewModel
                {
                    StudentID = stud.StudentID,
                    StudentFirstName = stud.StudentFirstName,
                    StudentLastName = stud.StudentLastName,
                    StudentMiddleName = stud.StudentMiddleName,
                    StudentGroup = stud.StudentGroup,
                    StudentBirthDate = stud.StudentBirthDate,
                    StudentFaculty = stud.StudentFaculty,
                    StudentCourse = stud.StudentCourse,
                    StudentGender = stud.StudentGender,
                    StudentRegistration = stud.StudentRegistration,
                    StudentINN = stud.StudentINN,
                    StudentSNILS = stud.StudentSNILS,
                    PassportNumber = stud.PassportNumber,
                    PassportSeries = stud.PassportSeries,
                    PassportIssuedBy = stud.PassportIssuedBy,
                    PassportIssuedDate = stud.PassportIssuedDate,
                    ItemHeader = string.Format("{0} {1} {2}",stud.StudentLastName.Trim(),stud.StudentFirstName.Trim(),stud.StudentMiddleName.Trim()),
                    ItemInformation = string.Format("Id : {0}  Group : {1}",stud.StudentID,stud.StudentGroup)
                });
            }

            return studs;
        }
    }
}
