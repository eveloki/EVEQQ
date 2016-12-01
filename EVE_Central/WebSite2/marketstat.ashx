<%@ WebHandler Language="C#" Class="marketstat" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public class marketstat : HttpTaskAsyncHandler {

    public async override Task ProcessRequestAsync (HttpContext context) {
        string keywords = GetQueryString("key").Trim();

        await Task.Run( () => doit(context,keywords));

    }
    public void doit (HttpContext context,string keywords)
    {
        string Chinesereturn = null;
        if (keywords == ".help")
        {
            Chinesereturn = geturlfromid(34,1, true, 3);
        }
        else
        {

            EVE_Central.DAL.Central dal = new EVE_Central.DAL.Central();
            EVE_Central.Model.Central model = new EVE_Central.Model.Central();
            int i = 0;
            //string s = keywords.Replace(".jita", "");
            try
            {
                int fist = keywords.IndexOf(' ');
                string key = null;//关键字
                string s = null;//操作数
                if (fist != -1)
                {
                    key = keywords.Substring(0, fist).Trim();
                    s = keywords.Replace(key, "").Trim();
                }
                else key = keywords;
                int x = 0;
                int gn = 0;//功能索引
                //if (key == ".jitad") { x = 1; i = 2; gn = 0; }
                //if (key == ".jitada") { x = 2; i = 1; gn = 0; }
                if (key == ".jita") { i = 2; gn = 0; }
                if (key == ".jitaa") { i = 1; gn = 0; }
                if (key == ".id") gn = 1;
                if (key == ".eh") gn = 2;
                if (key == ".col") gn = 3;
                if (key == ".thera") gn = 4;
                if (key == ".K") gn = 5;
                switch(gn)
                {
                    case 0:
                        #region  ExtensionMethod
                        if (s == "")
                        {
                            Chinesereturn = geturlfromid(34, i, true, 2);

                        }
                        else
                        {
                            if (s == "isk" || s == "ISK"|| s=="isk 1"|| s=="isk 2"|| s=="isk 6"|| s=="isk 12"|| s=="isk 28")
                            {
                                EVE_Central.BLL.ISK isk = new EVE_Central.BLL.ISK();
                                int plexs = 6;//默认plex6张
                                int f = s.IndexOf(' ');
                                if (f!=-1)
                                {
                                    string xx =s.Replace("isk", "").Trim();
                                    xx=xx.Replace("ISK", "").Trim();
                                    int hc = Convert.ToInt32(xx);
                                    if (hc == 1 || hc == 2 || hc == 6 || hc == 12 || hc == 28)
                                        plexs = hc;
                                }
                                double[] dou = isk.isk(plexs);
                                string text = "宁静比例:1B≈" + dou[0].ToString() + "RMB\n脑浆预估:" + dou[1].ToString() + "RMB";
                                Chinesereturn= geturlfromid(text);
                            }
                            else
                            {
                                if (s.Length < 50)
                                {
                                    //绝对模式
                                    EVE_Central.Model.name_en ENmodel =dal.API_definitelyStringGetModel(s);
                                    if (ENmodel != null)
                                    {
                                        Chinesereturn = geturlfromid(Convert.ToInt32(ENmodel.typeID.ToString()), i, true, 0);
                                    }
                                    else
                                    {
                                        model = dal.API_chines(s);//特征词匹配
                                        if (model != null)
                                            Chinesereturn = geturlfromid(Convert.ToInt32(model.typeID.Trim()), i, true, 0);
                                        else
                                        {
                                            model = dal.API_StringGetModel(s);
                                            if (model != null)
                                            {
                                                Chinesereturn = geturlfromid(Convert.ToInt32(model.typeID.Trim()), i, true, 0);
                                            }
                                            else
                                                Chinesereturn = geturlfromid(34, i, true);

                                        }
                                    }

                                }
                            }
                        }
                        #endregion  ExtensionMethod
                        break;
                    case 1:
                        if (s == null)
                        {
                            Chinesereturn = geturlfromid(34, i, true, 2);

                        }
                        else
                        {
                            EVE_Central.BLL.api api = new EVE_Central.BLL.api();
                            string[] id=api.StringCharacterInfo(s);
                            Chinesereturn = geturlfromid(id[1],id[0]);

                        }
                        break;
                    case 2:
                        if (s == null)
                        {
                            Chinesereturn = geturlfromid(34, i, true, 2);

                        }
                        else
                        {
                            EVE_Central.BLL.api api1 = new EVE_Central.BLL.api();
                            string id=api1.StringMemberHistory(s);
                            Chinesereturn = geturlfromid(id);

                        }
                        break;
                    case 3:
                        EVE_Central.BLL.ISK isk1 = new EVE_Central.BLL.ISK();
                        string ss = isk1.gaosipip(s);
                        if(ss!=null)
                            Chinesereturn = geturlfromid(ss);
                        break;
                    case 4:
                        EVE_Central.BLL.api api2 = new EVE_Central.BLL.api();
                        string sss = api2.eve_scout();
                        if(sss!=null)
                            Chinesereturn = geturlfromid(sss);
                        break;
                    case 5:
                        EVE_Central.BLL.api api3 = new EVE_Central.BLL.api();
                        if (s == null)
                        {
                            Chinesereturn = geturlfromid(34, i, true, 2);

                        }
                        else
                        {
                            string[] s2 = api3.eve_history(s);
                            Chinesereturn = geturlfromid(s2[0]+'\n'+s2[1]);
                        }
                        break;

                }
            }
            catch (Exception ex)
            {
                Chinesereturn = geturlfromid(34, i, true,2);
            }
        }
        context.Response.ContentType = "application/json";
        context.Response.Charset = "UTF-8";
        context.Response.Write(" "+Chinesereturn);

    }

    public bool IsReusable {
        get {
            return false;
        }
    }
    /// <summary>
    /// 组合返回语句
    /// </summary>
    /// <param name="id">物品id</param>
    /// <param name="b">true:返回价格 反正物品信息</param>
    /// <param name="x">默认1 回复找不到结果 2 参数错误回答</param>
    /// <param name="i">默认1 1全部模式 2 精简</param>
    /// <returns></returns>
    private string geturlfromid(int id,int i =1,bool b=true,int x =1)
    {
        Person p = new Person();
        p.return_code = 0;
        p.return_message = "";
        p.return_img = "";
        p.return_info = "";
        p.appver = 0;
        p.update_url = "";
        p.return_type = 100;//104时，从return_message取文字 (纯文字模式)
        JavaScriptSerializer jss = new JavaScriptSerializer();
        //string url = "http://mc-uuz.kuaiyunds.com/mc-uuz/qq/14715728626994108.jpg";
        string url = "http://mc-uuz.kuaiyunds.com/mc-uuz/qq/1111.jpg";
        if (x==1)
        {
            p.return_img = url;
            p.return_type = 100;
            p.return_message = "";
            string jsons = jss.Serialize(p);
            return jsons;
        }
        if (x == 2)
        {
            p.return_img = "http://mc-uuz.kuaiyunds.com/mc-uuz/qq/121afsfef.jpg";
            p.return_type = 100;
            p.return_message = "";
            string jsons = jss.Serialize(p);
            return jsons;
        }
        if (x == 3)
        {
            p.return_type = 104;
            p.return_message = "市场姬版本：1.07_T 数据库YC-118-9_1.0 \n 命令：\n jita 一般搜索 显示最高收购和最低卖出\n jitaa 增强搜索 获取更多信息\n id 个人信息\n eh 雇佣记录 \ncol 列表  测试状态\n thera 希拉虫洞 格式 星域 星系(安等)总通过质量";
            string jsons = jss.Serialize(p);
            return jsons;
        }
        EVE_Central.BLL.api api = new EVE_Central.BLL.api();
        EVE_Central.BLL.Central cenbll = new EVE_Central.BLL.Central();
        EVE_Central.BLL.typrID typebll = new EVE_Central.BLL.typrID();
        EVE_Central.Model.marketstat mark = new EVE_Central.Model.marketstat();
        EVE_Central.Model.cnoren ce = new EVE_Central.Model.cnoren();
        EVE_Central.Model.typrID typemodel = new EVE_Central.Model.typrID();
        mark=api.marketstat(id);

        ce = cenbll.apifind(id);
        string name_en = null;
        string name_cn = null;
        string mark_en = null;
        string mark_cn = null;
        if (ce == null)
        {
            //如果在数据库中找不到物品的中文信息 则到英文数据库检索
            typemodel = typebll.GetModelfromtypeID(id);
            name_en = typemodel.name_en;
            mark_en = typemodel.description_en.Replace("\\n", string.Empty).Replace("\\r", string.Empty);
        }
        else
        {
            name_cn = ce.cn;
            name_en = ce.en;
            mark_cn = ce.mcn;
            mark_en = ce.men;
        }
        name_en = name_en.Trim().Replace("\n", string.Empty);
        string s = null;
        if (b)
        {
            string imgurl = "https://imageserver.eveonline.com/Type/" + id + "_64.png";
            //string imgurl = "http://imageserver.eve-central.cn/types/" + id + "_64.png";
            p.return_img = imgurl;
            if (i == 1)
            {
                mark = isktom(mark);
                //增强
                s = name_cn + "$" +name_en + " \n收购 AVG(中间):" + mark.buy_avg + "ISK\n  MAX(最高):" + mark.buy_max + "ISK\n  MEDIAN(中间):" + mark.buy_median + "ISK " + "\n售出 AVG(中间):" + mark.sell_avg + "ISK \n  MIN(最低):" + mark.sell_min + "ISK \n  MEDIAN(中间):" + mark.sell_median + "ISK";
            }
            if (i == 2)
            {
                mark = isktom(mark,true);
                //简洁
                s = name_en + " \n" + mark.sell_min + "/" + mark.buy_max;
            }
        }
        else
        {
            s = name_cn + "$" + name_en + " " + mark_cn + "$" + mark_en;
        }
        p.return_message = s;
        string json = jss.Serialize(p);
        return json;
    }
    /// <summary>
    /// 组合机器人发回的语句
    /// </summary>
    /// <param name="text">文字</param>
    /// <param name="img">图片网络地址</param>
    /// <returns></returns>
    private string geturlfromid(string text,string img=null)
    {
        Person p = new Person();
        p.return_code = 0;
        p.return_message = "";
        p.return_img = "";
        p.return_info = "";
        p.appver = 0;
        p.update_url = "";
        p.return_type = 104;//104时，从return_message取文字 (纯文字模式)
        JavaScriptSerializer jss = new JavaScriptSerializer();
        if(img!=null)
        {
            p.return_img = img;
            p.return_type = 100;
        }
        else
            p.return_type = 104;
        p.return_message = text;
        string jsons = jss.Serialize(p);
        return jsons;

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
    /// json对象类
    /// </summary>
    public class Person
    {
        public int return_code { get; set; }
        public string return_message { get; set; }
        public string return_img { get; set; }
        public string return_info { get; set; }
        public int appver { get; set; }
        public string update_url { get; set; }
        public int return_type { get; set; }
    }
    /// <summary>
    /// isk 规则话
    /// </summary>
    /// <param name="mark"></param>
    /// <param name="b">是否触发isk规则转换 10e转为1b 默认不转换flase</param>
    /// <returns></returns>
    private EVE_Central.Model.marketstat isktom(EVE_Central.Model.marketstat mark,bool b =false)
    {
        EVE_Central.Model.marketstat mark1 = new EVE_Central.Model.marketstat();
        mark1.buy_avg = Convert.ToDouble(mark.buy_avg).ToString("N");
        mark1.buy_max = Convert.ToDouble(mark.buy_max).ToString("N");
        mark1.buy_median = Convert.ToDouble(mark.buy_median).ToString("N");
        mark1.buy_min = Convert.ToDouble(mark.buy_min).ToString("N");
        mark1.sell_avg = Convert.ToDouble(mark.sell_avg).ToString("N");
        mark1.sell_max = Convert.ToDouble(mark.sell_max).ToString("N");
        mark1.sell_median = Convert.ToDouble(mark.sell_median).ToString("N");
        mark1.sell_min = Convert.ToDouble(mark.sell_min).ToString("N");
        int i = mark.buy_max.Length;
        if (i> 9 && b ) //1m
        {
            mark1.buy_avg = misk(mark.buy_avg);
            mark1.buy_max = misk(mark.buy_max);
            mark1.buy_median = misk(mark.buy_median);
            mark1.buy_min = misk(mark.buy_min);
            mark1.sell_avg = misk(mark.sell_avg);
            mark1.sell_max = misk(mark.sell_max);
            mark1.sell_median = misk(mark.sell_median);
            mark1.sell_min = misk(mark.sell_min);
        }
        return mark1;
    }
    /// <summary>
    /// 处理m isk 返回150M ISK
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    private string misk(string s)
    {
        if (s.Length > 12)
        {
            string k = s.Substring(0, s.Length - 10);
            double b = Convert.ToDouble(k) / 100;
            s = b.ToString() + "B ISK";

        }
        else
        if(s.Length>9)
        {
            string k = s.Substring(0, s.Length - 7);
            double b = Convert.ToDouble(k) / 100;
            s = b.ToString() + "M ISK";
        }
        return s;


    }
    private void EVE_CentralLog()
    {
        int i = 1;
        string s = System.Web.HttpContext.Current.Server.MapPath("./");
        string path =s+ "login.txt";
        StreamReader m_streamReader = new StreamReader(path, System.Text.Encoding.GetEncoding("GB2312"));
        m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
        string strLine = m_streamReader.ReadLine();
        i = Convert.ToInt32(strLine);
        m_streamReader.Close();
        StreamWriter m_streamWriter = new StreamWriter(path, false,Encoding.GetEncoding("GB2312"));
        m_streamWriter.Flush();
        m_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
        i = i + 1;
        m_streamWriter.Write(i.ToString());
        m_streamWriter.Flush();
        m_streamWriter.Close();
    }

}
