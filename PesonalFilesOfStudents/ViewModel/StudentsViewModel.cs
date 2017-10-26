using PesonalFilesOfStudents.AppData;
using PesonalFilesOfStudents.Model;
using PesonalFilesOfStudents.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PesonalFilesOfStudents.ViewModel
{
    public delegate ICollectionView ShowValuesFromDB();

    class StudentsViewModel : DependencyObject
    {
        private static bool isDone = false;

        public StudentsViewModel()
        {
            ShowValuesFromDB db = new ShowValuesFromDB(GetValuesFromDB);
            IAsyncResult res = db.BeginInvoke(new AsyncCallback(GetValuesDone), null);
            Items = db.EndInvoke(res);
            Items.Filter = FilterStudents;
        }

        private ICollectionView GetValuesFromDB()
        {
            return CollectionViewSource.GetDefaultView(StudentModel.Students.ToList());
        }

        private void GetValuesDone(IAsyncResult res)
        {
            isDone = true;
        }

        //Method for text filter
        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }

        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(StudentsViewModel), new PropertyMetadata("",FilterText_Changed));

        private static void FilterText_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as StudentsViewModel;
            if(current != null)
            {
                current.Items.Filter = null;
                current.Items.Filter = current.FilterStudents;
            }
        }

        private bool FilterStudents(object obj)
        {
            bool result = true;
            Student current = obj as Student;
            if (!string.IsNullOrWhiteSpace(FilterText) && current != null && !current.FirstName.Contains(FilterText) && !current.LastName.Contains(FilterText))
            {
                result = false;
            }

            return result;
        }

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }


        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(StudentsViewModel), new PropertyMetadata(null));

        
        //private static void Items_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var current = d as StudentsViewModel;
        //    if(current != null)
        //    {
        //        current.Items = CollectionViewSource.GetDefaultView(StudentModel.Students);
        //    }
        //}
    }
}
