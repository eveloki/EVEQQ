using System;
namespace EVE_Central.Model
{
    /// <summary>
    /// typrID:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class typrID
    {
        public typrID()
        { }
        #region Model
        private int _id;
        private int _typeid;
        private int _groupid;
        private string _name_de;
        private string _name_en;
        private string _name_fr;
        private string _name_ja;
        private string _name_ru;
        private string _name_zh;
        private int _iconid;
        private int _marketgroupid;
        private string _mass;
        private string _description_de;
        private string _description_en;
        private string _description_fr;
        private string _description_ja;
        private string _description_ru;
        private string _description_zh;
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
        public int typeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int groupID
        {
            set { _groupid = value; }
            get { return _groupid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name_de
        {
            set { _name_de = value; }
            get { return _name_de; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name_en
        {
            set { _name_en = value; }
            get { return _name_en; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name_fr
        {
            set { _name_fr = value; }
            get { return _name_fr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name_ja
        {
            set { _name_ja = value; }
            get { return _name_ja; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name_ru
        {
            set { _name_ru = value; }
            get { return _name_ru; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name_zh
        {
            set { _name_zh = value; }
            get { return _name_zh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iconID
        {
            set { _iconid = value; }
            get { return _iconid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int marketGroupID
        {
            set { _marketgroupid = value; }
            get { return _marketgroupid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mass
        {
            set { _mass = value; }
            get { return _mass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string description_de
        {
            set { _description_de = value; }
            get { return _description_de; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string description_en
        {
            set { _description_en = value; }
            get { return _description_en; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string description_fr
        {
            set { _description_fr = value; }
            get { return _description_fr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string description_ja
        {
            set { _description_ja = value; }
            get { return _description_ja; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string description_ru
        {
            set { _description_ru = value; }
            get { return _description_ru; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string description_zh
        {
            set { _description_zh = value; }
            get { return _description_zh; }
        }
        #endregion Model

    }
}

