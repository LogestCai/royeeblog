using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ABegin;
using AHC_InterFace;
using IF_P工伤医保.baseData;
using System.Windows.Forms;
using IF_P工伤医保.baseComm;
using System.Net;
using IF_P工伤医保.baseForm;
using IF_P工伤医保.MyCode;

namespace IF_P工伤医保.baseCode
{
    internal static class bas保险业务
    {
        /// <summary>
        /// 其他通用操作
        /// </summary>
        /// <param name="vs业务名称"></param>
        /// <param name="pCtrl"></param>
        /// <param name="vsMessage"></param>
        public static string KDo其他业务操作(string vs业务名称, object pCtrl, string vsMessage)
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
        public static void KDo通用列表窗口_准备打开(string vs业务名称, object pCtrl, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo通用列表窗口_接口按钮被点击(string vs业务名称, object pCtrl, string vsTag)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo按键被按下(object pFormCtrl, string pFCName, long KeyCode, long Shift)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        #region KDo系统已初始化:读取配置信息
        public static bool KDo系统已初始化(string vs保险类型, long vl上次组件版本)
        {
            try
            {
                #region//内置代码
                if (vl上次组件版本 > basData.Gl当前组件版本)
                {
                    throw new Exception("接口组件[" + typeof(InterFace).Assembly.GetName().Name + "]太旧，请使用更新版本的保险接口组件！");
                }
                else if (vl上次组件版本 < basData.Gl当前组件版本)
                {
                    if (baseComm.basComm.MsgBoxYN("接口组件[" + typeof(InterFace).Assembly.GetName().Name + "]需要升级，确定要升级吗？") == false)
                    {
                        return false;
                    }
                    if (!basComm.Do接口相关升级(vs保险类型, vl上次组件版本))
                    {
                        return false;
                    }
                }

                #endregion
                #region //获取配置文件
                string s文件夹路径 = AppDomain.CurrentDomain.BaseDirectory + "\\YbUpDown";
                if (!System.IO.Directory.Exists(s文件夹路径)) System.IO.Directory.CreateDirectory(s文件夹路径);
                string sPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "IF_P工伤医保.ini");
                basData.gsAppPah = sPath;
                basData.gb保险客户端 = System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\" + "IF_P工伤医保客户端标志.ini");
                string s对账误差额 = basComm.ReadIni(sPath, "配置信息", "对账误差额");
                basData.gd对账误差额 = Convert.ToDecimal(string.IsNullOrEmpty(s对账误差额) ? "0" : s对账误差额);
                basData.gs社保机构编号 = basComm.ReadIni(sPath, "配置信息", "社保机构编号");
                basData.gs医院编码 = basComm.ReadIni(sPath, "配置信息", "医院编码");
                basData.gs工伤保险url = basComm.ReadIni(sPath, "配置信息", "工伤保险url");
               
                string sErrMsg = "";
               
                
                #endregion
                #region 输出表前缀
                //basData.dt系统参数 = DB.ExecuteDataTable("select distinct A.参数名称,A.参数值1,A.参数值2,A.备注 from INF_TAHYB_系统参数列表  A");
                basComm.WriteLog(string.Format("本接口[组件版本:{0}]后台表前缀:[INF_TAHYB_]和[INF_DAHYB_]", baseData.basData.Gl当前组件版本));
                #endregion
                return true;
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
                return true;
            }
        }
        #endregion
        
        public static void KDo打开接口首页(string vs接口类别)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
      
        /// <summary>
        /// 未使用
        /// </summary>
        /// <param name="pForm"></param>
        /// <param name="pCmd"></param>
        public static void KDo操作员登录窗口_准备打开(object pForm, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        /// <summary>
        /// 未使用
        /// </summary>
        /// <param name="pForm"></param>
        /// <param name="vsTag"></param>
        public static void KDo操作员登录窗口_接口按钮被点击(object pForm, string vsTag)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        #region KDo操作员已登录:添加菜单，接口初始化/签到
        public static bool KDo操作员已登录(long vInt操作员编号, string vStr操作员名称, long vInt隶属机构编号, string vStr隶属机构名称, long vLong终端序号, string vStr终端名称, object vFrmMain)
        {
            try
            {
                #region 添加菜单
                if (basData.gb保险客户端)
                {
                    baseComm.basComm.Do新增菜单("MNU工伤医保", "工伤医保..目录管理");
                    baseComm.basComm.Do新增菜单("MNU工伤医保", "工伤医保..备案管理");                   

                    #region 接口初始化
                  
                    #endregion
                }
                #endregion
                return true;
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
                return true;
            }
        }
        #endregion
        public static void KDo操作员已退出()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        #region KDo保险接口菜单被选择:点击【接口】菜单下菜单
        public static bool KDo保险接口菜单被选择(string vs名称)
        {
            try
            {
                if (vs名称 == "工伤医保..目录管理")
                {
                    string s输出参数 = "";
                    string sHIS交易号 = "";
                    if (!GSYB.sendRequest("query_basic_info", "{\"p_grbh\":\"341125199010235974\",\"p_yltclb\":\"0\",\"p_xzbz\":\"D\",\"p_rq\":\"20211214\"}", ref s输出参数, ref sHIS交易号))
                    {
                        basComm.MsgBox(s输出参数);
                        return false;
                    }
                    else {
                        basComm.MsgBox(s输出参数);
                        return false;
                    }
                }

                if (vs名称 == "工伤医保..备案管理")
                {
                    Fg工伤备案 f = new Fg工伤备案();
                    f.Text = basData.gs接口简名 + ".." + f.Text;
                    f.Show();
                }
                
                
                return true;
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
                return false;
            }
        }
        #endregion

        #region KDo系统准备退出:签退
        public static void KDo系统准备退出()
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

        internal static void KDo会员刷卡(object pCtrl, long vl病员编号)
        {

        }
        //一卡通读卡
        public static void KDo制卡读卡窗口_接口按钮被点击(object pForm, string vsTag)
        {

        }

        public static void KDo制卡读卡窗口_准备打开(object pForm, object pCmd)
        {

        }

        public static void KDo制卡读卡窗口_读卡成功后(long vLng病员编号)
        {

        }
        //一卡通读卡
        public static void KDo会员准备刷卡(object pTxt)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message); ;
            }
        }

        //返回null，表示接口不读 否则返回实体
        public static IDMessageInfo KDo身份证读卡(object pForm)
        {
            try
            {               
                return null;
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
                return null;
            }
        }
        //前面是健康序号，后面是健康ID,竖线分割,返回空，则不走这个接口
        //比如你社保卡绑定到健康档案社保卡字段
        //那么你在读社保卡的还是，这个地方就把社保卡号读出来，然后去健康档案里面查，查到了，就返回查到的健康序号和id
        //没查到就提示先去绑定
        public static string KDo快速检索刷卡(object pCtrl, string vs备用参数1, string vs备用参数2)
        {
            try
            {
                //return "3155|00003099";
                return string.Empty;
            }
            catch (Exception err)
            {
                baseComm.basComm.MsgError("[KDo快速检索刷卡]异常:" + err.Message);
                return string.Empty;
            }
        }
    }
}
