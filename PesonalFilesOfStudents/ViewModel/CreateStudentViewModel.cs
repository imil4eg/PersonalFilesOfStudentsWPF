using PesonalFilesOfStudents.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PesonalFilesOfStudents.ViewModel
{
    class CreateStudentViewModel : DependencyObject
    {
        private CommandHandler addStudentToDBCommand;
        public CommandHandler AddStudentToDBCommand
        {
            get
            {
                return addStudentToDBCommand ??
                    (addStudentToDBCommand = new CommandHandler(obj => AddStudentToDB()));
            }
        }

        public void AddStudentToDB()
        {
            int id = Model.StudentModel.Students.OrderByDescending(p => p.StudentID).FirstOrDefault().StudentID + 1;

            Model.StudentModel.CreateStudent(new Student
            {
                StudentID = id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Birth_Date = this.BirthDate,
                Course = this.Course,
                Faculty = this.Faculty,
                Registration = this.Registration,
                Gender = this.Gender,
                Group = this.Group,
                MiddleName = this.MiddleName,
                ReadingBookID = id,
                RecordBookID = id
            });
        }

        public string FirstName
        {
            get { return (string)GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FirstName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FirstNameProperty =
            DependencyProperty.Register("FirstName", typeof(string), typeof(CreateStudentViewModel), new PropertyMetadata(""));



        public string LastName
        {
            get { return (string)GetValue(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastNameProperty =
            DependencyProperty.Register("LastName", typeof(string), typeof(CreateStudentViewModel), new PropertyMetadata(""));



        public string MiddleName
        {
            get { return (string)GetValue(MiddleNameProperty); }
            set { SetValue(MiddleNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MiddleName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MiddleNameProperty =
            DependencyProperty.Register("MiddleName", typeof(string), typeof(CreateStudentViewModel), new PropertyMetadata(""));



        public int Course
        {
            get { return (int)GetValue(CourseProperty); }
            set { SetValue(CourseProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Course.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CourseProperty =
            DependencyProperty.Register("Course", typeof(int), typeof(CreateStudentViewModel), new PropertyMetadata(null));



        public string Faculty
        {
            get { return (string)GetValue(FacultyProperty); }
            set { SetValue(FacultyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Faculty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FacultyProperty =
            DependencyProperty.Register("Faculty", typeof(string), typeof(CreateStudentViewModel), new PropertyMetadata(""));



        public int Group
        {
            get { return (int)GetValue(GroupProperty); }
            set { SetValue(GroupProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Group.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GroupProperty =
            DependencyProperty.Register("Group", typeof(int), typeof(CreateStudentViewModel), new PropertyMetadata(null));



        public string Gender
        {
            get { return (string)GetValue(GenderProperty); }
            set { SetValue(GenderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Gender.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GenderProperty =
            DependencyProperty.Register("Gender", typeof(string), typeof(CreateStudentViewModel), new PropertyMetadata(""));



        public string Registration
        {
            get { return (string)GetValue(RegistrationProperty); }
            set { SetValue(RegistrationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Registration.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RegistrationProperty =
            DependencyProperty.Register("Registration", typeof(string), typeof(CreateStudentViewModel), new PropertyMetadata(""));



        public DateTime BirthDate
        {
            get { return (DateTime)GetValue(BirthDateProperty); }
            set { SetValue(BirthDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BirthDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BirthDateProperty =
            DependencyProperty.Register("BirthDate", typeof(DateTime), typeof(CreateStudentViewModel), new PropertyMetadata(null));



        public int RecordBookID
        {
            get { return (int)GetValue(RecordBookIDProperty); }
            set { SetValue(RecordBookIDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RecordBookID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RecordBookIDProperty =
            DependencyProperty.Register("RecordBookID", typeof(int), typeof(CreateStudentViewModel), new PropertyMetadata(null));



        public int ReadingBookID
        {
            get { return (int)GetValue(ReadingBookIDProperty); }
            set { SetValue(ReadingBookIDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ReadingBookID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReadingBookIDProperty =
            DependencyProperty.Register("ReadingBookID", typeof(int), typeof(CreateStudentViewModel), new PropertyMetadata(null));

        public class CommandHandler : ICommand
        {
            private Action<object> execute;
            private Func<object, bool> canExecute;

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public CommandHandler(Action<object> execute, Func<object, bool> canExecute = null)
            {
                this.execute = execute;
                this.canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return this.canExecute == null || this.canExecute(parameter);
            }

            public void Execute(object parameter)
            {
                this.execute(parameter);
            }
        }

    }
}
