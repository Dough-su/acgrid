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
        public int  update(UserInfo user)//更新用户信息
        {
            string sql = "update UserInfo set name=@name,realname=@realname,professional=@professional,degree=@degree,email=@email,birthday=@birthday,qq=@qq,wechat=@wechat,research_direction=@research_direction,telephone_number=@telephone_number where username=@user";
            SqlParameter[] pms = new SqlParameter[] {
                new SqlParameter("@name",SqlDbType.VarChar,20){ Value=user.name },
                new SqlParameter("@realname",SqlDbType.VarChar,20){ Value=user.realname },
                new SqlParameter("@professional",SqlDbType.VarChar,20){ Value=user.professional },
                new SqlParameter("@degree",SqlDbType.VarChar,20){ Value=user.degree },
                new SqlParameter("@email",SqlDbType.VarChar,20){ Value=user.email },
                new SqlParameter("@birthday",SqlDbType.VarChar,20){ Value=user.birthday },
                new SqlParameter("@qq",SqlDbType.VarChar,20){ Value=user.qq },
                new SqlParameter("@wechat",SqlDbType.VarChar,20){ Value=user.wechat },
                new SqlParameter("@user",SqlDbType.VarChar,20){ Value=user.username},
                new SqlParameter("@telephone_number",SqlDbType.VarChar,20){ Value=user.telephone_number},
                new SqlParameter("@research_direction",SqlDbType.VarChar,20){ Value=user.research_direction },
                };
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms);
        }


        public int Insert(UserInfo Models)//注册用
        {
            string sql = "insert into UserInfo values(@username,@password,@phone,@createdate,@email)";
            SqlParameter[] pms = new SqlParameter[] {
               // new SqlParameter("password",System.Data.SqlDbType.VarChar,32){ Value=Models.UserPwd},
               //new SqlParameter("createdate",System.Data.SqlDbType.DateTime){Value=Models.CreatedDate},
               // new SqlParameter("username",System.Data.SqlDbType.VarChar,255){Value=Models.UserName},
               //   new SqlParameter("phone",System.Data.SqlDbType.VarChar,255){Value=Models.Phone},
               //   new SqlParameter("email",System.Data.SqlDbType.VarChar,255){Value=Models.Email},
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);

        }
        public int ListUserInfo(string username)
        {

            string sql = "SELECT Email,Avater,Phone,name FROM UserInfo WHERE username=@username";
            SqlParameter[] pms = new SqlParameter[] {
          
                new SqlParameter("username",System.Data.SqlDbType.VarChar,255){Value=username},
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }
        public int Avater(string username,string Avater)//更新用户头像
        {
            string sql = "update UserInfo set Avater=@Avater where username=@username ";
            SqlParameter[] pms = new SqlParameter[] {
                new SqlParameter("Avater",System.Data.SqlDbType.VarChar,32){ Value=Avater},
                new SqlParameter("username",System.Data.SqlDbType.VarChar,32){ Value=username},
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);

        }
    }
}
