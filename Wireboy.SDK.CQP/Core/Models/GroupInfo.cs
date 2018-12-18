using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Models;

namespace Wireboy.SDK.CQP.Core.Models
{
    /// <summary>
    /// QQ群信息
    /// </summary>
    public class GroupInfo: SdkModelBase
    {
        /// <summary>
        /// 群号码
        /// </summary>
        [QQJson(1)]
        public long GroupNumber { set; get; }
        /// <summary>
        /// 群名称
        /// </summary>
        [QQJson(2)]
        public string GroupName { set; get; }
    }
}
