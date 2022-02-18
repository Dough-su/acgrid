<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Login.aspx.cs" Inherits="liveweb.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <link rel="icon" type="image/x-icon" href="#" />
    <link type="text/css" rel="styleSheet"  href="css/main.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>账号登录</title>
</head>
<body>
    <form id="form1" runat="server">
         <div id="bg">
        <div id="hint"><!-- 提示框 -->
            <p>登录失败</p>
        </div>
        <div id="login_wrap">
            <div id="login"><!-- 登录注册切换动画 -->
                <div id="status">
                    <i style="top: 0">登</i>
                    <i style="top: 35px">注</i>
                    <i style="right: 5px">入</i>
                    <i style="top: 35px ">册</i>
                </div>
                <span>
                    <form action="post">
                        <p class="form"><input type="text" runat="server" id="user" placeholder="用户名"></p>
                        <p class="form"><input type="password" runat="server" id="passwd" placeholder="密码"></p>
                        <p class="form confirm"><input type="password" runat="server" id="confirm_passwd" placeholder="确认密码"></p>
                        <input type="button" value="登入" class="btn" runat="server" onclick="javascript:if(login())" onserverclick="Unnamed_ServerClick" style="margin-right: 20px;">
                        <input type="button" value="注册" class="btn" runat="server" onclick="javascript:if(signin())" onserverclick="btn_ServerClick" id="btn">
                    </form>
                    <a href="#">忘记密码了?</a>
                </span>
            </div>

            <div id="login_img"><!-- 图片绘制框 -->
                <span class="circle">
                    <span></span>
                    <span></span>
                </span>
                <span class="star">
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                </span>
                <span class="fly_star">
                    <span></span>
                    <span></span>
                </span>
                <p id="title">CLOUD</p>
            </div>
        </div>
    </div>
    </form>
</body>
<script>
    var onoff = true//根据此布尔值判断当前为注册状态还是登录状态
    var confirm = document.getElementsByClassName("confirm")[0]
    var user = document.getElementById("user")
    var passwd = document.getElementById("passwd")
    var con_pass = document.getElementById("confirm_passwd")
    
    //自动居中title
    var name_c = document.getElementById("title")
    name = name_c.innerHTML.split("")
    name_c.innerHTML = ""
    for (i = 0; i < name.length; i++)
        if (name[i] != ",")
            name_c.innerHTML += "<i>" + name[i] + "</i>"
    //引用hint()在最上方弹出提示
    function hint() {
        let hit = document.getElementById("hint")
        hit.style.display = "block"
        setTimeout("hit.style.opacity = 1", 0)
        setTimeout("hit.style.opacity = 0", 2000)
        setTimeout('hit.style.display = "none"', 3000)
    }


    //注册按钮
    function signin() {
        let status = document.getElementById("status").getElementsByTagName("i")
        let hit = document.getElementById("hint").getElementsByTagName("p")[0]
        if (onoff) {
            confirm.style.height = 51 + "px"
            status[0].style.top = 35 + "px"
            status[1].style.top = 0
            status[2].style.top=35+"px"
            status[2].style.right=0
            status[3].style.top=0
            status[3].style.right=5+"px"
            onoff = !onoff
        } else {
            return true
           
        }
    }

    //登录按钮
    function login() {
        if (onoff) {
            return true
        } else {
            let status = document.getElementById("status").getElementsByTagName("i")
            confirm.style.height = 0
            status[0].style.top = 0
            status[1].style.top = 35 + "px"
            status[3].style.top=35+"px"
            status[3].style.right=0
            status[2].style.top=0
            status[2].style.right=5+"px"

            onoff = !onoff
            return false
        }
    }

    </script>
</html>
