using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

    }
}


