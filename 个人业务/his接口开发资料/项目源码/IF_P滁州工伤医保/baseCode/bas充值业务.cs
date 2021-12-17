using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IF_P工伤医保.baseCode
{
    internal static class bas充值业务
    {

        public static void KDo账户充值列表窗口_准备打开(object pForm, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo账户充值列表窗口_接口按钮被点击(object pForm, string vsTag, long vl充值序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        //2017年9月8日16:44:55新增
        public static void KDo账户充值窗口_准备打开(object pForm, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo账户充值窗口_接口按钮被点击(object pForm, string vsTag, long vl健康序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }


        public static bool KDo账户充值窗口_提交前(object pForm, long vl健康序号)
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
        public static string KDo账户充值窗口_提交中(object pForm, long vl健康序号, long vl单据序号)
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
        public static void KDo账户充值窗口_提交后(object pForm, long vl健康序号, long vl单据序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo账户充值窗口_提交失败(object pForm, long vl健康序号, long vl单据序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }

        }


        public static void KDo账户退费窗口_准备打开(object pForm, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo账户退费窗口_接口按钮被点击(object pForm, string vsTag, long vl健康序号, long vl单据序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }


        public static bool KDo账户退费窗口_提交前(object pForm, long vl健康序号, long vl单据序号)
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
        public static string KDo账户退费窗口_提交中(object pForm, long vl健康序号, long vl原单据序号, long vl新单据序号)
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
        public static void KDo账户退费窗口_提交后(object pForm, long vl健康序号, long vl原单据序号, long vl新单据序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo账户退费窗口_提交失败(object pForm, long vl健康序号, long vl原单据序号, long vl新单据序号)
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
