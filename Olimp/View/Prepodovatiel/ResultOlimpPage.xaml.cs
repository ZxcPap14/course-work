using Olimp.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            int qqw = studentIdD.StudentID;
            string asd = Protocol_name.Text;
            int assdd = int.Parse(asd);
            string fff = score_tete.Text;
            int fffq = int.Parse(fff);

            string insertQuery = "INSERT INTO Results (protocol_id, student_id, score, result) VALUES (@protocol_id, @student_id, @score, @result)";

            using (var command = db.context.Database.Connection.CreateCommand())
            {
                command.CommandText = insertQuery;
                command.Parameters.Add(new SqlParameter("@protocol_id", assdd));
                command.Parameters.Add(new SqlParameter("@student_id", qqw));
                command.Parameters.Add(new SqlParameter("@score", fffq));
                command.Parameters.Add(new SqlParameter("@result", resultt.Text));

                db.context.Database.Connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    db.context.Database.Connection.Close();
                }
            }
        }
        //private void AddZ(object sender, RoutedEventArgs e)
        //{
        //    string first = AddDateBox.Text;
        //    string second = AddServiceBox.Text;
        //    string tretuy = AddStatusBox.Text;
        //    string chetvertyi = AddTimeBox.Text;

        //    string insertQuery = "INSERT INTO Orders (order_date, services, status, perform_time ) VALUES (@first, @second, @tretuy, @chetvertyi)";
        //    using (var command = db.context.Database.Connection.CreateCommand())
        //    {
        //        command.CommandText = insertQuery;
        //        command.Parameters.Add(new SqlParameter("@first", first));
        //        command.Parameters.Add(new SqlParameter("@second", second));
        //        command.Parameters.Add(new SqlParameter("@tretuy", tretuy));
        //        command.Parameters.Add(new SqlParameter("@chetvertyi", chetvertyi));
        //        db.context.Database.Connection.Open();
        //        try
        //        {
        //            command.ExecuteNonQuery();
        //            MessageBox.Show("Успех");
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //        finally
        //        {
        //            db.context.Database.Connection.Close();
        //        }


        //    }

        //}

        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void jopa(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.Prepodovatiel.EditResults());
        }
    }
}
