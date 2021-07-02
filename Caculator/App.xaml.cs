using Caculator.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// ServiceProvider
        /// </summary>
        private readonly ServiceProvider _serviceProvider;

        /// <summary>
        /// 初始化app
        /// </summary>
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// DI設定
        /// </summary>
        /// <param name="services">service collection</param>
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddHttpClient("CalculateService", c =>
            {
                c.BaseAddress = new Uri("https://localhost:5001/Calculate/");
            });

            services.AddSingleton<IGetResultByWebAPIService, GetResultByWebAPIService>();
            services.AddSingleton<ICalculateExpressionService, CalculateExpressionService>();
            services.AddSingleton<IEditViewModelService, EditViewModelService>();
            services.AddSingleton<CalculatorViewModel>();
            services.AddSingleton<IAppendNumberService, AppendNumberService>();
            services.AddSingleton<IBackService, BackService>();
            services.AddSingleton<IClearService, ClearService>();
            services.AddSingleton<IClearCurrentService, ClearCurrentService>();
            services.AddSingleton<IReverseService, ReverseService>();
            services.AddSingleton<ISquareRootService, SquareRootService>();
            services.AddSingleton<MainWindow>();
        }

        /// <summary>
        /// 啟動app
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">args</param>
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
