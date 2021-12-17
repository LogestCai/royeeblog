using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using AHC_InterFace;
using IF_P工伤医保.baseComm;
using IF_P工伤医保.baseData;
using IF_P工伤医保.baseForm;
using IF_P工伤医保.MyCode;

namespace IF_P工伤医保.baseCode
{
    internal static class bas挂号业务
    {
        //2016年7月22日
        #region 定义变量
       
        #endregion
       
        public static void KDo门诊挂号列表窗口_准备打开(object pCtrl, object pCmd)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
   
        //挂号序号 0表示没有选择挂号数据
       
        public static void KDo门诊挂号列表窗口_接口按钮被点击(object pCtrl, string vsTag, long vl挂号序号)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo门诊挂号支付窗口_准备打开(object pCtrl, object pCmd)
        {
            try
            {
              
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo门诊挂号支付窗口_接口按钮被点击(object pCtrl, string vsTag)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo门诊挂号窗口_挂号金额改变(object pForm)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
               
            }
        }

        public static void KDo门诊挂号窗口_准备打开(object pCtrl, object pCmd)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo门诊挂号窗口_接口按钮被点击(object pCtrl, string vsTag)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo门诊挂号确认_提交前(object pCtrl)
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
        
        public static string KDo门诊挂号确认_提交中(object pCtrl, long vl单据序号)
        {
            try
            {
                return "";
            }
            catch (Exception ex)
            { 
                return "错误："+ ex.Message;
            }
        }
       
        public static void KDo门诊挂号确认_提交后(object pCtrl, long vl单据序号)
        {
            try
            {
                
                
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
            Do重置变量();
        }

        public static void KDo门诊挂号确认_失败(object pForm, long v单据编号)
        {
            basComm.WriteLog("进入【KDo门诊挂号确认_失败】");
            try
            {
               

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
            Do重置变量();
        }

        public static void KDo门诊挂号窗口取消(object pCtrl)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
            
        }

        public static bool KDo门诊挂号列表窗口_作废_提交前(object pCtrl, long vl单据序号)
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

        public static string KDo门诊挂号列表窗口_作废_提交中(object pCtrl, long vl单据序号, long vl新挂号单序号)
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

        public static void KDo门诊挂号列表窗口_作废_提交后(object pCtrl, long vl单据序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo门诊挂号列表窗口_作废_提交失败(object pCtrl, long vl单据序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo快速建档保存窗口_准备打开(object pForm, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        //读卡并赋值界面，准备保存一份新的档案
        public static void KDo快速建档保存窗口_接口按钮被点击(object pForm, string vsTag)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo快速建档保存确认_提交前(object pCtrl)
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

        public static string KDo快速建档保存确认_提交中(object pCtrl, long vl病员编号)
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

        public static void KDo快速建档保存确认_提交后(object pCtrl, long vl病员编号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo快速建档列表窗口_准备打开(object pForm, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo快速建档列表窗口_接口按钮被点击(object pForm, string vsTag)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo挂号收费窗口会员刷卡成功后(object pCtrl, long vl病员编号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
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

        public static void Do重置变量()
        {
            
        }
    }
}
