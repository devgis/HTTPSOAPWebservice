using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace HongFengShu.WSLib.COMMON
{
    public static class SQLServerHelper
    {
        private static SqlConnection SqlConn;
        static SQLServerHelper()
        {
            if (SqlConn == null)
            {
                SqlConn = new SqlConnection();
                SqlConn.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["SqlStr"].ToString();
            }
        }
        //public static string connectionString = "Data Source=" + ostr + ";Persist Security Info=True;User ID=" + ustr + ";Password=" + pstr + ";Unicode=True;Pooling=true;Min Pool Size=50;Max Pool Size=500;Connection Lifetime=1;";   //Connection Lifetime=10000;

        public static SqlDataReader GetDataReader(string sql)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = sql;
                sqlCmd.Connection = SqlConn;
                SqlDataReader sqlDr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                sqlDr.Read();
                return sqlDr;
            }
            catch (Exception ex)
            {
                Loger.WriteLog(ex);
                throw ex;
            }
        }

        public static DataSet GetDataTable(string sql,SqlParameter[] parameters)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = sql;
                sqlCmd.Parameters.AddRange(parameters);
                sqlCmd.Connection = SqlConn;

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                Loger.WriteLog(ex);
                throw ex;
            }
            finally
            {
                SqlConn.Close();
            }
        }

        public static DataSet GetDataTable(string sql)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = sql;
                sqlCmd.Connection = SqlConn;

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                Loger.WriteLog(ex);
                throw ex;
            }
            finally
            {
                SqlConn.Close();
            }
        }

        public static int ExecSql(string sql)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = sql;
                sqlCmd.Connection = SqlConn;
                int i = sqlCmd.ExecuteNonQuery();
                return i;
            }
            catch (Exception ex)
            {
                Loger.WriteLog(ex);
                throw ex;
            }
            finally
            {
                SqlConn.Close();
            }
        }

        public static int ExecSql(string sql, SqlParameter[] parameters)
        {
            try
            {
                SqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = sql;
                sqlCmd.Parameters.AddRange(parameters);
                sqlCmd.Connection = SqlConn;
                int i = sqlCmd.ExecuteNonQuery();
                return i;
            }
            catch (Exception ex)
            {
                Loger.WriteLog(ex);
                throw ex;
            }
            finally
            {
                SqlConn.Close();
            }
        }

        public static bool ExecSqlByTran(List<string> listsqls, List<SqlParameter[]> listparameters)
        {
            if (listsqls == null || listparameters == null || listsqls.Count <= 0 || listparameters.Count <= 0 || listsqls.Count != listparameters.Count)
            {
                return false;
            }
            else
            {
                
                SqlConn.Open();
                SqlTransaction tran = SqlConn.BeginTransaction();
                try
                {
                    for (int i = 0; i < listsqls.Count; i++)
                    {
                        SqlCommand sqlCmd = new SqlCommand();
                        sqlCmd.CommandText = listsqls[i];
                        sqlCmd.Parameters.AddRange(listparameters[i]);
                        sqlCmd.Connection = SqlConn;
                        sqlCmd.Transaction = tran;
                        sqlCmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                    SqlConn.Close();
                    return true;
                }
                catch(Exception ex)
                {
                    tran.Rollback();
                    SqlConn.Close();
                    Loger.WriteLog(ex);
                    throw ex;
                    //return false;
                }
                
            }
        }

        public static int ExecSql(string sql,SqlConnection con)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = sql;
                sqlCmd.Connection = con;
                int i = sqlCmd.ExecuteNonQuery();
                return i;
            }
            catch (Exception ex)
            {
                Loger.WriteLog(ex);
                throw ex;
            }
        }

        public static string getConfig(string sConfigStr)
        {
            SqlDataReader odr = null;
            try
            {
                odr = GetDataReader("select value from config where name='" + sConfigStr + "'");
                string sValue = odr.GetString(0);
                return sValue;
            }
            catch(Exception ex)
            {
                Loger.WriteLog(ex);
                return "";
            }
            finally
            {
                if (!odr.IsClosed)
                {
                    odr.Close();
                }
            }
        }

        

        public static DataSet GetDataSet(string sql)
        {
            try
            {
                SqlDataAdapter oda = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand sqlcmd = new SqlCommand(sql, SqlConn);
                oda.SelectCommand = sqlcmd;
                oda.Fill(ds);
                return ds;
            }
            catch(Exception ex)
            {
                Loger.WriteLog(ex);
                return null;
            }

        }
        static SqlConnection conn = null;
        public static SqlConnection OracleCon()
        {
            if (conn == null)
            {
                conn = new SqlConnection();
                conn.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["SqlStr"].ToString();
            }
            return conn;
        }
    }
}
