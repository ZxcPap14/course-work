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
using Windows.UI.Xaml.Controls;

namespace Olimp.View
{
    /// <summary>
    /// Логика взаимодействия для Protocol.xaml
    /// </summary>
    public partial class Protocol : System.Windows.Controls.Page
    {
        Core db = new Core();
        public Protocol()
        {
            InitializeComponent();
            Update();
        }
        private void Update()
        {
            
                var protocols = db.context.Protocol.ToList();

                var protocolViewModel = protocols.Select(t => new Model.Protocol
                {
                    ProtocolID = t.ProtocolID,
                    OlympiadID = t.OlympiadID,
                    Status = t.Status,
                }).ToList();

                ProtocolsDataGrid.ItemsSource = protocolViewModel;
            
        }
        private void PublishButton_Click(object sender, RoutedEventArgs e)
        {
            var zxc = db.context.Protocol.FirstOrDefault(u => u.ProtocolID == protocolID);
            if (zxc.Status== "Подготовлен")
            {
                
                zxc.Status = "Опубликован";
                db.context.SaveChanges();
                Update();
            }
            else
            {
                MessageBox.Show("Опубликовать можно только подготовленные протоколы");
            }
        }
        int protocolID;
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;
            if (btn != null)
            {
                // Получение номера протокола из атрибута Tag кнопки
                 protocolID = (int)btn.Tag;

                edit.Visibility = Visibility.Visible;
                var zxc = db.context.Protocol.FirstOrDefault(u => u.ProtocolID == protocolID);
                StatusProtocola.Text = zxc.Status;

            }
    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveEdit(object sender, RoutedEventArgs e)
        {
            edit.Visibility = Visibility.Hidden;
            var zxc = db.context.Protocol.FirstOrDefault(u => u.ProtocolID == protocolID);
            zxc.Status = StatusProtocola.Text;
            db.context.SaveChanges();
            Update();
        }

        private void listviewUsers1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ProtocolsDataGrid.SelectedItem != null)
            {
                // Получаем выбранный объект Protocol из SelectedItem
                Model.Protocol selectedProtocol = (Model.Protocol)ProtocolsDataGrid.SelectedItem;

                // Присваиваем поле protocolID значению ProtocolID выбранного объекта
                protocolID = selectedProtocol.ProtocolID;
            }
        }

        private void PublishBtton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
