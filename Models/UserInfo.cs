

using System;

namespace Models
{
    //用户信息实体类
    public class UserInfo
    {
        //用户编号
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
