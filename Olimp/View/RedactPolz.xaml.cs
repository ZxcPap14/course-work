using Olimp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using System.Xml.Linq;

namespace Olimp.View
{
    /// <summary>
    /// Логика взаимодействия для RedactPolz.xaml
    /// </summary>
    public partial class RedactPolz : Page
    {
        Core db = new Core();
        string login;
        public RedactPolz()
        {
            InitializeComponent();
            RefreshListView();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var existingUser = db.context.Users.FirstOrDefault(u => u.Username == login);
            //MessageBox.Show($"Выбран пользователь с логином: {existingUser}");
            if (existingUser != null)
            {

                db.context.Users.Remove(existingUser);

                if (existingUser.UserType == 1)
                {
                    var dadada = db.context.Teachers.FirstOrDefault(u => u.Login == login);
                    db.context.Teachers.Remove(dadada);
                }
                else
                {
                    var dadada = db.context.Students.FirstOrDefault(u => u.Login == login);
                    db.context.Students.Remove(dadada);
                }


                // Сохраняем изменения в базе данных
                db.context.SaveChanges();
                RefreshListView();
            }

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminPage());
        }


        private void listviewUsers1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listviewUsers1.SelectedItem != null)
            {
                ListViewItem selectedItem = (ListViewItem)listviewUsers1.SelectedItem;

                try
                {
                    Teachers selected = (Teachers)selectedItem.Content;
                    login = selected.Login;
                }
                catch {
                    Students selected = (Students)selectedItem.Content;
                    login = selected.Login;
                }

            }
        }


        private void RefreshListView()
        {
                
            listviewUsers1.Items.Clear();

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
                    Specialty = t.Specialty,
                    UserType = t.UserType
                }).ToList();
                foreach (var teacherViewModel in teacherViewModels)
                {
                    var item = new ListViewItem();
                    item.Content = teacherViewModel;
                    listviewUsers1.Items.Add(item);
                }
            
            
                var students = db.context.Students.ToList();
                var studentViewModels = students.Select(s => new Students
                {
                    FullName = s.FullName,
                    BirthDate = s.BirthDate,
                    Email = s.Email,
                    Login = s.Login,
                    Password = s.Password,
                    Institution = s.Institution,
                    EducationLevel = s.EducationLevel,
                    Course = s.Course,
                    Specialty = s.Specialty,
                    UserType =s.UserType,
                }).ToList();
                foreach (var studentViewModel in studentViewModels)
                {
                    var item = new ListViewItem();
                    item.Content = studentViewModel;
                    listviewUsers1.Items.Add(item);
                }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminPage());

        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EditPage());
        }
    }
}
