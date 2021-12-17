using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IF_P安徽医保.MyCode
{

    public class C医保目录信息查询出参数据项
    {
        public string hilist_code;//医保目录编码-字符型-30--Y
        public string hilist_name;//医保目录名称-字符型-200--Y
        public string insu_admdvs;//参保机构医保区划-字符型-6-Y　-Y
        public string begndate;//开始日期-日期型---Y
        public string enddate;//结束日期-日期型---N
        public string med_chrgitm_type;//医疗收费项目类别-字符型-6-Y　-Y
        public string chrgitm_lv;//收费项目等级-字符型-3-Y　-Y
        public string lmt_used_flag;//限制使用标志-字符型-3-Y　-Y
        public string list_type;//目录类别-字符型-3-Y　-Y
        public string med_use_flag;//医疗使用标志-字符型-3-Y　-Y
        public string matn_used_flag;//生育使用标志-字符型-3-Y　-Y
        public string hilist_use_type;//医保目录使用类别-字符型-3-Y　-Y
        public string lmt_cpnd_type;//限复方使用类型-字符型-3-Y　-Y
        public string wubi;//五笔助记码-字符型-30--N
        public string pinyin;//拼音助记码-字符型-30--N
        public string memo;//备注-字符型-500--N
        public string vali_flag;//有效标志-字符型-3-Y　-Y
        public string rid;//唯一记录号-字符型-40--Y
        public string updt_time;//更新时间-日期型---Y
        public string crter_id;//创建人-字符型-20--N
        public string crter_name;//创建人姓名-字符型-50--N
        public string crte_time;//创建时间-日期型---Y
        public string crte_optins_no;//创建机构-字符型-20--N
        public string opter_id;//经办人-字符型-20--N
        public string opter_name;//经办人姓名-字符型-50--N
        public string opt_time;//经办时间-日期型---N
        public string optins_no;//经办机构-字符型-20--N
        public string poolarea_no;//统筹区-字符型-6-Y　-N

    }
    public class C医保目录信息查询出参数数据项集合
    {
        public C医保目录信息查询出参数据项[] Items;
    }
    public class C返回集合<T>
    {
        T[] Items;
    }
}
