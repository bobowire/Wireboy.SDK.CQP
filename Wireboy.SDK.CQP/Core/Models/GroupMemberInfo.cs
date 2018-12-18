using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Models;

namespace Wireboy.SDK.CQP.Core.Models
{
    /// <summary>
    /// QQ群成员信息
    /// </summary>
    public class GroupMemberInfo: SdkModelBase
    {
        /// <summary>
        /// QQ群号
        /// </summary>
        [QQJson(1)]
        public long Group { set; get; }
        /// <summary>
        /// QQ号
        /// </summary>
        [QQJson(2)]
        public long QQ { set; get; }
        /// <summary>
        /// 昵称
        /// </summary>
        [QQJson(3)]
        public string NickName { set; get; }
        /// <summary>
        /// 群名片
        /// </summary>
        [QQJson(4)]
        public string GroupCard { set; get; }
        /// <summary>
        /// 性别
        /// </summary>
        [QQJson(5)]
        public Enums.Sex Sex { set; get; }
        /// <summary>
        /// 年龄
        /// </summary>
        [QQJson(6)]
        public int Age { set; get; }
        /// <summary>
        /// 地区
        /// </summary>
        [QQJson(7)]
        public string Area { set; get; }
        /// <summary>
        /// 加群时间
        /// </summary>
        [QQJson(8)]
        public DateTime JoinGroupTime { set; get; }
        /// <summary>
        /// 最后发言时间
        /// </summary>
        [QQJson(9)]
        public DateTime LastSayTime { set; get; }
        /// <summary>
        /// 等级_名称
        /// </summary>
        [QQJson(10)]
        public string LevelName { set; get; }
        /// <summary>
        /// 管理权限（群主、管理员、成员）
        /// </summary>
        [QQJson(11)]
        public Enums.GroupMemberType GroupMemberType { set; get; }
        /// <summary>
        /// 不良记录成员
        /// </summary>
        [QQJson(12)]
        public bool HasBadRecord { set; get; }
        /// <summary>
        /// 专属头衔
        /// </summary>
        [QQJson(13)]
        public string PersionalNickName { set; get; }
        /// <summary>
        /// 专属头衔过期时间
        /// </summary>
        [QQJson(14)]
        public DateTime PersionalNickNameTime { set; get; }
        /// <summary>
        /// 允许修改名片
        /// </summary>
        [QQJson(15)]
        public bool AllowChangeGroupCard { set; get; }
    }
}
