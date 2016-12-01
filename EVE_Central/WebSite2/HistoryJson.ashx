<%@ WebHandler Language="C#" Class="HistoryJson" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EVE_Central;
using EVE_Central.Model;
using System.Xml;
using Xfrog.Net;
using Newtonsoft.Json;
using EVE_Central.Basis;
using System.Drawing;

public class HistoryJson : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        string sss = GetQueryString("typeid");
        int keywords = Convert.ToInt32(sss);
        EVE_Central.BLL.api api = new EVE_Central.BLL.api();
        List<EVE_Central.Model.Hiosty> modelist =api.eve_historylist(keywords);
        string json = "[\n";
        for (int i = 0; i < modelist.Count; i++)
        {
            json += "[";
            json += time(modelist[i].date)+",";//时间
            json += modelist[i].highest.ToString("f2")+",";//高
            json += modelist[i].highest.ToString("f2")+",";//高
            json += modelist[i].lowest.ToString("f2") + ",";//低
            json += modelist[i].lowest.ToString("f2") + ",";//低  
            json += modelist[i].volume.ToString();//成交量
            json = json.Substring(0, json.Length - 1);
            json += "],\n";
        }
        json = json.Substring(0, json.Length - 2);
        json += "\n]";
        context.Response.ContentType = "text/javascript";
        context.Response.Charset = "UTF-8";
        context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
        context.Response.Write(json);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }
    /// <summary>
    /// 获得指定Url参数的值
    /// </summary>
    /// <param name="strName">Url参数</param>
    /// <returns>Url参数的值</returns>
    public static string GetQueryString(string strName)
    {
        return GetQueryString(strName, false);
    }
    /// <summary>
    /// 获得指定Url参数的值
    /// </summary> 
    /// <param name="strName">Url参数</param>
    /// <param name="sqlSafeCheck">是否进行SQL安全检查</param>
    /// <returns>Url参数的值</returns>
    public static string GetQueryString(string strName, bool sqlSafeCheck)
    {
        if (HttpContext.Current.Request.QueryString[strName] == null)
            return "";


        return HttpContext.Current.Request.QueryString[strName];
    }
    /// <summary>
    /// yyyy-MM-ddThh:mm:ss格式转换成datatime 并处理
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string time(string s)
    {
        DateTime dt = DateTime.ParseExact(s, "yyyy-MM-ddTHH:mm:ssZ", System.Globalization.CultureInfo.CurrentCulture);
        return EVE_Central.Basis.UnixTime.ConvertDateTimeInt(dt).ToString();

    }
}