### 新装oracle数据初始配置

#### 一、开放端口

此步骤可先直接关闭防火墙测试效果。待测试通过后制定开发端口,默认为1521

#### 二、配置网络访问

配置监听程序

Windows下依次点击【开始】->【所有程序】->【ORACLE】->【配置移植工具】->【Net Configuration Assistant】配置

【监听程序配置】和 【本地网络服务名配置】

![image-20210102151631704](images/image-20210102151631704.png)

![image-20210102151813690](images/image-20210102151813690.png)

![image-20210102151934592](images/image-20210102151934592.png)

![image-20210102151943586](images/image-20210102151943586.png)

![image-20210102151955496](images/image-20210102151955496.png)

![image-20210102152005256](images/image-20210102152005256.png)

![image-20210102152016114](images/image-20210102152016114.png)

![image-20210102152027976](images/image-20210102152027976.png)

![image-20210102152037632](images/image-20210102152037632.png)



![image-20210102152051361](images/image-20210102152051361.png)

![image-20210102152106929](images/image-20210102152106929.png)

![image-20210102152116538](images/image-20210102152116538.png)



![image-20210102152126129](images/image-20210102152126129.png)

![image-20210102152135722](images/image-20210102152135722.png)

![image-20210102152147432](images/image-20210102152147432.png)



![image-20210102152157506](images/image-20210102152157506.png)



![image-20210102152207809](images/image-20210102152207809.png)

![image-20210102152219801](images/image-20210102152219801.png)

![image-20210102152233776](images/image-20210102152233776.png)

![image-20210102152242945](images/image-20210102152242945.png)

![image-20210102152255953](images/image-20210102152255953.png)

![image-20210102152308288](images/image-20210102152308288.png)





Windows下依次点击【开始】->【所有程序】->【ORACLE】->【配置移植工具】->【Net Manger】

如下图 依次点击【服务命名】->【orcl】

![image-20201209135015953](images/image-20201209135015953.png)

关闭窗口后后点击保存   

然后在客户端使用plsql连接

![image-20201209135129238](images/image-20201209135129238.png)



![image-20201209135138373](images/image-20201209135138373.png)

![image-20201209135212590](images/image-20201209135212590.png)

#### 三、默认登录方式

如果配置了登录密码则以自己配置的密码登录。

![image-20201209133455437](images/image-20201209133455437.png)

#### 四、plsql中文乱码处理

原因：本机没有配置数据库字符集环境变量，或是与数据库字符集不一致。

步骤一：在plsql中执行

```mysql
select userenv('language') from dual;
```

或是执

```msyql
select * from V$NLS_PARAMETERS;
```

两者的区别是：第一种查看到的是拼接好的一条字符集数据；第二种是查询数据库详细配置参数，有多条数据，需要以 第一行_第二行.第九行的格式拼接起来

例如：AMERICAN_AMERICA.ZHS16GBK

步骤二：在环境变量中添加配置：

NLS_LANG=AMERICAN_AMERICA.ZHS16GBK（这个value值就是我们步骤一中拼接好的那个值）

步骤三：重启plsql即可，如果没有生效，需要重启电脑。

![image-20201209134310399](images/image-20201209134310399.png)

