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
    /// Логика взаимодействия для RegUserMainPageZV.xaml
    /// </summary>
    public partial class RegUserMainPageZV : Page
    {
        public RegUserMainPageZV()
        {
            InitializeComponent();
        }

        private void Profile(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.Reg_User.UserPageEdit());
        }

        private void Zapis(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.Reg_User.Zapis());
        }

        private void Blablabla(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.Reg_User.ResyltatiOlimpiadiGG());
        }
    }
}
