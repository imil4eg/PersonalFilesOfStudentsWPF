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
            System.Collections.Generic.List<Student> student = new List<Student>();

            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();

                SqlCommand command = new SqlCommand(String.Format("SELECT * FROM [dbo].[Students] students"));

                command.Connection = con;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    student.Add(new Student
                    {
                        StudentID = (int)reader["StudentID"],
                        FirstName = reader["FirstName"].ToString(),
                        MiddleName = reader["MiddleName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        //BirthDate = DateTime.Parse(reader["Birth_Date"].ToString()),
                        Course = (int)reader["Course"],
                        Faculty = (int)reader["Faculty"],
                        Gender = reader["Gender"].ToString(),
                        Group = (int)reader["Group"]
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

            return student;
        }

    }
}


