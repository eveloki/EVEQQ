using System;
namespace EVE_Central.Model
{
    /// <summary>
    /// Market_History:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Market_History
    {
        public Market_History()
        { }
        #region Model
        private int _id;
        private int? _typeid;
        private long? _volume;
        private long? _ordercount;
        private decimal? _lowprice;
        private decimal? _highprice;
        private decimal? _avgprice;
        private DateTime? _date;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? typeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? volume
        {
            set { _volume = value; }
            get { return _volume; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? orderCount
        {
            set { _ordercount = value; }
            get { return _ordercount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? lowPrice
        {
            set { _lowprice = value; }
            get { return _lowprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? highPrice
        {
            set { _highprice = value; }
            get { return _highprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? avgPrice
        {
            set { _avgprice = value; }
            get { return _avgprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? date
        {
            set { _date = value; }
            get { return _date; }
        }
        #endregion Model

    }
}

