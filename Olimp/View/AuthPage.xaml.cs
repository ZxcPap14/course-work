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

namespace Olimp.View
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        Core db = new Core();

        public AuthPage()
        {
            InitializeComponent();
            passwordBox.PasswordChar='*';
        }
        private bool IsValidCredentials(string username, string password)
        {

            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string name = usernameTextBox.Text;
            string password = passwordBox.Password;
            if (!IsValidCredentials(name, password))
            {
                Info.Text = "Не все поля заполнены";
            }
            else
            {
                Info.Text = null;
                if (UserVM.CheckAuth(name, password))
                {
                    foreach (var user in db.context.Users.ToList().Where(x => x.Username == name && x.Password == password))
                    {
                        if (user.UserType == "0")
                        {
                            this.NavigationService.Navigate(new AdminPage());
                        }
                        if (user.UserType == "1")
                        {
                            Info.Text = "1";
                        }
                    }



                }
                else
                {
                    Info.Text = "Неверные данные";
                }

            }


        }
    }
}
