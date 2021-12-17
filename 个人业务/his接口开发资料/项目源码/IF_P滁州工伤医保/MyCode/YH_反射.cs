using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using AHC_InterFace;
using IF_成都市医保.baseComm;
using IF_成都市医保.baseCtrl;
using IF_成都市医保.baseForm;

namespace IF_成都市医保.MyCode
{
    #region  接口API申明类
    public class YH
    {
        //（1）一般对于char* ,void*这种可以直接对应IntPtr,比如在C#中，我们经常用string类型，其转换为IntPtr再传给char*,void*等，转换方法为
        //string txt="test"; Marshal.StringToCoTaskMemAuto(txt);
        //这里有时会用 StringToCoTaskMemAnsi，不过StringToCoTaskMemAuto自动分配内存就可以了。这样就会将txt的内容复制到非托管的内存块中。
        //(2)对于结构体，比如有一结构体 StructText，将其转换为Intptr，尽量不要直接用Marshal.StructureToPtr，这样很容易出错。可以这样来用：
        //int size = Marshal.SizeOf(StructText);//获取结构体占用空间大小
        //IntPtr intptr= Marshal.AllocHGlobal(size);//声明一个同样大小的空间
        //Marshal.StructureToPtr(StructText, intptr, true);//将结构体放到这个空间中
        //成功返回1；失败返回<0的整数
        #region  接口API原型
        private System.Type jkType;
        public object jk;
        public YH()
        {
            try
            {
                jkType = System.Type.GetTypeFromProgID("YinHai.ChenDu.Interface");
                jk = System.Activator.CreateInstance(jkType);
            }
            catch (Exception)
            {
                throw new Exception("无法创建接口调用实例[YinHai.ChenDu.Interface]，请检查接口环境是否配置正确！");
            }
        }
        //初始化函数
        public object yh_interface_init(ref long aint_appcode, ref string astr_appmsg)
        {
            try
            {
                object[] ParamArray = new object[2];
                ParamArray[0] = 0;
                ParamArray[1] = string.Empty;
                //Com参数封装
                ParameterModifier[] ParamMods = new ParameterModifier[1];
                ParamMods[0] = new ParameterModifier(2); // 初始化为接口参数的个数
                ParamMods[0][0] = true; // 设置第一个参数为返回参数
                ParamMods[0][1] = true; // 设置第二个参数为返回参数
                object o = jkType.InvokeMember("yh_interface_init", System.Reflection.BindingFlags.InvokeMethod, null, jk,
                                           ParamArray, ParamMods, null, null);
                aint_appcode = Convert.ToInt32(ParamArray[0]);
                astr_appmsg = ParamArray[1].ToString();
                return o;
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        //释放接口
        public object yh_interface_destroy()
        {
            //Com参数封装
            object o = jkType.InvokeMember("yh_interface_destroy", System.Reflection.BindingFlags.InvokeMethod, null, jk,
                                       null);
            return o;
        }
        //接口交易函数
        public object yh_interface_call(string astr_jybh, string astr_jykz_xml, string astr_jysr_xml, ref string astr_pcbh, ref string astr_jylsh,
ref string astr_jyyzm, ref string astr_jysc_xml, ref long aint_appcode, ref string astr_appmsg)
        {
            object[] ParamArray = new object[9];
            ParamArray[0] = astr_jybh;
            ParamArray[1] = astr_jykz_xml;
            ParamArray[2] = astr_jysr_xml;
            ParamArray[3] = string.Empty;
            ParamArray[4] = string.Empty;
            ParamArray[5] = string.Empty;
            ParamArray[6] = string.Empty;
            ParamArray[7] = 0;
            ParamArray[8] = string.Empty;
            //Com参数封装
            ParameterModifier[] ParamMods = new ParameterModifier[1];
            ParamMods[0] = new ParameterModifier(9); // 初始化为接口参数的个数
            ParamMods[0][3] = true; // 设置第4个参数为返回参数
            ParamMods[0][4] = true; // 设置第5个参数为返回参数
            ParamMods[0][5] = true; // 设置第6个参数为返回参数
            ParamMods[0][6] = true; // 设置第7个参数为返回参数
            ParamMods[0][7] = true; // 设置第8个参数为返回参数
            ParamMods[0][8] = true; // 设置第9个参数为返回参数
            object o = jkType.InvokeMember("yh_interface_call", System.Reflection.BindingFlags.InvokeMethod, null, jk,
                                       ParamArray, ParamMods, null, null);
            //获取返回值
            astr_pcbh = ParamArray[3].ToString();
            astr_jylsh = ParamArray[4].ToString();
            astr_jyyzm = ParamArray[5].ToString();
            astr_jysc_xml = ParamArray[6].ToString();
            aint_appcode = Convert.ToInt32(ParamArray[7]);
            astr_appmsg = ParamArray[8].ToString();
            return o;
        }
        //确认交易
        public object yh_interface_confirm(string astr_jylsh, string astr_jyyzm, ref long aint_appcode, ref  string astr_appmsg)
        {
            object[] ParamArray = new object[4];
            ParamArray[0] = astr_jylsh;
            ParamArray[1] = astr_jyyzm;
            ParamArray[2] = string.Empty;
            ParamArray[3] = string.Empty;
            //Com参数封装
            ParameterModifier[] ParamMods = new ParameterModifier[1];
            ParamMods[0] = new ParameterModifier(4); // 初始化为接口参数的个数
            ParamMods[0][2] = true; // 设置第3个参数为返回参数
            ParamMods[0][3] = true; // 设置第4个参数为返回参数
            object o = jkType.InvokeMember("yh_interface_confirm", System.Reflection.BindingFlags.InvokeMethod, null, jk,
                                       ParamArray, ParamMods, null, null);
            aint_appcode = Convert.ToInt32(ParamArray[2]);
            astr_appmsg = ParamArray[3].ToString();
            return o;
        }
        //取消交易
        public object yh_interface_cancel(string astr_jylsh, ref long aint_appcode, ref  string astr_appmsg)
        {
            object[] ParamArray = new object[3];
            ParamArray[0] = astr_jylsh;
            ParamArray[1] = string.Empty;
            ParamArray[2] = string.Empty;
            //Com参数封装
            ParameterModifier[] ParamMods = new ParameterModifier[1];
            ParamMods[0] = new ParameterModifier(3); // 初始化为接口参数的个数
            ParamMods[0][1] = true; // 设置第2个参数为返回参数
            ParamMods[0][2] = true; // 设置第3个参数为返回参数
            object o = jkType.InvokeMember("yh_interface_cancel", System.Reflection.BindingFlags.InvokeMethod, null, jk,
                                       ParamArray, ParamMods, null, null);
            aint_appcode = Convert.ToInt32(ParamArray[1]);
            astr_appmsg = ParamArray[2].ToString();
            return o;
        }
        //不确认交易查询
        public object yh_interface_getuncertaintytrade(string astr_jylsh, ref string astr_jgxml, ref long aint_appcode, ref  string astr_appmsg)
        {
            object[] ParamArray = new object[4];
            ParamArray[0] = astr_jylsh;
            ParamArray[1] = string.Empty;
            ParamArray[2] = string.Empty;
            ParamArray[3] = string.Empty;
            //Com参数封装
            ParameterModifier[] ParamMods = new ParameterModifier[1];
            ParamMods[0] = new ParameterModifier(4); // 初始化为接口参数的个数
            ParamMods[0][1] = true; // 设置第2个参数为返回参数
            ParamMods[0][2] = true; // 设置第3个参数为返回参数
            ParamMods[0][3] = true; // 设置第4个参数为返回参数
            object o = jkType.InvokeMember("yh_interface_confirm", System.Reflection.BindingFlags.InvokeMethod, null, jk,
                                       ParamArray, ParamMods, null, null);
            astr_jgxml = ParamArray[1].ToString();
            aint_appcode = Convert.ToInt32(ParamArray[2]);
            astr_appmsg = ParamArray[3].ToString();
            return o;
        }
        #endregion
    }
    #endregion
    #region  接口API(封装)
    public static class JK_API
    {
        #region  交易中产生的成员变量
        public static bool gb接口已初始化成功;
        public static bool gb签到成功;
        //本次交易的流水号和验证码
        public static string gs签到流水号;
        //私有变量
        private static YH jk;
        private static int vn计数器;
        #endregion
        #region  初始化
        public static bool Do接口初始化(ref string vs错误信息)
        {
            long vi执行结果 = -1;
            try
            {
                jk = new YH();
                jk.yh_interface_init(ref vi执行结果, ref vs错误信息);
                basComm.WriteLog("【(yh_interface_init)交易后】交易标志:" + vi执行结果 + "\r\n交易返回消息：" + vs错误信息);
                return gb接口已初始化成功 = vi执行结果 >= 0;//大于等于0时交易成功，其他均为失败。此值数据类型是整数，范围为-2147483648 to +2147483647
            }
            catch (Exception err)
            {
                vs错误信息 = "【接口初始化抛出异常】:" + err.Message;
                basComm.WriteLog(vs错误信息);
                return false;
            }
        }
        #endregion
        #region  医保交易
        //输出 中心交易流水号^联脱机标志^输出参数^
        public static bool Do进行医保交易(string vs业务编号, string vs交易控制XML, string vs交易输入XML, ref string vs批次编号, ref string vs交易流水号, ref string vs交易验证码, ref string vs交易输出XML, ref string vs错误信息,bool vb判断交易标志=true)
        {
            vs业务编号 = vs业务编号.Trim();
            if (gb签到成功 || vs业务编号.Equals("05") || vs业务编号.Equals("06") || vs业务编号.Equals("08"))//签到交易
            {
                long vi执行结果 = -1;
                try
                {
                    vs业务编号 = vs业务编号.Trim();
                    vs交易控制XML = vs交易控制XML.Trim();
                    vs交易输入XML = vs交易输入XML.Trim();
                    basComm.WriteLog(string.Format("【(yh_interface_call)交易前】交易编号:{0}\r\n交易控制XML:", vs业务编号) + vs交易控制XML + "\r\n交易输入XML:" + vs交易输入XML);
                    jk.yh_interface_call(vs业务编号, vs交易控制XML, vs交易输入XML, ref vs批次编号, ref vs交易流水号, ref vs交易验证码,
                                         ref vs交易输出XML, ref vi执行结果, ref vs错误信息);
                    basComm.WriteLog(string.Format("【(yh_interface_call)交易后】交易编号:{0}\r\n批次编号:", vs业务编号) + vs批次编号 + "\r\n交易标志:" + vi执行结果 + "\r\n交易流水号:" + vs交易流水号 + "\r\n交易验证码:" + vs交易验证码 + "\r\n交易返回消息:" + vs错误信息 + "\r\n交易输出XML:" + vs交易输出XML);
                    if (!string.IsNullOrEmpty(vs交易输出XML))
                    {
                        vs错误信息 = "医保交易返回了空参数，可能是医保中心交易处理出错了!";
                        return false;
                    }else if(vb判断交易标志&&vi执行结果<0)
                    {
                        vs错误信息 = string.Format("医保交易返回失败标志[交易标志:{0}]!",vi执行结果);
                        return false;
                    }
                    //交易成功
                    return true;
                }
                catch (Exception err)
                {
                    vs错误信息 = "【医保交易抛出异常】:" + err.Message;
                    basComm.WriteLog(vs错误信息);
                    return false;
                }
            }
            else
            {
                vs错误信息 = "签到操作失败，不能进行医保交易！";
                return false;
            }
        }
        #endregion
        #region 确认交易
        public static bool Do确认交易(string vs交易流水号, string vs交易验证码, ref string vs错误信息)
        {
            try
            {
                long vi执行结果 = -1;
                basComm.WriteLog("【(yh_interface_confirm)交易前】交易流水号:" + vs交易流水号 + "\r\n交易验证码:" + vs交易验证码);
                jk.yh_interface_confirm(vs交易流水号, vs交易验证码, ref vi执行结果, ref vs错误信息);
                basComm.WriteLog("【(yh_interface_confirm)交易后】交易标志:" + vi执行结果 + "\r\n交易返回消息:" + vs错误信息);
                return true;
            }
            catch (Exception err)
            {
                vs错误信息 = err.Message;
                return false;
            }
        }

        #endregion
        #region 取消交易
        public static bool Do取消交易(string vs交易流水号, ref string vs错误信息)
        {
            try
            {
                long vi执行结果 = -1;
                basComm.WriteLog("【(yh_interface_cancel)交易前】交易流水号:" + vs交易流水号);
                jk.yh_interface_cancel(vs交易流水号, ref vi执行结果, ref vs错误信息);
                basComm.WriteLog("【(yh_interface_cancel)交易后】交易标志:" + vi执行结果 + "\r\n交易返回消息:" + vs错误信息);
                return true;
            }
            catch (Exception err)
            {
                vs错误信息 = err.Message;
                return false;
            }
        }

        #endregion
        #region 不确定交易查询
        public static bool Do不确定交易查询(string vs交易编号, ref string vs交易输出XML, ref string vs错误信息)
        {
            try
            {
                if (gb接口已初始化成功)
                {
                    long vi执行结果 = -1;
                    basComm.WriteLog("【(yh_interface_getuncertaintytrade)交易前】交易编号:" + vs交易编号);
                    jk.yh_interface_getuncertaintytrade(vs交易编号, ref vs交易输出XML, ref vi执行结果, ref vs错误信息);
                    basComm.WriteLog("【(yh_interface_getuncertaintytrade)交易后】交易标志:" + vi执行结果 + "\r\n交易返回消息:" + vs错误信息 +
                                     "\r\n交易输出XML:" + vs交易输出XML);
                    return vi执行结果 >= 0; //大于等于0时交易成功，其他均为失败。此值数据类型是整数，范围为-2147483648 to +2147483647
                }
                else
                {
                    vs错误信息 = "接口没有初始化成功，不能进行交易！";
                    return false;
                }
            }
            catch (Exception err)
            {
                vs错误信息 = err.Message;
                return false;
            }
        }

        #endregion
        //扩展函数
        #region  医保读卡交易
        public static Card Do刷卡(string vs支付类别 = "0201")
        {
            Card card = null;
            if (gb签到成功)
            {
                try
                {
                    string s交易控制XML = baseData.basData.gsXML头 + "<control><edition>"+baseData.basData.gs银海版本号+"</edition></control>";
                    string s交易输入XML = baseData.basData.gsXML头 + "<data></data>";
                    string s交易批次号 = string.Empty;
                    string s交易流水号 = string.Empty;
                    string s交易验证码 = string.Empty;
                    string s错误信息 = string.Empty;
                    string s交易输出XML = string.Empty;
                    bool bOK = Do进行医保交易("03", s交易控制XML, s交易输入XML, ref s交易批次号, ref s交易流水号, ref s交易验证码,
                                               ref s交易输出XML, ref s错误信息);
                    if (bOK)
                    {
                        card = new Card();
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(s交易输出XML);
                        XmlNode root = xmlDoc.SelectSingleNode("output");
                        if (root != null)
                        {
                            string s个人编号 = root.SelectSingleNode("aac001").InnerText;
                            card.fs个人编号 = s个人编号;
                            card.fs身份证号 = root.SelectSingleNode("aac002").InnerText;
                            card.fs姓名 = root.SelectSingleNode("aac003").InnerText;
                            card.fs性别 = root.SelectSingleNode("aac004").InnerText;
                            card.fs出生日期 = root.SelectSingleNode("aac006").InnerText;
                            card.fs实足年龄 = root.SelectSingleNode("akc023").InnerText;
                            card.fs医疗人员类别 = root.SelectSingleNode("akc021").InnerText;
                            card.fs公务员类别 = root.SelectSingleNode("ykc117").InnerText;
                            card.fs个人帐户XML = root.SelectSingleNode("grzhye").OuterXml;
                            card.fs社保经办机构 = root.SelectSingleNode("yab003").InnerText;
                            card.fs其他说明 = root.SelectSingleNode("aae013").InnerText;
                            card.fs参保人所在单位编号 = root.SelectSingleNode("aab001").InnerText;
                            card.fs单位名称 = root.SelectSingleNode("aab004").InnerText;
                            card.fs工伤人员信息XML = root.SelectSingleNode("gsdataset").OuterXml;
                            card.fs离休人员信息XML = root.SelectSingleNode("lxdataset").OuterXml;
                            card.CS刷卡信息 = s交易输出XML;
                            card.CB个人账户可支付 = Do查询个人账户是否可支付(s个人编号, vs支付类别);
                            return card;
                        }
                        else
                        {
                            basComm.MsgError("解析根节点出错，请检查返回XML是否正确！");
                            return null;
                        }
                    }
                    else
                    {
                        basComm.MsgError(s错误信息);
                        return null;
                    }
                }
                catch (Exception err)
                {
                    string vs错误信息 = "【刷卡发生异常】:" + err.Message;
                    basComm.WriteLog(vs错误信息);
                    basComm.MsgError(vs错误信息);
                    return null;
                }
            }
            else
            {
                basComm.MsgError("签到操作失败，不能进行医保交易！");
                return null;
            }
        }
        private static bool Do查询个人账户是否可支付(string s个人编号, string vs支付类别)
        {
            try
            {
                string s交易控制XML = baseData.basData.gsXML头 + string.Format("<control><aac001>{0}</aac001><yab003>{1}</yab003><aka130>{2}</aka130></control>", s个人编号, baseData.basData.gs社保经办机构编码,vs支付类别);
                string s交易输入XML = baseData.basData.gsXML头 + "<data></data>";
                string s交易批次号 = string.Empty;
                string s交易流水号 = string.Empty;
                string s交易验证码 = string.Empty;
                string s错误信息 = string.Empty;
                string s交易输出XML = string.Empty;
                return Do进行医保交易("13", s交易控制XML, s交易输入XML, ref s交易批次号, ref s交易流水号, ref s交易验证码,
                                           ref s交易输出XML, ref s错误信息);
            }
            catch (Exception err)
            {
                basComm.WriteLog("【查询个人账户是否可支付发生异常】：" + err.Message);
                return false;
            }
        }

        #endregion
        #region 签到
        public static string Do签到()
        {
            string s签到错误信息 = string.Empty;

            #region 判断该操作员是否上一次登陆未作签退操作

            string sSQL = @"select 批次编号 FROM INF_DCDSYB_签到签退表 where (隶属机构I='{0}') And (isnull(签退时间,'')='') and 经办人序号='{1}'";
            sSQL = string.Format(sSQL,baseData.basData.pInt隶属机构编号, baseData.basData.pInt操作员编号);
            string s未签退业务周期号 = DB.ExecSingle(sSQL).Trim();
            if (!string.IsNullOrEmpty(s未签退业务周期号))
            {
                basComm.MsgError("系统检测到您上一次登陆未作签退操作，现在进行补签!");
                string s失败信息 = Do签退(s未签退业务周期号);
                if (!string.IsNullOrEmpty(s失败信息))
                {
                    s签到错误信息 = "[补签退失败，请联系九阵公司客服部]:" + s失败信息;
                    return s签到错误信息;
                }
            }

            #endregion

            #region 签到操作

            F签到签退 f = new F签到签退(1);
            long viResult = ABegin.Fun.ShowForm(f);
            if (viResult==1)
            {
                s签到错误信息 = f.fs错误信息;
            }
            else
            {
                s签到错误信息 = "用户取消了交易！";
            }

            #endregion

            return s签到错误信息;
        }

        #endregion
        #region 签退
        public static string Do签退(string vs业务周期号 = "")
        {
            string s签到错误信息 = string.Empty;
            try
            {
                F签到签退 f = new F签到签退(2, vs业务周期号);
                long viResult = ABegin.Fun.ShowForm(f);
                if (viResult==1)
                {
                    s签到错误信息 = f.fs错误信息;
                }
                else
                {
                    s签到错误信息 = "用户取消了交易！";
                }
            }
            catch (Exception err)
            {
                s签到错误信息 = err.Message;
            }
            return s签到错误信息;
        }

        #endregion
        #region 患者就诊登记号:为空表示自费患者
        public static string Get患者就诊登记号(string vs住院序号)
        {
            string s就诊登记号 = string.Empty;
            //查询
            string sSQL =
                @"select 就诊登记号,支付类别,个人编号 from INF_DCDSYB_入院登记表 where 住院序号='{0}' and (nvl(作废,'0')='0' And nvl(已出院,'0')='0')";
            sSQL = string.Format(sSQL, vs住院序号);
            IRecordSet rs = DB.ExecSQL(sSQL);
            if (!rs.IsEof())
            {
                s就诊登记号 = rs.GetValue("就诊登记号").ToString().Trim();
                rs.Close();
            }
            //为空表示自费
            return s就诊登记号;
        }

        #endregion
    }
    #endregion
    #region  卡信息类

    public class Card
    {
        public string fs个人编号 = string.Empty;
        public string fs身份证号 = string.Empty;
        public string fs姓名 = string.Empty;
        public string fs性别 = string.Empty;
        public string fs民族 = string.Empty;
        public string fs出生日期 = string.Empty;
        public string fs实足年龄 = string.Empty;
        public string fs医疗人员类别 = string.Empty;
        public string fs公务员类别 = string.Empty;
        public string fs个人帐户XML = string.Empty;
        public string fs社保经办机构 = string.Empty;
        public string fs其他说明 = string.Empty;
        public string fs参保人所在单位编号 = string.Empty;
        public string fs单位名称 = string.Empty;
        public string fs工伤人员信息XML = string.Empty;
        public string fs离休人员信息XML = string.Empty;
        public string CS刷卡信息 = string.Empty;
        public bool CB个人账户可支付 = false;
    }
    #endregion
}
