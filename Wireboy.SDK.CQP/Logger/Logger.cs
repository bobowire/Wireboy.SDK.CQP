using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Events;

namespace Wireboy.SDK.CQP
{
    public class Logger : ILogger
    {
        /// <summary>
        /// MySql数据库链接，目前仅支持mysql
        /// </summary>
        MySqlConnection mySqlConnection = new MySqlConnection("[mysql连接字符串]");
        /// <summary>
        /// 写数据库的异步锁
        /// </summary>
        object lock_ExcuteCmd = new object();
        /// <summary>
        /// ExcuteCmd是否正在执行
        /// </summary>
        bool isBuzy_ExcuteCmd = false;
        /// <summary>
        /// ExcuteCmd数据缓存
        /// </summary>
        Dictionary<int, List<string>> sqlDic_ExcuteCmd = new Dictionary<int, List<string>>();
        /// <summary>
        /// ExcuteCmd缓存集合下标
        /// </summary>
        int position_ExcuteCmd = 0;
        public Logger()
        {
            //初始化ExcuteCmd用到的集合
            sqlDic_ExcuteCmd.Add(0, new List<string>());
            sqlDic_ExcuteCmd.Add(1, new List<string>());
        }
        /// <summary>
        /// 记录QQ群聊天数据
        /// </summary>
        /// <param name="groupMsgContext"></param>
        public void GroupMsg(GroupMsgContext groupMsgContext)
        {
            string sql = string.Format("insert into QQGroupLog(Msg,QQ,Time) values('{0}','{1}','{2}');", groupMsgContext.msg, groupMsgContext.fromQQ, DateTime.Now.ToString("yyyyMMddHHmmss"));
            ExcuteCmd(sql);
        }

        /// <summary>
        /// 执行ExecuteNonQuery方法，在多线程同时调用时，最高会有200ms的延迟
        /// </summary>
        /// <param name="sql">要执行的Sql语句</param>
        private void ExcuteCmd(string sql)
        {
            if (!isBuzy_ExcuteCmd)
            {
                lock (lock_ExcuteCmd)
                {
                    if (!isBuzy_ExcuteCmd)
                    {
                        mySqlConnection.Open();
                        do
                        {
                            int curIndex = position_ExcuteCmd;
                            position_ExcuteCmd = curIndex == 1 ? 0 : 1;
                            isBuzy_ExcuteCmd = true;
                            sqlDic_ExcuteCmd[curIndex].Add(sql);
                            string allSql = "";
                            foreach (string csql in sqlDic_ExcuteCmd[curIndex])
                            {
                                allSql = string.Format("{0}{1}", allSql, csql);
                            }
                            sqlDic_ExcuteCmd[curIndex].Clear();
                            MySqlCommand mySqlCommand = new MySqlCommand(allSql, mySqlConnection);
                            mySqlCommand.ExecuteNonQuery();
                            Thread.Sleep(200);
                        }
                        while (sqlDic_ExcuteCmd[position_ExcuteCmd].Count > 0);
                        mySqlConnection.Close();
                        isBuzy_ExcuteCmd = false;
                    }
                    else
                    {
                        sqlDic_ExcuteCmd[position_ExcuteCmd].Add(sql);
                    }
                }
            }
            else
            {
                sqlDic_ExcuteCmd[position_ExcuteCmd].Add(sql);
            }
        }

        ~Logger()
        {
            if (mySqlConnection.State != System.Data.ConnectionState.Closed)
                mySqlConnection.Close();
        }
    }
}
