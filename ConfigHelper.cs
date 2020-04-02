using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WxWebCore
{
    /// <summary>
    /// 配制帮助类
    /// </summary>
    public class ConfigHelper
    {
        private static IConfiguration config;

        static ConfigHelper()
        {

            var filename = "appsettings.json";
            var directiory = AppContext.BaseDirectory.Replace("\\", "/");
            var filepath = directiory + filename;
            if (!File.Exists(filepath))
            {
                var length = directiory.IndexOf("/bin");
                filepath = $"{directiory.Substring(0, length)}/{filename}";

            }
            var builder = new ConfigurationBuilder().AddJsonFile(filepath, false, true);
            config = builder.Build();
        }
        /// <summary>
        /// 获取配制项
        /// </summary>
        /// <param name="key">键：AppSettings:appkey</param>
        /// <returns></returns>
        public static string GetGetSectionValue(string key)
        {
            return config.GetSection(key).Value;
        }
        /// <summary>
        /// 获取连接配制
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string ConnectionStrings(string key)
        {

            return config.GetSection($"ConnectionStrings:{key}").Value;

        }
        /// <summary>
        /// 获取应用配制
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string AppSettings(string key)
        {
            return config.GetSection($"AppSettings:{key}").Value;
        }
    }
}
