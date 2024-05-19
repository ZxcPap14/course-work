using Olimp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations.Model;
using System.Windows.Controls;

namespace Olimp.View
{
    public partial class Protokol : Page
    {

        public Protokol()
        {
            InitializeComponent(); 
            UpdateView();
        }
        public void UpdateView()
        {
            listviewProtocol.Items.Clear();
            
        }

    }

}
