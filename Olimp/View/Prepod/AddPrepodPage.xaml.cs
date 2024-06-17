using Microsoft.Toolkit.Uwp.Notifications;
using Olimp.Model;
using Olimp.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Foundation.Diagnostics;

namespace Olimp.View.Prepod
{
    /// <summary>
    /// Логика взаимодействия для AddPrepodPage.xaml
    /// </summary>
    public partial class AddPrepodPage : Page
    {
        Core db = new Core();
        public string checkbox2;
        public AddPrepodPage()
        {
            InitializeComponent();

        }
        public bool check(string test)
        {
            bool result = String.IsNullOrEmpty(test);
            return !result;
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                // Дальнейшая логика обработки выбранной опции
                checkbox2 = radioButton.Content.ToString();
                MessageBox.Show($"Вы выбрали: {checkbox2}");
            }
        }
        private void AddTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            
            //var dbContext = new OLIMPEntities14();
            var existingUser = db.context.Users.FirstOrDefault(u => u.Username == LoginTextBox.Text);
            var existingTeacher = db.context.Teachers.FirstOrDefault(t => t.Email == EmailTextBox.Text);
            
                if (check(FullNameTextBox.Text) != false && check(BirthDatePicker.Text) != false && check(EmailTextBox.Text) != false && check(LoginTextBox.Text) != false && check(PasswordBox.Password) != false && check(InstitutionTextBox.Text) != false && check(EducationLevelComboBox.Text) != false && check(CourseTextBox.Text) != false && check(SpecialtyTextBox.Text) != false)
                {

                    if (existingUser == null && existingTeacher == null)
                    {
                        if (!FullNameTextBox.Text.Any(char.IsDigit))
                        {
                            var newPolz = new Users
                            {
                                Username = LoginTextBox.Text,
                                Password = UserVM.HashPassword(PasswordBox.Password),
                                UserType = 1
                            };
                            db.context.Users.Add(newPolz);
                            db.context.SaveChanges();
                            int userRole = db.context.Users
                            .Where(u => u.Username == LoginTextBox.Text)
                            .Select(u => u.UserType)
                            .FirstOrDefault();

                            var newTeacher = new Teachers
                            {
                                FullName = FullNameTextBox.Text,
                                BirthDate = BirthDatePicker.SelectedDate ?? DateTime.MinValue,
                                Email = EmailTextBox.Text,
                                Login = LoginTextBox.Text,
                                Password = UserVM.HashPassword(PasswordBox.Password),
                                Institution = InstitutionTextBox.Text,
                                EducationLevel = (EducationLevelComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                                Course = Convert.ToInt32(CourseTextBox.Text),
                                Specialty = SpecialtyTextBox.Text,
                                UserType = userRole,
                            };


                            db.context.Teachers.Add(newTeacher);
                            db.context.SaveChanges();


                            MessageBox.Show("Успешно");
                        }
                        else
                        {
                            MessageBox.Show("Имя не должен содержать цифр");
                            

                        }
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
            this.NavigationService.Navigate(new AdminPage());
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) // это чтоб принимал ток цифры . На вставку не рабоатет 
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true; 
            }

        }

        private void CourseTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
