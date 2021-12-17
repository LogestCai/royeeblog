using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IF_P工伤医保.baseData;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using AHC_InterFace;


namespace IF_P工伤医保.baseComm
{
    /// <summary>
    /// 公用函数
    /// </summary>
    internal static class basComm
    {
        /// <summary>
        /// 用于接口脚本升级
        /// </summary>
        /// <param name="vs组件序号">当前接口组件序号,标记当前接口唯一</param>
        /// <param name="vi原版本号">当前接口原来的版本号</param>
        /// <returns>true:升级成功,false:升级失败</returns>
        public static bool Do接口相关升级(string vs组件序号, long vi原版本号)
        {
            try
            {
                for (long i = vi原版本号; i < basData.Gl当前组件版本; i++)
                {
                    List<string> listSQL = new List<string>();
                    switch (i)
                    {
                        #region 初始版本:建表

                        case 0:
                            {
                                //#region INF_TAHYB_系统参数列表

//                                if (
//                                    !DB.ExecSQLExist(
//                                        "select table_name from user_tables where table_name='INF_TAHYB_系统参数列表'"))
//                                {
//                                    #region 建表:INF_TAHYB_系统参数列表

//                                    listSQL.Add(
//                                        @"create table INF_TAHYB_系统参数列表
//(
//  系统序号  NUMBER(18) not null,
//  隶属机构i NUMBER(18),
//  参数名称  NVARCHAR2(60),
//  参数值1  NVARCHAR2(2000),
//  参数值2  NVARCHAR2(2000),
//  备注    VARCHAR2(4000)
//)
//tablespace USERS
//  pctfree 10
//  initrans 1
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 1M
//    minextents 1
//    maxextents unlimited
//  )");
//                                    #endregion

//                                    #region 主键:PK_TAHYB_系统参数列表

//                                    listSQL.Add(
//                                        @"alter table INF_TAHYB_系统参数列表
//  add constraint PK_TAHYB_系统参数列表 primary key (系统序号)
//  using index 
//  tablespace AHIS_TABLESPACE
//  pctfree 10
//  initrans 2
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 1M
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 写入默认值
//                                    //医疗机构编号
//                                    listSQL.Add(
//                                        @"insert into INF_TAHYB_系统参数列表(系统序号, 隶属机构i, 参数名称, 参数值1, 参数值2, 备注)values('1','0','医疗机构编号','','','医保局提供的医疗机构编号')");
//                                    //对账误差额
//                                    listSQL.Add(
//                                       @"insert into INF_TAHYB_系统参数列表(系统序号, 隶属机构i, 参数名称, 参数值1, 参数值2, 备注)values('2','0','对账误差额','0.1','','医保与HIS对账最大允许误差额')");
//                                    #endregion
//                                }

//                                #endregion

//                                #region  INF_TAHYB_三大目录表

//                                if (
//                                    !DB.ExecSQLExist(
//                                        "select table_name from user_tables where table_name='INF_TAHYB_三大目录表'"))
//                                {
//                                    #region 建表:INF_TAHYB_三大目录表

//                                    #endregion
//                                    #region 索引:PK_三大目录主键
//                                    #endregion
//                                }

//                                #endregion

//                                #region INF_TAHYB_二级代码目录

//                                if (
//                                    !DB.ExecSQLExist(
//                                        "select table_name from user_tables where table_name='INF_TAHYB_二级代码目录'"))
//                                {
//                                    #region 建表:INF_TAHYB_二级代码目录

//                                    listSQL.Add(
//                                        @"create table INF_TAHYB_二级代码目录
//(
//  隶属机构i NUMBER(30) not null,
//  代码类别  NVARCHAR2(20) not null,
//  类别名称  NVARCHAR2(50),
//  代码值   NVARCHAR2(30) not null,
//  代码名称  NVARCHAR2(100)
//)
//tablespace USERS
//  pctfree 10
//  initrans 1
//  maxtrans 255
//  storage
//  (
//    initial 16K
//    next 8K
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 主键:FK_二级码表主键

//                                    listSQL.Add(
//                                        @"alter table INF_TAHYB_二级代码目录
//  add constraint FK_我二级代码目录主键 primary key (隶属机构I, 代码值, 代码类别)
//  using index 
//  tablespace USERS
//  pctfree 10
//  initrans 2
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 1M
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion
//                                }

//                                #endregion

//                                #region INF_TAHYB_ICD10表

//                                if (
//                                    !DB.ExecSQLExist(
//                                        "select table_name from user_tables where table_name='INF_TAHYB_ICD10表'"))
//                                {
//                                    #region 建表:INF_TAHYB_ICD10表

//                                    listSQL.Add(
//                                        @"create table INF_TAHYB_ICD10表
//(
//  隶属机构i    number(30),
//  icd10代码  nvarchar2(50),
//  icd10副编码 nvarchar2(50),
//  icd10名称  varchar2(300),
//  拼音助记码    varchar2(100),
//  五笔助记码    varchar2(100),
//  变更时间     varchar2(30),
//  备注       varchar2(200)
//)
//tablespace USERS
//  storage
//  (
//    initial 64K
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 主键:PK_ICD10主键

//                                    listSQL.Add(
//                                        @"alter table INF_TAHYB_ICD10表  add constraint PK_ICD10主键 primary key (隶属机构I, ICD10代码)");

//                                    #endregion
//                                }

//                                #endregion

//                                #region INF_DAHYB_目录对码表

//                                if (
//                                    !DB.ExecSQLExist(
//                                        "select table_name from user_tables where table_name='INF_DAHYB_目录对码表'"))
//                                {
//                                    #region 建表:INF_DAHYB_目录对码表

//                                    listSQL.Add(
//                                        @"create table INF_DAHYB_目录对码表
//(
//  系统序号      NUMBER not null,
//  隶属机构I     NUMBER,
//  本地项目编号    NUMBER,
//  本地项目名称    NVARCHAR2(600),
//  本地项目类型    NVARCHAR2(10),
//  本地项目组合码 NVARCHAR2(100),
//  中心项目编码    NVARCHAR2(50),
//  中心项目名称    NVARCHAR2(600),
//  中心项目类型    NVARCHAR2(10),
//  中心收费类别    NVARCHAR2(30),
//  药品限制使用范围 NVARCHAR2(2000),
//  发生时间      DATE default sysdate,
//  对码人员      NVARCHAR2(30),
//  药品生产厂家 NVARCHAR2(2000)
//)
//tablespace USERS
//  pctfree 10
//  initrans 1
//  maxtrans 255
//  storage
//  (
//    initial 16K
//    next 8K
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 主键:INF_DAHYB_目录对码表主键

//                                    listSQL.Add(@"comment on column INF_DAHYB_目录对码表.本地项目类型  is '1.西药 2.项目 3.卫材 4.中药'");
//                                    listSQL.Add(
//                                        "comment on column INF_DAHYB_目录对码表.本地项目组合码 is '本地项目类型+本地项目编号,如药品:1000001,诊疗20000001'");
//                                    listSQL.Add(
//                                        @"alter table INF_DAHYB_目录对码表
//  add constraint PK_INF_DAHYB_目录对码表主键 primary key (系统序号)
//  using index 
//  tablespace USERS
//  pctfree 10
//  initrans 2
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 1M
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 建立索引:INF_DAHYB_目录对码表.本地项目编号

//                                    listSQL.Add(@"create index IX_目录对码表_本地项目编号 on INF_DAHYB_目录对码表(本地项目编号)");

//                                    #endregion

//                                    #region 建立索引:INF_DAHYB_目录对码表.中心项目编码

//                                    listSQL.Add(@"create index IX_目录对码表_中心项目编码 on INF_DAHYB_目录对码表(中心项目编码)");

//                                    #endregion

//                                    #region 创建序列:INF_SDAHYB_目录对码表

//                                    listSQL.Add(
//                                        @"create sequence INF_SDAHYB_目录对码表
//minvalue 1
//maxvalue 9999999999999999999999999999
//start with 1
//increment by 1
//cache 20");

//                                    #endregion
//                                }

//                                #endregion

//                                #region INF_DAHYB_字典对码表

//                                if (
//                                    !DB.ExecSQLExist(
//                                        "select table_name from user_tables where table_name='INF_DAHYB_字典对码表'"))
//                                {
//                                    #region 建表:INF_DAHYB_字典对码表

//                                    listSQL.Add(
//                                        @"create table INF_DAHYB_字典对码表
//(
//  系统序号      NUMBER not null,
//  隶属机构I     NUMBER,
//  本地字典编号    NUMBER,
//  本地字典名称    NVARCHAR2(600),
//  本地字典类型    NVARCHAR2(30),
//  中心字典编码    NVARCHAR2(50),
//  中心字典名称    NVARCHAR2(600),
//  发生时间      DATE default sysdate,
//  对码人员      NVARCHAR2(30)
//)
//tablespace USERS
//  pctfree 10
//  initrans 1
//  maxtrans 255
//  storage
//  (
//    initial 16K
//    next 8K
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 主键:INF_DAHYB_字典对码表主键

//                                    listSQL.Add(
//                                        @"comment on column INF_DAHYB_字典对码表.本地字典类型  is 'mrg_stas|婚姻状况;YKE350|药物使用-途径代码;drug_dosform|剂型编码;YKE315|检查/检验-类别代码;YKE319|检查/检验-结果代码;YKE320|检查部位代码;YKE327|麻醉-方法代码;YKE329|手术操作代码[ICD9];yke670|手术级别;yke672|手术切口等级'");
//                                    listSQL.Add(
//                                        @"alter table INF_DAHYB_字典对码表
//  add constraint PK_INF_DAHYB_字典对码表主键 primary key (系统序号)
//  using index 
//  tablespace USERS
//  pctfree 10
//  initrans 2
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 1M
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 建立索引:INF_DAHYB_字典对码表.本地字典编号

//                                    listSQL.Add(@"create index IX_本地字典编号 on INF_DAHYB_字典对码表(本地字典编号)");

//                                    #endregion

//                                    #region 建立索引:INF_DAHYB_字典对码表.中心字典编码

//                                    listSQL.Add(@"create index IX_中心字典编码 on INF_DAHYB_字典对码表(中心字典编码)");

//                                    #endregion

//                                    #region 创建序列:INF_SDAHYB_字典对码表

//                                    listSQL.Add(
//                                        @"create sequence INF_SDAHYB_字典对码表
//minvalue 1
//maxvalue 9999999999999999999999999999
//start with 1
//increment by 1
//cache 20");

//                                    #endregion
//                                }

//                                #endregion

//                                #region INF_DAHYB_签到签退表

//                                if (
//                                    !DB.ExecSQLExist(
//                                        "select table_name from user_tables where table_name='INF_DAHYB_签到签退表'"))
//                                {
//                                    #region 建表:INF_DAHYB_签到签退表

//                                    listSQL.Add(
//                                        @"create table INF_DAHYB_签到签退表
//(
//  系统序号    NUMBER(30) not null,
//  隶属机构i   NUMBER(18) not null,
//  经办人序号   NUMBER(30),
//  批次编号    NVARCHAR2(50),
//  签到时间    NVARCHAR2(30),
//  签退时间    NVARCHAR2(30),
//  备注      NVARCHAR2(300),
//  签到输出xml VARCHAR2(4000)
//)
//tablespace USERS
//  pctfree 10
//  initrans 1
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 8K
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 主键:PK_INF_DAHYB_系统序号

//                                    listSQL.Add(
//                                        @"alter table INF_DAHYB_签到签退表
//  add constraint PK_INF_DAHYB_系统序号 primary key (系统序号, 隶属机构I)
//  using index 
//  tablespace USERS
//  pctfree 10
//  initrans 2
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 1M
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 建立索引:INF_DAHYB_签到签退表.批次编号

//                                    listSQL.Add(@"create index IX_AHYB_批次编号 on INF_DAHYB_签到签退表(批次编号)");

//                                    #endregion

//                                    #region 创建序列:INF_SDAHYB_签到签退表

//                                    listSQL.Add(
//                                        @"create sequence INF_SDAHYB_签到签退表
//minvalue 1
//maxvalue 9999999999999999999999999999
//start with 1
//increment by 1
//cache 20");

//                                    #endregion
//                                }

//                                #endregion

//                                #region INF_DAHYB_门诊费用结算列表

//                                if (
//                                    !DB.ExecSQLExist(
//                                        "select table_name from user_tables where table_name='INF_DAHYB_门诊费用结算列表'"))
//                                {
//                                    #region 建表:INF_DAHYB_门诊费用结算列表

//                                    listSQL.Add(
//                                        @"create table INF_DAHYB_门诊费用结算列表
//(
//  系统序号      NUMBER(30) not null,
//  隶属机构i     NUMBER(30),
//  就诊登记号     NVARCHAR2(50),
//  结算编号      NVARCHAR2(50),
//  支付类别      NVARCHAR2(10),
//  his门诊临时序号 NUMBER(30),
//  his门诊正式序号 NUMBER(30),
//  费用总额      NUMBER(18,4),
//  个人帐户支付总额  NUMBER(18,4),
//  社保基金支付总额  NUMBER(18,4),
//  现金及其他自付   NUMBER(18,4),
//  刷卡信息      VARCHAR2(4000),
//  交易输入xml   VARCHAR2(4000),
//  交易输出xml   VARCHAR2(4000),
//  作废        NUMBER(2) default 0,
//  发生时间      DATE default sysdate,
//  批次编号      NVARCHAR2(50),
//  个人编号      NVARCHAR2(30),
//  退单序号      NUMBER(30),
//  结算类型      NUMBER(2)
//)
//tablespace USERS
//  pctfree 10
//  initrans 1
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 8K
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 主键:PK_AHYB_门诊费用结算列表

//                                    listSQL.Add(
//                                        @"alter table INF_DAHYB_门诊费用结算列表
//  add constraint PK_AHYB_门诊费用结算列表 primary key (系统序号)
//  using index 
//  tablespace USERS
//  pctfree 10
//  initrans 2
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 1M
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 注释文字:INF_DAHYB_门诊费用结算列表.作废

//                                    listSQL.Add(@"comment on column INF_DAHYB_门诊费用结算列表.作废  is '1.作废 0.正常'");

//                                    #endregion

//                                    #region 注释文字:INF_DAHYB_门诊费用结算列表.批次编号

//                                    listSQL.Add(@"comment on column INF_DAHYB_门诊费用结算列表.批次编号  is '签到产生的批次编号，用于对账'");

//                                    #endregion

//                                    #region 注释文字:INF_DAHYB_门诊费用结算列表.个人编号

//                                    listSQL.Add(@"comment on column INF_DAHYB_门诊费用结算列表.个人编号  is '55号交易使用'");

//                                    #endregion

//                                    #region 注释文字:INF_DAHYB_门诊费用结算列表.结算类型

//                                    listSQL.Add(@"comment on column INF_DAHYB_门诊费用结算列表.结算类型  is '1.普通门诊 2.门诊统筹 3.异地门诊'");

//                                    #endregion

//                                    #region 建立索引:INF_DAHYB_门诊费用结算列表.结算编号

//                                    listSQL.Add(@"create index IX_AHYB_结算编号 on INF_DAHYB_门诊费用结算列表(结算编号)");

//                                    #endregion

//                                    #region 创建序列:INF_SDAHYB_门诊费用结算列表

//                                    listSQL.Add(
//                                        @"create sequence INF_SDAHYB_门诊费用结算列表
//minvalue 1
//maxvalue 9999999999999999999999999999
//start with 1
//increment by 1
//cache 20");

//                                    #endregion
//                                }

//                                #endregion

//                                #region INF_DAHYB_门诊结算明细表

//                                if (
//                                    !DB.ExecSQLExist(
//                                        "select table_name from user_tables where table_name='INF_DAHYB_门诊结算明细表'"))
//                                {
//                                    #region 建表:INF_DAHYB_门诊结算明细表

//                                    listSQL.Add(
//                                        @"create table INF_DAHYB_门诊结算明细表
//(
//  系统序号     NUMBER(30) not null,
//  就诊登记号    NVARCHAR2(50),
//  结算编号     NVARCHAR2(50),
//  经办时间     NVARCHAR2(30),
//  参保所属分中心  NVARCHAR2(30),
//  费用分段标准   NVARCHAR2(30),
//  起付线      NVARCHAR2(30),
//  进入起付线部份  NVARCHAR2(30),
//  报销比例     NVARCHAR2(30),
//  社保基金支付总额 NVARCHAR2(30),
//  个人帐户支付   NVARCHAR2(30) not null,
//  就诊结算方式   NVARCHAR2(10),
//  清算分中心    NVARCHAR2(30),
//  清算方式     NVARCHAR2(10),
//  清算类别     NVARCHAR2(10),
//  发生时间     DATE default sysdate
//)
//tablespace USERS
//  pctfree 10
//  initrans 1
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 1M
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 主键:PK_INF_DAHYB_门诊结算明细表

//                                    listSQL.Add(
//                                        @"  alter table INF_DAHYB_门诊结算明细表
//  add constraint PK_INF_DAHYB_门诊结算明细表 primary key (系统序号)
//  using index 
//  tablespace USERS
//  pctfree 10
//  initrans 2
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 1M
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 建立索引:INF_DAHYB_门诊结算明细表.就诊登记号

//                                    listSQL.Add(@"create index IX1_INF_DAHYB_门诊结算明细表 on INF_DAHYB_门诊结算明细表(就诊登记号)");

//                                    #endregion

//                                    #region 建立索引:INF_DAHYB_门诊结算明细表.结算编号

//                                    listSQL.Add(@"create index IX2_INF_DAHYB_门诊结算明细表 on INF_DAHYB_门诊结算明细表(结算编号)");

//                                    #endregion

//                                    #region 创建序列:INF_SDAHYB_门诊结算明细表

//                                    listSQL.Add(
//                                        @"create sequence INF_SDAHYB_门诊结算明细表
//minvalue 1
//maxvalue 9999999999999999999999999999
//start with 1
//increment by 1
//cache 20");

//                                    #endregion
//                                }

//                                #endregion

//                                #region INF_DAHYB_入院登记表

//                                if (
//                                    !DB.ExecSQLExist(
//                                        "select table_name from user_tables where table_name='INF_DAHYB_入院登记表'"))
//                                {
//                                    #region 建表:INF_DAHYB_入院登记表

//                                    listSQL.Add(
//                                        @"create table INF_DAHYB_入院登记表
//(
//  系统序号     NUMBER(30) not null,
//  隶属机构i    NUMBER(30),
//  住院序号     NUMBER(30),
//  就诊登记号    NVARCHAR2(50),
//  支付类别     NVARCHAR2(30),
//  个人编号     NVARCHAR2(50),
//  医疗人员类别   NVARCHAR2(30),
//  病种编码     NVARCHAR2(50),
//  本次起付线    NVARCHAR2(30),
//  本次医疗支付限额 NVARCHAR2(30),
//  入院诊断编码   NVARCHAR2(200),
//  入院诊断名称   NVARCHAR2(1024),
//  刷卡信息     VARCHAR2(4000),
//  交易输入xml  VARCHAR2(4000),
//  交易输出xml  VARCHAR2(4000),
//  作废       NUMBER(2) default 0,
//  已出院      NUMBER(2) default 0,
//  发生时间     DATE default sysdate
//)
//tablespace USERS
//  pctfree 10
//  initrans 1
//  maxtrans 255
//  storage
//  (
//    initial 16K
//    next 8K
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 主键:PK_AHYB_入院登记表主键

//                                    listSQL.Add(
//                                        @"alter table INF_DAHYB_入院登记表
//  add constraint PK_AHYB_入院登记表主键 primary key (系统序号)
//  using index 
//  tablespace USERS
//  pctfree 10
//  initrans 2
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 1M
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 建立索引:IX_AHYB_住院序号.住院序号

//                                    listSQL.Add(
//                                        @"create index IX_AHYB_住院序号 on INF_DAHYB_入院登记表 (住院序号)
//  tablespace USERS
//  pctfree 10
//  initrans 2
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 1M
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 注释文字:INF_DAHYB_入院登记表.作废

//                                    listSQL.Add(@"comment on column INF_DAHYB_入院登记表.作废 is '1.作废 0.正常'");

//                                    #endregion

//                                    #region 注释文字:INF_DAHYB_入院登记表.已出院

//                                    listSQL.Add(@"comment on column INF_DAHYB_入院登记表.已出院 is '0.在院 1.已出院'");

//                                    #endregion

//                                    #region 创建序列:INF_SDAHYB_入院登记表

//                                    listSQL.Add(
//                                        @"create sequence INF_SDAHYB_入院登记表
//minvalue 1
//maxvalue 9999999999999999999999999999
//start with 1
//increment by 1
//cache 20");

//                                    #endregion
//                                }

//                                #endregion

//                                #region INF_DAHYB_住院明细上传记录表

//                                if (
//                                    !DB.ExecSQLExist(
//                                        "select table_name from user_tables where table_name='INF_DAHYB_住院明细上传记录表'"))
//                                {
//                                    #region 建表:INF_DAHYB_住院明细上传记录表

//                                    listSQL.Add(
//                                        @"create table INF_DAHYB_住院明细上传记录表
//(
//  系统序号    NUMBER(30) not null,
//  隶属机构i   NUMBER(30),
//  记账流水号   NVARCHAR2(30),
//  住院序号    NUMBER(30),
//  发生时间    DATE default sysdate,
//  医院审核标志  NVARCHAR2(10),
//  单价      NUMBER(18,6),
//  数量      NUMBER(18,4),
//  金额      NUMBER(18,6),
//  交易输入xml VARCHAR2(4000),
//  交易返回xml VARCHAR2(4000)
//)
//tablespace USERS
//  pctfree 10
//  initrans 1
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 8K
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 主键:PK_INF_DAHYB_住院明细

//                                    listSQL.Add(
//                                        @"alter table INF_DAHYB_住院明细上传记录表
//  add constraint PK_INF_DAHYB_住院明细 primary key (系统序号)
//  using index 
//  tablespace USERS
//  pctfree 10
//  initrans 2
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 1M
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 注释文字:INF_DAHYB_住院明细上传记录表.医院审核标志

//                                    listSQL.Add(@"comment on column INF_DAHYB_住院明细上传记录表.医院审核标志 is '0.不纳入,1.纳入,2.院外检查'");

//                                    #endregion

//                                    #region 建立索引:INF_DAHYB_住院明细上传记录表.结算编号

//                                    listSQL.Add(
//                                        @"create index IX_INF_DAHYB_记账流水号 on INF_DAHYB_住院明细上传记录表 (记账流水号)
//  tablespace USERS
//  pctfree 10
//  initrans 2
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 1M
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 创建序列:INF_SDAHYB_住院明细上传记录表

//                                    listSQL.Add(
//                                        @"create sequence INF_SDAHYB_住院明细上传记录表
//minvalue 1
//maxvalue 9999999999999999999999999999
//start with 1
//increment by 1
//cache 20");

//                                    #endregion
//                                }

//                                #endregion

//                                #region INF_DAHYB_住院费用结算列表

//                                if (
//                                    !DB.ExecSQLExist(
//                                        "select table_name from user_tables where table_name='INF_DAHYB_住院费用结算列表'"))
//                                {
//                                    #region 建表:INF_DAHYB_住院费用结算列表

//                                    listSQL.Add(
//                                        @"create table INF_DAHYB_住院费用结算列表
//(
//  系统序号     NUMBER(30) not null,
//  隶属机构i    NUMBER(30),
//  就诊登记号    NVARCHAR2(50),
//  批次编号     NVARCHAR2(50),
//  个人编号     NVARCHAR2(30),
//  结算编号     NVARCHAR2(50),
//  支付类别     NVARCHAR2(10),
//  住院序号     NUMBER(30),
//  费用总额     NUMBER(18,4),
//  个人帐户支付总额 NUMBER(18,4),
//  社保基金支付总额 NUMBER(18,4),
//  现金及其他自付  NUMBER(18,4),
//  交易输入xml  VARCHAR2(4000),
//  交易输出xml  VARCHAR2(4000),
//  作废       NUMBER(2) default 0,
//  发生时间     DATE default sysdate,
//  结算序号     NUMBER(30),
//  退单序号     NUMBER(30),
//  出院办理输入XML  VARCHAR2(4000)
//)
//tablespace USERS
//  pctfree 10
//  initrans 1
//  maxtrans 255
//  storage
//  (
//    initial 16K
//    next 8K
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 主键:PK_AHYB_住院费用结算列表

//                                    listSQL.Add(
//                                        @"  alter table INF_DAHYB_住院费用结算列表
//add constraint PK_AHYB_住院费用结算列表 primary key (系统序号)
//  using index 
//  tablespace USERS
//  pctfree 10
//  initrans 2
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 1M
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 注释文字:INF_DAHYB_住院费用结算列表.作废

//                                    listSQL.Add(@"comment on column INF_DAHYB_住院费用结算列表.作废 is '1.作废 0.正常'");

//                                    #endregion

//                                    #region 注释文字:INF_DAHYB_住院费用结算列表.批次编号

//                                    listSQL.Add(@"comment on column INF_DAHYB_住院费用结算列表.批次编号  is '签到产生的批次编号，用于对账'");

//                                    #endregion

//                                    #region 注释文字:INF_DAHYB_住院费用结算列表.个人编号

//                                    listSQL.Add(@"comment on column INF_DAHYB_住院费用结算列表.个人编号  is '55号交易使用'");

//                                    #endregion

//                                    #region 建立索引:INF_DAHYB_住院费用结算列表.结算编号

//                                    listSQL.Add(@"create index IX_AHYB_住院结算编号 on INF_DAHYB_住院费用结算列表(结算编号)");

//                                    #endregion

//                                    #region 创建序列:INF_SDAHYB_住院费用结算列表

//                                    listSQL.Add(
//                                        @"create sequence INF_SDAHYB_住院费用结算列表
//minvalue 1
//maxvalue 9999999999999999999999999999
//start with 1
//increment by 1
//cache 20");

//                                    #endregion
//                                }

//                                #endregion

//                                #region INF_DAHYB_住院结算明细表

//                                if (
//                                    !DB.ExecSQLExist(
//                                        "select table_name from user_tables where table_name='INF_DAHYB_住院结算明细表'"))
//                                {
//                                    #region 建表:INF_DAHYB_住院结算明细表

//                                    listSQL.Add(
//                                        @"create table INF_DAHYB_住院结算明细表
//(
//  系统序号     NUMBER(30) not null,
//  就诊登记号    NVARCHAR2(50),
//  结算编号     NVARCHAR2(50),
//  经办时间     NVARCHAR2(30),
//  参保所属分中心  NVARCHAR2(30),
//  费用分段标准   NVARCHAR2(30),
//  起付线      NVARCHAR2(30),
//  进入起付线部份  NVARCHAR2(30),
//  报销比例     NVARCHAR2(30),
//  社保基金支付总额 NVARCHAR2(30),
//  个人帐户支付   NVARCHAR2(30) not null,
//  就诊结算方式   NVARCHAR2(10),
//  清算分中心    NVARCHAR2(30),
//  清算方式     NVARCHAR2(10),
//  清算类别     NVARCHAR2(10),
//  发生时间     DATE default sysdate
//)
//tablespace USERS
//  pctfree 10
//  initrans 1
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 1M
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 主键:PK_INF_DAHYB_住院结算明细表

//                                    listSQL.Add(
//                                        @"  alter table INF_DAHYB_住院结算明细表
//  add constraint PK_INF_DAHYB_住院结算明细表 primary key (系统序号)
//  using index 
//  tablespace USERS
//  pctfree 10
//  initrans 2
//  maxtrans 255
//  storage
//  (
//    initial 64K
//    next 1M
//    minextents 1
//    maxextents unlimited
//  )");

//                                    #endregion

//                                    #region 建立索引:INF_DAHYB_住院结算明细表.就诊登记号

//                                    listSQL.Add(@"create index IX1_INF_DAHYB_住院结算明细表 on INF_DAHYB_住院结算明细表(就诊登记号)");

//                                    #endregion

//                                    #region 建立索引:INF_DAHYB_住院结算明细表.结算编号

//                                    listSQL.Add(@"create index IX2_INF_DAHYB_住院结算明细表 on INF_DAHYB_住院结算明细表(结算编号)");

//                                    #endregion

//                                    #region 创建序列:INF_SDAHYB_住院结算明细表

//                                    listSQL.Add(
//                                        @"create sequence INF_SDAHYB_住院结算明细表
//minvalue 1
//maxvalue 9999999999999999999999999999
//start with 1
//increment by 1
//cache 20");

//                                    #endregion
//                                }

//                                #endregion

                                break;
                            }

                        #endregion
                        #region 升级版本:1-->2

                        case 1:
                            {
                                //序列 待完善
                                break;
                            }

                        #endregion
                        #region 升级版本:2-->3

                        case 2:
                            {
                               
                                break;
                            }

                        #endregion
                        #region 升级版本:3-->4

                        case 3:
                            {
                                break;
                            }

                        #endregion
                        #region 升级版本:4-->5

                        case 4:
                            {
                                break;
                            }


                        #endregion
                        default:
                            {
                                throw new Exception("没有对应的升级脚本");
                            }
                    }
                    //执行升级脚本
                    DB.ExecListCmd(listSQL);
                    ////更新版本号
                    int viCount =
                        DB.ExecCmd(string.Format(@"Update AMS_B接口列表 Set 组件版本='{0}' Where 组件序号='{1}'", (i+1),vs组件序号));
                    if (viCount == 0)
                    {
                        throw new Exception("保险组件版本号没有更新成功");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
                return false;
            }
        }
        #region 读取TXT文本文件到datatable
        public static System.Data.DataTable ReadTXT(string vs文件路径, ref int vn数据列数, char vsSplitChar = '\t', char vs行分隔符 = '\n')
        {
            try
            {
                StreamReader iniReader = new StreamReader(vs文件路径, Encoding.Default);
                System.Data.DataTable dt = new System.Data.DataTable();
                #region Tab分割的行

                if (vs行分隔符.Equals('\n'))
                {
                    string sLine = iniReader.ReadLine();
                    if (!string.IsNullOrEmpty(sLine))
                    {
                        string[] arr = sLine.Split(vsSplitChar);
                        int nColCount = arr.Length;
                        if (nColCount > 0)
                        {
                            vn数据列数 = nColCount;
                            for (int i = 0; i < nColCount; i++)
                            {
                                dt.Columns.Add("数据列" + i);
                            }
                        }
                        iniReader.Close();
                        //读取数据到datatable
                        StreamReader objReader = new StreamReader(vs文件路径, Encoding.Default);

                        while (!objReader.EndOfStream)
                        {
                            sLine = objReader.ReadLine();

                            if (sLine != null && !sLine.Equals(""))
                            {
                                string[] sArrItem = new string[nColCount];
                                string[] aTempArr = sLine.Split(vsSplitChar);
                                for (int i = 0; i < sArrItem.Length; i++)
                                {
                                    try { sArrItem[i] = aTempArr[i]; }
                                    catch (Exception) { }
                                }
                                System.Data.DataRow dr = dt.NewRow();
                                //处理
                                if (aTempArr.Length < nColCount)
                                {
                                    for (int i = aTempArr.Length; i < nColCount; i++)
                                    {
                                        sArrItem[i] = string.Empty;
                                    }
                                }
                                //赋值
                                for (int i = 0; i < nColCount; i++)
                                {
                                    dr["数据列" + i] = sArrItem[i];
                                }
                                dt.Rows.Add(dr);
                            }
                        }
                        objReader.Close();
                        return dt;
                    }

                    else
                    {
                        return null;
                    }
                }
                #endregion
                #region 其他分割符分割的行
                else
                {
                    string sContent = iniReader.ReadToEnd();
                    string sLine = sContent.Split(vs行分隔符)[0];
                    if (!string.IsNullOrEmpty(sLine))
                    {
                        string[] arr = sLine.Split(vsSplitChar);
                        int nColCount = arr.Length;
                        if (nColCount > 0)
                        {
                            vn数据列数 = nColCount;
                            for (int i = 0; i < nColCount; i++)
                            {
                                dt.Columns.Add("数据列" + i);
                            }
                        }
                        //填充数据
                        string[] arr行集合 = sContent.Split(vs行分隔符);
                        for (int j = 1; j < arr行集合.Length; j++)
                        {
                            sLine = arr行集合[j];
                            if (sLine != null && !sLine.Equals(""))
                            {
                                string[] sArrItem = new string[nColCount];
                                string[] aTempArr = sLine.Split(vsSplitChar);
                                for (int i = 0; i < aTempArr.Length; i++)
                                {
                                    sArrItem[i] = aTempArr[i];
                                }
                                System.Data.DataRow dr = dt.NewRow();
                                //处理
                                if (aTempArr.Length < nColCount)
                                {
                                    for (int i = aTempArr.Length; i < nColCount; i++)
                                    {
                                        sArrItem[i] = string.Empty;
                                    }
                                }
                                //赋值
                                for (int i = 0; i < nColCount; i++)
                                {
                                    dr["数据列" + i] = sArrItem[i];
                                }
                                dt.Rows.Add(dr);
                            }
                        }
                        iniReader.Close();
                        return dt;
                    }
                    else
                    {
                        return null;
                    }
                }
                #endregion
            }
            catch (Exception err)
            {
                basComm.MsgError(err.Message);
                return null;
            }
        }
        #endregion
        #region 获取病员费别ID:没有的自动新建
        public static string Get费别ID(string vs费别名称)
        {
            return AHC_InterFace.AHC_InterFace.Get费别ID(vs费别名称);
        }
        #endregion
        #region 格式化XML值:处理转义字符
        public static string Do格式化XML值(string vs原XML值)
        {
            return vs原XML值.Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&amp;").Replace("\"", "&quot;").Replace("'", "&apos;");
        }
        #endregion
        #region 更新住院档案:转医保登记或者撤销医保登记后如果病人记账单价需要随之变化则调用此功能
        public static void Do更新住院档案(long vl住院序号)
        {
            try
            {
                string sXML = string.Format("<info><proc 名称='INF_PD住院档案_修改'><vl住院序号>{0}</vl住院序号></proc></info>", vl住院序号);
                string s单据序号 = string.Empty;
                DB.CallDB(sXML, ref s单据序号);
            }
            catch (Exception err)
            {
                throw;
            }
        }
        #endregion
        /// <summary>
        /// 向本地写入文本日志
        /// </summary>
        /// <param name="vsString">要记录的文本内容</param>
        public static void WriteLog(string vsString)
        {
            try
            {
                string logFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, typeof(InterFace).Assembly.GetName().Name + "/日志");
                if (!Directory.Exists(logFilePath))
                {
                    Directory.CreateDirectory(logFilePath);
                }
                string logFile = logFilePath + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                using (StreamWriter sw = new StreamWriter(logFile, true))
                {
                    sw.WriteLine(string.Format("【{0}】", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                    sw.WriteLine(vsString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 根据定义的列信息，获取表格设置的XML，不显示的列设置宽度为0即可
        /// </summary>
        /// <param name="sFormat">两种格式:列1|宽度;列2|宽度，或者:列名1|显示文字1|宽度;列名2|显示文字2|宽度2</param>
        public static string GetGridFormatXML(string sFormat)
        {
            try
            {
                StringBuilder sbXML = new StringBuilder("<info>\r\n<fields>\r\n");
                string[] arr = sFormat.TrimEnd(';').Split(';');
                foreach (var s in arr)
                {
                    string[] temp = s.Split('|');
                    string sTemp =
                        "\t<col 名称=\"{0}\" 标题=\"{1}\" 类型=\"S\" 宽度=\"{2}\" 必选=\"1\" 选用=\"1\" 表头对齐=\"C\" 表格对齐=\"L\" 合计=\"0\" />\r\n";
                    if (temp.Length == 3)
                    {
                        sTemp = string.Format(sTemp, temp[0].Trim(), temp[1].Trim(), temp[2].Trim());
                    }
                    else if (temp.Length == 2)
                    {
                        sTemp = string.Format(sTemp, temp[0].Trim(), temp[0].Trim(), temp[1].Trim());
                    }
                    sbXML.Append(sTemp);
                }
                //添加结束节点
                sbXML.Append("</fields>\r\n</info>\r\n");
                return sbXML.ToString();
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// AgridList控件根据SQL语句自动设置列后加载数据
        /// </summary>
        /// <param name="sFormat"></param>
        public static void AgridLoadDataFromSQL(ACtrllist.AGridList grid, string sSQL)
        {
            try
            {
                IRecordSet rs = DB.ExecSQL(string.Format("select * from({0})T where rownum<2", sSQL));
                StringBuilder sbXML = new StringBuilder("<info>\r\n<fields>\r\n");
                for (int i = 0; i < rs.GetColCount(); i++)
                {
                    string sColName = rs.GetFieldName(i).Trim();
                    string sTemp = "\t<col 名称=\"{0}\" 标题=\"{1}\" 类型=\"S\" 宽度=\"{2}\" 必选=\"1\" 选用=\"1\" 表头对齐=\"C\" 表格对齐=\"L\" 合计=\"0\" />\r\n";
                    sTemp = string.Format(sTemp, sColName, sColName, sColName.Equals("系统序号") ? 0 : sColName.Length * 20);
                    sbXML.Append(sTemp);
                }
                //添加结束节点
                sbXML.Append("</fields>\r\n</info>\r\n");
                grid.SetFormatXML(sbXML.ToString());
                grid.LoadList(sSQL);
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// 用于修改pCtrl窗口指定控件的指定属性值
        /// </summary>
        /// <param name="pCtrl">当前窗口对象,由窗口打开时获取</param>
        /// <param name="vsName">要修改的控件名称</param>
        /// <param name="vsAttr">要修改的控件属性</param>
        /// <param name="vsValue">要修改的控件值</param>
        public static void Do修改控件(object pCtrl, string vsName, string vsAttr, object vsValue)
        {
            AHC_InterFace.AHC_InterFace.Do修改控件(pCtrl, vsName, vsAttr, vsValue);
        }
        /// <summary>
        /// 获取指定控件的指定属性值,如:Name属性
        /// </summary>
        /// <param name="pCtrl">当前窗口对象,由窗口打开时获取</param>
        /// <param name="vsName">要获取的控件名称</param>
        /// <param name="vsAttr">要获取的控件属性名称</param>
        /// <returns>获取后的属性值</returns>
        public static object Do获取控件属性值(object pCtrl, string vsName, string vsAttr)
        {
            return AHC_InterFace.AHC_InterFace.Do获取控件属性值(pCtrl, vsName, vsAttr);
        }
        /// <summary>
        /// 从指定窗口获取一个公开变量值
        /// </summary>
        /// <param name="pCtrl">当前窗口对象,由窗口打开时获取</param>
        /// <param name="vsName">公开变量名称</param>
        /// <returns>获取到的变量值</returns>
        public static object Do窗口变量取值(object pCtrl, string vsName)
        {
            return AHC_InterFace.AHC_InterFace.Do窗口变量取值(pCtrl, vsName);
        }
        /// <summary>
        /// 为指定窗口的公开变量赋值
        /// </summary>
        /// <param name="pCtrl">当前窗口对象,由窗口打开时获取</param>
        /// <param name="vsName">公开变量名称</param>
        /// <param name="vsValue">变量值</param>
        public static void Do窗口变量赋值(object pCtrl, string vsName, object vsValue)
        {
            AHC_InterFace.AHC_InterFace.Do窗口变量赋值(pCtrl, vsName, vsValue);
        }
        /// <summary>
        /// 在指定窗口的指定接口面板处增加一个按钮
        /// </summary>
        /// <param name="vsName">按钮名称</param>
        /// <param name="vsText">按钮文本</param>
        /// <param name="pCtrl">当前窗口对象,由窗口打开时获取</param>
        /// <param name="pCmd">当前窗口接口面板,由窗口打开时获取</param>
        public static void Do新增按钮(string vsName, string vsText, object pCtrl, object pCmd)
        {
            AHC_InterFace.AHC_InterFace.Do新增按钮(vsName, vsText, pCtrl, pCmd);
        }
        /// <summary>
        /// 获取指定窗口的属性值,如:name属性
        /// </summary>
        /// <param name="pCtrl">当前窗口对象,由窗口打开时获取</param>
        /// <param name="vsAttr">属性名称</param>
        /// <returns>获取到的属性值</returns>
        public static object Do获取窗口属性值(object pCtrl, string vsAttr)
        {
            return AHC_InterFace.AHC_InterFace.Do获取窗口属性值(pCtrl, vsAttr);
        }
        /// <summary>
        /// 设置指定窗口的一个属性值
        /// </summary>
        /// <param name="pCtrl">当前窗口对象,由窗口打开时获取</param>
        /// <param name="vsAttr">属性名称</param>
        /// <param name="vsValue">要设置的属性值</param>
        public static void Do设置窗口属性值(object pCtrl, string vsAttr, string vsValue)
        {
            AHC_InterFace.AHC_InterFace.Do设置窗口属性值(pCtrl, vsAttr, vsValue);
        }
        /// <summary>
        /// 在系统主菜单->接口菜单下新增一个菜单,用于接口功能的扩展
        /// </summary>
        /// <param name="vsName">菜单名称</param>
        /// <param name="vsText">菜单文本</param>
        /// <param name="vsParentName">上级菜单名称</param>
        public static void Do新增菜单(string vsName, string vsText, string vsParentName)
        {
            AHC_InterFace.AHC_InterFace.Do新增菜单(vsName, vsText, vsParentName);
        }
        /// <summary>
        /// 在系统主菜单->接口菜单下新增一个菜单,用于接口功能的扩展
        /// </summary>
        /// <param name="vsName">菜单名称</param>
        /// <param name="vsText">菜单文本</param>
        public static void Do新增菜单(string vsName, string vsText)
        {
            AHC_InterFace.AHC_InterFace.Do新增菜单(vsName, vsText);
        }
        /// <summary>
        /// 在住院护理中心床位档案处新增一个右键菜单
        /// </summary>
        /// <param name="vsName">菜单名称</param>
        /// <param name="vsText">菜单文本</param>
        /// <param name="pMenuz">菜单对象,由窗口打开时获取</param>
        public static void Do新增右键菜单(string vsName, string vsText, object pMenuz)
        {
            AHC_InterFace.AHC_InterFace.Do新增右键菜单(vsName, vsText, pMenuz);
        }
        /// <summary>
        /// 在住院护理中心床位档案处新增一个右键菜单
        /// </summary>
        /// <param name="vsName">菜单名称</param>
        /// <param name="vsText">菜单文本</param>
        /// <param name="pMenuz">菜单对象,由窗口打开时获取</param>
        /// <param name="vsParentName">上级菜单名称</param>
        public static void Do新增右键菜单(string vsName, string vsText, object pMenuz, string vsParentName)
        {
            AHC_InterFace.AHC_InterFace.Do新增右键菜单(vsName, vsText, pMenuz, vsParentName);
        }
        /// <summary>
        /// 列举当前指定窗口所有的子控件信息,成功会提示本地路径
        /// </summary>
        /// <param name="pForm">当前窗口对象,由窗口打开时获取</param>
        public static void Do列举控件名称(object pForm)
        {
            AHC_InterFace.AHC_InterFace.Do列举控件名称(pForm);
        }
        /// <summary>
        /// 读取一个ini配置文件参数值
        /// </summary>
        /// <param name="vsFileName">文件路径</param>
        /// <param name="Section">配置节点</param>
        /// <param name="Ident">配置参数名</param>
        /// <param name="vsDefault">默认值</param>
        /// <returns>获取到的本地参数值</returns>
        public static string ReadIni(string vsFileName, string Section, string Ident, string vsDefault = "")
        {
            return AHC_InterFace.AHC_InterFace.ReadIni(vsFileName, Section, Ident, vsDefault).Replace("\0", "");
        }
        /// <summary>
        /// 向本地DebugSql调试器发送一条调试文本信息
        /// </summary>
        /// <param name="vsText">要发送的文本信息</param>
        public static void SendDebugText(string vsText)
        {
            AHC_InterFace.AHC_InterFace.SendDebugText(vsText);
        }
        /// <summary>
        /// 提示一个文本框
        /// </summary>
        /// <param name="vsText">提示文本</param>
        /// <param name="veIcon">提示图标</param>
        /// <param name="viWaitTime">多长时间自动关闭,0表示不关闭,秒为单位</param>
        static public void MsgBox(string vsText, MessageBoxIcon veIcon = MessageBoxIcon.Warning, int viWaitTime = 0)
        {
            AHC_InterFace.AHC_InterFace.MsgBox(vsText, veIcon, viWaitTime);
        }
        /// <summary>
        /// 提示一个错误文本框
        /// </summary>
        /// <param name="vsText">提示文本</param>
        /// <param name="veIcon">提示图标</param>
        /// <param name="vbSaveScreen">是否保存当前屏幕信息</param>
        static public void MsgError(string vsText, MessageBoxIcon veIcon = MessageBoxIcon.Warning, bool vbSaveScreen = false)
        {
            AHC_InterFace.AHC_InterFace.MsgError(vsText, veIcon, vbSaveScreen);
        }
        static public void MsgAndWriteError(string vsText, MessageBoxIcon veIcon = MessageBoxIcon.Warning, bool vbSaveScreen = false)
        {
            AHC_InterFace.AHC_InterFace.MsgError(vsText, veIcon, vbSaveScreen);
            WriteLog(vsText);
        }

        /// <summary>
        /// 提示一个是/否 选择框
        /// </summary>
        /// <param name="vsText">提示文本</param>
        /// <param name="vbDefYes">true:默认是;false:默认否</param>
        /// <returns>true:选择是;false:选择否</returns>
        static public bool MsgBoxYN(string vsText, bool vbDefYes = true)
        {
            return AHC_InterFace.AHC_InterFace.MsgBoxYN(vsText, vbDefYes);
        }
        /// <summary>
        /// 提示一个 确定/取消 选择框
        /// </summary>
        /// <param name="vsText">提示文本</param>
        /// <param name="vbDefSure">true:默认确定;false:默认取消</param>
        /// <returns>true:选择确定;false:选择取消</returns>
        static public bool MsgBoxSC(string vsText, bool vbDefSure = true)
        {
            return AHC_InterFace.AHC_InterFace.MsgBoxSC(vsText, vbDefSure);
        }
        /// <summary>
        /// 提示一个 是/否/取消 选择框
        /// </summary>
        /// <param name="vsText">提示文本</param>
        /// <param name="viDefButton">1:默认是;2:默认否;3:默认取消</param>
        /// <returns>1:选择是;2:选择否;3:选择取消</returns>
        static public int MsgBoxYNC(string vsText, int viDefButton = 1)
        {
            return AHC_InterFace.AHC_InterFace.MsgBoxYNC(vsText, viDefButton);
        }
        //2017年8月26日
        public static string Do获取表格数据(object pForm, string gridName, string columnName, int rowIndex = -1)
        {
            return AHC_InterFace.AHC_InterFace.Do获取表格数据(pForm, gridName, columnName, rowIndex);
        }
    }
}