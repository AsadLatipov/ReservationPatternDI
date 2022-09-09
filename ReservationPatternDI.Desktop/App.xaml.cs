
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReservationPatternDI.Desktop.StartupHelpers;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace ReservationPatternDI.Desktop
{
    public partial class App : Application
    {
        private readonly IHost AppHost;
        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(services);
                })
                .Build();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<OrdersWindow>();
            services.AddFormFactory<MakeReservationWindow>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StopAsync();

            var startUpForm = AppHost.Services.GetRequiredService<OrdersWindow>();
            startUpForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {

            await AppHost.StopAsync();
            base.OnExit(e);
        }
    }
}
