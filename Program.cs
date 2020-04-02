using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace WxWebCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
           BuildWebHost(args).Run();
           //BuildWebHostIIS(args).Run();

        }
        /// <summary>
        /// 构建配制
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost BuildWebHost(string[] args)
        {

            var configBuilder = new ConfigurationBuilder();
            var host = new WebHostBuilder();
            try
            {
                if (args != null && args.Length > 0)
                    configBuilder.AddCommandLine(args);
                else
                    configBuilder.AddJsonFile("hosting.json", optional: true);
                //配制文件创建
                var Hosting = configBuilder.Build();
                //web服务创建
                host.UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseConfiguration(Hosting);



            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return host.Build();
        }
        /// <summary>
        /// 默认IIS加载
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost BuildWebHostIIS(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();






    }
}
