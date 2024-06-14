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
    /// Логика взаимодействия для NonRegUserMainPage.xaml
    /// </summary>
    public partial class NonRegUserMainPage : Page
    {
        public NonRegUserMainPage()
        {
            InitializeComponent();
        }

        private void Olimpiada(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.NonRegUsers.AllOlimp());
        }
    }
}
