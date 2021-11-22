// jQuery实现网页异步刷新，不刷新导航栏
// $(document).ready(function())->非简写
$(function () {
    //通过id获取元素
    var $search = $("#search");
    var $add = $("#add");
    var $search_equip = $("#search_equip_link");
    var $search_dept = $("#search_dept_link");
    var $search_emp = $("#search_emp_link");
    var $change_pwd = $("#change_pwd_link");
    var $add_equip = $("#add_equip_link");
    var $add_dept = $("#add_dept_link");
    var $add_emp = $("#add_emp_link");
    var change = function () {
        //js绑定对应内容区id
        if (this.id == 'search' || this.id == 'add') {//制造等效连接
            var name = this.id + '_equip_link_select'
        }
        else {
            var name = this.id + '_select';
        }
        var newId = document.getElementById(name);
        //将js对象转化为jq对象
        var $newId = $(newId);
        //隐藏—除选中的newId下其他所有div标签
        $newId.siblings('div').hide();
        //展示newId的内容
        $newId.show();
    }
    //为链接绑定点击事件
    $search_equip.click(change);
    $search_dept.click(change);
    $search_emp.click(change);
    $search.click(change);
    $add.click(change);
    $add_emp.click(change);
    $add_dept.click(change);
    $add_equip.click(change);
    $change_pwd.click(change);
})