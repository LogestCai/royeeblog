using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AHC_InterFace;

namespace IF_P工伤医保.baseComm
{
    public static class DB
    {
        /// <summary>
        /// 执行一个List中的SQL语句，使用事物执行
        /// </summary>
        /// <param name="listSQL">List中的SQL语句</param>
        /// <param name="vbIgnoreAffected">是否需要影响行数>0才提交</param>
        /// <returns></returns>

        public static int ExecListCmd(List<string> listSQL, bool vbTran = true)
        {
            try
            {
                int Index = 0;
                List<ISQL> list = new List<ISQL>();
                foreach (var vSql in listSQL)
                {
                    if (Index > 0 && Index % 1000 == 0)
                    {
                        AHC_InterFace.AHC_InterFace.ExecCmd_Batch(list.ToArray(), vbTran);
                        list.Clear();
                    }
                    //添加
                    ISQL sql = new ISQL(vSql, 0);
                    list.Add(sql);
                    Index++;
                }
                //临头
                if (list.Count > 0) { AHC_InterFace.AHC_InterFace.ExecCmd_Batch(list.ToArray(), vbTran); }
                return 1;
            }
            catch (Exception err)
            {
                string sMsg = "[ExecListCmd异常]:" + err.Message;
                basComm.WriteLog(sMsg);
                throw new Exception(sMsg);
            }
        }

        //执行脚本

        /// <summary>
        /// 执行一条Update、Insert、Delete语句,执行完毕后返回影响行数
        /// </summary>
        /// <param name="vsSqlText">要执行的T-SQL语句</param>
        /// <param name="sqlPara">T-SQL语句的附加参数</param>
        /// <returns>执行成功后的影响行数</returns>
        public static int ExecCmd(string vsSqlText, ISQLPara sqlPara = null)
        {
            basComm.WriteLog(vsSqlText);
            return AHC_InterFace.AHC_InterFace.ExecCmd(vsSqlText, sqlPara);
        }
        /// <summary>
        /// 执行一条Select语句,返回查询后的首行首列值
        /// </summary>
        /// <param name="vsSqlText">要执行的T-SQL语句</param>
        /// <param name="sqlPara">T-SQL语句的附加参数</param>
        /// <returns>查询成功后返回的首行首列值</returns>
        public static string ExecSingle(string vsSqlText, ISQLPara sqlPara = null)
        {
            return AHC_InterFace.AHC_InterFace.ExecSingle(vsSqlText, sqlPara);
        }
        /// <summary>
        /// 执行一条Select语句,返回查询成功后的结果集
        /// </summary>
        /// <param name="vsSqlText">要执行的T-SQL语句</param>
        /// <param name="sqlPara">T-SQL语句的附加参数</param>
        /// <returns>查询成功后返回的结果集对象</returns>
        public static IRecordSet ExecSQL(string vsSqlText, ISQLPara sqlPara = null)
        {
            return AHC_InterFace.AHC_InterFace.ExecSQL(vsSqlText, sqlPara);
        }
        /// <summary>
        ///  执行一条Select语句,返回查询成功后的DataTable
        /// </summary>
        /// <param name="vsSqlText">要执行的T-SQL语句</param>
        /// <param name="sqlPara">T-SQL语句的附加参数</param>
        /// <returns>查询成功后返回的结果DataTable对象</returns>
        public static DataTable ExecuteDataTable(string vsSqlText, ISQLPara sqlPara = null)
        {
            DataTable dt = new DataTable();
            IRecordSet rs = AHC_InterFace.AHC_InterFace.ExecSQL(vsSqlText, sqlPara);
            if (rs != null)
            {
                //获得列信息
                for (int i = 0; i < rs.GetColCount(); i++)
                {
                    dt.Columns.Add(rs.GetFieldName(i));
                }
                //填充数据
                while (!rs.IsEof())
                {
                    System.Data.DataRow dr = dt.NewRow();
                    for (int i = 0; i < rs.GetColCount(); i++)
                    {
                        dr[i] = rs.GetValue(i);
                    }
                    dt.Rows.Add(dr); //添加一行
                    rs.MoveNext();
                }
                rs.Close();
            }
            return dt;
        }

        /// <summary>
        /// 执行一条Select语句,返回是否查询到满足条件的数据
        /// </summary>
        /// <param name="vsSqlText">要执行的T-SQL语句</param>
        /// <param name="sqlPara">T-SQL语句的附加参数</param>
        /// <returns>true:查询有数据,false:查询无数据</returns>
        public static bool ExecSQLExist(string vsSqlText, ISQLPara sqlPara = null)
        {
            return AHC_InterFace.AHC_InterFace.ExecSQLExist(vsSqlText, sqlPara);
        }
        /// <summary>
        /// 执行一条更新语句,用于更新数据类型为NCLOB类型的oracle字段,每次只能更新一列值
        /// </summary>
        /// <param name="vsSqlText">要执行的T-SQL语句,格式 select 列 from 表 for update where 条件=条件值</param>
        /// <param name="vsValue">要保存的数据值</param>
        public static void UpdateCLOB(string vsSqlText, string vsValue)
        {
            AHC_InterFace.AHC_InterFace.UpdateCLOB(vsSqlText, vsValue);
        }
        /// <summary>
        /// 使用XML进行一组数据的保存,支持存储过程,具体调用可参见AHC组件文档
        /// </summary>
        /// <param name="vsSQLText">要保存的XML文本,具体格式参见AHC组件文档</param>
        /// <param name="vs单据序号">当前数据保存后,返回的主表系统序号</param>
        /// <param name="vbAutoTran">在保存的过程中是否开启事务</param>
        /// <returns>执行保存后返回的参数结果</returns>
        public static ISQLPara CallDB(string vsSQLText, ref string vs单据序号, bool vbAutoTran = true)
        {
            return AHC_InterFace.AHC_InterFace.CallDB(vsSQLText, ref vs单据序号, vbAutoTran);
        }

        public static DataTable ToDataTable(DataRow[] rows)
        {
            if (rows == null || rows.Length == 0) return new DataTable();
            DataTable dtTmp = rows[0].Table.Clone();// 复制DataRow的表结构
            foreach (DataRow dataRow in rows)
            {
                dtTmp.Rows.Add(dataRow.ItemArray);
            }
            //释放之前的datatable
            return dtTmp;
        }
        /// <summary>
        /// 根据sql语句获取返回结果  返回值为布尔类型  
        /// </summary>
        /// <param name="rs"></param>
        /// <param name="vsSqlText"></param>
        /// <param name="sqlPara"></param>
        /// <returns></returns>
        public static bool ExecSQLResult(ref IRecordSet rs, string vsSqlText, ISQLPara sqlPara = null)
        {
            if (ExecSQLExist(vsSqlText, sqlPara))
            {
                rs = ExecSQL(vsSqlText, sqlPara);
                return true;
            }
            else 
            {
                rs = null;
                return false;
            }            
        }
    }
}
