using Olimp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Olimp.View
{
    /// <summary>
    /// Логика взаимодействия для RedactPolz.xaml
    /// </summary>
    public partial class RedactPolz : Page
    {
        Core db = new Core();

        public RedactPolz()
        {
            InitializeComponent();
        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            var teachers = db.context.Teachers.ToList();
            var teacherViewModels = teachers.Select(t => new Teachers
            {
                FullName = t.FullName,
                BirthDate = t.BirthDate,
                Email = t.Email,
                Login = t.Login,
                Password = t.Password,
                Institution = t.Institution,
                EducationLevel = t.EducationLevel,
                Course = t.Course,
                Specialty = t.Specialty
            }).ToList();
            listviewUsers1.Items.Clear();
            foreach (var teacherViewModel in teacherViewModels)
            {
                var item = new ListViewItem();
                item.Content = teacherViewModel;
                listviewUsers1.Items.Add(item);
            }

        }
        private void Second_Click(object sender, RoutedEventArgs e)
        {
            var student = db.context.Students.ToList();
            var teacherViewModels = student.Select(t => new Teachers
            {
                FullName = t.FullName,
                BirthDate = t.BirthDate,
                Email = t.Email,
                Login = t.Login,
                Password = t.Password,
                Institution = t.Institution,
                EducationLevel = t.EducationLevel,
                Course = t.Course,
                Specialty = t.Specialty
            }).ToList();
            listviewUsers1.Items.Clear();
            foreach (var teacherViewModel in teacherViewModels)
            {
                var item = new ListViewItem();
                item.Content = teacherViewModel;
                listviewUsers1.Items.Add(item);
            }
        }

        private void listviewUsers1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
