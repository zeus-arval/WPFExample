using BankApp.MVVM;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace BankApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IHost AppHost { get; init; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices(RegisterServices)
                .Build();
        }

        private void RegisterServices(HostBuilderContext context, IServiceCollection collection)
        {
            collection.AddSingleton<MainWindow>();
            collection.AddSingleton<IUserRepository, UserRepository>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
