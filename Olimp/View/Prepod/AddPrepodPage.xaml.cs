using Microsoft.Toolkit.Uwp.Notifications;
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

namespace Olimp.View.Prepod
{
    /// <summary>
    /// Логика взаимодействия для AddPrepodPage.xaml
    /// </summary>
    public partial class AddPrepodPage : Page
    {
        Core db = new Core();

        public AddPrepodPage()
        {
            InitializeComponent();
        }
        public bool check(string test)
        {
            bool result = String.IsNullOrEmpty(test);
            //testfor.Text = result.ToString();
            return !result;
       
        }
        private void AddTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            var existingUser = db.context.Users.FirstOrDefault(u => u.Username == LoginTextBox.Text);
            var existingTeacher = db.context.Teachers.FirstOrDefault(t => t.Email == EmailTextBox.Text);
            if (check(FullNameTextBox.Text) !=false&& check(BirthDatePicker.Text)!=false&&check(EmailTextBox.Text) !=false && check(LoginTextBox.Text)!=false&& check(PasswordBox.Password)!=false&& check(InstitutionTextBox.Text)!=false &&check(EducationLevelComboBox.Text)!=false&& check(CourseTextBox.Text) !=false&&check(SpecialtyTextBox.Text)!=false )
            {

                if (existingUser==null && existingTeacher==null)
                {
                    var newTeacher = new Teachers
                    {
                        FullName = FullNameTextBox.Text,
                        BirthDate = BirthDatePicker.SelectedDate ?? DateTime.MinValue,
                        Email = EmailTextBox.Text,
                        Login = LoginTextBox.Text,
                        Password = PasswordBox.Password,
                        Institution = InstitutionTextBox.Text,
                        EducationLevel = (EducationLevelComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                        Course = Convert.ToInt32(CourseTextBox.Text),
                        Specialty = SpecialtyTextBox.Text
                    };


                    db.context.Teachers.Add(newTeacher);
                    db.context.SaveChanges();
                    var newPolz = new Users
                    {
                        Username = LoginTextBox.Text,
                        Password = PasswordBox.Password,
                        UserType = "1"
                    };
                    db.context.Users.Add(newPolz);
                    db.context.SaveChanges();
                    testfor.Text = "Успешно";
                }
                else
                {
                    testfor.Text = "Логин и почта уже используются";

                }
            }
            else
            {
                testfor.Text = "Не все поля заполнены";
            }
        }




        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminPage());
        }
    }
}
