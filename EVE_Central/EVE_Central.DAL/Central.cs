using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using EVE_Central.Model;
using EVE_Central.DBUtility;

namespace EVE_Central.DAL
{
    /// <summary>
    /// 数据访问类:Central
    /// </summary>
    public partial class Central
    {
        public Central()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EVE_Central.Model.Central model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 物品列表$(");
            strSql.Append("typeID,物品名称,描述,第一市场分类,第二市场分类,第三市场分类,第四市场分类,第五市场分类,第六市场分类,F10,F11,F12,F13,F14,F15,F16)");
            strSql.Append(" values (");
            strSql.Append("SQL2012typeID,SQL2012物品名称,SQL2012描述,SQL2012第一市场分类,SQL2012第二市场分类,SQL2012第三市场分类,SQL2012第四市场分类,SQL2012第五市场分类,SQL2012第六市场分类,SQL2012F10,SQL2012F11,SQL2012F12,SQL2012F13,SQL2012F14,SQL2012F15,SQL2012F16)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012typeID", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012物品名称", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012描述", SqlDbType.NVarChar,-1),
                    new SqlParameter("SQL2012第一市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012第二市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012第三市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012第四市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012第五市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012第六市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012F10", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012F11", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012F12", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012F13", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012F14", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012F15", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012F16", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.typeID;
            parameters[1].Value = model.物品名称;
            parameters[2].Value = model.描述;
            parameters[3].Value = model.第一市场分类;
            parameters[4].Value = model.第二市场分类;
            parameters[5].Value = model.第三市场分类;
            parameters[6].Value = model.第四市场分类;
            parameters[7].Value = model.第五市场分类;
            parameters[8].Value = model.第六市场分类;
            parameters[9].Value = model.F10;
            parameters[10].Value = model.F11;
            parameters[11].Value = model.F12;
            parameters[12].Value = model.F13;
            parameters[13].Value = model.F14;
            parameters[14].Value = model.F15;
            parameters[15].Value = model.F16;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EVE_Central.Model.Central model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 物品列表$ set ");
            strSql.Append("typeID=SQL2012typeID,");
            strSql.Append("物品名称=SQL2012物品名称,");
            strSql.Append("描述=SQL2012描述,");
            strSql.Append("第一市场分类=SQL2012第一市场分类,");
            strSql.Append("第二市场分类=SQL2012第二市场分类,");
            strSql.Append("第三市场分类=SQL2012第三市场分类,");
            strSql.Append("第四市场分类=SQL2012第四市场分类,");
            strSql.Append("第五市场分类=SQL2012第五市场分类,");
            strSql.Append("第六市场分类=SQL2012第六市场分类,");
            strSql.Append("F10=SQL2012F10,");
            strSql.Append("F11=SQL2012F11,");
            strSql.Append("F12=SQL2012F12,");
            strSql.Append("F13=SQL2012F13,");
            strSql.Append("F14=SQL2012F14,");
            strSql.Append("F15=SQL2012F15,");
            strSql.Append("F16=SQL2012F16");
            strSql.Append(" where id=SQL2012id");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012typeID", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012物品名称", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012描述", SqlDbType.NVarChar,-1),
                    new SqlParameter("SQL2012第一市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012第二市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012第三市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012第四市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012第五市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012第六市场分类", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012F10", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012F11", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012F12", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012F13", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012F14", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012F15", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012F16", SqlDbType.NVarChar,255),
                    new SqlParameter("SQL2012id", SqlDbType.Int,4)};
            parameters[0].Value = model.typeID;
            parameters[1].Value = model.物品名称;
            parameters[2].Value = model.描述;
            parameters[3].Value = model.第一市场分类;
            parameters[4].Value = model.第二市场分类;
            parameters[5].Value = model.第三市场分类;
            parameters[6].Value = model.第四市场分类;
            parameters[7].Value = model.第五市场分类;
            parameters[8].Value = model.第六市场分类;
            parameters[9].Value = model.F10;
            parameters[10].Value = model.F11;
            parameters[11].Value = model.F12;
            parameters[12].Value = model.F13;
            parameters[13].Value = model.F14;
            parameters[14].Value = model.F15;
            parameters[15].Value = model.F16;
            parameters[16].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 物品列表$ ");
            strSql.Append(" where id=SQL2012id");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 物品列表$ ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EVE_Central.Model.Central GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,typeID,物品名称,描述,第一市场分类,第二市场分类,第三市场分类,第四市场分类,第五市场分类,第六市场分类,F10,F11,F12,F13,F14,F15,F16 from 物品列表$ ");
            strSql.Append(" where id=@SQL2012id");
            SqlParameter[] parameters = {
                    new SqlParameter("@SQL2012id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            EVE_Central.Model.Central model = new EVE_Central.Model.Central();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// api模糊检索中文专用
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public EVE_Central.Model.Central API_chines(string s)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from 物品列表$,typrID,TLB ");
            strSql.Append("where TLB.char LIKE @物品名称 and typrID.typeID = 物品列表$.typeID and 物品列表$.typeID =TLB.typeid");
            SqlParameter[] parameters = {
                    new SqlParameter("@物品名称", SqlDbType.NVarChar,255)
            };
            s = "%" + s + "%";
            parameters[0].Value = s;
            EVE_Central.Model.Central model = new EVE_Central.Model.Central();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EVE_Central.Model.Central DataRowToModel(DataRow row)
        {
            EVE_Central.Model.Central model = new EVE_Central.Model.Central();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["typeID"] != null)
                {
                    model.typeID = row["typeID"].ToString();
                }
                if (row["物品名称"] != null)
                {
                    model.物品名称 = row["物品名称"].ToString();
                }
                if (row["描述"] != null)
                {
                    model.描述 = row["描述"].ToString();
                }
                if (row["第一市场分类"] != null)
                {
                    model.第一市场分类 = row["第一市场分类"].ToString();
                }
                if (row["第二市场分类"] != null)
                {
                    model.第二市场分类 = row["第二市场分类"].ToString();
                }
                if (row["第三市场分类"] != null)
                {
                    model.第三市场分类 = row["第三市场分类"].ToString();
                }
                if (row["第四市场分类"] != null)
                {
                    model.第四市场分类 = row["第四市场分类"].ToString();
                }
                if (row["第五市场分类"] != null)
                {
                    model.第五市场分类 = row["第五市场分类"].ToString();
                }
                if (row["第六市场分类"] != null)
                {
                    model.第六市场分类 = row["第六市场分类"].ToString();
                }
                if (row["F10"] != null)
                {
                    model.F10 = row["F10"].ToString();
                }
                if (row["F11"] != null)
                {
                    model.F11 = row["F11"].ToString();
                }
                if (row["F12"] != null)
                {
                    model.F12 = row["F12"].ToString();
                }
                if (row["F13"] != null)
                {
                    model.F13 = row["F13"].ToString();
                }
                if (row["F14"] != null)
                {
                    model.F14 = row["F14"].ToString();
                }
                if (row["F15"] != null)
                {
                    model.F15 = row["F15"].ToString();
                }
                if (row["F16"] != null)
                {
                    model.F16 = row["F16"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,typeID,物品名称,描述,第一市场分类,第二市场分类,第三市场分类,第四市场分类,第五市场分类,第六市场分类,F10,F11,F12,F13,F14,F15,F16 ");
            strSql.Append(" FROM 物品列表$ ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="parameters">parameters对象</param>
        /// <returns></returns>
        public DataSet GetList(StringBuilder strSql, SqlParameter[] parameters)
        {
            return DbHelperSQL.Query(strSql.ToString(), parameters);

        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,typeID,物品名称,描述,第一市场分类,第二市场分类,第三市场分类,第四市场分类,第五市场分类,第六市场分类,F10,F11,F12,F13,F14,F15,F16 ");
            strSql.Append(" FROM 物品列表$ ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM 物品列表$ ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from 物品列表$ T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012tblName", SqlDbType.VarChar, 255),
					new SqlParameter("SQL2012fldName", SqlDbType.VarChar, 255),
					new SqlParameter("SQL2012PageSize", SqlDbType.Int),
					new SqlParameter("SQL2012PageIndex", SqlDbType.Int),
					new SqlParameter("SQL2012IsReCount", SqlDbType.Bit),
					new SqlParameter("SQL2012OrderType", SqlDbType.Bit),
					new SqlParameter("SQL2012strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "物品列表$";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获取实体对象来自于中文名
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public EVE_Central.Model.Central GetIDfromChinses(string s)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,typeID,物品名称,描述,第一市场分类,第二市场分类,第三市场分类,第四市场分类,第五市场分类,第六市场分类,F10,F11,F12,F13,F14,F15,F16 from 物品列表$ ");
            strSql.Append(" where 物品名称=@s");
            SqlParameter[] parameters = {
                    new SqlParameter("@s", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = s;

            EVE_Central.Model.Central model = new EVE_Central.Model.Central();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取实体对象来自于Typeid
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public EVE_Central.Model.Central GetIDfromTypeid(string s)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,typeID,物品名称,描述,第一市场分类,第二市场分类,第三市场分类,第四市场分类,第五市场分类,第六市场分类,F10,F11,F12,F13,F14,F15,F16 from 物品列表$ ");
            strSql.Append(" where typeID=@s");
            SqlParameter[] parameters = {
                    new SqlParameter("@s", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = s;

            EVE_Central.Model.Central model = new EVE_Central.Model.Central();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体 api用
        /// </summary>
        public EVE_Central.Model.cnoren APIGetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 物品列表$.typeID,物品名称,描述,name_en,typrID.description_en from 物品列表$,typrID");
            strSql.Append(" where typrID.typeID=@SQL2012id and typrID.typeID=物品列表$.typeID");
            SqlParameter[] parameters = {
                    new SqlParameter("@SQL2012id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return APIDataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// api专用
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public EVE_Central.Model.cnoren APIDataRowToModel(DataRow row)
        {
            EVE_Central.Model.cnoren model = new EVE_Central.Model.cnoren();
            if (row != null)
            {
                if (row["typeID"] != null && row["typeID"].ToString() != "")
                {
                    model.typeID = int.Parse(row["typeID"].ToString());
                }
                if (row["物品名称"] != null)
                {
                    model.cn = row["物品名称"].ToString();
                }
                if (row["name_en"] != null)
                {
                    model.en = row["name_en"].ToString();
                }
                if (row["描述"] != null)
                {
                    model.mcn = row["描述"].ToString();
                }
                if (row["description_en"] != null)
                {
                    model.men = row["description_en"].ToString();
                }
            }

            return model;

        }
        /// <summary>
        /// api模糊联合搜索
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public EVE_Central.Model.Central API_StringGetModel(string s)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 物品列表$.id,物品列表$.typeID,物品名称,描述,第一市场分类,第二市场分类,第三市场分类,第四市场分类,第五市场分类,第六市场分类,F10,F11,F12,F13,F14,F15,F16 from 物品列表$,typrID ");
            //strSql.Append("select top 1 * from 物品列表$,typrID ");
            strSql.Append("where(物品名称 LIKE @物品名称 or name_en LIKE @name_en ) and marketGroupID != 0 and typrID.typeID = 物品列表$.typeID ORDER BY LEN(物品名称)");
            SqlParameter[] parameters = {
                    new SqlParameter("@物品名称", SqlDbType.NVarChar,255),
                    new SqlParameter("@name_en", SqlDbType.NVarChar,-1)
            };
            s = "%" + s + "%";
            parameters[0].Value = s;
            parameters[1].Value = s;

            EVE_Central.Model.Central model = new EVE_Central.Model.Central();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 精确匹配英文
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public EVE_Central.Model.name_en API_definitelyStringGetModel(string s)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 typrID.typeID,物品名称,name_en,marketGroupID from 物品列表$ right outer join typrID on typrID.typeID = 物品列表$.typeID ");
            //strSql.Append("select top 1 * from 物品列表$,typrID ");
            strSql.Append("where name_en like @name_en");
            SqlParameter[] parameters = {
                    new SqlParameter("@name_en", SqlDbType.NVarChar,-1)
            };
            parameters[0].Value = s+ '_';

            EVE_Central.Model.Central model = new EVE_Central.Model.Central();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ENDataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 英文匹配
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public EVE_Central.Model.name_en ENDataRowToModel(DataRow row)
        {
            EVE_Central.Model.name_en model = new EVE_Central.Model.name_en();
            if (row != null)
            {
                if (row["typeID"] != null && row["typeID"].ToString() != "")
                {
                    model.typeID = int.Parse(row["typeID"].ToString());
                }
                if (row["物品名称"] != null)
                {
                    model.物品名称 = row["物品名称"].ToString();
                }
                if (row["name_en"] != null)
                {
                    model.name = row["name_en"].ToString();
                }
                if (row["marketGroupID"] != null && row["marketGroupID"].ToString() != "")
                {
                    model.marketGroupID = int.Parse(row["marketGroupID"].ToString());
                }
            }
            return model;
        }
        #endregion  ExtensionMethod
    }
}

