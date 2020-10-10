using EKZAMENADONET.ViewModels;
using EKZAMENADONET.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EKZAMENADONET
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainView = new MainView()
            {
                DataContext = new MainViewModel(new GoodViewModel())
            };

            MainWindow = mainView;
            MainWindow.Show();
        }
    }
}
