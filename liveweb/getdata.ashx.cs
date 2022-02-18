using Bll;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Xml.Linq;
using Models;


namespace liveweb
{
    /// <summary>
    /// getdata 的摘要说明
    /// </summary>
    public class getdata : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "application/json";
            //接收提交过来的meth参数
            string meth = context.Request.Params["meth"].ToString();
            string name = context.Request.Params["name"].ToString();
           
            //根据参数调用不同的方法
            SqlConnection conn = new SqlConnection();

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
                        paperid=context.Request.Params["paperid"].ToString(),
                        lunwenleixing = context.Request.Params["lunwenleixing"].ToString(),
                        lunwenlingyu = context.Request.Params["lunwenlingyu"].ToString(),
                        duzhu = context.Request.Params["duzhu"].ToString(),
                        tongxunzuozhe = context.Request.Params["tongxunzuozhe"].ToString(),
                        kanwumingcheng =context.Request.Params["kanwumingcheng"].ToString(),
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
                        AHCI = context.Request.Params["AHCI"].ToString(),
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
                    int r = bll.Update(model);
                    context.Response.Write(r);
                    break;
                default:
                    conn.ConnectionString = "Password=Su56656488xin@;User ID=sa;Initial Catalog=liveweb;Data Source=114.96.100.98";
                    conn.Open();
                    string sql = "select * from " + meth + " where username=" + name+"";
                    //定义字符串，" "中的字符串可以在sql server中运行，运行结果就是一会要读取的数据表，表名为上面数据库名称里面的表； 
                    SqlCommand sqlcomm = new SqlCommand(sql, conn);
                    //连接到表
                    SqlDataAdapter dataAdpter = new SqlDataAdapter(sqlcomm);//通过数据适配器执行命令
                    DataTable dt = new DataTable();//创建一张临时数据表
                    dataAdpter.Fill(dt);//将命令执行的结果存入临时数据表
                    conn.Dispose();

                    context.Response.Write(ToJson(dt));
                    break;

            }
        }
       

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        
        //对象转换为Json字符串 
        public static string ToJson(object jsonObject)
        {
            object objectValue = string.Empty;
            string jsonString = "{";
            if (jsonObject == null)
            {
                return jsonString + "}";
            }
            PropertyInfo[] propertyInfo = jsonObject.GetType().GetProperties();
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                try
                {
                    objectValue = propertyInfo[i].GetGetMethod().Invoke(jsonObject, BindingFlags.InvokeMethod, null, new object[] { }, null);
                    string value = string.Empty;
                    if (objectValue is DateTime || objectValue is Guid || objectValue is TimeSpan)
                    {
                        value = "'" + objectValue.ToString() + "'";
                    }
                    else if (objectValue is string)
                    {
                        value = "'" + ToJson(objectValue.ToString()) + "'";
                    }
                    else if (objectValue is IEnumerable)
                    {
                        value = ToJson((IEnumerable)objectValue);
                    }
                    else
                    {
                        value = ToJson(objectValue.ToString());
                    }
                    jsonString += "\"" + ToJson(propertyInfo[i].Name) + "\":" + value + ",";
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
            }
            jsonString.Remove(jsonString.Length - 1);
            return jsonString + "}";
        }

        //对象集合转换Json
        public static string ToJson(IEnumerable array)
        {
            if (array == null) return "";
            string jsonString = "[";
            foreach (object item in array)
            {
                jsonString += ToJson(item) + ",";
            }
            jsonString.Remove(jsonString.Length - 1);
            return jsonString + "]";
        }
        //普通集合转换Json
        public static string ToArrayString(IEnumerable array)
        {
            if (array == null) return "";
            string jsonString = "[";
            foreach (object item in array)
            {
                jsonString = ToJson(item.ToString()) + ",";
            }
            jsonString.Remove(jsonString.Length - 1, jsonString.Length);
            return jsonString + "]";
        }
        //Datatable转换为Json 
        public static string ToJson(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0) return "[{}]";
            StringBuilder jsonString = new StringBuilder();

            jsonString.Append("[");
            DataRowCollection drc = dt.Rows;
            for (int i = 0; i < drc.Count; i++)
            {
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string strKey = dt.Columns[j].ColumnName;
                    string strValue = drc[i][j].ToString();
                    Type type = dt.Columns[j].DataType;
                    jsonString.Append("\"" + strKey + "\":");
                    strValue = StringFormat(strValue, type);
                    if (j < dt.Columns.Count - 1)
                        jsonString.Append(strValue + ",");
                    else
                        jsonString.Append(strValue);
                }
                jsonString.Append("},");
            }
            jsonString.Remove(jsonString.Length - 1, 1);
            jsonString.Append("]");
            return jsonString.ToString();
        }
        //DataTable转成Json 
        public static string ToJson(DataTable dt, string jsonName)
        {
            if (string.IsNullOrEmpty(jsonName))
                jsonName = dt.TableName;
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"" + jsonName + "\":[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Type type = dt.Rows[i][j].GetType();
                        sb.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + StringFormat(dt.Rows[i][j].ToString(), type));
                        if (j < dt.Columns.Count - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
            }
            sb.Append("]}");
            return sb.ToString();
        }

        //DataReader转换为Json 
        public static string ToJson(DbDataReader dataReader)
        {
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            while (dataReader.Read())
            {
                jsonString.Append("{");
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    Type type = dataReader.GetFieldType(i);
                    string strKey = dataReader.GetName(i);
                    string strValue = dataReader[i].ToString();
                    jsonString.Append("\"" + strKey + "\":");
                    strValue = StringFormat(strValue, type);
                    if (i < dataReader.FieldCount - 1)
                    {
                        jsonString.Append(strValue + ",");
                    }
                    else
                    {
                        jsonString.Append(strValue);
                    }
                }
                jsonString.Append("},");
            }
            dataReader.Close();
            jsonString.Remove(jsonString.Length - 1, 1);
            jsonString.Append("]");
            return jsonString.ToString();
        }

        //DataSet转换为Json 
        public static string ToJson(DataSet dataSet)
        {
            string jsonString = "{";
            foreach (DataTable table in dataSet.Tables)
            {
                jsonString += "\"" + table.TableName + "\":" + ToJson(table) + ",";
            }
            jsonString = jsonString.TrimEnd(',');
            return jsonString + "}";
        }
        //ArrayList转化为json
        public static string ArryListToJson(ArrayList alist, string jsonName)
        {
            string json = string.Empty;
            string strSubList = "\"" + jsonName + "\":" + "[{";
            for (int i = 0; i < alist.Count; i++)
            {
                Hashtable ht1 = (Hashtable)alist[i];
                foreach (DictionaryEntry de in ht1)
                {
                    if (de.Value is ArrayList)
                    {
                        strSubList += ArryListToJson((ArrayList)de.Value, de.Key.ToString());
                        strSubList += "]";
                    }
                    else
                    {
                        strSubList += "\"" + de.Key + "\":" + "\"" + de.Value + "\",";
                    }
                }
                strSubList = strSubList.Remove(strSubList.Length - 1);
                strSubList += "},{";
            }
            if (strSubList.Length >= 2)
            {
                json = strSubList.Remove(strSubList.Length - 2);
            }
            json += "]";
            return json;
        }
        //Hashtable To Json
        public static string HashtableToJson(Hashtable hr)
        {
            string json = "{";
            foreach (DictionaryEntry row in hr)
            {
                try
                {
                    string key = "\"" + row.Key + "\":";
                    string value = string.Empty;

                    if (row.Value is ArrayList)
                    {
                        key = string.Empty;
                        value = ArryListToJson((ArrayList)row.Value, row.Key.ToString());
                        value += ",";
                    }
                    else
                    {
                        value = "\"" + (row.Value == null ? "" : row.Value.ToString()) + "\",";
                    }
                    json += key + value;
                }
                catch (Exception ex)
                {
                    string mess = ex.Message;
                }
            }
            json = json.Remove(json.Length - 1);
            json = json + "}";
            return json;
        }
        //转换字符格式
        private static string StringFormat(string str, Type type)
        {
            if (string.IsNullOrEmpty(str)) return "\"\"";
            if (type == typeof(string))
            {
                str = "\"" + ConvertStrToSpecificationStrs(str) + "\"";
            }
            else if (type == typeof(DateTime))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(bool))
            {
                str = str.ToLower();
            }
            return str;
        }
        //json转换为datatable
        public static DataTable JsonToDataTable(string json)
        {
            DataTable table = new DataTable();
            //JsonStr为Json字符串
            JArray array = JsonConvert.DeserializeObject(json) as JArray;//反序列化为数组
            if (array.Count > 0)
            {
                StringBuilder columns = new StringBuilder();
JObject objColumns = array[0] as JObject;
//构造表头
                foreach (JToken jkon in objColumns.AsEnumerable<JToken>())
                {
                    string name = ((JProperty)(jkon)).Name;
                    columns.Append(name + ",");
                    table.Columns.Add(name);
                }
                //向表中添加数据
                for (int i = 0; i < array.Count; i++)
                {
                    DataRow row = table.NewRow();
JObject obj = array[i] as JObject;
                    foreach (JToken jkon in obj.AsEnumerable<JToken>())
                    {

                        string name = ((JProperty)(jkon)).Name;
                        string value = ((JProperty)(jkon)).Value.ToString();
                        row[name] = value;
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }
        //转换字符格式
        public static string ConvertStrToSpecificationStrs(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                char cStr = str.ToCharArray()[i];

                switch (cStr)
                {
                    case '\"':
                        sb.Append("\\\""); break;
                    case '\\':
                        sb.Append("\\\\"); break;
                    case '/':
                        sb.Append("\\/"); break;
                    case '\b':
                        sb.Append("\\b"); break;
                    case '\f':
                        sb.Append("\\f"); break;
                    case '\n':
                        sb.Append("\\n"); break;
                    case '\r':
                        sb.Append("\\r"); break;
                    case '\t':
                        sb.Append("\\t"); break;
                    default:
                        sb.Append(cStr); break;
                }
            }
            return sb.ToString();
        }

        }

    }