using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EVE_Central.BLL
{
    public class ISK
    {
        /// <summary>
        /// 按照plex的购买套餐计算isk价值以及脑浆价值 默认6 数组0为plex 1为脑浆
        /// </summary>
        /// <param name="i">plex套餐 仅可用1 2 6 12 28</param>
        /// <returns></returns>
        public double[] isk(int i = 6)
        {
            double[] dou = new double[2];
            double usd = getRMBtoUSD() / 100; //获取每1usd等于多少rmb
            api api = new api();
            EVE_Central.Model.PLEX plex = new Model.PLEX(); plex.PLEX1 = 19.95; plex.PLEX2 = 34.99; plex.PLEX6 = 104.97; plex.PLEX12 = 209.94; plex.PLEX28 = 489.86;
            double plexusd = 0;
            switch (i)//每plex等于多少usd
            {
                case 1: plexusd = plex.PLEX1 / i; break;
                case 2: plexusd = plex.PLEX2 / i; break;
                case 6: plexusd = plex.PLEX6 / i; break;
                case 12: plexusd = plex.PLEX12 / i; break;
                case 28: plexusd = plex.PLEX28 / i; break;
            }
            plexusd = Math.Round(plexusd, 4);//节约资源限制小数位
            Model.marketstat markstatplex = new Model.marketstat();
            Model.marketstat markstatsk = new Model.marketstat();
            markstatplex = api.marketstat(29668); //plex
            markstatsk = api.marketstat(40520);//脑浆
            int plexe = (int)(Convert.ToDouble(markstatplex.buy_max) / 100000000); //得出plex多少e isk
            int ske = (int)(Convert.ToDouble(markstatsk.sell_min) / 100000000);//获得脑浆数据
            dou[0] = (plexusd / plexe) * usd;
            dou[1] = dou[0] * ske;
            dou[0] = Math.Round(dou[0], 3) * 10;
            dou[1] = Math.Round(dou[1], 2);
            return dou;
        }
        /// <summary>
        /// 调用聚合api获得usd汇率单位100
        /// </summary>
        /// <returns></returns>
        private double getRMBtoUSD()
        {
            EVE_Central.ConsoleAPI.ConsoleAPI api = new EVE_Central.ConsoleAPI.ConsoleAPI();
            string s = api.Main();
            double d = Convert.ToDouble(s);
            return d;
        }
        /// <summary>
        /// 高水  等迷糊词检索
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string gaosipip(string s)
        {
            int k = 0;
            int[] i = null;
            switch (s)
            {
                case "加4": case "+4": i = new int[] { 10208, 10216, 10221, 10212, 10225 }; break;
                case "加3": case "+3": i = new int[] { 9899, 9941, 9942, 9943, 9956 }; break;
                case "加5": case "+5": i = new int[] { 10209, 10217, 10222, 10213, 10226 }; break;
                case "高水": case "高级水晶": case "High-grade Crystal": i = new int[] { 20121, 20157, 20158, 20159, 20160, 20161 }; break;
                case "高蝰": case "高级蝰蛇": case "High-grade Snake": i = new int[] { 19540, 19551, 19553, 19554, 19555, 19556 }; break;
                case "高斯": case "高级斯拉夫": case "High-grade Slave": i = new int[] { 20499, 20501, 20503, 20505, 20507, 20509 }; break;
                case "高魔爪": case "高级魔爪": case "High-grade Talon": k = 31962; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "高圣杯": case "高级圣杯": case "High-grade Grail": k = 31954; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "高马刺": case "高级马刺": case "High-grade Spur": k = 31968; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "高豺狼": case "高级豺狼": case "High-grade Jackal": k = 31974; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "高统御": case "高级统御": case "High-grade Ascendancy": k = 33525; i = new int[] { 33516, k, k + 1, k + 2, k + 3, k + 4 }; break;
                case "高圣光": case "高级圣光": case "High-grade Halo": k = 20500; i = new int[] { k - 2, k, k + 2, k + 4, k + 6, k + 8 }; break;
                case "高阿斯克雷": case "高级阿斯克雷": case "High-Grade Asklepian": k = 42210; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "高护符": case "高级护符": case "High-grade Talisman": k = 19534; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "中水": case "中级水晶": case "Mid-grade Crystal": i = new int[] { 22107, 22108, 22109, 22110, 22111, 22112 }; break;
                case "中蝰": case "中级蝰蛇": case "Mid-grade Snake": i = new int[] { 22125, 22126, 22127, 22128, 22129, 22130 }; break;
                case "中斯": case "中级斯拉夫": case "Mid-grade Slave": i = new int[] { 22119, 22120, 22121, 22122, 22123, 22124 }; break;
                case "中百夫": case "中级百夫长": case "Mid-grade Centurion": k = 28790; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "中游牧": case "中级游牧者": case "Mid-grade Nomad": k = 28796; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "中圣光": case "中级圣光": case "Mid-grade Halo": k = 22113; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "中采集": case "中级采集": case "Mid-grade Harvest": k = 28802; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "中护符": case "中级护符": case "Mid-grade Talisman": k = 22121; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "中美德": case "中级美德": case "Mid-grade Virtue": k = 28808; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "中强势": case "中级强势": case "Mid-grade Edge": k = 28814; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "中统御": case "中级统御": case "Mid-grade Ascendancy": k = 33555; i = new int[] { k, k + 2, k + 4, k + 6, k + 8, k + 10 }; break;
                case "中阿斯克雷": case "中级阿斯克雷": case "Mid-Grade Asklepian": k = 42204; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "低水": case "低级水晶": case "Low-grade Crystal": i = new int[] { 33923, 33924, 33925, 33926, 33927, 33928 }; break;
                case "低蝰": case "低级蝰蛇": case "Low-grade Snake": k = 33959; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "低斯": case "低级斯拉夫": case "Low-grade Slave": k = 33953; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "低百夫": case "低级百夫长": case "Low-grade Centurion": k = 33917; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "低游牧": case "低级游牧者": case "Low-grade Nomad": k = 33947; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "低圣光": case "低级圣光": case "Low-grade Halo": k = 33935; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "低采集": case "低级采集": case "Low-grade Harvest": k = 33941; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "低护符": case "低级护符": case "Low-grade Talisman": k = 33965; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "低美德": case "低级美德": case "Low-grade Virtue": k = 33971; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "低强势": case "低级强势": case "Low-grade Edge": k = 33929; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, k + 5 }; break;
                case "低阿斯克雷": case "低级阿斯克雷": case "Low-Grade Asklepian": k = 42200; i = new int[] {42154,42156, k , k + 1, k + 2, k + 3 }; break;
                case "低魔爪": case "低级魔爪": case "Low-grade Talon": k = 32112; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, 32125 }; break;
                case "低圣杯": case "低级圣杯": case "Low-grade Grail": k = 32101; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, 32122 }; break;
                case "低马刺": case "低级马刺": case "Low-grade Spur": k = 32107; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, 32124 }; break;
                case "低豺狼": case "低级豺狼": case "Low-grade Jackal": k = 32117; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, 32123}; break;
                case "第一中文匹配": case "第二中文匹配": case "英文匹配": k = 32117; i = new int[] { k, k + 1, k + 2, k + 3, k + 4, 32123 }; break;
                default: return null;
            }
            string ss = null;
            EVE_Central.BLL.api api = new EVE_Central.BLL.api();
            EVE_Central.BLL.Central cenbll = new EVE_Central.BLL.Central();
            EVE_Central.BLL.typrID typebll = new EVE_Central.BLL.typrID();
            EVE_Central.Model.marketstat mark = new EVE_Central.Model.marketstat();
            EVE_Central.Model.cnoren ce = new EVE_Central.Model.cnoren();
            EVE_Central.Model.typrID typemodel = new EVE_Central.Model.typrID();
            int x = i.Length;
            double isk = 0;
            for (int g = 0; g < x; g++)
            {
                mark = api.marketstat(i[g]);
                isk += Convert.ToDouble(mark.sell_min);
                mark = isktom(mark, true);
                typemodel = typebll.GetModelfromtypeID(i[g]);
                ss += typemodel.name_en.Trim().Replace("\n", string.Empty)+ ":" +mark.sell_min+'\n';
            }
            isk = Math.Round(isk, 2);
            ss += "合计:" + misk(isk.ToString("0.00"));
            return ss;
        }
        /// <summary>
        /// isk 规则化
        /// </summary>
        /// <param name="mark"></param>
        /// <param name="b">是否触发isk规则转换 10e转为1b 默认不转换flase</param>
        /// <returns></returns>
        private EVE_Central.Model.marketstat isktom(EVE_Central.Model.marketstat mark, bool b = false)
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
            if (i > 9 && b) //1m
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
            if (s.Length > 9)
            {
                string k = s.Substring(0, s.Length - 7);
                double b = Convert.ToDouble(k) / 100;
                s = b.ToString() + "M ISK";
            }
            return s;


        }
    }
}
