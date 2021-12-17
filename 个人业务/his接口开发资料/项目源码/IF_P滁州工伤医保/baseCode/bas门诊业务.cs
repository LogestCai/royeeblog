using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using IF_P工伤医保.baseComm;
using IF_P工伤医保.baseData;
using IF_P工伤医保.baseForm;
using AHC_InterFace;
using IF_P工伤医保.MyCode;


namespace IF_P工伤医保.baseCode
{    
    internal static class bas门诊业务
    {
        #region 定义变量
        
        #endregion
        #region KDo门诊收费窗口_准备打开:添加按钮
        public static void KDo门诊收费窗口_准备打开(object pCtrl, object pCmd)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        #endregion
        #region KDo门诊收费窗口_接口按钮被点击:刷卡
        public static void KDo门诊收费窗口_接口按钮被点击(object pCtrl, string vsTag)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        #endregion

        public static void KDo门诊收费窗口_选择挂号单(object pForm, long vl挂号单号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static bool KDo门诊收费窗口_准备加入一个项目(object pCtrl, long vl项目序号)
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
        public static bool KDo门诊收费窗口_调入一笔处方单(object pCtrl, long vl划价单序号)
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
        #region KDo门诊收费支付窗口_准备打开:医保登记\上传费用\预结算
        public static bool KDo门诊收费支付窗口_准备打开(object pForm, object pCmd, long vl缴费序号)
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
        #endregion
        public static void KDo门诊收费支付窗口_接口按钮被点击(object pForm, string vsTag, long vl缴费序号)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo门诊收费支付窗口_收到金额按下(object pForm, int KeyCode, int Shift)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        #region KDo门诊收费支付窗口取消:取消结算
        public static void KDo门诊收费支付窗口取消(object pForm)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        #endregion

        #region KDo门诊收费确认_提交前:医保结算
        public static bool KDo门诊收费确认_提交前(object pCtrl)
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
        #endregion

        public static string KDo门诊收费确认_提交中(object pCtrl, long vl缴费序号)
        {
            try
            {

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #region KDo门诊收费确认_提交后:更新正式序号
        public static void KDo门诊收费确认_提交后(object pCtrl, long vl收费序号)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        #endregion
        //不做处理 在支付窗口取消时处理
        public static void KDo门诊收费确认_失败(bool vbln开始保存, bool vbln结算成功)
        {
            try
            {
                       
                
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        #region KDo门诊收费窗口取消:初始化变量
        public static void KDo门诊收费窗口取消(object pCtrl)
        {
            try
            {
              
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        #endregion
        #region KDo门诊收费列表窗口_准备打开:添加按钮
        public static void KDo门诊收费列表窗口_准备打开(object pCtrl, object pCmd)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        #endregion
        #region KDo门诊收费列表窗口_接口按钮被点击:打印结算单
        public static void KDo门诊收费列表窗口_接口按钮被点击(object pCtrl, string vsTag, long vl单据序号)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        #endregion
        #region KDo门诊收费列表窗口_整单退费_提交前:医保退费
        public static bool KDo门诊收费列表窗口_整单退费_提交前(object pCtrl, long vl单据序号)
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
        #endregion

        public static string KDo门诊收费列表窗口_整单退费_提交中(object pCtrl, long vl单据序号, long vl新单据序号)
        {
            try
            {
                
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #region KDo门诊收费列表窗口_整单退费_提交后:更新退单序号
        public static void KDo门诊收费列表窗口_整单退费_提交后(object pCtrl, long vl单据序号)
        {
            try
            {
                //update ....
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        #endregion

        public static void KDo门诊收费列表窗口_整单退费_提交失败(object pCtrl, long vl单据序号)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo门诊支付窗口_分单退费_接口按钮被点击(object pCtrl, string vsTag, long vl原单序号, long vl新临时序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo门诊支付窗口_分单退费_准备打开(object pCtrl, object pCmd, long vl原单序号, long vl新临时序号)
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
        //医保结算的病人不允许分单退费
        public static bool KDo门诊收费列表窗口_分单退费_提交前(object pCtrl, long vLng待退明细序号)
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
        public static string KDo门诊收费列表窗口_分单退费_提交中(object pCtrl, long vl原单据号, long vl新单据号)
        {
            try
            {
                return "";
            }
            catch (Exception ex)
            {
                return "[安徽医保_分单退费_提交中]" + ex.Message;
            }
        }
        public static void KDo门诊收费列表窗口_分单退费_提交后(object pCtrl, long vl原单据号, long vl新单据号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo门诊收费列表窗口_分单退费_提交失败(object pCtrl, long vl原单序号, long vl新临时序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo门诊支付窗口_分单退费_取消(object pCtrl, object pCmd, long vl原单序号, long vl新临时序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
            finally 
            {
                
            }
        }

        public static bool KDo门诊药房_分零退药许可(object pCtrl, long vLng处方序号)
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

        #region KDo门诊保险结算单打印:打印医保结算单
        public static bool KDo门诊保险结算单打印(object pForm, long vl门诊序号)
        {
            try
            {
                //查询是否医保结算记录

                //调用打印结算单处理
                return true;//接口打印
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
                return true;//接口打印
            }
        }
        #endregion
        public static bool KDo门诊收费列表窗口_修改信息_提交前(object pForm, long vl单据序号)
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

        public static void KDo门诊发药_刷卡(object pForm, long vlng会员编号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo门诊收费窗口会员刷卡成功后(object pCtrl, long vl病员编号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo门诊就诊确认_提交前(object pCtrl)
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

        public static string KDo门诊就诊确认_提交中(object pCtrl, long vl就诊序号)
        {
            try
            {
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static void KDo门诊就诊确认_提交后(object pCtrl, long vl就诊序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo门诊就诊窗口_接口按钮被点击(object pCtrl, string vsTag)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo门诊就诊窗口_准备打开(object pForm, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo下帐收费确认窗口取消(object pCtrl, long vl挂号序号, long vl就诊序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo下帐收费确认窗口_准备打开(object pCtrl, object pCmd, long vl挂号序号, long vl就诊序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }


        public static bool KDo下帐收费确认_提交前(object pForm,long vl挂号序号)
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

        public static string KDo下帐收费确认_提交中(object pForm,long vl挂号序号, long vl就诊序号)
        {
            try
            {
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static void KDo下帐收费确认_提交后(object pForm,long vl收费序号, long vl就诊序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo下帐收费确认_失败(object pForm,long vl挂号序号, long vl就诊序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo门诊医生工作站_准备打开(object pCtrl, object pCmd)
        {
            try
            {
                //basComm.Do列举控件名称(pCtrl);
                basComm.Do新增按钮("医保审批", "新医保病种审批查询", pCtrl, pCmd);
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo门诊医生工作站_接口按钮被点击(object pCtrl, string vsTag, long vl就诊序号)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static bool KDo门诊医生工作站_准备加入一个项目(object pForm, long vl收费项目序号, decimal vDub项目价格)
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

        public static bool KDo电子处方划价窗口_准备加入一个药品(object pForm, long vl就诊序号, long vl药品编号)
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

        public static void KDo门诊医生工作站_查看健康档案(object pCtrl, long vl病员编号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static bool KDo电子处方划价确认_提交前(object pForm, long vl就诊序号)
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

        public static string KDo电子处方划价确认_提交中(object pForm, long vl就诊序号, long vl处方序号)
        {
            try
            {
                //basComm.MsgBox("KDo电子处方划价确认_提交中!");
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static void KDo电子处方划价确认_提交后(object pForm, long vl就诊序号, long vl处方序号)
        {
            try
            {
                basComm.WriteLog("进入【 KDo电子处方划价确认_提交后】");
             
                
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        //提价后置一个标志，表示业务成功，在窗口取消方法里就不做退冲处理了 
        public static void KDo电子处方划价窗口取消(object pForm, long vl就诊序号)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo门诊收费窗口取消刷卡(object pCtrl)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        //2017年5月11日
        //1.当前窗体  (没有意义  接口加的  我传null  你忽略这个参数)
        //2.检查/检验
        //3.辅检申请序号(检查为 INS_D检查申请系统.系统序号 检验为  EXP_D检验申请列表.系统序号)
        //4.婴儿序号(住院婴儿序号 没有婴儿就是0)
        public static string KDo门诊医生工作站_临床查询辅检报告(object pCtrl, string vs业务类别,long vl辅检申请序号, long vl婴儿序号)
        {
            try
            {
              
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
        //vs业务来源 : 门诊/住院
        // //返回true  调用原始的Pacs/LIS报告 返回false 调用接口方法，HIS直接返回
        public static bool KDo门诊医生工作站_临床调阅原始报告(object pCtrl,long vl辅检申请序号)
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

        //2017年8月15日
        //vs操作类型有:门诊收费、门诊挂号、住院登记、住院交款、住院结算 
        //vl其他序号 在不同的操作类型下面，值不一样门诊可能是挂号序号，住院可能是住院序号，结算序号之类的
        //你如果返回的是false，则HIs不继续下一步
        public static bool KDo健康刷卡后(object pForm, object pCmd, string vs操作类型, string vl健康序号, string vl其他序号)
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

        //2017年9月12日
        public static bool KDo门诊发药_提交前(long vl处方编号, string vs处方类型)
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
        public static string KDo门诊发药_提交中(long vl处方编号, string vs处方类型)
        {
            try
            {
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static void KDo门诊发药_提交后(long vl处方编号, string vs处方类型)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo门诊发药_失败(long vl处方编号, string vs处方类型)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        //2017年4月5日13:35:41新增
        public static void KDo门诊医生工作站呼叫患者(object pCtrl, long vl待诊序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo门诊医生站_发送医嘱提交后(object pCtrl, long vl就诊序号)
        {
            try
            {
                basComm.WriteLog("进入【 KDo门诊医生站_发送医嘱提交后】");
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        //辅检报告
        public static void KDo报告完成后(object pCtrl, long vl健康序号, long vl单据序号, string vs报告类型)
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
