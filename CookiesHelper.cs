using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

/// <summary>
///  Cookies帮肋类
/// </summary>
public class CookiesHelper: ControllerBase
{
    public CookiesHelper()
    {

    }
    /// <summary>
    /// 添加Cookies
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void Add(string key, string value)
    {
      Response.Cookies.Append(key, value);
    }

    /// <summary>
    /// 添加Cookies
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void Add(string key, string value, TimeSpan ts)
    {
        Response.Cookies.Append(key, value, new CookieOptions { Expires = DateTime.Now.Add(ts) });
    }
    /// <summary>
    /// 获取cookies
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string getCookies(string key)
    {
        string result = string.Empty;
        if (!string.IsNullOrEmpty(key))
        {
            var haskey = Request.Cookies.ContainsKey(key);
            if (haskey)
            {
                Request.Cookies.TryGetValue(key, out string value);
                result = value;
            }
        }
        return result;

    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="key"></param>
    public void DelCookies(string key)
    {
        Response.Cookies.Delete(key);
    }
}

