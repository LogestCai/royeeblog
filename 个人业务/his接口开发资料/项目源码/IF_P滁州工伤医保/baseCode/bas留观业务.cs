using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IF_P工伤医保.baseCode
{
    public static class bas留观业务
    {

        //2017年5月11日
        //1.当前窗体  (没有意义  接口加的  我传null  你忽略这个参数)
        //2.检查/检验
        //3.辅检申请序号(检查为 INS_D检查申请系统.系统序号 检验为  EXP_D检验申请列表.系统序号)
        //4.婴儿序号(住院婴儿序号 没有婴儿就是0)
        public static string KDo留观医生工作站_临床查询辅检报告(object pCtrl, string vs业务类别, long vl辅检申请序号, long vl婴儿序号)
        {
            try
            {
                #region 正常返回以下XML数据
                // <PACSView>
                //    <row> 
                //         <报告序号i/>
                //         <检查类别/>
                //         <检查部位/>
                //         <阳性报告B/>
                //         <危急报告B/>
                //         <检查所见/>
                //         <检查诊断/>
                //    <Row/>
                //<PACSView/>
                #endregion
                return "";
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
                return ex.Message;
            }
        }
        //pCtrl 原定义传当前窗口, 目前无意义.
        //vlng检查申请序号 和 文字报告的 序号是一样的 
        //返回true  调用原始的Pacs/LIS报告 返回false 调用接口方法，HIS直接返回
        public static bool KDo留观医生工作站_临床调阅原始报告(object pCtrl, long vl辅检申请序号)
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
                return false;
            }
        }
        //其他序号表示：健康序号I
        public static void KDo留观病历夹_打开后(object pCtrl, long vl留观序号, long vl其它序号)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

    }
}
