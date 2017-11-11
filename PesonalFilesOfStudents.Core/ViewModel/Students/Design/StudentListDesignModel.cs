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


                new StudentsListItemViewModel
                {
                    Name="Luke",
                    Initials = "LM",
                    Message = "this chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5"
                },
                new StudentsListItemViewModel
                {
                    Name="Jesse",
                    Initials = "JA",
                    Message = "Hey dude, here are new icons",
                    ProfilePictureRGB = "fe4503",
                    IsSelected = true
                },
                new StudentsListItemViewModel
                {
                    Name="Parnell",
                    Initials = "PL",
                    Message = "The new server is up, got 192.168.1.1",
                    ProfilePictureRGB = "00d405"
                },
                new StudentsListItemViewModel
                {
                    Name="Luke",
                    Initials = "LM",
                    Message = "this chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5"
                },
                new StudentsListItemViewModel
                {
                    Name="Jesse",
                    Initials = "JA",
                    Message = "Hey dude, here are new icons",
                    ProfilePictureRGB = "fe4503"
                },
                new StudentsListItemViewModel
                {
                    Name="Parnell",
                    Initials = "PL",
                    Message = "The new server is up, got 192.168.1.1",
                    ProfilePictureRGB = "00d405"
                },
                new StudentsListItemViewModel
                {
                    Name="Luke",
                    Initials = "LM",
                    Message = "this chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5"
                },
                new StudentsListItemViewModel
                {
                    Name="Jesse",
                    Initials = "JA",
                    Message = "Hey dude, here are new icons",
                    ProfilePictureRGB = "fe4503",
                },
                new StudentsListItemViewModel
                {
                    Name="Parnell",
                    Initials = "PL",
                    Message = "The new server is up, got 192.168.1.1",
                    ProfilePictureRGB = "00d405"
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
                    Name = stud.LastName + " " + stud.FirstName + " " + stud.MiddleName,
                    Message = "Group " + stud.Group.ToString(),
                    Initials = stud.LastName[0].ToString() + stud.FirstName[0].ToString(),
                    ProfilePictureRGB = Colors[rnd.Next(2)]

                });
            }

            return studs;
        }
    }
}
