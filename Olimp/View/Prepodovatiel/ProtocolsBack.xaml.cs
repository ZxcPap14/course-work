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

namespace Olimp.View.Prepodovatiel
{
    /// <summary>
    /// Логика взаимодействия для ProtocolsBack.xaml
    /// </summary>
    public partial class ProtocolsBack : Page
    {
        Core db = new Core();
        public ProtocolsBack()
        {
            InitializeComponent();
            Update();
        }
        int protocolID;
        private void OtozvatClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;
            if (btn != null)
            {
                // Получение номера протокола из атрибута Tag кнопки
                protocolID = (int)btn.Tag;

                var UpdateProtocol = db.context.Protocol.FirstOrDefault(u => u.ProtocolID == protocolID);
                if(UpdateProtocol.Status == "Подготовлен")
                {
                    UpdateProtocol.Status = "Формируется";
                    Update();

                }
                else
                {
                    MessageBox.Show("Отозвать возможно только протоколы с статусом (Подготовлен)");
                }
            }
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

        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
