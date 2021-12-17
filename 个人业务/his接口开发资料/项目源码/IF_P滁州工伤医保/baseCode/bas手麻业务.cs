using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IF_P工伤医保.baseCode
{
    internal static class bas手麻业务
    {
        //2018年9月14日  
        public static bool KDo手麻工作站_准备打开(object pCtrl, object pCmd)
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

        public static void KDo手麻工作站_接口按钮被点击(object pCtrl, string vsTag, long vl住院序号, long vl其他序号)
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
