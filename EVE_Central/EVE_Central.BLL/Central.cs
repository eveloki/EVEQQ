using System;
using System.Data;
using System.Collections.Generic;
using EVE_Central.Model;
using System.Text;
using System.Data.SqlClient;

namespace EVE_Central.BLL
{
    /// <summary>
    /// Central
    /// </summary>
    public partial class Central
    {
        private readonly EVE_Central.DAL.Central dal = new EVE_Central.DAL.Central();
        public Central()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EVE_Central.Model.Central model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EVE_Central.Model.Central model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EVE_Central.Model.Central GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EVE_Central.Model.Central> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EVE_Central.Model.Central> DataTableToList(DataTable dt)
        {
            List<EVE_Central.Model.Central> modelList = new List<EVE_Central.Model.Central>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EVE_Central.Model.Central model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
      
        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 根据中文名获取物品id并返回对象实体
        /// </summary>
        /// <param name="s">中文名</param>
        /// <returns></returns>
        public Model.Central FindChineseToID(string s)
        {
            EVE_Central.Model.Central m = dal.GetIDfromChinses(s);
            if (m == null)
                return null;
            else
            return GetModel(m.id);
          
         }
        /// <summary>
        /// api专用 根据物品id获取中文和英文信息
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public Model.cnoren apifind(int typeid)
        {
            EVE_Central.Model.cnoren m = dal.APIGetModel(typeid);
            if (m == null)
                return null;
            else
                return m;
        }
        /// <summary>
        /// 根据typeid获取物品id并返回对象实体
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public Model.Central FindTypeiidToID(string s)
        {
            EVE_Central.Model.Central m = dal.GetIDfromTypeid(s);
            if (m == null)
                return null;
            else
                return GetModel(m.id);

        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="a">第一市场分类</param>
        /// <param name="b">第二市场分类</param>
        /// <param name="c">第三市场分类</param>
        /// <param name="d">第四市场分类</param>
        /// <param name="f">第五市场分类</param>
        /// <param name="g">第六市场分类</param>
        /// <returns></returns>
        public DataSet FindChineseTolist(string a,string b,string c,string d,string f,string g)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 物品列表$.id,物品列表$.typeID,物品名称,描述,第一市场分类,第二市场分类,第三市场分类,第四市场分类,第五市场分类,第六市场分类,F10,F11,F12,F13,F14,F15,F16,name_en from 物品列表$,typrID ");
            strSql.Append(" where 第一市场分类=@第一市场分类 and 第二市场分类=@第二市场分类 and 第三市场分类=@第三市场分类 and 第四市场分类=@第四市场分类 and 第五市场分类=@第五市场分类 and 第六市场分类=@第六市场分类 and typrID.typeID=物品列表$.typeID");
            SqlParameter[] parameters = {
                    new SqlParameter("@第一市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("@第二市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("@第三市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("@第四市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("@第五市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("@第六市场分类", SqlDbType.NVarChar,255)
            };
            parameters[0].Value = a;
            parameters[1].Value = b;
            parameters[2].Value = c;
            parameters[3].Value = d;
            parameters[4].Value = f;
            parameters[5].Value = g;
            return dal.GetList(strSql, parameters);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="a">第一市场分类</param>
        /// <param name="b">第二市场分类</param>
        /// <param name="c">第三市场分类</param>
        /// <param name="d">第四市场分类</param>
        /// <param name="f">第五市场分类</param>
        /// <returns></returns>
        public DataSet FindChineseTolist(string a, string b, string c, string d, string f)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 物品列表$.id,物品列表$.typeID,物品名称,描述,第一市场分类,第二市场分类,第三市场分类,第四市场分类,第五市场分类,第六市场分类,F10,F11,F12,F13,F14,F15,F16,name_en from 物品列表$,typrID ");
            strSql.Append(" where 第一市场分类=@第一市场分类 and 第二市场分类=@第二市场分类 and 第三市场分类=@第三市场分类 and 第四市场分类=@第四市场分类 and 第五市场分类=@第五市场分类 and typrID.typeID=物品列表$.typeID");
            SqlParameter[] parameters = {
                    new SqlParameter("@第一市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("@第二市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("@第三市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("@第四市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("@第五市场分类", SqlDbType.NVarChar,255)
            };
            parameters[0].Value = a;
            parameters[1].Value = b;
            parameters[2].Value = c;
            parameters[3].Value = d;
            parameters[4].Value = f;
            return dal.GetList(strSql, parameters);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="a">第一市场分类</param>
        /// <param name="b">第二市场分类</param>
        /// <param name="c">第三市场分类</param>
        /// <param name="d">第四市场分类</param>
        /// <returns></returns>
        public DataSet FindChineseTolist(string a, string b, string c, string d)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 物品列表$.id,物品列表$.typeID,物品名称,描述,第一市场分类,第二市场分类,第三市场分类,第四市场分类,第五市场分类,第六市场分类,F10,F11,F12,F13,F14,F15,F16,name_en from 物品列表$,typrID ");
            strSql.Append(" where 第一市场分类=@第一市场分类 and 第二市场分类=@第二市场分类 and 第三市场分类=@第三市场分类 and 第四市场分类=@第四市场分类 and typrID.typeID=物品列表$.typeID");
            SqlParameter[] parameters = {
                    new SqlParameter("@第一市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("@第二市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("@第三市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("@第四市场分类", SqlDbType.NVarChar,255)
            };
            parameters[0].Value = a;
            parameters[1].Value = b;
            parameters[2].Value = c;
            parameters[3].Value = d;
            return dal.GetList(strSql, parameters);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="a">第一市场分类</param>
        /// <param name="b">第二市场分类</param>
        /// <param name="c">第三市场分类</param>
        /// <returns></returns>
        public DataSet FindChineseTolist(string a, string b, string c)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 物品列表$.id,物品列表$.typeID,物品名称,描述,第一市场分类,第二市场分类,第三市场分类,第四市场分类,第五市场分类,第六市场分类,F10,F11,F12,F13,F14,F15,F16,name_en from 物品列表$,typrID ");
            strSql.Append(" where 第一市场分类=@第一市场分类 and 第二市场分类=@第二市场分类 and 第三市场分类=@第三市场分类  and typrID.typeID=物品列表$.typeID");
            SqlParameter[] parameters = {
                    new SqlParameter("@第一市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("@第二市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("@第三市场分类", SqlDbType.NVarChar,255)
            };
            parameters[0].Value = a;
            parameters[1].Value = b;
            parameters[2].Value = c;
            return dal.GetList(strSql, parameters);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="a">第一市场分类</param>
        /// <param name="b">第二市场分类</param>
        /// <returns></returns>
        public DataSet FindChineseTolist(string a, string b)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 物品列表$.id,物品列表$.typeID,物品名称,描述,第一市场分类,第二市场分类,第三市场分类,第四市场分类,第五市场分类,第六市场分类,F10,F11,F12,F13,F14,F15,F16,name_en from 物品列表$,typrID ");
            strSql.Append(" where 第一市场分类=@第一市场分类 and 第二市场分类=@第二市场分类 and typrID.typeID=物品列表$.typeID");
            SqlParameter[] parameters = {
                    new SqlParameter("@第一市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("@第二市场分类", SqlDbType.NVarChar,255)
            };
            parameters[0].Value = a;
            parameters[1].Value = b;
            return dal.GetList(strSql,parameters);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="a">第一市场分类</param>
        /// <returns></returns>
        public DataSet FindChineseTolist(string a)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 物品列表$.id,物品列表$.typeID,物品名称,描述,第一市场分类,第二市场分类,第三市场分类,第四市场分类,第五市场分类,第六市场分类,F10,F11,F12,F13,F14,F15,F16,name_en from 物品列表$,typrID ");
            strSql.Append(" where 第一市场分类=@第一市场分类 and 第二市场分类=@第二市场分类  and typrID.typeID=物品列表$.typeID");
            SqlParameter[] parameters = {
                    new SqlParameter("@第一市场分类", SqlDbType.NVarChar,255)
            };
            parameters[0].Value = a;
            return dal.GetList(strSql, parameters);
        }
        /// <summary>
        /// 联合搜索
        /// </summary>
        /// <param name="s"></param>
        /// <param name="b">是否显示非市场物品</param>
        /// <returns></returns>
        public DataSet FindTolist_like(string s,bool b=true)
        {
            StringBuilder strSql = new StringBuilder();

            if (b)
            {
                strSql.Append("select top 10 typrID.typeID,物品名称,name_en,marketGroupID from 物品列表$ right　outer join typrID on typrID.typeID = 物品列表$.typeID ");
                strSql.Append("where(物品名称 LIKE @物品名称 or name_en LIKE @name_en ) and marketGroupID != 0 ORDER BY LEN(name_en)");
            }
            else
            {
                strSql.Append("select top 10 typrID.typeID,物品名称,name_en,marketGroupID from 物品列表$,typrID ");
                strSql.Append("where(物品名称 LIKE @物品名称 or name_en LIKE @name_en ) and marketGroupID = 0 and typrID.typeID = 物品列表$.typeID ORDER BY LEN(name_en) ");
            }
            SqlParameter[] parameters = {
                    new SqlParameter("@物品名称", SqlDbType.NVarChar,255),
                    new SqlParameter("@name_en", SqlDbType.NVarChar,-1)
            };
        
            parameters[0].Value = "%" + s + "%";
            parameters[1].Value = "%" + s +"%";
            //strSql.Append("select top 10 物品列表$.typeID,物品名称,name_en,marketGroupID from 物品列表$,typrID");
            //strSql.Append(" where(物品名称 LIKE '%马克瑞%' or name_en LIKE '%马克瑞%') and marketGroupID != 0 and typrID.typeID = 物品列表$.typeID");
            //SqlParameter[] parameters = null;



            return dal.GetList(strSql, parameters);
        }
        /// <summary>
        /// 关键字搜索
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public DataSet TLB(string s)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 10 物品列表$.typeID,物品名称,name_en,marketGroupID from 物品列表$,typrID,TLB ");
            strSql.Append("where TLB.char LIKE @物品名称 and typrID.typeID = 物品列表$.typeID and 物品列表$.typeID =TLB.typeid");
            SqlParameter[] parameters = {
                    new SqlParameter("@物品名称", SqlDbType.NVarChar,255)
            };
            s = "%" + s + "%";
            parameters[0].Value = s;
            return dal.GetList(strSql, parameters);

        }
        #endregion  ExtensionMethod
    }
}

