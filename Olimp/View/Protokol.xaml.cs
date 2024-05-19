using Olimp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Olimp.View
{
    public partial class Protokol : Page
    {
        public ObservableCollection<ProtocolViewModel> Protocols { get; set; }

        public Protokol()
        {
            InitializeComponent();
            Protocols = new ObservableCollection<ProtocolViewModel>();

            // Пример заполнения списка протоколов. Замените этот код на ваш запрос к базе данных.
            Protocols.Add(new ProtocolViewModel { Name = "Олимпиада по математике", Status = "формируется" });
            Protocols.Add(new ProtocolViewModel { Name = "Олимпиада по физике", Status = "подготовлен" });

            DataContext = this;
        }
    }

    public class ProtocolViewModel
    {
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
