using MailSender.Infrastructure;
using MailSender.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace MailSender
{
    public partial class App : Application
    {
        private static IHost __Hosting;
        public static IHost Hosting => __Hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).ConfigureServices(ConfigureServices);
        public static IServiceProvider Services => Hosting.Services;

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MessagesWindowViewModel>();
            services.AddSingleton<MessagesRepository>();
        }
    }
}
