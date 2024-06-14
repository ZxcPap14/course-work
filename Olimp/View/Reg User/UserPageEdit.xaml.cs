using DocumentFormat.OpenXml.Office2019.Excel.RichData2;
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

namespace Olimp.View.Reg_User
{
    /// <summary>
    /// Логика взаимодействия для UserPageEdit.xaml
    /// </summary>
    public partial class UserPageEdit : Page
    {
        Core db = new Core();
        int qwe = Properties.Settings.Default.IDuserForZXC;
        public UserPageEdit()
        {
            InitializeComponent();
            Update();
        }
        public void Update()
        {
            var test = db.context.Students.Where(x => x.StudentID == qwe).FirstOrDefault();
            FullNameTextBox.Text = test.FullName;
            BirthDatePicker.SelectedDate = test.BirthDate.Date;
            EmailTextBox.Text = test.Email;
            LoginTextBox.Text = test.Login;
            PasswordBox.Password = test.Password;
            InstitutionTextBox.Text = test.Institution;
            EducationLevelComboBox.Text = test.EducationLevel;
            CourseComboBox.Text = test.Course.ToString();
            SpecialtyTextBox.Text = test.Specialty;
        }

        private void jopagovno(object sender, RoutedEventArgs e)
        {

            var updStudent = db.context.Students.Where(u => u.StudentID == qwe).FirstOrDefault();
            updStudent.FullName = FullNameTextBox.Text;
            updStudent.BirthDate = BirthDatePicker.SelectedDate ?? DateTime.MinValue;
            updStudent.Email = EmailTextBox.Text;
            updStudent.Login = LoginTextBox.Text;
            updStudent.Password = PasswordBox.Password;
            updStudent.Institution = InstitutionTextBox.Text;
            updStudent.EducationLevel = (EducationLevelComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            updStudent.Course = int.Parse(CourseComboBox.Text);
            updStudent.Specialty = SpecialtyTextBox.Text;

            try
            {
                db.context.SaveChanges();

                MessageBox.Show("Успешно");

            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
