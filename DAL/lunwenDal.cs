using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class lunwenDal
    {
        public int Update(lunwen model)//更新操作
        {
            string sql = "update lunwen set code=@code,rank=@rank,time=@time,DOI号=@DOI号,引用次数=@引用次数,关键词=@关键词,起止页码=@起止页码,关联课题=@关联课题,成果同步=@成果同步,影响因子=@影响因子,卷号=@卷号,期号=@期号,ISSN号=@ISSN号,CN号=@CN号,摘要=@摘要,备注信息=@备注信息,download=@download,export=@export,edit=@edit ,kanwumingcheng=@kanwumingcheng,lunwenlingyu=@lunwenlingyu,duzhu=@duzhu,tongxunzuozhe=@tongxunzuozhe,EI=@EI,ISTP=@ISTP,ISSHP=@ISSHP,PKU=@PKU,SCD=@SCD,CSCDE=@CSCDE,省级期刊=@省级期刊,ESCI=@ESCI,SSCI=@SSCI,其他=@其他,CSSCI扩展版=@CSSCI扩展版,自然指数杂志=@自然指数杂志,SCIE=@SCIE,SCI=@SCI,会议期刊=@会议期刊,科研核心=@科研核心,国家级期刊=@国家级期刊,AHCI=@AHCI,校内核心=@校内核心,share=@share,CSSCI=@CSSCI,CSCD=@CSCD,name=@name,lunwenleixing=@lunwenleixing where username=@username and paperid=@paperid ";
            SqlParameter[] pms = new SqlParameter[] {
                new SqlParameter("username",System.Data.SqlDbType.VarChar,255 ){ Value=model.username},
                new SqlParameter("code",System.Data.SqlDbType.VarChar,255){ Value=model.code},
                new SqlParameter("name",System.Data.SqlDbType.VarChar,255){ Value=model.name},
                new SqlParameter("rank",System.Data.SqlDbType.VarChar,255){ Value=model.rank},
                new SqlParameter("time",System.Data.SqlDbType.VarChar,255){ Value=model.time},
                new SqlParameter("download",System.Data.SqlDbType.VarChar,255){ Value=model.download},
                new SqlParameter("export",System.Data.SqlDbType.VarChar,255){ Value=model.export},
                new SqlParameter("edit",System.Data.SqlDbType.VarChar,255){ Value=model.edit},
                new SqlParameter("share",System.Data.SqlDbType.VarChar,255){ Value=model.share},
                new SqlParameter("paperid",System.Data.SqlDbType.VarChar,255){ Value=model.paperid},
                new SqlParameter("lunwenleixing",System.Data.SqlDbType.VarChar,255){ Value=model.lunwenleixing},
                new SqlParameter("lunwenlingyu",System.Data.SqlDbType.VarChar,255){ Value=model.lunwenlingyu},
                new SqlParameter("tongxunzuozhe",System.Data.SqlDbType.VarChar,255){Value= model.tongxunzuozhe},
                new SqlParameter("kanwumingcheng",System.Data.SqlDbType.VarChar,255){ Value=model.kanwumingcheng},
                new SqlParameter("duzhu", System.Data.SqlDbType.VarChar, 255) { Value = model.duzhu },
                new SqlParameter("EI",System.Data.SqlDbType.VarChar,255){Value=model.EI},
                new SqlParameter("ISTP",System.Data.SqlDbType.VarChar,255){Value=model.ISTP},
                new SqlParameter("ISSHP",System.Data.SqlDbType.VarChar,255){Value=model.ISSHP},
                new SqlParameter("PKU",System.Data.SqlDbType.VarChar,255){Value=model.PKU},
                new SqlParameter("SCD",System.Data.SqlDbType.VarChar,255){Value=model.SCD},
                new SqlParameter("CSCDE",System.Data.SqlDbType.VarChar,255){Value=model.CSCDE},
                new SqlParameter("省级期刊",System.Data.SqlDbType.VarChar,255){Value=model.省级期刊},
                new SqlParameter("ESCI",System.Data.SqlDbType.VarChar,255){Value=model.ESCI},
                new SqlParameter("SSCI",System.Data.SqlDbType.VarChar,255){Value=model.SSCI},
                new SqlParameter("其他",System.Data.SqlDbType.VarChar,255){Value=model.其他},
                new SqlParameter("CSCD",System.Data.SqlDbType.VarChar,255){Value=model.CSCD},
                new SqlParameter("CSSCI扩展版",System.Data.SqlDbType.VarChar,255){Value=model.CSSCI扩展版},
                new SqlParameter("CSSCI",System.Data.SqlDbType.VarChar,255){Value=model.CSSCI},
                new SqlParameter("自然指数杂志",System.Data.SqlDbType.VarChar,255){Value=model.自然指数杂志},
                new SqlParameter("SCIE",System.Data.SqlDbType.VarChar,255){Value=model.SCIE},
                new SqlParameter("SCI",System.Data.SqlDbType.VarChar,255){Value=model.SCI},
                new SqlParameter("会议期刊",System.Data.SqlDbType.VarChar,255){Value=model.会议期刊},
                new SqlParameter("科研核心",System.Data.SqlDbType.VarChar,255){Value=model.科研核心},
                new SqlParameter("国家级期刊",System.Data.SqlDbType.VarChar,255){Value=model.国家级期刊},
                new SqlParameter("AHCI",System.Data.SqlDbType.VarChar,255){Value=model.AHCI},
                new SqlParameter("DOI号",System.Data.SqlDbType.VarChar,255){Value=model.DOI号},
new SqlParameter("引用次数",System.Data.SqlDbType.VarChar,255){Value=model.引用次数},
new SqlParameter("关键词",System.Data.SqlDbType.VarChar,255){Value=model.关键词},
new SqlParameter("起止页码",System.Data.SqlDbType.VarChar,255){Value=model.起止页码},
new SqlParameter("关联课题",System.Data.SqlDbType.VarChar,255){Value=model.关联课题},
new SqlParameter("成果同步",System.Data.SqlDbType.VarChar,255){Value=model.成果同步},
new SqlParameter("影响因子",System.Data.SqlDbType.VarChar,255){Value=model.影响因子},
new SqlParameter("卷号",System.Data.SqlDbType.VarChar,255){Value=model.卷号},
new SqlParameter("期号",System.Data.SqlDbType.VarChar,255){Value=model.期号},
new SqlParameter("ISSN号",System.Data.SqlDbType.VarChar,255){Value=model.ISSN号},
new SqlParameter("CN号",System.Data.SqlDbType.VarChar,255){Value=model.CN号},
new SqlParameter("摘要",System.Data.SqlDbType.VarChar,255){Value=model.摘要},
new SqlParameter("备注信息",System.Data.SqlDbType.VarChar,255){Value=model.备注信息},
                new SqlParameter("校内核心",System.Data.SqlDbType.VarChar,255){Value=model.校内核心} };
            

            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }
        public int Insert(lunwen model)//增加记录
        {
            string sql = "insert into lunwen values(@code, @name, @rank, @time, @download, @export, @edit, @share, @username, @CSSCI, @CSCD, @paperid, @lunwenleixing, @lunwenlingyu, @省级期刊, @tongxunzuozhe, @kanwumingcheng, @duzhu, @EI, @ISTP, @ISSHP, @PKU, @SCD, @CSCDE, @ESCI, @SSCI, @其他, @CSSCI扩展版, @自然指数杂志, @SCIE, @SCI, @会议期刊, @科研核心, @国家级期刊, @AHCI, @校内核心, @DOI号, @引用次数, @关键词, @起止页码, @关联课题, @成果同步, @影响因子, @卷号, @期号, @ISSN号, @CN号, @摘要, @备注信息)";
            SqlParameter[] pms = new SqlParameter[] {
             new SqlParameter("username",System.Data.SqlDbType.VarChar,255 ){ Value=model.username},
                new SqlParameter("code",System.Data.SqlDbType.VarChar,255){ Value=model.code},
                new SqlParameter("name",System.Data.SqlDbType.VarChar,255){ Value=model.name},
                new SqlParameter("rank",System.Data.SqlDbType.VarChar,255){ Value=model.rank},
                new SqlParameter("time",System.Data.SqlDbType.VarChar,255){ Value=model.time},
                new SqlParameter("download",System.Data.SqlDbType.VarChar,255){ Value=model.download},
                new SqlParameter("export",System.Data.SqlDbType.VarChar,255){ Value=model.export},
                new SqlParameter("edit",System.Data.SqlDbType.VarChar,255){ Value=model.edit},
                new SqlParameter("share",System.Data.SqlDbType.VarChar,255){ Value=model.share},
                new SqlParameter("paperid",System.Data.SqlDbType.BigInt,255){ Value=model.paperid},
                new SqlParameter("lunwenleixing",System.Data.SqlDbType.VarChar,255){ Value=model.lunwenleixing},
                new SqlParameter("lunwenlingyu",System.Data.SqlDbType.VarChar,255){ Value=model.lunwenlingyu},
                new SqlParameter("tongxunzuozhe",System.Data.SqlDbType.VarChar,255){Value= model.tongxunzuozhe},
                new SqlParameter("kanwumingcheng",System.Data.SqlDbType.VarChar,255){ Value=model.kanwumingcheng},
                new SqlParameter("duzhu", System.Data.SqlDbType.VarChar, 255) { Value = model.duzhu },
                new SqlParameter("EI",System.Data.SqlDbType.VarChar,255){Value=model.EI},
                new SqlParameter("ISTP",System.Data.SqlDbType.VarChar,255){Value=model.ISTP},
                new SqlParameter("ISSHP",System.Data.SqlDbType.VarChar,255){Value=model.ISSHP},
                new SqlParameter("PKU",System.Data.SqlDbType.VarChar,255){Value=model.PKU},
                new SqlParameter("SCD",System.Data.SqlDbType.VarChar,255){Value=model.SCD},
                new SqlParameter("CSCDE",System.Data.SqlDbType.VarChar,255){Value=model.CSCDE},
                new SqlParameter("省级期刊",System.Data.SqlDbType.VarChar,255){Value=model.省级期刊},
                new SqlParameter("ESCI",System.Data.SqlDbType.VarChar,255){Value=model.ESCI},
                new SqlParameter("SSCI",System.Data.SqlDbType.VarChar,255){Value=model.SSCI},
                new SqlParameter("其他",System.Data.SqlDbType.VarChar,255){Value=model.其他},
                new SqlParameter("CSCD",System.Data.SqlDbType.VarChar,255){Value=model.CSCD},
                new SqlParameter("CSSCI扩展版",System.Data.SqlDbType.VarChar,255){Value=model.CSSCI扩展版},
                new SqlParameter("CSSCI",System.Data.SqlDbType.VarChar,255){Value=model.CSSCI},
                new SqlParameter("自然指数杂志",System.Data.SqlDbType.VarChar,255){Value=model.自然指数杂志},
                new SqlParameter("SCIE",System.Data.SqlDbType.VarChar,255){Value=model.SCIE},
                new SqlParameter("SCI",System.Data.SqlDbType.VarChar,255){Value=model.SCI},
                new SqlParameter("会议期刊",System.Data.SqlDbType.VarChar,255){Value=model.会议期刊},
                new SqlParameter("科研核心",System.Data.SqlDbType.VarChar,255){Value=model.科研核心},
                new SqlParameter("国家级期刊",System.Data.SqlDbType.VarChar,255){Value=model.国家级期刊},
                new SqlParameter("AHCI",System.Data.SqlDbType.VarChar,255){Value=model.AHCI},
                new SqlParameter("DOI号",System.Data.SqlDbType.VarChar,255){Value=model.DOI号},
new SqlParameter("引用次数",System.Data.SqlDbType.VarChar,255){Value=model.引用次数},
new SqlParameter("关键词",System.Data.SqlDbType.VarChar,255){Value=model.关键词},
new SqlParameter("起止页码",System.Data.SqlDbType.VarChar,255){Value=model.起止页码},
new SqlParameter("关联课题",System.Data.SqlDbType.VarChar,255){Value=model.关联课题},
new SqlParameter("成果同步",System.Data.SqlDbType.VarChar,255){Value=model.成果同步},
new SqlParameter("影响因子",System.Data.SqlDbType.VarChar,255){Value=model.影响因子},
new SqlParameter("卷号",System.Data.SqlDbType.VarChar,255){Value=model.卷号},
new SqlParameter("期号",System.Data.SqlDbType.VarChar,255){Value=model.期号},
new SqlParameter("ISSN号",System.Data.SqlDbType.VarChar,255){Value=model.ISSN号},
new SqlParameter("CN号",System.Data.SqlDbType.VarChar,255){Value=model.CN号},
new SqlParameter("摘要",System.Data.SqlDbType.VarChar,255){Value=model.摘要},
new SqlParameter("备注信息",System.Data.SqlDbType.VarChar,255){Value=model.备注信息},
                new SqlParameter("校内核心",System.Data.SqlDbType.VarChar,255){Value=model.校内核心} };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);

        }
    }
}
