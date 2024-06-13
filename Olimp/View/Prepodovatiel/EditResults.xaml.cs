using Olimp.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Olimp.View.Prepodovatiel
{
    /// <summary>
    /// Логика взаимодействия для EditResults.xaml
    /// </summary>
    public partial class EditResults : Page
    {
        Core db = new Core();
        public EditResults()
        {
            InitializeComponent();
            Update();
        }
        int IDD;
        private void listviewUsrs1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ResultDataGrid.SelectedItem != null)
            {
                // Получаем выбранный объект Protocol из SelectedItem
                Model.Results selectedProtocol = (Model.Results)ResultDataGrid.SelectedItem;

                // Присваиваем поле protocolID значению ProtocolID выбранного объекта
                IDD = selectedProtocol.id;
            }
        }

        private void RedactClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;
            if (btn != null)
            {
                // Получение номера протокола из атрибута Tag кнопки
                IDD = (int)btn.Tag;

                edit.Visibility = Visibility.Visible;
                var zxc = db.context.Results.FirstOrDefault(u => u.id == IDD);
                Protocol_name.Text = zxc.protocol_id.ToString();
                Student_name.Text = zxc.student_id.ToString();
                score_tete.Text = zxc.score.ToString();
                resultt.Text = zxc.result.ToString();

            }
        }
        private void Update()
        {
            var zxc = db.context.Results.ToList();
            var qwe = zxc.Select(t => new Model.Results
            {
                id = t.id,
                protocol_id = t.protocol_id,
                student_id = t.student_id,
                score = t.score,
                result = t.result,

            }).ToList();
            ResultDataGrid.ItemsSource = qwe;
        }

        private void SaveNewResult(object sender, RoutedEventArgs e)
        {
            int qqw = IDD;
            int Protocoll = int.Parse(Protocol_name.Text);
            int scoraia = int.Parse(score_tete.Text);
            var newzxc = db.context.Results.FirstOrDefault(u => u.id == IDD);

            newzxc.student_id = qqw;
            newzxc.protocol_id= Protocoll;
            newzxc.score = scoraia;
            newzxc.result = resultt.Text;
            try
            {
                db.context.SaveChanges();
                MessageBox.Show("Успех");
                edit.Visibility = Visibility.Hidden;
                Update();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Backk(object sender, RoutedEventArgs e)
        {

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
