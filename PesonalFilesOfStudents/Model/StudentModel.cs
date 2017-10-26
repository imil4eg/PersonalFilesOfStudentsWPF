using PesonalFilesOfStudents.AppData;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PesonalFilesOfStudents.Model
{
    public static class StudentModel 
    {
        //private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zis\documents\visual studio 2015\Projects\PesonalFilesOfStudents\PesonalFilesOfStudents\AppData\PersonalFilesOfStudentsDB.mdf;Integrated Security=True";

        private static PersonalFilesOfStudentsDBEntities Db;

        static StudentModel()
        {
            Db = new PersonalFilesOfStudentsDBEntities();
        }

        public static IQueryable<Student> Students
        {
            get
            {
                return Db.Students;
            }
        }

        public static bool CreateStudent(Student instance)
        {
            if (instance.StudentID == 0)
            {
                Db.Students.Add(instance);
                Db.SaveChanges();
                return true;
            }
            return false;
        }

        //public bool UpdateStudent(Student instance)
        //{
        //    Student cache = Db.Students.FirstOrDefault(p => p.StudentID == instance.StudentID);
        //    if (instance.StudentID == 0)
        //    {
        //        cache.FirstName = instance.FirstName;
        //        cache.MiddleName = instance.MiddleName;
        //        cache.LastName = instance.LastName;
        //        cache.Registration = instance.Registration;
        //        cache.Course = instance.Course;
        //        cache.Group = instance.Group;
        //        cache.Birth_Date = instance.Birth_Date;
        //        Db.Students.Context.SubmitChanges();
        //        return true;
        //    }

        //    return false;
        //}

        //public bool RemoveStudent(int studentsNumber)
        //{
        //    Student instance = Db.Students.FirstOrDefault(p => p.StudentID == studentsNumber);
        //    if (instance != null)
        //    {
        //        Db.Students.DeleteOnSubmit(instance);
        //        Db.Students.Context.SubmitChanges();
        //        return true;
        //    }

        //    return false;
        //}
    }
    }
