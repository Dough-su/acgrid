using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{  
        public class zhuzuoDal
        {
            public int Update(zhuzuo model)//更新操作
            {
                string sql = "update zhuzuo set caogao=@caogao,name=@name,number=@number,identify=@identify,rank=@rank,出版社=@出版社,著作类型=@著作类型,字数=@字数,出版地=@出版地,出版时间=@出版时间,备注信息=@备注信息,关联课题=@关联课题,成果同步=@成果同步 where username=@username and paperid=@paperid ";
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("caogao",System.Data.SqlDbType.VarChar,255 ){ Value=model.caogao},
                new SqlParameter("name",System.Data.SqlDbType.VarChar,255 ){ Value=model.name},
                new SqlParameter("number",System.Data.SqlDbType.VarChar,255 ){ Value=model.number},
                new SqlParameter("identify",System.Data.SqlDbType.VarChar,255 ){ Value=model.identify},
                new SqlParameter("rank",System.Data.SqlDbType.VarChar,255 ){ Value=model.rank},
                new SqlParameter("出版社",System.Data.SqlDbType.VarChar,255 ){ Value=model.出版社},
                new SqlParameter("著作类型",System.Data.SqlDbType.VarChar,255 ){ Value=model.著作类型},
                new SqlParameter("字数",System.Data.SqlDbType.VarChar,255 ){ Value=model.字数},
                new SqlParameter("出版地",System.Data.SqlDbType.VarChar,255 ){ Value=model.出版地},
                new SqlParameter("出版时间",System.Data.SqlDbType.VarChar,255 ){ Value=model.出版时间},
                new SqlParameter("备注信息",System.Data.SqlDbType.VarChar,255 ){ Value=model.备注信息},
                new SqlParameter("关联课题",System.Data.SqlDbType.VarChar,255 ){ Value=model.关联课题},
                new SqlParameter("成果同步",System.Data.SqlDbType.VarChar,255 ){ Value=model.成果同步},
                new SqlParameter("username",System.Data.SqlDbType.VarChar,255 ){ Value=model.username},
                new SqlParameter("paperid",System.Data.SqlDbType.BigInt,255 ){ Value=model.paperid},};

                return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
            }
            public int Insert(zhuzuo model)//增加记录
            {
                string sql = "insert into zhuzuo  values(@name,@number,@identify,@rank,@出版社,@著作类型,@字数,@出版地,@出版时间,@备注信息,@关联课题,@成果同步,@username,@paperid,@caogao)";
                SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("caogao",System.Data.SqlDbType.VarChar,255 ){ Value=model.caogao},
                new SqlParameter("name",System.Data.SqlDbType.VarChar,255 ){ Value=model.name},
                new SqlParameter("number",System.Data.SqlDbType.VarChar,255 ){ Value=model.number},
                new SqlParameter("identify",System.Data.SqlDbType.VarChar,255 ){ Value=model.identify},
                new SqlParameter("rank",System.Data.SqlDbType.VarChar,255 ){ Value=model.rank},
                new SqlParameter("出版社",System.Data.SqlDbType.VarChar,255 ){ Value=model.出版社},
                new SqlParameter("著作类型",System.Data.SqlDbType.VarChar,255 ){ Value=model.著作类型},
                new SqlParameter("字数",System.Data.SqlDbType.VarChar,255 ){ Value=model.字数},
                new SqlParameter("出版地",System.Data.SqlDbType.VarChar,255 ){ Value=model.出版地},
                new SqlParameter("出版时间",System.Data.SqlDbType.VarChar,255 ){ Value=model.出版时间},
                new SqlParameter("备注信息",System.Data.SqlDbType.VarChar,255 ){ Value=model.备注信息},
                new SqlParameter("关联课题",System.Data.SqlDbType.VarChar,255 ){ Value=model.关联课题},
                new SqlParameter("成果同步",System.Data.SqlDbType.VarChar,255 ){ Value=model.成果同步},
                new SqlParameter("username",System.Data.SqlDbType.VarChar,255 ){ Value=model.username},
                new SqlParameter("paperid",System.Data.SqlDbType.BigInt,255 ){ Value=model.paperid},};
                return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
            }

        }
}
