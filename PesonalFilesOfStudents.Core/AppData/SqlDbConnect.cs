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
                        //StudentBirthDate = DateTime.Parse(reader["Birth_Date"].ToString()) ?? DateTime.MinValue,
                        StudentCourse = (int)reader["Course"],
                        StudentFaculty = (int)reader["Faculty"],
                        StudentGender = reader["Gender"].ToString(),
                        StudentGroup = (int)reader["Group"],
                        StudentRegistration = reader["Registration"].ToString(),
                        StudentINN = (long)reader["INN"],
                        StudentSNILS = (long)reader["SNILS"]
                    });
                }
                reader.Close();

                SqlCommand command2 = new SqlCommand("SELECT * FROM [dbo].[Passport]");

                command2.Connection = con;

                reader = command2.ExecuteReader();

                int i = 0;

                while (reader.Read())
                {
                    students[i].PassportNumber = (long)reader["Number"];
                    students[i].PassportSeries = (long) reader["Series"];
                    students[i].PassportIssuedBy = reader["IssuedBy"].ToString();
                    //students[i].PassportIssuedDate = reader["IssuedDate"].ToString();

                    i++;
                }

                reader.Close();

                SqlCommand command3 = new SqlCommand("SELECT * FROM [dbo].[Parent]");

                command3.Connection = con;

                reader = command3.ExecuteReader();

                i = 0;

                while (reader.Read())
                {
                    students[i].ParentFirstName = reader["FirstName"].ToString();
                    students[i].ParentLastName = reader["LastName"].ToString();
                    students[i].ParentMiddleName = reader["MiddleName"].ToString();
                    students[i].ParentPhone = (long)reader["Phone"];

                    i++;
                }

                reader.Close();

                SqlCommand command4 = new SqlCommand("SELECT * FROM [dbo].[InsurancePolicy]");

                command4.Connection = con;

                reader = command4.ExecuteReader();

                i = 0;

                while (reader.Read())
                {
                    students[i].InsuranceNumber = (long)reader["Number"];
                    students[i].InsuranceCompany = reader["Company"].ToString();
                }

                reader.Close();

                SqlCommand command5 = new SqlCommand("SELECT * FROM [dbo].[DocumentsOnEducation]");

                command5.Connection = con;

                reader = command5.ExecuteReader();

                i = 0;

                while (reader.Read())
                {
                    students[i].EducationFile = reader["File"].ToString();
                    //students[i].EducationDateOfEnd = DateTime.Parse(reader["DateOfEnd"].ToString());

                    i++;

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

    }
}


