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

namespace Olimp.View.Reg_User
{
    /// <summary>
    /// Логика взаимодействия для Zapis.xaml
    /// </summary>
    public partial class Zapis : Page
    {
        int jopa;
        int qwe = Properties.Settings.Default.IDuserForZXC;

        Core db = new Core();
        public Zapis()
        {
            InitializeComponent();
            Update();
        }
        private void Update()
        {
            var protocols = db.context.Olympiads.ToList();

            var protocolViewModel = protocols.Select(t => new Model.Olympiads
            {
                OlympiadID = t.OlympiadID,
                Name = t.Name,
            }).Where(t => t.OlympiadID == db.context.Protocol.Where(u => u.Status == "Опубликован").FirstOrDefault().OlympiadID).ToList();

            Olimp.ItemsSource = protocolViewModel;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void OtozvatClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;
            if (btn != null)
            {
                // Получение номера протокола из атрибута Tag кнопки

                if (db.context.Results.Where(u=> u.protocol_id == jopa && u.student_id == qwe).Count() == 0 )
                {
                    var newEblan = new Model.Results
                    {
                        protocol_id = jopa,
                        student_id = qwe,
                    };
                    try
                    {
                        db.context.Results.Add(newEblan);
                        db.context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        MessageBox.Show("Вы записались на олимпиаду ");
                    }
                }
                else
                {
                    MessageBox.Show("Вы уже записаны");

                }
            }
        }

        private void KaiAngel(object sender, SelectionChangedEventArgs e)
        {
            if (Olimp.SelectedItem != null)
            {
                // Получаем выбранный объект Protocol из SelectedItem
                Model.Olympiads selectedProtocol = (Model.Olympiads)Olimp.SelectedItem;

                // Присваиваем поле protocolID значению ProtocolID выбранного объекта
                jopa = selectedProtocol.OlympiadID;
            }
        }
    }
}
