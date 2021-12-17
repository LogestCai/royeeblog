using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IF_P工伤医保.MyCode
{
    /******************************************************** 
    * 项目名称： CardDC.cs
    * 命名空间 ： IF_P工伤医保.MyCode
    * 类 名 称 ： CardDC
    * 作   者  ： RoyeeCai
    * 邮   箱  ： caimh0223@163.com
    * 概   述  ： 
    * 创建时间 ： 2021-10-07 09:02:24
    * 更新时间 ： 2021-10-07 09:02:24
    * CLR版本  ： 4.0.30319.42000
    * ******************************************************
    * Copyright@RoyeeCai 2021 .All rights reserved.
    * ******************************************************
    */
    public class CardDC
    {
        //[System.Runtime.InteropServices.DllImport("SSCardDriver_DC.DLL")] //, EntryPoint = "InitDLL"       
        [System.Runtime.InteropServices.DllImport("SSCardDriver.DLL")] //, EntryPoint = "InitDLL"
        static extern int iReadCardBas(int iType, StringBuilder pOutInfo);
        //[System.Runtime.InteropServices.DllImport("SSCardDriver_DC.DLL")] //, EntryPoint = "InitDLL"
        [System.Runtime.InteropServices.DllImport("SSCardDriver.DLL")] //, EntryPoint = "InitDLL"
        static extern int iVerifyPIN(int iType, StringBuilder pOutInfo);

        /// <summary>
        /// 德生四合一读卡器读医保卡功能
        /// </summary>
        /// <param name="iType"></param>
        /// <param name="pOutInfo"></param>
        /// <returns></returns>
        public static int iReadYB_DC(int iType, StringBuilder pOutInfo)
        {
            return iReadCardBas(iType, pOutInfo);
        }
        /// <summary>
        /// 德生四合一读卡器验证医保卡密码功能
        /// </summary>
        /// <param name="iType"></param>
        /// <param name="pOutInfo"></param>
        /// <returns></returns>
        public static int iVerifyPIN_DC(int iType, StringBuilder pOutInfo)
        {
            int res = 10;
            try{
                res = iVerifyPIN(iType, pOutInfo);
            }catch(Exception Ex)
            {                
                baseComm.basComm.WriteLog("德卡密码验证是失败！。。。"+Ex.Message);
            }
            return res;             

        }

    }
}
