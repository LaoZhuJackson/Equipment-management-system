////const Search = document.getElementById('search_btn');
//const grid = document.getElementsByClassName('grid_background')[0];
//const ok = document.getElementById('ok');

////Search.onclick = function () {
////    grid.classList.add('visible');
////}

//ok.onclick = function () {
//    grid.classList.remove('visible');
//}

// jQuery实现网页异步刷新，不刷新导航栏
// $(document).ready(function())->非简写
$(function () {
    //通过id获取元素
    var $search_equip = $("#search_equip_link");
    var $search = $("#search");
    var $search_dept = $("#search_dept_link");
    var $search_emp = $("#search_emp_link");
    var $change_pwd = $("#change_pwd_link");
    var change = function () {
        //js绑定对应内容区id
        if (this.id == 'search') {
            var name = this.id + '_equip_link_select'
        } else {
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
    $change_pwd.click(change);
})