using Olimp.Model;
using Olimp.ViewModel;
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
using Windows.UI.Xaml.Controls;

namespace Olimp.View.Prepodovatiel
{
    /// <summary>
    /// Логика взаимодействия для AddNewStudent.xaml
    /// </summary>
    public partial class AddNewStudent : System.Windows.Controls.Page
    {
        Core db = new Core();
        public AddNewStudent()
        {
            InitializeComponent();
        }
        public bool check(string test)
        {
            bool result = String.IsNullOrEmpty(test);
            return !result;
        }
        private void AddTeacherButton_Click(object sender, RoutedEventArgs e)
        {

            //var dbContext = new OLIMPEntities14();
            var existingUser = db.context.Users.FirstOrDefault(u => u.Username == LoginTextBox.Text);
            var existingStudent = db.context.Students.FirstOrDefault(t => t.Email == EmailTextBox.Text);
            
                if (check(FullNameTextBox.Text) != false && check(BirthDatePicker.Text) != false && check(EmailTextBox.Text) != false && check(LoginTextBox.Text) != false && check(PasswordBox.Password) != false && check(InstitutionTextBox.Text) != false && check(EducationLevelComboBox.Text) != false && check(CourseComboBox.Text) != false && check(SpecialtyTextBox.Text) != false)
                {

                    if (existingUser == null && existingStudent == null)
                    {
                        var newPolz = new Users
                        {
                            Username = LoginTextBox.Text,
                            Password = UserVM.HashPassword(PasswordBox.Password),
                            UserType = 2
                        };
                        db.context.Users.Add(newPolz);
                        db.context.SaveChanges();
                        int userRole = db.context.Users
                        .Where(u => u.Username == LoginTextBox.Text)
                        .Select(u => u.UserType)
                        .FirstOrDefault();

                        var newStudent = new Students
                        {
                            FullName = FullNameTextBox.Text,
                            BirthDate = BirthDatePicker.SelectedDate ?? DateTime.MinValue,
                            Email = EmailTextBox.Text,
                            Login = LoginTextBox.Text,
                            Password = UserVM.HashPassword(PasswordBox.Password),
                            Institution = InstitutionTextBox.Text,
                            EducationLevel = (EducationLevelComboBox.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString(),
                            Course = Convert.ToInt32(CourseComboBox.Text),
                            Specialty = SpecialtyTextBox.Text,
                            UserType = 2,
                        };


                        db.context.Students.Add(newStudent);
                        db.context.SaveChanges();

                        MessageBox.Show("Успешно");
                    }
                    else
                    {
                        MessageBox.Show("Логин и почта уже используются");
                }
                }
                else
                {
                MessageBox.Show("Не все поля заполнены");
                }
            
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
