using System.Data.SqlClient;
using System.Data;
using DAL;
using Models;
using System;

namespace DAl
{
    public class UserInfoDal
    {
        public int logincheck(string user, string pwd)//登录校验用户名和密码
        {
            string sql = "Select count(*) from users where UserName=@user and UserPwd=@pwd ";
            SqlParameter[] pms = new SqlParameter[] {
                new SqlParameter("@user",SqlDbType.VarChar,20){ Value=user },
                new SqlParameter("@pwd",SqlDbType.VarChar,32){ Value=pwd } };
            return (int)SqlHelper.ExecuteScalar(sql, CommandType.Text, pms);
        }
        public int signincheck(string user)//注册时防止用户名重复
        {
            string sql = "Select count(*) from users where UserName=@user  ";
            SqlParameter[] pms = new SqlParameter[] {
                new SqlParameter("@user",SqlDbType.VarChar,20){ Value=user } };
            return (int)SqlHelper.ExecuteScalar(sql, CommandType.Text, pms);
        }



        public int Insert(UserInfo Models)//注册用
        {
            string sql = "insert into users values(@username,@password,@phone,@createdate,@email)";
            SqlParameter[] pms = new SqlParameter[] {
                new SqlParameter("password",System.Data.SqlDbType.VarChar,32){ Value=Models.UserPwd},
               new SqlParameter("createdate",System.Data.SqlDbType.DateTime){Value=Models.CreatedDate},
                new SqlParameter("username",System.Data.SqlDbType.VarChar,255){Value=Models.UserName},
                  new SqlParameter("phone",System.Data.SqlDbType.VarChar,255){Value=Models.Phone},
                  new SqlParameter("email",System.Data.SqlDbType.VarChar,255){Value=Models.Email},
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);

        }
    }
}
