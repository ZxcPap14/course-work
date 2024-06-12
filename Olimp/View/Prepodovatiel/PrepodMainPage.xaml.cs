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
    /// Логика взаимодействия для PrepodMainPage.xaml
    /// </summary>
    public partial class PrepodMainPage : Page
    {
        public PrepodMainPage()
        {
            InitializeComponent();
        }

        private void addStudnetov(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.Prepodovatiel.AddNewStudent());
        }

        private void Result(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.Prepodovatiel.ResultOlimpPage());
        }
    }
}
