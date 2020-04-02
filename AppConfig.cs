using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WxWebCore
{
    /// <summary>
    /// 配制类
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// 帐号配制
        /// </summary>
        public static readonly string appID = ConfigHelper.AppSettings("appID");
        /// <summary>
        /// 帐号凭证
        /// </summary>
        public static readonly string appsecret = ConfigHelper.AppSettings("appsecret");
        /// <summary>
        /// access_token服务地址
        /// </summary>
        public static readonly string access_token_url = ConfigHelper.AppSettings("access_token_url");
        /// <summary>
        /// 页面受服务
        /// </summary>
        public static readonly string authorize_url = ConfigHelper.AppSettings("authorize_url");
        /// <summary>
        /// 受权跳转
        /// </summary>
        public static readonly string redirect_url = ConfigHelper.AppSettings("redirect_url");
        /// <summary>
        /// 用户服务地址
        /// </summary>
        public static readonly string userinfo_url = ConfigHelper.AppSettings("userinfo_url");

    }
}
