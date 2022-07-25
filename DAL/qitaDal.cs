﻿using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class qitaDal
    {
        public int Update(qita model)//更新操作
        {
            string sql = "update qita set caogao=@caogao,name=@name,rank=@rank,获得时间=@获得时间,备注信息=@备注信息,关联课题=@关联课题,成果同步=@成果同步 where username=@username and paperid=@paperid ";
            SqlParameter[] pms = new SqlParameter[] {
                new SqlParameter("caogao",System.Data.SqlDbType.VarChar,255 ){ Value=model.caogao},
                new SqlParameter("username",System.Data.SqlDbType.VarChar,255 ){ Value=model.username},
                new SqlParameter("paperid",System.Data.SqlDbType.BigInt,255 ){ Value=model.paperid},
                new SqlParameter("name",System.Data.SqlDbType.VarChar,255 ){ Value=model.name},
                new SqlParameter("rank",System.Data.SqlDbType.VarChar,255 ){ Value=model.rank},  
                new SqlParameter("获得时间",System.Data.SqlDbType.VarChar,255 ){ Value=model.获得时间},
                new SqlParameter("备注信息",System.Data.SqlDbType.VarChar,255 ){ Value=model.备注信息},
                new SqlParameter("关联课题",System.Data.SqlDbType.VarChar,255 ){ Value=model.关联课题},
                new SqlParameter("成果同步",System.Data.SqlDbType.VarChar,255 ){ Value=model.成果同步},};

            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }
        public int Insert(qita model)//增加记录
        {
            string sql = "insert into qita  values(@username,@paperid,@name,@rank,@获得时间,@备注信息,@关联课题,@成果同步,@caogao)";
            SqlParameter[] pms = new SqlParameter[] {
                new SqlParameter("caogao",System.Data.SqlDbType.VarChar,255 ){ Value=model.caogao},
                new SqlParameter("username",System.Data.SqlDbType.VarChar,255 ){ Value=model.username},
                new SqlParameter("paperid",System.Data.SqlDbType.BigInt,255 ){ Value=model.paperid},
                new SqlParameter("name",System.Data.SqlDbType.VarChar,255 ){ Value=model.name},
                new SqlParameter("rank",System.Data.SqlDbType.VarChar,255 ){ Value=model.rank},
                new SqlParameter("获得时间",System.Data.SqlDbType.VarChar,255 ){ Value=model.获得时间},
                new SqlParameter("备注信息",System.Data.SqlDbType.VarChar,255 ){ Value=model.备注信息},
                new SqlParameter("关联课题",System.Data.SqlDbType.VarChar,255 ){ Value=model.关联课题},
                new SqlParameter("成果同步",System.Data.SqlDbType.VarChar,255 ){ Value=model.成果同步},};
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }

    }
}