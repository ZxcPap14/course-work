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

namespace Olimp.View.NonRegUsers
{
    /// <summary>
    /// Логика взаимодействия для AllOlimp.xaml
    /// </summary>
    public partial class AllOlimp : Page
    {
        Core db = new Core();
        public AllOlimp()
        {
            InitializeComponent();
            Update();
        }
        private void Update()
        {
            var protocols = db.context.Olympiads.ToList();

            var protocolViewModel = protocols.Select(t => new
            {
                OlympiadID = t.OlympiadID,
                Name = t.Name,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
            }).Where(t => t.OlympiadID == db.context.Protocol.Where(u => u.Status == "Опубликован").FirstOrDefault().OlympiadID).ToList();


            Olimp.ItemsSource = protocolViewModel;
        }

        private void Bck(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
