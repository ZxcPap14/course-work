using Olimp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace Olimp.View.Prepodovatiel
{
    /// <summary>
    /// Логика взаимодействия для ResultOlimpPage.xaml
    /// </summary>
    public partial class ResultOlimpPage : Page
    {
        Core db = new Core();
        public ResultOlimpPage()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {

            List<int?> preparedOlympiadIds = db.context.Protocol
                .Where(p => p.Status == "Опубликован")
                .Select(p => p.OlympiadID)
                .ToList(); Protocol_name.ItemsSource = preparedOlympiadIds;
            List<Students> student = db.context.Students.ToList();
            Student_name.ItemsSource = student;
        }

        private void SaveNewResult(object sender, RoutedEventArgs e)
        {
            var studentIdD = db.context.Students.FirstOrDefault(u => u.FullName == Student_name.Text);
            var resultss = new Results 
            { 
                protocol_id = Convert.ToInt32(Protocol_name.Text),
                student_id = Convert.ToInt32(studentIdD.StudentID),
                score = Convert.ToInt32(score_tete.Text),
                result = resultt.Text,
            };
            MessageBox.Show(resultss.protocol_id.ToString() + "\n" +resultss.student_id + "\n" + resultss.score + "\n" + resultss.result);
            db.context.Results.Add(resultss);
            db.context.SaveChanges();
            MessageBox.Show("Успех");

        }
    }
}
