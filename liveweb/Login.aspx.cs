using Bll;
using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace liveweb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<script>'loginsignexist()'</script>");
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)//登录按钮
        {
            if(user.Value!="")
            {
                if (passwd.Value != "")
                {
                    UserInfoBll bll = new UserInfoBll();
                    string usern = user.Value.Trim();
                    string pwd = passwd.Value.Trim();
                    Md5Helper common = new Md5Helper();
                    bool check = Convert.ToBoolean(bll.logincheck(usern, common.GetMd5(pwd)));
                    if (check)//登陆成功则跳转
                    {
                        Response.Redirect("/index.html");
                    }
                    else
                    {
                        Page.RegisterStartupScript("", "<script>alert('用户名或密码错误')</script>");
                    }
                }
                else Page.RegisterStartupScript("", "<script>alert('密码为空')</script>");

            }
            Page.RegisterStartupScript("", "<script>alert('用户名为空')</script>");

        }

        protected void btn_ServerClick(object sender, EventArgs e)//注册按钮
        {
            if (user.Value != "")
            {
                if (passwd.Value != "")//确保密码不为空
                {

                    if (confirm_passwd.Value == passwd.Value)//确保两次密码相同
                    {
                        UserInfoBll bll = new UserInfoBll();
                        string usern = user.Value.Trim();
                        bool check = Convert.ToBoolean(bll.signincheck(usern));//防止重复注册
                        if (!check)//如果用户名不重复则可以执行
                        {
                            string pwd = passwd.Value.Trim();
                            Md5Helper common = new Md5Helper();
                            UserInfo model = new UserInfo//封装注册所需的model
                            {
                                UserName = usern,
                                UserPwd = common.GetMd5(pwd),
                                CreatedDate = DateTime.Now,
                                Phone = "",
                                Email = "",

                            };
                            bool checksign = Convert.ToBoolean(bll.Insert(model));
                            if (checksign) Page.RegisterStartupScript("", "<script>alert('注册成功')</script>");
                            else Page.RegisterStartupScript("", "<script>alert('注册失败')</script>");
                        }
                        else Page.RegisterStartupScript("", "<script>alert('用户名已存在')</script>");
                    }
                    else Page.RegisterStartupScript("", "<script>alert('两次密码不一致')</script>");
                }
                else Page.RegisterStartupScript("", "<script>alert('密码为空')</script>");
            }
            else Page.RegisterStartupScript("", "<script>alert('用户名为空')</script>");

        }
    }
}