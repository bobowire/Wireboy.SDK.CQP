using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Models;

namespace Wireboy.SDK.CQP.Core.Models
{
    /// <summary>
    /// 陌生人信息
    /// </summary>
    public class StrangerInfo: SdkModelBase
    {
        /// <summary>
        /// QQ号
        /// </summary>
        [QQJson(1)]
        public long QQ { set; get; }
        /// <summary>
        /// 昵称
        /// </summary>
        [QQJson(2)]
        public string NickName { set; get; }
        /// <summary>
        /// 性别
        /// </summary>
        [QQJson(3)]
        public Enums.Sex Sex { set; get; }
        /// <summary>
        /// 年龄
        /// </summary>
        [QQJson(4)]
        public int Age { set; get; }
    }
}
