using DAl;
using Models;

namespace Bll
{
    public class UserInfoBll
    {
        UserInfoDal dal = new UserInfoDal();
        public int logincheck(string user, string pwd)
        {
            return dal.logincheck(user, pwd);
        }
        public int signincheck(string user)
        {
            return dal.signincheck(user);
        }
        public int Insert(UserInfo model)//插入数据
        {
            return dal.Insert(model);
        }
    }
}
