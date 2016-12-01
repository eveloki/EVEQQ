using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE_Central.Model
{
    /// <summary>
    /// 中文 英文物品数据 实体类
    /// </summary>
    [Serializable]
    public class cnoren
    {
        public cnoren()
        { }
        private int _typeid;
        private string _cn;
        private string _en;
        private string _mcn;
        private string _men;
        /// <summary>
        /// 物品id
        /// </summary>
        public int typeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 中文
        /// </summary>
        public string cn
        {
            set { _cn = value; }
            get { return _cn; }
        }
        /// <summary>
        /// 英文
        /// </summary>
        public string en
        {
            set { _en = value; }
            get { return _en; }
        }
        /// <summary>
        /// 中文描述
        /// </summary>
        public string mcn
        {
            set { _mcn = value; }
            get { return _mcn; }
        }
        /// <summary>
        /// 英文描述
        /// </summary>
        public string men
        {
            set { _men = value; }
            get { return _men; }
        }
    }
}
