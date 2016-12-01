
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using EVE_Central.DBUtility;//Please add references
namespace EVE_Central.DAL
{
    /// <summary>
    /// 数据访问类:typrID
    /// </summary>
    public partial class typrID
    {
        public typrID()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from typrID");
            strSql.Append(" where id=SQL2012id ");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012id", SqlDbType.Int,4)          };
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EVE_Central.Model.typrID model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into typrID(");
            strSql.Append("typeID,groupID,name_de,name_en,name_fr,name_ja,name_ru,name_zh,iconID,marketGroupID,mass,description_de,description_en,description_fr,description_ja,description_ru,description_zh)");
            strSql.Append(" values (");
            strSql.Append("@SQL2012typeID,@SQL2012groupID,@SQL2012name_de,@SQL2012name_en,@SQL2012name_fr,@SQL2012name_ja,@SQL2012name_ru,@SQL2012name_zh,@SQL2012iconID,@SQL2012marketGroupID,@SQL2012mass,@SQL2012description_de,@SQL2012description_en,@SQL2012description_fr,@SQL2012description_ja,@SQL2012description_ru,@SQL2012description_zh)");
            SqlParameter[] parameters = {
                    new SqlParameter("@SQL2012typeID", SqlDbType.Int,4),
                    new SqlParameter("@SQL2012groupID", SqlDbType.Int,4),
                    new SqlParameter("@SQL2012name_de", SqlDbType.NVarChar,-1),
                    new SqlParameter("@SQL2012name_en", SqlDbType.NVarChar,-1),
                    new SqlParameter("@SQL2012name_fr", SqlDbType.NVarChar,-1),
                    new SqlParameter("@SQL2012name_ja", SqlDbType.NVarChar,-1),
                    new SqlParameter("@SQL2012name_ru", SqlDbType.NVarChar,-1),
                    new SqlParameter("@SQL2012name_zh", SqlDbType.NVarChar,-1),
                    new SqlParameter("@SQL2012iconID", SqlDbType.Int,4),
                    new SqlParameter("@SQL2012marketGroupID", SqlDbType.Int,4),
                    new SqlParameter("@SQL2012mass", SqlDbType.NVarChar,50),
                    new SqlParameter("@SQL2012description_de", SqlDbType.NVarChar,-1),
                    new SqlParameter("@SQL2012description_en", SqlDbType.NVarChar,-1),
                    new SqlParameter("@SQL2012description_fr", SqlDbType.NVarChar,-1),
                    new SqlParameter("@SQL2012description_ja", SqlDbType.NVarChar,-1),
                    new SqlParameter("@SQL2012description_ru", SqlDbType.NVarChar,-1),
                    new SqlParameter("SQL2012description_zh", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.typeID;
            parameters[1].Value = model.groupID;
            parameters[2].Value = model.name_de;
            parameters[3].Value = model.name_en;
            parameters[4].Value = model.name_fr;
            parameters[5].Value = model.name_ja;
            parameters[6].Value = model.name_ru;
            parameters[7].Value = model.name_zh;
            parameters[8].Value = model.iconID;
            parameters[9].Value = model.marketGroupID;
            parameters[10].Value = model.mass;
            parameters[11].Value = model.description_de;
            parameters[12].Value = model.description_en;
            parameters[13].Value = model.description_fr;
            parameters[14].Value = model.description_ja;
            parameters[15].Value = model.description_ru;
            parameters[16].Value = model.description_zh;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(EVE_Central.Model.typrID model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update typrID set ");
            strSql.Append("id=SQL2012id,");
            strSql.Append("typeID=SQL2012typeID,");
            strSql.Append("groupID=SQL2012groupID,");
            strSql.Append("name_de=SQL2012name_de,");
            strSql.Append("name_en=SQL2012name_en,");
            strSql.Append("name_fr=SQL2012name_fr,");
            strSql.Append("name_ja=SQL2012name_ja,");
            strSql.Append("name_ru=SQL2012name_ru,");
            strSql.Append("name_zh=SQL2012name_zh,");
            strSql.Append("iconID=SQL2012iconID,");
            strSql.Append("marketGroupID=SQL2012marketGroupID,");
            strSql.Append("mass=SQL2012mass,");
            strSql.Append("description_de=SQL2012description_de,");
            strSql.Append("description_en=SQL2012description_en,");
            strSql.Append("description_fr=SQL2012description_fr,");
            strSql.Append("description_ja=SQL2012description_ja,");
            strSql.Append("description_ru=SQL2012description_ru,");
            strSql.Append("description_zh=SQL2012description_zh");
            strSql.Append(" where id=SQL2012id ");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012id", SqlDbType.Int,4),
                    new SqlParameter("SQL2012typeID", SqlDbType.Int,4),
                    new SqlParameter("SQL2012groupID", SqlDbType.Int,4),
                    new SqlParameter("SQL2012name_de", SqlDbType.NVarChar,-1),
                    new SqlParameter("SQL2012name_en", SqlDbType.NVarChar,-1),
                    new SqlParameter("SQL2012name_fr", SqlDbType.NVarChar,-1),
                    new SqlParameter("SQL2012name_ja", SqlDbType.NVarChar,-1),
                    new SqlParameter("SQL2012name_ru", SqlDbType.NVarChar,-1),
                    new SqlParameter("SQL2012name_zh", SqlDbType.NVarChar,-1),
                    new SqlParameter("SQL2012iconID", SqlDbType.Int,4),
                    new SqlParameter("SQL2012marketGroupID", SqlDbType.Int,4),
                    new SqlParameter("SQL2012mass", SqlDbType.NVarChar,50),
                    new SqlParameter("SQL2012description_de", SqlDbType.NVarChar,-1),
                    new SqlParameter("SQL2012description_en", SqlDbType.NVarChar,-1),
                    new SqlParameter("SQL2012description_fr", SqlDbType.NVarChar,-1),
                    new SqlParameter("SQL2012description_ja", SqlDbType.NVarChar,-1),
                    new SqlParameter("SQL2012description_ru", SqlDbType.NVarChar,-1),
                    new SqlParameter("SQL2012description_zh", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.typeID;
            parameters[2].Value = model.groupID;
            parameters[3].Value = model.name_de;
            parameters[4].Value = model.name_en;
            parameters[5].Value = model.name_fr;
            parameters[6].Value = model.name_ja;
            parameters[7].Value = model.name_ru;
            parameters[8].Value = model.name_zh;
            parameters[9].Value = model.iconID;
            parameters[10].Value = model.marketGroupID;
            parameters[11].Value = model.mass;
            parameters[12].Value = model.description_de;
            parameters[13].Value = model.description_en;
            parameters[14].Value = model.description_fr;
            parameters[15].Value = model.description_ja;
            parameters[16].Value = model.description_ru;
            parameters[17].Value = model.description_zh;

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
            strSql.Append("delete from typrID ");
            strSql.Append(" where id=@SQL2012id ");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012id", SqlDbType.Int,4)          };
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
            strSql.Append("delete from typrID ");
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
        public EVE_Central.Model.typrID GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,typeID,groupID,name_de,name_en,name_fr,name_ja,name_ru,name_zh,iconID,marketGroupID,mass,description_de,description_en,description_fr,description_ja,description_ru,description_zh from typrID ");
            strSql.Append(" where id=@SQL2012id ");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012id", SqlDbType.Int,4)          };
            parameters[0].Value = id;

            EVE_Central.Model.typrID model = new EVE_Central.Model.typrID();
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
        public EVE_Central.Model.typrID DataRowToModel(DataRow row)
        {
            EVE_Central.Model.typrID model = new EVE_Central.Model.typrID();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["typeID"] != null && row["typeID"].ToString() != "")
                {
                    model.typeID = int.Parse(row["typeID"].ToString());
                }
                if (row["groupID"] != null && row["groupID"].ToString() != "")
                {
                    model.groupID = int.Parse(row["groupID"].ToString());
                }
                if (row["name_de"] != null)
                {
                    model.name_de = row["name_de"].ToString();
                }
                if (row["name_en"] != null)
                {
                    model.name_en = row["name_en"].ToString();
                }
                if (row["name_fr"] != null)
                {
                    model.name_fr = row["name_fr"].ToString();
                }
                if (row["name_ja"] != null)
                {
                    model.name_ja = row["name_ja"].ToString();
                }
                if (row["name_ru"] != null)
                {
                    model.name_ru = row["name_ru"].ToString();
                }
                if (row["name_zh"] != null)
                {
                    model.name_zh = row["name_zh"].ToString();
                }
                if (row["iconID"] != null && row["iconID"].ToString() != "")
                {
                    model.iconID = int.Parse(row["iconID"].ToString());
                }
                if (row["marketGroupID"] != null && row["marketGroupID"].ToString() != "")
                {
                    model.marketGroupID = int.Parse(row["marketGroupID"].ToString());
                }
                if (row["mass"] != null)
                {
                    model.mass = row["mass"].ToString();
                }
                if (row["description_de"] != null)
                {
                    model.description_de = row["description_de"].ToString();
                }
                if (row["description_en"] != null)
                {
                    model.description_en = row["description_en"].ToString();
                }
                if (row["description_fr"] != null)
                {
                    model.description_fr = row["description_fr"].ToString();
                }
                if (row["description_ja"] != null)
                {
                    model.description_ja = row["description_ja"].ToString();
                }
                if (row["description_ru"] != null)
                {
                    model.description_ru = row["description_ru"].ToString();
                }
                if (row["description_zh"] != null)
                {
                    model.description_zh = row["description_zh"].ToString();
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
            strSql.Append("select id,typeID,groupID,name_de,name_en,name_fr,name_ja,name_ru,name_zh,iconID,marketGroupID,mass,description_de,description_en,description_fr,description_ja,description_ru,description_zh ");
            strSql.Append(" FROM typrID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" id,typeID,groupID,name_de,name_en,name_fr,name_ja,name_ru,name_zh,iconID,marketGroupID,mass,description_de,description_en,description_fr,description_ja,description_ru,description_zh ");
            strSql.Append(" FROM typrID ");
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
            strSql.Append("select count(1) FROM typrID ");
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
            strSql.Append(")AS Row, T.*  from typrID T ");
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
			parameters[0].Value = "typrID";
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
        public EVE_Central.Model.typrID GetModelfromtypeID(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,typeID,groupID,name_de,name_en,name_fr,name_ja,name_ru,name_zh,iconID,marketGroupID,mass,description_de,description_en,description_fr,description_ja,description_ru,description_zh from typrID ");
            strSql.Append(" where typeid=@SQL2012id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@SQL2012id", SqlDbType.Int,4)          };
            parameters[0].Value = id;

            EVE_Central.Model.typrID model = new EVE_Central.Model.typrID();
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
        #endregion  ExtensionMethod
    }
}

