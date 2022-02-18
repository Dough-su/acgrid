using System.Configuration;//这里务必要引用
using System.Data;
using System.Data.SqlClient;
//此处必须要引用system.configuration

namespace DAL
{
    public static class SqlHelper //静态类
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings
            ["mssql"].ConnectionString;
        //insert delete update
        public static int ExecuteNonQuery(string sql, CommandType cmdType, params
            SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = cmdType;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();//只有执行增删改的时候才会返回影响的行数，其他情况返回-1
                }
            }
        }
        //返回单个值
        public static object ExecuteScalar(string sql,CommandType cmdType,params
            SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = cmdType;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
        //执行返回datareader
        public static SqlDataReader ExecuteReader(string sql, CommandType cmdType, params
            SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(conStr);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = cmdType;
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                //con.open();
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch
                {
                    con.Close();
                    con.Dispose();
                    throw;//抛出当前异常
                }
            }
        }
        public static DataTable ExecuteDataTable(string sql, CommandType cmdType, params
            SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conStr))
            {
                adapter.SelectCommand.CommandType = cmdType;
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);

                }
                adapter.Fill(dt);
            }
            return dt;
        }
    }
    
}
