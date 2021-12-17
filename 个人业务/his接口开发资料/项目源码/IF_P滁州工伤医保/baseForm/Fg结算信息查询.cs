using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ACtrllist;
using AModelList;
using IF_P工伤医保.baseComm;
using IF_P工伤医保.MyCode;
using AHC_InterFace;
using IF_P工伤医保.baseData;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections;
using Newtonsoft.Json.Linq;
namespace IF_P工伤医保.baseForm
{
    public partial class Fg结算信息查询 : AForm
    {
        public Fg结算信息查询()
        {
            InitializeComponent();
        }

        private void Fg医疗费用汇总_Load(object sender, EventArgs e)
        {
            dt开始日期.asText = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            dt终止日期.asText = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            #region 设置就诊信息表明细
            grid就诊信息.SetFormatXML(@"<info>
              <fields>    
                <col 名称=""类型"" 标题=""类型"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""姓名"" 标题=""姓名"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""性别名称"" 标题=""性别名称"" 类型=""S"" 宽度=""40"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""证件号码"" 标题=""证件号码"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""结算时间"" 标题=""结算时间"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""就诊ID"" 标题=""就诊ID"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""结算ID"" 标题=""结算ID"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""人员编号"" 标题=""人员编号"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""就诊凭证编号"" 标题=""就诊凭证编号"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""医疗类别名称"" 标题=""医疗类别名称"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""人员类别"" 标题=""人员类别"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""险种类型名称"" 标题=""险种类型名称"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""医疗费总额"" 标题=""医疗费总额"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""全自费金额"" 标题=""全自费金额"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""超限价自费费用"" 标题=""超限价自费费用"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""先行自付金额"" 标题=""先行自付金额"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""符合政策范围金额"" 标题=""符合政策范围金额"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""实际支付起付线"" 标题=""实际支付起付线"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""基本医疗保险统筹基金支出"" 标题=""基本医疗保险统筹基金支出"" 类型=""S"" 宽度=""200"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""基本医疗保险统筹基金支付比例"" 标题=""基本医疗保险统筹基金支付比例"" 类型=""S"" 宽度=""200"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""其他支出"" 标题=""其他支出"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""基金支付总额"" 标题=""基金支付总额"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""个人负担总金额"" 标题=""个人负担总金额"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""个人账户支出"" 标题=""个人账户支出"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""个人现金支出"" 标题=""个人现金支出"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""医院负担金额"" 标题=""医院负担金额"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""行政区划代码"" 标题=""行政区划代码"" 类型=""S"" 宽度=""50"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
            </fields> 
	
            </info>");
            #endregion

            #region 设置费用明细表表头

            grid费用明细.SetFormatXML(@"<info>
              <fields>    
                <col 名称=""mdtrt_id"" 标题=""就诊ID"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""setl_id"" 标题=""结算ID"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""feedetl_sn"" 标题=""费用明细流水号"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""rx_drord_no"" 标题=""处方号"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""med_type"" 标题=""医疗类别"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""fee_ocur_time"" 标题=""费用发生时间"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""cnt"" 标题=""数量"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""pric"" 标题=""单价"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""sin_dos_dscr"" 标题=""单次剂量描述"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""used_frqu_dscr"" 标题=""使用频次描述"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""prd_days"" 标题=""周期天数"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""medc_way_dscr"" 标题=""用药途径描述"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""det_item_fee_sumamt"" 标题=""明细项目费用总额"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""pric_uplmt_amt"" 标题=""定价上限金额"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""selfpay_prop"" 标题=""自付比例"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""fulamt_ownpay_amt"" 标题=""全自费金额"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""overlmt_amt"" 标题=""超限价金额"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""preselfpay_amt"" 标题=""先行自付金额"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""inscp_scp_amt"" 标题=""符合政策范围金额"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""chrgitm_lv"" 标题=""收费项目等级"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""hilist_code"" 标题=""医保目录编码"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""hilist_name"" 标题=""医保目录名称"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""list_type"" 标题=""目录类别"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""med_list_codg"" 标题=""医疗目录编码"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""medins_list_codg"" 标题=""医药机构目录编码"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""medins_list_name"" 标题=""医药机构目录名称"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""med_chrgitm_type"" 标题=""医疗收费项目类别"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""prodname"" 标题=""商品名"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""spec"" 标题=""规格"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""dosform_name"" 标题=""剂型名称"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""bilg_dept_codg"" 标题=""开单科室编码"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""bilg_dept_name"" 标题=""开单科室名称"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""bilg_dr_codg"" 标题=""开单医生编码"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""bilg_dr_name"" 标题=""开单医师姓名"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""acord_dept_codg"" 标题=""受单科室编码"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""acord_dept_name"" 标题=""受单科室名称"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""orders_dr_code"" 标题=""受单医生编码"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""orders_dr_name"" 标题=""受单医生姓名"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""lmt_used_flag"" 标题=""限制使用标志"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""hosp_prep_flag"" 标题=""医院制剂标志"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""hosp_appr_flag"" 标题=""医院审批标志"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""tcmdrug_used_way"" 标题=""中药使用方式"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""prodplac_type"" 标题=""生产地类别"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""bas_medn_flag"" 标题=""基本药物标志"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""hi_nego_drug_flag"" 标题=""医保谈判药品标志"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""chld_medc_flag"" 标题=""儿童用药标志"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""etip_flag"" 标题=""外检标志"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""etip_hosp_code"" 标题=""外检医院编码"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""dscg_tkdrug_flag"" 标题=""出院带药标志"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""list_sp_item_flag"" 标题=""目录特项标志"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""matn_fee_flag"" 标题=""生育费用标志"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""drt_reim_flag"" 标题=""直报标志"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""memo"" 标题=""备注"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""opter_id"" 标题=""经办人ID"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""opter_name"" 标题=""经办人姓名"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
                <col 名称=""opt_time"" 标题=""经办时间"" 类型=""S"" 宽度=""100"" 必选=""1"" 选用=""1"" 表头对齐=""C"" 表格对齐=""C"" 合计=""0"" />
            </fields>
            </info>"); 
            #endregion
        }

        private void btn查询_Click(object sender, EventArgs e)
        {
            Do加载数据();
        }

        private void Do加载数据()
        {
            string sSQL = @"select *from (

select '住院'as  类型,a.姓名,decode(a.性别,'1','男','2','女',a.性别) as 性别名称,A.证件号码,A.结算时间,A.就诊ID,A.结算ID,A.人员编号,A.就诊凭证编号,A.yllb.名称 as 医疗类别名称,rylb.名称 as 人员类别, xzlx.名称 as 险种类型名称,

a.医疗费总额,A.全自费金额,A.超限价自费费用,A.先行自付金额,A.符合政策范围金额,A.实际支付起付线,A.基本医疗保险统筹基金支出,A.基本医疗保险统筹基金支付比例,A.其他支出,A.基金支付总额,A.个人负担总金额,A.个人账户支出,a.个人现金支出,A.医院负担金额

,c.行政区划代码 as 行政区划代码
from INF_DAHYB_住院结算 a 

--inner join INF_DAHYB_住院结算基金分项 b on a.系统序号=b.单据序号i 

inner join INF_DAHYB_住院登记列表 c on c.住院序号i=a.住院序号i

left join INF_TAHYB_中心字典 yllb on yllb.字典名='医疗类别' and yllb.编码=c.医疗类别

left join INF_TAHYB_中心字典 rylb on rylb.字典名='人员类别' and rylb.编码=a.人员类别

left join INF_TAHYB_中心字典 xzlx on xzlx.字典名='险种类型' and xzlx.编码=a.险种类型

where a.医保冲销时间 is null 

union all 

select '门诊'as  类型,a.姓名,decode(a.性别,'1','男','2','女',a.性别) as 性别名称,A.证件号码,A.结算时间,A.就诊ID,A.结算ID,A.人员编号,A.就诊凭证编号,A.yllb.名称 as 医疗类别名称,rylb.名称 as 人员类别, xzlx.名称 as 险种类型名称,

a.医疗费总额,A.全自费金额,A.超限价自费费用,A.先行自付金额,A.符合政策范围金额,A.实际支付起付线,A.基本医疗保险统筹基金支出,A.基本医疗保险统筹基金支付比例,A.其他支出,A.基金支付总额,A.个人负担总金额,A.个人账户支出,a.个人现金支出,A.医院负担金额

,c.统筹区编码 as 行政区划代码
--from INF_DAHYB_住院结算 a 

from INF_DAHYB_门诊费用结算 a 

--inner join inf_dahyb_门诊费用结算基金分项 b on a.系统序号=b.单据序号i 

inner join inf_dahyb_门诊登记  c on c.就诊ID=a.就诊ID

left join INF_TAHYB_中心字典 yllb on yllb.字典名='医疗类别' and yllb.编码=a.医疗类别

left join INF_TAHYB_中心字典 rylb on rylb.字典名='人员类别' and rylb.编码=a.人员类别

left join INF_TAHYB_中心字典 xzlx on xzlx.字典名='险种类型' and xzlx.编码=a.险种类型
where a.医保冲销时间 is null 

) jsxx ";
            string sWhere条件 = string.Format("where jsxx.结算时间 between  to_date('{0}','yyyy-mm-dd hh24:mi:ss') and to_date('{1}','yyyy-mm-dd hh24:mi:ss')",dt开始日期.asText,dt终止日期.asText);
            if (!string.IsNullOrEmpty(txbx姓名.asText)) { sWhere条件 += string.Format(" and 姓名 like '%{0}%' ", txbx姓名.asText); }
            if (!string.IsNullOrEmpty(txbx身份证.asText)) { sWhere条件 += string.Format(" and 证件号码 = '{0}' ", txbx身份证.asText); }
            sWhere条件 += " order by 类型 asc, 结算时间 desc ";

            grid就诊信息.LoadList(sSQL+sWhere条件);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn显示单据费用明细_Click(object sender, EventArgs e)
        {
            if (grid就诊信息.aiRow < 1 || grid就诊信息.aiRows - grid就诊信息.aiFixedRows < 1) { basComm.MsgAndWriteError("请选择就诊信息！"); return; }
            int i当前就诊行  = grid就诊信息.aiRow;
            string s输出参数 = "";
            string sErrorMsg = "";
            //string s行政区划代码 = "";
            int i类型 = 1;//默认类型为1  住院  2 门诊 
            //获取参保地编码
            string s结算入参信息 = DB.ExecSingle("select * from inf_dahyb_住院结算 where 结算ID= '"+grid就诊信息.GetText(i当前就诊行, "结算ID")+"'");
            //如果住院找不到  则查找门诊
            if (string.IsNullOrEmpty(s结算入参信息)) {
                i类型 = 2;
               // s结算入参信息 = DB.ExecSingle("select * from inf_dahyb_住院结算 where 结算ID= '" + grid就诊信息.GetText(i当前就诊行, "结算ID") + "'");
             }
            s结算入参信息 = "{" + s结算入参信息 + "}";
            //if (!JK.Do费用明细查询(grid就诊信息.GetText(i当前就诊行, "人员编号"), grid就诊信息.GetText(i当前就诊行, "就诊ID"), grid就诊信息.GetText(i当前就诊行, "结算ID"), grid就诊信息.GetText(i当前就诊行, "行政区划代码"), ref s输出参数, ref sErrorMsg))
            //{
            //    basComm.MsgAndWriteError("获取结算信息失败！"+sErrorMsg);
            //    return;
            //}
            try
            {
                #region 业务逻辑
                //string tab字典 = "{\"mdtrt_id\":\"就诊ID\",\"setl_id\":\"结算ID\",\"feedetl_sn\":\"费用明细流水号\",\"rx_drord_no\":\"处方号\",\"med_type\":\"医疗类别\",\"fee_ocur_time\":\"费用发生时间\",\"cnt\":\"数量\",\"pric\":\"单价\",\"sin_dos_dscr\":\"单次剂量描述\",\"used_frqu_dscr\":\"使用频次描述\",\"prd_days\":\"周期天数\",\"medc_way_dscr\":\"用药途径描述\",\"det_item_fee_sumamt\":\"明细项目费用总额\",\"pric_uplmt_amt\":\"定价上限金额\",\"selfpay_prop\":\"自付比例\",\"fulamt_ownpay_amt\":\"全自费金额\",\"overlmt_amt\":\"超限价金额\",\"preselfpay_amt\":\"先行自付金额\",\"inscp_scp_amt\":\"符合政策范围金额\",\"chrgitm_lv\":\"收费项目等级\",\"hilist_code\":\"医保目录编码\",\"hilist_name\":\"医保目录名称\",\"list_type\":\"目录类别\",\"med_list_codg\":\"医疗目录编码\",\"medins_list_codg\":\"医药机构目录编码\",\"medins_list_name\":\"医药机构目录名称\",\"med_chrgitm_type\":\"医疗收费项目类别\",\"prodname\":\"商品名\",\"spec\":\"规格\",\"dosform_name\":\"剂型名称\",\"bilg_dept_codg\":\"开单科室编码\",\"bilg_dept_name\":\"开单科室名称\",\"bilg_dr_codg\":\"开单医生编码\",\"bilg_dr_name\":\"开单医师姓名\",\"acord_dept_codg\":\"受单科室编码\",\"acord_dept_name\":\"受单科室名称\",\"orders_dr_code\":\"受单医生编码\",\"orders_dr_name\":\"受单医生姓名\",\"lmt_used_flag\":\"限制使用标志\",\"hosp_prep_flag\":\"医院制剂标志\",\"hosp_appr_flag\":\"医院审批标志\",\"tcmdrug_used_way\":\"中药使用方式\",\"prodplac_type\":\"生产地类别\",\"bas_medn_flag\":\"基本药物标志\",\"hi_nego_drug_flag\":\"医保谈判药品标志\",\"chld_medc_flag\":\"儿童用药标志\",\"etip_flag\":\"外检标志\",\"etip_hosp_code\":\"外检医院编码\",\"dscg_tkdrug_flag\":\"出院带药标志\",\"list_sp_item_flag\":\"目录特项标志\",\"matn_fee_flag\":\"生育费用标志\",\"drt_reim_flag\":\"直报标志\",\"memo\":\"备注\",\"opter_id\":\"经办人ID\",\"opter_name\":\"经办人姓名\",\"opt_time\":\"经办时间\"}";
                //JObject tab字典Obj = JObject.Parse(tab字典);
                //IEnumerable<JProperty> properties = tab字典Obj.Properties();
                //JObject jo结算费用明细 = JObject.Parse("{\"data\":" + s输出参数 + "}");
                //int size = jo结算费用明细["data"].ToArray().Count();
                //if (size > 0)
                //{
                //    grid费用明细.SetAiRows(grid费用明细.aiFixedRows + size);
                //    grid费用明细.BeginUpdate();
                //    grid费用明细.fbAllowSum = false;
                //    for (int i = 0; i < size; i++)
                //    {
                //        grid费用明细.SetText(i + 1, "mdtrt_id", getJObjectValue(jo结算费用明细, i, "mdtrt_id"));
                //        grid费用明细.SetText(i + 1, "setl_id", getJObjectValue(jo结算费用明细, i, "setl_id"));
                //        grid费用明细.SetText(i + 1, "feedetl_sn", getJObjectValue(jo结算费用明细, i, "feedetl_sn"));
                //        grid费用明细.SetText(i + 1, "rx_drord_no", getJObjectValue(jo结算费用明细, i, "rx_drord_no"));
                //        grid费用明细.SetText(i + 1, "med_type", getJObjectValue(jo结算费用明细, i, "med_type"));
                //        grid费用明细.SetText(i + 1, "fee_ocur_time", Tools.Format时间格式(getJObjectValue(jo结算费用明细, i, "fee_ocur_time")));
                //        grid费用明细.SetText(i + 1, "cnt", getJObjectValue(jo结算费用明细, i, "cnt"));
                //        grid费用明细.SetText(i + 1, "pric", getJObjectValue(jo结算费用明细, i, "pric"));
                //        grid费用明细.SetText(i + 1, "sin_dos_dscr", getJObjectValue(jo结算费用明细, i, "sin_dos_dscr"));
                //        grid费用明细.SetText(i + 1, "used_frqu_dscr", getJObjectValue(jo结算费用明细, i, "used_frqu_dscr"));
                //        grid费用明细.SetText(i + 1, "prd_days", getJObjectValue(jo结算费用明细, i, "prd_days"));
                //        grid费用明细.SetText(i + 1, "medc_way_dscr", getJObjectValue(jo结算费用明细, i, "medc_way_dscr"));
                //        grid费用明细.SetText(i + 1, "det_item_fee_sumamt", getJObjectValue(jo结算费用明细, i, "det_item_fee_sumamt"));
                //        grid费用明细.SetText(i + 1, "pric_uplmt_amt", getJObjectValue(jo结算费用明细, i, "pric_uplmt_amt"));
                //        grid费用明细.SetText(i + 1, "selfpay_prop", getJObjectValue(jo结算费用明细, i, "selfpay_prop"));
                //        grid费用明细.SetText(i + 1, "fulamt_ownpay_amt", getJObjectValue(jo结算费用明细, i, "fulamt_ownpay_amt"));
                //        grid费用明细.SetText(i + 1, "overlmt_amt", getJObjectValue(jo结算费用明细, i, "overlmt_amt"));
                //        grid费用明细.SetText(i + 1, "preselfpay_amt", getJObjectValue(jo结算费用明细, i, "preselfpay_amt"));
                //        grid费用明细.SetText(i + 1, "inscp_scp_amt", getJObjectValue(jo结算费用明细, i, "inscp_scp_amt"));
                //        grid费用明细.SetText(i + 1, "chrgitm_lv", getJObjectValue(jo结算费用明细, i, "chrgitm_lv"));
                //        grid费用明细.SetText(i + 1, "hilist_code", getJObjectValue(jo结算费用明细, i, "hilist_code"));
                //        grid费用明细.SetText(i + 1, "hilist_name", getJObjectValue(jo结算费用明细, i, "hilist_name"));
                //        grid费用明细.SetText(i + 1, "list_type", getJObjectValue(jo结算费用明细, i, "list_type"));
                //        grid费用明细.SetText(i + 1, "med_list_codg", getJObjectValue(jo结算费用明细, i, "med_list_codg"));
                //        grid费用明细.SetText(i + 1, "medins_list_codg", getJObjectValue(jo结算费用明细, i, "medins_list_codg"));
                //        grid费用明细.SetText(i + 1, "medins_list_name", getJObjectValue(jo结算费用明细, i, "medins_list_name"));
                //        grid费用明细.SetText(i + 1, "med_chrgitm_type", getJObjectValue(jo结算费用明细, i, "med_chrgitm_type"));
                //        grid费用明细.SetText(i + 1, "prodname", getJObjectValue(jo结算费用明细, i, "prodname"));
                //        grid费用明细.SetText(i + 1, "spec", getJObjectValue(jo结算费用明细, i, "spec"));
                //        grid费用明细.SetText(i + 1, "dosform_name", getJObjectValue(jo结算费用明细, i, "dosform_name"));
                //        grid费用明细.SetText(i + 1, "bilg_dept_codg", getJObjectValue(jo结算费用明细, i, "bilg_dept_codg"));
                //        grid费用明细.SetText(i + 1, "bilg_dept_name", getJObjectValue(jo结算费用明细, i, "bilg_dept_name"));
                //        grid费用明细.SetText(i + 1, "bilg_dr_codg", getJObjectValue(jo结算费用明细, i, "bilg_dr_codg"));
                //        grid费用明细.SetText(i + 1, "bilg_dr_name", getJObjectValue(jo结算费用明细, i, "bilg_dr_name"));
                //        grid费用明细.SetText(i + 1, "acord_dept_codg", getJObjectValue(jo结算费用明细, i, "acord_dept_codg"));
                //        grid费用明细.SetText(i + 1, "acord_dept_name", getJObjectValue(jo结算费用明细, i, "acord_dept_name"));
                //        grid费用明细.SetText(i + 1, "orders_dr_code", getJObjectValue(jo结算费用明细, i, "orders_dr_code"));
                //        grid费用明细.SetText(i + 1, "orders_dr_name", getJObjectValue(jo结算费用明细, i, "orders_dr_name"));
                //        grid费用明细.SetText(i + 1, "lmt_used_flag", getJObjectValue(jo结算费用明细, i, "lmt_used_flag"));
                //        grid费用明细.SetText(i + 1, "hosp_prep_flag", getJObjectValue(jo结算费用明细, i, "hosp_prep_flag"));
                //        grid费用明细.SetText(i + 1, "hosp_appr_flag", getJObjectValue(jo结算费用明细, i, "hosp_appr_flag"));
                //        grid费用明细.SetText(i + 1, "tcmdrug_used_way", getJObjectValue(jo结算费用明细, i, "tcmdrug_used_way"));
                //        grid费用明细.SetText(i + 1, "prodplac_type", getJObjectValue(jo结算费用明细, i, "prodplac_type"));
                //        grid费用明细.SetText(i + 1, "bas_medn_flag", getJObjectValue(jo结算费用明细, i, "bas_medn_flag"));
                //        grid费用明细.SetText(i + 1, "hi_nego_drug_flag", getJObjectValue(jo结算费用明细, i, "hi_nego_drug_flag"));
                //        grid费用明细.SetText(i + 1, "chld_medc_flag", getJObjectValue(jo结算费用明细, i, "chld_medc_flag"));
                //        grid费用明细.SetText(i + 1, "etip_flag", getJObjectValue(jo结算费用明细, i, "etip_flag"));
                //        grid费用明细.SetText(i + 1, "etip_hosp_code", getJObjectValue(jo结算费用明细, i, "etip_hosp_code"));
                //        grid费用明细.SetText(i + 1, "dscg_tkdrug_flag", getJObjectValue(jo结算费用明细, i, "dscg_tkdrug_flag"));
                //        grid费用明细.SetText(i + 1, "list_sp_item_flag", getJObjectValue(jo结算费用明细, i, "list_sp_item_flag"));
                //        grid费用明细.SetText(i + 1, "matn_fee_flag", getJObjectValue(jo结算费用明细, i, "matn_fee_flag"));
                //        grid费用明细.SetText(i + 1, "drt_reim_flag", getJObjectValue(jo结算费用明细, i, "drt_reim_flag"));
                //        grid费用明细.SetText(i + 1, "memo", getJObjectValue(jo结算费用明细, i, "memo"));
                //        grid费用明细.SetText(i + 1, "opter_id", getJObjectValue(jo结算费用明细, i, "opter_id"));
                //        grid费用明细.SetText(i + 1, "opter_name", getJObjectValue(jo结算费用明细, i, "opter_name"));
                //        grid费用明细.SetText(i + 1, "opt_time", Tools.Format时间格式(getJObjectValue(jo结算费用明细, i, "opt_time")));

                //    }
                //    grid费用明细.fbAllowSum = true;
                //    grid费用明细.DoUpdateForzen();
                //    grid费用明细.EndUpdate();
                //    basComm.MsgBox("下载中心明细成功！");
                //}
                
                #endregion
                //string trs = s输出参数;
               
               // basComm.MsgAndWriteError(jo结算费用明细.ToString());
            }
            catch (Exception ex)
            {
                basComm.MsgAndWriteError("解析数据失败了！"+ex.Message);
            }
            

            

        }

        public static string getJObjectValue(JObject sArr,int i,string skey) {
            try
            {
                JObject tmp = JObject.Parse(sArr["data"][i].ToString());
                if (tmp.Property(skey) != null)
                {
                    return tmp[skey].ToString();
                }
                else {
                    return "";
                }
               
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private void btn导出Excel_Click(object sender, EventArgs e)
        {
            grid费用明细.DoSaveExcel();
        }
    }
}
