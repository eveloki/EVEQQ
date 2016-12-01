using System;
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

namespace EVE_Central.BLL
{
    /// <summary>
    /// eve-central API解析代码
    /// </summary>
    public class api
    {
        /// <summary>
        /// 根据物品id获取市场快照
        /// </summary>
        /// <param name="typeID">物品id</param>
        /// <param name="usesystem">星系id</param>
        /// <param name="regionlimit">星域id</param>
        /// <param name="BID">0买单 1卖单</param>
        /// <returns></returns>
        public List<EVEXml> Quicklook(int typeID, string usesystem = null, string regionlimit = null, int BID = 0)
        {
            string url = urlfind(typeID, usesystem, regionlimit);
            XDocument oXDoc = XDocument.Load(url);
            List<EVEXml> bookModeList = new List<EVEXml>();
            //XDocument oXDoc = XDocument.Load(url);
            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            //XmlNodeList Xmllist = doc.GetElementsByTagName("evec_api");
            XmlNode xn = doc.SelectSingleNode("evec_api");
            XmlNode xn2 = xn.SelectSingleNode("quicklook");
            XmlNode Xnsell = xn2.SelectSingleNode("sell_orders");
            XmlNode Xnbuy = xn2.SelectSingleNode("buy_orders");
            if (BID == 1)
            {
                XmlNodeList xnl = Xnsell.ChildNodes;// 得到根节点的所有子节点
                foreach (XmlNode xn1 in xnl)
                {
                    EVE_Central.Model.EVEXml bookModel = new EVEXml();
                    // 将节点转换为元素，便于得到节点的属性值
                    XmlElement xe = (XmlElement)xn1;
                    // 得到Type和ISBN两个属性的属性值
                    bookModel.id = xe.GetAttribute("id").ToString();
                    // 得到Book节点的所有子节点
                    XmlNodeList xnl0 = xe.ChildNodes;
                    bookModel.region = xnl0.Item(0).InnerText;
                    bookModel.station = xnl0.Item(1).InnerText;
                    bookModel.station_name = xnl0.Item(2).InnerText;
                    bookModel.security = xnl0.Item(3).InnerText;
                    bookModel.range = xnl0.Item(4).InnerText;
                    bookModel.price = xnl0.Item(5).InnerText;
                    bookModel.vol_remain = xnl0.Item(6).InnerText;
                    bookModel.min_volume = xnl0.Item(7).InnerText;
                    bookModel.expires = xnl0.Item(8).InnerText;
                    bookModel.reported_time = xnl0.Item(9).InnerText;
                    bookModeList.Add(bookModel);
                }
            }
            else
            {
                XmlNodeList xnl = Xnbuy.ChildNodes;// 得到根节点的所有子节点
                foreach (XmlNode xn1 in xnl)
                {
                    EVE_Central.Model.EVEXml bookModel = new EVEXml();
                    // 将节点转换为元素，便于得到节点的属性值
                    XmlElement xe = (XmlElement)xn1;
                    // 得到Type和ISBN两个属性的属性值
                    bookModel.id = xe.GetAttribute("id").ToString();
                    // 得到Book节点的所有子节点
                    XmlNodeList xnl0 = xe.ChildNodes;
                    bookModel.region = xnl0.Item(0).InnerText;
                    bookModel.station = xnl0.Item(1).InnerText;
                    bookModel.station_name = xnl0.Item(2).InnerText;
                    bookModel.security = xnl0.Item(3).InnerText;
                    bookModel.range = xnl0.Item(4).InnerText;
                    bookModel.price = xnl0.Item(5).InnerText;
                    bookModel.vol_remain = xnl0.Item(6).InnerText;
                    bookModel.min_volume = xnl0.Item(7).InnerText;
                    bookModel.expires = xnl0.Item(8).InnerText;
                    bookModel.reported_time = xnl0.Item(9).InnerText;
                    bookModeList.Add(bookModel);
                }
            }

            return bookModeList;
        }
        private string urlfind(int typeID, string usesystem, string regionlimit)
        {
            string url = "http://api.eve-central.com/api/quicklook?";
            url += typeID.ToString();
            if (usesystem != null)
                url += ("&usesystem=" + usesystem);
            if (regionlimit != null)
                url += ("&regionlimit=" + regionlimit);
            return url;

        }
        public Model.marketstat marketstat(int typeID)
        {
            string url = "http://api.eve-central.com/api/marketstat?typeid=" + typeID.ToString() + "&usesystem=30000142";
            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            //XmlNodeList Xmllist = doc.GetElementsByTagName("evec_api");
            XmlNode xn = doc.SelectSingleNode("evec_api");
            XmlNode xn1 = xn.SelectSingleNode("marketstat");
            XmlNode xn2 = xn1.SelectSingleNode("type");
            XmlNode Xnsbuy = xn2.SelectSingleNode("buy");
            XmlNode Xnssell = xn2.SelectSingleNode("sell");
            Model.marketstat mark = new Model.marketstat();
            XmlNodeList xnl0 = Xnsbuy.ChildNodes;
            mark.buy_avg = xnl0.Item(1).InnerText;
            mark.buy_max = xnl0.Item(2).InnerText;
            mark.buy_min = xnl0.Item(3).InnerText;
            mark.buy_median = xnl0.Item(5).InnerText;
            XmlNodeList xnl1 = Xnssell.ChildNodes;
            mark.sell_avg = xnl1.Item(1).InnerText;
            mark.sell_max = xnl1.Item(2).InnerText;
            mark.sell_min = xnl1.Item(3).InnerText;
            mark.sell_median = xnl1.Item(5).InnerText;
            return mark;
        }
        /// <summary>
        /// 根据名字返回精简用户信息 [0]返回头像url 【1】信息
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string[] StringCharacterInfo(string s)
        {
            Model.CharacterInfo memberinfo = CharacterInfoFromName(s);
            string url = "https://imageserver.eveonline.com/Character/" + memberinfo.characterID + "_128.jpg"; 
            string stringinfo = "人物名称:" + memberinfo.characterName + '\n';
            stringinfo += "建号时间:" + memberinfo.employmentHistory[memberinfo.employmentHistory.Count - 1].startDate + '\n';
            stringinfo += "所在公司:" + memberinfo.corporation + '\n';
            stringinfo += "加入时间:" + gethisttime(memberinfo.employmentHistory[0].startDate) + '\n';
            if (memberinfo.alliance == null)
                stringinfo += "所在联盟:Strategic Fooyou Agency\n";
            else
            stringinfo += "所在联盟:" + memberinfo.alliance + '\n';
            stringinfo += "安全等级:" + memberinfo.securityStatus.Substring(0,4);
            string[] ss = new string[2];
            ss[0]= url;
            ss[1] = stringinfo;
            return ss;
        }
        /// <summary>
        /// 雇佣记录
        /// </summary>
        /// <param name="s"></param>
        /// <param name="i">默认5 最多展示五条雇佣记录</param>
        /// <returns></returns>
        public string StringMemberHistory(string s,int k =5)
        {
            Model.CharacterInfo memberinfo = CharacterInfoFromName(s);
            string stringinfo = "人物名称:" + memberinfo.characterName + '\n';
            if (memberinfo.employmentHistory.Count < k)
                k = memberinfo.employmentHistory.Count;

            for (int i = 0; i < k; i++)
            {
                stringinfo += memberinfo.employmentHistory[i].corporationNam+' '+ memberinfo.employmentHistory[i].startDate+ '\n';
            }
            return stringinfo;
        }
        /// <summary>
        /// 根据名字获取用户信息
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public Model.CharacterInfo CharacterInfoFromName(string s)
        {
            return CharacterInfo(CharacterID(s));
        }
        /// <summary>
        /// 官方api 根据名字获取角色id
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string CharacterID(string s)
        {
            string url = "https://api.eveonline.com/eve/CharacterID.xml.aspx?names=" + s;
            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlNode xn = doc.SelectSingleNode("eveapi");
            XmlNode xn2 = xn.SelectSingleNode("result");
            XmlNode xn3 = xn2.SelectSingleNode("rowset");
            XmlNodeList xnl = xn3.ChildNodes;// 得到根节点的所有子节点
            string id = null;
            foreach (XmlNode xn1 in xnl)
            {

                // 将节点转换为元素，便于得到节点的属性值
                XmlElement xe = (XmlElement)xn1;
                // 得到Type和ISBN两个属性的属性值
                id = xe.GetAttribute("characterID").ToString();
                // 得到Book节点的所有子节点
                XmlNodeList xnl0 = xe.ChildNodes;

            }
            return id;
        }
        /// <summary>
        ///  官方ESIapi 根据名字获取角色id
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ESICharacterID(string s)
        {
            string url = "https://esi.tech.ccp.is/latest/search/?search="+s + "&categories=character&language=en-us&strict=false&datasource=tranquility";
            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlNode xn = doc.SelectSingleNode("eveapi");
            XmlNode xn2 = xn.SelectSingleNode("result");
            XmlNode xn3 = xn2.SelectSingleNode("rowset");
            XmlNodeList xnl = xn3.ChildNodes;// 得到根节点的所有子节点
            string id = null;
            foreach (XmlNode xn1 in xnl)
            {

                // 将节点转换为元素，便于得到节点的属性值
                XmlElement xe = (XmlElement)xn1;
                // 得到Type和ISBN两个属性的属性值
                id = xe.GetAttribute("characterID").ToString();
                // 得到Book节点的所有子节点
                XmlNodeList xnl0 = xe.ChildNodes;

            }
            return id;
        }
        /// <summary>
        /// 官方api 根据玩家id获取玩家信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.CharacterInfo CharacterInfo(string id)
        {
            string url = "https://api.eveonline.com/eve/CharacterInfo.xml.aspx?characterID=" + id;
            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlNode xn = doc.SelectSingleNode("eveapi");
            XmlNode xn2 = xn.SelectSingleNode("result");
            Model.CharacterInfo ci = new Model.CharacterInfo();
            XmlNodeList xnl0 = xn2.ChildNodes; //开始收集玩家信息
            if (xnl0.Count > 13)//没用联盟有12个元素
            {
                ci.characterID = xnl0.Item(0).InnerText;
                ci.characterName = xnl0.Item(1).InnerText;
                ci.race = xnl0.Item(2).InnerText;
                ci.bloodline = xnl0.Item(4).InnerText;
                ci.ancestry = xnl0.Item(6).InnerText;
                ci.corporationID = xnl0.Item(7).InnerText;
                ci.corporation = xnl0.Item(8).InnerText;
                ci.corporationDate = xnl0.Item(9).InnerText;
                ci.allianceID = xnl0.Item(10).InnerText;
                ci.alliance = xnl0.Item(11).InnerText;
                ci.allianceDate = xnl0.Item(12).InnerText;
                ci.securityStatus = xnl0.Item(13).InnerText;
            }
            else
            {
                ci.characterID = xnl0.Item(0).InnerText;
                ci.characterName = xnl0.Item(1).InnerText;
                ci.race = xnl0.Item(2).InnerText;
                ci.bloodline = xnl0.Item(4).InnerText;
                ci.ancestry = xnl0.Item(6).InnerText;
                ci.corporationID = xnl0.Item(7).InnerText;
                ci.corporation = xnl0.Item(8).InnerText;
                ci.corporationDate = xnl0.Item(9).InnerText;
                ci.securityStatus = xnl0.Item(10).InnerText;
            }
            XmlNode xn3 = xn2.SelectSingleNode("rowset");//雇佣记录信息收集
            XmlNodeList xnl1 = xn3.ChildNodes;
            List<EVE_Central.Model.corporation> corplist = new List<corporation>();//雇佣记录泛型
            foreach (XmlNode xn1 in xnl1)
            {
                EVE_Central.Model.corporation bookModel = new corporation();//雇佣记录实体类
                // 将节点转换为元素，便于得到节点的属性值
                XmlElement xe = (XmlElement)xn1;
                // 得到Type和ISBN两个属性的属性值
                bookModel.recordID = xe.GetAttribute("recordID").ToString();
                bookModel.corporationID = xe.GetAttribute("corporationID").ToString();
                bookModel.corporationNam = xe.GetAttribute("corporationName").ToString();
                bookModel.startDate = xe.GetAttribute("startDate").ToString();
                corplist.Add(bookModel);
            }
            ci.employmentHistory = corplist;
            return ci;
        }
        /// <summary>
        /// 获取eve服务器时间以及人数 [0]为服务器时间[1]为服务器状态[2]为服务器人数
        /// </summary>
        /// <returns></returns>
        public string[] EVEtime()
        {
            string[] s = new string[3];
            string url = "https://api.eveonline.com/server/ServerStatus.xml.aspx";
            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlNode xn = doc.SelectSingleNode("eveapi");
            XmlNode xn2 = xn.SelectSingleNode("result");
            XmlNodeList xnl0 = xn.ChildNodes;
            s[0] = xnl0.Item(0).InnerText;
            XmlNodeList xnl1 = xn2.ChildNodes;
            s[1] = xnl0.Item(0).InnerText;
            s[2] = xnl0.Item(1).InnerText;
            return s;
        }
        /// <summary>
        /// 返回雇佣记录持续时间
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        private string gethisttime(string start)
        {
            string[] evetime = EVEtime();
            return DateDiff(Convert.ToDateTime(start),Convert.ToDateTime(evetime[0]));

        }
        /// <summary>
        /// 两个日期相减 得到年、月、日字符串
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static string DateDiff(DateTime start, DateTime end)
        {
            string dateDiff = string.Empty;
            try
            {
                DateTime end1;
                int date = (end.AddDays(1) - start).Days;//两个日期相距的天数
                int date1 = 0;
                //开始日期的天<=结束日期的天。
                if (start.Day <= end.Day)
                {
                    //自定义一个日期，结束日期。年月不变，天变为开始日期的天
                    end1 = new DateTime(end.Year, end.Month, start.Day);
                }
                //开始日期的天>结束日期的天。结束日期需要减小一个月
                else
                {
                    //自定义一个日期，结束日期。年不变，月份减1，天变为开始日期的天
                    end1 = new DateTime(end.Year, end.Month - 1, start.Day);
                }
                //自定义结束日期与开始日期相距的天数
                date1 = (end1 - start).Days;
                int year = 0;
                int month = (end1.Year - start.Year) * 12 + end1.Month - start.Month;
                int day = date - date1;
                if (month >= 12)
                {
                    year = (int)month / 12;
                    month = month % 12;
                }
                if (year > 0)
                {
                    dateDiff += year + "年";
                }
                if (month > 0)
                {
                    dateDiff += month + "月";
                }
                if (day > 0)
                {
                    dateDiff += day + "天";
                }
            }
            catch (Exception ex)
            {
                dateDiff = null;
            }


            return dateDiff;
        }
        /// <summary>
        /// 根据id获取历史记录
        /// </summary>
        /// <param name="id"></param>
        public List<EVE_Central.Model.Market_History> gethoisty(int id)
        {
            List<EVE_Central.Model.Market_History> ml = new List<Model.Market_History>();
            EVE_Central.Model.Market_History moble = new Model.Market_History();
            string url1 = "https://esi.tech.ccp.is/legacy/markets/10000002/history/?type_id=" + id.ToString()+ "&datasource=tranquility";
            string url = "https://esi.tech.ccp.is/legacy/markets/10000002/history/";
            EVE_Central.ConsoleAPI.ConsoleAPI jsapi = new EVE_Central.ConsoleAPI.ConsoleAPI();
            var parameters1 = new Dictionary<string, string>();
            parameters1.Add("type_id", id.ToString());//你申请的key
            parameters1.Add("datasource", "tranquility");
            string result1=jsapi.sendPost(url, parameters1, "get");
            JsonObject newObj1 = new JsonObject(result1);
            JsonProperty js = newObj1[""];
            return null;
        }
        /// <summary>
        /// api 希拉胡同
        /// </summary>
        /// <returns></returns>
        public string eve_scout()
        {
            string s = "";
            List < EVE_Central.Model.eve_scout > eve= eve_scoutlist();
            int x = eve.Count; int g = 0;
            if (x > 20) x = 20;
            for (int i = 0; i < x; i++)
            {
                s += eve[i].destinationSolarSystem.region.name + "$" + eve[i].destinationSolarSystem.name + '(' + eve[i].destinationSolarSystem.security.ToString("0.00") + ')';
                if (eve[i].destinationWormholeType.maxMass!=0)
                    s +=eve[i].destinationWormholeType.maxMass.ToString();
                else 
                    s += eve[i].sourceWormholeType.maxMass.ToString();
                g++;
                if (g == 2) { g = 0; s += "\n"; }
                else s += "|";
            }
            return s;
        }
        /// <summary>
        /// 返回希拉虫洞对象
        /// </summary>
        /// <returns></returns>
        public List<EVE_Central.Model.eve_scout> eve_scoutlist()
        {
            string url = "http://www.eve-scout.com/api/wormholes";
            EVE_Central.ConsoleAPI.ConsoleAPI jsapi = new EVE_Central.ConsoleAPI.ConsoleAPI();
            var parameters1 = new Dictionary<string, string>();
            parameters1.Add("systemSearch", "Jita");
            parameters1.Add("limit", "1000");
            parameters1.Add("offset", "0");
            parameters1.Add("order", "asc");
            //parameters1.Add("_", "1479083537439");
            string result1 = jsapi.sendPost(url, parameters1, "get");
            return json.JsonHelper.DeserializeJsonToList<EVE_Central.Model.eve_scout>(result1);
        }
        
        /// <summary>
        /// 返回ESI history对象
        /// </summary>
        /// <returns></returns>
        public List<EVE_Central.Model.Hiosty> eve_historylist(int i)
        {
            string url = "https://esi.tech.ccp.is/latest/markets/10000002/history/";
            EVE_Central.ConsoleAPI.ConsoleAPI jsapi = new EVE_Central.ConsoleAPI.ConsoleAPI();
            var parameters1 = new Dictionary<string, string>();
            parameters1.Add("type_id", i.ToString());//你申请的key
            parameters1.Add("datasource", "tranquility");
            string result1 = jsapi.sendPost(url, parameters1, "get");
            return json.JsonHelper.DeserializeJsonToList<EVE_Central.Model.Hiosty>(result1);
        }
        public Bitmap eve_historyimg(int i)
        {
            List<EVE_Central.Model.Hiosty> modelist = eve_historylist(i);
            int x = modelist.Count;int g=0;
            if (x > 30)
            {
                g = x - 30-1;
            }
            float[] fltsValues = new float[60];int d = 0;
            string[] strsKeys = new string[] { "-30","","","","" ,"-25", "", "", "", "", "-20", "", "", "", "", "-15", "", "", "", "", "-10", "", "", "", "", "-5", "", "", "", "0" };
            for (int k = x - 1; k >= 0+g; k--)
            {
                fltsValues[d] = float.Parse(modelist[k].highest.ToString());
                fltsValues[d + 29] = float.Parse(modelist[k].lowest.ToString());
                d++;
            }
            EVE_Central.BLL.typrID bll = new typrID();
            EVE_Central.Model.typrID mode = new Model.typrID();
            mode=bll.GetModelfromtypeID(i);
            EVE_Central.Basis.Curve2D cuv2D = new Curve2D();
            cuv2D.set(mode.name_en+ "曲线图", " 时间", "价格", strsKeys, fltsValues);
            cuv2D.Fit();

            return cuv2D.CreateImage();


        }
        public string[] eve_history(string s)
        {
            string[] ss = new string[2];
            EVE_Central.DAL.Central dal = new EVE_Central.DAL.Central();
            EVE_Central.Model.Central model = new EVE_Central.Model.Central();
            EVE_Central.Model.name_en ENmodel = dal.API_definitelyStringGetModel(s);//英文匹配
            int typeid = 0;
            if (ENmodel != null)
            {
                typeid = ENmodel.typeID;
                ss[0] = ENmodel.物品名称;
            }
            else
            {
                model = dal.API_chines(s);//特征词匹配
                if (model != null)
                {
                    typeid = Convert.ToInt32(model.typeID);
                    ss[0] = model.物品名称;
                }
                else
                {
                    model = dal.API_StringGetModel(s);
                    if (model != null)
                    {
                        typeid = Convert.ToInt32(model.typeID);
                        ss[0] = model.物品名称;
                    }
                    else
                        return null;
                }
            }
            
            ss[1]= "https://www.eve-central.cn/HistoryShow.aspx?typeid=" + typeid.ToString();
            return ss;
        }
    }
}
