

using System;

namespace Models
{
    //用户信息实体类
    public class UserInfo
    {
        //用户编号
        public string username { get; set; }
        public string name { get; set; }
        public string realname { get; set; }
        public string professional { get; set; }
        public string degree { get; set; }
        public string email { get; set; }
        public string birthday { get; set; }
        public string qq { get; set; }
        public string telephone_number { get; set; }
        public string wechat { get; set; }
        public string research_direction { get; set; }
        public DateTime CreatedDate { get; set; } 
        public string Avater { get; set; }
    }
}
