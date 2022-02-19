//解析id
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}
//设置查找对应的pdf路径
var id = "/upload/"+getUrlParam('id')+".pdf";
console.log(id);
//如果为null说明是上传页面展示上传
if (id == "/upload/null.pdf") {
    $("#picture_wrap").empty();
    //下面两句话上传空间所需
    $(".submit-wrap.text-center.col-sm-12").append('<div class="container my-4"></script ><script src="../js/fileinput.js" type="text/javascript"></script><script src="../js/locales/zh.js" type="text/javascript"></script><script src="../themes/fas/theme.js" type="text/javascript"></script><script src="../themes/explorer-fas/theme.js" type="text/javascript"></script><hr>');
    $(".submit-wrap.text-center.col-sm-12").append('<input id="model_file" name="model_file" type="file" multiple></div></form></div>');
}
//pdf所需
else {
    PDFObject.embed(id, "#pdfview");
    $(".submit-wrap.text-center.col-sm-12").append('<button id="submit" onclick="upload("../../ getdata.ashx")" type="button" class="btn btn-large btn-primary" data-loading-text="正在处理中...">上传</button>');
}
//获取当前距离1970年1月1日到现在的毫秒数
var nowtime = $.now();
//上传所需
$(function () {
    var control = $("#model_file");
    var uploadrul = "../../upload.ashx";//处理文件的url
    var upObj = {
        language: 'zh', //设置语言
        uploadUrl: uploadrul, //上传的地址
        uploadExtraData: { "savepath": "/upload/", "meth": "lunwenload", "paperid": nowtime },//上传至服务器的参数，非常重要
        allowedFileExtensions: ['xml', 'pdf', 'jpg', 'png', 'gif', 'rar', 'doc'],//接收的文件后缀
        showUpload: true, //显示批量上传按钮
        showCaption: false,//是否显示标题
        dropZoneEnabled: true,//是否显示拖拽区域
        browseClass: "btn btn-primary",                        // 浏览按钮样式
        uploadClass: "btn btn-primary",                        // 上传按钮样式
        maxFileSize: 4096,//单位为kb，如果为0表示不限制文件大小
        hideThumbnailContent: false,                  // 是否隐藏文件内容
        minFileCount: 1,
        maxFileCount: 10,
        msgSizeTooLarge: " \"{name}\" 大小为({size} KB) 最大文件大小为 {maxSize} KB.请重新上传!",//文件的实际大小有些许偏差
        enctype: 'multipart/form-data',
        validateInitialCount: true,
        previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",
        msgFilesTooMany: "选择上传的文件数量({n}) 超过允许的最大数值{m}！",
        allowedPreviewTypes: ['image', 'pdf'],//能够预览的文件类型，如果不限制。文件预览时可能很慢
        fileActionSettings: {                               // 在预览窗口中为新选择的文件缩略图设置文件操作的对象配置
            showRemove: true,                                   // 显示删除按钮
            showUpload: true,                                   // 显示上传按钮
            showDownload: false,                            // 显示下载按钮
            showZoom: true,                                    // 显示预览按钮
            showDrag: false,                                        // 显示拖拽
            removeIcon: '<i class="fa fa-trash"></i>',   // 删除图标
            uploadIcon: '<i class="fa fa-upload"></i>',     // 上传图标
            uploadRetryIcon: '<i class="fa fa-repeat"></i>'  // 重试图标
        },
    };
    $('#modalShow').html("[请选择" + upObj.allowedFileExtensions + "]文件");
    control.fileinput(upObj);

    //导入文件上传成功之后的事件
    $("#model_file").on("fileuploaded", function (event, data, previewId, index) {
        //这里负责插入数据库
        upload("../../upload.ashx");
    });
    //导入文件上传失败之后的事件
    $('#model_file').on('fileuploaderror', function (event, data, msg) {
        var msg = data.response;
    });
});
//添加作者按钮
$(".add-author").click(function() {
    $(".authors-block.chinese").append('<div class="tr-wrap"> <div class="delete-block"> <input type="hidden" class="version-control" name="co_authors[0][version]" value="-2"> <span class="delete-author iconfont icon-srcm-i-delete" data-toggle="tooltip" data-placement="top" title="" data-original-title="移除"></span> </div> <div class="sort-block"> <select class="form-control" name="co_authors[0][rank]">  <option value="1">1</option>  <option value="2">2</option>  <option value="3">3</option>  <option value="4">4</option>  <option value="5">5</option>  <option value="6">6</option>  <option value="7">7</option>  <option value="8">8</option>  <option value="9">9</option>  <option value="10">10</option>  <option value="11">11</option>  <option value="12">12</option>  <option value="13">13</option>  <option value="14">14</option>  <option value="15">15</option>   <option value="其他">其他</option> </select> </div> <div class="name-block"> <input class="form-control" type="text" name="co_authors[0][realname]" value="" autocomplete="off"> <p>输入姓名</p> </div>  <div class="en-nickname-block"> <input class="form-control" type="text" name="co_authors[0][en_realname]" value="" autocomplete="off"> <p>输入姓名</p> </div>  <div class="identity-block"> <select class="form-control" name="co_authors[0][identity]">  <option value="老师">老师</option>  <option value="博士生">博士生</option>  <option value="硕士生">硕士生</option>  <option value="本科生">本科生</option>  <option value="其他">其他</option>  </select> </div>  <div class="correspondent-block"> <input type="checkbox" name="co_authors[0][correspondent]" value="1"> </div> <div class="equal-first-block"> <input type="checkbox" name="co_authors[0][equal_first]" value="1"> </div>  <div class="institution-block"> <div class="per-institution"> <input class="form-control" type="text" name="co_authors[0][multi_ins][0][institution]" autocomplete="off"> <input type="hidden" name="co_authors[0][multi_ins][0][author_id]" value="0"> <input type="hidden" class="version-control" name="co_authors[0][multi_ins][0][version]" value="-2"> <input type="hidden" name="co_authors[0][multi_ins][0][ins_rank]" value="0"> <input type="hidden" name="co_authors[0][multi_ins][0][staff_id]" value="0"> <input type="hidden" name="co_authors[0][multi_ins][0][id]" value="0"> <input type="hidden" name="co_authors[0][multi_ins][0][ins_id]" value="0"> </div> </div> <div class="operation-block"> <a href="#" class="add-unit">添加单位</a> </div> </div>');
    return false;
});
function checkvalue(element) {
    $("input[value='"+element+"']").prop('checked', true);
}
function completeele(element, value) {
    $("input[name='" + element + "']").prop('value', value);
}
$.ajax({
    type: "get",
    url: "../../bianji.ashx",
    data: { "name": "6666", "meth": "lunwen" ,"paperid":"123"},
    dataType: "json",
    success: function (data) {
        console.log(data);
        var lunwenbianjiload={ };
        for (var i = 0; i < data.length; i++) {
            lunwenbianjiload = data[0];
            console.log(lunwenbianjiload);
            //勾选元素
            $.each(lunwenbianjiload, function (index) {
                $("input[value='" + index + "']").prop('checked', true);
            });
            //开始填充元素
            $("input[name='title']").prop('value', lunwenbianjiload.name);//论文名称 普通input
            $("input[value='" + lunwenbianjiload.lunwenleixing + "']").prop('checked', true);//论文类型 radio
            $("input[value='" + lunwenbianjiload.lunwenlingyu + "']").prop('checked', true);//刊物名称 radio
            $("select[name='my_rank']").prop('value', lunwenbianjiload.rank);//排名 select
            $("input[value='" + lunwenbianjiload.tongxunzuozhe + "']").prop('checked', true);//通讯作者 input
            $("input[value='" + lunwenbianjiload.duzhu + "']").prop('checked', true);//独著 input
            $("input[name='jurnal']").prop('value', lunwenbianjiload.kanwumingcheng);//刊物名称 普通input
            let sentences = lunwenbianjiload.time.split(/[-]/);
            $(".mtr-input.years").prop('value', sentences[0]);
            $(".mtr-input.months").prop('value', sentences[1]);
            $(".mtr-input.dates").prop('value', sentences[2]);

        }
     
    },
    error: function (data) {
        alert(err);
    }
});
//此代码为数组转换为json
$.fn.stringify = function() {
    console.log(this);
    console.log(JSON.stringify(this));
    return JSON.stringify(this);

}
var username = document.cookie;
//object
function upload(uri) {
    var lunwenbianji = {
        meth: "lunwenbianji",
        name: $("input[name='title']").val(),
        download: "#",
        export: "#",
        edit: "#",
        share: "#",
        username: "6666",
        code: "666",
        paperid: nowtime,
        lunwenleixing: $("input[name='paper_type']:checked").val(),
        lunwenlingyu: $("input[name='paper_field']:checked").val(),
        duzhu: $("input[name='write_alone']:checked").val(),
        tongxunzuozhe: $("input[name='cor_author']:checked").val(),
        kanwumingcheng: $("input[name='jurnal']").val(),
        EI: "0",
        ISTP: "0",
        ISSHP: "0",
        PKU: "0",
        SCD: "0",
        CSCDE: "0",
        省级期刊: "0",
        ESCI: "0",
        SSCI: "0",
        其他: "0",
        CSCD: "0",
        CSSCI扩展版: "0",
        CSSCI: "0",
        自然指数杂志: "0",
        SCIE: "0",
        SCI: "0",
        会议期刊: "0",
        科研核心: "0",
        国家级期刊: "0",
        AHCI: "0",
        校内核心: "0",
        DOI号: $("input[name='doi']").val(),
        引用次数: $("input[name='citations']").val(),
        关键词: $("input[name='keywords']").val(),
        起止页码: $("input[name='page_index']").val(),
        关联课题: $("select[name='researches[0][id]']").val(),

        影响因子: $("input[name='impact_factor']").val(),
        卷号: $("input[name='batch']").val(),
        期号: $("input[name='issue']").val(),
        ISSN号: $("input[name='issn']").val(),
        CN号: $("input[name='cn']").val(),
        摘要: $("input[name='abstract']").val(),
        备注信息: $("textarea[name='description']").val(),


    }
    console.log($("textarea[name='description']").val());
    //遍历元素并填入所需信息
    $("input[name='jurnal_lever[]']:checked").each(function(index, obj) {
        lunwenbianji[obj.value] = 1;

    })
    lunwenbianji["rank"] = $("select[name='my_rank']").val();
    lunwenbianji["time"] = $("input[class='mtr-input years ']").val() + "-" + $("input[class='mtr-input months']").val() + "-" + $("input[class='mtr-input dates']").val();
    lunwenbianji["成果同步"] = $("select[name='is_private']").val();
    console.log(lunwenbianji);

    $.ajax({
        url: uri,
        type: "get",
        dataType: "json",
        data: lunwenbianji,
        success: function (data) {
            console.log(data);
            alert('更新' + data + '条');
        },
        err: function(err) {
            alert(err);
        }
    })
};