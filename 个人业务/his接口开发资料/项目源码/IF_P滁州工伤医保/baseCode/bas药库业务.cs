using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IF_P工伤医保.baseComm;
using IF_P工伤医保.baseData;

namespace IF_P工伤医保.baseCode
{
    internal static class bas药库业务
    {

        public static bool KDo单据保存_提交前(object pForm, long vlng单据编号, string vStr业务类型)
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

        public static string KDo单据保存_提交中(object pForm, long vlng单据编号, string vStr业务类型)
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

        public static void KDo单据保存_提交后(object pForm, long vlng单据编号, string vStr业务类型)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo单据保存_失败(object pForm, long vlng单据编号, string vStr业务类型)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo单据审核_提交前(object pForm, long vlng单据编号, string vStr业务类型)
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

        public static string KDo单据审核_提交中(object pForm, long vlng单据编号, string vStr业务类型)
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

        public static void KDo单据审核_提交后(object pForm, long vlng单据编号, string vStr业务类型)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo单据审核_失败(object pForm, long vlng单据编号, string vStr业务类型)
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
