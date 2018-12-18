using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Core.Models;
using Wireboy.SDK.CQP.Models;

namespace Wireboy.SDK.CQP.Core
{
    public class JsonUtils
    {
        /// <summary>
        /// 数据流缓存
        /// </summary>
        byte[] _byteData;
        /// <summary>
        /// 数据流当前位置
        /// </summary>
        int _startIndex = 0;
        /// <summary>
        /// 是否读取到末尾
        /// </summary>
        public bool IsLast { get { return _startIndex == _byteData.Length - 1; } }
        public JsonUtils(string jsonData)
        {
            _byteData = Convert.FromBase64String(jsonData);
        }
        public JsonUtils(byte[] jsonData)
        {
            _byteData = jsonData;
        }
        /// <summary>
        /// 解析数组数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newEntityList"></param>
        public void ResolveList<T>(List<T> newEntityList) where T : SdkModelBase
        {
            int listCount =  GetInt32();
            Type elemType = newEntityList.GetType().GetGenericArguments()[0];
            for (int i = 0; i < listCount; i++)
            {
                JsonUtils jsonUtils = new JsonUtils(GetObject());
                var entity = elemType.Assembly.CreateInstance(elemType.FullName);
                T newEntity = entity as T;
                jsonUtils.Resolve(newEntity);
                newEntityList.Add(newEntity);
            }
        }
        /// <summary>
        /// 解析对象数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newEntity"></param>
        public void Resolve<T>(T newEntity)  where T : SdkModelBase
        {
            PropertyInfo[] propertyInfoList = newEntity.GetType().GetProperties().Where(t=>t.GetCustomAttribute<QQJsonAttribute>(true) != null).OrderBy(t=>t.GetCustomAttribute<QQJsonAttribute>().OrderNo).ToArray();
            foreach (PropertyInfo propertyInfo in propertyInfoList)
            {
                //string类型
                if (propertyInfo.PropertyType == typeof(string))
                {
                    propertyInfo.SetValue(newEntity, GetString(Encoding.GetEncoding("GB18030")));
                }
                //short类型
                else if (propertyInfo.PropertyType == typeof(short))
                {
                    propertyInfo.SetValue(newEntity, GetInt16());
                }
                //int类型
                else if (propertyInfo.PropertyType == typeof(int))
                {
                    propertyInfo.SetValue(newEntity, GetInt32());
                }
                //long类型
                else if (propertyInfo.PropertyType == typeof(long))
                {
                    propertyInfo.SetValue(newEntity, GetInt64());
                }
                //bool类型
                else if (propertyInfo.PropertyType == typeof(bool))
                {
                    propertyInfo.SetValue(newEntity, GetByte() == 1 ? true : false);
                }
                //DateTime类型
                else if(propertyInfo.PropertyType == typeof(DateTime))
                {
                    propertyInfo.SetValue(newEntity, GetTime());
                }
                //枚举类型（因为无法判断是否枚举类型，所以放在这里）
                else
                {
                    propertyInfo.SetValue(newEntity, GetInt32());
                }
            }
        }

        /// <summary>
        /// 读取byte类型数据，并后移流位置
        /// </summary>
        /// <returns></returns>
        public byte GetByte()
        {
                return GetBytes(1)[0];
        }
        /// <summary>
        /// 获取short类型数据，并后移流位置
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public short GetInt16(bool flag = true)
        {
            return BitConverter.ToInt16(GetBytes(2, flag), 0);
        }
        /// <summary>
        /// 读取int类型数据，并后移流位置
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public int GetInt32(bool flag = true)
        {
            return BitConverter.ToInt32(GetBytes(4, flag), 0);
        }
        /// <summary>
        /// 读取long类型数据，并后移流位置
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public long GetInt64(bool flag = true)
        {
            return BitConverter.ToInt64(GetBytes(8, flag), 0);
        }
        /// <summary>
        /// 读取string类型数据，并后移流位置
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetString(Encoding code = null)
        {
            if (code == null)
            {
                code = Encoding.Default;
            }
            short len = GetInt16();
            return code.GetString(GetBytes(len));
        }
        /// <summary>
        /// 读取DateTime类型数据，并后移流位置
        /// </summary>
        /// <returns></returns>
        public DateTime GetTime()
        {
            int unixTime = GetInt32();
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long longTime = long.Parse(string.Format("{0}{0:d17}",unixTime).Remove(17));
            TimeSpan nowSpan = new TimeSpan(longTime);
            DateTime retTime = startTime.Add(nowSpan);
            return retTime;
        }
        /// <summary>
        /// 读取一个对象的数据，并后移流位置
        /// </summary>
        /// <returns></returns>
        public byte[] GetObject()
        {
            short len = GetInt16();
            return GetBytes(len);
        }

        /// <summary>
		/// 获取指定位数的 byte[], 并把游标向后移动指定长度
		/// </summary>
		/// <param name="len">长度</param>
		/// <param name="isReverse">是否反转, 默认: False</param>
		/// <returns></returns>
		public byte[] GetBytes(int len, bool isReverse = false)
        {
            byte[] temp = new byte[len];
            Buffer.BlockCopy(_byteData, _startIndex, temp, 0, len);
            _startIndex += len;
            return isReverse == true ? temp.Reverse().ToArray() : temp;
        }
    }
}
