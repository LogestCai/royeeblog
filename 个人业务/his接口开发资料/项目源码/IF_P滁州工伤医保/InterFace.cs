using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using ABegin;
using IF_P工伤医保.baseCode;

namespace IF_P工伤医保
{

    [ComVisible(true),
    ClassInterface(ClassInterfaceType.AutoDual)]
    public class InterFace
    {
        public static void IDo其他业务操作(string vs业务名称, object pCtrl, string vsMessage)
        {
            bas保险业务.KDo其他业务操作(vs业务名称, pCtrl, vsMessage);
        }
        public static void IDo按键被按下(object pFormCtrl, string pFCName, long KeyCode, long Shift)
        {
            bas保险业务.KDo按键被按下(pFormCtrl, pFCName, KeyCode, Shift);
        }

        public static bool IDo保险接口菜单被选择(string vs名称)

        {
            return bas保险业务.KDo保险接口菜单被选择(vs名称);
        }
        public static bool IGet查询函数可用(string vs函数名称)
        {
            foreach (MethodInfo TT in typeof(InterFace).GetMethods())
            {
                if (vs函数名称.ToUpper().Equals(TT.Name.ToUpper()))
                {
                    return true;
                }
            }
            return false;
        }

        public static void IDo制卡读卡窗口_接口按钮被点击(object pForm, string vsTag)
        {
            bas保险业务.KDo制卡读卡窗口_接口按钮被点击(pForm, vsTag);
        }

        public static void IDo制卡读卡窗口_准备打开(object pForm, object pCmd)
        {
            bas保险业务.KDo制卡读卡窗口_准备打开(pForm, pCmd);
        }

        public static void IDo制卡读卡窗口_读卡成功后(long vLng病员编号)
        {
            bas保险业务.KDo制卡读卡窗口_读卡成功后(vLng病员编号);
        }

        public static string IDo住院发药_提交中(long vl处方编号)
        {
            return bas住院业务.KDo住院发药_提交中(vl处方编号);
        }

        public static void IDo住院记帐窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            bas住院业务.KDo住院记帐窗口_接口按钮被点击(pForm, vsTag, vl住院序号);
        }

        public static void IDo住院记帐窗口_准备打开(object pForm, object pCmd)
        {
            bas住院业务.KDo住院记帐窗口_准备打开(pForm, pCmd);
        }

        public static void IDo快速建档保存窗口_准备打开(object pForm, object pCmd)
        {
            bas挂号业务.KDo快速建档保存窗口_准备打开(pForm, pCmd);
        }

        public static void IDo快速建档窗口_接口按钮被点击(object pForm, string vsTag)
        {
            bas挂号业务.KDo快速建档保存窗口_接口按钮被点击(pForm, vsTag);
        }

        public static bool IDo快速建档保存确认_提交前(object pCtrl)
        {
            return bas挂号业务.KDo快速建档保存确认_提交前(pCtrl);
        }

        public static string IDo快速建档保存确认_提交中(object pCtrl, long vl病员编号)
        {
            return bas挂号业务.KDo快速建档保存确认_提交中(pCtrl, vl病员编号);
        }

        public static void IDo快速建档保存确认_提交后(object pCtrl, long vl病员编号)
        {
            bas挂号业务.KDo快速建档保存确认_提交后(pCtrl, vl病员编号);
        }

        public static void IDo门诊收费支付窗口_收到金额按下(object pForm, int KeyCode, int Shift)
        {
            bas门诊业务.KDo门诊收费支付窗口_收到金额按下(pForm, KeyCode, Shift);
        }

        public static void IDo门诊医生工作站_查看健康档案(object pCtrl, long vl病员编号)
        {
            bas门诊业务.KDo门诊医生工作站_查看健康档案(pCtrl, vl病员编号);
        }

        public static bool IDo门诊就诊确认_提交前(object pCtrl)
        {
            return bas门诊业务.KDo门诊就诊确认_提交前(pCtrl);
        }

        public static string IDo门诊就诊确认_提交中(object pCtrl, long vl就诊序号)
        {
            return bas门诊业务.KDo门诊就诊确认_提交中(pCtrl, vl就诊序号);
        }

        public static void IDo门诊就诊确认_提交后(object pCtrl, long vl就诊序号)
        {
            bas门诊业务.KDo门诊就诊确认_提交后(pCtrl, vl就诊序号);
        }

        public static void IDo门诊就诊窗口_接口按钮被点击(object pCtrl, string vsTag)
        {
            bas门诊业务.KDo门诊就诊窗口_接口按钮被点击(pCtrl, vsTag);
        }

        public static void IDo门诊就诊窗口_准备打开(object pForm, object pCmd)
        {
            bas门诊业务.KDo门诊就诊窗口_准备打开(pForm, pCmd);
        }

        public static void IDo门诊挂号窗口_挂号金额改变(object pForm)
        {
            bas挂号业务.KDo门诊挂号窗口_挂号金额改变(pForm);
        }

        public static void IDo门诊收费窗口_选择挂号单(object pForm, long vl挂号单号)
        {
            bas门诊业务.KDo门诊收费窗口_选择挂号单(pForm, vl挂号单号);
        }

        public static void IDo门诊收费列表窗口_整单退费_提交失败(object pCtrl, long vl单据序号)
        {
            bas门诊业务.KDo门诊收费列表窗口_整单退费_提交失败(pCtrl, vl单据序号);
        }

        public static void IDo门诊挂号列表窗口_作废_提交失败(object pCtrl, long vl单据序号)
        {
            bas挂号业务.KDo门诊挂号列表窗口_作废_提交失败(pCtrl, vl单据序号);
        }
        //2016年7月1日
        public static bool IDo住院西药划价单_提交前(object pForm, long vl住院序号)
        {
            return bas住院业务.KDo住院西药划价单_提交前(pForm, vl住院序号);
        }
        public static string IDo住院西药划价单_提交中(object pForm, long vl住院序号, long vl划价单序号)
        {
            return bas住院业务.KDo住院西药划价单_提交中(pForm, vl住院序号, vl划价单序号);
        }
        public static void IDo住院西药划价单_提交后(object pForm, long vl住院序号, long vl划价单序号)
        {
            bas住院业务.KDo住院西药划价单_提交后(pForm, vl住院序号, vl划价单序号);
        }
        //中药
        public static bool IDo住院中药划价单_提交前(object pForm, long vl住院序号)
        {
            return bas住院业务.KDo住院中药划价单_提交前(pForm, vl住院序号);
        }
        public static string IDo住院中药划价单_提交中(object pForm, long vl住院序号, long vl划价单序号)
        {
            return bas住院业务.KDo住院中药划价单_提交中(pForm, vl住院序号, vl划价单序号);
        }
        public static void IDo住院中药划价单_提交后(object pForm, long vl住院序号, long vl划价单序号)
        {
            bas住院业务.KDo住院中药划价单_提交后(pForm, vl住院序号, vl划价单序号);
        }
        //藏药
        public static bool IDo住院藏药划价单_提交前(object pForm, long vl住院序号)
        {
            return bas住院业务.KDo住院藏药划价单_提交前(pForm, vl住院序号);
        }
        public static string IDo住院藏药划价单_提交中(object pForm, long vl住院序号, long vl划价单序号)
        {
            return bas住院业务.KDo住院藏药划价单_提交中(pForm, vl住院序号, vl划价单序号);
        }
        public static void IDo住院藏药划价单_提交后(object pForm, long vl住院序号, long vl划价单序号)
        {
            bas住院业务.KDo住院藏药划价单_提交后(pForm, vl住院序号, vl划价单序号);
        }

        public static bool IDo电子处方划价窗口_准备加入一个药品(object pForm, long vl就诊序号, long vl药品编号)
        {
            return bas门诊业务.KDo电子处方划价窗口_准备加入一个药品(pForm, vl就诊序号, vl药品编号);
        }

        public static bool IDo电子处方划价确认_提交前(object pForm, long vl就诊序号)
        {
            return bas门诊业务.KDo电子处方划价确认_提交前(pForm, vl就诊序号);
        }

        public static string IDo电子处方划价确认_提交中(object pForm, long vl就诊序号, long vl处方序号)
        {
            return bas门诊业务.KDo电子处方划价确认_提交中(pForm, vl就诊序号, vl处方序号);
        }

        public static void IDo电子处方划价确认_提交后(object pForm, long vl就诊序号, long vl处方序号)
        {
            bas门诊业务.KDo电子处方划价确认_提交后(pForm, vl就诊序号, vl处方序号);
        }

        public static void IDo电子处方划价窗口取消(object pForm, long vl就诊序号)
        {
            bas门诊业务.KDo电子处方划价窗口取消(pForm, vl就诊序号);
        }

        public static bool IDo住院药房退药_提交前(object pCtrl, long vl住院序号, long vl处方编号)
        {
            return bas住院业务.KDo住院药房退药_提交前(pCtrl, vl住院序号, vl处方编号);
        }

        public static string IDo住院药房退药_提交中(object pCtrl, long vl住院序号, long vl处方编号)
        {
            return bas住院业务.KDo住院药房退药_提交中(pCtrl, vl住院序号, vl处方编号);
        }

        public static void IDo住院药房退药_提交后(object pCtrl, long vl住院序号, long vl处方编号)
        {
            bas住院业务.KDo住院药房退药_提交后(pCtrl, vl住院序号, vl处方编号);
        }

        public static void IDo自动费用上传(long vl住院序号)
        {
            bas住院业务.KDo自动费用上传(vl住院序号);
        }

        public static void IDo打开接口首页(string vs接口类别)
        {
            bas保险业务.KDo打开接口首页(vs接口类别);
        }

        public static bool IDo系统已初始化(string vs保险类型, long vl组件版本)
        {
            return bas保险业务.KDo系统已初始化(vs保险类型, vl组件版本);
        }

        public static void IDo操作员登录窗口_准备打开(object pForm, object pCmd)
        {
            bas保险业务.KDo操作员登录窗口_准备打开(pForm, pCmd);
        }

        public static void IDo操作员登录窗口_接口按钮被点击(object pForm, string vsTag)
        {
            bas保险业务.KDo操作员登录窗口_接口按钮被点击(pForm, vsTag);
        }

        public static bool IDo操作员已登录(long vInt操作员编号, string vStr操作员名称, long vInt隶属机构编号, string vStr隶属机构名称, long vLong终端序号, string vStr终端名称, object vFrmMain)
        {
            return bas保险业务.KDo操作员已登录(vInt操作员编号, vStr操作员名称, vInt隶属机构编号, vStr隶属机构名称, vLong终端序号, vStr终端名称, vFrmMain);
        }
        public static void IDo操作员已退出()
        {
            bas保险业务.KDo操作员已退出();
        }

        public static void IDo系统准备退出()
        {
            bas保险业务.KDo系统准备退出();
        }

        public static void IDo会员准备刷卡(object pTxt)
        {
            bas保险业务.KDo会员准备刷卡(pTxt);
        }
        public static void IDo门诊挂号支付窗口_准备打开(object pCtrl, object pCmd)
        {
            bas挂号业务.KDo门诊挂号支付窗口_准备打开(pCtrl, pCmd);
        }

        public static void IDo门诊挂号支付窗口_接口按钮被点击(object pCtrl, string vsTag)
        {
            bas挂号业务.KDo门诊挂号支付窗口_接口按钮被点击(pCtrl, vsTag);
        }
        public static void IDo门诊挂号窗口_准备打开(object pCtrl, object pCmd)
        {
            bas挂号业务.KDo门诊挂号窗口_准备打开(pCtrl, pCmd);
        }

        public static void IDo门诊挂号窗口_接口按钮被点击(object pCtrl, string vsTag)
        {
            bas挂号业务.KDo门诊挂号窗口_接口按钮被点击(pCtrl, vsTag);
        }

        public static bool IDo门诊挂号确认_提交前(object pCtrl)
        {
            return bas挂号业务.KDo门诊挂号确认_提交前(pCtrl);
        }

        public static string IDo门诊挂号确认_提交中(object pCtrl, long vl单据序号)
        {
            return bas挂号业务.KDo门诊挂号确认_提交中(pCtrl, vl单据序号);
        }

        public static void IDo门诊挂号确认_提交后(object pCtrl, long vl单据序号)
        {
            bas挂号业务.KDo门诊挂号确认_提交后(pCtrl, vl单据序号);
        }

        public static void IDo门诊挂号确认_失败(object pForm, long v单据编号)
        {
            bas挂号业务.KDo门诊挂号确认_失败(pForm, v单据编号);
        }

        public static void IDo门诊挂号窗口取消(object pCtrl)
        {
            bas挂号业务.KDo门诊挂号窗口取消(pCtrl);
        }

        public static bool IDo门诊挂号列表窗口_作废_提交前(object pCtrl, long vl单据序号)
        {
            return bas挂号业务.KDo门诊挂号列表窗口_作废_提交前(pCtrl, vl单据序号);
        }

        public static string IDo门诊挂号列表窗口_作废_提交中(object pCtrl, long vl单据序号, long vl新挂号单序号)
        {
            return bas挂号业务.KDo门诊挂号列表窗口_作废_提交中(pCtrl, vl单据序号, vl新挂号单序号);
        }

        public static void IDo门诊挂号列表窗口_作废_提交后(object pCtrl, long vl单据序号)
        {
            bas挂号业务.KDo门诊挂号列表窗口_作废_提交后(pCtrl, vl单据序号);
        }

        public static void IDo门诊收费窗口_准备打开(object pCtrl, object pCmd)
        {
            bas门诊业务.KDo门诊收费窗口_准备打开(pCtrl, pCmd);
        }

        public static void IDo门诊收费窗口_接口按钮被点击(object pCtrl, string vsTag)
        {
            bas门诊业务.KDo门诊收费窗口_接口按钮被点击(pCtrl, vsTag);
        }

        public static bool IDo门诊收费窗口_准备加入一个项目(object pCtrl, long vl项目序号)
        {
            return bas门诊业务.KDo门诊收费窗口_准备加入一个项目(pCtrl, vl项目序号);
        }

        public static bool IDo门诊收费窗口_调入一笔处方单(object pCtrl, long vl划价单序号)
        {
            return bas门诊业务.KDo门诊收费窗口_调入一笔处方单(pCtrl, vl划价单序号);
        }

        public static bool IDo门诊收费支付窗口_准备打开(object pForm, object pCmd, long vl缴费序号)
        {
            return bas门诊业务.KDo门诊收费支付窗口_准备打开(pForm, pCmd, vl缴费序号);
        }

        public static void IDo门诊收费支付窗口_接口按钮被点击(object pForm, string vsTag, long vl缴费序号)
        {
            bas门诊业务.KDo门诊收费支付窗口_接口按钮被点击(pForm, vsTag, vl缴费序号);
        }

        public static void IDo门诊收费支付窗口取消(object pForm)
        {
            bas门诊业务.KDo门诊收费支付窗口取消(pForm);
        }

        public static bool IDo门诊收费确认_提交前(object pCtrl)
        {
            return bas门诊业务.KDo门诊收费确认_提交前(pCtrl);
        }

        public static string IDo门诊收费确认_提交中(object pCtrl, long vl缴费序号)
        {
            return bas门诊业务.KDo门诊收费确认_提交中(pCtrl, vl缴费序号);
        }

        public static void IDo门诊收费确认_提交后(object pCtrl, long vl收费序号)
        {
            bas门诊业务.KDo门诊收费确认_提交后(pCtrl, vl收费序号);
        }

        public static void IDo门诊收费确认_失败(bool vbln开始保存, bool vbln结算成功)
        {
            bas门诊业务.KDo门诊收费确认_失败(vbln开始保存, vbln结算成功);
        }

        public static void IDo门诊收费窗口取消(object pCtrl)
        {
            bas门诊业务.KDo门诊收费窗口取消(pCtrl);
        }

        public static void IDo门诊收费列表窗口_准备打开(object pCtrl, object pCmd)
        {
            bas门诊业务.KDo门诊收费列表窗口_准备打开(pCtrl, pCmd);
        }

        public static void IDo门诊收费列表窗口_接口按钮被点击(object pCtrl, string vsTag, long vl单据序号)
        {
            bas门诊业务.KDo门诊收费列表窗口_接口按钮被点击(pCtrl, vsTag, vl单据序号);
        }

        public static bool IDo门诊收费列表窗口_整单退费_提交前(object pCtrl, long vl单据序号)
        {
            return bas门诊业务.KDo门诊收费列表窗口_整单退费_提交前(pCtrl, vl单据序号);
        }

        public static string IDo门诊收费列表窗口_整单退费_提交中(object pCtrl, long vl单据序号, long vl新单据序号)
        {
            return bas门诊业务.KDo门诊收费列表窗口_整单退费_提交中(pCtrl, vl单据序号, vl新单据序号);
        }

        public static void IDo门诊收费列表窗口_整单退费_提交后(object pCtrl, long vl单据序号)
        {
            bas门诊业务.KDo门诊收费列表窗口_整单退费_提交后(pCtrl, vl单据序号);
        }

        public static void IDo门诊支付窗口_分单退费_接口按钮被点击(object pCtrl, string vsTag, long vl原单序号, long vl新临时序号)
        {
            bas门诊业务.KDo门诊支付窗口_分单退费_接口按钮被点击(pCtrl, vsTag, vl原单序号, vl新临时序号);
        }

        public static bool IDo门诊支付窗口_分单退费_准备打开(object pCtrl, object pCmd, long vl原单序号, long vl新临时序号)
        {
            return bas门诊业务.KDo门诊支付窗口_分单退费_准备打开(pCtrl, pCmd, vl原单序号, vl新临时序号);
        }

        public static bool IDo门诊收费列表窗口_分单退费_提交前(object pCtrl, long vLng待退明细序号)
        {
            return bas门诊业务.KDo门诊收费列表窗口_分单退费_提交前(pCtrl, vLng待退明细序号);
        }

        public static string IDo门诊收费列表窗口_分单退费_提交中(object pCtrl, long vl原单据号, long vl新单据号)
        {
            return bas门诊业务.KDo门诊收费列表窗口_分单退费_提交中(pCtrl, vl原单据号, vl新单据号);
        }

        public static void IDo门诊收费列表窗口_分单退费_提交后(object pCtrl, long vl原单据号, long vl新单据号)
        {
            bas门诊业务.KDo门诊收费列表窗口_分单退费_提交后(pCtrl, vl原单据号, vl新单据号);
        }

        public static void IDo门诊收费列表窗口_分单退费_提交失败(object pCtrl, long vl原单序号, long vl新临时序号)
        {
            bas门诊业务.KDo门诊收费列表窗口_分单退费_提交失败(pCtrl, vl原单序号, vl新临时序号);
        }

        public static bool IDo门诊药房_分零退药许可(object pCtrl, long vLng处方序号)
        {
            return bas门诊业务.KDo门诊药房_分零退药许可(pCtrl, vLng处方序号);
        }

        public static void IDo住院管理窗口_准备打开(object pCtrl)
        {
            bas住院业务.KDo住院管理窗口_准备打开(pCtrl);
        }

        public static void IDo住院管理窗口_接口菜单被点击(object pCtrl, string vsTag, long vl住院序号)
        {
            bas住院业务.KDo住院管理窗口_接口菜单被点击(pCtrl, vsTag, vl住院序号);
        }

        public static void IDo住院管理窗口_右键菜单准备打开(object pMenu)
        {
            bas住院业务.KDo住院管理窗口_右键菜单准备打开(pMenu);
        }
        public static void IDo入院登记窗口_准备打开(object pForm, object pCmd)
        {
            bas住院业务.KDo入院登记窗口_准备打开(pForm, pCmd);
        }

        public static void IDo入院登记窗口_接口按钮被点击(object pCtrl, string vsTag)
        {
            bas住院业务.KDo入院登记窗口_接口按钮被点击(pCtrl, vsTag);
        }

        public static bool IDo入院登记确认_提交前(object pForm, long vl住院序号)
        {
            return bas住院业务.KDo入院登记确认_提交前(pForm, vl住院序号);
        }

        public static string IDo入院登记确认_提交中(object pForm, long vl住院序号)
        {
            return bas住院业务.KDo入院登记确认_提交中(pForm, vl住院序号);
        }

        public static void IDo入院登记确认_提交后(object pForm, long vl住院序号)
        {
            bas住院业务.KDo入院登记确认_提交后(pForm, vl住院序号);
        }

        public static void IDo入院登记确认_提交失败(object pForm, long vl住院序号)
        {
            bas住院业务.KDo入院登记确认_提交失败(pForm, vl住院序号);
        }

        public static void IDo入院登记窗口取消(object pForm, long vl住院序号)
        {
            bas住院业务.KDo入院登记窗口取消(pForm, vl住院序号);
        }

        public static bool IDo撤消入院登记_提交前(long vl住院序号)
        {
            return bas住院业务.KDo撤消入院登记_提交前(vl住院序号);
        }

        public static string IDo撤消入院登记_提交中(long vl住院序号)
        {
            return bas住院业务.KDo撤消入院登记_提交中(vl住院序号);
        }

        public static void IDo撤消入院登记_提交后(long vl住院序号)
        {
            bas住院业务.KDo撤消入院登记_提交后(vl住院序号);
        }

        public static void IDo住院费用记帐窗口_准备打开(object pCtrl, object pCmd, long vl住院序号)
        {
            bas住院业务.KDo住院费用记帐窗口_准备打开(pCtrl, pCmd, vl住院序号);
        }

        public static void IDo住院费用记帐窗口_接口按钮被点击(object pCtrl, string vsTag, long vl住院序号)
        {
            bas住院业务.KDo住院费用记帐窗口_接口按钮被点击(pCtrl, vsTag, vl住院序号);
        }

        public static bool IDo住院费用记帐窗口_准备加入一个项目(object pCtrl, long vl住院序号, long vl项目序号, decimal vd数量)
        {
            return bas住院业务.KDo住院费用记帐窗口_准备加入一个项目(pCtrl, vl住院序号, vl项目序号, vd数量);
        }

        public static string IDo住院划价单_保存验证(long vl住院序号, long vl划价单序号)
        {
            return bas住院业务.KDo住院划价单_保存验证(vl住院序号, vl划价单序号);
        }

        public static bool IDo住院费用记帐确认_提交前(object pCtrl, long vl住院序号)
        {
            return bas住院业务.KDo住院费用记帐确认_提交前(pCtrl, vl住院序号);
        }

        public static string IDo住院费用记帐确认_提交中(object pCtrl, long vl住院序号, long vl单据序号)
        {
            return bas住院业务.KDo住院费用记帐确认_提交中(pCtrl, vl住院序号, vl单据序号);
        }

        public static void IDo住院费用记帐确认_提交后(object pCtrl, long vl住院序号, long vl单据序号)
        {
            bas住院业务.KDo住院费用记帐确认_提交后(pCtrl, vl住院序号, vl单据序号);
        }

        public static void IDo住院费用记帐窗口取消(object pCtrl, long vl住院序号)
        {
            bas住院业务.KDo住院费用记帐窗口取消(pCtrl, vl住院序号);
        }

        public static bool IDo住院费用记帐冲销_提交前(object pCtrl, long vl住院序号, string vl费用明细序号)
        {
            return bas住院业务.KDo住院费用记帐冲销_提交前(pCtrl, vl住院序号, vl费用明细序号);
        }

        public static string IDo住院费用记帐冲销_提交中(object pCtrl, long vl住院序号, string vl费用明细序号)
        {
            return bas住院业务.KDo住院费用记帐冲销_提交中(pCtrl, vl住院序号, vl费用明细序号);
        }

        public static void IDo住院费用记帐冲销_提交后(object pCtrl, long vl住院序号, string vl费用明细序号)
        {
            bas住院业务.KDo住院费用记帐冲销_提交后(pCtrl, vl住院序号, vl费用明细序号);
        }

        public static bool IDo住院费用记帐作废_提交前(object pCtrl, long vl住院序号, string vl费用明细序号)
        {
            return bas住院业务.KDo住院费用记帐作废_提交前(pCtrl, vl住院序号, vl费用明细序号);
        }

        public static string IDo住院费用记帐作废_提交中(object pCtrl, long vl住院序号, string vl费用明细序号)
        {
            return bas住院业务.KDo住院费用记帐作废_提交中(pCtrl, vl住院序号, vl费用明细序号);
        }

        public static void IDo住院费用记帐作废_提交后(object pCtrl, long vl住院序号, string vl费用明细序号)
        {
            bas住院业务.KDo住院费用记帐作废_提交后(pCtrl, vl住院序号, vl费用明细序号);
        }

        public static void IDo住院交款窗口_准备打开(object pForm, object pCmd)
        {
            bas住院业务.KDo住院交款窗口_准备打开(pForm, pCmd);
        }

        public static void IDo住院交款窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            bas住院业务.KDo住院交款窗口_接口按钮被点击(pForm, vsTag, vl住院序号);
        }

        public static bool IDo住院交款确认_提交前(object pForm, long vl住院序号)
        {
            return bas住院业务.KDo住院交款确认_提交前(pForm, vl住院序号);
        }

        public static string IDo住院交款确认_提交中(object pForm, long vl住院序号, long vl单据序号)
        {
            return bas住院业务.KDo住院交款确认_提交中(pForm, vl住院序号, vl单据序号);
        }

        public static void IDo住院交款确认_提交后(object pForm, long vl住院序号, long vl单据序号)
        {
            bas住院业务.KDo住院交款确认_提交后(pForm, vl住院序号, vl单据序号);
        }

        public static void IDo住院交款窗口取消(object pForm, long vl住院序号)
        {
            bas住院业务.KDo住院交款窗口取消(pForm, vl住院序号);
        }

        public static void IDo住院结算审核窗口_准备打开(object pForm, object pCmd)
        {
            bas住院业务.KDo住院结算审核窗口_准备打开(pForm, pCmd);
        }

        public static void IDo住院结算审核窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            bas住院业务.KDo住院结算审核窗口_接口按钮被点击(pForm, vsTag, vl住院序号);
        }

        public static bool IDo住院结算审核确认_提交前(object pForm, string vs操作方式, long vl住院序号)
        {
            return bas住院业务.KDo住院结算审核确认_提交前(pForm, vs操作方式, vl住院序号);
        }

        public static string IDo住院结算审核确认_提交中(object pForm, string vs操作方式, long vl住院序号)
        {
            return bas住院业务.KDo住院结算审核确认_提交中(pForm, vs操作方式, vl住院序号);
        }

        public static void IDo住院结算审核确认_提交后(object pForm, string vs操作方式, long vl住院序号)
        {
            bas住院业务.KDo住院结算审核确认_提交后(pForm, vs操作方式, vl住院序号);
        }

        public static void IDo住院结算审核窗口取消(object pForm)
        {
            bas住院业务.KDo住院结算审核窗口取消(pForm);
        }
        public static void IDo住院中途结算审核窗口_准备打开(object pForm, object pCmd)
        {
            bas住院业务.KDo住院中途结算审核窗口_准备打开(pForm, pCmd);
        }

        public static void IDo住院中途结算审核窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            bas住院业务.KDo住院中途结算审核窗口_接口按钮被点击(pForm, vsTag, vl住院序号);
        }

        public static bool IDo住院中途结算审核确认_提交前(object pForm, string vs操作方式, long vl住院序号)
        {
            return bas住院业务.KDo住院中途结算审核确认_提交前(pForm, vs操作方式, vl住院序号);
        }

        public static string IDo住院中途结算审核确认_提交中(object pForm, string vs操作方式, long vl住院序号)
        {
            return bas住院业务.KDo住院中途结算审核确认_提交中(pForm, vs操作方式, vl住院序号);
        }

        public static void IDo住院中途结算审核确认_提交后(object pForm, string vs操作方式, long vl住院序号)
        {
            bas住院业务.KDo住院中途结算审核确认_提交后(pForm, vs操作方式, vl住院序号);
        }

        public static void IDo住院中途结算审核窗口取消(object pForm)
        {
            bas住院业务.KDo住院中途结算审核窗口取消(pForm);
        }

        public static void IDo住院结算列表窗口_准备打开(object pCtrl, object pCmd)
        {
            bas住院业务.KDo住院结算列表窗口_准备打开(pCtrl, pCmd);
        }

        public static void IDo住院结算列表窗口_接口按钮被点击(object pCtrl, string vsTag, long vl结算序号)
        {
            bas住院业务.KDo住院结算列表窗口_接口按钮被点击(pCtrl, vsTag, vl结算序号);
        }

        public static bool IDo住院结算列表窗口_取消结算_提交前(object pCtrl, long vl结算序号)
        {
            return bas住院业务.KDo住院结算列表窗口_取消结算_提交前(pCtrl, vl结算序号);
        }

        public static string IDo住院结算列表窗口_取消结算_提交中(object pCtrl, long vl结算序号)
        {
            return bas住院业务.KDo住院结算列表窗口_取消结算_提交中(pCtrl, vl结算序号);
        }

        public static void IDo住院结算列表窗口_取消结算_提交后(object pCtrl, long vl结算序号)
        {
            bas住院业务.KDo住院结算列表窗口_取消结算_提交后(pCtrl, vl结算序号);
        }

        public static void IDo住院结算列表窗口_取消结算_提交失败(object pForm, long vl结算序号)
        {
            bas住院业务.KDo住院结算列表窗口_取消结算_提交失败(pForm, vl结算序号);
        }

        public static void IDo住院结算窗口_准备打开(object pForm, object pCmd)
        {
            bas住院业务.KDo住院结算窗口_准备打开(pForm, pCmd);
        }

        public static void IDo住院结算窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            bas住院业务.KDo住院结算窗口_接口按钮被点击(pForm, vsTag, vl住院序号);
        }

        public static bool IDo住院结算窗口_报销预算(object pForm, long vl住院序号)
        {
            return bas住院业务.KDo住院结算窗口_报销预算(pForm, vl住院序号);
        }

        public static bool IDo住院结算确认_提交前(object pForm, long vl住院序号)
        {
            return bas住院业务.KDo住院结算确认_提交前(pForm, vl住院序号);
        }

        public static string IDo住院结算确认_提交中(object pForm, long vl住院序号)
        {
            return bas住院业务.KDo住院结算确认_提交中(pForm, vl住院序号);
        }

        public static void IDo住院结算确认_提交后(object pForm, long vl住院序号)
        {
            bas住院业务.KDo住院结算确认_提交后(pForm, vl住院序号);
        }

        public static void IDo住院结算确认_提交失败(object pForm, long vl住院序号)
        {
            bas住院业务.KDo住院结算确认_提交失败(pForm, vl住院序号);
        }

        public static void IDo住院结算窗口取消(object pForm, long vl住院序号)
        {
            bas住院业务.KDo住院结算窗口取消(pForm, vl住院序号);
        }

        public static void IDo中途结算窗口_准备打开(object pForm, object pCmd)
        {
            bas住院业务.KDo中途结算窗口_准备打开(pForm, pCmd);
        }

        public static void IDo中途结算窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            bas住院业务.KDo中途结算窗口_接口按钮被点击(pForm, vsTag, vl住院序号);
        }

        public static bool IDo中途结算窗口_报销预算(object pForm, long vl住院序号)
        {
            return bas住院业务.KDo中途结算窗口_报销预算(pForm, vl住院序号);
        }

        public static bool IDo中途结算确认_提交前(object pForm, long vl住院序号)
        {
            return bas住院业务.KDo中途结算确认_提交前(pForm, vl住院序号);
        }

        public static string IDo中途结算确认_提交中(object pForm, long vl住院序号)
        {
            return bas住院业务.KDo中途结算确认_提交中(pForm, vl住院序号);
        }

        public static void IDo中途结算确认_提交后(object pForm, long vl住院序号)
        {
            bas住院业务.KDo中途结算确认_提交后(pForm, vl住院序号);
        }

        public static void IDo中途结算窗口取消(object pForm, long vl住院序号)
        {
            bas住院业务.KDo中途结算窗口取消(pForm, vl住院序号);
        }

        public static void IDo建立健康档案_准备打开(object pForm, object pCmd)
        {
            bas挂号业务.KDo快速建档列表窗口_准备打开(pForm, pCmd);
        }

        public static void IDo建立健康档案_接口按钮被点击(object pForm, string vsTag)
        {
            bas挂号业务.KDo快速建档列表窗口_接口按钮被点击(pForm, vsTag);
        }


        public static void IDo出院档案列表窗口_准备打开(object pForm, object pCmd)
        {
            bas住院业务.KDo出院档案列表窗口_准备打开(pForm, pCmd);
        }

        public static void IDo出院档案列表窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            bas住院业务.KDo出院档案列表窗口_接口按钮被点击(pForm, vsTag, vl住院序号);
        }

        public static bool IDo出院保险清单打印(object pForm, long vl住院序号)
        {
            return bas住院业务.KDo出院保险清单打印(pForm, vl住院序号);
        }



        public static bool IDo出院保险发票打印(object pForm, long vl住院序号)
        {
            return bas住院业务.KDo出院保险发票打印(pForm, vl住院序号);
        }



        public static bool IDo出院保险结算单打印(object pForm, long vl住院序号)
        {
            return bas住院业务.KDo出院保险结算单打印(pForm, vl住院序号);
        }



        public static bool IDo门诊保险结算单打印(object pForm, long vl门诊序号)
        {
            return bas门诊业务.KDo门诊保险结算单打印(pForm, vl门诊序号);

        }


        public static bool IDo门诊收费列表窗口_修改信息_提交前(object pForm, long vl单据序号)
        {
            return bas门诊业务.KDo门诊收费列表窗口_修改信息_提交前(pForm, vl单据序号);

        }



        public static void IDo住院登记列表_准备打开(object pForm, object pCmd)
        {
            bas住院业务.KDo住院登记列表_准备打开(pForm, pCmd);
        }


        public static void IDo住院登记列表_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            bas住院业务.KDo住院登记列表_接口按钮被点击(pForm, vsTag, vl住院序号);
        }

        public static void IDo在院病人管理窗口_准备打开(object pForm, object pCmd)
        {
            bas住院业务.KDo在院病人管理窗口_准备打开(pForm, pCmd);
        }


        public static void IDo在院病人管理窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            bas住院业务.KDo在院病人管理窗口_接口按钮被点击(pForm, vsTag, vl住院序号);
        }
        public static bool IDo修改住院编号_提交前(object pForm, long vl住院序号)
        {
            return bas住院业务.KDo修改住院编号_提交前(pForm, vl住院序号);
        }


        public static void IDo新型医嘱管理窗口_准备打开(object pForm, long vl住院序号)
        {
            bas住院业务.KDo新型医嘱管理窗口_准备打开(pForm, vl住院序号);

        }



        public static bool IDo新型医嘱管理_准备加入一个药品(object pForm, long vl住院序号, long vl药品编号)
        {
            return bas住院业务.KDo新型医嘱管理_准备加入一个药品(pForm, vl住院序号, vl药品编号);
        }



        public static bool IDo新型医嘱保存确认_提交前(object pForm, long vl住院序号, string vs本次药品编号)
        {
            return bas住院业务.KDo新型医嘱保存确认_提交前(pForm, vl住院序号, vs本次药品编号);
        }



        public static void IDo新型医嘱保存确认_提交后(object pForm, long vl住院序号, string vS本次项目医嘱序号, string vS本次药品医嘱序号)
        {
            bas住院业务.KDo新型医嘱保存确认_提交后(pForm, vl住院序号, vS本次项目医嘱序号, vS本次药品医嘱序号);
        }

        public static bool IDo单据保存_提交前(object pForm, long vlng单据编号, string vStr业务类型)
        {
            return bas药库业务.KDo单据保存_提交前(pForm, vlng单据编号, vStr业务类型);
        }

        public static string IDo单据保存_提交中(object pForm, long vlng单据编号, string vStr业务类型)
        {
            return bas药库业务.KDo单据保存_提交中(pForm, vlng单据编号, vStr业务类型);
        }

        public static void IDo单据保存_提交后(object pForm, long vlng单据编号, string vStr业务类型)
        {
            bas药库业务.KDo单据保存_提交后(pForm, vlng单据编号, vStr业务类型);
        }

        public static void IDo单据保存_失败(object pForm, long vlng单据编号, string vStr业务类型)
        {
            bas药库业务.KDo单据保存_失败(pForm, vlng单据编号, vStr业务类型);
        }

        public static bool IDo单据审核_提交前(object pForm, long vlng单据编号, string vStr业务类型)
        {
            return bas药库业务.KDo单据审核_提交前(pForm, vlng单据编号, vStr业务类型);
        }

        public static string IDo单据审核_提交中(object pForm, long vlng单据编号, string vStr业务类型)
        {
            return bas药库业务.KDo单据审核_提交中(pForm, vlng单据编号, vStr业务类型);
        }

        public static void IDo单据审核_提交后(object pForm, long vlng单据编号, string vStr业务类型)
        {
            bas药库业务.KDo单据审核_提交后(pForm, vlng单据编号, vStr业务类型);
        }

        public static void IDo单据审核_失败(object pForm, long vlng单据编号, string vStr业务类型)
        {
            bas药库业务.KDo单据审核_失败(pForm, vlng单据编号, vStr业务类型);
        }

        public static bool IDo下帐收费确认_提交前(object pForm, long vl挂号序号)
        {
            return bas门诊业务.KDo下帐收费确认_提交前(pForm, vl挂号序号);
        }

        public static string IDo下帐收费确认_提交中(object pForm, long vl挂号序号, long vl就诊序号)
        {
            return bas门诊业务.KDo下帐收费确认_提交中(pForm, vl挂号序号, vl就诊序号);
        }

        public static void IDo下帐收费确认_提交后(object pForm, long vl收费序号, long vl就诊序号)
        {
            bas门诊业务.KDo下帐收费确认_提交后(pForm, vl收费序号, vl就诊序号);
        }

        public static void IDo下帐收费确认_失败(object pForm, long vl挂号序号, long vl就诊序号)
        {
            bas门诊业务.KDo下帐收费确认_失败(pForm, vl挂号序号, vl就诊序号);
        }

        public static void IDo会员刷卡(object pCtrl, long vl病员编号)
        {
            bas保险业务.KDo会员刷卡(pCtrl, vl病员编号);
        }

        public static void IDo门诊发药_刷卡(object pForm, long vlng会员编号)
        {
            bas门诊业务.KDo门诊发药_刷卡(pForm, vlng会员编号);
        }

        public static bool IDo门诊医生工作站_准备加入一个项目(object pForm, long vl收费项目序号, decimal vDub项目价格)
        {
            return bas门诊业务.KDo门诊医生工作站_准备加入一个项目(pForm, vl收费项目序号, vDub项目价格);
        }

        public static void IDo门诊收费窗口取消刷卡(object pCtrl)
        {
            bas门诊业务.KDo门诊收费窗口取消刷卡(pCtrl);
        }
        public static void IDo通用列表窗口_准备打开(string vs业务名称, object pCtrl, object pCmd)
        {
            bas保险业务.KDo通用列表窗口_准备打开(vs业务名称, pCtrl, pCmd);
        }
        public static void IDo通用列表窗口_接口按钮被点击(string vs业务名称, object pCtrl, string vsTag)
        {
            bas保险业务.KDo通用列表窗口_接口按钮被点击(vs业务名称, pCtrl, vsTag);
        }
        public static void InitBaseData(long vsUserId, string vsUserName, long vsOrgId, string vsOrgName, long vLong终端序号, string vStr终端名称)
        {
            baseData.basData.pInt操作员编号 = vsUserId;
            baseData.basData.pStr操作员名称 = vsUserName;
            baseData.basData.pInt隶属机构编号 = vsOrgId;
            baseData.basData.pStr隶属机构名称 = vsOrgName;
            baseData.basData.pInt终端序号 = vLong终端序号;
            baseData.basData.pStr终端名称 = vStr终端名称;
        }


        //2016年7月1日
        public static bool IDo住院西药划价窗口_准备加入一个药品(object pForm, long vl住院序号, long vl药品序号, decimal vd数量)
        {
            return bas住院业务.KDo住院西药划价窗口_准备加入一个药品(pForm, vl住院序号, vl药品序号, vd数量);
        }

        public static bool IDo住院中药划价窗口_准备加入一个药品(object pForm, long vl住院序号, long vl药品序号, decimal vd数量)
        {
            return bas住院业务.KDo住院中药划价窗口_准备加入一个药品(pForm, vl住院序号, vl药品序号, vd数量);
        }

        public static bool IDo住院藏药划价窗口_准备加入一个药品(object pForm, long vl住院序号, long vl药品序号, decimal vd数量)
        {
            return bas住院业务.KDo住院藏药划价窗口_准备加入一个药品(pForm, vl住院序号, vl药品序号, vd数量);
        }
        //
        public static void IDo住院西药划价窗口_病人信息加载后(object pCtrl, long vl住院序号)
        {
            bas住院业务.KDo住院西药划价窗口_病人信息加载后(pCtrl, vl住院序号);
        }
        public static void IDo住院中药划价窗口_病人信息加载后(object pCtrl, long vl住院序号)
        {
            bas住院业务.KDo住院中药划价窗口_病人信息加载后(pCtrl, vl住院序号);
        }
        public static void IDo住院藏药划价窗口_病人信息加载后(object pCtrl, long vl住院序号)
        {
            bas住院业务.KDo住院藏药划价窗口_病人信息加载后(pCtrl, vl住院序号);
        }
        //
        public static void IDo住院西药划价窗口_准备打开(object pForm)
        {
            bas住院业务.KDo住院西药划价窗口_准备打开(pForm);
        }

        public static void IDo住院中药划价窗口_准备打开(object pForm)
        {
            bas住院业务.KDo住院中药划价窗口_准备打开(pForm);
        }

        public static void IDo住院藏药药划价窗口_准备打开(object pForm)
        {
            bas住院业务.KDo住院藏药划价窗口_准备打开(pForm);
        }

        //2016年7月19日
        public static void IDo住院费用记帐窗口_病人信息加载后(object pCtrl, long vl住院序号)
        {
            bas住院业务.KDo住院费用记帐窗口_病人信息加载后(pCtrl, vl住院序号);
        }

        //2016年7月22日
        public static void IDo门诊挂号列表窗口_准备打开(object pCtrl, object pCmd)
        {
            bas挂号业务.KDo门诊挂号列表窗口_准备打开(pCtrl, pCmd);
        }
        //
        public static void IDo门诊挂号列表窗口_接口按钮被点击(object pCtrl, string vsTag, long vL挂号序号)
        {
            bas挂号业务.KDo门诊挂号列表窗口_接口按钮被点击(pCtrl, vsTag, vL挂号序号);
        }


        //20161205 加入
        public static void IDo门诊医生工作站_准备打开(object pCtrl, object pCmd)
        {
            bas门诊业务.KDo门诊医生工作站_准备打开(pCtrl, pCmd);
        }

        public static void IDo门诊医生工作站_接口按钮被点击(object pCtrl, string vsTag, long vl就诊序号)
        {
            bas门诊业务.KDo门诊医生工作站_接口按钮被点击(pCtrl, vsTag, vl就诊序号);
        }

        public static void IDo住院医生工作站_准备打开(object pCtrl, object pCmd)
        {
            bas住院业务.KDo住院医生工作站_准备打开(pCtrl, pCmd);
        }
        public static void IDo住院医生工作站_接口按钮被点击(object pCtrl, string vsTag, long vl住院序号)
        {
            bas住院业务.KDo住院医生工作站_接口按钮被点击(pCtrl, vsTag, vl住院序号);
        }

        //2017年5月11日
        //1.当前窗体  (没有意义  接口加的  我传null  你忽略这个参数)
        //2.检查/检验
        //3.门诊/住院/留观
        //4.辅检申请序号(检查为 INS_D检查申请系统.系统序号 检验为  EXP_D检验申请列表.系统序号)
        //5.婴儿序号(住院婴儿序号 没有婴儿就是0)
        public static string IDo临床查询辅检报告(object pCtrl, string vs业务类别, string vs业务来源, long vl辅检申请序号, long vl婴儿序号)
        {
            if (vs业务来源.Equals("门诊"))
            {
                return bas门诊业务.KDo门诊医生工作站_临床查询辅检报告(pCtrl, vs业务类别, vl辅检申请序号, vl婴儿序号);
            }
            else if (vs业务来源.Equals("门特"))
            {
                return bas门特业务.KDo门特医生工作站_临床查询辅检报告(pCtrl, vs业务类别, vl辅检申请序号, vl婴儿序号);
            }
            else if (vs业务来源.Equals("留观"))
            {
                return bas留观业务.KDo留观医生工作站_临床查询辅检报告(pCtrl, vs业务类别, vl辅检申请序号, vl婴儿序号);
            }
            else if (vs业务来源.Equals("住院"))
            {
                return bas住院业务.KDo住院医生工作站_临床查询辅检报告(pCtrl, vs业务类别, vl辅检申请序号, vl婴儿序号);
            }
            else
            {
                return "";//其他情况
            }
        }
        //pCtrl 原定义传当前窗口, 目前无意义.
        //vlng检查申请序号 和 文字报告的 序号是一样的 
        //vs业务来源 : 门诊/住院/留观
        //返回true  调用原始的Pacs/LIS报告 返回false 调用接口方法，HIS直接返回
        public static bool IDo临床调阅原始报告(object pCtrl, long vl辅检申请序号, string vs业务来源)
        {
            if (vs业务来源.Equals("门诊"))
            {
                return bas门诊业务.KDo门诊医生工作站_临床调阅原始报告(pCtrl, vl辅检申请序号);
            }
            else if (vs业务来源.Equals("门特"))
            {
                return bas门特业务.KDo门特医生工作站_临床调阅原始报告(pCtrl, vl辅检申请序号);
            }
            else if (vs业务来源.Equals("留观"))
            {
                return bas留观业务.KDo留观医生工作站_临床调阅原始报告(pCtrl, vl辅检申请序号);
            }
            else if (vs业务来源.Equals("住院"))
            {
                return bas住院业务.KDo住院医生工作站_临床调阅原始报告(pCtrl, vl辅检申请序号);
            }
            else
            {
                //其他情况
                return true;
            }
        }

        //2017年5月22日
        public static void IDo住院退款窗口_准备打开(object pForm, object pCmd, long vl住院序号)
        {
            bas住院业务.KDo住院退款窗口_准备打开(pForm, pCmd, vl住院序号);
        }
        public static void IDo住院退款窗口_接口按钮被点击(object pForm, string vsTag, long vl住院序号, long vl交款序号)
        {
            bas住院业务.KDo住院退款窗口_接口按钮被点击(pForm, vsTag, vl住院序号, vl交款序号);
        }
        public static bool IDo住院退款窗口_提交前(object pForm, long vl住院序号, long vl单据序号)
        {
            return bas住院业务.KDo住院退款窗口_退款_提交前(pForm, vl住院序号, vl单据序号);
        }
        public static string IDo住院退款窗口_提交中(object pForm, long vl住院序号, long vl单据序号)
        {
            return bas住院业务.KDo住院退款窗口_退款_提交中(pForm, vl住院序号, vl单据序号);
        }
        public static void IDo住院退款窗口_提交后(object pForm, long vl住院序号, long vl单据序号, long lv新单据序号)
        {
            bas住院业务.KDo住院退款窗口_退款_提交后(pForm, vl住院序号, vl单据序号, lv新单据序号);
        }
        public static void IDo住院退款窗口_提交失败(object pForm, long vl住院序号, long vl单据序号)
        {
            bas住院业务.KDo住院退款窗口_退款_提交失败(pForm, vl住院序号, vl单据序号);
        }

        //2017年5月24日
        public static void IDo住院交款列表_准备打开(object pForm, object pCmd)
        {
            bas住院业务.KDo住院交款列表_准备打开(pForm, pCmd);
        }
        public static void IDo住院交款列表_接口按钮被点击(object pForm, string vsTag, long vl住院序号, long vl交款序号)
        {
            bas住院业务.KDo住院交款列表_接口按钮被点击(pForm, vsTag, vl住院序号, vl交款序号);
        }
        //2017年6月9日
        public static void IDo门诊支付窗口_分单退费_取消(object pCtrl, object pCmd, long vl原单序号, long vl新临时序号)
        {
            bas门诊业务.KDo门诊支付窗口_分单退费_取消(pCtrl, pCmd, vl原单序号, vl新临时序号);
        }

        //2017年8月15日
        //vs操作类型有:门诊收费、门诊挂号、住院登记、住院交款、住院结算 
        //vl其他序号 在不同的操作类型下面，值不一样门诊可能是挂号序号，住院可能是住院序号，结算序号之类的
        //你如果返回的是false，则HIs不继续下一步
        public static bool IDo健康刷卡后(object pForm, object pCmd, string vs操作类型, string vl健康序号, string vl其他序号)
        {
            if (vs操作类型.IndexOf("门诊") > -1)
            {
                if (vs操作类型.IndexOf("挂号") > -1)
                {
                    return bas挂号业务.KDo健康刷卡后(pForm, pCmd, vs操作类型, vl健康序号, vl其他序号);
                }
                else
                {
                    return bas门诊业务.KDo健康刷卡后(pForm, pCmd, vs操作类型, vl健康序号, vl其他序号);
                }
            }
            else if (vs操作类型.IndexOf("院") > -1)
            {
                return bas住院业务.KDo健康刷卡后(pForm, pCmd, vs操作类型, vl健康序号, vl其他序号);
            }
            else
            {
                return true;
            }
        }


        //2017年3月14日18:37:47 新增/修改
        public static bool IDo门诊发药_提交前(long vl处方编号, string vs处方类型)
        {
            return bas门诊业务.KDo门诊发药_提交前(vl处方编号, vs处方类型);
        }
        public static string IDo门诊发药_提交中(long vl处方编号, string vs处方类型)
        {
            return bas门诊业务.KDo门诊发药_提交中(vl处方编号, vs处方类型);
        }

        public static void IDo门诊发药_提交后(long vl处方编号, string vs处方类型)
        {
            bas门诊业务.KDo门诊发药_提交后(vl处方编号, vs处方类型);
        }
        public static void IDo门诊发药_失败(long vl处方编号, string vs处方类型)
        {
            bas门诊业务.KDo门诊发药_失败(vl处方编号, vs处方类型);
        }
        //2017年4月5日13:35:41新增
        public static void IDo门诊医生工作站呼叫患者(object pCtrl, long vl待诊序号)
        {
            bas门诊业务.KDo门诊医生工作站呼叫患者(pCtrl, vl待诊序号);
        }
        public static void IDo门诊医生站_发送医嘱提交后(object pCtrl, long vl就诊序号)
        {
            bas门诊业务.KDo门诊医生站_发送医嘱提交后(pCtrl, vl就诊序号);
        }

        public static void IDo报告完成后(object pCtrl, long vl健康序号, long vl单据序号, string vs报告类型)
        {
            bas门诊业务.KDo报告完成后(pCtrl, vl健康序号, vl单据序号, vs报告类型);
        }

        public static void IDo住院医生站_医嘱发送完成后(object pCtrl, long vl住院序号, string vl单据序号, string vs医嘱类型)
        {
            bas住院业务.KDo住院医生站_医嘱发送完成后(pCtrl, vl住院序号, vl单据序号, vs医嘱类型);
        }
        public static void IDo住院医生站_手术申请完成后(object pCtrl, long vl住院序号, long vl单据序号)
        {
            bas住院业务.KDo住院医生站_手术申请完成后(pCtrl, vl住院序号, vl单据序号);
        }


        //2017年9月8日16:45:49新增
        public static void IDo住院长期医嘱_准备打开(object pForm, object pCmd)
        {
            bas住院业务.KDo住院长期医嘱_准备打开(pForm, pCmd);
        }
        //默认返回空  接口调用成功返回“vsTag|医嘱序号”
        public static string IDo住院长期医嘱_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            return bas住院业务.KDo住院长期医嘱_接口按钮被点击(pForm, vsTag, vl住院序号);
        }
        public static void IDo住院临时医嘱_准备打开(object pForm, object pCmd)
        {
            bas住院业务.KDo住院临时医嘱_准备打开(pForm, pCmd);
        }
        //默认返回空  接口调用成功返回“vsTag|医嘱序号”
        public static string IDo住院临时医嘱_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            return bas住院业务.KDo住院临时医嘱_接口按钮被点击(pForm, vsTag, vl住院序号);
        }
        public static void IDo住院术中医嘱_准备打开(object pForm, object pCmd)
        {
            bas住院业务.KDo住院术中医嘱_准备打开(pForm, pCmd);
        }
        //默认返回空  接口调用成功返回“vsTag|医嘱序号”
        public static string IDo住院术中医嘱_接口按钮被点击(object pForm, string vsTag, long vl住院序号)
        {
            return bas住院业务.KDo住院术中医嘱_接口按钮被点击(pForm, vsTag, vl住院序号);
        }


        public static void IDo账户充值列表窗口_准备打开(object pForm, object pCmd)
        {
            bas充值业务.KDo账户充值列表窗口_准备打开(pForm, pCmd);
        }
        public static void IDo账户充值列表窗口_接口按钮被点击(object pForm, string vsTag, long vl充值序号)
        {
            bas充值业务.KDo账户充值列表窗口_接口按钮被点击(pForm, vsTag, vl充值序号);
        }

        //2017年9月8日16:44:55新增
        public static void IDo账户充值窗口_准备打开(object pForm, object pCmd)
        {
            bas充值业务.KDo账户充值列表窗口_准备打开(pForm, pCmd);
        }
        public static void IDo账户充值窗口_接口按钮被点击(object pForm, string vsTag, long vl健康序号)
        {
            bas充值业务.KDo账户充值列表窗口_接口按钮被点击(pForm, vsTag, vl健康序号);
        }


        public static bool IDo账户充值窗口_提交前(object pForm, long vl健康序号)
        {
            return bas充值业务.KDo账户充值窗口_提交前(pForm, vl健康序号);
        }
        public static string IDo账户充值窗口_提交中(object pForm, long vl健康序号, long vl单据序号)
        {
            return bas充值业务.KDo账户充值窗口_提交中(pForm, vl健康序号, vl单据序号);
        }
        public static void IDo账户充值窗口_提交后(object pForm, long vl健康序号, long vl单据序号)
        {
            bas充值业务.KDo账户充值窗口_提交后(pForm, vl健康序号, vl单据序号);
        }
        public static void IDo账户充值窗口_提交失败(object pForm, long vl健康序号, long vl单据序号)
        {
            bas充值业务.KDo账户充值窗口_提交失败(pForm, vl健康序号, vl单据序号);
        }


        public static void IDo账户退费窗口_准备打开(object pForm, object pCmd)
        {
            bas充值业务.KDo账户退费窗口_准备打开(pForm, pCmd);
        }

        public static void IDo账户退费窗口_接口按钮被点击(object pForm, string vsTag, long vl健康序号, long vl单据序号)
        {
            bas充值业务.KDo账户退费窗口_接口按钮被点击(pForm, vsTag, vl健康序号, vl单据序号);
        }


        public static bool IDo账户退费窗口_提交前(object pForm, long vl健康序号, long vl单据序号)
        {
            return bas充值业务.KDo账户退费窗口_提交前(pForm, vl健康序号, vl单据序号);
        }
        public static string IDo账户退费窗口_提交中(object pForm, long vl健康序号, long vl原单据序号, long vl新单据序号)
        {
            return bas充值业务.KDo账户退费窗口_提交中(pForm, vl健康序号, vl原单据序号, vl新单据序号);
        }
        public static void IDo账户退费窗口_提交后(object pForm, long vl健康序号, long vl原单据序号, long vl新单据序号)
        {
            bas充值业务.KDo账户退费窗口_提交后(pForm, vl健康序号, vl原单据序号, vl新单据序号);
        }
        public static void IDo账户退费窗口_提交失败(object pForm, long vl健康序号, long vl原单据序号, long vl新单据序号)
        {
            bas充值业务.KDo账户退费窗口_提交失败(pForm, vl健康序号, vl原单据序号, vl新单据序号);
        }
        //返回null，表示接口不读 否则返回实体
        public static IDMessageInfo IDo身份证读卡(object pForm)
        {
            return bas保险业务.KDo身份证读卡(pForm);
        }
        //2017年9月21日
        public static void IDo住院联动记账窗口_准备打开(object pCtrl, object pCmd, long vl住院序号)
        {
            bas住院业务.KDo住院联动记账窗口_准备打开(pCtrl, pCmd, vl住院序号);
        }
        public static void IDo住院联动记账窗口_接口按钮被点击(object pCtrl, string vsTag, long vl住院序号, string vs记账明细串)
        {
            bas住院业务.KDo住院联动记账窗口_接口按钮被点击(pCtrl, vsTag, vl住院序号, vs记账明细串);
        }
        public static bool IDo住院联动记账_提交前(object pCtrl, long vl住院序号, string vs记账明细串)
        {
            return bas住院业务.KDo住院联动记账_提交前(pCtrl, vl住院序号, vs记账明细串);
        }

        public static string IDo住院联动记账_提交中(object pCtrl, long vl住院序号, string vs记账明细串)
        {
            return bas住院业务.KDo住院联动记账_提交中(pCtrl, vl住院序号, vs记账明细串);
        }

        public static void IDo住院联动记账_提交后(object pCtrl, long vl住院序号, string vs记账明细串)
        {
            bas住院业务.KDo住院联动记账_提交后(pCtrl, vl住院序号, vs记账明细串);
        }

        public static void IDo住院联动记账窗口取消(object pCtrl, long vl住院序号)
        {
            bas住院业务.KDo住院联动记账窗口取消(pCtrl, vl住院序号);
        }
        //2017年9月22日
        public static void IDo检查确认工作站_准备打开(object pCtrl, object pCmd)
        {
            bas医技业务.KDo检查确认工作站_准备打开(pCtrl, pCmd);
        }
        public static void IDo检查确认工作站_接口按钮被点击(object pCtrl, string vs业务类别, string vsTag, long vl业务序号, string vs记账明细)
        {
            bas医技业务.KDo检查确认工作站_接口按钮被点击(pCtrl, vsTag, vs业务类别, vl业务序号, vs记账明细);
        }
        public static bool IDo检查确认工作站_确认_提交前(object pCtrl, string vs业务类别, long vl业务序号, string vs记账明细)
        {
            return bas医技业务.KDo检查确认工作站_确认_提交前(pCtrl, vs业务类别, vl业务序号, vs记账明细);
        }

        public static string IDo检查确认工作站_确认_提交中(object pCtrl, string vs业务类别, long vl业务序号, string vs记账明细)
        {
            return bas医技业务.KDo检查确认工作站_确认_提交中(pCtrl, vs业务类别, vl业务序号, vs记账明细);
        }

        public static void IDo检查确认工作站_确认_提交后(object pCtrl, string vs业务类别, long vl业务序号, string vs记账明细)
        {
            bas医技业务.KDo检查确认工作站_确认_提交后(pCtrl, vs业务类别, vl业务序号, vs记账明细);
        }

        //2017年10月9日
        public static bool IDo检查确认工作站_确认_取消前(object pCtrl, string vs业务类别, long vl业务序号, string vs记账明细)
        {
            return bas医技业务.KDo检查确认工作站_确认_取消前(pCtrl, vs业务类别, vl业务序号, vs记账明细);
        }

        public static string IDo检查确认工作站_确认_取消中(object pCtrl, string vs业务类别, long vl业务序号, string vs记账明细)
        {
            return bas医技业务.KDo检查确认工作站_确认_取消中(pCtrl, vs业务类别, vl业务序号, vs记账明细);
        }

        public static void IDo检查确认工作站_确认_取消后(object pCtrl, string vs业务类别, long vl业务序号, string vs记账明细)
        {
            bas医技业务.KDo检查确认工作站_确认_取消后(pCtrl, vs业务类别, vl业务序号, vs记账明细);
        }

        public static void IDo检查确认工作站_确认_取消失败(object pCtrl, string vs业务类别, long vl业务序号, string vs记账明细)
        {
            bas医技业务.KDo检查确认工作站_确认_取消失败(pCtrl, vs业务类别, vl业务序号, vs记账明细);
        }
        //2018年1月10日
        public static void IDo患者排床后(object pCtrl, string vs业务类型, long vl住院序号)
        {
            bas住院业务.KDo患者排床后(pCtrl, vs业务类型, vl住院序号);
        }

        //2018年1月24日
        public static string IDo快速检索刷卡(object pCtrl, string vs备用参数1, string vs备用参数2)
        {
            return bas保险业务.KDo快速检索刷卡(pCtrl, vs备用参数1, vs备用参数2);
        }

        //2018年7月12日
        public static void IDo下帐收费确认窗口取消(object pCtrl, long vl挂号序号, long vl就诊序号)
        {
            bas门诊业务.KDo下帐收费确认窗口取消(pCtrl, vl挂号序号, vl就诊序号);
        }

        public static void IDo下帐收费确认窗口_准备打开(object pCtrl, object pCmd, long vl挂号序号, long vl就诊序号)
        {
            bas门诊业务.KDo下帐收费确认窗口_准备打开(pCtrl, pCmd, vl挂号序号, vl就诊序号);
        }

        //2018年9月14日 新增
        public static bool IDo手麻工作站_准备打开(object pCtrl, object pCmd)
        {
            return bas手麻业务.KDo手麻工作站_准备打开(pCtrl, pCmd);
        }

        public static void IDo手麻工作站_接口按钮被点击(object pCtrl, string vsTag, long vl住院序号, long vl其他序号)
        {
            bas手麻业务.KDo手麻工作站_接口按钮被点击(pCtrl, vsTag, vl住院序号, vl其他序号);
        }
        //2018年9月27日:住院医生双击病人，打开病历夹触发,其他序号表示：健康序号I
        public static void IDo住院病历夹_打开后(object pCtrl, long vl住院序号, long vl其它序号)
        {
            bas住院业务.KDo住院病历夹_打开后(pCtrl, vl住院序号, vl其它序号);
        }
        //其他序号表示：健康序号I
        public static void IDo留观病历夹_打开后(object pCtrl, long vl留观序号, long vl其它序号)
        {
            bas留观业务.KDo留观病历夹_打开后(pCtrl, vl留观序号, vl其它序号);
        }

    }
}
