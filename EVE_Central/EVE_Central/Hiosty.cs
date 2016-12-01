using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE_Central.Model
{
    /// <summary>
    /// esi api 市场历史记录
    /// </summary>
    public class Hiosty
    {
        public double lowest { get; set; }
        public double highest { get; set; }
        public string date { get; set; }
        public double average { get; set; }
        public long volume { get; set; }
        public long order_count { get; set; }
    }
}
