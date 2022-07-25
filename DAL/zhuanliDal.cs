using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class zhuanliDal
    {
        public int Update(zhuanli model)//更新操作
        {
            string sql = "update zhuanli set caogao=@caogao,name=@name,code=@code,paperid=@paperid, 专利类型=@专利类型,专利状态=@专利状态,专利编号=@专利编号,专利权人=@专利权人,授权公告日=@授权公告日,申请编号=@申请编号,专利申请日=@专利申请日,rank=@rank,备注信息=@备注信息,关联课题=@关联课题,成果同步=@成果同步 where username=@username and paperid=@paperid ";
            SqlParameter[] pms = new SqlParameter[] {
                new SqlParameter("caogao",System.Data.SqlDbType.VarChar,255 ){ Value=model.caogao},
                new SqlParameter("name",System.Data.SqlDbType.VarChar,255 ){ Value=model.name},
                new SqlParameter("username",System.Data.SqlDbType.VarChar,255 ){ Value=model.username},
                new SqlParameter("code",System.Data.SqlDbType.VarChar,255 ){ Value=model.code},
                new SqlParameter("paperid",System.Data.SqlDbType.BigInt,255 ){ Value=model.paperid},
                new SqlParameter("专利类型",System.Data.SqlDbType.VarChar,255 ){ Value=model.专利类型},
                new SqlParameter("专利状态",System.Data.SqlDbType.VarChar,255 ){ Value=model.专利状态},
                new SqlParameter("专利编号",System.Data.SqlDbType.VarChar,255 ){ Value=model.专利编号},
                new SqlParameter("专利权人",System.Data.SqlDbType.VarChar,255 ){ Value=model.专利权人},
                new SqlParameter("授权公告日",System.Data.SqlDbType.VarChar,255 ){ Value=model.授权公告日},
                new SqlParameter("申请编号",System.Data.SqlDbType.VarChar,255 ){ Value=model.申请编号},
                new SqlParameter("专利申请日",System.Data.SqlDbType.VarChar,255 ){ Value=model.专利申请日},
                new SqlParameter("rank",System.Data.SqlDbType.VarChar,255 ){ Value=model.rank},
                new SqlParameter("备注信息",System.Data.SqlDbType.VarChar,255 ){ Value=model.备注信息},
                new SqlParameter("关联课题",System.Data.SqlDbType.VarChar,255 ){ Value=model.关联课题},
               
                new SqlParameter("成果同步",System.Data.SqlDbType.VarChar,255 ){ Value=model.成果同步}, };

            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }
        public int Insert(zhuanli model)//增加记录
        {
            string sql = "insert into zhuanli  values(@name,@code,@paperid,@专利类型,@专利状态,@专利编号,@专利权人,@授权公告日,@申请编号,@专利申请日,@rank,@备注信息,@关联课题,@成果同步,@username,@caogao)";
            SqlParameter[] pms = new SqlParameter[] {
                new SqlParameter("caogao",System.Data.SqlDbType.VarChar,255 ){ Value=model.caogao},
                new SqlParameter("name",System.Data.SqlDbType.VarChar,255 ){ Value=model.name},
                new SqlParameter("username",System.Data.SqlDbType.VarChar,255 ){ Value=model.username},
                new SqlParameter("code",System.Data.SqlDbType.VarChar,255 ){ Value=model.code},
                new SqlParameter("paperid",System.Data.SqlDbType.BigInt,255 ){ Value=model.paperid},
                new SqlParameter("专利类型",System.Data.SqlDbType.VarChar,255 ){ Value=model.专利类型},
                new SqlParameter("专利状态",System.Data.SqlDbType.VarChar,255 ){ Value=model.专利状态},
                new SqlParameter("专利编号",System.Data.SqlDbType.VarChar,255 ){ Value=model.专利编号},
                new SqlParameter("专利权人",System.Data.SqlDbType.VarChar,255 ){ Value=model.专利权人},
                new SqlParameter("授权公告日",System.Data.SqlDbType.VarChar,255 ){ Value=model.授权公告日},
                new SqlParameter("申请编号",System.Data.SqlDbType.VarChar,255 ){ Value=model.申请编号},
                new SqlParameter("专利申请日",System.Data.SqlDbType.VarChar,255 ){ Value=model.专利申请日},
                new SqlParameter("rank",System.Data.SqlDbType.VarChar,255 ){ Value=model.rank},
                new SqlParameter("备注信息",System.Data.SqlDbType.VarChar,255 ){ Value=model.备注信息},
                new SqlParameter("关联课题",System.Data.SqlDbType.VarChar,255 ){ Value=model.关联课题},
                new SqlParameter("成果同步",System.Data.SqlDbType.VarChar,255 ){ Value=model.成果同步}, };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }
    }
}
