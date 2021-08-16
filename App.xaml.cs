using DevExpress.Charts.Designer.Native;
using DevExpress.Xpf.Core;
using DXApplication1.Export;
using DXApplication1.ViewModels;
using DXApplication1.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DXApplication1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    { 
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IExport, ExportData>();
            services.AddScoped<MainViewModel>();
            return services.BuildServiceProvider();
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = new MainWindow();
            window.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            window.Show();
        }

    }
}
