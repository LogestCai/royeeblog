using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IF_P工伤医保.baseCode
{
    public static class bas医技业务
    {
        public static void KDo检查确认工作站_准备打开(object pCtrl, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        //vs业务类别:门诊/住院    业务序号:申请单的系统序号
        //Select * From ins_vd检查申请主表 A 
        //Inner Join Ins_D检查申请系统 B On A.申请序号i=B.系统序号
        //Inner Join Ins_D检查申请列表 C On B.单据序号i=C.系统序号
        //Inner Join ins_Vl检查申请明细 D On D.单据序号i=A.申请序号i
        //Inner Join INS_VL检查申请费用明细 E On E.单据序号i=A.申请序号i
        //Where C.系统序号=参数业务序号;
        public static void KDo检查确认工作站_接口按钮被点击(object pCtrl, string vs业务类别, string vsTag, long vl业务序号, string vs记账明细)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static bool KDo检查确认工作站_确认_提交前(object pCtrl, string vs业务类别, long vl业务序号, string vs记账明细)
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

        public static string KDo检查确认工作站_确认_提交中(object pCtrl, string vs业务类别, long vl业务序号, string vs记账明细)
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

        public static void KDo检查确认工作站_确认_提交后(object pCtrl, string vs业务类别, long vl业务序号, string vs记账明细)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        //2017年10月9日
        public static bool KDo检查确认工作站_确认_取消前(object pCtrl, string vs业务类别, long vl业务序号, string vs记账明细)
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

        public static string KDo检查确认工作站_确认_取消中(object pCtrl, string vs业务类别, long vl业务序号, string vs记账明细)
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

        public static void KDo检查确认工作站_确认_取消后(object pCtrl, string vs业务类别, long vl业务序号, string vs记账明细)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo检查确认工作站_确认_取消失败(object pCtrl, string vs业务类别, long vl业务序号, string vs记账明细)
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
