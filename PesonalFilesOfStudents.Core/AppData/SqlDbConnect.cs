using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// The class of commands to data base
    /// </summary>
    public static class SqlDbConnect
    {

        public static readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" + @"AttachDbFilename=C:\Users\zis\Documents\Visual Studio 2015\Projects\PesonalFilesOfStudents\PesonalFilesOfStudents\PersonalFilesOfStudentsDB.mdf;" + "Integrated Security = True;";

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
                                StudentID = (int) reader["StudentID"],
                                StudentFirstName = reader["FirstName"].ToString(),
                                StudentMiddleName = reader["MiddleName"].ToString(),
                                StudentLastName = reader["LastName"].ToString(),
                                StudentBirthDate = DateTime.Parse(reader["Birth Date"].ToString()),
                                StudentCourse = (int) reader["Course"],
                                StudentFaculty = (int) reader["Faculty"],
                                StudentGender = reader["Gender"].ToString(),
                                StudentGroup = (int) reader["Group"],
                                StudentRegistration = reader["Registration"].ToString(),
                                StudentINN = (long) reader["INN"],
                                StudentSNILS = (long) reader["SNILS"],
                                PassportNumber = (long) reader["PassportNumber"],
                                PassportSeries = (long) reader["PassportSeries"],
                                PassportIssuedBy = reader["PassportIssuedBy"].ToString(),
                                PassportIssuedDate = DateTime.Parse(reader["PassportIssuedDate"].ToString()),
                                InsuranceNumber = (long) reader["InsuranceNumber"],
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
                                Id = (int) reader["Id"],
                                StudentId = (int) reader["StudentID"],
                                ParentLastName = reader["LastName"].ToString(),
                                ParentFirstName = reader["FirstName"].ToString(),
                                ParentMiddleName = reader["MiddleName"].ToString(),
                                ParentPhone = (int) reader["Phone"]
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
                                StudentID = (int) reader["StudentID"],
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

        public static void CreateUpdateEducations(int id, List<TextEntryViewModel> educations)
        {
            // Contains the number of entered in entry box Educations
            int numberOfEnteredEducations = 0;

            // Current parent information id to start from in list
            int currentEducationsInfromationId = 0;

            // Takes the existing parents in DB with specific id
            Education[] existingEducations = TakeEducations().Where(x => x.StudentID == id).ToArray();

            // Check if the value in entry box have entered 
            // if true insrease numberOfEntereParents
            if (!string.IsNullOrWhiteSpace(educations[0].OriginalText))
                numberOfEnteredEducations++;

            if (!string.IsNullOrWhiteSpace(educations[2].OriginalText))
                numberOfEnteredEducations++;

            if (!string.IsNullOrWhiteSpace(educations[4].OriginalText))
                numberOfEnteredEducations++;


            // Cicle for updating all users that exists.
            // Firing while number of entered parents in textbox is not end or
            // while number existing parents in database is not end
            for (int i = existingEducations.Length; numberOfEnteredEducations != 0 && i != 0; currentEducationsInfromationId += 2, i--, numberOfEnteredEducations--)
            {
                UpdateEducation(id,educations, currentEducationsInfromationId);
            }

            // Create line in db for each parent , that isn't existit in db
            for (; numberOfEnteredEducations != 0 && !string.IsNullOrWhiteSpace(educations[currentEducationsInfromationId].OriginalText); currentEducationsInfromationId += 2, numberOfEnteredEducations--)
            {
                CreateEducation(id, educations, currentEducationsInfromationId);
            }
        }

        /// <summary>
        /// Updates the values in DocumentsOnEducation table
        /// </summary>
        /// <param name="id">The id of current education to updated</param>
        /// <param name="educations">The list of values</param>
        /// <param name="i">The score that indicated what values we need to use in update</param>
        /// <returns></returns>
        private static void UpdateEducation(int id, List<TextEntryViewModel> educations,int i)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    string query = string.Format("UPDATE [dbo].[DocumentsOnEducation] " +
                                                 "SET [File] = '{0}', DateOfEnd = '{1}' " +
                                                 "WHERE Id = {2}", educations[i].OriginalText, DateTime.Parse(educations[i + 1].OriginalText).ToString("yyyy/M/dd"), int.Parse(educations[i].OriginalText));

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
        private static void CreateEducation(int id, List<TextEntryViewModel> educations,int i)
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

        public static bool CreateStudent(string studentLastName,string studentFirstName,string studentGroup,string studentFaculty,
            string studentCourse,string inn,string studentSnils,string passportNumber,
            string passportSeries,string passportIssuedBy,string passportIssuedDate,string insuranceNumber,
            string insuranceCompany, List<TextEntryViewModel> parents,List<TextEntryViewModel> educations ,
            string studentGender = null,string studentRegistration = null,string studentBirthDate = null,string studentMiddleName = null)
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

            CreateUpdateParents(id,parents);
            CreateUpdateEducations(id,educations);

            return true;
        }

        public static bool UpdateInfromation(List<TextEntryViewModel> students,List<TextEntryViewModel> parents,List<TextEntryViewModel> educations)
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
                        long.Parse(students[12].OriginalText), long.Parse(students[13].OriginalText),
                        students[14].OriginalText, DateTime.Parse(students[15].OriginalText).ToString("yyyy/M/dd"),
                        long.Parse(students[16].OriginalText), students[17].OriginalText,
                        int.Parse(students[0].OriginalText));

                    using (SqlCommand command = new SqlCommand(query))
                    {
                        connection.Open();

                        command.Connection = connection;

                        command.ExecuteNonQuery();
                    }
                }

                CreateUpdateParents(int.Parse(students[0].OriginalText), parents);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        public static void CreateUpdateParents(int id, List<TextEntryViewModel> parents)
        { 
            // Contains the number of entered in entry box parents
            int numberOfEnteredParents = 0;

            // Current parent information id to start from in list
            int currentParentsInfoId = 0;

            // Takes the existing parents in DB with specific id
            Parent[] existingParents = TakeParents().Where(x => x.StudentId == id).ToArray();

            // Check if the value in entry box have entered 
            // if true insrease numberOfEntereParents
            if (!string.IsNullOrWhiteSpace(parents[0].OriginalText))
                numberOfEnteredParents++;

            if (!string.IsNullOrWhiteSpace(parents[4].OriginalText))
                numberOfEnteredParents++;


            // Cicle for updating all users that exists.
            // Firing while number of entered parents in textbox is not end or
            // while number existing parents in database is not end
            for (int i = existingParents.Length; numberOfEnteredParents != 0 && i != 0; currentParentsInfoId += 4,i--,numberOfEnteredParents--)
            {
                UpdateParent(parents, currentParentsInfoId);
            }

            // Create line in db for each parent , that isn't existit in db
            for (;numberOfEnteredParents != 0 && !string.IsNullOrWhiteSpace(parents[currentParentsInfoId].OriginalText) ; currentParentsInfoId += 4,numberOfEnteredParents--)
            {
                CreateParent(id,parents,currentParentsInfoId);
            }
        }

        private static void CreateParent(int id, List<TextEntryViewModel> parentsInfo,int currentInfoId)
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

        private static void UpdateParent(List<TextEntryViewModel> parentsInfo, int currentInfoId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = string.Format("UPDATE [dbo].[Parent] " +
                                                 "SET LastName = '{0}', FirstName = '{1}', MiddleName = '{2}', Phone = {3} " +
                                                 "WHERE Id = {4}", parentsInfo[currentInfoId].OriginalText,
                        parentsInfo[currentInfoId + 1].OriginalText, parentsInfo[currentInfoId + 2].OriginalText, long.Parse(parentsInfo[currentInfoId + 3].OriginalText), parentsInfo[currentInfoId].OriginalText);

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

        public static ObservableCollection<StudentsListItemViewModel> CreateStudentsListViewModel()
        {
            ObservableCollection<StudentsListItemViewModel> studs =
                new ObservableCollection<StudentsListItemViewModel>();

            foreach (var stud in SqlDbConnect.TakeStudents())
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

    }
}


