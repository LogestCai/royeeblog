using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IF_P工伤医保.MyCode
{
    /******************************************************** 
    * 项目名称： CardHSSFZ.cs
    * 命名空间 ： IF_P工伤医保.MyCode
    * 类 名 称 ： CardHSSFZ
    * 作   者  ： RoyeeCai
    * 邮   箱  ： caimh0223@163.com
    * 概   述  ： 
    * 创建时间 ： 2021-10-07 09:57:47
    * 更新时间 ： 2021-10-07 09:57:47
    * CLR版本  ： 4.0.30319.42000
    * ******************************************************
    * Copyright@RoyeeCai 2021 .All rights reserved.
    * ******************************************************
    */
    public class CardHSSFZ
    {
        [DllImport("Termb.dll", EntryPoint = "CVR_SetBaudRate", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int CVR_SetComBaudrate(int nBaudRate);//声明外部的标准动态库, 跟Win32API是一样的,设置波特率

        [DllImport("Termb.dll", EntryPoint = "CVR_InitComm", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int CVR_InitComm(int Port);//声明外部的标准动态库, 跟Win32API是一样的


        [DllImport("Termb.dll", EntryPoint = "CVR_Authenticate", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int CVR_Authenticate();


        [DllImport("Termb.dll", EntryPoint = "CVR_Read_Content", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int CVR_Read_Content(int Active);


        [DllImport("Termb.dll", EntryPoint = "CVR_Read_FPContent", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int CVR_Read_FPContent();

        [DllImport("Termb.dll", EntryPoint = "CVR_FindCard", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int CVR_FindCard();

        [DllImport("Termb.dll", EntryPoint = "CVR_SelectCard", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int CVR_SelectCard();


        [DllImport("Termb.dll", EntryPoint = "CVR_CloseComm", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int CVR_CloseComm();

        [DllImport("Termb.dll", EntryPoint = "GetCertType", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern  int GetCertType(ref byte strTmp, ref int strLen);


        [DllImport("Termb.dll", EntryPoint = "GetPeopleName", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern  int GetPeopleName(ref byte strTmp, ref int strLen);


        [DllImport("Termb.dll", EntryPoint = "GetPeopleChineseName", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern  int GetPeopleChineseName(ref byte strTmp, ref int strLen);


        [DllImport("Termb.dll", EntryPoint = "GetPeopleNation", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int GetPeopleNation(ref byte strTmp, ref int strLen);


        [DllImport("Termb.dll", EntryPoint = "GetNationCode", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int GetNationCode(ref byte strTmp, ref int strLen);


        [DllImport("Termb.dll", EntryPoint = "GetPeopleBirthday", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleBirthday(ref byte strTmp, ref int strLen);


        [DllImport("Termb.dll", EntryPoint = "GetPeopleAddress", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleAddress(ref byte strTmp, ref int strLen);


        [DllImport("Termb.dll", EntryPoint = "GetPeopleIDCode", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleIDCode(ref byte strTmp, ref int strLen);


        [DllImport("Termb.dll", EntryPoint = "GetDepartment", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetDepartment(ref byte strTmp, ref int strLen);


        [DllImport("Termb.dll", EntryPoint = "GetStartDate", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetStartDate(ref byte strTmp, ref int strLen);


        [DllImport("Termb.dll", EntryPoint = "GetEndDate", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetEndDate(ref byte strTmp, ref int strLen);


        [DllImport("Termb.dll", EntryPoint = "GetPeopleSex", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleSex(ref byte strTmp, ref int strLen);


        //[DllImport("Termb.dll", EntryPoint = "CVR_GetIDCardUID", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        //public static extern int GetIDCardUID(ref byte strTmp, int strLen);

        [DllImport("Termb.dll", EntryPoint = "GetBMPData", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetBMPData(ref byte btBmp, ref int nLen);

        [DllImport("Termb.dll", EntryPoint = "GetJpgData", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetJpgData(ref byte btBmp, ref int nLen);

        [DllImport("Termb.dll", EntryPoint = "M1_MF_HL_Request", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int M1_MF_HL_Request(byte nMode, ref byte pSNR, ref byte pTagType);

        [DllImport("Termb.dll", EntryPoint = "M1_MF_HL_Read", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int M1_MF_HL_Read(byte nMode, uint nSNR, byte nBlock, ref byte nKey, ref byte pReadBuff, uint nBuff);

        [DllImport("Termb.dll", EntryPoint = "M1_MF_HL_Write", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int M1_MF_HL_Write(byte nMode, uint nSNR, byte nBlock, ref byte nKey, ref byte pWriteBuff, uint nBuff);

        static int m_Port = 0; //0 usb端口  1  串口
        static int m_Baudrate = 9600;
        static bool m_ComOpen = false;
        /// <summary>
        ///  华氏crv_uc100读卡器读取身份证功能。
        /// </summary>
        /// <param name="sOutInfo"></param>
        /// <returns></returns>
        public static int iReadSFZ_HS(ref string  sOutInfo)
        {
            // 如果没有初始化成功则退出。
            if (!initSFZ_HS(ref sOutInfo)) return -3;
            try
            {
                int authenticate = CVR_Authenticate();
                if (authenticate == 1)
                {
                    int readContent = CVR_Read_Content(4);
                    if (readContent == 1)
                    {
                        ///读卡成功获取数据 
                        int length;
                        // 照片保存在当前目录
                        string s文件夹路径 = AppDomain.CurrentDomain.BaseDirectory;
                        String szXPPath = s文件夹路径+"\\zp.bmp";
                        System.Drawing.Image img = System.Drawing.Image.FromFile(szXPPath);
                        System.Drawing.Image bmp = new System.Drawing.Bitmap(img);
                        img.Dispose();
                        //pictureBoxPhoto.Image = bmp;
                        //身份证号
                        byte[] number = new byte[128];
                        length = 128;
                        GetPeopleIDCode(ref number[0], ref length);
                        //姓名
                        byte[] name = new byte[128];
                        length = 128;
                        GetPeopleName(ref name[0], ref length);
                        //性别
                        byte[] sex = new byte[128];
                        length = 128;
                        GetPeopleSex(ref sex[0], ref length);
                        sOutInfo = System.Text.Encoding.GetEncoding("GB2312").GetString(number).Replace("\0", "").Trim();
                        sOutInfo += "|" + System.Text.Encoding.GetEncoding("GB2312").GetString(name);
                        sOutInfo += "|" + System.Text.Encoding.GetEncoding("GB2312").GetString(sex).Replace("\0", "").Trim();
                        return 0;
                       
                    }
                    else
                    {
                        sOutInfo =  "读卡操作失败！";
                        return -1;
                    }
                }
                else
                {
                    sOutInfo = "未放卡或卡片放置不正确";
                    return -2;
                }
            }
            catch (Exception ex)
            {
                sOutInfo = ex.ToString();
                return -5;
            }
        }
        /// <summary>
        /// 华氏crv_uc100读卡器初始化
        /// </summary>
        /// <param name="mess"></param>
        /// <returns></returns>
        public static bool initSFZ_HS(ref string mess)
        {
            if (m_ComOpen) 
            {
                mess = "连接成功！";
                return true;
            
            }
            else
            {
                CVR_SetComBaudrate(m_Baudrate);// 设置波特率
                if (0 == m_Port)    //usb
                {
                    for (int i = 1001; i <= 1016; i++)
                    {
                        if (1 == CVR_InitComm(i))
                        {
                            m_ComOpen = true;
                            m_Port = i;
                            break;
                        }
                    }
                }
                else if (CVR_InitComm(m_Port) == 1)  //UART
                {
                    m_ComOpen = true;
                }

                if (!m_ComOpen)
                {
                    mess = "连接失败！";
                    CVR_CloseComm();
                    return false;
                }
                else
                {
                    mess = "连接成功！";
                    return true;
                }
            }
        }
    }
}
