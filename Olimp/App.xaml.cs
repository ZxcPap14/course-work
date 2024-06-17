using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Olimp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Загрузка шрифта из файла конфигурации
            string fontFamily = ConfigurationManager.AppSettings["FontFamily"];

            if (!string.IsNullOrEmpty(fontFamily))
            {
                // Установка шрифта как динамического ресурса
                Resources["AppFontFamily"] = new FontFamily(new Uri("C:\\Users\\SystemX\\Source\\Repos\\ZxcPap14\\course-work\\Olimp\\src\\font\\OpenSans-VariableFont_wdth,wght.ttf"), fontFamily);
            }
        }
    }
}
