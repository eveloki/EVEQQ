using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE_Central.Model
{
    /// <summary>
    /// 虫洞信息
    /// </summary>
    public class eve_scout
    {
        public int id { get; set; }
        /// <summary>
        /// 信号名称
        /// </summary>
        public string signatureId { get; set; }
        /// <summary>
        /// 信号类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 信号状态 已扫描 /未扫描
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 洞口质量 稳定（至少有50%以上剩余质量）
        /// </summary>
        public string wormholeMass { get; set; }
        /// <summary>
        /// 洞口剩余时间：快塌了。。
        /// </summary>
        public string wormholeEol { get; set; }
        /// <summary>
        /// 坍塌时间
        /// </summary>
        public string wormholeEstimatedEol { get; set; }
        /// <summary>
        /// 目标虫洞类型
        /// </summary>
        public string wormholeDestinationSignatureId { get; set; }
        /// <summary>
        /// 虫洞生成时间
        /// </summary>
        public string createdAt { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public string updatedAt { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public string deletedAt { get; set; }
        /// <summary>
        /// 状态更新时间
        /// </summary>
        public string statusUpdatedAt { get; set; }
        /// <summary>
        /// 上传人
        /// </summary>
        public string createdBy { get; set; }
        /// <summary>
        /// 上传id
        /// </summary>
        public string createdById { get; set; }
        /// <summary>
        /// 删除人
        /// </summary>
        public string deletedBy { get; set; }
        /// <summary>
        /// 删除id
        /// </summary>
        public string deletedById { get; set; }
        /// <summary>
        /// 虫洞源头id
        /// </summary>
        public int wormholeSourceWormholeTypeId { get; set; }
        /// <summary>
        /// 虫洞目标id
        /// </summary>
        public int wormholeDestinationWormholeTypeId { get; set; }
        /// <summary>
        /// 星系id
        /// </summary>
        public int solarSystemId { get; set; }
        /// <summary>
        /// 目标星系id
        /// </summary>
        public int wormholeDestinationSolarSystemId { get; set; }
        /// <summary>
        /// 源虫洞类型
        /// </summary>
        public sourceWormholeType sourceWormholeType { get; set; }
        /// <summary>
        /// 出口虫洞类型
        /// </summary>
        public destinationWormholeType destinationWormholeType { get; set; }
        /// <summary>
        /// 源星系
        /// </summary>
        public sourceSolarSystem sourceSolarSystem { get; set; }
        /// <summary>
        /// 出口星系
        /// </summary>
        public destinationSolarSystem destinationSolarSystem { get; set; }
        /// <summary>
        /// 跳跃数量
        /// </summary>
        public int jumps { get; set; }
        /// <summary>
        /// 光年距离
        /// </summary>
        public double lightyears { get; set; }
    }
    /// <summary>
    /// 源虫洞类型
    /// </summary>
    public class sourceWormholeType
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 来源虫洞
        /// </summary>
        public string src { get; set; }
        /// <summary>
        /// 可能通往
        /// </summary>
        public string dest { get; set; }
        /// <summary>
        /// 存在时间
        /// </summary>
        public int lifetime { get; set; }
        /// <summary>
        /// 最大通过质量
        /// </summary>
        public int djumpMass { get; set; }
        /// <summary>
        /// 总通过质量
        /// </summary>
        public int maxMass { get; set; }

    }
    /// <summary>
    /// 出口虫洞类型
    /// </summary>
    public class destinationWormholeType
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 来源虫洞
        /// </summary>
        public string src { get; set; }
        /// <summary>
        /// 可能通往
        /// </summary>
        public string dest { get; set; }
        /// <summary>
        /// 存在时间
        /// </summary>
        public int lifetime { get; set; }
        /// <summary>
        /// 最大通过质量
        /// </summary>
        public int djumpMass { get; set; }
        /// <summary>
        /// 总通过质量
        /// </summary>
        public int maxMass { get; set; }

    }
    /// <summary>
    /// 源星系
    /// </summary>
    public class sourceSolarSystem
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 星座id
        /// </summary>
        public int constellationID { get; set; }
        /// <summary>
        /// 安全等级
        /// </summary>
        public double security { get; set; }
        /// <summary>
        /// 星域id
        /// </summary>
        public int regionId { get; set; }
        /// <summary>
        /// 星域信息
        /// </summary>
        public region region { get; set; }

    }

    /// <summary>
    /// 出口星系
    /// </summary>
    public class destinationSolarSystem
    {   /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 星座id
        /// </summary>
        public int constellationID { get; set; }
        /// <summary>
        /// 安全等级
        /// </summary>
        public double security { get; set; }
        /// <summary>
        /// 星域id
        /// </summary>
        public int regionId { get; set; }
        /// <summary>
        /// 星域信息
        /// </summary>
        public region region { get; set; }

    }
    /// <summary>
    /// 星域信息
    /// </summary>
    public class region
    {
        /// <summary>
        /// 星域id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 星域名称
        /// </summary>
        public string name { get; set; }
    }
}
