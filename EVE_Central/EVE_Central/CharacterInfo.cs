using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE_Central.Model
{
    /// <summary>
    /// 用户信息实体类
    /// </summary>
    [Serializable]
    public class CharacterInfo
    {
        public CharacterInfo() { }
        private string _characterID;
        private string _characterName;
        private string _race;
        private string _bloodline;
        private string _ancestry;
        private string _corporationID;
        private string _corporation;
        private string _corporationDate;
        private string _allianceID;
        private string _alliance;
        private string _allianceDate;
        private string _securityStatus;
        private List <EVE_Central.Model.corporation> _employmentHistory;
        /// <summary>
        /// 用户id
        /// </summary>
        public string characterID
        {
            set { _characterID = value; }
            get { return _characterID; }
        }
        /// <summary>
        /// 名字
        /// </summary>
        public string characterName
        {
            set { _characterName = value; }
            get { return _characterName; }
        }
        /// <summary>
        /// 民族
        /// </summary>
        public string race
        {
            set { _race = value; }
            get { return _race; }
        }
        /// <summary>
        /// 血统
        /// </summary>
        public string bloodline
        {
            set { _bloodline = value; }
            get { return _bloodline; }
        }
        /// <summary>
        /// 祖先
        /// </summary>
        public string ancestry
        {
            set { _ancestry = value; }
            get { return _ancestry; }
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
        /// 公司名
        /// </summary>
        public string corporation
        {
            set { _corporation = value; }
            get { return _corporation; }
        }
        /// <summary>
        /// 公司成立时间
        /// </summary>
        public string corporationDate
        {
            set { _corporationDate = value; }
            get { return _corporationDate; }
        }
        /// <summary>
        /// 联盟id
        /// </summary>
        public string allianceID
        {
            set { _allianceID = value; }
            get { return _allianceID; }
        }
        /// <summary>
        /// 联盟名称
        /// </summary>
        public string alliance
        {
            set { _alliance = value; }
            get { return _alliance; }
        }
    
        /// <summary>
        /// 联盟成立时间
        /// </summary>
        public string allianceDate
        {
            set { _allianceDate = value; }
            get { return _allianceDate; }
        }
        /// <summary>
        /// 安全等级
        /// </summary>
        public string securityStatus
        {
            set { _securityStatus = value; }
            get { return _securityStatus; }
        }
        /// <summary>
        /// 雇佣记录 list
        /// </summary>
        public List<EVE_Central.Model.corporation> employmentHistory
        {
            set { _employmentHistory = value; }
            get { return _employmentHistory; }
        }
        
    }
}
