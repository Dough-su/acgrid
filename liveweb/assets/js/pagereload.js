//此文件是翻页重新加载数据所用js，函数头应以reload开头，并加入后面与之匹配的页面，例如论文页面需用"reloadlunwen"
function reloadlunwen(number) {
    $.ajax(
        {
            url: "json.txt",//请求地址
            type: "get",//请求方式
            dataType: "json",//接收文件类型
            success: function (data)//data是形参
            {
                $(".btn-group").empty();//将分页清空
                var xiamian = Math.ceil(data.length / 10);
                $("#lunwen").empty();
                for (var i = (number - 1) * 10; i < number * 10; i++)//填充文档内容
                {
                    $("#lunwen").append('  <tr class="transform"><td style="padding-top: 19px;"><input type="checkbox"></td><td style="padding-top: 19px;">' + data[i].code + '</td><td><img src="https://img.okay.do/acagrid/static/build/images/info/file_large.png" style="width: 39px;height: 49.3px;">' + data[i].name + '</td><td style="padding-top: 19px;">3</td><td style="padding-top: 19px;">2022-2-11</td><td><div class="dropdown"><button class="btn btn-primary dropdown-toggle dropdown-toggle" aria-expanded="false" data-bs-toggle="dropdown" id="daochu" style="margin-top: 5px;margin-left: 0px;margin-right: 40px;/*float: right;*/background-color: rgba(60,33,247,.75);">更多</button><div class="dropdown-menu"><a class="dropdown-item" href="#">编辑</a><a class="dropdown-item" href="#">分享</a><a class="dropdown-item" href="#" style="color: rgb(255,3,3);">删除</a></div></div><a href="#" style="margin-top: 12px;padding-top: 0px;float: left;color: #6d59f9;">下载</a><a href="#" style="margin-top: 12px;float: left;margin-left: 18px;color: #6d59f9;">导出</a><div class="dropdown"><button class="btn btn-primary dropdown-toggle dropdown-menu" aria-expanded="false" data-bs-toggle="dropdown">Dropdown </button><div class="dropdown-menu"><a class="dropdown-item" href="#">First Item</a><a class="dropdown-item" href="#">Second Item</a><a class="dropdown-item" href="#">Third Item</a></div></div></td></tr><tr></tr>')
                }
                if (i != number)//判断序号是不是当前页面
                {
                    for (var i = 1; i <= xiamian; i++) {


                        $(".btn-group").append('<button class="btn btn-primary" type="button" onclick="reloadlunwen('+i+')" style="background: #6d59f9;border-style: none;border-radius: 10px;margin-left: 3px;">'+data[i].code+'</button>');
                    }

                }
            }
        })
}