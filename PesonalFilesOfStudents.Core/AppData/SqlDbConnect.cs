using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using Microsoft.SqlServer.Server;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// The class of commands to data base
    /// </summary>
    public static class SqlDbConnect
    {
        #region Connection

        /// <summary>
        /// ConnectiongString to connect to the data base
        /// </summary>
        public static readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" + @"AttachDbFilename=C:\Users\zis\Documents\Visual Studio 2015\Projects\PesonalFilesOfStudents\PesonalFilesOfStudents\PersonalFilesOfStudentsDB.mdf;" + "Integrated Security = True;";

        #endregion

        #region Public Methods

        /// <summary>
        /// Method that takes all students from data base
        /// </summary>
        /// <returns><see cref="ObservableCollection{Student}"/></returns>
        public static ObservableCollection<Student> TakeStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = string.Format("SELECT * FROM [dbo].[Students] students");

                    using (SqlCommand command = new SqlCommand(query))
                    {
                        connection.Open();

                        command.Connection = connection;

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                StudentID = (int)reader["StudentID"],
                                StudentFirstName = reader["FirstName"].ToString(),
                                StudentMiddleName = reader["MiddleName"].ToString(),
                                StudentLastName = reader["LastName"].ToString(),
                                StudentBirthDate = DateTime.Parse(reader["Birth Date"].ToString()),
                                StudentCourse = (int)reader["Course"],
                                StudentFaculty = (int)reader["Faculty"],
                                StudentGender = reader["Gender"].ToString(),
                                StudentGroup = (int)reader["Group"],
                                StudentRegistration = reader["Registration"].ToString(),
                                StudentINN = (long)reader["INN"],
                                StudentSNILS = (long)reader["SNILS"],
                                PassportNumber = (long)reader["PassportNumber"],
                                PassportSeries = (long)reader["PassportSeries"],
                                PassportIssuedBy = reader["PassportIssuedBy"].ToString(),
                                PassportIssuedDate = DateTime.Parse(reader["PassportIssuedDate"].ToString()),
                                InsuranceNumber = (long)reader["InsuranceNumber"],
                                InsuranceCompany = reader["InsuranceCompany"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return students;
        }

        /// <summary>
        /// Method that takes all parents from data base
        /// </summary>
        /// <returns><see cref="ObservableCollection{Parent}"/></returns>
        public static List<Parent> TakeParents()
        {
            List<Parent> parents = new List<Parent>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = string.Format("SELECT * FROM [dbo].[Parent]");

                    using (SqlCommand command = new SqlCommand(query))
                    {
                        connection.Open();

                        command.Connection = connection;

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            parents.Add(new Parent
                            {
                                Id = (int)reader["Id"],
                                StudentId = (int)reader["StudentID"],
                                ParentLastName = reader["LastName"].ToString(),
                                ParentFirstName = reader["FirstName"].ToString(),
                                ParentMiddleName = reader["MiddleName"].ToString(),
                                ParentPhone = (int)reader["Phone"]
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return parents;
        }

        /// <summary>
        /// Method that takes all educations from data base
        /// </summary>
        /// <returns><see cref="ObservableCollection{Education}"/></returns>
        public static List<Education> TakeEducations()
        {
            List<Education> educations = new List<Education>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = string.Format("SELECT * FROM [dbo].[DocumentsOnEducation]");

                    using (SqlCommand command = new SqlCommand(query))
                    {
                        connection.Open();

                        command.Connection = connection;

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            educations.Add(new Education
                            {
                                Id = (int)reader["Id"],
                                StudentID = (int)reader["StudentID"],
                                EducationFile = reader["File"].ToString(),
                                EducationDateOfEnd = DateTime.Parse(reader["DateOfEnd"].ToString())
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return educations;
        }

        /// <summary>
        /// Method that creates student and all infrmation about them in db
        /// </summary>
        /// <returns><see cref="bool"/>that indicates if method was successfull</returns>
        public static bool CreateStudent(string studentLastName, string studentFirstName, string studentGroup, string studentFaculty,
            string studentCourse, string inn, string studentSnils, string passportNumber,
            string passportSeries, string passportIssuedBy, string passportIssuedDate, string insuranceNumber,
            string insuranceCompany, List<TextEntryViewModel> parents, List<TextEntryViewModel> educations,
            string studentGender = null, string studentRegistration = null, string studentBirthDate = null, string studentMiddleName = null)
        {
            studentBirthDate = !string.IsNullOrEmpty(studentBirthDate) ? studentBirthDate : DateTime.Now.ToString();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = string.Format(
                        "INSERT INTO [dbo].[Students] (LastName, FirstName, MiddleName, [Birth Date], Registration, Course, [Group], " +
                        "Faculty, Gender, INN, SNILS, PassportNumber, PassportSeries, PassportIssuedBy, PassportIssuedDate,InsuranceNumber, InsuranceCompany) " +
                        "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', {5}, {6}, {7}, '{8}', {9}, {10}, {11}, {12}, '{13}', '{14}', {15},'{16}')",
                        studentLastName, studentFirstName, studentMiddleName ?? " ",
                        DateTime.Parse(studentBirthDate).ToString("yyyy/M/dd"), studentRegistration,
                        int.Parse(studentCourse), int.Parse(studentGroup),
                        int.Parse(studentFaculty), studentGender, long.Parse(inn), long.Parse(studentSnils),
                        long.Parse(passportNumber), long.Parse(passportSeries), passportIssuedBy,
                        DateTime.Parse(passportIssuedDate).ToString("yyyy/M/dd"), long.Parse(insuranceNumber),
                        insuranceCompany);

                    using (SqlCommand command = new SqlCommand(query))
                    {
                        connection.Open();

                        command.Connection = connection;

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");

                return false;
            }

            int id = TakeStudents().OrderByDescending(x => x.StudentID).FirstOrDefault().StudentID;

            CreateUpdateParents(id, parents);
            CreateUpdateEducations(id, educations);

            return true;
        }

        /// <summary>
        /// Method that updates all infromation about student and his parents,educations
        /// </summary>
        /// <param name="students"></param>
        /// <param name="parents"></param>
        /// <param name="educations"></param>
        /// <returns><see cref="bool"/>that indicates if method was successfull</returns>
        public static bool UpdateInfromation(List<TextEntryViewModel> students, List<TextEntryViewModel> parents, List<TextEntryViewModel> educations)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = string.Format("UPDATE [dbo].[Students] " +
                                                 "SET LastName = '{0}', FirstName = '{1}', MiddleName = '{2}', [Birth Date] = '{3}', " +
                                                 "Registration = '{4}', Course = {5}, [Group] = {6}, Faculty = {7}, Gender = '{8}', " +
                                                 "INN = {9}, SNILS = {10}, PassportNumber = {11}, PassportSeries = {12}, " +
                                                 "PassportIssuedBy = '{13}', PassportIssuedDate = '{14}', " +
                                                 "InsuranceNumber = {15}, InsuranceCompany = '{16}' " +
                                                 "WHERE StudentID = {17}", students[1].OriginalText,
                        students[2].OriginalText, students[3].OriginalText,
                        DateTime.Parse(students[4].OriginalText).ToString("yyyy/M/dd"), students[5].OriginalText,
                        int.Parse(students[6].OriginalText), int.Parse(students[7].OriginalText),
                        int.Parse(students[8].OriginalText),
                        students[9].OriginalText, long.Parse(students[10].OriginalText),
                        long.Parse(students[11].OriginalText),
                        long.Parse(students[13].OriginalText), long.Parse(students[14].OriginalText),
                        students[15].OriginalText, DateTime.Parse(students[16].OriginalText).ToString("yyyy/M/dd"),
                        long.Parse(students[17].OriginalText), students[18].OriginalText,
                        int.Parse(students[0].OriginalText));

                    using (SqlCommand command = new SqlCommand(query))
                    {
                        connection.Open();

                        command.Connection = connection;

                        command.ExecuteNonQuery();
                    }
                }

                CreateUpdateParents(int.Parse(students[0].OriginalText), parents);
                CreateUpdateEducations(int.Parse(students[0].OriginalText), educations);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method that creates <see cref="StudentsListItemViewModel"/>
        /// </summary>
        /// <returns><see cref="ObservableCollection{StudentListItemViewModel}"/></returns>
        public static ObservableCollection<StudentsListItemViewModel> CreateStudentsListViewModel()
        {
            ObservableCollection<StudentsListItemViewModel> studs =
                new ObservableCollection<StudentsListItemViewModel>();

            foreach (var stud in TakeStudents())
            {
                studs.Add(new StudentsListItemViewModel
                {
                    StudentID = stud.StudentID,
                    StudentFirstName = stud.StudentFirstName.Trim(),
                    StudentLastName = stud.StudentLastName.Trim(),
                    StudentMiddleName = stud.StudentMiddleName.Trim(),
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
                    InsuranceNumber = stud.InsuranceNumber,
                    InsuranceCompany = stud.InsuranceCompany,
                    ItemHeader = string.Format("{0} {1} {2}", stud.StudentLastName.Trim(), stud.StudentFirstName.Trim(), stud.StudentMiddleName.Trim()),
                    ItemInformation = string.Format("Id : {0}  Group : {1}", stud.StudentID, stud.StudentGroup)
                });
            }

            return studs;
        }

        /// <summary>
        /// Delete all information about this student from all tables in data base
        /// </summary>
        /// <param name="studentId">Id of current student to delete</param>
        public static bool DeleteInformation(int studentId)
        {
            // Existing parents of this user in data base
            var existingParents = TakeParents().Where(x => x.StudentId == studentId).ToArray();

            // Existring educations in data base
            var existringEducations = TakeEducations().Where(x => x.StudentID == studentId).ToArray();

            // Deleting every parent of this user
            foreach (var item in existingParents)
            {
                DeleteParent(item.Id);
            }

            // Deleting every education of this user
            foreach (var item in existringEducations)
            {
                DeleteEducation(item.Id);
            }


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = string.Format("DELETE FROM [dbo].[Students] WHERE StudentID = {0}", studentId);

                    using (SqlCommand command = new SqlCommand(query))
                    {
                        connection.Open();

                        command.Connection = connection;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");

                return false;
            }

            return true;
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// The method that controls that <see cref="Education"/> is not exiist in db and creates them,
        /// and if <see cref="Education"/> is exists just updates them
        /// </summary>
        /// <param name="id">current students id</param>
        /// <param name="educations">All <see cref="TextEntryViewModel"/> that hold information about all <see cref="Education"/></param>
        private static void CreateUpdateEducations(int id, List<TextEntryViewModel> educations)
        {
            // Contains the number of entered in entry box Educations
            int numberOfEnteredEducations = 0;

            // Current parent information id to start from in list
            int currentEducationsInfromationId = 0;

            // Takes the existing parents in DB with specific id
            List<Education> existingEducations = TakeEducations().Where(x => x.StudentID == id).ToList();

            // Check if the value in entry box have entered and
            // his value is different from old value in db
            // if true insrease numberOfEntereParents
            for (int i = 0,j = 0; i < 3; i++,j += 2)
            {
                if (!string.IsNullOrWhiteSpace(educations[j].OriginalText) ||
                    (existingEducations.Count > i && existingEducations[i].EducationFile != educations[j].OriginalText))
                    numberOfEnteredEducations++;
            }


            // Cicle for updating all users that exists.
            // Firing while number of entered parents in textbox is not end or
            // while number existing parents in database is not end
            for (int i = existingEducations.Count, j = 0; numberOfEnteredEducations != 0 && i != 0; currentEducationsInfromationId += 2, i--, numberOfEnteredEducations--, j++)
            {
                UpdateEducation(existingEducations[j].Id, educations, currentEducationsInfromationId);
            }

            // Create line in db for each parent , that isn't existit in db
            for (; numberOfEnteredEducations != 0 && !string.IsNullOrWhiteSpace(educations[currentEducationsInfromationId].OriginalText); currentEducationsInfromationId += 2, numberOfEnteredEducations--)
            {
                CreateEducation(id, educations, currentEducationsInfromationId);
            }

            // Clear list of parents
            existingEducations.Clear();

            // Takes the existing parents in DB with specific id
            existingEducations = TakeEducations().Where(x => x.StudentID == id).ToList();

            // Fore each existing parent with specific id...
            for (int i = 0; i < existingEducations.Count; i++)
            {
                // Check if it's null after update
                // If true , delete line from data base
                if (string.IsNullOrWhiteSpace(existingEducations[i].EducationFile))
                    DeleteEducation(existingEducations[i].Id);
            }
        }

        /// <summary>
        /// The method that controls that parents is not exiist in db and creates them,
        /// and if parent is exists just updates them
        /// </summary>
        /// <param name="id">current student id</param>
        /// <param name="parents">All <see cref="TextEntryViewModel"/> that hold information about all <see cref="Parent"/></param>
        private static void CreateUpdateParents(int id, List<TextEntryViewModel> parents)
        {
            // Contains the number of entered in entry box parents
            int numberOfEnteredParents = 0;

            // Current parent information id to start from in list
            int currentParentsInfoId = 0;

            // Takes the existing parents in DB with specific id
            List<Parent> existingParents = TakeParents().Where(x => x.StudentId == id).ToList();

            // Check if the value in entry box have entered 
            // if true insrease numberOfEntereParents
            //if (!string.IsNullOrWhiteSpace(parents[0].OriginalText))
            //    numberOfEnteredParents++;

            //if (!string.IsNullOrWhiteSpace(parents[4].OriginalText))
            //    numberOfEnteredParents++;

            for (int i = 0, j = 0; i < 2; i++,j += 4)
            {
                if (!string.IsNullOrWhiteSpace(parents[j].OriginalText) ||
                    (existingParents.Count > i && existingParents[i].ParentLastName != parents[j].OriginalText))
                    numberOfEnteredParents++;
            }


            // Cicle for updating all users that exists.
            // Firing while number of entered parents in textbox is not end or
            // while number existing parents in database is not end
            for (int i = existingParents.Count, j = 0; numberOfEnteredParents != 0 && i != 0; currentParentsInfoId += 4, i--, numberOfEnteredParents--, j++)
            {
                UpdateParent(parents, currentParentsInfoId, existingParents[j].Id);
            }

            // Create line in db for each parent , that isn't existit in db
            for (; numberOfEnteredParents != 0 && !string.IsNullOrWhiteSpace(parents[currentParentsInfoId].OriginalText); currentParentsInfoId += 4, numberOfEnteredParents--)
            {
                CreateParent(id, parents, currentParentsInfoId);
            }

            // Clear list of parents
            existingParents.Clear();

            // Takes the existing parents in DB with specific id
            existingParents = TakeParents().Where(x => x.StudentId == id).ToList();

            // Fore each existing parent with specific id...
            for (int i = 0; i < existingParents.Count; i++)
            {
                // Check if it's null after update
                // If true , delete line from data base
                if (string.IsNullOrWhiteSpace(existingParents[i].ParentLastName))
                   DeleteParent(existingParents[i].Id);
            }

        }

        /// <summary>
        /// Method that creates parent in database
        /// </summary>
        /// <param name="id">Current students id</param>
        /// <param name="parentsInfo"><see cref="List{TextEntryViewModel}"/> that takes all <see cref="TextEntryViewModel"/> that hold infromation about parent</param>
        /// <param name="currentInfoId">The start index for parentsInfo to show from whic place method should start taking information about current parent</param>
        private static void CreateParent(int id, List<TextEntryViewModel> parentsInfo, int currentInfoId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = string.Format(
                        "INSERT INTO [dbo].[Parent] (StudentID,LastName, FirstName, MiddleName, Phone) " +
                        "VALUES ('{0}','{1}','{2}','{3}',{4})", id, parentsInfo[currentInfoId].OriginalText,
                        parentsInfo[currentInfoId + 1].OriginalText, parentsInfo[currentInfoId + 2].OriginalText, long.Parse(parentsInfo[currentInfoId + 3].OriginalText));

                    using (SqlCommand command = new SqlCommand(query))
                    {
                        connection.Open();

                        command.Connection = connection;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Method that updates parents information in database
        /// </summary>
        /// <param name="parentsInfo"><see cref="List{TextEntryViewModel}"/> that takes all <see cref="TextEntryViewModel"/> that hold infromation about parent</param>
        /// <param name="currentInfoId">The start index for parentsInfo to show from whic place method should start taking information about current parent</param>
        /// <param name="id">Current parents id</param>
        private static void UpdateParent(List<TextEntryViewModel> parentsInfo, int currentInfoId, int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = string.Format("UPDATE [dbo].[Parent] " +
                                                 "SET LastName = '{0}', FirstName = '{1}', MiddleName = '{2}', Phone = {3} " +
                                                 "WHERE Id = {4}", parentsInfo[currentInfoId].OriginalText,
                        parentsInfo[currentInfoId + 1].OriginalText, parentsInfo[currentInfoId + 2].OriginalText,
                        long.Parse(string.IsNullOrEmpty(parentsInfo[currentInfoId + 3].OriginalText)
                            ? "0"
                            : parentsInfo[currentInfoId + 3].OriginalText), id);

                    using (SqlCommand command = new SqlCommand(query))
                    {
                        connection.Open();

                        command.Connection = connection;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Updates the values in DocumentsOnEducation table
        /// </summary>
        /// <param name="id">The id of current education to updated</param>
        /// <param name="educations">The list of values</param>
        /// <param name="i">The score that indicated what values we need to use in update</param>
        /// <returns></returns>
        private static void UpdateEducation(int id, List<TextEntryViewModel> educations, int i)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = string.Format("UPDATE [dbo].[DocumentsOnEducation] " +
                                                 "SET [File] = '{0}', DateOfEnd = '{1}' " +
                                                 "WHERE Id = {2}", educations[i].OriginalText,
                        DateTime.Parse(educations[i + 1].OriginalText =
                            string.IsNullOrWhiteSpace(educations[i + 1].OriginalText)
                                ? DateTime.Today.ToString()
                                : educations[i + 1].OriginalText).ToString("yyyy/M/dd"), id);

                    using (SqlCommand command = new SqlCommand(query))
                    {
                        connection.Open();

                        command.Connection = connection;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Creates the values in DocumentsOnEducation table
        /// </summary>
        /// <param name="id">The id of current education to updated</param>
        /// <param name="educations">The list of values</param>
        /// <param name="i">The score that indicated what values we need to use in update</param>
        private static void CreateEducation(int id, List<TextEntryViewModel> educations, int i)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = string.Format(
                        "INSERT INTO [dbo].[DocumentsOnEducation] (StudentID, [File], DateOfEnd) " +
                        "VALUES ({0}, '{1}', '{2}')", id, educations[i].OriginalText,
                        DateTime.Parse(educations[i + 1].OriginalText).ToString("yyyy/M/dd"));

                    using (SqlCommand command = new SqlCommand(query))
                    {
                        connection.Open();

                        command.Connection = connection;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Delete education from data base
        /// </summary>
        /// <param name="id">Id of current <see cref="Education"/></param>
        private static void DeleteEducation(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = string.Format("DELETE FROM [dbo].[DocumentsOnEducation] WHERE Id = {0}", id);

                    using (SqlCommand command = new SqlCommand(query))
                    {
                        connection.Open();

                        command.Connection = connection;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Delete parent from data base
        /// </summary>
        /// <param name="id">Id of current <see cref="Parent"/></param>
        private static void DeleteParent(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = string.Format("DELETE FROM [dbo].[Parent] WHERE Id = {0}", id);

                    using (SqlCommand command = new SqlCommand(query))
                    {
                        connection.Open();

                        command.Connection = connection;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        #endregion

    }
}


