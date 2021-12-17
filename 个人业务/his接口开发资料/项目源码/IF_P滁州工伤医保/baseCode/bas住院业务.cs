using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ABegin;
using AHC_InterFace;
using IF_P工伤医保.baseComm;
using IF_P工伤医保.baseForm;
using IF_P工伤医保.MyCode;
using IF_P工伤医保.baseData;


namespace IF_P工伤医保.baseCode
{
    internal static class bas住院业务
    {
        #region 定义变量 
        
        #endregion

        public static void KDo住院管理窗口_准备打开(object pCtrl)
        {
            try
            {
                //---------------------

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        #region KDo住院管理窗口_右键菜单准备打开:添加护理中心右键菜单【在住院护理站中新增转医保操作功能】
        public static void KDo住院管理窗口_右键菜单准备打开(object pMenu)
        {
            try
            {
                if (baseData.basData.gb保险客户端)
                {
                    
                    basComm.Do新增右键菜单("工伤医保..转医保登记", "工伤医保..转医保登记", pMenu);
                    basComm.Do新增右键菜单("工伤医保..撤销医保登记", "工伤医保..撤销医保登记", pMenu);
                   
                }
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        #endregion
        private static ContextMenuStrip mnu = null;
        private static long pvl住院序号 = 0;
        #region KDo住院管理窗口_接口菜单被点击:点击护理中心右键菜单
        public static void KDo住院管理窗口_接口菜单被点击(object pCtrl, string vsTag, long vl住院序号)
        {
            try
            {
                #region 查询患者是否是医保患者
               
                
                #endregion
              
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(vsTag + "->" + ex.Message);
            }
        }

        #endregion
        #region 撤销登记
        private static bool Do撤销登记(long vl住院序号)
        {
            try
            {
                //撤销中心医保登记
                //更新本地作废状态
                //删除费用上传记录
                //删除其他上传记录(如，医嘱、手术信息)
                //更新费别为自费
                //DB.ExecCmd(string.Format("update INQ_D住院档案 set 病员费别I='{0}' where 系统序号='{1}' ", "1", vl住院序号));
                return true;
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
                return false;
            }
        }

        #endregion
        #region KDo在院病人管理窗口_准备打开:添加按钮

        public static void KDo在院病人管理窗口_准备打开(object pForm, object pCmd)
        {
            try
            {
                basComm.Do新增按钮("MNU工伤医保", "工伤医保..接口操作", pForm, pCmd);
                if (mnu == null)
                {
                    mnu = new ContextMenuStrip();
                    mnu.Name = "在院";
                    #region 工伤医保..转医保登记

                    ToolStripMenuItem t1 = new ToolStripMenuItem("工伤医保..转医保登记");
                    t1.Name = "工伤医保..转医保登记";

                    #endregion

                    #region  工伤医保..撤销医保登记

                    ToolStripMenuItem t2 = new ToolStripMenuItem("工伤医保..撤销医保登记");
                    t2.Name = "工伤医保..撤销医保登记";

                    #endregion

                    #region  工伤医保..费用上传管理

                    ToolStripMenuItem t4 = new ToolStripMenuItem("工伤医保..费用上传管理");
                    t4.Name = "工伤医保..费用上传管理";

                    #endregion
                    #region  工伤医保..取消出院登记

                    ToolStripMenuItem t3 = new ToolStripMenuItem("工伤医保..取消出院登记");
                    t3.Name = "工伤医保..取消出院登记";

                    #endregion
                    #region  工伤医保..就诊结算信息查询

                    ToolStripMenuItem t5 = new ToolStripMenuItem("工伤医保..就诊结算信息查询");
                    t5.Name = "工伤医保..就诊结算信息查询";

                    #endregion
                    //basComm.Do新增右键菜单("工伤医保..取消出院登记", "工伤医保..取消出院登记", pMenu);
                    ToolStripItem[] t = new ToolStripItem[]
                                            {
                                                t1, t2,t3 , t4,t5
                                            };
                    mnu.Items.AddRange(t);
                    mnu.ItemClicked += Menu_ItemClicked;
                }
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        #endregion
        #region KDo在院病人管理窗口_接口按钮被点击:操作接口按钮菜单
        public static void KDo在院病人管理窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            try
            {
                if (vsTag.Equals("MNU工伤医保"))
                {
                    pvl住院序号 = vl住院序号;
                    mnu.Show(Cursor.Position);
                }
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        private static void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip c = (ContextMenuStrip)sender;
            c.Visible = false;
            string vsTag = e.ClickedItem.Name;
            long vl住院序号 = c.Name.Equals("在院") ? pvl住院序号 : pCy_vl住院序号;
            if (vsTag.Contains("工伤医保"))
            {
                KDo住院管理窗口_接口菜单被点击(sender, vsTag, vl住院序号);
            }
        }
        #endregion
        #region KDo入院登记窗口_准备打开:添加按钮
        public static void KDo入院登记窗口_准备打开(object pForm, object pCmd)
        {
            try
            {
                if (baseData.basData.gb保险客户端)
                {
                   // basComm.Do新增按钮("新SYB刷卡", "新医保..刷卡", pForm, pCmd);
                   
                }
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        #endregion
        #region KDo入院登记窗口_接口按钮被点击:刷卡
        public static void KDo入院登记窗口_接口按钮被点击(object pCtrl, string vsTag)
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
        public static bool KDo入院登记确认_提交前(object pForm, long vl住院序号)
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

        public static string KDo入院登记确认_提交中(object pForm, long vl住院序号)
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
        #region KDo入院登记确认_提交后:医保登记
        public static void KDo入院登记确认_提交后(object pForm, long vl住院序号)
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

        public static void KDo入院登记确认_提交失败(object pForm, long vl住院序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo入院登记窗口取消(object pForm, long vl住院序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        #region KDo撤消入院登记_提交前:撤销医保登记
        public static bool KDo撤消入院登记_提交前(long vl住院序号)
        {
            try
            {
                #region 查询是是医保登记患者
                string sSQL = @"select * from inf_dahyb_住院登记列表 where (住院序号i={0})";
                sSQL = string.Format(sSQL, vl住院序号);
                #endregion
                IRecordSet rs = DB.ExecSQL(sSQL);
                if (!rs.IsEof())
                {
                   basComm.MsgBox("请先撤销医保登记！");
                   return false;
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
        public static string KDo撤消入院登记_提交中(long vl住院序号)
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

        public static void KDo撤消入院登记_提交后(long vl住院序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院费用记帐窗口_准备打开(object pCtrl, object pCmd, long vl住院序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        //2016年7月19日

        public static void KDo住院费用记帐窗口_病人信息加载后(object pCtrl, long vl住院序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院费用记帐窗口_接口按钮被点击(object pCtrl, string vsTag, long vl住院序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo住院费用记帐窗口_准备加入一个项目(object pCtrl, long vl住院序号, long vl项目序号, decimal vd数量)
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

        //2016年7月1日
        public static void KDo住院西药划价窗口_准备打开(object pForm)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo住院中药划价窗口_准备打开(object pForm)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo住院藏药划价窗口_准备打开(object pForm)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院西药划价窗口_病人信息加载后(object pCtrl, long vl住院序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }


        public static void KDo住院中药划价窗口_病人信息加载后(object pCtrl, long vl住院序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }


        public static void KDo住院藏药划价窗口_病人信息加载后(object pCtrl, long vl住院序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }


        public static bool KDo住院西药划价窗口_准备加入一个药品(object pCtrl, long vl住院序号, long vl药品序号, decimal vd数量)
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


        public static bool KDo住院中药划价窗口_准备加入一个药品(object pCtrl, long vl住院序号, long vl药品序号, decimal vd数量)
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


        public static bool KDo住院藏药划价窗口_准备加入一个药品(object pCtrl, long vl住院序号, long vl药品序号, decimal vd数量)
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

        public static string KDo住院划价单_保存验证(long vl住院序号, long vl划价单序号)
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


        public static bool KDo住院西药划价单_提交前(object pForm, long vl住院序号)
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


        public static string KDo住院西药划价单_提交中(object pForm, long vl住院序号, long vl划价单序号)
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


        public static void KDo住院西药划价单_提交后(object pForm, long vl住院序号, long vl划价单序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }


        public static bool KDo住院中药划价单_提交前(object pForm, long vl住院序号)
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


        public static string KDo住院中药划价单_提交中(object pForm, long vl住院序号, long vl划价单序号)
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


        public static void KDo住院中药划价单_提交后(object pForm, long vl住院序号, long vl划价单序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo住院藏药划价单_提交前(object pForm, long vl住院序号)
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


        public static string KDo住院藏药划价单_提交中(object pForm, long vl住院序号, long vl划价单序号)
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


        public static void KDo住院藏药划价单_提交后(object pForm, long vl住院序号, long vl划价单序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo住院费用记帐确认_提交前(object pCtrl, long vl住院序号)
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

        public static string KDo住院费用记帐确认_提交中(object pCtrl, long vl住院序号, long vl单据序号)
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

        public static void KDo住院费用记帐确认_提交后(object pCtrl, long vl住院序号, long vl单据序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院费用记帐窗口取消(object pCtrl, long vl住院序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo住院费用记帐冲销_提交前(object pCtrl, long vl住院序号, string vl费用明细序号)
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

        public static string KDo住院费用记帐冲销_提交中(object pCtrl, long vl住院序号, string vl费用明细序号)
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

        public static void KDo住院费用记帐冲销_提交后(object pCtrl, long vl住院序号, string vl费用明细序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo住院费用记帐作废_提交前(object pCtrl, long vl住院序号, string vl费用明细序号)
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

        public static string KDo住院费用记帐作废_提交中(object pCtrl, long vl住院序号, string vl费用明细序号)
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

        public static void KDo住院费用记帐作废_提交后(object pCtrl, long vl住院序号, string vl费用明细序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院交款窗口_准备打开(object pForm, object pCmd)
        {
            try
            {
                //basComm.Do新增按钮("POS银联刷卡", "POS银联刷卡", pForm, pCmd);
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院交款窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            try
            {
                // MessageBox.Show("vsTag" + vsTag);
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo住院交款确认_提交前(object pForm, long vl住院序号)
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

        public static string KDo住院交款确认_提交中(object pForm, long vl住院序号, long vl单据序号)
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

        public static void KDo住院交款确认_提交后(object pForm, long vl住院序号, long vl单据序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院交款窗口取消(object pForm, long vl住院序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院结算审核窗口_准备打开(object pForm, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院结算审核窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo住院结算审核确认_提交前(object pForm, string vs操作方式, long vl住院序号)
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

        public static string KDo住院结算审核确认_提交中(object pForm, string vs操作方式, long vl住院序号)
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

        public static void KDo住院结算审核确认_提交后(object pForm, string vs操作方式, long vl住院序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院结算审核窗口取消(object pForm)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo住院中途结算审核窗口_准备打开(object pForm, object pCmd)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院中途结算审核窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo住院中途结算审核确认_提交前(object pForm, string vs操作方式, long vl住院序号)
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

        public static string KDo住院中途结算审核确认_提交中(object pForm, string vs操作方式, long vl住院序号)
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

        public static void KDo住院中途结算审核确认_提交后(object pForm, string vs操作方式, long vl住院序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院中途结算审核窗口取消(object pForm)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院结算列表窗口_准备打开(object pCtrl, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }


        public static void KDo住院结算列表窗口_接口按钮被点击(object pCtrl, string vsTag, long vl住院序号)
        {
            try
            {
                //string s结算序号 = basComm.Do获取表格数据(pCtrl, "gridList", "结算序号i");
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo住院结算列表窗口_取消结算_提交前(object pCtrl, long vl结算序号, long vl住院序号 = 0)
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

        public static string KDo住院结算列表窗口_取消结算_提交中(object pCtrl, long vl结算序号)
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

        public static void KDo住院结算列表窗口_取消结算_提交后(object pCtrl, long vl结算序号)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
               
            }
        }

        public static void KDo住院结算列表窗口_取消结算_提交失败(object pForm, long vl结算序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院结算窗口_准备打开(object pForm, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }

        }

        public static void KDo住院结算窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        #region KDo住院结算窗口_报销预算:预结算
        public static bool KDo住院结算窗口_报销预算(object pForm, long vl住院序号)
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
        #region KDo住院结算确认_提交前:出院结算
        public static bool KDo住院结算确认_提交前(object pForm, long vl住院序号)
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
        public static string KDo住院结算确认_提交中(object pForm, long vl住院序号)
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

        public static void KDo住院结算确认_提交后(object pForm, long vl住院序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
                
            }
        }
        #region KDo住院结算确认_提交失败:回退医保结算
        public static void KDo住院结算确认_提交失败(object pForm, long vl住院序号)
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
        public static void KDo住院结算窗口取消(object pForm, long vl住院序号)
        {
            try
            {
                basComm.WriteLog("KDo住院结算窗口取消：住院序号i为：" + vl住院序号.ToString());
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo中途结算窗口_准备打开(object pForm, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }

        }

        public static void KDo中途结算窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo中途结算窗口_报销预算(object pForm, long vl住院序号)
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

        public static bool KDo中途结算确认_提交前(object pForm, long vl住院序号)
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

        public static string KDo中途结算确认_提交中(object pForm, long vl住院序号)
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

        public static void KDo中途结算确认_提交后(object pForm, long vl住院序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo中途结算窗口取消(object pForm, long vl住院序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        #region 出院档案,添加接口按钮
        private static ContextMenuStrip cy_mnu = null;
        private static long pCy_vl住院序号 = 0;
        public static void KDo出院档案列表窗口_准备打开(object pForm, object pCmd)
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
        #region KDo出院档案列表窗口_接口按钮被点击:点击医保按钮
        public static void KDo出院档案列表窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            try
            {
                if (vsTag.Equals("MNU工伤医保"))
                {
                    pCy_vl住院序号 = vl住院序号;
                    cy_mnu.Show(Cursor.Position);
                }
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        #endregion

        public static bool KDo出院保险清单打印(object pForm, long vl住院序号)
        {
            try
            {
                return true;//接口打印  2016年7月27日目前只能返回true
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
                return true;
            }
        }

        public static bool KDo出院保险发票打印(object pForm, long vl住院序号)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
                return true;
            }
        }

        public static bool KDo出院保险结算单打印(object pForm, long vl住院序号)
        {
            try
            {

                return true;//HIS打印 2016年7月27日：目前只能返回true否则无法进入下一步
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
                return true;
            }
        }

        public static void KDo住院登记窗口会员刷卡成功后(object pCtrl, long vl病员编号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }


        public static void KDo住院登记列表_准备打开(object pForm, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院登记列表_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static bool KDo修改住院编号_提交前(object pForm, long vl住院序号)
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

        public static void KDo新型医嘱管理窗口_准备打开(object pForm, long vl住院序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo新型医嘱管理_准备加入一个药品(object pForm, long vl住院序号, long vl药品编号)
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

        public static bool KDo新型医嘱保存确认_提交前(object pForm, long vl住院序号, string vs本次药品编号)
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
        /// <summary>
        /// KDo新型医嘱保存确认_提交后
        /// </summary>
        /// <param name="pForm"></param>
        /// <param name="vl住院序号"></param>
        /// <param name="vS医嘱识别串">处置/西药/中药/膳食/说明/护理/检查/检验|医嘱类型(长期、临时)|医嘱序号</param>
        /// <param name="vS项目或药品序号">药品价格或者项目价格表的序号</param>
        public static void KDo新型医嘱保存确认_提交后(object pForm, long vl住院序号, string vS医嘱识别串, string vS项目或药品序号)
        {
            try
            {
               

                
               
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo住院药房退药_提交前(object pCtrl, long vl住院序号, long vl处方编号)
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

        public static string KDo住院药房退药_提交中(object pCtrl, long vl住院序号, long vl处方编号)
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

        public static void KDo住院药房退药_提交后(object pCtrl, long vl住院序号, long vl处方编号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static string KDo住院发药_提交中(long vl处方编号)
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

        public static void KDo住院记帐窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院记帐窗口_准备打开(object pForm, object pCmd)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }


        public static void KDo自动费用上传(long vl住院序号)
        {
            try
            {
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }


        public static void KDo住院医生工作站_准备打开(object pCtrl, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo住院医生工作站_接口按钮被点击(object pCtrl, string vsTag, long vl住院序号)
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
        //1.当前窗体  (没有意义 忽略这个参数)
        //2.检查/检验
        //3.辅检申请序号(检查为 INS_D检查申请系统.系统序号 检验为  EXP_D检验申请列表.系统序号)
        //4.婴儿序号(住院婴儿序号 没有婴儿就是0)
        public static string KDo住院医生工作站_临床查询辅检报告(object pCtrl, string vs业务类别, long vl辅检申请序号, long vl婴儿序号)
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
        //返回true  调用原始的Pacs/LIS报告 返回false 调用接口方法，HIS直接返回
        public static bool KDo住院医生工作站_临床调阅原始报告(object pCtrl, long vl辅检申请序号)
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
        //2017年5月22日
        public static void KDo住院退款窗口_准备打开(object pForm, object pCmd, long vl住院序号)
        {
            try
            {


            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }


        public static void KDo住院退款窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号, long vl交款序号)
        {
            try
            {


            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static bool KDo住院退款窗口_退款_提交前(object pForm, long vl住院序号, long vl单据序号)
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
        public static string KDo住院退款窗口_退款_提交中(object pForm, long vl住院序号, long vl单据序号)
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
        public static void KDo住院退款窗口_退款_提交后(object pForm, long vl住院序号, long vl单据序号, long lv新单据序号)
        {
            try
            {


            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo住院退款窗口_退款_提交失败(object pForm, long vl住院序号, long vl单据序号)
        {
            try
            {


            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        //2017年5月24日
        public static void KDo住院交款列表_准备打开(object pForm, object pCmd)
        {
            try
            {


            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院交款列表_接口按钮被点击(object pForm, string vsTag, long vl住院序号, long vl交款序号)
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
        //2017年9月12日
        public static void KDo住院医生站_医嘱发送完成后(object pCtrl, long vl住院序号, string vl单据序号, string vs医嘱类型)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo住院医生站_手术申请完成后(object pCtrl, long vl住院序号, long vl单据序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }


        //2017年9月8日16:45:49新增
        public static void KDo住院长期医嘱_准备打开(object pForm, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }

        }
        //默认返回空  接口调用成功返回“vsTag|医嘱序号”
        public static string KDo住院长期医嘱_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            try
            {
                return "";
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
                return "";
            }

        }
        public static void KDo住院临时医嘱_准备打开(object pForm, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        //默认返回空  接口调用成功返回“vsTag|医嘱序号”
        public static string KDo住院临时医嘱_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            try
            {
                return "";
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
                return "";
            }

        }
        public static void KDo住院术中医嘱_准备打开(object pForm, object pCmd)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        //默认返回空  接口调用成功返回“vsTag|医嘱序号”
        public static string KDo住院术中医嘱_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            try
            {
                return "";
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
                return "";
            }
        }
        //2017年9月21日
        public static void KDo住院联动记账窗口_准备打开(object pCtrl, object pCmd, long vl住院序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static void KDo住院联动记账窗口_接口按钮被点击(object pCtrl, string vsTag, long vl住院序号, string vs记账明细)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }
        public static bool KDo住院联动记账_提交前(object pCtrl, long vl住院序号, string vs记账明细)
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

        public static string KDo住院联动记账_提交中(object pCtrl, long vl住院序号, string vs记账明细)
        {
            try
            {
                return "";
            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
                return "";
            }
        }

        public static void KDo住院联动记账_提交后(object pCtrl, long vl住院序号, string vs记账明细)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo住院联动记账窗口取消(object pCtrl, long vl住院序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        public static void KDo患者排床后(object pCtrl, string vs业务类型, long vl住院序号)
        {
            try
            {

            }
            catch (Exception ex)
            {
                baseComm.basComm.MsgError(ex.Message);
            }
        }

        //2018年9月27日:住院医生双击病人，打开病历夹触发,其他序号表示：健康序号I
        public static void KDo住院病历夹_打开后(object pCtrl, long vl住院序号, long vl其它序号)
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
