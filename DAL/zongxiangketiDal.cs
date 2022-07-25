using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class zongxiangketiDal
    {
        public int Update(zongxiangketi model)//更新操作
        {
            string sql = "update zongxiangketi set caogao=@caogao,name=@name,source=@source,课题类型=@课题类型,授予单位=@授予单位,课题级别=@课题级别,课题编号=@课题编号,到账经费=@到账经费,rank=@rank,开始时间=@开始时间,截止时间=@截止时间,课题状态=@课题状态,备注信息=@备注信息,成果同步=@成果同步 where username=@username and paperid=@paperid ";
            SqlParameter[] pms = new SqlParameter[] {
                new SqlParameter("caogao",System.Data.SqlDbType.VarChar,255 ){ Value=model.caogao},
                new SqlParameter("name",System.Data.SqlDbType.VarChar,255 ){ Value=model.name},
new SqlParameter("source",System.Data.SqlDbType.VarChar,255 ){ Value=model.source},
new SqlParameter("课题类型",System.Data.SqlDbType.VarChar,255 ){ Value=model.课题类型},
new SqlParameter("授予单位",System.Data.SqlDbType.VarChar,255 ){ Value=model.授予单位},
new SqlParameter("课题级别",System.Data.SqlDbType.VarChar,255 ){ Value=model.课题级别},
new SqlParameter("课题编号",System.Data.SqlDbType.VarChar,255 ){ Value=model.课题编号},
new SqlParameter("到账经费",System.Data.SqlDbType.VarChar,255 ){ Value=model.到账经费},
new SqlParameter("rank",System.Data.SqlDbType.VarChar,255 ){ Value=model.rank},
new SqlParameter("开始时间",System.Data.SqlDbType.VarChar,255 ){ Value=model.开始时间},
new SqlParameter("截止时间",System.Data.SqlDbType.VarChar,255 ){ Value=model.截止时间},
new SqlParameter("课题状态",System.Data.SqlDbType.VarChar,255 ){ Value=model.课题状态},
new SqlParameter("备注信息",System.Data.SqlDbType.VarChar,255 ){ Value=model.备注信息},
new SqlParameter("成果同步",System.Data.SqlDbType.VarChar,255 ){ Value=model.成果同步},
new SqlParameter("username",System.Data.SqlDbType.VarChar,255 ){ Value=model.username},
new SqlParameter("paperid",System.Data.SqlDbType.BigInt,255 ){ Value=model.paperid}, };

            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }
        public int Insert(zongxiangketi model)//增加记录
        {
            string sql = "insert into zongxiangketi  values(@name,@source,@课题类型,@授予单位,@课题级别,@课题编号,@到账经费,@rank,@开始时间,@截止时间,@课题状态,@备注信息,@成果同步,@username,@paperid,@caogao)";
            SqlParameter[] pms = new SqlParameter[] {
                new SqlParameter("caogao",System.Data.SqlDbType.VarChar,255 ){ Value=model.caogao},
                new SqlParameter("name",System.Data.SqlDbType.VarChar,255 ){ Value=model.name},
new SqlParameter("source",System.Data.SqlDbType.VarChar,255 ){ Value=model.source},
new SqlParameter("课题类型",System.Data.SqlDbType.VarChar,255 ){ Value=model.课题类型},
new SqlParameter("授予单位",System.Data.SqlDbType.VarChar,255 ){ Value=model.授予单位},
new SqlParameter("课题级别",System.Data.SqlDbType.VarChar,255 ){ Value=model.课题级别},
new SqlParameter("课题编号",System.Data.SqlDbType.VarChar,255 ){ Value=model.课题编号},
new SqlParameter("到账经费",System.Data.SqlDbType.VarChar,255 ){ Value=model.到账经费},
new SqlParameter("rank",System.Data.SqlDbType.VarChar,255 ){ Value=model.rank},
new SqlParameter("开始时间",System.Data.SqlDbType.VarChar,255 ){ Value=model.开始时间},
new SqlParameter("截止时间",System.Data.SqlDbType.VarChar,255 ){ Value=model.截止时间},
new SqlParameter("课题状态",System.Data.SqlDbType.VarChar,255 ){ Value=model.课题状态},
new SqlParameter("备注信息",System.Data.SqlDbType.VarChar,255 ){ Value=model.备注信息},
new SqlParameter("成果同步",System.Data.SqlDbType.VarChar,255 ){ Value=model.成果同步},
new SqlParameter("username",System.Data.SqlDbType.VarChar,255 ){ Value=model.username},
new SqlParameter("paperid",System.Data.SqlDbType.BigInt,255 ){ Value=model.paperid}, };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }
    }
}
