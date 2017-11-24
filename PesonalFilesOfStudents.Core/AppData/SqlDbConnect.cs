using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace PesonalFilesOfStudents.Core
{
    public static class SqlDbConnect
    {

        public static readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" + @"AttachDbFilename=C:\Users\zis\Documents\Visual Studio 2015\Projects\PesonalFilesOfStudents\PesonalFilesOfStudents\PersonalFilesOfStudentsDB.mdf;" + "Integrated Security = True;";

        public static List<Student> TakeStudents()
        {
            List<Student> students = new List<Student>();

            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();

                SqlCommand command = new SqlCommand(String.Format("SELECT * FROM [dbo].[Students] students"));

                command.Connection = con;

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return students;
        }

        public static List<Parent> TakeParents()
        {
            List<Parent> parents = new List<Parent>();

            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Parent]");

                command.Connection = con;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    parents.Add(new Parent
                    {
                        StudentId = (int) reader["StudentID"],
                        ParentLastName = reader["LastName"].ToString(),
                        ParentFirstName = reader["FirstName"].ToString(),
                        ParentMiddleName = reader["MiddleName"].ToString(),
                        ParentPhone = (int) reader["Phone"]
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return parents;
        }

        public static List<Education> TakeEducations()
        {
            List<Education> educations = new List<Education>();

            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[DocumentsOnEducation]");

                command.Connection = con;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    educations.Add(new Education
                    {
                        StudentID = (int) reader["StudentID"],
                        EducationFile = reader["File"].ToString(),
                        EducationDateOfEnd = DateTime.Parse(reader["DateOfEnd"].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return educations;
        }

        public static bool UpdateEducationControl(int id, List<TextEntryViewModel> educations)
        {
            // The score to indicate how many educations have , if the entry box is empty 
            // it means that student dont have education
            int i = 0;

            // The score to makr that values from list,that we need
            int j = 0;

            // Take the count of existing in data base 
            // to know , do we want to create new instance or just update old versions
            int EducationCount = TakeEducations().Select(x => x.StudentID == id).Count();

            if (!string.IsNullOrWhiteSpace(educations[0].OriginalText))
                i++;

            if (!string.IsNullOrWhiteSpace(educations[2].OriginalText))
                i++;

            if (!string.IsNullOrWhiteSpace(educations[4].OriginalText))
                i++;

            if (i == 0)
            {
                return true;
            }
            else if (i == 1 && EducationCount == 1)
            {
                UpdateEducation(id, educations, 0);
            }
            else if(i == 2 && EducationCount == 2)
            {
                UpdateEducation(id, educations, 0);
                UpdateEducation(id, educations, 2);
            }
            else if (i == 3 && EducationCount == 3)
            {
                UpdateEducation(id, educations, 0);
                UpdateEducation(id, educations, 2);
                UpdateEducation(id, educations, 4);
            }
            else if (i == 2 && EducationCount == 1)
            {
                UpdateEducation(id, educations, 0);
                CreateEducation(id, educations, 2);
            }
            else if (i == 3 && EducationCount == 1)
            {
                UpdateEducation(id, educations, 0);
                CreateEducation(id, educations, 2);
                CreateEducation(id, educations, 4);
            }
            else if (i == 3 && EducationCount == 2)
            {
                UpdateEducation(id, educations, 0);
                UpdateEducation(id, educations, 2);
                CreateEducation(id, educations, 4);
            }

            return true;

        }

        /// <summary>
        /// Updates the values in DocumentsOnEducation table
        /// </summary>
        /// <param name="id">The id of current education to updated</param>
        /// <param name="educations">The list of values</param>
        /// <param name="i">The score that indicated what values we need to use in update</param>
        /// <returns></returns>
        public static bool UpdateEducation(int id, List<TextEntryViewModel> educations,int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand("UPDATE [dbo].[DocumentsOnEducation] " +
                                                    "SET File = @File, DateOfEnd = @DateOfEnd " +
                                                    "WHERE StudentID = " + id);

                command.Parameters.AddWithValue("@File", educations[i].OriginalText);
                command.Parameters.AddWithValue("@DateOfEnd", SqlDbType.Date).Value =
                    DateTime.Parse(educations[i + 1].OriginalText).Date;

                command.Connection = connection;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
            finally
            {
                connection.Close();
            }

            return true;
        }

        /// <summary>
        /// Creates the values in DocumentsOnEducation table
        /// </summary>
        /// <param name="id">The id of current education to updated</param>
        /// <param name="educations">The list of values</param>
        /// <param name="i">The score that indicated what values we need to use in update</param>
        /// <returns></returns>
        public static bool CreateEducation(int id, List<TextEntryViewModel> educations,int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(string.Format(
                    "INSERT INTO [dbo].[DocumentsOnEducation] (StudentID, File, DateOfEnd" +
                    "VALUES @StudentID, @File, @DateOfEnd"));

                command.Parameters.AddWithValue("@StudentID", id);
                command.Parameters.AddWithValue("@File", educations[i].OriginalText);
                command.Parameters.AddWithValue("@DateOfEnd", SqlDbType.Date).Value =
                    DateTime.Parse(educations[i + 1].OriginalText).Date;

                command.Connection = connection;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
            finally
            {
                connection.Close();
            }

            return true;
        }

        public static bool AddInformationToDb(string studentLastName,string studentFirstName,string studentGroup,string studentFaculty,
            string studentCourse,string inn,string studentSnils,string passportNumber,
            string passportSeries,string passportIssuedBy,string passportIssuedDate,string insuranceNumber,string insuranceCompany,
            string studentGender = null,string studentRegistration = null,string studentBirthDate = null,string studentMiddleName = null)
        {
            studentBirthDate = !string.IsNullOrEmpty(studentBirthDate) ? studentBirthDate : DateTime.Now.ToString();

            MessageBox.Show(DateTime.Parse(studentBirthDate).ToString());

            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();

                SqlCommand command = new SqlCommand(string.Format(
                    "INSERT INTO [dbo].[Students] (LastName, FirstName, MiddleName, BirthDate, Registration, Course, Group,Faculty, Gender, INN, SNILS, PassportNumber, PassportSeries, PassportIssuedBy, PassportIssuedDate,InsuranceNumber, InsuranceCompany) " +
                    "VALUES (@LastName, @FirstName, @MiddleName, @Birth Date, @Registration, @Course, @Group, @Faculty, @Gender, @INN, @SNILS, @PassportNumber, @PassportSeries, @PassportIssuedBy, @PassportIssuedDate, @InsuranceNumber, @InsuranceCompany"));


                command.Parameters.AddWithValue("@LastName", studentLastName);
                command.Parameters.AddWithValue("@FirstName", studentFirstName);
                command.Parameters.AddWithValue("@MiddleName", studentMiddleName ?? " ");
                command.Parameters.AddWithValue("@Birth Date", SqlDbType.Date).Value = DateTime.Parse(studentBirthDate).Date;
                command.Parameters.AddWithValue("@Registration",!string.IsNullOrEmpty(studentRegistration) ? studentRegistration : " ");
                command.Parameters.AddWithValue("@Course",int.Parse(studentCourse));
                command.Parameters.AddWithValue("@Group",int.Parse(studentGroup.Trim()));
                command.Parameters.AddWithValue("@Faculty",int.Parse(studentFaculty));
                command.Parameters.AddWithValue("@Gender",!string.IsNullOrEmpty(studentGender) ? studentGender : " ");
                command.Parameters.AddWithValue("@INN",long.Parse(inn));
                command.Parameters.AddWithValue("@SNILS",long.Parse(studentSnils));
                command.Parameters.AddWithValue("@PassportNumber",long.Parse(passportNumber));
                command.Parameters.AddWithValue("@PassportSeries",long.Parse(passportSeries));
                command.Parameters.AddWithValue("@PassportIssuedBy",passportIssuedBy);
                command.Parameters.AddWithValue("@PassportIssuedDate",DateTime.Parse(passportIssuedDate));
                command.Parameters.AddWithValue("@InsuranceNumber",long.Parse(insuranceNumber));
                command.Parameters.AddWithValue("@InsuranceCompany",insuranceCompany);
                //studentLastName, studentFirstName, studentMiddleName ?? " ", DateTime.Parse(studentBirthDate),
                    //studentRegistration ?? " ",studentRegistration ?? " ",
                    //int.Parse(studentCourse), int.Parse(studentGroup), int.Parse(studentFaculty), studentGender ?? " ",
                    //int.Parse(inn),
                    //int.Parse(studentSnils), long.Parse(passportNumber), long.Parse(passportSeries), passportIssuedBy,
                    //DateTime.Parse(passportIssuedDate),
                    //long.Parse(insuranceNumber), insuranceCompany));

                command.Connection = con;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }

            return true;
        }

        public static bool UpdateInfromation(List<TextEntryViewModel> students,List<TextEntryViewModel> parents,List<TextEntryViewModel> educations)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();

                SqlCommand command = new SqlCommand("UPDATE [dbo].[Students] " +
                                                    "SET LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName, Birth Date = @BirthDate, " +
                                                    "Registration = @Registration, Course = @Course, Group = @Group, Faculty = @Faculty, Gender = @Gender, " +
                                                    "INN = @INN, SNILS = @SNILS, PassportNumber = @PassportNumber, PassportSeries = @PassportSeries, " +
                                                    "PassportIssuedBy = @PassportIssuedBy, PassportIssuedDate = @PassportIssuedDate, " +
                                                    "InsuranceNumber = @InsuranceNumber, InsuranceCompany = @InsuranceCompany " +
                                                    "WHERE StudentID = " + int.Parse(students[0].OriginalText));

                command.Parameters.AddWithValue("@LastName", students[1].OriginalText);
                command.Parameters.AddWithValue("@FirstName", students[2].OriginalText);
                command.Parameters.AddWithValue("@MiddleName", students[3].OriginalText);
                command.Parameters.AddWithValue("@BirthDate", SqlDbType.Date).Value =
                    DateTime.Parse(students[4].OriginalText).Date;
                command.Parameters.AddWithValue("@Registration", students[5].OriginalText);
                command.Parameters.AddWithValue("@Course", int.Parse(students[6].OriginalText));
                command.Parameters.AddWithValue("@Group", int.Parse(students[7].OriginalText));
                command.Parameters.AddWithValue("@Faculty", int.Parse(students[8].OriginalText));
                command.Parameters.AddWithValue("@Gender", students[9].OriginalText);
                command.Parameters.AddWithValue("@INN", long.Parse(students[10].OriginalText));
                command.Parameters.AddWithValue("@SNILS", long.Parse(students[11].OriginalText));
                command.Parameters.AddWithValue("@PassportNumber", long.Parse(students[12].OriginalText));
                command.Parameters.AddWithValue("@PassportSeries", long.Parse(students[13].OriginalText));
                command.Parameters.AddWithValue("@PassportIssuedBy", students[14].OriginalText);
                command.Parameters.AddWithValue("@PassportIssuedDate", SqlDbType.Date).Value =
                    DateTime.Parse(students[15].OriginalText).Date;
                command.Parameters.AddWithValue("@InsuranceNumber", long.Parse(students[16].OriginalText));
                command.Parameters.AddWithValue("@InsurancyCompany", students[17].OriginalText);

                command.Connection = con;

                command.ExecuteNonQuery();

                UpdateParents(int.Parse(students[0].OriginalText), parents);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        public static bool UpdateParents(int id, List<TextEntryViewModel> parents)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            int i = 0;
            int parentsCount = TakeParents().Select(x => x.StudentId == id).Count();

            if (!string.IsNullOrWhiteSpace(parents[0].OriginalText))
                i++;

            if (!string.IsNullOrWhiteSpace(parents[3].OriginalText))
                i++;

            if (i == 0 && parentsCount > i)
                return false;

            if (i == 1 && parentsCount == i)
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("UPDATE [dbo].[Parent] " +
                                                        "SET LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName, Phone = @Phone " +
                                                        "WHERE StudentID = " + id);

                    command.Parameters.AddWithValue("@LastName", parents[0].OriginalText);
                    command.Parameters.AddWithValue("@FirstName", parents[1].OriginalText);
                    command.Parameters.AddWithValue("@MiddleName", parents[2].OriginalText);
                    command.Parameters.AddWithValue("@Phone", long.Parse(parents[3].OriginalText));

                    command.Connection = connection;

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
            else if (i == 2 && parentsCount == 1)
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("UPDATE [dbo].[Parent] " +
                                                        "SET LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName, Phone = @Phone " +
                                                        "WHERE StudentID = " + id);

                    command.Parameters.AddWithValue("@LastName", parents[0].OriginalText);
                    command.Parameters.AddWithValue("@FirstName", parents[1].OriginalText);
                    command.Parameters.AddWithValue("@MiddleName", parents[2].OriginalText);
                    command.Parameters.AddWithValue("@Phone", long.Parse(parents[3].OriginalText));

                    command.Connection = connection;

                    command.ExecuteNonQuery();

                    CreateParent(id, new List<TextEntryViewModel> {parents[4], parents[5], parents[6], parents[7]});
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
            else if (i == 2 && parentsCount == 2)
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("UPDATE [dbo].[Parent] " +
                                                        "SET LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName, Phone = @Phone " +
                                                        "WHERE StudentID = " + id);

                    command.Parameters.AddWithValue("@LastName", parents[0].OriginalText);
                    command.Parameters.AddWithValue("@FirstName", parents[1].OriginalText);
                    command.Parameters.AddWithValue("@MiddleName", parents[2].OriginalText);
                    command.Parameters.AddWithValue("@Phone", long.Parse(parents[3].OriginalText));

                    command.Connection = connection;

                    command.ExecuteNonQuery();

                    command = new SqlCommand(string.Format("UPDATE [dbo].[Parent] " +
                                             "SET LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName, Phone = @Phone " +
                                             "WHERE StudentID = {0} AND LastName != {1}",id,parents[0].OriginalText));

                    command.Parameters.AddWithValue("@LastName", parents[0].OriginalText);
                    command.Parameters.AddWithValue("@FirstName", parents[1].OriginalText);
                    command.Parameters.AddWithValue("@MiddleName", parents[2].OriginalText);
                    command.Parameters.AddWithValue("@Phone", long.Parse(parents[3].OriginalText));

                    command.Connection = connection;

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
            else if (i == 2 && parentsCount == 0)
            {

                CreateParent(id, new List<TextEntryViewModel> {parents[0], parents[1], parents[2], parents[3]});
                CreateParent(id, new List<TextEntryViewModel> { parents[4], parents[5], parents[6], parents[7] });

            }

            connection.Close();
            return true;
        }

        public static bool CreateParent(int id,List<TextEntryViewModel> parent)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "INSERT INTO [dbo].[Parent] (StudentID, LastName, FirstName, MiddleName, Phone) " +
                    "VALUES (StudentID = @StudentID, LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName, Phone = @Phone");

                command.Parameters.AddWithValue("@StudentID", id);
                command.Parameters.AddWithValue("@LastName", parent[0].OriginalText);
                command.Parameters.AddWithValue("@FirstName", parent[1].OriginalText);
                command.Parameters.AddWithValue("@MiddleName", parent[2].OriginalText);
                command.Parameters.AddWithValue("@Phone", long.Parse(parent[3].OriginalText));

                command.Connection = connection;

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "error");
                return false;
            }
            finally
            {
                connection.Close();
            }

            return true;
        }

    }
}


