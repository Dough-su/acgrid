
function sidebarload()//此js为页面首次加载时的js，直接在此函数内写入即可
{
    //侧边栏加载
    $.ajax({
        type:"get",
        url:"getdata.ashx",
        data:{"name":"6666","meth":"sidebar"},
        dataType:"json",
        success: function(data){
            console.log(data);       
       $("#cebian").empty();//清空内容
       $("#cebian").append('<li class="nav-item active" role="presentation" style="border-radius: 20px;"><a class="nav-link" role="tab" data-bs-toggle="tab" style="background: rgba(60,33,247,.75);color: rgb(255,255,255);font-size: 18px;font-weight: bold;border-radius: 4px;" disable="enabled">资料夹</a></li>');
       $("#cebian").append('<li class="nav-item sideitems" role="presentation"><a class="nav-link linkside" role="tab" data-bs-toggle="tab" href="#tab-2"><i class="fa fa-newspaper-o sidebaritem" style="margin-right: 9px;"></i><span style="font-weight: bold;">'+data[0].name+'</span><span id="jishuqi" class="badge" style="border-radius: 25px;">'+data[0].code+'</span></a></li>');
       for(var i=1;i<data.length-1;i++)
       { 
       j=i+2;
       $("#cebian").append('<li class="nav-item sideitems"role="presentation"><a class="nav-link linkside" role="tab" data-bs-toggle="tab" id="ruanjianzuzuouan" href="#tab-'+data[i].tab+'"><i class="'+data[i].icon+'" style="margin-right: 13px;"></i><span class="sidebaritem">'+data[i].name+'</span><span class="sidebaritem"></span><span id="jishuqi" class="badge" style="border-radius: 25px;">'+data[i].code+'</span></a></li>')
       }
       $("#cebian").append('<li class="nav-item" role="presentation"><a class="nav-link" role="tab" data-bs-toggle="tab" style="background: rgba(60,33,247,.75);color: rgb(255,255,255);font-size: 18px;font-weight: bold;margin-top: 49px;border-radius: 4px;" disable="enabled">回收站</a></li><li class="nav-item sideitems" role="presentation"><a class="nav-link linkside" role="tab" data-bs-toggle="tab" href="#tab-9"><i class="fa fa-trash-o sidebaritem" style="margin-right: 17px;"></i><span class="sidebaritem">'+data[9].name+'</span><span id="jishuqi" class="badge" style="border-radius: 25px;">'+data[9].code+'</span></a></li>');
        }
    });
    //论文加载
    $.ajax(
            {
            url:"getdata.ashx",
                type:"get",
                data:{"name":"6666","meth":"lunwen"},
                dataType:"json",
                success:function(data)
                {
                  var xiamian=data.length/10;//10是每页内容的最大数量 data.length是所有内容数量 xiamian是分出的几页
                  $("#lunwenbutton").empty();//清空分页
                  $("#lunwen").empty();//清空内容
                  for(var i=0;i<10;i++)//将第一页内容填充进去
                  {
                    $("#lunwen").append('  <tr class="transform"><td style="padding-top: 19px;"><input type="checkbox"></td><td style="padding-top: 19px;">'+data[i].code+'</td><td><img src="https://img.okay.do/acagrid/static/build/images/info/file_large.png" style="width: 39px;height: 49.3px;">'+data[i].name+'</td><td style="padding-top: 19px;">3</td><td style="padding-top: 19px;">2022-2-11</td><td><div class="dropdown"><button class="btn btn-primary dropdown-toggle dropdown-toggle" aria-expanded="false" data-bs-toggle="dropdown" id="daochu" style="margin-top: 5px;margin-left: 0px;margin-right: 40px;/*float: right;*/background-color: rgba(60,33,247,.75);">更多</button><div class="dropdown-menu"><a class="dropdown-item" href="#">编辑</a><a class="dropdown-item" href="#">分享</a><a class="dropdown-item" href="#" style="color: rgb(255,3,3);">删除</a></div></div><a href="#" style="margin-top: 12px;padding-top: 0px;float: left;color: #6d59f9;">下载</a><a href="#" style="margin-top: 12px;float: left;margin-left: 18px;color: #6d59f9;">导出</a><div class="dropdown"><button class="btn btn-primary dropdown-toggle dropdown-menu" aria-expanded="false" data-bs-toggle="dropdown">Dropdown </button><div class="dropdown-menu"><a class="dropdown-item" href="#">First Item</a><a class="dropdown-item" href="#">Second Item</a><a class="dropdown-item" href="#">Third Item</a></div></div></td></tr><tr></tr>')
                  }
                  if(xiamian>1)//如果分出的页数大于1（内容超出十个）
                  {
                      //加入第一页
                      $("#lunwenbutton").append('<button class="btn btn-primary active" type="button" style="background: #6d59f9;border-style: none;border-radius: 10px;margin-left: 10px;">1</button>');
                      for(var i=2;i<=xiamian;i++)//加入后面存在的页数，i从2开始。
                      {
                          $("#lunwenbutton").append('<button class="btn btn-primary" type="button" onclick="reloadlunwen('+i+')"  style="background: #aba3e6;border-style: none;border-radius: 10px;margin-left: 3px;">'+i+'</button></div>')
                      }
                  }
                },
                err:function(err){
                    alert(err);
               }
           }
        )
    //软件著作权加载
    $.ajax(
                {
                    url:"json.txt",
                    type:"get",
                    dataType:"json",
                    success:function(data)
                    {
                      var xiamian=data.length/10;//10是每页内容的最大数量 data.length是所有内容数量 xiamian是分出的几页
                      $("#ruanjianbutton").empty();//清空分页
                      $("#ruanjianzhuzuoquan").empty();//清空内容
                      for(var i=0;i<10;i++)//将第一页内容填充进去
                      {
                        $("#ruanjianzhuzuoquan").append('<tr class="transform"><td style="padding-top: 19px;"><input type="checkbox"></td><td><img src="https://img.okay.do/acagrid/static/build/images/info/file_large.png" style="width: 39px;height: 49.3px;">'+data[i].name+'</td><td style="padding-top: 19px;">'+data[i].type+'</td><td style="padding-top: 19px;">'+data[i].time+'</td><td><div class="dropdown"><button class="btn btn-primary dropdown-toggle dropdown-toggle" aria-expanded="false" data-bs-toggle="dropdown" id="daochu-1" style="margin-top: 5px;margin-left: 0px;margin-right: 38px;background-color: rgba(60,33,247,.75);float: right;">更多</button><div class="dropdown-menu"><a class="dropdown-item" href="#">编辑</a><a class="dropdown-item" href="#">分享</a><a class="dropdown-item" href="#" style="color: rgb(255,3,3);">删除</a></div></div><a href="#" style="margin-top: 12px;padding-top: 0px;float: left;color: #6d59f9;">下载</a><a href="#" style="margin-top: 12px;float: left;margin-left: 18px;color: #6d59f9;">导出</a><div class="dropdown"><button class="btn btn-primary dropdown-toggle dropdown-menu" aria-expanded="false" data-bs-toggle="dropdown">Dropdown </button><div class="dropdown-menu"><a class="dropdown-item" href="#">First Item</a><a class="dropdown-item" href="#">Second Item</a><a class="dropdown-item" href="#">Third Item</a></div></div></td></tr><tr></tr>')
                      }
                      if(xiamian>1)//如果分出的页数大于1（内容超出十个）
                      {
                          //加入第一页
                          $("#ruanjianbutton").append('<button class="btn btn-primary active" type="button" style="background: #6d59f9;border-style: none;border-radius: 10px;margin-left: 10px;">1</button>');
                          for(var i=2;i<=xiamian;i++)//加入后面存在的页数，i从2开始。
                          {
                              $("#ruanjianbutton").append('<button class="btn btn-primary" type="button" onclick="reloadruanjian('+i+')"  style="background: #aba3e6;border-style: none;border-radius: 10px;margin-left: 3px;">'+i+'</button></div>')
                          }
                      }
                    },
                    err:function(err){
                        alert(err);
                   }
               }
            )



    //专利加载
    $.ajax(
                {
                    url:"json.txt",
                    type:"get",
                    dataType:"json",
                    success:function(data)
                    {
                      var xiamian=data.length/10;//10是每页内容的最大数量 data.length是所有内容数量 xiamian是分出的几页
                      $("#zhuanlibutton").empty();//清空分页
                      $("#zhuanli").empty();//清空内容
                      for(var i=0;i<10;i++)//将第一页内容填充进去
                      {
                        $("#zhuanli").append('<tr class="transform" style="height: 65px;"><td style="padding-top: 20px;"><input type="checkbox"></td><td style="width: 400px;"><img src="https://img.okay.do/acagrid/static/build/images/info/file_large.png" style="width: 39px;height: 49.3px;"><span class="first_yeah"'+data[i].name+'></span></td><td style="padding-top: 20px;">'+data[i].rank+'</td><td style="padding-top: 20px;">'+data[i].type+'</td><td style="padding-top: 20px;">'+data[i].time+'</td><td style="padding-top: 21px;width: 199.2px;"><div class="dropdown" style="width: 72px;float: right;margin-top: -7px;margin-left: 0px;margin-right: 17px;"><button class="btn btn-primary dropdown-toggle" aria-expanded="false" data-bs-toggle="dropdown" type="button" style="float: right;display: inline-block;background-color: rgb(109,89,249);margin-right: 9px;">更多</button><div class="dropdown-menu"><a class="dropdown-item" href="#">First Item</a><a class="dropdown-item" href="#">Second Item</a><a class="dropdown-item" href="#">Third Item</a></div></div><a href="#" style="margin-left: 0px;margin-top: 0px;padding-top: 0px;margin-bottom: 0px;padding-bottom: 0px;color: #6d59f9;">下载</a><a href="#" style="margin-top: 0px;padding-top: 0px;margin-bottom: 0px;padding-bottom: 0px;border-style: none;color: #6d59f9;margin-left: 18px;">导出</a></td></tr>')
                      }
                      if(xiamian>1)//如果分出的页数大于1（内容超出十个）
                      {
                          //加入第一页
                          $("#zhuanlibutton").append('<button class="btn btn-primary active" type="button" style="background: #6d59f9;border-style: none;border-radius: 10px;margin-left: 10px;">1</button>');
                          for(var i=2;i<=xiamian;i++)//加入后面存在的页数，i从2开始。
                          {
                              $("#zhuanlibutton").append('<button class="btn btn-primary" type="button" onclick="reloadzhuanli('+i+')"  style="background: #aba3e6;border-style: none;border-radius: 10px;margin-left: 3px;">'+i+'</button></div>')
                          }
                      }
                    },
                    err:function(err){
                        alert(err);
                   }
               }
            )

    //个人获奖
    $.ajax(
            {
                url:"json.txt",
                type:"get",
                dataType:"json",
                success:function(data)
                {
                  var xiamian=data.length/10;//10是每页内容的最大数量 data.length是所有内容数量 xiamian是分出的几页
                  $("#gerenbutton").empty();//清空分页
                  $("#gerenhuojiang").empty();//清空内容
                  for(var i=0;i<10;i++)//将第一页内容填充进去
                  {
                    $("#gerenhuojiang").append('<tr class="transform" style="height: 65px;"><td style="padding-top: 20px;"><input type="checkbox"></td><td style="width: 400px;"><img src="https://img.okay.do/acagrid/static/build/images/info/file_large.png" style="width: 39px;height: 49.3px;"><span>'+data[i].name+'</span></td><td style="padding-top: 20px;">'+data[i].award+'</td><td style="padding-top: 20px;">'+data[i].type+'</td><td style="padding-top: 20px;">'+data[i].time+'</td><td style="padding-top: 21px;"><div class="dropdown" style="width: 72px;float: right;margin-top: -7px;margin-left: 0px;margin-right: 17px;"><button class="btn btn-primary dropdown-toggle" aria-expanded="false" data-bs-toggle="dropdown" type="button" style="float: right;display: inline-block;background-color: rgb(109,89,249);">更多</button><div class="dropdown-menu"><a class="dropdown-item" href="#">First Item</a><a class="dropdown-item" href="#">Second Item</a><a class="dropdown-item" href="#">Third Item</a></div></div><a href="#" style="margin-top: 0px;padding-top: 0px;margin-bottom: 0px;padding-bottom: 0px;border-style: none;color: #6d59f9;">导出</a><a href="#" style="margin-left: 20px;margin-top: 0px;padding-top: 0px;margin-bottom: 0px;padding-bottom: 0px;color: #6d59f9;">下载</a></td></tr><tr></tr>')
                  }
                  if(xiamian>1)//如果分出的页数大于1（内容超出十个）
                  {
                      //加入第一页
                      $("#gerenbutton").append('<button class="btn btn-primary active" type="button" style="background: #6d59f9;border-style: none;border-radius: 10px;margin-left: 10px;">1</button>');
                      for(var i=2;i<=xiamian;i++)//加入后面存在的页数，i从2开始。
                      {
                          $("#gerenbutton").append('<button class="btn btn-primary" type="button" onclick="reloadgeren('+i+')"  style="background: #aba3e6;border-style: none;border-radius: 10px;margin-left: 3px;">'+i+'</button></div>')
                      }
                  }
                },
                err:function(err){
                    alert(err);
               }
           }
        )
    //学生获奖
    $.ajax(
                {
                    url:"json.txt",
                    type:"get",
                    dataType:"json",
                    success:function(data)
                    {
                      var xiamian=data.length/10;//10是每页内容的最大数量 data.length是所有内容数量 xiamian是分出的几页
                      $("#xueshengbutton").empty();//清空分页
                      $("#xueshenghuojiang").empty();//清空内容
                      for(var i=0;i<10;i++)//将第一页内容填充进去
                      {
                        $("#xueshenghuojiang").append('<tr class="transform" style="height: 65px;"><td style="padding-top: 20px;"><input type="checkbox"></td><td style="width: 400px;"><img src="https://img.okay.do/acagrid/static/build/images/info/file_large.png" style="width: 39px;height: 49.3px;"><span>'+data[i].name+'</span></td><td style="padding-top: 20px;">'+data[i].award+'</td><td style="padding-top: 20px;">'+data[i].type+'</td><td style="padding-top: 20px;">'+data[i].time+'</td><td style="padding-top: 21px;"><div class="dropdown" style="width: 72px;float: right;margin-top: -7px;margin-left: 0px;margin-right: 17px;"><button class="btn btn-primary dropdown-toggle" aria-expanded="false" data-bs-toggle="dropdown" type="button" style="float: right;display: inline-block;background-color: rgb(109,89,249);">更多</button><div class="dropdown-menu"><a class="dropdown-item" href="#">First Item</a><a class="dropdown-item" href="#">Second Item</a><a class="dropdown-item" href="#">Third Item</a></div></div><a href="#" style="margin-top: 0px;padding-top: 0px;margin-bottom: 0px;padding-bottom: 0px;border-style: none;color: #6d59f9;">导出</a><a href="#" style="margin-left: 20px;margin-top: 0px;padding-top: 0px;margin-bottom: 0px;padding-bottom: 0px;color: #6d59f9;">下载</a></td></tr><tr></tr>')
                      }
                      if(xiamian>1)//如果分出的页数大于1（内容超出十个）
                      {
                          //加入第一页
                          $("#xueshengbutton").append('<button class="btn btn-primary active" type="button" style="background: #6d59f9;border-style: none;border-radius: 10px;margin-left: 10px;">1</button>');
                          for(var i=2;i<=xiamian;i++)//加入后面存在的页数，i从2开始。
                          {
                              $("#xueshengbutton").append('<button class="btn btn-primary" type="button" onclick="reloadxuesheng('+i+')"  style="background: #aba3e6;border-style: none;border-radius: 10px;margin-left: 3px;">'+i+'</button></div>')
                          }
                      }
                    },
                    err:function(err){
                        alert(err);
                   }
               }
            )
    //著作
    $.ajax(
                {
                    url:"json.txt",
                    type:"get",
                    dataType:"json",
                    success:function(data)
                    {
                      var xiamian=data.length/10;//10是每页内容的最大数量 data.length是所有内容数量 xiamian是分出的几页
                      $("#zhuzuobutton").empty();//清空分页
                      $("#zhuzuo").empty();//清空内容
                      for(var i=0;i<10;i++)//将第一页内容填充进去
                      {
                        $("#zhuzuo").append('<tr class="transform"><td style="padding-top: 19px;"><input type="checkbox"></td><td><img src="https://img.okay.do/acagrid/static/build/images/info/file_large.png" style="width: 39px;height: 49.3px;">'+data[i].name+'</td><td style="padding-top: 19px;">'+data[i].type+'</td><td style="padding-top: 19px;">'+data[i].time+'</td><td><div class="dropdown"><button class="btn btn-primary dropdown-toggle dropdown-toggle" aria-expanded="false" data-bs-toggle="dropdown" id="daochu-2" style="margin-top: 5px;margin-left: 0px;margin-right: 38px;background-color: rgba(60,33,247,.75);float: right;">更多</button><div class="dropdown-menu"><a class="dropdown-item" href="#">编辑</a><a class="dropdown-item" href="#">分享</a><a class="dropdown-item" href="#" style="color: rgb(255,3,3);">删除</a></div></div><a href="#" style="margin-top: 12px;padding-top: 0px;float: left;color: #6d59f9;">下载</a><a href="#" style="margin-top: 12px;float: left;margin-left: 18px;color: #6d59f9;">导出</a><div class="dropdown"><button class="btn btn-primary dropdown-toggle dropdown-menu" aria-expanded="false" data-bs-toggle="dropdown">Dropdown </button><div class="dropdown-menu"><a class="dropdown-item" href="#">First Item</a><a class="dropdown-item" href="#">Second Item</a><a class="dropdown-item" href="#">Third Item</a></div></div></td></tr><tr></tr>')
                      }
                      if(xiamian>1)//如果分出的页数大于1（内容超出十个）
                      {
                          //加入第一页
                          $("#zhuzuobutton").append('<button class="btn btn-primary active" type="button" style="background: #6d59f9;border-style: none;border-radius: 10px;margin-left: 10px;">1</button>');
                          for(var i=2;i<=xiamian;i++)//加入后面存在的页数，i从2开始。
                          {
                              $("#zhuzuobutton").append('<button class="btn btn-primary" type="button" onclick="reloadzhuzuo('+i+')"  style="background: #aba3e6;border-style: none;border-radius: 10px;margin-left: 3px;">'+i+'</button></div>')
                          }
                      }
                    },
                    err:function(err){
                        alert(err);
                   }
               }
            )

    //新闻报道
    $.ajax(
                {
                    url:"json.txt",
                    type:"get",
                    dataType:"json",
                    success:function(data)
                    {
                      var xiamian=data.length/10;//10是每页内容的最大数量 data.length是所有内容数量 xiamian是分出的几页
                      $("#xinwenbutton").empty();//清空分页
                      $("#xinwenbaodao").empty();//清空内容
                      for(var i=0;i<10;i++)//将第一页内容填充进去
                      {
                        $("#xinwenbaodao").append('<tr class="transform"><td style="padding-top: 19px;"><input type="checkbox"></td><td><img src="https://img.okay.do/acagrid/static/build/images/info/file_large.png" style="width: 39px;height: 49.3px;">'+data[i].name+'</td><td style="padding-top: 19px;">'+data[i].type+'</td><td style="padding-top: 19px;">'+data[i].time+'</td><td><div class="dropdown"><button class="btn btn-primary dropdown-toggle dropdown-toggle" aria-expanded="false" data-bs-toggle="dropdown" id="daochu-3" style="margin-top: 5px;margin-left: 0px;margin-right: 38px;background-color: rgba(60,33,247,.75);float: right;">更多</button><div class="dropdown-menu"><a class="dropdown-item" href="#">编辑</a><a class="dropdown-item" href="#">分享</a><a class="dropdown-item" href="#" style="color: rgb(255,3,3);">删除</a></div></div><a href="#" style="margin-top: 12px;padding-top: 0px;float: left;color: #6d59f9;">下载</a><a href="#" style="margin-top: 12px;float: left;margin-left: 18px;color: #6d59f9;">导出</a><div class="dropdown"><button class="btn btn-primary dropdown-toggle dropdown-menu" aria-expanded="false" data-bs-toggle="dropdown">Dropdown </button<div class="dropdown-menu"><a class="dropdown-item" href="#">First Item</a><a class="dropdown-item" href="#">Second Item</a><a class="dropdown-item" href="#">Third Item</a></div></div></td></tr><tr></tr>')
                      }
                      if(xiamian>1)//如果分出的页数大于1（内容超出十个）
                      {
                          //加入第一页
                          $("#xinwenbutton").append('<button class="btn btn-primary active" type="button" style="background: #6d59f9;border-style: none;border-radius: 10px;margin-left: 10px;">1</button>');
                          for(var i=2;i<=xiamian;i++)//加入后面存在的页数，i从2开始。
                          {
                              $("#xinwenbutton").append('<button class="btn btn-primary" type="button" onclick="reloadxinwen('+i+')"  style="background: #aba3e6;border-style: none;border-radius: 10px;margin-left: 3px;">'+i+'</button></div>')
                          }
                      }
                    },
                    err:function(err){
                        alert(err);
                   }
               }
            )
    //科研项目
    $.ajax(
                {
                    url:"json.txt",
                    type:"get",
                    dataType:"json",
                    success:function(data)
                    {
                      var xiamian=data.length/10;//10是每页内容的最大数量 data.length是所有内容数量 xiamian是分出的几页
                      $("#keyanbutton").empty();//清空分页
                      $("#keyanxiangmu").empty();//清空内容
                      for(var i=0;i<10;i++)//将第一页内容填充进去
                      {
                        $("#keyanxiangmu").append('<tr class="transform"><td style="padding-top: 19px;"><input type="checkbox"></td><td><img src="https://img.okay.do/acagrid/static/build/images/info/file_large.png" style="width: 39px;height: 49.3px;">'+data[i].name+'</td><td style="padding-top: 19px;">'+data[i].time+'</td><td><div class="dropdown"><button class="btn btn-primary dropdown-toggle dropdown-toggle" aria-expanded="false" data-bs-toggle="dropdown" id="daochu-4" style="margin-top: 5px;margin-left: 0px;margin-right: 38px;background-color: rgba(60,33,247,.75);float: right;">更多</button><div class="dropdown-menu"><a class="dropdown-item" href="#">编辑</a><a class="dropdown-item" href="#">分享</a><a class="dropdown-item" href="#" style="color: rgb(255,3,3);">删除</a></div></div><a href="#" style="margin-top: 12px;padding-top: 0px;float: left;color: #6d59f9;">下载</a><a href="#" style="margin-top: 12px;float: left;margin-left: 40px;color: #6d59f9;">导出</a><div class="dropdown"><button class="btn btn-primary dropdown-toggle dropdown-menu" aria-expanded="false" data-bs-toggle="dropdown">Dropdown </button><div class="dropdown-menu"><a class="dropdown-item" href="#">First Item</a><a class="dropdown-item" href="#">Second Item</a><a class="dropdown-item" href="#">Third Item</a></div></div></td></tr><tr></tr>')
                      }
                      if(xiamian>1)//如果分出的页数大于1（内容超出十个）
                      {
                          //加入第一页
                          $("#keyanbutton").append('<button class="btn btn-primary active" type="button" style="background: #6d59f9;border-style: none;border-radius: 10px;margin-left: 10px;">1</button>');
                          for(var i=2;i<=xiamian;i++)//加入后面存在的页数，i从2开始。
                          {
                              $("#keyanbutton").append('<button class="btn btn-primary" type="button" onclick="reloadkeyan('+i+')"  style="background: #aba3e6;border-style: none;border-radius: 10px;margin-left: 3px;">'+i+'</button></div>')
                          }
                      }
                    },
                    err:function(err){
                        alert(err);
                   }
               }
            )

    //其他
    $.ajax(
                {
                    url:"json.txt",
                    type:"get",
                    dataType:"json",
                    success:function(data)
                    {
                      var xiamian=data.length/10;//10是每页内容的最大数量 data.length是所有内容数量 xiamian是分出的几页
                      $("#qitabutton").empty();//清空分页
                      $("#qita").empty();//清空内容
                      for(var i=0;i<10;i++)//将第一页内容填充进去
                      {
                        $("#qita").append('<tr class="transform" style="height: 66px;padding-top: 8px;"><td style="padding-top: 19px;"><i class="fa fa-file-o" style="padding-left: 6px;"></i></td><td style="padding-left: 17px;padding-top: 19px;">'+data[i].name+'</td><td style="padding-left: 34px;padding-top: 19px;">'+data[i].rank+'</td><td style="padding-top: 19px;">'+data[i].time+'</td><td style="padding-top: 19px;"><a href="#" style="color: #6d59f9;margin-right: 20px;">编辑</a><a href="#" style="color: var(--bs-red);">删除</a></td></tr>')
                      }
                      if(xiamian>1)//如果分出的页数大于1（内容超出十个）
                      {
                          //加入第一页
                          $("#qitabutton").append('<button class="btn btn-primary active" type="button" style="background: #6d59f9;border-style: none;border-radius: 10px;margin-left: 10px;">1</button>');
                          for(var i=2;i<=xiamian;i++)//加入后面存在的页数，i从2开始。
                          {
                              $("#qitabutton").append('<button class="btn btn-primary" type="button" onclick="reloadqita('+i+')"  style="background: #aba3e6;border-style: none;border-radius: 10px;margin-left: 3px;">'+i+'</button></div>')
                          }
                      }
                    },
                    err:function(err){
                        alert(err);
                   }
               }
            )
}