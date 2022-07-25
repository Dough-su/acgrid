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
        public int update(UserInfo model)
        { 
        return dal.update(model);
        }
        public int signincheck(string user)
        {
            return dal.signincheck(user);
        }
        public int Insert(UserInfo model)//插入数据
        {
            return dal.Insert(model);
        }
        public int ListUserInfo(string username)
        { 
            return dal.ListUserInfo(username);
        }
        public int Avater(string username, string Avater)
        { 
            return dal.Avater(username, Avater);
        }
    }
}
