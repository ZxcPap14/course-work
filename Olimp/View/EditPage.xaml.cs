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
using Windows.Networking.Proximity;

namespace Olimp.View
{
    /// <summary>
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {

        Core db = new Core();
        string selectedName;
        bool isstudent;
        public EditPage()
        {
            InitializeComponent();
            LoadNames();       
                
        }
           
        private void LoadNames()
        {

            List<string> studentNames = db.context.Students.Select(s => s.Login).ToList();

            List<string> teacherNames = db.context.Teachers.Select(t => t.Login).ToList();

            List<string> allNames = studentNames.Concat(teacherNames).ToList();

            comboBoxNames.ItemsSource = allNames;
        }
        private void comboBoxNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (comboBoxNames.SelectedItem != null)
            {
                selectedName = comboBoxNames.SelectedItem.ToString();
                //MessageBox.Show($"Selected name: {selectedName}", "Selected Name", MessageBoxButton.OK);
            }
                
           

            if (txtFullName.Text!= null && dpBirthDate.Text!= null && Email.Text!=null && Username.Text!=null && Password.Password != null && Institution.Text != null && EducationLevel.Text != null && Course.Text != null && Specialty.Text != null)
            {
                if (!txtFullName.Text.Any(char.IsDigit))
                {
                    bool isNameExists = db.context.Students.Any(s => s.Login == selectedName);
                    if (isNameExists)
                    {

                        isstudent = true;
                        var student = db.context.Students.FirstOrDefault(s => s.Login == selectedName);
                        txtFullName.Text = student.FullName;
                        dpBirthDate.SelectedDate = student.BirthDate;
                        Email.Text = student.Email;
                        Username.Text = student.Login;
                        Password.Password = student.Password;
                        Institution.Text = student.Institution;
                        EducationLevel.Text = student.EducationLevel;
                        Course.Text = student.Course.ToString();
                        Specialty.Text = student.Specialty;
                    }

                    else
                    {
                        isstudent = false;
                        var prepod = db.context.Teachers.FirstOrDefault(s => s.Login == selectedName);
                        txtFullName.Text = prepod.FullName;
                        dpBirthDate.SelectedDate = prepod.BirthDate;
                        Email.Text = prepod.Email;
                        Username.Text = prepod.Login;
                        Password.Password = prepod.Password;
                        Institution.Text = prepod.Institution;
                        EducationLevel.Text = prepod.EducationLevel;
                        Course.Text = prepod.Course.ToString();
                        Specialty.Text = prepod.Specialty;
                    }
                }
                {
                    MessageBox.Show("Имя не должен содержать цифр");
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполненый");

            }
        }

        private void Specialty_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public bool check(string test)
        {
            bool result = String.IsNullOrEmpty(test);
            return !result;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(selectedName);
            if (check(txtFullName.Text) == true && check(dpBirthDate.Text)==true && check(Email.Text)==true && check(Username.Text)==true && check(Password.Password)==true && check(Institution.Text) ==true && check(EducationLevel.Text)==true && check(Course.Text)==true && check(Specialty.Text)==true)
            {
                if (isstudent == true)
                {
                    var existingStudent = db.context.Students.FirstOrDefault(u => u.Login == selectedName);
                    var existingStudentUser = db.context.Users.FirstOrDefault(u => u.Username == selectedName);
                    //Student
                    existingStudent.FullName = txtFullName.Text;
                    existingStudent.BirthDate = dpBirthDate.SelectedDate ?? DateTime.MinValue;
                    existingStudent.Email = Email.Text;
                    existingStudent.Login = Username.Text;
                    if (existingStudent.Password != Password.Password)
                    {
                        existingStudent.Password = UserVM.HashPassword(Password.Password);
                    }
                    existingStudent.Institution = Institution.Text;
                    existingStudent.EducationLevel = EducationLevel.Text;
                    existingStudent.Course = Convert.ToInt32(Course.Text);
                    existingStudent.Specialty = Specialty.Text;
                    // User
                    existingStudentUser.Username = Username.Text;
                    if (existingStudentUser.Password != Password.Password)
                    {
                        existingStudentUser.Password = UserVM.HashPassword(Password.Password);
                    }
                    db.context.SaveChanges();
                }
                else
                {
                    var existingTeacher = db.context.Teachers.FirstOrDefault(u => u.Login == selectedName);
                    var existingTeacherUser = db.context.Users.FirstOrDefault(u => u.Username == selectedName);
                    existingTeacher.FullName = txtFullName.Text;
                    existingTeacher.BirthDate = dpBirthDate.SelectedDate ?? DateTime.MinValue;
                    existingTeacher.Email = Email.Text;
                    existingTeacher.Login = Username.Text;
                    if (existingTeacher.Password != Password.Password)
                    {
                        existingTeacher.Password = UserVM.HashPassword(Password.Password);
                    }
                    existingTeacher.Institution = Institution.Text;
                    existingTeacher.EducationLevel = EducationLevel.Text;
                    existingTeacher.Course = Convert.ToInt32(Course.Text);
                    existingTeacher.Specialty = Specialty.Text;
                    // User
                    existingTeacherUser.Username = Username.Text;
                    if (existingTeacherUser.Password != Password.Password)
                    {
                        existingTeacherUser.Password = UserVM.HashPassword(Password.Password);
                    }
                    db.context.SaveChanges();
                }
                MessageBox.Show("Успех");
            }
            else
            {
                MessageBox.Show("Не все поля" +"заполнены");
            }
        }
    }
}
