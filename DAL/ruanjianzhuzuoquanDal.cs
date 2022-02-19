using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ruanjianzhuzuoquanDal
    {
        public int Update(ruanjianzhuzuoquan model)//更新操作
        {
            string sql = "update ruanjianzhuzuoquan set name=@name,证书号=@证书号,download=@download,export=@export,edit=@edit,share=@share,code=@code,rank=@rank,开发完成时间=@开发完成时间,获得时间=@获得时间,成果同步=@成果同步,登记号=@登记号,著作权类型=@著作权类型,著作权人=@著作权人,关联课题=@关联课题,备注信息=@备注信息 where username=@username and paperid=@paperid ";
            SqlParameter[] pms = new SqlParameter[] {
               
new SqlParameter("name",System.Data.SqlDbType.VarChar,255 ){ Value=model.name},
new SqlParameter("证书号",System.Data.SqlDbType.VarChar,255 ){ Value=model.证书号},
new SqlParameter("download",System.Data.SqlDbType.VarChar,255 ){ Value=model.download},
new SqlParameter("export",System.Data.SqlDbType.VarChar,255 ){ Value=model.export},
new SqlParameter("edit",System.Data.SqlDbType.VarChar,255 ){ Value=model.edit},
new SqlParameter("share",System.Data.SqlDbType.VarChar,255 ){ Value=model.share},
new SqlParameter("username",System.Data.SqlDbType.VarChar,255 ){ Value=model.username},
new SqlParameter("code",System.Data.SqlDbType.VarChar,255 ){ Value=model.code},
new SqlParameter("paperid",System.Data.SqlDbType.VarChar,255 ){ Value=model.paperid},
new SqlParameter("rank",System.Data.SqlDbType.VarChar,255 ){ Value=model.rank},
new SqlParameter("开发完成时间",System.Data.SqlDbType.VarChar,255 ){ Value=model.开发完成时间},
new SqlParameter("获得时间",System.Data.SqlDbType.VarChar,255 ){ Value=model.获得时间},
new SqlParameter("成果同步",System.Data.SqlDbType.VarChar,255 ){ Value=model.成果同步},
new SqlParameter("登记号",System.Data.SqlDbType.VarChar,255 ){ Value=model.登记号},
new SqlParameter("著作权类型",System.Data.SqlDbType.VarChar,255 ){ Value=model.著作权类型},
new SqlParameter("著作权人",System.Data.SqlDbType.VarChar,255 ){ Value=model.著作权人},
new SqlParameter("关联课题",System.Data.SqlDbType.VarChar,255 ){ Value=model.关联课题},
new SqlParameter("备注信息",System.Data.SqlDbType.VarChar,255 ){ Value=model.备注信息}, };


            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }
        public int Insert(ruanjianzhuzuoquan model)//增加记录
        {
            string sql = "insert into ruanjianzhuzuoquan values(@name,@证书号,@download,@export,@edit,@share,@username,@code,@paperid,@rank,@开发完成时间,@获得时间,@成果同步,@登记号,@著作权类型,@著作权人,@关联课题,@备注信息)";
            SqlParameter[] pms = new SqlParameter[] {
             new SqlParameter("name",System.Data.SqlDbType.VarChar,255 ){ Value=model.name},
new SqlParameter("证书号",System.Data.SqlDbType.VarChar,255 ){ Value=model.证书号},
new SqlParameter("download",System.Data.SqlDbType.VarChar,255 ){ Value=model.download},
new SqlParameter("export",System.Data.SqlDbType.VarChar,255 ){ Value=model.export},
new SqlParameter("edit",System.Data.SqlDbType.VarChar,255 ){ Value=model.edit},
new SqlParameter("share",System.Data.SqlDbType.VarChar,255 ){ Value=model.share},
new SqlParameter("username",System.Data.SqlDbType.VarChar,255 ){ Value=model.username},
new SqlParameter("code",System.Data.SqlDbType.VarChar,255 ){ Value=model.code},
new SqlParameter("paperid",System.Data.SqlDbType.VarChar,255 ){ Value=model.paperid},
new SqlParameter("rank",System.Data.SqlDbType.VarChar,255 ){ Value=model.rank},
new SqlParameter("开发完成时间",System.Data.SqlDbType.VarChar,255 ){ Value=model.开发完成时间},
new SqlParameter("获得时间",System.Data.SqlDbType.VarChar,255 ){ Value=model.获得时间},
new SqlParameter("成果同步",System.Data.SqlDbType.VarChar,255 ){ Value=model.成果同步},
new SqlParameter("登记号",System.Data.SqlDbType.VarChar,255 ){ Value=model.登记号},
new SqlParameter("著作权类型",System.Data.SqlDbType.VarChar,255 ){ Value=model.著作权类型},
new SqlParameter("著作权人",System.Data.SqlDbType.VarChar,255 ){ Value=model.著作权人},
new SqlParameter("关联课题",System.Data.SqlDbType.VarChar,255 ){ Value=model.关联课题},
new SqlParameter("备注信息",System.Data.SqlDbType.VarChar,255 ){ Value=model.备注信息}, };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);

        }
    }
}
