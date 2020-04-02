using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WxPayLib;
using WxPayLib.Command;
using WxPayLib.Model;
using WxWebCore.Models;

namespace WxWebCore.Controllers
{
    public class HomeController : ControllerBase
    {

        public IActionResult Index()
        {

            var parm = new WxParm()
            {
                appid = AppConfig.appID,
                redirect_uri = AppConfig.redirect_url,
                response_type = "code",
                scope = "snsapi_userinfo",
                state = "STATE"
            };
            var server = new WxApiHelper(AppConfig.authorize_url).GetCodeUrl(parm);
            Response.Redirect(server);
            return View();
        }
        /// <summary>
        /// 通过Code获取用户凭证
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            var code = Request.Query["code"];
            Loger.Log("code:" + code);
            if (!string.IsNullOrEmpty(code))
            {
                try
                {
                    var json = new WxApiHelper(AppConfig.access_token_url).GetAccess_token(AppConfig.appID, AppConfig.appsecret, code);
                    var mode = json.JsonToObject<AccessTokenReturn>();
                    if (mode != null)
                    {
                        var userinfo = new WxApiHelper(AppConfig.userinfo_url).GetUserInfo(mode.access_token, mode.openid);
                        Loger.Log("WxUserInfo:" + userinfo);
                        var userinfomode = userinfo.JsonToObject<WxUserInfo>();
                        if (userinfomode != null)
                        {
                            ViewBag.userinfo = userinfomode;
                        }
                        else
                        {
                            Loger.Log("userinfomode:为空！");
                        }
                    }
                    else
                    {
                        Loger.Log("Privacy:" + json);
                    }
                }
                catch (System.Exception ex)
                {

                    Loger.Log("导常",ex.ToString());
                }
               
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
