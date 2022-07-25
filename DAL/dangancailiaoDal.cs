using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dangancailiaoDal
    {
        public int Update(dangancailiao model)//更新操作
        {
            string sql = "update dangancailiao set caogao=@caogao,name=@name,证书类型=@证书类型,获得时间=@获得时间,证书编号=@证书编号,授予机构=@授予机构,备注信息=@备注信息,关联课题=@关联课题,成果同步=@成果同步 where username=@username and paperid=@paperid ";
            SqlParameter[] pms = new SqlParameter[] {
                new SqlParameter("caogao",System.Data.SqlDbType.VarChar,255 ){ Value=model.caogao},
                new SqlParameter("username",System.Data.SqlDbType.VarChar,255 ){ Value=model.username},
new SqlParameter("paperid",System.Data.SqlDbType.BigInt,255 ){ Value=model.paperid},
new SqlParameter("name",System.Data.SqlDbType.VarChar,255 ){ Value=model.name},
new SqlParameter("证书类型",System.Data.SqlDbType.VarChar,255 ){ Value=model.证书类型},
new SqlParameter("获得时间",System.Data.SqlDbType.VarChar,255 ){ Value=model.获得时间},
new SqlParameter("证书编号",System.Data.SqlDbType.VarChar,255 ){ Value=model.证书编号},
new SqlParameter("授予机构",System.Data.SqlDbType.VarChar,255 ){ Value=model.授予机构},
new SqlParameter("备注信息",System.Data.SqlDbType.VarChar,255 ){ Value=model.备注信息},
new SqlParameter("关联课题",System.Data.SqlDbType.VarChar,255 ){ Value=model.关联课题},
new SqlParameter("成果同步",System.Data.SqlDbType.VarChar,255 ){ Value=model.成果同步},};

            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }
        public int Insert(dangancailiao model)//增加记录
        {
            string sql = "insert into dangancailiao  values(@username,@paperid,@name,@证书类型,@获得时间,@证书编号,@授予机构,@备注信息,@关联课题,@成果同步,@caogao)";
            SqlParameter[] pms = new SqlParameter[] {
                new SqlParameter("caogao",System.Data.SqlDbType.VarChar,255 ){ Value=model.caogao},
                new SqlParameter("username",System.Data.SqlDbType.VarChar,255 ){ Value=model.username},
new SqlParameter("paperid",System.Data.SqlDbType.BigInt,255 ){ Value=model.paperid},
new SqlParameter("name",System.Data.SqlDbType.VarChar,255 ){ Value=model.name},
new SqlParameter("证书类型",System.Data.SqlDbType.VarChar,255 ){ Value=model.证书类型},
new SqlParameter("获得时间",System.Data.SqlDbType.VarChar,255 ){ Value=model.获得时间},
new SqlParameter("证书编号",System.Data.SqlDbType.VarChar,255 ){ Value=model.证书编号},
new SqlParameter("授予机构",System.Data.SqlDbType.VarChar,255 ){ Value=model.授予机构},
new SqlParameter("备注信息",System.Data.SqlDbType.VarChar,255 ){ Value=model.备注信息},
new SqlParameter("关联课题",System.Data.SqlDbType.VarChar,255 ){ Value=model.关联课题},
new SqlParameter("成果同步",System.Data.SqlDbType.VarChar,255 ){ Value=model.成果同步},
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }

    }
}
