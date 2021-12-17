using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using IF_P工伤医保.baseComm;
using IF_P工伤医保.baseForm;
using IF_P工伤医保.MyCode;

namespace IF_P工伤医保.baseData
{
    internal static class basData
    {
        #region 内置全局变量
        public static string pStr终端名称 = "";
        public static long pInt终端序号 = 0;
        public static long pInt操作员编号 = 0;

        public static string pStr操作员名称 = "";

        private static int gl当前组件版本 = 0;

        public static long pInt隶属机构编号 = 0;
        public static string pStr隶属机构名称 = "";

        public static int Gl当前组件版本
        {
            get { return basData.gl当前组件版本; }
            set { basData.gl当前组件版本 = value; }
        }
        #endregion
        #region 自定义全局变量
        public static bool gb保险客户端;
        public static decimal gd对账误差额;
        public static string gs日期时间格式化字符串 = "yyyy-MM-dd HH:mm:ss";
        public static string gs日期部分格式化字符串 = "yyyy-MM-dd 00:00:00";
        public static readonly string gsXML头 = "<?xml version=\"1.0\" encoding=\"GBK\" standalone=\"yes\" ?>\r\n";

        public static string gs就医地行政区划代码 = "";
        public static string gs接收方系统代码 = "";
        public static string gs设备编号 = "";
        public static string gs设备安全信息 = "";
        public static string gs签名类型 = "";
        public static string gs接口版本号 = "";
        public static string gs经办人类别 = "1";
        public static string gs定点医药机构编号 = "";
        public static string gs定点医药机构名称 = "";
        public static string pStr电子凭证Url = "";
        public static string gs卡鉴权Url = "";
        public static string gs读卡信息 = "";//读卡后赋值  特殊查询业务使用 尽量减少使用
        public static string gs参保经办地 = "";//读卡后赋值  特殊查询业务使用 尽量减少使用
        public static string gsAppPah = "";

        public static string mac = "00-00-00-00-00-00";
        public static string ip = "127.0.0.1";
        public static string gs接口简名 = "工伤保险";
        public static string pStr保险类别 = "市医保";
        public static bool gb已升级缴费序号 = true;
        public static string pStr自费费别名称 = "普通病员";
        public static string gs定点医药机构用户号 = "";
        public static string gs门诊挂号参数 = "";
        public static string gs读卡密码验证 = "1";
        public static string gs本地启用诊断绑定 = "0";
        public static string gs科室诊断名称 = "";
        public static string gs特殊诊断启用标识 = "0";
        public static string gs特殊诊断编码 = "";
        public static string gs特殊诊断名称 = "";
        public static string gs门诊健康id = "";
    

        public static string gs社保机构编号 = "";
        public static string gs医院编码 = "";
        public static string gs工伤保险url = "";


        #region 属性：下载文件输出目录
        public static string gs下载文件输出目录
        {
            get
            {
                string sTemp = basData.gsAppPah+ @"\DownLoad";

                #region 判断文件夹是否存在

                DirectoryInfo d = new DirectoryInfo(sTemp);
                if (!d.Exists)
                {
                    d.Create();
                }

                #endregion

                return sTemp;
            }
        }
        #endregion

        public static DataTable dt系统参数;
        public static void Do设置系统参数值1(long vl参数序号,string vs参数值)
        {
            if (dt系统参数 != null && dt系统参数.Rows.Count > 0)
            {
                DataRow[] row = dt系统参数.Select(string.Format("系统序号='{0}'", vl参数序号));
                if (row != null && row.Length > 0)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        row[i]["参数值1"] = vs参数值;
                    }
                }
            }
        }
        public static void Do设置系统参数值2(long vl参数序号, string vs参数值)
        {
            if (dt系统参数 != null && dt系统参数.Rows.Count > 0)
            {
                DataRow[] row = dt系统参数.Select(string.Format("系统序号='{0}'", vl参数序号));
                if (row != null && row.Length > 0)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        row[i]["参数值2"] = vs参数值;
                    }
                }
            }
        }
        public static string Do获取系统参数值1(long vl参数序号)
        {
            string sValue = string.Empty;
            if (dt系统参数 != null && dt系统参数.Rows.Count > 0)
            {
                DataRow[] row = dt系统参数.Select(string.Format("系统序号='{0}'", vl参数序号));
                if (row != null && row.Length > 0)
                {
                    return row[0]["参数值1"].ToString();
                }
            }
            return sValue;
        }
        public static string Do获取系统参数值2(long vl参数序号)
        {
            string sValue = string.Empty;
            if (dt系统参数 != null && dt系统参数.Rows.Count > 0)
            {
                DataRow[] row = dt系统参数.Select(string.Format("系统序号='{0}'", vl参数序号));
                if (row != null && row.Length > 0)
                {
                    return row[0]["参数值2"].ToString();
                }
            }
            return sValue;
        }
        #endregion
        #region 门诊费用明细SQL
        public static string Get获取门诊费用明细SQL(long vl缴费序号)
        {
            #region SQL 
            string sSQL = @"select distinct 
case when scjl.系统序号 is null then '' else '√' end as 已上传,
a.记账流水号 as 医嘱记录序号,a.医院项目名称 as 医嘱内容,
a.开单医生姓名 as 医生姓名,a.开单医生编号 as 医职人员编码,
a.开单科室编号 as 医嘱科室编码,a.开单科室名称 医嘱科室名称,g.中心项目编码 as 医院对码编码,'1' as 医嘱类别,'' as 医嘱分类,
a.单位 as 剂量单位,a.数量 as 剂量,yytj.中心字典编码 as 用药途径,a.用药剂量 as 每次数量,a.单位 as 每次数量单位,a.数量 as 发药量,
a.单位 as 发药量单位,yypc.中心字典编码 as 频次,a.周期天数 as 使用天数,nvl(scjl.门统记账流水号,a.记账流水号) as 记账流水号,g.中心项目编码 as 医保项目编码,
g.本地项目组合码 as 本地项目组合码,a.医院项目序号 as 医院项目编号,
a.医院项目名称,a.数量 as 数量,a.单价 as 单价,a.金额,decode(g.药品限制使用范围,'','',null,'','1') as 医院审核标志,a.开单科室编号 as 开单科室编码,
a.开单科室名称,a.执行科室编号 as 受单科室编码,a.执行科室名称 as 受单科室名称,a.开单医生姓名 as 开单医生,a.开单医生编号 as 开单医生编码,a.开单医生姓名 as 受单医生,
a.开单医生姓名 as 经办人姓名,to_char(a.记账时间,'yyyy-mm-dd hh24:mi:ss') as 明细录入时间,to_char(a.记账时间,'yyyy-mm-dd hh24:mi:ss') as 明细发生时间,'' as 手术编号,
'' as 备注,decode(a.类别,'中药' , '1','') as 中药使用方式,a.记账流水号 as 处方号,a.单价 as 药品进价,a.药品规格 as 规格,a.药品剂型 as 剂型,mtfylb.中心字典编码 as 门统费用分类代码
from INF_VI门诊费用明细 a
left join INF_DAHYB_目录对码表 g on a.医院项目目录序号 = g.本地项目编号 and g.本地项目类型=a.类别 and g.隶属机构I=a.隶属机构i
left join INF_DAHYB_字典对码表 mtfylb on a.费用类别i =mtfylb.本地字典编号 and mtfylb.本地字典类型='YKE447' and mtfylb.隶属机构I=a.隶属机构i
left join INF_DAHYB_字典对码表 yytj on a.给药方式I =yytj.本地字典编号 and yytj.本地字典类型='rute' and yytj.隶属机构I=a.隶属机构i
left join INF_DAHYB_字典对码表 yypc on a.用药频率i =yypc.本地字典编号 and yypc.本地字典类型='BKC045' and yypc.隶属机构I=a.隶属机构i
left join INF_DAHYB_门诊明细上传记录表 scjl on a.记账流水号 = scjl.记账流水号 and scjl.隶属机构I=a.隶属机构i And scjl.收费模式=1
where a.金额<>0 And a.缴费序号i='{0}'";
            #endregion

            return string.Format(sSQL, vl缴费序号);
        }
        public static string Get获取门诊费用明细SQL(string vs门诊临时序号,string vl挂号序号, bool vb分单退费新建单据)
        {
            #region SQL
            string sSQL = "";
            if (!vb分单退费新建单据)
            {
                #region 收费新建单据
                    sSQL = @"select distinct a.记账流水号,
                        jzlb.就诊科室I as 医嘱科室编码,jzlb.就诊科室 as 医嘱科室名称,'1' as 医嘱类别,'' as 医嘱分类,
                        a.单位 as 剂量单位,a.数量 as 剂量,yytj.名称 as 用药途径,a.用药剂量 as 每次数量,a.单位 as 每次数量单位,a.数量 as 发药量,
                        a.单位 as 发药量单位,yypc.名称 as 频次,用药天数 as 使用天数,g.中心项目编码,g.中心项目名称,g.中心收费类别,g.中心医保项目,a.项目序号i as 医院项目编号,g.本地项目组合码,
                        decode(g.审核标志,'1',g. 本地项目名称,b.名称) as 本地项目名称,a.数量 as 数量,a.单价 as 单价,a.金额,g.审核标志 as 审核标志,g.上传标志 ,a.开单科室i as 开单科室编码,
                        kdks.名称 as 开单科室名称,a.执行科室i as 受单科室编码,sdks.名称 as 受单科室名称,kdys.名称 as 开单医生,nvl(ybysbm.国家医保编码,kdys.编码) as 开单医生编码,kdys.名称 as 受单医生,
                        kdys.名称 as 经办人姓名,to_char(a.操作时间,'yyyy-mm-dd hh24:mi:ss') as 明细录入时间,to_char(a.操作时间,'yyyy-mm-dd hh24:mi:ss') as 明细发生时间,'' as 手术编号,
                        '' as 备注,a.处方号,a.处方日期,a.单价 as 药品进价,decode(g.审核标志,'1',g.本地项目规格,b.药品规格) as 规格,decode(g.审核标志,'1',g. 本地项目剂型,b.剂型) as 剂型,a.草药单复方标识,to_char(sysdate,'yyyy-mm-dd hh24:mi:ss') as 系统时间,to_char(sysdate,'yyyymmdd') as 系统日期,g.医院审批标志
                        from (
                        --项目
                        select 'XM'||a.系统序号 as 处方号,to_char(a.操作时间,'yyyy-mm-dd hh24:mi:ss') as 处方日期 ,to_char('')  as 用药频率i,to_char('') as 给药方式i,to_char('次')as 单位,a.系统序号 as 收费单序号i,a.项目序号i,to_char('1'||a.系统序号) as 记账流水号,round(a.执行单价,4) as 单价,  round(a.数量,4) as 数量,round( round(a.执行单价,4) * round(a.数量,4),4) as 金额,
                        a.开单科室i,a.开单医生r,a.执行科室i,'项目' as 类别,to_char(a.包明细数量) as 用药剂量,'1' as 用药天数,A.就诊序号i,A.操作时间,N'' as 草药单复方标识,''as 医保药师代码,'' as 医保药师名称
                        from CNC_VD门诊费用记账_收费 a  
                        where a.项目类型 ='项目' and a.冲销状态N=0 and a.已作废B=0
                        and a.缴费序号i='{0}' and a.隶属机构i='{1}' and a.挂号序号i='{2}'
                        union all
                        --西药
                        select 'XY'||c.系统序号 as 处方号,to_char(c.划价时间,'yyyy-mm-dd hh24:mi:ss') as 处方日期 ,to_char(d.用药频率i) as 用药频率i,to_char(d.给药方式i) as 给药方式i, to_char(d.剂量单位) as 单位, a.系统序号 as 收费单序号i,d.药品序号i as 项目序号i,to_char('2'||d.系统序号) as 记账流水号,round(d.零售单价,4) as 单价,  round(d.数量,2) as 数量,round(round(d.零售单价,4) * round(d.数量,2),2) as 金额,
                        a.开单科室i,a.开单医生r,a.执行科室i,'西药' as 类别,to_char(d.用药剂量) as 用药剂量,to_char(d.周期天数) as 用药天数,A.就诊序号i,A.操作时间,N'' as 草药单复方标识,to_char(fyr.资格证书编号) as 医保药师代码,to_char(fyr.名称) as 医保药师名称
                        from CNC_VD门诊费用记账_收费 a 
                        inner join dug_vd西药房门诊处方单 c on a.业务序号i = c.系统序号
                        inner join dug_vd西药房门诊处方明细 d on c.系统序号 = d.单据序号i
                        left join doc_t员工档案 fyr on fyr.系统序号=c.发药人R
                        where a.项目类型 ='西药' and a.冲销状态N=0 And C.状态N='0'
                        and  a.缴费序号i='{0}' and a.隶属机构i='{1}' and a.挂号序号i='{2}'
                        union all 
                        --中药
                        select 'ZY'||c.系统序号 as 处方号,to_char(c.划价时间,'yyyy-mm-dd hh24:mi:ss') as 处方日期 ,to_char(c.用药频率i) as 用药频率i,to_char(c.给药方式i) as 给药方式i,to_char(d.计量单位) as 单位,a.系统序号 as 收费单序号i,d.药品序号i as 项目序号i,to_char('3'||d.系统序号) as 记账流水号,round(d.零售单价,4) as 单价,round(c.付数 * d.数量,4) as 数量,round(round(d.零售单价,4)*round(c.付数 * d.数量,4),2) as 金额,
                        a.开单科室i,a.开单医生r,a.执行科室i,'中药' as 类别,to_char(d.数量) as 用药剂量,'1' as 用药天数,A.就诊序号i,A.操作时间,case when b.草药味数>1 then N'1' else N'2' end  as 草药单复方标识,to_char(fyr.资格证书编号) as 医保药师代码,to_char(fyr.名称) as 医保药师名称
                        from CNC_VD门诊费用记账_收费 a 
                        inner join dug_vd中药房门诊处方单 c on a.业务序号i = c.系统序号
                        inner join dug_vd中药房门诊处方明细 d on c.系统序号 = d.单据序号i
                        inner join (
                            select a.业务序号i,count(distinct d.药品序号i) as 草药味数
                            from CNC_VD门诊费用记账_收费 a 
                            inner join dug_vd中药房门诊处方单 c on a.业务序号i = c.系统序号
                            inner join dug_vd中药房门诊处方明细 d on c.系统序号 = d.单据序号i
                            where a.项目类型 ='中药' and a.冲销状态N=0 And C.状态N='0'
                            and a.缴费序号i='{0}' and a.隶属机构i='{1}' and a.挂号序号i='{2}'
                            group by a.业务序号i) b on a.业务序号i=b.业务序号i
                        left join doc_t员工档案 fyr on fyr.系统序号=c.发药人R
                        where a.项目类型 ='中药' and a.冲销状态N=0 And C.状态N='0'
                        and a.缴费序号i='{0}' and a.隶属机构i='{1}' and a.挂号序号i='{2}'
                        ) a 
                        inner join doc_vt药品收费项目 b on a.项目序号i = b.系统序号 and a.类别 = b.类别  and b.隶属机构i='{1}'
                        left join Inf_DAHYB_项目对码 g on b.系统序号 = g.本地项目编号 and g.本地项目类型=b.子类别 and g.隶属机构I='{1}'
                        left join doc_t给药方式 yytj on a.用药频率i =yytj.系统序号
                        left join doc_t用药频率 yypc on a.用药频率i =yypc.系统序号
                        left join cnc_vd门诊就诊列表 jzlb on A.就诊序号i=jzlb.系统序号
                        left join doc_T科室档案 kdks on  a.开单科室i = kdks.系统序号
                        left join doc_T科室档案 sdks on  a.执行科室i = sdks.系统序号
                        left join doc_T员工档案 kdys on a.开单医生r = kdys.系统序号
                        left join INF_DAHYB_医执人员档案 ybysbm on ybysbm.编号i= a.开单医生r";
                #endregion
                    sSQL = string.Format(sSQL, vs门诊临时序号, baseData.basData.pInt隶属机构编号,vl挂号序号);
            }
            else
            {
                #region 分单退费新建单据
                sSQL = @"select distinct a.记账流水号,
jzlb.就诊科室I as 医嘱科室编码,jzlb.就诊科室 as 医嘱科室名称,'1' as 医嘱类别,'' as 医嘱分类,
a.单位 as 剂量单位,a.数量 as 剂量,yytj.名称 as 用药途径,a.用药剂量 as 每次数量,a.单位 as 每次数量单位,a.数量 as 发药量,
a.单位 as 发药量单位,yypc.名称 as 频次,用药天数 as 使用天数,g.中心项目编码,g.中心项目名称,g.中心收费类别,g.中心医保项目,a.项目序号i as 医院项目编号,g.本地项目组合码,
decode(g.审核标志,'1',g. 本地项目名称,b.名称) as 本地项目名称,a.数量 as 数量,a.单价 as 单价,a.金额,g.审核标志 as 审核标志,g.上传标志 ,a.开单科室i as 开单科室编码,
kdks.名称 as 开单科室名称,a.执行科室i as 受单科室编码,sdks.名称 as 受单科室名称,kdys.名称 as 开单医生,nvl(ybysbm.国家医保编码,kdys.编码) as 开单医生编码,kdys.名称 as 受单医生,
kdys.名称 as 经办人姓名,to_char(a.操作时间,'yyyy-mm-dd hh24:mi:ss') as 明细录入时间,to_char(a.操作时间,'yyyy-mm-dd hh24:mi:ss') as 明细发生时间,'' as 手术编号,
'' as 备注,a.处方号,a.处方日期,a.单价 as 药品进价,decode(g.审核标志,'1',g.本地项目规格,b.药品规格) as 规格,decode(g.审核标志,'1',g. 本地项目剂型,b.剂型) as 剂型,a.草药单复方标识,to_char(sysdate,'yyyy-mm-dd hh24:mi:ss') as 系统时间,to_char(sysdate,'yyyymmdd') as 系统日期,g.医院审批标志
from (
--项目
select 'TXM'||a.系统序号 as 处方号,to_char(a.操作时间,'yyyy-mm-dd hh24:mi:ss') as 处方日期 ,to_char('')  as 用药频率i,to_char('') as 给药方式i,to_char('次')as 单位,a.系统序号 as 收费单序号i,a.项目序号i,to_char('T1'||a.系统序号) as 记账流水号,round(a.执行单价,4) as 单价,round(decode(a.打包序号i,null,a.数量,a.包明细数量),2) as 数量,round(round(a.执行单价,4) * round(decode(a.打包序号i,null,a.数量,a.包明细数量),2),2) as 金额,
a.开单科室i,a.开单医生r,a.执行科室i,'项目' as 类别,to_char(a.包明细数量) as 用药剂量,'1' as 用药天数,A.就诊序号i,A.操作时间,N'' as 草药单复方标识
from CNC_D门诊费用记账_零退 a  
where a.项目类型 ='项目'  and a.已作废B=0
and a.退费序号I='{0}' 
union all
--西药
select 'TXY'||c.系统序号 as 处方号,to_char(c.划价时间,'yyyy-mm-dd hh24:mi:ss') as 处方日期 ,to_char(d.用药频率i) as 用药频率i,to_char(d.给药方式i) as 给药方式i, to_char(d.剂量单位) as 单位, a.系统序号 as 收费单序号i,d.药品序号i as 项目序号i,to_char('T2'||d.系统序号) as 记账流水号,round(d.零售单价,4) as 单价,  round(d.数量,2) as 数量,round(round(d.零售单价,4) * round(d.数量),2) as 金额,
a.开单科室i,a.开单医生r,a.执行科室i,'西药' as 类别,to_char(d.用药剂量) as 用药剂量,to_char(d.周期天数) as 用药天数,A.就诊序号i,A.操作时间,N'' as 草药单复方标识
from CNC_D门诊费用记账_零退 a 
inner join dug_vd西药房门诊处方单 c on a.业务序号i = c.系统序号
inner join dug_vd西药房门诊处方明细 d on c.系统序号 = d.单据序号i
where a.项目类型 ='西药' 
and  a.退费序号I='{0}' 
union all 
--中药
select 'TZY'||c.系统序号 as 处方号,to_char(c.划价时间,'yyyy-mm-dd hh24:mi:ss') as 处方日期 ,to_char(c.用药频率i) as 用药频率i,to_char(c.给药方式i) as 给药方式i,to_char(d.计量单位) as 单位,a.系统序号 as 收费单序号i,d.药品序号i as 项目序号i,to_char('T3'||d.系统序号) as 记账流水号,round(d.零售单价,4) as 单价,round(c.付数 * d.数量,4) as 数量,round(round(d.零售单价,4)*round(c.付数 * d.数量,4),2) as 金额,
a.开单科室i,a.开单医生r,a.执行科室i,'中药' as 类别,to_char(d.数量) as 用药剂量,'1' as 用药天数,A.就诊序号i,A.操作时间,case when b.草药味数>1 then N'1' else N'2' end  as 草药单复方标识
from CNC_D门诊费用记账_零退 a 
inner join dug_vd中药房门诊处方单 c on a.业务序号i = c.系统序号
inner join dug_vd中药房门诊处方明细 d on c.系统序号 = d.单据序号i
inner join (
    select a.业务序号i,count(distinct d.药品序号i) as 草药味数
    from CNC_D门诊费用记账_零退 a 
    inner join dug_vd中药房门诊处方单 c on a.业务序号i = c.系统序号
    inner join dug_vd中药房门诊处方明细 d on c.系统序号 = d.单据序号i
    where a.项目类型 ='中药' 
    and a.退费序号I='{0}' 
    group by a.业务序号i) b on a.业务序号i=b.业务序号i
where a.项目类型 ='中药' 
and a.退费序号I='{0}' 
) a 
inner join doc_vt药品收费项目 b on a.项目序号i = b.系统序号 and a.类别 = b.类别  and b.隶属机构i='{1}'
left join Inf_DAHYB_项目对码 g on b.系统序号 = g.本地项目编号 and g.本地项目类型=b.子类别 and g.隶属机构I='{1}'
left join doc_t给药方式 yytj on a.用药频率i =yytj.系统序号
left join doc_t用药频率 yypc on a.用药频率i =yypc.系统序号
left join cnc_vd门诊就诊列表 jzlb on A.就诊序号i=jzlb.系统序号
left join doc_T科室档案 kdks on  a.开单科室i = kdks.系统序号
left join doc_T科室档案 sdks on  a.执行科室i = sdks.系统序号
left join doc_T员工档案 kdys on a.开单医生r = kdys.系统序号
left join INF_DAHYB_医执人员档案 ybysbm on ybysbm.编号i= a.开单医生r";

                #endregion 分单退费新建单据
                sSQL = string.Format(sSQL, vs门诊临时序号, baseData.basData.pInt隶属机构编号);
            }
            return sSQL;
        }
        #endregion
        #region 住院费用明细SQL
        public static string Get获取住院费用明细SQL(string vs住院序号, bool vb允许传退费明细 = false)
        {
//            grid费用明细列表.SetFormatXML(@"<info>
//  <fields>    
//    <col 名称=""已上传"" 标题=""已上传"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
//    <col 名称=""操作信息"" 标题=""上传消息"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""记账流水号"" 标题=""记账流水号"" 类型=""S"" 宽度=""80"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />
//    <col 名称=""本地项目组合码"" 标题=""本地项目组合码"" 类型=""S"" 宽度=""120"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""医院项目名称"" 标题=""医院项目名称"" 类型=""S"" 宽度=""200"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""中心项目编码"" 标题=""中心项目编码"" 类型=""S"" 宽度=""70"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />
//    <col 名称=""中心项目名称"" 标题=""中心项目名称"" 类型=""S"" 宽度=""130"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""中心收费类别"" 标题=""中心收费类别"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""中心项目类别"" 标题=""中心项目类别"" 类型=""S"" 宽度=""30"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""规格"" 标题=""规格"" 类型=""S"" 宽度=""130"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""剂型"" 标题=""剂型"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""单位"" 标题=""单位"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""数量"" 标题=""数量"" 类型=""S"" 宽度=""80"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""单价"" 标题=""单价"" 类型=""S"" 宽度=""80"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""金额"" 标题=""金额"" 类型=""S"" 宽度=""80"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""开单医师编码"" 标题=""开单医师编码"" 类型=""S"" 宽度=""120"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""开单医师姓名"" 标题=""开单医师姓名"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""开单科室编码"" 标题=""开单科室编码"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""开单科室名称"" 标题=""开单科室名称"" 类型=""S"" 宽度=""120"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""经办人姓名"" 标题=""经办人姓名"" 类型=""S"" 宽度=""120"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""明细录入时间"" 标题=""记账时间"" 类型=""S"" 宽度=""130"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />    
//    <col 名称=""医保医师名称"" 标题=""医保医师名称"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />  
//    <col 名称=""医保医师代码"" 标题=""医保医师代码"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />  
//    <col 名称=""医保药师名称"" 标题=""医保药师名称"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />  
//    <col 名称=""原费用流水号"" 标题=""原费用流水号"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />  
//    <col 名称=""受单科室编码"" 标题=""受单科室编码"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />  
//    <col 名称=""受单科室名称"" 标题=""受单科室名称"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />  
//    <col 名称=""受单医生编码"" 标题=""受单医生编码"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />  
//    <col 名称=""受单医生姓名"" 标题=""受单医生姓名"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />  
//    <col 名称=""医院审批标志"" 标题=""医院审批标志"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />  
//    <col 名称=""中药使用方式"" 标题=""中药使用方式"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />  
//    <col 名称=""外检标志"" 标题=""外检标志"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />  
//    <col 名称=""外检医院编码"" 标题=""外检医院编码"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />  
//    <col 名称=""出院带药标志"" 标题=""出院带药标志"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />      
//    <col 名称=""生育费用标志"" 标题=""生育费用标志"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />  
//    <col 名称=""备注"" 标题=""备注"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" />      
//    <col 名称=""补报"" 标题=""补报"" 类型=""S"" 宽度=""20"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""L"" 合计=""0"" /> 
//</fields>
//</info>");
            //医院审批标志,外检标志,外检医院编码,出院带药标志,生育费用标志  //中药使用方式(单复方),
            #region SQL
            //剂型规格审批后取上报时规格剂型
            string sSQL;
            if (!vb允许传退费明细)
            {
                sSQL = @"select distinct
case when scjl.系统序号 is null then '' else '√' end as 已上传,
a.记账流水号,a.冲销序号 as 原费用流水号,b.系统序号 as 医院项目编号,decode(dmb.审核标志,'001',dmb. 本地项目名称,b.名称) as 医院项目名称,dmb.中心项目编码,
a.单价,a.数量,round(a.单价*a.数量,2)  as 金额 ,dmb. 中心项目名称,dmb.本地项目组合码,dmb.中心收费类别,dmb.中心项目类别,dmb.中心医保项目 as 医保项目,a.单位,
kdks.名称 as 开单科室名称,nvl(YBSDKS.平台编码, a.执行科室i) as 受单科室编码,sdks.名称 as 受单科室名称,kdys.名称 as 开单医师姓名,nvl(ybysbm.国家医保编码,kdys.编码) as 开单医师编码,nvl(YBKDKS.平台编码,a.开单科室i) as 开单科室编码,kdys.名称 as 受单医生,decode(dmb.审核标志,'001',dmb. 本地项目规格,b.药品规格) as 规格,decode(dmb.审核标志,'001',dmb.本地项目剂型,b.剂型) as 剂型,
kdys.名称 as 经办人姓名,to_char(a.记账时间,'yyyy-mm-dd hh24:mi:ss') as 明细录入时间,a.发生时间 as 明细发生时间,decode(dmb.上传标志,1, '√','') as 审核上传,decode(dmb.审核标志,'001','√','') as 审核标志,
'' as 备注,a.中药使用方式,a. 处方号,a.处方日期,a.单价 as 药品进价,decode(a.医嘱记录序号,'',A.记账流水号,'0',A.记账流水号) as 医嘱记录序号,g.系统序号 as 住院序号,a.医保药师代码,a.医保药师名称,dmb.目录限制使用标志,dmb.医院审批标志  as 医院审批标志,'0' as 外检标志,'' as 外检医院编码,'0' as 出院带药标志,'0' as 生育费用标志
from (
        --西药，卫材
        select 'XY'||c.系统序号 as 处方号,to_char(b.划价时间,'yyyy-mm-dd hh24:mi:ss') as 处方日期,to_char(nvl(a.执行时间,b.划价时间),'yyyy-mm-dd hh24:mi:ss') as 发生时间,c.退药数量 as 退药数量,to_char(c.用药频率i) as 用药频率i,to_char(c.给药方式i) as 给药方式i, '1'||to_char(c.系统序号) as 记账流水号, '1'||to_char(c.冲销序号i) as 冲销序号, a.单据序号i,a.住院序号i,c.药品序号i as 项目序号i,round(decode(c.数量-nvl(c.退药数量,0),0,case when (c.零售金额-nvl(c.退药金额,0))>0 then 1 else -1 end,c.数量-nvl(c.退药数量,0)),2) as 数量,to_char(c.单位) as 单位,round((c.零售金额-nvl(c.退药金额,0))/decode(c.数量-nvl(c.退药数量,0),0,case when (c.零售金额-nvl(c.退药金额,0))>0 then 1 else -1 end,c.数量-nvl(c.退药数量,0)),4) as 单价,round(c.零售金额-nvl(c.退药金额,0),2) as 金额,a.记账时间, a.开单科室i,a.开单医师r,a.执行科室i,'西药' as 类别,c.药品序号i as 医院项目编号,
        a.医嘱明细序号i as 医嘱记录序号,N'' as 中药使用方式,to_char(fyr.资格证书编号) as 医保药师代码,to_char(fyr.名称) as 医保药师名称
        from inq_d住院费用明细 a
        inner join dug_d西药房住院处方单 b on a.处方序号i = b.系统序号
        inner join dug_d西药房住院处方明细 c on b.系统序号 = c.单据序号i
        left join doc_t员工档案 fyr on fyr.系统序号=b.发药人r
        where a.处方序号I>0 and a.处方类型='西药' and a.住院序号i='{0}' And (c.零售金额-nvl(c.退药金额,0))>0
        union all
        --中药
        select 'ZY'||b.系统序号 as 处方号,to_char(b.划价时间,'yyyy-mm-dd hh24:mi:ss') as 处方日期,to_char(nvl(a.执行时间,b.划价时间),'yyyy-mm-dd hh24:mi:ss') as 发生时间 ,c.退药数量 as 退药数量,to_char(b.用药频率i) as 用药频率i,to_char(b.给药方式i) as 给药方式i,'2'||to_char(c.系统序号) as 记账流水号, '2'||to_char(c.正单序号i) as 冲销序号,a.单据序号i,a.住院序号i,c.药品序号i as 项目序号i,round(b.付数*(c.数量-nvl(c.退药数量,0)),2) as 数量,to_char(c.单位) as 单位,round(c.零售单价,4) as 单价,round(round(c.零售单价,4)*round((b.付数*(c.数量-nvl(c.退药数量,0))),2),2) as 金额,a.记账时间, a.开单科室i,a.开单医师r,a.执行科室i,'中药' as 类别,c.药品序号i as 医院项目编号,
        a.医嘱明细序号i as 医嘱记录序号,case when d.草药味数>1 then N'1' else N'2' end  as 中药使用方式,to_char(fyr.资格证书编号) as 医保药师代码,to_char(fyr.名称) as 医保药师名称
        from inq_d住院费用明细 a
        inner join dug_vd中药房住院处方单 b on a.处方序号i = b.系统序号
        inner join dug_vd中药房住院处方明细 c on b.系统序号 = c.单据序号i 
        inner join  ( select a.处方序号i,count(distinct c.药品序号i) as 草药味数
                        from inq_d住院费用明细 a
                        inner join dug_vd中药房住院处方明细 c on a.处方序号i = c.单据序号i
                        where a.处方序号I>0 and a.处方类型='中药' and a.住院序号i='{0}' And (c.数量-nvl(c.退药数量,0))>0
                        group by a.处方序号i) D on a.处方序号i=d.处方序号i
        left join doc_t员工档案 fyr on fyr.系统序号=b.发药人r
        where a.处方序号I>0 and a.处方类型='中药' and a.住院序号i='{0}' And (c.数量-nvl(c.退药数量,0))>0
        union all
        --收费项目及打包项目
        select  'XM'||a.系统序号 as 处方号,to_char(a.记账时间,'yyyy-mm-dd hh24:mi:ss') as 处方日期,to_char(a.记账时间,'yyyy-mm-dd hh24:mi:ss') as 发生时间 ,a.已退数量 as 退药数量,to_char('')  as 用药频率i,to_char('') as 给药方式i,'3'||to_char(a.系统序号) as 记账流水号,'3'||to_char(a.冲销序号i) as 冲销序号, a.单据序号i,a.住院序号i,a.收费项目序号i as 项目序号i,round((a.数量-nvl(a.已退数量,0)),2) as 数量,to_char('次') as 单位,round(a.执行单价,4) as 单价,round(round(a.执行单价,4)*round((a.数量-nvl(a.已退数量,0)),2),2) as 金额,a.记账时间, a.开单科室i,a.开单医师r,a.执行科室i,'项目' as 类别,d.系统序号 as 医院项目编号,
        a.医嘱明细序号i as 医嘱记录序号,N'' as 中药使用方式,'' as 医保药师代码,'' as 医保药师名称
        from inq_d住院费用明细 a
        inner join doc_vt收费项目价格表 d on a.收费项目序号I = d.系统序号
        where a.处方序号I=0 and a.住院序号i='{0}' And (a.数量-nvl(a.已退数量,0))>0
) a 
inner join doc_vt药品收费项目 b on a.项目序号i = b.系统序号 and a.类别 = b.类别  and b.隶属机构i='{1}'
inner join inq_d住院费用列表 f on a.单据序号i = f.系统序号
inner join inq_d住院档案 g on f.住院序号i = g.系统序号  
left join Inf_DAHYB_项目对码 dmb on B.系统序号=dmb.本地项目编号 and dmb.本地项目类型=b.子类别  and dmb.隶属机构I='{1}' 
left join INF_DAHYB_住院明细上传记录 scjl on a.记账流水号 = scjl.记账流水号 and g.系统序号=scjl.住院序号i and scjl.隶属机构I='{1}'
left join doc_T科室档案 kdks on a.开单科室i =kdks.系统序号
left join doc_T科室档案 sdks on a.执行科室i =sdks.系统序号
left join Doc_T员工档案 kdys on a.开单医师r= kdys.系统序号
left join INF_DAHYB_医执人员档案 ybysbm on ybysbm.编号i= a.开单医师r
left join inf_DAHYB_字典对码 YBKDKS on (YBKDKS.字典代码='dept' or YBKDKS.字典名='科室代码') and YBKDKS.本院编码=a.开单科室i
left join inf_DAHYB_字典对码 YBSDKS on (YBSDKS.字典代码='dept' or YBSDKS.字典名='科室代码') and YBSDKS.本院编码=a.执行科室i
where g.系统序号='{0}' 
order by 明细发生时间 ";
            }
            else
            {
                sSQL = @"select distinct
case when scjl.系统序号 is null then '' else '√' end as 已上传,
a.记账流水号,a.冲销序号 as 原费用流水号,b.系统序号 as 医院项目编号,decode(dmb.审核标志,'1',dmb. 本地项目名称,b.名称) as 医院项目名称,dmb.中心项目编码 ,
a.单价,a.数量,round(a.单价*a.数量,2)  as 金额 ,dmb.中心项目名称,dmb.本地项目组合码,dmb.中心收费类别,dmb.中心项目类别,dmb.中心医保项目 as 医保项目,a.单位,
kdks.名称 as 开单科室名称,nvl(YBSDKS.平台编码, a.执行科室i) as 受单科室编码,sdks.名称 as 受单科室名称,kdys.名称 as 开单医师姓名,nvl(ybysbm.国家医保编码,kdys.编码) as 开单医师编码,nvl(YBKDKS.平台编码,a.开单科室i) as 开单科室编码,kdys.名称 as 受单医生,decode(dmb.审核标志,'1',dmb. 本地项目规格,b.药品规格) as 规格,decode(dmb.审核标志,'1',dmb.本地项目剂型,b.剂型) as 剂型,
kdys.名称 as 经办人姓名,to_char(a.记账时间,'yyyy-mm-dd hh24:mi:ss') as 明细录入时间,a.发生时间 as 明细发生时间,decode(dmb.上传标志,1, '√','') as 审核上传,decode(dmb.审核标志,'001','√','') as 审核标志,
'' as 备注,a.草药单复方标识,a. 处方号,a.处方日期,a.单价 as 药品进价,decode(a.医嘱记录序号,'',A.记账流水号,'0',A.记账流水号) as 医嘱记录序号,g.系统序号 as 住院序号,a.医保药师代码,a.医保药师名称,dmb.目录限制使用标志,dmb.医院审批标志  as 医院审批标志,'0' as 外检标志,'' as 外检医院编码,'0' as 出院带药标志,'0' as 生育费用标志
from (
        --西药，卫材
        select 'XY'||c.系统序号 as 处方号,to_char(b.划价时间,'yyyy-mm-dd hh24:mi:ss') as 处方日期,to_char(nvl(a.执行时间,b.划价时间),'yyyy-mm-dd hh24:mi:ss') as 发生时间,c.退药数量 as 退药数量,to_char(c.用药频率i) as 用药频率i,to_char(c.给药方式i) as 给药方式i, '1'||to_char(c.系统序号) as 记账流水号, '1'||to_char(c.冲销序号i) as 冲销序号, a.单据序号i,a.住院序号i,c.药品序号i as 项目序号i,round(c.数量,2) as 数量,to_char(c.单位) as 单位,round(c.零售单价,4) as 单价,round(round(c.零售单价,4)*round(c.数量,2),2) as 金额,a.记账时间, a.开单科室i,a.开单医师r,a.执行科室i,'西药' as 类别,c.药品序号i as 医院项目编号,
        a.医嘱明细序号i as 医嘱记录序号,N'' as 草药单复方标识,to_char(fyr.资格证书编号) as 医保药师代码,to_char(fyr.名称) as 医保药师名称
        from inq_d住院费用明细 a
        inner join dug_d西药房住院处方单 b on a.处方序号i = b.系统序号
        inner join dug_d西药房住院处方明细 c on b.系统序号 = c.单据序号i
        left join doc_t员工档案 fyr on fyr.系统序号=b.发药人r
        where a.处方序号I>0 and a.处方类型='西药' and a.住院序号i='{0}'
        union all
        --中药
        select 'ZY'||b.系统序号 as 处方号,to_char(b.划价时间,'yyyy-mm-dd hh24:mi:ss') as 处方日期,to_char(nvl(a.执行时间,b.划价时间),'yyyy-mm-dd hh24:mi:ss') as 发生时间 ,c.退药数量 as 退药数量,to_char(b.用药频率i) as 用药频率i,to_char(b.给药方式i) as 给药方式i,'2'||to_char(c.系统序号) as 记账流水号, '2'||to_char(c.正单序号i) as 冲销序号,a.单据序号i,a.住院序号i,c.药品序号i as 项目序号i,round(b.付数*c.数量,2) as 数量,to_char(c.单位) as 单位,round(c.零售单价,4) as 单价,round(round(c.零售单价,4)*round(b.付数*c.数量,2),2) as 金额,a.记账时间, a.开单科室i,a.开单医师r,a.执行科室i,'中药' as 类别,c.药品序号i as 医院项目编号,
        a.医嘱明细序号i as 医嘱记录序号,case when d.草药味数>1 then N'1' else N'2' end  as 草药单复方标识,to_char(fyr.资格证书编号) as 医保药师代码,to_char(fyr.名称) as 医保药师名称
        from inq_d住院费用明细 a
        inner join dug_vd中药房住院处方单 b on a.处方序号i = b.系统序号
        inner join dug_vd中药房住院处方明细 c on b.系统序号 = c.单据序号i 
        inner join  (select a.处方序号i,count(distinct c.药品序号i) as 草药味数
                        from inq_d住院费用明细 a
                        inner join dug_vd中药房住院处方明细 c on a.处方序号i = c.单据序号i
                        where a.处方序号I>0 and a.处方类型='中药' and a.住院序号i='{0}' And (c.数量-nvl(c.退药数量,0))>0
                        group by a.处方序号i) D on a.处方序号i=d.处方序号i
         left join doc_t员工档案 fyr on fyr.系统序号=b.发药人r        
        where a.处方序号I>0 and a.处方类型='中药' and a.住院序号i='{0}'
        union all
        --收费项目及打包项目
        select  'XM'||a.系统序号 as 处方号,to_char(a.记账时间,'yyyy-mm-dd hh24:mi:ss') as 处方日期,to_char(a.记账时间,'yyyy-mm-dd hh24:mi:ss') as 发生时间 ,a.已退数量 as 退药数量,to_char('')  as 用药频率i,to_char('') as 给药方式i,'3'||to_char(a.系统序号) as 记账流水号,'3'||to_char(a.冲销序号i) as 冲销序号, a.单据序号i,a.住院序号i,a.收费项目序号i as 项目序号i,round(a.数量,2) as 数量,to_char('次') as 单位,round(a.执行单价,4) as 单价,round(round(a.执行单价,4)*round(a.数量,2),2) as 金额,a.记账时间, a.开单科室i,a.开单医师r,a.执行科室i,'项目' as 类别,d.系统序号 as 医院项目编号,
        a.医嘱明细序号i as 医嘱记录序号,N'' as 草药单复方标识,'' as 医保药师代码,'' as 医保药师名称
        from inq_d住院费用明细 a
        inner join doc_vt收费项目价格表 d on a.收费项目序号I = d.系统序号
        where a.处方序号I=0 and a.住院序号i='{0}' 
) a 
inner join doc_vt药品收费项目 b on a.项目序号i = b.系统序号 and a.类别 = b.类别  and b.隶属机构i='{1}'
inner join inq_d住院费用列表 f on a.单据序号i = f.系统序号
inner join inq_d住院档案 g on f.住院序号i = g.系统序号  
left join Inf_DAHYB_项目对码 dmb on B.系统序号=dmb.本地项目编号 and dmb.本地项目类型=b.子类别  and dmb.隶属机构I='{1}' 
left join INF_DAHYB_住院明细上传记录 scjl on a.记账流水号 = scjl.记账流水号 and g.系统序号=scjl.住院序号i and scjl.隶属机构I='{1}'
left join doc_T科室档案 kdks on a.开单科室i =kdks.系统序号
left join doc_T科室档案 sdks on a.执行科室i =sdks.系统序号
left join Doc_T员工档案 kdys on a.开单医师r= kdys.系统序号
left join INF_DAHYB_医执人员档案 ybysbm on ybysbm.编号i= a.开单医师r
left join inf_DAHYB_字典对码 YBKDKS on (YBKDKS.字典代码='dept' or YBKDKS.字典名='科室代码') and YBKDKS.本院编码=a.开单科室i 
left join inf_DAHYB_字典对码 YBSDKS on (YBSDKS.字典代码='dept' or YBSDKS.字典名='科室代码') and YBSDKS.本院编码=a.执行科室i
where g.系统序号='{0}'";
            }
            #endregion
            sSQL = string.Format(sSQL, vs住院序号, baseData.basData.pInt隶属机构编号);
            return sSQL;
        }

        #endregion
        #region 二级代码目录
        //一级缓存
        private static DataTable _gDt二级代码目录;
        private static DataTable gDt二级代码目录
        {
            get
            {
                if (_gDt二级代码目录 == null)
                {
                    _gDt二级代码目录 = DB.ExecuteDataTable("Select T.代码值,T.代码值||'.'||T.代码名称 as 代码名称,T.代码类别 from INF_TAHYB_二级代码目录 T");
                }
                return _gDt二级代码目录;
            }
        }
        //二级缓存
        private static Dictionary<string,string>dic二级代码=new Dictionary<string, string>();
        public static string Do获取二级代码数据(string vs代码类别)
        {
            try
            {
                if (!dic二级代码.ContainsKey(vs代码类别))
                {
                    DataTable dt = DB.ToDataTable(gDt二级代码目录.Select(string.Format("代码类别='{0}'", vs代码类别)));
                    if (dt != null)
                    {
                        StringBuilder sb数据 = new StringBuilder();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            sb数据.Append(string.Format("{0}|{1};", dt.Rows[i]["代码值"], dt.Rows[i]["代码名称"]));
                        }
                        string s代码数据 = sb数据.ToString().TrimEnd(';');
                        if (dic二级代码.ContainsKey(vs代码类别)) {dic二级代码[vs代码类别] = s代码数据; }else{dic二级代码.Add(vs代码类别,s代码数据);}
                        return s代码数据;
                    }
                    else
                    {
                        return "|";
                    }
                }
                else
                {
                    return dic二级代码[vs代码类别];
                }
            }
            catch (Exception err)
            {
                throw new Exception("[Do获取二级代码数据]异常:" + err.Message);
            }
        }
        public static DataTable Do获取二级代码数据DT(string vs代码类别)
        {
            try
            {
                DataTable dt = DB.ToDataTable(gDt二级代码目录.Select(string.Format("代码类别='{0}'", vs代码类别)));
                return dt;
            }
            catch (Exception err)
            {
                throw new Exception("[Do获取二级代码数据]异常:" + err.Message);
            }
        }
        #endregion
    }
}
        #endregion