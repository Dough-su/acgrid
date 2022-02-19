using Bll;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
             string json = "{\"msg\":\"上传成功!\"}";
            try
            {

                //接收提交过来的meth参数
                string meth = context.Request.Params["meth"].ToString();

                switch (meth)
                {

                    case "lunwenbianji":
                        lunwenBll bll = new lunwenBll();
                        //1。采集数据，封装model
                        lunwen model = new lunwen
                        {
                            name = context.Request.Params["name"].ToString(),
                            code = context.Request.Params["code"].ToString(),
                            rank = context.Request.Params["rank"].ToString(),
                            time = context.Request.Params["time"].ToString(),
                            download = context.Request.Params["download"].ToString(),
                            export = context.Request.Params["export"].ToString(),
                            edit = context.Request.Params["edit"].ToString(),
                            share = context.Request.Params["share"].ToString(),
                            username = context.Request.Params["username"].ToString(),
                            CSSCI = context.Request.Params["CSSCI"].ToString(),
                            CSCD = context.Request.Params["CSCD"].ToString(),
                            paperid = context.Request.Params["paperid"].ToString(),
                            lunwenleixing = context.Request.Params["lunwenleixing"].ToString(),
                            lunwenlingyu = context.Request.Params["lunwenlingyu"].ToString(),
                            duzhu = context.Request.Params["duzhu"].ToString(),
                            tongxunzuozhe = context.Request.Params["tongxunzuozhe"].ToString(),
                            kanwumingcheng = context.Request.Params["kanwumingcheng"].ToString(),
                            EI = context.Request.Params["EI"].ToString(),
                            ISTP = context.Request.Params["ISTP"].ToString(),
                            ISSHP = context.Request.Params["ISSHP"].ToString(),
                            PKU = context.Request.Params["PKU"].ToString(),
                            SCD = context.Request.Params["SCD"].ToString(),
                            CSCDE = context.Request.Params["CSCDE"].ToString(),
                            省级期刊 = context.Request.Params["省级期刊"].ToString(),
                            ESCI = context.Request.Params["ESCI"].ToString(),
                            SSCI = context.Request.Params["SSCI"].ToString(),
                            其他 = context.Request.Params["其他"].ToString(),
                            CSSCI扩展版 = context.Request.Params["CSSCI扩展版"].ToString(),
                            自然指数杂志 = context.Request.Params["自然指数杂志"].ToString(),
                            SCIE = context.Request.Params["SCIE"].ToString(),
                            SCI = context.Request.Params["SCI"].ToString(),
                            会议期刊 = context.Request.Params["会议期刊"].ToString(),
                            科研核心 = context.Request.Params["科研核心"].ToString(),
                            国家级期刊 = context.Request.Params["国家级期刊"].ToString(),
                            AHCI = context.Request.Params["AHCI"].ToString().ToString(),
                            校内核心 = context.Request.Params["校内核心"].ToString(),
                            DOI号 = context.Request.Params["DOI号"].ToString(),
                            引用次数 = context.Request.Params["引用次数"].ToString(),
                            关键词 = context.Request.Params["关键词"].ToString(),
                            起止页码 = context.Request.Params["起止页码"].ToString(),
                            关联课题 = context.Request.Params["关联课题"].ToString(),
                            成果同步 = context.Request.Params["成果同步"].ToString(),
                            影响因子 = context.Request.Params["影响因子"].ToString(),
                            卷号 = context.Request.Params["卷号"].ToString(),
                            期号 = context.Request.Params["期号"].ToString(),
                            ISSN号 = context.Request.Params["ISSN号"].ToString(),
                            CN号 = context.Request.Params["CN号"].ToString(),
                            摘要 = context.Request.Params["摘要"].ToString(),
                            备注信息 = context.Request.Params["备注信息"].ToString(),



                        };
                        

                        context.Response.Write(bll.Insert(model));
                        break;
                        case "ruanjianbianji":
                        ruanjianzhuzuoquanbll bll_1 = new ruanjianzhuzuoquanbll();
                        //1。采集数据，封装model
                        ruanjianzhuzuoquan model_1 = new ruanjianzhuzuoquan
                        {
                            name = context.Request.Params["name"].ToString(),
                            证书号 = context.Request.Params["证书号"].ToString(),
                            download = context.Request.Params["download"].ToString(),
                            export = context.Request.Params["export"].ToString(),
                            edit = context.Request.Params["edit"].ToString(),
                            share = context.Request.Params["share"].ToString(),
                            username = context.Request.Params["username"].ToString(),
                            code = context.Request.Params["code"].ToString(),
                            paperid = context.Request.Params["paperid"].ToString(),
                            rank = context.Request.Params["rank"].ToString(),
                            开发完成时间 = context.Request.Params["开发完成时间"].ToString(),
                            获得时间 = context.Request.Params["获得时间"].ToString(),
                            成果同步 = context.Request.Params["成果同步"].ToString(),
                            登记号 = context.Request.Params["登记号"].ToString(),
                            著作权类型 = context.Request.Params["著作权类型"].ToString(),
                            著作权人 = context.Request.Params["著作权人"].ToString(),
                            关联课题 = context.Request.Params["关联课题"].ToString(),
                            备注信息 = context.Request.Params["备注信息"].ToString(),
                        };
                        context.Response.Write(bll_1.Insert(model_1));
                        break;
                    default:
                        context.Response.ContentType = "text/plain";
                        Stream sr = context.Request.InputStream;
                        byte[] bt = new byte[sr.Length];
                        HttpPostedFile file = context.Request.Files["model_file"];
                        string savepath = context.Request["savepath"];//获取文件保存的路径
                        string paperid = context.Request["paperid"];//获取名字
                        sr.Read(bt, 0, bt.Length);
                        savepath = context.Server.MapPath(savepath) + "\\" + paperid + ".pdf";
                        FileStream fs = new FileStream(savepath, FileMode.Create);
                        fs.Write(bt, 0, bt.Length);
                        fs.Close();
                        sr.Close();
                        break;
                }



            }
            catch (Exception ex)
            {
                //失败时返回的参数必须加 error键
                json = "{\"error\":\"" + ex.Message + "\"}";
            }
             context.Response.Write(json);
             context.Response.End();
         }
 

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}