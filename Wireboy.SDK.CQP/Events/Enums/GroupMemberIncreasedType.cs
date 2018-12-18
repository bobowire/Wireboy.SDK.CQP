namespace Wireboy.SDK.CQP.Events.Enums
{
    /// <summary>
    /// 群成员增加原因
    /// </summary>
    public enum GroupMemberIncreasedType
    {
        /// <summary>
        /// 未知原因
        /// </summary>
        Unknow = 0,

        /// <summary>
        /// 管理员批准入群
        /// </summary>
        AdminAllowed = 1,

        /// <summary>
        /// 群成员邀请
        /// </summary>
        GroupMemberInvitated = 2,
    }
}