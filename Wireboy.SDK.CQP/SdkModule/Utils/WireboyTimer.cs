using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP.SdkModule.Utils
{

    public delegate void TimeExcuteFunc();

    public class TimerTask
    {
        public DateTime ExcuteTime { get; set; }
        /// <summary>
        /// 模式（0：一次，1：每周，2：每天，3，每小时
        /// </summary>
        public int Mode { set; get; } = 0;
        public TimeExcuteFunc CallBack { set; get; }
    }

    public class WireboyTimer
    {
        Task m_task = null;
        bool m_isCancel = false;
        TaskFactory m_taskFactory = new TaskFactory();
        List<TimerTask> m_taskList = new List<TimerTask>();
        public void Start()
        {
            m_isCancel = false;
            if (m_task == null)
            {
                m_task = m_taskFactory.StartNew(() =>
                {
                    while (true && !m_isCancel)
                    {
                        List<TimerTask> listFunc = m_taskList.Where(t => MatchTime(t.ExcuteTime, DateTime.Now)).ToList();
                        foreach (TimerTask task in listFunc)
                        {
                            switch (task.Mode)
                            {
                                case 0:
                                    {
                                        m_taskList.Remove(task);
                                    }
                                    break;
                                case 1:
                                    {
                                        task.ExcuteTime = task.ExcuteTime.AddDays(1);
                                    }
                                    break;
                                case 2:
                                    {
                                        task.ExcuteTime = task.ExcuteTime.AddHours(1);
                                    }
                                    break;
                                case 3:
                                    {
                                        task.ExcuteTime = task.ExcuteTime.AddMinutes(1);
                                    }
                                    break;
                            }
                            m_taskFactory.StartNew(() =>
                            {
                                TimerTask _this = task;
                                _this.CallBack();
                            });
                        }
                        Thread.Sleep(1000);
                    }
                    m_task = null;
                });
            }
        }

        public void Stop()
        {
            m_isCancel = true;
        }

        public void AddTask(int minute, bool isRepeat, TimeExcuteFunc callBack)
        {
            DateTime dateTime;
            TimerTask timerTask = new TimerTask();
            timerTask.CallBack = callBack;
            timerTask.Mode = isRepeat ? 3 : 0;
            if (isRepeat)
            {
                dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, minute, 0);
                if (dateTime < DateTime.Now)
                {
                    dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour + 1, minute, 0);
                }
                timerTask.Mode = 3;
            }
            else
            {
                dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, minute, 0);
                timerTask.Mode = 0;
            }
            timerTask.ExcuteTime = dateTime;
        }

        public void AddTask(int hour,int minute,bool isRepeat,TimeExcuteFunc callBack)
        {
            DateTime dateTime;
            TimerTask timerTask = new TimerTask();
            timerTask.CallBack = callBack;
            timerTask.Mode = isRepeat ? 2 : 0;
            if (isRepeat)
            {
                dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, minute, 0);
                if (dateTime < DateTime.Now)
                {
                    dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, DateTime.Now.Hour, minute, 0);
                }
                timerTask.Mode = 2;
            }
            else
            {
                dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, minute, 0);
                timerTask.Mode = 0;
            }
            timerTask.ExcuteTime = dateTime;
        }


        private bool MatchTime(DateTime excuteTime, DateTime curTime)
        {
            if (excuteTime.ToString("yyyyMMddhhmm") == curTime.ToString("yyyyMMddhhmm"))
            {
                return true;
            }
            return false;
        }
    }
}
