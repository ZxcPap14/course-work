
using Olimp.View;
using Olimp.View.Prepod;
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

namespace Olimp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //MainFrame.Navigate(new View.Prepodovatiel.PrepodMainPage());
            //MainFrame.Navigate(new View.Prepodovatiel.Certificate());
            //MainFrame.Navigate(new View.AdminPage());
            MainFrame.Navigate(new View.AuthPage());
            //MainFrame.Navigate(new View.Prepodovatiel.EditResults());
            //MainFrame.Navigate(new View.Reg_User.UserPageEdit());
            //MainFrame.Navigate(new View.NonRegUsers.NonRegUserMainPage());
            //MainFrame.Navigate(new View.Prepodovatiel.ReportPage());
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
