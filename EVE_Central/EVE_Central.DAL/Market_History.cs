using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using EVE_Central.Model;
using EVE_Central.DBUtility;

namespace EVE_Central.DAL
{
    /// <summary>
    /// 数据访问类:Market_History
    /// </summary>
    public partial class Market_History
    {
        public Market_History()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Market_History");
            strSql.Append(" where id=SQL2012id");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EVE_Central.Model.Market_History model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Market_History(");
            strSql.Append("typeID,volume,orderCount,lowPrice,highPrice,avgPrice,date)");
            strSql.Append(" values (");
            strSql.Append("SQL2012typeID,SQL2012volume,SQL2012orderCount,SQL2012lowPrice,SQL2012highPrice,SQL2012avgPrice,SQL2012date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012typeID", SqlDbType.Int,4),
                    new SqlParameter("SQL2012volume", SqlDbType.BigInt,8),
                    new SqlParameter("SQL2012orderCount", SqlDbType.BigInt,8),
                    new SqlParameter("SQL2012lowPrice", SqlDbType.Float,8),
                    new SqlParameter("SQL2012highPrice", SqlDbType.Float,8),
                    new SqlParameter("SQL2012avgPrice", SqlDbType.Float,8),
                    new SqlParameter("SQL2012date", SqlDbType.DateTime)};
            parameters[0].Value = model.typeID;
            parameters[1].Value = model.volume;
            parameters[2].Value = model.orderCount;
            parameters[3].Value = model.lowPrice;
            parameters[4].Value = model.highPrice;
            parameters[5].Value = model.avgPrice;
            parameters[6].Value = model.date;

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
        public bool Update(EVE_Central.Model.Market_History model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Market_History set ");
            strSql.Append("typeID=SQL2012typeID,");
            strSql.Append("volume=SQL2012volume,");
            strSql.Append("orderCount=SQL2012orderCount,");
            strSql.Append("lowPrice=SQL2012lowPrice,");
            strSql.Append("highPrice=SQL2012highPrice,");
            strSql.Append("avgPrice=SQL2012avgPrice,");
            strSql.Append("date=SQL2012date");
            strSql.Append(" where id=SQL2012id");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012typeID", SqlDbType.Int,4),
                    new SqlParameter("SQL2012volume", SqlDbType.BigInt,8),
                    new SqlParameter("SQL2012orderCount", SqlDbType.BigInt,8),
                    new SqlParameter("SQL2012lowPrice", SqlDbType.Float,8),
                    new SqlParameter("SQL2012highPrice", SqlDbType.Float,8),
                    new SqlParameter("SQL2012avgPrice", SqlDbType.Float,8),
                    new SqlParameter("SQL2012date", SqlDbType.DateTime),
                    new SqlParameter("SQL2012id", SqlDbType.Int,4)};
            parameters[0].Value = model.typeID;
            parameters[1].Value = model.volume;
            parameters[2].Value = model.orderCount;
            parameters[3].Value = model.lowPrice;
            parameters[4].Value = model.highPrice;
            parameters[5].Value = model.avgPrice;
            parameters[6].Value = model.date;
            parameters[7].Value = model.id;

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
            strSql.Append("delete from Market_History ");
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
            strSql.Append("delete from Market_History ");
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
        public EVE_Central.Model.Market_History GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,typeID,volume,orderCount,lowPrice,highPrice,avgPrice,date from Market_History ");
            strSql.Append(" where id=SQL2012id");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            EVE_Central.Model.Market_History model = new EVE_Central.Model.Market_History();
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
        public EVE_Central.Model.Market_History DataRowToModel(DataRow row)
        {
            EVE_Central.Model.Market_History model = new EVE_Central.Model.Market_History();
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
                if (row["volume"] != null && row["volume"].ToString() != "")
                {
                    model.volume = long.Parse(row["volume"].ToString());
                }
                if (row["orderCount"] != null && row["orderCount"].ToString() != "")
                {
                    model.orderCount = long.Parse(row["orderCount"].ToString());
                }
                if (row["lowPrice"] != null && row["lowPrice"].ToString() != "")
                {
                    model.lowPrice = decimal.Parse(row["lowPrice"].ToString());
                }
                if (row["highPrice"] != null && row["highPrice"].ToString() != "")
                {
                    model.highPrice = decimal.Parse(row["highPrice"].ToString());
                }
                if (row["avgPrice"] != null && row["avgPrice"].ToString() != "")
                {
                    model.avgPrice = decimal.Parse(row["avgPrice"].ToString());
                }
                if (row["date"] != null && row["date"].ToString() != "")
                {
                    model.date = DateTime.Parse(row["date"].ToString());
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
            strSql.Append("select id,typeID,volume,orderCount,lowPrice,highPrice,avgPrice,date ");
            strSql.Append(" FROM Market_History ");
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
            strSql.Append(" id,typeID,volume,orderCount,lowPrice,highPrice,avgPrice,date ");
            strSql.Append(" FROM Market_History ");
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
            strSql.Append("select count(1) FROM Market_History ");
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
            strSql.Append(")AS Row, T.*  from Market_History T ");
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
			parameters[0].Value = "Market_History";
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

        #endregion  ExtensionMethod
    }
}

