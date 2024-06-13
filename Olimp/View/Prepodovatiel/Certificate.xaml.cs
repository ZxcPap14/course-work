using Olimp.Model;
using Olimp.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using Windows.Networking.Proximity;

namespace Olimp.View.Prepodovatiel
{
    /// <summary>
    /// Логика взаимодействия для Certificate.xaml
    /// </summary>
    public partial class Certificate : Page
    {
        Core db = new Core();
        public Certificate()
        {
            InitializeComponent();
            Update();
            UpdateOlimp();
        }
        private void Update()
        {

            var protocols = db.context.Certifikat.ToList();

            var protocolViewModel = protocols.Select(t => new Model.Certifikat
            {
                CertificateID = t.CertificateID,
                OlympiadID = t.OlympiadID,
                Name = t.Name,
            }).ToList();

            ProtocolsDataGrid.ItemsSource = protocolViewModel;

        }
        private void UpdateOlimp()
        {
            
            List<Olympiads> olimpik = db.context.Olympiads.ToList();
            glhf.ItemsSource = olimpik;
        }

        private void holokok(object sender, RoutedEventArgs e)
        {
            int olimpid = int.Parse(glhf.Text);
            string nazvanie = Naz.Text;

            if (nazvanie != "" && olimpid != 0)
            {
                
                    string insertQuery = "INSERT INTO Certifikat (OlympiadID, Name) VALUES (@olimpid, @nazvanie)";

                    using (var command = db.context.Database.Connection.CreateCommand())
                    {
                        command.CommandText = insertQuery;
                        command.Parameters.Add(new SqlParameter("@olimpid", olimpid));
                        command.Parameters.Add(new SqlParameter("@nazvanie", nazvanie));

                        db.context.Database.Connection.Open();
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Успех");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            db.context.Database.Connection.Close();
                            Update();
                        }
                    }
                
                
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
