using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Runtime.InteropServices;
using IF_P工伤医保.baseComm;
using System.Reflection;
namespace IF_P工伤医保.MyCode
{
    public struct YbBT //医保业务类型
    {
        public static readonly string 挂号 = "01101";
        public static readonly string 住院建档 = "01102";
        public static readonly string 入院登记 = "01103";
        public static readonly string 缴纳预缴金 = "01104";
        public static readonly string 问诊 = "01201";
        public static readonly string 预约检查 = "01202";
        public static readonly string 检查 = "01203";
        public static readonly string 治疗 = "01204";
        public static readonly string 结算 = "01301";
        public static readonly string 取药 = "01302";
        public static readonly string 取报告 = "01303";
        public static readonly string 打印票据和清单 = "01304";
        public static readonly string 病历材料复印 = "01305";
        public static readonly string 药店购药 = "02121";
        public static readonly string 下载外购处方 = "02122";
        public static readonly string 医疗类APP线上身份认证 = "03131";
        public static readonly string 医疗类APP线上结算 = "03132";

    }
    public static class Tools
    {
        //[System.Runtime.InteropServices.DllImport("SSCardDriver_DC.DLL")] //, EntryPoint = "InitDLL"       
        [DllImport("SSCardDriver.DLL")] //, EntryPoint = "InitDLL"
        static extern int iReadCardBas(int iType, StringBuilder pOutInfo);
        //[System.Runtime.InteropServices.DllImport("SSCardDriver_DC.DLL")] //, EntryPoint = "InitDLL"
        [DllImport("SSCardDriver.DLL")] //, EntryPoint = "InitDLL"
        static extern int iVerifyPIN(int iType, StringBuilder pOutInfo);
        [DllImport("GetSFZInfoDriver_AH.dll")]
        //读取身份证信息
        static extern int iReadSFZ(string imagePath, StringBuilder pOutInfo);
        /// <summary>
        /// 德生四合一读卡器读身份证功能
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="pOutInfo"></param>
        /// <returns></returns>
        public static int iReadSFZ_DS(string imagePath, StringBuilder pOutInfo)
        {
            return iReadSFZ(imagePath,pOutInfo);
        }
        /// <summary>
        /// 德生四合一读卡器读医保卡功能
        /// </summary>
        /// <param name="iType"></param>
        /// <param name="pOutInfo"></param>
        /// <returns></returns>
        public static int iReadYB_DS(int iType, StringBuilder pOutInfo) 
        {
            return iReadCardBas(iType,pOutInfo);
        }
        /// <summary>
        /// 德生四合一读卡器验证医保卡密码功能
        /// </summary>
        /// <param name="iType"></param>
        /// <param name="pOutInfo"></param>
        /// <returns></returns>
        public static int iVerifyPIN_DS(int iType, StringBuilder pOutInfo)
        {
            int res = 10;
            try
            {
                res = iVerifyPIN(iType, pOutInfo);
            }
            catch (Exception Ex)
            {
                //pOutInfo = Ex.Message;
                baseComm.basComm.WriteLog("德生密码验证是失败！。。。" + Ex.Message);
            }
            return res;             
        }


            /// <summary>
            /// 压缩成zip
            /// </summary>
            /// <param name="filesPath">d:\</param>
            /// <param name="zipFilePath">d:\a.zip</param>
            private static void CreateZipFile(string filesPath, string zipFilePath)
            {

                if (!Directory.Exists(filesPath))
                {
                    Console.WriteLine("Cannot find directory '{0}'", filesPath);
                    return;
                }

                try
                {
                    string[] filenames = Directory.GetFiles(filesPath);
                    using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFilePath)))
                    {

                        s.SetLevel(9); // 压缩级别 0-9
                        //s.Password = "123"; //Zip压缩文件密码
                        byte[] buffer = new byte[4096]; //缓冲区大小
                        foreach (string file in filenames)
                        {
                            ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                            entry.DateTime = DateTime.Now;
                            s.PutNextEntry(entry);
                            using (FileStream fs = File.OpenRead(file))
                            {
                                int sourceBytes;
                                do
                                {
                                    sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                    s.Write(buffer, 0, sourceBytes);
                                } while (sourceBytes > 0);
                            }
                        }
                        s.Finish();
                        s.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception during processing {0}", ex);
                }
            }
            private static void Do建立压缩文件(string filesPathAndName, string zipFilePathAndName)
            {

                if (!File.Exists(filesPathAndName))
                {
                    Console.WriteLine("Cannot find File '{0}'", filesPathAndName);
                    return;
                }
                try
                {
                    using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFilePathAndName)))
                    {
                        s.SetLevel(9); // 压缩级别 0-9
                        //s.Password = "123"; //Zip压缩文件密码
                        byte[] buffer = new byte[4096]; //缓冲区大小

                        ZipEntry entry = new ZipEntry(Path.GetFileName(filesPathAndName));
                            entry.DateTime = DateTime.Now;
                            s.PutNextEntry(entry);
                            using (FileStream fs = File.OpenRead(filesPathAndName))
                            {
                                int sourceBytes;
                                do
                                {
                                    sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                    s.Write(buffer, 0, sourceBytes);
                                } while (sourceBytes > 0);
                            }
                        s.Finish();
                        s.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception during processing {0}", ex);
                }
            }
        #region 解压
        /// <summary>
        /// 功能：解压zip格式的文件。
        /// </summary>
        /// <param name="zipFilePath">压缩文件路径</param>
        /// <param name="unZipDir">解压文件存放路径,为空时默认与压缩文件同一级目录下，跟压缩文件同名的文件夹</param>
        /// <param name="err">出错信息</param>
        /// <returns>解压是否成功</returns>
        public static bool Do解压文件(string zipFilePath, ref string unZipFile, ref string err)
        {
            err = "";
            if (zipFilePath == string.Empty)
            {
                err = "压缩文件不能为空！";
                return false;
            }
            if (!File.Exists(zipFilePath))
            {
                err = "压缩文件不存在！";
                return false;
            }
            string unZipDir = zipFilePath.Replace(Path.GetFileName(zipFilePath), Path.GetFileNameWithoutExtension(zipFilePath));
            if (!unZipDir.EndsWith("//"))
                unZipDir += "//";
            if (!Directory.Exists(unZipDir))
                Directory.CreateDirectory(unZipDir);

            try
            {
                using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFilePath)))
                {

                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                        string directoryName = Path.GetDirectoryName(theEntry.Name);
                        string fileName = Path.GetFileName(theEntry.Name);
                        if (directoryName.Length > 0)
                        {
                            Directory.CreateDirectory(unZipDir + directoryName);
                        }
                        if (!directoryName.EndsWith("//"))
                            directoryName += "//";
                        if (fileName != String.Empty)
                        {
                            unZipFile = unZipDir + theEntry.Name;
                            using (FileStream streamWriter = File.Create(unZipFile))
                            {
                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);
                                    if (size > 0)
                                    {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }//while
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
            return true;
        }//解压结束
        #endregion
        public static string StringToJson(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '/':
                        sb.Append("\\/");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 生成指定长度的数字字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Do获取随机字符串(int length)
        {
            string result_string = "";
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                result_string += rd.Next(0, 9).ToString();
            }
            return result_string;
        }

        /// <summary>  
        /// 时间戳Timestamp转换成日期  
        /// </summary>  
        /// <param name="timeStamp"></param>  
        /// <returns></returns>  
        public static string Format时间格式(string timeStamp)
        {
            string s结果 = "";
            if (string.IsNullOrEmpty(timeStamp)) { return ""; }
            double timeVal = double.Parse(timeStamp);//createTime为毫秒数
            if (timeVal < 0) { return ""; }
            try {
               s结果 =  DateTime.Parse(DateTime.Now.ToString("1970-01-01 08:00:00")).AddMilliseconds(timeVal).ToString("yyyy-MM-dd HH:mm:ss");
            }catch(Exception ex){
                return "";
            }
            return s结果;
            //返回为时间格式
        }  
        /// <summary>
        /// 获取医保病人类型函数
        /// </summary>
        /// <param name="s参保地医保区划"></param>
        /// <param name="vs医疗类别代码"></param>
        /// <param name="vs险种类型编码"></param>
        /// <returns></returns>
        public static string Get医保业务费别名称(string s参保地医保区划, string vs医疗类别代码, string vs险种类型编码,string vs人员类型编码)
        {
            string s统筹区名称 = "";
            switch (s参保地医保区划)
            {
                case "341199":// 	经办机构	滁州市本级
                    s统筹区名称 = "市";
                    break;
                case "341102":// 	经办机构	琅琊"; 琅玡区
                    s统筹区名称 = "琅琊";
                    break;
                case "341103"://	经办机构	南谯区
                    s统筹区名称 = "南谯";
                    break;
                case "341122"://	经办机构	来安县
                    s统筹区名称 = "来安";
                    break;
                case "341124"://	经办机构	全椒县
                    s统筹区名称 = "全椒";
                    break;
                case "341125":// 	经办机构	定远县
                    s统筹区名称 = "定远";
                    break;
                case "341126"://	经办机构	凤阳县
                    s统筹区名称 = "凤阳";
                    break;
                case "341181"://	经办机构	天长市
                    s统筹区名称 = "天长";
                    break;
                case "341182"://	经办机构	明光市
                    s统筹区名称 = "明光";
                    break;
                default:
                    s统筹区名称 = "异地";
                    break;
            }


            //获取医疗类别名称
            string s医疗类别名称 = DB.ExecSingle("select 名称 from  inf_tahyb_中心字典 where 字典代码='med_type' and 编码='"+vs医疗类别代码+"'");
            if (string.IsNullOrEmpty(s医疗类别名称)) {
                s医疗类别名称 = "未知医疗类别";
            }

            //vs险种类型编码
            string s医疗险种名称 = DB.ExecSingle("select 名称 from  inf_tahyb_中心字典 where 字典代码='insutype' and 编码='" + vs险种类型编码 + "'");
            if (string.IsNullOrEmpty(s医疗险种名称))
            {
                s医疗险种名称 = "未知险种";
            }

            //vs险种类型编码
            string s人员类型名称 = DB.ExecSingle("select 名称 from  inf_tahyb_中心字典 where 字典代码='psn_type' and 编码='" + vs人员类型编码 + "'");
            if (string.IsNullOrEmpty(s人员类型名称))
            {
                s人员类型名称 = "未知人员类型";
            }

            return s统筹区名称+s医疗类别名称 + "-" + s人员类型名称 + "-" + s医疗险种名称;
        }
        /// <summary>
        /// 
        /// 根据健康id获取门诊用户身份证号
        /// </summary>
        /// <param name="s健康id"></param>
        /// <returns></returns>
        public static string Get门诊用户身份证(string s健康id)
        {
            string s身份证号 = "";
            if (string.IsNullOrEmpty(s健康id))
            { return ""; }
            else
            {
                try { s身份证号 = DB.ExecSingle("Select 身份证号 From crm_Vd健康档案 where 健康ID='" + s健康id + "'"); }catch(Exception ex){}
                
            }
            return s身份证号;
        }
      

    }

    public class Card2
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 8)]
        public struct PERSONINFOW
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string name;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
            public string sex;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
            public string nation;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
            public string birthday;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
            public string address;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string cardId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string police;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
            public string validStart;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
            public string validEnd;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
            public string sexCode;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string nationCode;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
            public string appendMsg;
        }
        [DllImport("cardapi3.dll", EntryPoint = "OpenCardReader",
            CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern Int32 OpenCardReader(Int32 lPort, UInt32 ulFlag, UInt32 ulBaudRate);
        [DllImport("cardapi3.dll", EntryPoint = "GetPersonMsgW",
            CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern Int32 GetPersonMsgW(ref PERSONINFOW pInfo, string pszImageFile);
        [DllImport("cardapi3.dll", EntryPoint = "CloseCardReader",
            CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern Int32 CloseCardReader();
        [DllImport("cardapi3.dll", EntryPoint = "GetErrorTextW",
            CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void GetErrorTextW(StringBuilder pszBuffer, UInt32 dwBufLen);
    }
}
