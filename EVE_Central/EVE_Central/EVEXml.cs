using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE_Central.Model
{
    [Serializable]
    public class EVEXml
    {
        public EVEXml()
        {
        }
        private string _id;
        private string _region;
        private string _station;
        private string _station_name;
        private string _security;
        private string _range;
        private string _price;
        private string _vol_remain;
        private string _min_volume;
        private string _expires;
        private string _reported_time;
        /// <summary>
        /// 订单id
        /// </summary>
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 区域id
        /// </summary>
        public string region
        {
            set { _region = value; }
            get { return _region; }
        }
        /// <summary>
        /// 空间站id
        /// </summary>
        public string station
        {
            set { _station = value; }
            get { return _station; }
        }
        /// <summary>
        /// 空间站名
        /// </summary>
        public string station_name
        {
            set { _station_name = value; }
            get { return _station_name; }
        }
        /// <summary>
        /// 星系安等
        /// </summary>
        public string security
        {
            set { _security = value; }
            get { return _security; }
        }
        /// <summary>
        /// 空间站交互范围/订单有效覆盖范围
        /// </summary>
        public string range
        {
            set { _range = value; }
            get { return _range; }
        }
        /// <summary>
        /// 价格
        /// </summary>
        public string price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        ///剩余数量
        /// </summary>
        public string vol_remain
        {
            set { _vol_remain = value; }
            get { return _vol_remain; }
        }
        /// <summary>
        /// 体积/立方米
        /// </summary>
        public string min_volume
        {
            set { _min_volume = value; }
            get { return _min_volume; }
        }
        /// <summary>
        /// 到期时间
        /// </summary>
        public string expires
        {
            set { _expires = value; }
            get { return _expires; }
        }
        /// <summary>
        /// 订单报单时间
        /// </summary>
        
        public string reported_time
        {
            set { _reported_time = value; }
            get { return _reported_time; }
        }
    }
}
