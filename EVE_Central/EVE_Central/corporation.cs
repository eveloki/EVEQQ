using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE_Central.Model
{
    /// <summary>
    /// eve雇佣记录实体类
    /// </summary>
    [Serializable]
    public class corporation
    {
        public corporation()
        { }
        private string _recordID;
        private string _corporationID;
        private string _corporationNam;
        private string _startDate;
        /// <summary>
        /// 记录id 
        /// </summary>
        public string recordID
        {
            set { _recordID = value; }
            get { return _recordID; }
        }
        /// <summary>
        /// 公司id
        /// </summary>
        public string corporationID
        {
            set { _corporationID = value; }
            get { return _corporationID; }
        }
        /// <summary>
        /// 公司名字
        /// </summary>
        public string corporationNam
        {
            set { _corporationNam = value; }
            get { return _corporationNam; }
        }
        /// <summary>
        /// 进入军团时间
        /// </summary>
        public string startDate
        {
            set { _startDate = value; }
            get { return _startDate; }
        }
    }
}
