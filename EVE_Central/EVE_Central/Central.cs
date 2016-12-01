using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE_Central.Model
{
    /// <summary>
    /// Central:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Central
    {
        public Central()
        { }
        #region Model
        private int _id;
        private string _typeid;
        private string _物品名称;
        private string _描述;
        private string _第一市场分类;
        private string _第二市场分类;
        private string _第三市场分类;
        private string _第四市场分类;
        private string _第五市场分类;
        private string _第六市场分类;
        private string _f10;
        private string _f11;
        private string _f12;
        private string _f13;
        private string _f14;
        private string _f15;
        private string _f16;
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
        public string typeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 物品名称
        {
            set { _物品名称 = value; }
            get { return _物品名称; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 描述
        {
            set { _描述 = value; }
            get { return _描述; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 第一市场分类
        {
            set { _第一市场分类 = value; }
            get { return _第一市场分类; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 第二市场分类
        {
            set { _第二市场分类 = value; }
            get { return _第二市场分类; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 第三市场分类
        {
            set { _第三市场分类 = value; }
            get { return _第三市场分类; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 第四市场分类
        {
            set { _第四市场分类 = value; }
            get { return _第四市场分类; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 第五市场分类
        {
            set { _第五市场分类 = value; }
            get { return _第五市场分类; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 第六市场分类
        {
            set { _第六市场分类 = value; }
            get { return _第六市场分类; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F10
        {
            set { _f10 = value; }
            get { return _f10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F11
        {
            set { _f11 = value; }
            get { return _f11; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F12
        {
            set { _f12 = value; }
            get { return _f12; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F13
        {
            set { _f13 = value; }
            get { return _f13; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F14
        {
            set { _f14 = value; }
            get { return _f14; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F15
        {
            set { _f15 = value; }
            get { return _f15; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F16
        {
            set { _f16 = value; }
            get { return _f16; }
        }
        #endregion Model



    }
}
