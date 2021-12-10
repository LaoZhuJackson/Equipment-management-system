# 帮助文档
## 0.目录
*   [1.登录和注册](#login)
*   [2.查询](#search)
*   [3.修改](#change)
*   [4.删除（管理员特有）](#delete)
*   [5.添加（管理员特有）](#add)
*   [6.修改密码](#pwd)
-----------------------
## <span id="login">1.登录和注册</span>
```
输入账号密码登录，管理员与普通人的账户添加在注册中实现，登录和注册不需要选择身份，
在同一个登录框输入即可识别。
```
>存在空值判断，不能输入空值

>用户已存在会给出提示

>存在非法值判断
## <span id="search">2.查询</span>
```
通过左侧侧边导航栏进入对应的查询页面。进入后通过选择下拉列表来选择需要按照
那种方式然后点击search按钮进行查询
```
>存在空值判断，不能输入空值

>通过编号查询需要输入数字，否则非法
## <span id="change">3.修改</span>
```
管理员特有功能，在查询出结果后，可以在右侧的修改区域中通过输入需要修改的编号，
然后在下拉列表中选择需要修改的列名，最后输入修改对应的值，点击change按钮可以提交修改
```
>存在空值判断，不能输入空值

>实现了非法值检测，如果需要修改的内容是数字，就不能输入`除数字外`的其他内容
## <span id="delete">5.删除</span>
```
管理员特有功能，右下角的删除区域可以进行删除输入对应编号的数据
```
>存在空值判断，不能输入空值

>删除单条数据只需要输入一个id点击删除按钮即可
## <span id="add">5.添加</span>
```
实现设备、部门、人员的添加。
```
>存在空值判断，不能输入空值

>存在非法值判断机制
## <span id="pwd">6.修改密码</span>
```
通过验证旧密码，以及输入两遍新密码进行修改保存
```
>存在空值判断，不能输入空值