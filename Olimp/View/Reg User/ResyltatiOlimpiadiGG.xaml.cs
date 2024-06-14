using GSF.Collections;
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

namespace Olimp.View.Reg_User
{
    /// <summary>
    /// Логика взаимодействия для ResyltatiOlimpiadiGG.xaml
    /// </summary>
    public partial class ResyltatiOlimpiadiGG : Page
    {
        Core db = new Core();
        int qwe = Properties.Settings.Default.IDuserForZXC;
        public ResyltatiOlimpiadiGG()
        {
            InitializeComponent();
            //MessageBox.Show(qwe.ToString());
            Update();
        }

        private void KaiAngel(object sender, SelectionChangedEventArgs e)
        {

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
                score = db.context.Results.Where(l => l.student_id == qwe).FirstOrDefault().score,
                result = db.context.Results.Where(l => l.student_id == qwe).FirstOrDefault().result,
            }).Where(t => t.OlympiadID == db.context.Results.Where(u => u.student_id == qwe).FirstOrDefault().protocol_id).ToList();


            Olimp.ItemsSource = protocolViewModel;
        }

        private void Bck(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
