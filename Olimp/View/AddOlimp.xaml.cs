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
    /// Логика взаимодействия для AddOlimp.xaml
    /// </summary>
    public partial class AddOlimp : Page
    {
        Core db = new Core();
        private readonly OLIMPEntities4 _context; 

        public AddOlimp()
        {
            InitializeComponent();
            _context = new OLIMPEntities4();
            LoadTeachers();
        }
        private void LoadTeachers()
        {
            List<Teachers> teachers = _context.Teachers.ToList();
            ResponsibleTeacherComboBox.ItemsSource = teachers;
        }

        private void AddOlympiadButton_Click(object sender, RoutedEventArgs e)
        {
            if (OlympiadNameTextBox.Text!=null&& (Teachers)ResponsibleTeacherComboBox.SelectedItem!=null&& StartDatePicker.SelectedDate!=null&& EndDatePicker.SelectedDate!=null)
            {
                string olympiadName = OlympiadNameTextBox.Text;
                Teachers selectedTeacher = (Teachers)ResponsibleTeacherComboBox.SelectedItem;
                DateTime startDate = StartDatePicker.SelectedDate ?? DateTime.MinValue;
                DateTime endDate = EndDatePicker.SelectedDate ?? DateTime.MinValue;
                var teacher = db.context.Teachers.FirstOrDefault(t => t.FullName == selectedTeacher.FullName);
                int teacherID = 0;

                teacherID = teacher.TeacherID;

                    

                    if (db.context.Olympiads.FirstOrDefault(z => z.Name == olympiadName) == null)
                    {
                            if (startDate < endDate)
                            {
                                var newOlimp = new Olympiads
                                {
                                    Name = olympiadName,
                                    OrganizerID = teacherID,
                                    StartDate = startDate,
                                    EndDate = endDate,
                                    Status = false
                                };
                                db.context.Olympiads.Add(newOlimp);
                                db.context.SaveChanges();
                                MessageBox.Show($"Название олимпиады: {olympiadName}\nОтветственный преподаватель: {selectedTeacher.FullName}\nДата начала олимпиады: {startDate}\nДата окончания олимпиады: {endDate}", "Информация о добавленной олимпиаде", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else
                            {
                                MessageBox.Show("Неверная длительность олимпиады");
                            }
                    }
                    else
                    {
                        MessageBox.Show("Олимпиада с таким названием уже существует");
                    }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
    }
}
