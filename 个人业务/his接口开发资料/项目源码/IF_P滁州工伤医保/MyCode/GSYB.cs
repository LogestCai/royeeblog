using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Reflection;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using IF_P工伤医保.baseData;
using IF_P工伤医保.baseComm;
using IF_P工伤医保.baseForm;
using System.Windows.Forms;

namespace IF_P工伤医保.MyCode
{
    /******************************************************** 
    * 项目名称： GSYB.cs
    * 命名空间 ： IF_P工伤医保.MyCode
    * 类 名 称 ： GSYB
    * 作   者  ： RoyeeCai
    * 邮   箱  ： caimh0223@163.com
    * 概   述  ： 
    * 创建时间 ： 2021-12-10 16:33:19
    * 更新时间 ： 2021-12-10 16:33:19
    * CLR版本  ： 4.0.30319.42000
    * ******************************************************
    * Copyright@RoyeeCai 2021 .All rights reserved.
    * ******************************************************
    */
    public static class GSYB
    {
        //封装统一请求函数
        public static bool sendRequest(string s方法名,string s传入参数, ref string s输出参数,ref string sHIS交易号,string s注册码="" ) 
        {          
            try{
                //string url = "http://10.88.20.67:6317/Capricorn/services/Mh3cservice?wsdl";// webservices 地址
               // string s方法 = "pipInvoke";//入口函数  
                string s工伤报销地址 = basData.gs工伤保险url;
                sHIS交易号 =string.IsNullOrEmpty(sHIS交易号)? DateTime.Now.ToString("yyyyMMddHHmmss") + Tools.Do获取随机字符串(4):sHIS交易号;
                basComm.WriteLog("====================交易【" + s方法名 + "】开始====================");
                basComm.WriteLog("交易地址为：【"+s工伤报销地址+"】");
                basComm.WriteLog("社保机构编号为：【" + basData.gs社保机构编号 + "】");
                basComm.WriteLog("注册码为：【"+s注册码+"】");
                basComm.WriteLog("his交易号为：【" + sHIS交易号 + "】");
                basComm.WriteLog("传入参数为：【" + s传入参数 + "】");
                basComm.WriteLog("医院编码为：【" + basData.gs医院编码 + "】");
                object[] s输入参数 = new Object[] { basData.gs社保机构编号, s注册码, sHIS交易号, s方法名, s传入参数, basData.gs医院编码 };

                if (requestWebservice(s工伤报销地址, s输入参数, ref s输出参数))
                {
                    basComm.WriteLog("交易输出为：" + s输出参数);
                    basComm.WriteLog("====================交易【" + s方法名 + "】结束====================");
                    return true;
                }
                else {
                    s输出参数 = "调用接口失败！"+s输出参数;
                    basComm.WriteLog("交易输出为：" + s输出参数);
                    basComm.WriteLog("====================交易【" + s方法名 + "】结束====================");
                    return false;
                }
                
            }catch(Exception e){
                basComm.WriteLog("交易【"+s方法名+"】出现异常。"+e.Message);
                s输出参数=e.Message;
                return false;
            }
            
            
        }

        /// <summary>
        /// webservices 统一请求函数封装
        /// </summary>
        /// <param name="s地址"></param>
        /// <param name="s输入参数"></param>
        /// <param name="s输出参数"></param>
        /// <param name="s方法"></param>
        /// <returns></returns>
        public static bool requestWebservice(string s地址, object[] s输入参数, ref string s输出参数, string s方法 = "pipInvoke")
        {
            try 
            {
                // 1. 使用 WebClient 下载 WSDL 信息。
                WebClient web = new WebClient();
                Stream stream = web.OpenRead(s地址);

                // 2. 创建和格式化 WSDL 文档。
                ServiceDescription description = ServiceDescription.Read(stream);

                // 3. 创建客户端代理代理类。
                ServiceDescriptionImporter importer = new ServiceDescriptionImporter();

                importer.ProtocolName = "Soap"; // 指定访问协议。
                importer.Style = ServiceDescriptionImportStyle.Client; // 生成客户端代理。
                importer.CodeGenerationOptions = CodeGenerationOptions.GenerateProperties | CodeGenerationOptions.GenerateNewAsync;

                importer.AddServiceDescription(description, null, null); // 添加 WSDL 文档。

                // 4. 使用 CodeDom 编译客户端代理类。
                CodeNamespace nmspace = new CodeNamespace(); // 为代理类添加命名空间，缺省为全局空间。
                CodeCompileUnit unit = new CodeCompileUnit();
                unit.Namespaces.Add(nmspace);

                ServiceDescriptionImportWarnings warning = importer.Import(nmspace, unit);
                CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

                CompilerParameters parameter = new CompilerParameters();
                parameter.GenerateExecutable = false;
                parameter.GenerateInMemory = true;
                parameter.ReferencedAssemblies.Add("System.dll");
                parameter.ReferencedAssemblies.Add("System.XML.dll");
                parameter.ReferencedAssemblies.Add("System.Web.Services.dll");
                parameter.ReferencedAssemblies.Add("System.Data.dll");
                CompilerResults result = provider.CompileAssemblyFromDom(parameter, unit);

                // 5. 使用 Reflection 调用 WebService。
                if (!result.Errors.HasErrors)
                {
                    Assembly asm = result.CompiledAssembly;
                    Type t = asm.GetType("Mh3cservice"); // 如果在前面为代理类添加了命名空间，此处需要将命名空间添加到类型前面。类的名称 【Mh3cservice】
                    object objInstence = Activator.CreateInstance(t);
                    #region 方法一直接调用对应函数

                    MethodInfo method = t.GetMethod(s方法);//调用的方法名称【pipInvoke】
                    //ParameterInfo[] rre = method.GetParameters();//获得当前函数的 参数信息可以打断点查看下对应参数信息
                    //Object[] paras = new Object[] { "34112201", "", "215454884518", "query_gsdjxx", "{\"p_grbh\":\"341125199010235974\"}", "221003" };
                    //object args = JObject.Parse("{\"sbjgbh\":\"34112201\",\"zcm\":\"\",\"hisjyh\":\"215454884518\",\"method\":\"query_gsdjxx\",\"jsonPara\":{\"p_grbh\":\"341125199010235974\"},\"yybm\":\"221003\"}");
                    object rest = method.Invoke(objInstence, s输入参数);
                    s输出参数 = rest.ToString();
                    JObject jo = (JObject)JsonConvert.DeserializeObject(s输出参数);
                    JObject jotrade = JObject.Parse(jo["traderesult"].ToString());
                    if (!jotrade["resultcode"].ToString().Equals("0")) //成功返回0 不成功返回小于0
                    {
                        //s输出参数 = jotrade["resulttext"].ToString() + "。错误码为：" + jotrade["resultcode"].ToString();
                        return false;
                    }
                    return true;

                    #endregion

                    #region 方法二遍历所以方法并匹配参数 测试可用
                    //MethodInfo[] info = t.GetMethods();
                    //for (int i = 0; i < info.Length; i++)
                    //{
                    //    var md = info[i];
                    //    string methodName = "pipInvoke";
                    //    //方法名
                    //    string mothodName = md.Name;
                    //    //参数集合
                    //    ParameterInfo[] paramInfos = md.GetParameters();
                    //    //方法名相同且参数个数一样
                    //    if (mothodName == methodName && paramInfos.Length == paras.Length)
                    //    {
                    //        md.Invoke(objInstence, paras);
                    //    }
                    //} 
                    #endregion

                }
                else
                {
                    s输出参数 = "调用请求失败！请联系管理员";
                    return false;
                }
            }catch(Exception ex)
            {
                s输出参数 = ex.Message;
                return false;
            }
            
        }


        


    }
}
