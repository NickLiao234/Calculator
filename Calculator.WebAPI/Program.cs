using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.WebAPI
{
    /// <summary>
    /// µ{¦¡¶i¤JÂI
    /// </summary>
    public class Program
    {
        /// <summary>
        /// ¥Dµ{¦¡¤èªk
        /// </summary>
        /// <param name="args">args</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// «Ø¥ßbuilder
        /// </summary>
        /// <param name="args">args</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
