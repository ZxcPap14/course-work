using GSF;
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
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                if (!name.Any(char.IsDigit))
                {
                    
                    if (UserVM.CheckAuth(name, password))
                    {
                        foreach (var user in db.context.Users.ToList().Where(x => x.Username == name && x.Password == UserVM.HashPassword(password)))
                        {
                            string login = usernameTextBox.Text;
                            string pass = passwordBox.Password;

                            Properties.Settings.Default.Save();
                            if (user.UserType == 0)
                            {
                                this.NavigationService.Navigate(new AdminPage());
                            }
                            if (user.UserType == 1)
                            {
                                this.NavigationService.Navigate(new View.Prepodovatiel.PrepodMainPage());
                            }
                            if (user.UserType == 2)
                            {
                                var zzxc = db.context.Students.Where(x => x.Login == login).FirstOrDefault();
                                Properties.Settings.Default.IDuserForZXC = (int)zzxc.StudentID;
                                this.NavigationService.Navigate(new View.Reg_User.RegUserMainPageZV());
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверные данные");
                    }
                }
                else
                {
                    MessageBox.Show("Логин не должен содержать цифры");
                }

            }


        }

        private void NonReg(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.NonRegUsers.NonRegUserMainPage());
        }
    }
}
