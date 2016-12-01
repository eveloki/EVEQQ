using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE_Central.Model
{
    /// <summary>
    /// name_en实体类 专用于英文搜索
    /// </summary>
    [Serializable]
    public class name_en
    {
        public name_en()
        {
           
        }
        private int _typeID;
        private string _物品名称;
        private string _name;
        private int _marketGroupID;
        public int typeID
        {
            set { _typeID = value; }
            get { return _typeID; }
        }
        public string 物品名称
        {
            set { _物品名称 = value; }
            get { return _物品名称; }
        }
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        public int marketGroupID
        {
            set { _marketGroupID = value; }
            get { return _marketGroupID; }
        }
    }
}
