namespace Wireboy.SDK.CQP.SdkEvents.Enums
{
    /// <summary>
    /// 私聊消息来源
    /// </summary>
    public enum PrivateMessageType
    {
        /// <summary>
        /// 未知来源
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 好友
        /// </summary>
        Friend = 11,

        /// <summary>
        /// 在线状态
        /// </summary>
        Online = 1,

        /// <summary>
        /// 群
        /// </summary>
        Group = 2,

        /// <summary>
        /// 讨论组
        /// </summary>
        DiscussGroup = 3
    }
}