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

        private Random rnd = new Random();

        #endregion

        #region Massive

        private readonly string[] Colors = { "3099c5", "fe4503", "00d405" };
        
        #endregion

        #region Contructor

        /// <summary>
        /// Default contructor
        /// </summary>
        public StudentListDesignModel()
        {
            Items = new List<StudentsListItemViewModel>() // CreateStudentsListViewModel();
            {
                // TODO : Remake this path fully

                new StudentsListItemViewModel
                {
                    FirstName= "Luke",
                    ProfilePicture = "LM",
                    LastName = "this chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5"
                },
                new StudentsListItemViewModel
                {
                    FirstName= "Jesse",
                    ProfilePicture = "JA",
                    LastName = "Hey dude, here are new icons",
                    ProfilePictureRGB = "fe4503",
                    IsSelected = true
                },
                new StudentsListItemViewModel
                {
                    FirstName= "Parnell",
                    ProfilePicture = "PL",
                    LastName = "The new server is up, got 192.168.1.1",
                    ProfilePictureRGB = "00d405"
                },
                new StudentsListItemViewModel
                {
                    FirstName= "Luke",
                    ProfilePicture = "LM",
                    LastName = "this chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5"
                }
            };
        }

        #endregion

        private List<StudentsListItemViewModel> CreateStudentsListViewModel()
        {
            List<StudentsListItemViewModel> studs = new List<StudentsListItemViewModel>();

            foreach (var stud in SqlDbConnect.TakeStudents())
            {
                studs.Add(new StudentsListItemViewModel
                {
                    FirstName = stud.LastName + " " + stud.FirstName + " " + stud.MiddleName,
                    LastName = "Group " + stud.Group.ToString(),
                    ProfilePicture = stud.LastName[0].ToString() + stud.FirstName[0].ToString(),
                    ProfilePictureRGB = Colors[rnd.Next(2)]

                });
            }

            return studs;
        }
    }
}
